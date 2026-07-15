using ispda.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ispda.Classes.Entities
{
    internal class Roles
    {
        public static DataTable dtListForCombobox = new DataTable();

        public static void GetListForComboBox()
        {
            try
            {
                Connection.command.CommandText = "SELECT * FROM roles ORDER BY role_name";
                dtListForCombobox.Clear();
                Connection.adapter.Fill(dtListForCombobox);
            }
            catch { Mes.Error("Не удалось получить данные"); }
        }
    }
}
