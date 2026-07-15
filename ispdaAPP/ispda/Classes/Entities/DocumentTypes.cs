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
    internal class DocumentTypes
    {

        public static DataTable dtList = new DataTable();
        public static DataTable dtListForComboBox = new DataTable();


        public static void GetList()
        {
            try
            {
                Connection.command.CommandText = $"SELECT document_type_id, document_type_name, if(is_active, 'Да', 'Нет') as is_active FROM document_types WHERE ({ViewReferenceForm.search})ORDER BY document_type_name";
                dtList.Clear();
                Connection.adapter.Fill(dtList);
            }
            catch (Exception ex) { Mes.Error(ex.Message); }
        }

        public static void GetListForComboBox()
        {
            try
            {
                Connection.command.CommandText = "SELECT * FROM document_types WHERE is_active = '1' ORDER BY document_type_name";
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
INSERT INTO document_types VALUES(null, '{name}', '{Convert.ToInt16(isActive)}');";
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
UPDATE document_types 
SET document_type_name = '{name}', 
    is_active = '{Convert.ToInt16(isActive)}'
WHERE document_type_id = '{id}';";
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
DELETE FROM document_types WHERE document_type_id = '{id}';";
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
SELECT document_type_name FROM document_types WHERE document_type_name = '{name}';";
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
