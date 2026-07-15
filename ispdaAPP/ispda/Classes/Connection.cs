using ispda.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                   logging = true;
                                   charset = utf8mb4;";
                connection = new MySqlConnection(connectString);
                MySqlTrace.Switch.Level = SourceLevels.Warning;
                MySqlTrace.Listeners.Add(new TextWriterTraceListener("ispda_log.txt"));
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

        public static async Task Import(string filePath)
        {
            try
            {
                string[] str = Settings.Default.connect_string.Split(';');
                string connectString = $@"database = {str[0]};
                                   datasource = {str[1]};
                                   user = {str[2]}; password = {str[3]};
                                   charset = utf8mb4;";
                using (var conn = new MySqlConnection(connectString))
                using (var cmd = conn.CreateCommand())
                using (var mb = new MySqlBackup(cmd))
                {
                    try
                    {
                        conn.Open();
                        mb.ImportFromFile(filePath);
                        conn.Close();
                    }

                    catch (Exception ex)
                    {
                        Mes.Error(ex.Message);
                    }
                }
            }
            catch
            {
            }
        }
        public static async Task Export(string filePath)
        {
            try
            {
                string[] str = Settings.Default.connect_string.Split(';');
                string connectString = $@"database = {str[0]};
                                   datasource = {str[1]};
                                   user = {str[2]}; password = {str[3]};
                                   charset = utf8mb4;";
                using (var conn = new MySqlConnection(connectString))
                using (var cmd = conn.CreateCommand())
                using (var mb = new MySqlBackup(cmd))
                {
                    try
                    {
                        conn.Open();
                        mb.ExportToFile(filePath);
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        Mes.Error(ex.Message);
                    }
                }



            }
            catch
            {
            }
        }

    }
}
