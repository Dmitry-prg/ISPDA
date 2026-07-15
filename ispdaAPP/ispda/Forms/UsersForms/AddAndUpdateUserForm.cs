using ispda.Classes.Entities;
using ispda.Entities;
using ispda.Forms.InfoForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ispda.Forms.UsersForms
{
    public partial class AddAndUpdateUserForm : Form
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

        public static string id;
        public static string login;
        public static string password;
        public static string lastName;
        public static string firstName;
        public static string patronymic;
        public static string organizationId;
        public static string positionId;
        public static string roleId;
        public static string email;
        public static string phone;
        public static bool isActive;
        public static bool isSuperuser;
        public static bool edit;





        public AddAndUpdateUserForm(bool update)
        {
            InitializeComponent();
            edit = update;
            if(edit)
            {
                Text = "Изменение информации о пользователе";
            }
            else
            {
                Text = "Добавление информации о пользователе";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtLogin.Text != string.Empty && txtPassword.Text != string.Empty && txtLastName.Text != string.Empty && txtFirstName.Text != string.Empty && txtEmail.Text != string.Empty)
            {
                if (edit)
                {
                    if (Users.CheckDuplicateLogin(txtLogin.Text) || txtLogin.Text == login)
                    {
                        if (Users.IsValidEmail(txtEmail.Text))
                        {
                            if (Users.CheckDuplicateEmail(txtEmail.Text) || txtEmail.Text == email)
                            {
                                if (Users.Update(id, txtLogin.Text, txtPassword.Text, txtLastName.Text, txtFirstName.Text, txtPatronymic.Text, comboBoxOrganization.SelectedValue.ToString(), comboBoxPosition.SelectedValue.ToString(), comboBoxRole.SelectedValue.ToString(), txtEmail.Text, txtPhone.Text,
                                    checkBoxIsActive.Checked, checkBoxIsSuperuser.Checked))
                                {
                                    Mes.Info("Информация о пользователе успешно изменена");
                                    this.Close();
                                }
                                else
                                {
                                    Mes.Error("Не получилось изменить информацию о пользователе");
                                }
                            }
                            else
                            {
                                Mes.Warning($"Пользователь с email '{txtEmail.Text}' уже существует");
                            }
                        }
                        else
                        {
                            Mes.Warning("Некорректный email");
                        }
                    }
                    else
                    {
                        Mes.Warning($"Пользователь с логином '{txtLogin.Text}' уже существует");
                    }
                }
                else
                {
                    if (Users.CheckDuplicateLogin(txtLogin.Text))
                    {
                        if (Users.IsValidEmail(txtEmail.Text))
                        {
                            if (Users.CheckDuplicateEmail(txtEmail.Text))
                            {
                                if (Users.Add(txtLogin.Text, txtPassword.Text, txtLastName.Text, txtFirstName.Text, txtPatronymic.Text, comboBoxOrganization.SelectedValue.ToString(), comboBoxPosition.SelectedValue.ToString(), comboBoxRole.SelectedValue.ToString(), txtEmail.Text, txtPhone.Text,
                                checkBoxIsActive.Checked, checkBoxIsSuperuser.Checked))
                                {
                                    Mes.Info("Информация о пользователе успешно добавлена");
                                    this.Close();
                                }
                                else
                                {
                                    Mes.Error("Не получилось добавить информацию о пользователе");
                                }
                            }
                            else
                            {
                                Mes.Warning($"Пользователь с email '{txtEmail.Text}' уже существует");
                            }
                        }
                        else
                        {
                            Mes.Warning("Некорректный email");
                        }
                    }
                    else
                    {
                        Mes.Warning($"Пользователь с логином '{txtLogin.Text}' уже существует");
                    }
                }
            }
            else
            {
                Mes.Warning("Заполните обязательные поля");
            }
        }

        private void AddAndUpdateUserForm_Load(object sender, EventArgs e)
        {
            
            Organizations.GetListForComboBox();
            comboBoxOrganization.DataSource = Organizations.dtListForComboBox;
            comboBoxOrganization.DisplayMember = "name";
            comboBoxOrganization.ValueMember = "organization_id";

            Positions.GetListForComboBox();
            comboBoxPosition.DataSource = Positions.dtListForCombobox;
            comboBoxPosition.DisplayMember = "position_name";
            comboBoxPosition.ValueMember = "position_id";


            Roles.GetListForComboBox();
            comboBoxRole.DataSource = Roles.dtListForCombobox;
            comboBoxRole.DisplayMember = "role_name";
            comboBoxRole.ValueMember = "role_id";


            if (edit)
            {
                txtLogin.Text = login;
                txtPassword.Text = password;
                txtFirstName.Text = firstName;
                txtLastName.Text = lastName;
                txtPatronymic.Text = patronymic;
                txtEmail.Text = email;
                txtPhone.Text = phone;
                checkBoxIsActive.Checked = isActive;
                checkBoxIsSuperuser.Checked = isSuperuser;
                comboBoxOrganization.SelectedValue = organizationId;
                comboBoxPosition.SelectedValue = positionId;
                comboBoxRole.SelectedValue = roleId;

            }
            else
            {
                comboBoxOrganization.SelectedIndex = 0;
                comboBoxPosition.SelectedIndex = 0;
                comboBoxRole.SelectedIndex = 0;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
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
    }
}
