using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ispda.Entities
{
    internal class Users
    {

        public static string id;
        public static string name;
        public static string role;


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
    }
}
