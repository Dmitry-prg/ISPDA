using DocumentFormat.OpenXml.Spreadsheet;
using ispda.Classes;
using ispda.Entities;
using ispda.Forms;
using ispda.Forms.ControlsForms;
using ispda.Forms.InfoForm;
using ispda.Forms.UsersForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ispda.Forms
{
    public partial class ViewUsersForm : Form
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

        public ViewUsersForm()
        {
            InitializeComponent();
        }

        private void UpdateData()
        {
            Entities.Users.GetList();
            dataGridViewUsers.DataSource = Entities.Users.dtList;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ViewUsersForm_Load(object sender, EventArgs e)
        {
            if (Entities.Users.role == "2")
                menuStripUsers.Visible = false;
            else
                menuStripUsers.Visible = true;
            UpdateData();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAndUpdateUserForm addAndUpdateUserForm = new AddAndUpdateUserForm(false);
            addAndUpdateUserForm.ShowDialog();
            UpdateData();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridViewUsers.SelectedRows.Count == 1)
            {
                AddAndUpdateUserForm.id = dataGridViewUsers.CurrentRow.Cells["user_id"].Value.ToString();
                AddAndUpdateUserForm.login = dataGridViewUsers.CurrentRow.Cells["login"].Value.ToString();
                AddAndUpdateUserForm.password = Entities.Users.GetPassword(dataGridViewUsers.CurrentRow.Cells["user_id"].Value.ToString());
                AddAndUpdateUserForm.lastName = dataGridViewUsers.CurrentRow.Cells["last_name"].Value.ToString();
                AddAndUpdateUserForm.firstName = dataGridViewUsers.CurrentRow.Cells["first_name"].Value.ToString();
                AddAndUpdateUserForm.patronymic = dataGridViewUsers.CurrentRow.Cells["patronymic"].Value.ToString();
                AddAndUpdateUserForm.organizationId = dataGridViewUsers.CurrentRow.Cells["organization_id"].Value.ToString();
                AddAndUpdateUserForm.positionId = dataGridViewUsers.CurrentRow.Cells["position_id"].Value.ToString();
                AddAndUpdateUserForm.roleId = dataGridViewUsers.CurrentRow.Cells["role_id"].Value.ToString();
                AddAndUpdateUserForm.email = dataGridViewUsers.CurrentRow.Cells["email"].Value.ToString();
                AddAndUpdateUserForm.phone = dataGridViewUsers.CurrentRow.Cells["phone"].Value.ToString();
                if (dataGridViewUsers.CurrentRow.Cells["is_active"].Value.ToString() == "Да")
                    AddAndUpdateUserForm.isActive = true;
                else
                    AddAndUpdateUserForm.isActive = false;

                if (dataGridViewUsers.CurrentRow.Cells["is_superuser"].Value.ToString() == "Да")
                    AddAndUpdateUserForm.isSuperuser = true;
                else
                    AddAndUpdateUserForm.isSuperuser = false;


                AddAndUpdateUserForm addAndUpdateUserForm = new AddAndUpdateUserForm(true);
                addAndUpdateUserForm.ShowDialog();
                UpdateData();
            }
            else
            {
                Mes.Warning("Выберите одного пользователя, у которого необходимо изменить информацию");
            }
        }

        private void настроитьОтображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingViewGridForm settingViewGridForm = new SettingViewGridForm(dataGridViewUsers);
            settingViewGridForm.ShowDialog();
            var columns = SettingViewGridForm.columns;
            foreach (DataGridViewColumn column in dataGridViewUsers.Columns)
            {
                if (columns.ContainsKey(column.Name))
                {
                    column.Visible = columns[column.Name];
                }
            }
        }

        private void выгрузитьВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Dictionary<string, string> data = new Dictionary<string, string>();

                if (Doc.CreateExcelFromDataTable(Doc.GetDataTableFromDataGridView(dataGridViewUsers), saveFileDialog.FileName, $"Users_for_{DateTime.Now:dd_MM_yyyy}", "Список пользователей", data))
                {
                    Mes.Info("Файл excel успешно сформирован и сохранён");
                }
                else
                {
                    Mes.Error("Не удалось сформировать файл excel");
                }
            }
        }

        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewUsers.Columns["btnDel"].Index == e.ColumnIndex)
            {
                string login = dataGridViewUsers.Rows[e.RowIndex].Cells["login"].Value.ToString();
                string id = dataGridViewUsers.Rows[e.RowIndex].Cells["user_id"].Value.ToString();
                if (Mes.Question($"Вы действительно хотите безвозвратно удалить всю информацию о пользователе с логином '{login}' ?") == DialogResult.OK)
                {
                    if (Entities.Users.CheckDel(id))
                    {
                        if (Entities.Users.Del(id))
                        {
                            Mes.Info("Информация о пользователе успешно удалена");
                            UpdateData();
                        }
                        else
                        {
                            Mes.Error("Не получилось удалить информацию о пользователе");
                        }
                    }
                    else
                    {
                        Mes.Warning("Нельзя удалить информацию о пользователе, который находится в составе проектной команды");

                    }

                }
            }
        }
    }
}
