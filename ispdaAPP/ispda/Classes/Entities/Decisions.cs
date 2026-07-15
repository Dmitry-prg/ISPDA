using ispda.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ispda.Classes.Entities
{
    internal class Decisions
    {
        public static DataTable dtList = new DataTable();
        public static DataTable dtListForComboBox = new DataTable();


        public static void GetList()
        {
            try
            {
                Connection.command.CommandText = "SELECT decision_id, decision_name, if(is_active, 'Да', 'Нет') as is_active FROM decisions ORDER BY decision_name";
                dtList.Clear();
                Connection.adapter.Fill(dtList);
            }
            catch(Exception ex) { Mes.Error(ex.Message); }
        }

        public static void GetListForComboBox()
        {
            try
            {
                Connection.command.CommandText = "SELECT * FROM decisions WHERE is_active = '1' ORDER BY decision_name";
                dtListForComboBox.Clear();
                Connection.adapter.Fill(dtListForComboBox);
            }
            catch (Exception ex) { Mes.Error(ex.Message); }
        }


        public static bool Add(string name, bool isActive)
        {
            try
            {
                Connection.command.CommandText = $@"
INSERT INTO decisions VALUES(null, '{name}', '{Convert.ToInt16(isActive)}');";
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
UPDATE decisions 
SET decision_name = '{name}', 
    is_active = '{Convert.ToInt16(isActive)}'
WHERE decision_id = '{id}';";
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
DELETE FROM decisions WHERE decisions_id = '{id}';";
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
SELECT decision_name FROM decisions WHERE decision_name = '{name}';";
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
