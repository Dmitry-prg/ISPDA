using ispda.Entities;
using ispda.Forms;
using ispda.Forms.InfoForm;
using ispda.Forms.Settings;
using Microsoft.VisualBasic;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ispda
{
    public partial class LoginForm : Form
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                InformationForm.item = "login";
                InformationForm form = new InformationForm();
                form.ShowDialog();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void panelLogInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxViewPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxViewPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtLogin.Text != string.Empty && txtPassword.Text != string.Empty)
            {
                if(Users.Login(txtLogin.Text, txtPassword.Text))
                {
                    if (Users.CheckStatus())
                    {
                        this.Hide();
                        MainMenuUserForm mainMenuUserForm = new MainMenuUserForm();
                        mainMenuUserForm.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        Mes.Warning("Отказано в доступе!\r\nОбратитесь к администратору для восстановления доступа");
                    }
                    
                }
                else
                {
                    Mes.Warning("Неверный логин или пароль");
                }
            }
            else
            {
                Mes.Warning("Заполните все поля");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage.License.SetNonCommercialOrganization("Dmitry");
                if (Connection.Open())
                {
                    labelStatus.Text = "Подключено";
                    labelStatus.ForeColor = Color.Green;
                    btnLogin.Enabled = true;
                }
                else
                {
                    labelStatus.Text = "Ошибка подключения";
                    labelStatus.ForeColor = Color.Red;
                    btnLogin.Enabled = false;
                }
                this.Hide();
                ScreenSaverForm screenSaverForm = new ScreenSaverForm();
                screenSaverForm.ShowDialog();
                this.Show();
            }
            catch { }
            
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Connection.Close();
            
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
           
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void настройкиПодключенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.ShowDialog();
            if (Connection.isOpen)
            {
                Connection.Close();
            }
            LoginForm_Load(sender, e);
        }

        private async void экспортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialogBD.ShowDialog() != DialogResult.OK)
                return;
            progressBar.Value = 0;
            timer.Start();
            try
            {
                await Connection.Export(saveFileDialogBD.FileName);
                Mes.Info("Успешно экспортированно");
            }
            catch
            {
                Mes.Error("Не получилось выполнить экспорт");
            }

        }

        private async void импортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogBD.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                progressBar.Value = 0;
                timer.Start();
                await Connection.Import(openFileDialogBD.FileName);
                Mes.Info("Успешно импортированно");
            }
            catch
            {
                Mes.Error("Не получилось выполнить импорт");
            }

        }

        private void btnSettings_DropDownOpening(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Введите пароль администратора", "Проверка ");
            if (input == Properties.Settings.Default.code_access_admin)
            {
                ((ToolStripDropDownItem)sender).DropDownItems[0].Visible = true;
                ((ToolStripDropDownItem)sender).DropDownItems[1].Visible = true;
            }
            else
            {
                ((ToolStripDropDownItem)sender).DropDownItems[0].Visible = false;
                ((ToolStripDropDownItem)sender).DropDownItems[1].Visible = false;
                Mes.Warning("Вы ввели неверный пароль");
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (progressBar.Value < progressBar.Maximum)
            {
                progressBar.Increment(10);
            }
            else
            {
                // Останавливаем таймер, когда прогресс завершён
                timer.Stop();
                progressBar.Value = 0;
            }
        }
    }
}
