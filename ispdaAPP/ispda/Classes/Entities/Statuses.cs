using ispda.Entities;
using ispda.Forms.Reference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ispda.Classes.Entities
{
    internal class Statuses
    {
        public static DataTable dtList = new DataTable();
        public static DataTable dtListForComboBox = new DataTable();

        public static void GetList()
        {
            try
            {
                Connection.command.CommandText = $"SELECT status_id, status_name, if(is_active, 'Да', 'Нет') as is_active FROM statuses  WHERE ({ViewReferenceForm.search}) ORDER BY status_name";
                dtList.Clear();
                Connection.adapter.Fill(dtList);
            }
            catch { Mes.Error("Не удалось получить данные"); }
        }

        public static void GetListForComboBox()
        {
            try
            {
                Connection.command.CommandText = "SELECT * FROM statuses WHERE is_active = '1' ORDER BY status_name";
                dtListForComboBox.Clear();
                Connection.adapter.Fill(dtListForComboBox);
            }
            catch { Mes.Error("Не удалось получить данные"); }
        }

        public static bool Add(string name, bool isActive)
        {
            try
            {
                Connection.command.CommandText = $@"
INSERT INTO statuses VALUES(null, '{name}', '{Convert.ToInt16(isActive)}');";
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

        public static bool Update(string id, string name, bool isActive)
        {
            try
            {
                Connection.command.CommandText = $@"
UPDATE statuses 
SET status_name = '{name}', 
    is_active = '{Convert.ToInt16(isActive)}'
WHERE status_id = '{id}';";
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

        public static bool Del(string id)
        {
            try
            {
                Connection.command.CommandText = $@"
DELETE FROM statuses WHERE status_id = '{id}';";
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

        public static bool CheckDuplicate(string name)
        {
            try
            {
                Connection.command.CommandText = $@"
SELECT status_name FROM statuses WHERE status_name = '{name}';";
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
    }
}
