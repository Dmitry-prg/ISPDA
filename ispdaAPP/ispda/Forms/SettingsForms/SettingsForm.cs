using ispda.Entities;
using ispda.Forms.InfoForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ispda.Forms.Settings
{
    public partial class SettingsForm : Form
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                InformationForm form = new InformationForm();
                form.ShowDialog();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public SettingsForm()
        {
            InitializeComponent();
        }
        private static string database;
        private static string datasource;
        private static string user;
        private static string password;

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            try
            {
                string[] str = Properties.Settings.Default.connect_string.Split(';');
                database = str[0];
                datasource = str[1];
                user = str[2];
                password = str[3];

                txtDatabase.Text = database;
                txtDatasource.Text = datasource;
                txtUser.Text = user;
                txtPassword.Text = password;
            }
            catch { }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDatabase.Text != database || txtDatasource.Text != datasource || txtUser.Text != user || txtPassword.Text != password)
                {
                    if(txtDatabase.Text != string.Empty && txtDatasource.Text != string.Empty && txtUser.Text != string.Empty && txtPassword.Text != string.Empty)
                    {
                        Properties.Settings.Default.connect_string = txtDatabase.Text.Trim() + ";"+ txtDatasource.Text.Trim() + ";"+ txtUser.Text.Trim() + ";"+ txtPassword.Text.Trim();
                        Properties.Settings.Default.Save();
                        Mes.Info("Изменения успешно сохранены");
                        this.Close();
                    }
                    else
                    {
                        Mes.Warning("Заполните все поля");
                    }
                }
                else
                {
                    Mes.Warning("Не было внесено изменений\r\nНевозможно сохранить");
                }
            }
            catch { }
        }

        private void txtDatabase_TextChanged(object sender, EventArgs e)
        {
            if (txtDatabase.Text != database || txtDatasource.Text != datasource || txtUser.Text != user || txtPassword.Text != password)
            {
                btnApply.Enabled = true;
            }
            else
            {
                btnApply.Enabled = false;
            }
        }
    }
}
