using ispda.Entities;
using ispda.Forms.InfoForm;
using ispda.Forms.Settings;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ispda.Forms.ControlsForms
{
    public partial class ProfileUserForm : Form
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

        public ProfileUserForm()
        {
            InitializeComponent();
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            string inputLast = Interaction.InputBox("Введите текущий пароль", "Проверка ");
            if (inputLast == txtPassword.Text)
            {
                string inputNew = Interaction.InputBox("Введите новый пароль", "Изменение ");
                if (inputNew.Trim() != txtPassword.Text && inputNew.Trim() != string.Empty)
                {
                    if (Users.SetNewPassord(inputNew))
                    {
                        Mes.Info("Пароль изменён");
                        txtPassword.Text = inputNew;
                    }
                    else
                    {
                        Mes.Error("Не удалось изменить пароль");
                    }
                }
                else
                {
                    Mes.Warning("Введённый пароль соответствует текущему или пустой");
                }

            }
            else
            {
                Mes.Warning("Вы ввели неверный пароль");
            }
        }

        private void ProfileUserForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (Users.isSuperUser)               
                    btnUpdatePassAdmin.Visible = true;
                else
                    btnUpdatePassAdmin.Visible = false;
                txtPassword.Text = Users.GetPassword(Users.id);
                txtLogin.Text = Users.GetLogin(Users.id);
                if (txtPassword.Text == null)
                    btnUpdatePassword.Enabled = false;
                else
                    btnUpdatePassword.Enabled = true;

                txtFio.Text = Users.name;
            }
            catch
            {
                Mes.Error("Не удалось получить данные");
                this.Close();
            }
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdatePassAdmin_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Введите текущий пароль администратора", "Проверка ");
            if (input == Properties.Settings.Default.code_access_admin)
            {
                string inputNew = Interaction.InputBox("Введите новый пароль администратора", "Изменение ");
                if (inputNew.Trim() != Properties.Settings.Default.code_access_admin && inputNew.Trim() != string.Empty)
                {
                    Properties.Settings.Default.code_access_admin = inputNew.Trim();
                    Mes.Info("Пароль администратора изменён");
                }
                else
                {
                    Mes.Warning("Введённый пароль соответствует текущему или пустой");
                }
            }
            else
            {
                
                Mes.Warning("Вы ввели неверный пароль");
            }
        }
    }
}
