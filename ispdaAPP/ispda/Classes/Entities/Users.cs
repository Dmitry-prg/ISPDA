using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ispda.Entities
{
    internal class Users
    {

        public static string id;
        public static string name;
        public static string role;
        public static bool isSuperUser;
        public static DataTable dtList = new DataTable();
        public static DataTable dtListForComboBox = new DataTable();


        public static bool Login(string login, string password)
        {
            try
            {
                Connection.command.CommandText = $@"Select * from users where login = '{login}' and password = '{password}';";
                var reader = Connection.command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        id = reader["user_id"].ToString();
                        name = reader["last_name"].ToString() + " " + reader["first_name"].ToString() + " " + reader["patronymic"].ToString();
                        role = reader["role_id"].ToString();
                        isSuperUser = reader.GetBoolean("is_superuser");
                        reader.Close();
                        return true;
                    }
                }
                reader.Close();
                id = null;
                name = null;
                role = null;
                return false;
            }
            catch
            {
                id = null;
                name = null;
                role = null;
                return false;
            }
        }

        public static string GetPassword(string id)
        {
            try
            {
                Connection.command.CommandText = $@"
SELECT password FROM users WHERE user_id = '{id}'";
                if (Connection.command.ExecuteScalar() == null)
                    return null;
                else
                    return Connection.command.ExecuteScalar().ToString();
            }
            catch
            {
                return null;
            }
        }
        public static string GetLogin(string id)
        {
            try
            {
                Connection.command.CommandText = $@"
SELECT login FROM users WHERE user_id = '{id}'";
                if (Connection.command.ExecuteScalar() == null)
                    return null;
                else
                    return Connection.command.ExecuteScalar().ToString();
            }
            catch
            {
                return null;
            }
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return mailAddress.Address == email;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool CheckDuplicateLogin(string login)
        {
            try
            {
                Connection.command.CommandText = $@"SELECT login FROM users WHERE login = '{login}'";

                if (Connection.command.ExecuteScalar() == null)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool CheckDuplicateEmail(string email)
        {
            try
            {
                Connection.command.CommandText = $@"SELECT email FROM users WHERE email = '{email}'";

                if (Connection.command.ExecuteScalar() == null)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool CheckStatus()
        {
            try
            {
                Connection.command.CommandText = $@"
SELECT if(is_active, 1, 0) from users where user_id = '{id}';";

            return Convert.ToBoolean(Connection.command.ExecuteScalar());
            }
            catch
            {
                return false;
            }
        }

        public static void GetList()
        {
            try
            {
                Connection.command.CommandText = $@"
SELECT 	users.user_id, 
		users.login,
		CONCAT(users.last_name, ' ', users.first_name, ' ', users.patronymic) as fio, 
        users.last_name, 
        users.first_name,
        users.patronymic,
        users.organization_id, 
        if(organizations.short_name is not null, organizations.short_name, organizations.full_name) as organization_name,
        users.position_id, 
        positions.position_name,
        users.role_id, 
        roles.role_name,
        users.email, 
        users.phone, 
        if(users.is_active, 'Да', 'Нет') as is_active,
		if(users.is_superuser, 'Да', 'Нет') as is_superuser
FROM users
LEFT JOIN positions ON positions.position_id = users.position_id
LEFT JOIN organizations ON organizations.organization_id = users.organization_id
LEFT JOIN roles ON roles.role_id = users.role_id

";
                dtList.Clear();
                Connection.adapter.Fill(dtList);
            }
            catch { Mes.Error("Не удалось получить данные"); }
        }

        public static void GetListForComboBox()
        {
            try
            {
                Connection.command.CommandText = $@"
SELECT 	users.user_id, 
		CONCAT(users.last_name, ' ', users.first_name, ' ', users.patronymic, ' | Проектов в работе: ', 
        (SELECT COUNT(project_teams.project_team_id)
        FROM project_teams 
        LEFT JOIN projects ON projects.project_id = project_teams.proejct_id 
        WHERE (project_teams.user_id = users.user_id AND projects.status_id = 9))  ) as fio       
FROM users
WHERE is_active = '1';";
                dtListForComboBox.Clear();
                Connection.adapter.Fill(dtListForComboBox);
            }
            catch { Mes.Error("Не удалось получить данные"); }
        }

        public static bool SetNewPassord(string password)
        {
            try
            {
                Connection.command.CommandText = $@"
UPDATE users 
SET password = '{password}' 
WHERE user_id = '{id}';";
                if (Connection.command.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool Add(string login, string password, string lastName, string firstName, string patronomic, string organizationId, string positionId, string roleId, string email, string phone, bool isActive, bool isSuperuser)
        {
            try
            {
                Connection.command.CommandText = $@"
INSERT INTO users VALUES(null, '{login}', '{password}', '{lastName}', '{firstName}', '{patronomic}', '{organizationId}', '{positionId}', '{roleId}', '{email}', '{phone}', '{Convert.ToInt16(isActive)}', '{Convert.ToInt16(isSuperuser)}', '{DateTime.Now:yyyy-MM-dd}', null);";
                if (Connection.command.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool Update(string id, string login, string password, string lastName, string firstName, string patronomic, string organizationId, string positionId, string roleId, string email, string phone, bool isActive, bool isSuperuser)
        {
            try
            {
                Connection.command.CommandText = $@"
UPDATE users 
SET login = '{login}', 
    password = '{password}', 
    last_name = '{lastName}', 
    first_name = '{firstName}', 
    patronymic = '{patronomic}', 
    organization_id = '{organizationId}', 
    position_id = '{positionId}', 
    role_id = '{roleId}', 
    email = '{email}', 
    phone = '{phone}', 
    is_active = '{Convert.ToInt16(isActive)}', 
    is_superuser = '{Convert.ToInt16(isSuperuser)}'
WHERE user_id = '{id}';";
                if (Connection.command.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool CheckDel(string id)
        {
            try
            {
                Connection.command.CommandText = $@"
SELECT user_id FROM project_teams WHERE user_id = '{id}';";
                if (Connection.command.ExecuteScalar() == null)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool Del(string id)
        {
            try
            {
                Connection.command.CommandText = $@"
DELETE FROM users WHERE user_id = '{id}';";
                if (Connection.command.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

    }
}
