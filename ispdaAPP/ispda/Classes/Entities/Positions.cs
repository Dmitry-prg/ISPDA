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
    internal class Positions
    {

        public static DataTable dtList = new DataTable();
        public static DataTable dtListForCombobox = new DataTable();


        public static void GetList()
        {
            try
            {
                Connection.command.CommandText = $"SELECT position_id, position_name, if(is_active, 'Да', 'Нет') as is_active FROM positions WHERE ({ViewReferenceForm.search})  ORDER BY position_name";
                dtList.Clear();
                Connection.adapter.Fill(dtList);
            }
            catch (Exception ex) { Mes.Error(ex.Message); }
        }

        public static void GetListForComboBox()
        {
            try
            {
                Connection.command.CommandText = "SELECT * FROM positions WHERE is_active = '1' ORDER BY position_name";
                dtListForCombobox.Clear();
                Connection.adapter.Fill(dtListForCombobox);
            }
            catch (Exception ex) { Mes.Error(ex.Message); }
        }


        public static bool Add(string name, bool isActive)
        {
            try
            {
                Connection.command.CommandText = $@"
INSERT INTO positions VALUES(null, '{name}', '{Convert.ToInt16(isActive)}');";
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
UPDATE positions 
SET position_name = '{name}', 
    is_active = '{Convert.ToInt16(isActive)}'
WHERE position_id = '{id}';";
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
DELETE FROM positions WHERE position_id = '{id}';";
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
SELECT position_name FROM positions WHERE position_name = '{name}';";
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
