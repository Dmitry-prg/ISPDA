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
    internal class StakeholderTypes
    {

        public static DataTable dtList = new DataTable();
        public static DataTable dtListForComboBox = new DataTable();


        public static void GetList()
        {
            try
            {
                Connection.command.CommandText = $"SELECT stakeholder_type_id, stakeholder_type_name, if(is_active, 'Да', 'Нет') as is_active FROM stakeholder_types WHERE ({ViewReferenceForm.search}) ORDER BY stakeholder_type_name";
                dtList.Clear();
                Connection.adapter.Fill(dtList);
            }
            catch { Mes.Error("Не удалось получить данные"); }
        }

        public static void GetListForComboBox()
        {
            try
            {
                Connection.command.CommandText = "SELECT * FROM stakeholder_types WHERE is_active = '1' ORDER BY stakeholder_type_name";
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
INSERT INTO stakeholder_types VALUES(null, '{name}', '{Convert.ToInt16(isActive)}');";
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
UPDATE stakeholder_types 
SET stakeholder_type_name = '{name}', 
    is_active = '{Convert.ToInt16(isActive)}'
WHERE stakeholder_type_id = '{id}';";
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
DELETE FROM stakeholder_types WHERE stakeholder_type_id = '{id}';";
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
SELECT stakeholder_type_name FROM stakeholder_types WHERE stakeholder_type_name = '{name}';";
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
