using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ispda.Properties;
using MySql.Data.MySqlClient;

namespace ispda.Entities
{
    internal class Connection
    {

        public static MySqlConnection connection;
        public static MySqlCommand command = new MySqlCommand();
        public static MySqlDataAdapter adapter;
        public static bool isOpen = false;


        public static bool Open()
        {
            try
            {
                string[] str = Settings.Default.connect_string.Split(';');
                string connectString = $@"database = {str[0]};
                                   datasource = {str[1]};
                                   user = {str[2]}; password = {str[3]};
                                   charset = utf8mb4;";
                connection = new MySqlConnection(connectString);
                connection.Open();
                command.Connection = connection;
                adapter = new MySqlDataAdapter(command);
                isOpen = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Close()
        {
            try
            {
                connection.Close();
                isOpen = false;
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
