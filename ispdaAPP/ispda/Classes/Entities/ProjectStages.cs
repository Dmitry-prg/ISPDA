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
    internal class ProjectStages
    {
        public static DataTable dtList = new DataTable();
        public static DataTable dtListForComboBox = new DataTable();


        public static void GetList()
        {
            try
            {
                Connection.command.CommandText = $"SELECT stage_id, stage_name, description, if(is_active, 'Да', 'Нет') as is_active FROM project_stages WHERE ({ViewReferenceForm.search}) ORDER BY stage_name";
                dtList.Clear();
                Connection.adapter.Fill(dtList);
            }
            catch (Exception ex) { Mes.Error(ex.Message); }
        }

        public static void GetListForComboBox()
        {
            try
            {
                Connection.command.CommandText = "SELECT * FROM project_stages WHERE is_active = '1' ORDER BY stage_name";
                dtListForComboBox.Clear();
                Connection.adapter.Fill(dtListForComboBox);
            }
            catch (Exception ex) { Mes.Error(ex.Message); }
        }

        public static string GetDescriptionById(string id)
        {
            try
            {
                Connection.command.CommandText = $"SELECT description FROM project_stages WHERE is_active = '1' AND stage_id = '{id}';";
                if(Connection.command.ExecuteScalar() != null) 
                    return Connection.command.ExecuteScalar().ToString();
                else
                    return "";
            }
            catch (Exception ex) { Mes.Error(ex.Message); return ""; }
        }


        public static bool Add(string name, string description, bool isActive)
        {
            try
            {
                Connection.command.CommandText = $@"
INSERT INTO project_stages VALUES(null, '{name}', '{description}', '{Convert.ToInt16(isActive)}');";
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

        public static bool Update(string id, string name, string description, bool isActive)
        {
            try
            {
                Connection.command.CommandText = $@"
UPDATE project_stages 
SET stage_name = '{name}', 
    description = '{description}',
    is_active = '{Convert.ToInt16(isActive)}'
WHERE stage_id = '{id}';";
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
DELETE FROM project_stages WHERE stage_id = '{id}';";
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
SELECT stage_name FROM project_stages WHERE stage_name = '{name}';";
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
