using ispda.Classes;
using ispda.Classes.Entities;
using ispda.Entities;
using ispda.Forms.ControlsForms;
using ispda.Forms.InfoForm;
using ispda.Forms.UsersForms;
using ispda.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ispda.Forms.Projects
{
    public partial class ViewProjectsForm : Form
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                InformationForm.item = "projects";
                InformationForm form = new InformationForm();
                form.ShowDialog();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public ViewProjectsForm()
        {
            InitializeComponent();
        }
        private void UpdateData()
        {
            Classes.Entities.Projects.GetList();
            dataGridViewProject.DataSource = Classes.Entities.Projects.dtProjects;
            saveFileDialog.FileName = "projects_for_" + DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void новыйПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAndUpdateProjectForm addProjectForm = new AddAndUpdateProjectForm(false);
            addProjectForm.ShowDialog();

            Statuses.GetListForComboBox();
            comboBoxStatus.DataSource = Statuses.dtListForComboBox;
            comboBoxStatus.DisplayMember = "status_name";
            comboBoxStatus.ValueMember = "status_id";

            Organizations.GetListForComboBox();
            comboBoxCustomer.DataSource = Organizations.dtListForComboBox;
            comboBoxCustomer.DisplayMember = "name";
            comboBoxCustomer.ValueMember = "organization_id";
            UpdateData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewProjectsForm_Load(object sender, EventArgs e)
        {
            if (Users.role == "2")
                menuStripProject.Visible = false;
            else
                menuStripProject.Visible = true;

            dateStart.Value = new DateTime(dateStart.Value.Year, 1, 1);
            dateEnd.Value = new DateTime(DateTime.Now.Year, 12, 31);
            Classes.Entities.Projects.dateStart = dateStart.Value.ToString("yyyy-MM-dd");
            Classes.Entities.Projects.dateEnd = dateEnd.Value.ToString("yyyy-MM-dd");

            Statuses.GetListForComboBox();
            comboBoxStatus.DataSource = Statuses.dtListForComboBox;
            comboBoxStatus.DisplayMember = "status_name";
            comboBoxStatus.ValueMember = "status_id";

            Organizations.GetListForComboBox();
            comboBoxCustomer.DataSource = Organizations.dtListForComboBox;
            comboBoxCustomer.DisplayMember = "name";
            comboBoxCustomer.ValueMember = "organization_id";

            UpdateData();
        }
        

        private void выгрузитьВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add($"С {Convert.ToDateTime(Classes.Entities.Projects.dateStart):dd.MM.yyyy}", $"По {Convert.ToDateTime(Classes.Entities.Projects.dateEnd):dd.MM.yyyy}");
          
                if (Classes.Entities.Projects.filterSql1 != "true")
                {
                    data.Add("Заказчик", comboBoxCustomer.Text);
                }
                if (Classes.Entities.Projects.filterSql2 != "true")
                {
                    data.Add("Статус", comboBoxStatus.Text);
                }

                if (Doc.CreateExcelFromDataTable(Doc.GetDataTableFromDataGridView(dataGridViewProject), saveFileDialog.FileName, $"Projects_for_{DateTime.Now:dd_MM_yyyy}", "Список проектов", data))
                {
                    Mes.Info("Файл excel успешно сформирован и сохранён");
                }
                else
                {
                    Mes.Error("Не удалось сформировать файл excel");
                }
            }
        }

        private void dataGridViewProject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                if (dataGridViewProject.Columns["btnOptions"].Index == e.ColumnIndex)
                {
                    RoadMapForProject.id = dataGridViewProject.Rows[e.RowIndex].Cells["project_id"].Value.ToString();
                    RoadMapForProject.projectStart = Convert.ToDateTime(dataGridViewProject.Rows[e.RowIndex].Cells["start_date"].Value);
                    RoadMapForProject.projectEnd = Convert.ToDateTime(dataGridViewProject.Rows[e.RowIndex].Cells["end_date"].Value);
                    RoadMapForProject.number = dataGridViewProject.Rows[e.RowIndex].Cells["project_number"].Value.ToString();
                    RoadMapForProject roadMapForProject = new RoadMapForProject();
                    roadMapForProject.ShowDialog();
                    UpdateData();
                }
                if (dataGridViewProject.Columns["btnDel"].Index == e.ColumnIndex)
                {
                    string number = dataGridViewProject.Rows[e.RowIndex].Cells["project_number"].Value.ToString();
                    string id = dataGridViewProject.Rows[e.RowIndex].Cells["project_id"].Value.ToString();
                    if (Mes.Question($"Вы действительно хотите безвозвратно удалить всю информацию о проекте с номером '{number}' ?") == DialogResult.OK)
                    {
                        if (Classes.Entities.Projects.CheckDel(id))
                        {
                            if (Classes.Entities.Projects.Del(id))
                            {
                                Mes.Info("Информация о проекте успешно удалена");
                                UpdateData();
                            }
                            else
                            {
                                Mes.Error("Не получилось удалить информацию о проекте");
                            }
                        }
                        else
                        {
                            Mes.Warning("Нельзя удалить информацию о проекте, который уже находится в работе");

                        }

                    }
                }
            }
            
        }

        private void comboBoxCustomer_SelectionChangeCommitted(object sender, EventArgs e)
        {
                Classes.Entities.Projects.filterSql1 = $@"customer.organization_id = {comboBoxCustomer.SelectedValue}";
            UpdateData();
        }

        private void comboBoxStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Classes.Entities.Projects.filterSql2 = $@"projects.status_id = {comboBoxStatus.SelectedValue}";
            UpdateData();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewProject.SelectedRows.Count == 1)
            {
                AddAndUpdateProjectForm.projectId = dataGridViewProject.CurrentRow.Cells["project_id"].Value.ToString();
                AddAndUpdateProjectForm.projectNumber = dataGridViewProject.CurrentRow.Cells["project_number"].Value.ToString();
                AddAndUpdateProjectForm.projectName = dataGridViewProject.CurrentRow.Cells["project_name"].Value.ToString();
                AddAndUpdateProjectForm.projectShortName = dataGridViewProject.CurrentRow.Cells["project_short_name"].Value.ToString();
                AddAndUpdateProjectForm.developerId = dataGridViewProject.CurrentRow.Cells["developer_id"].Value.ToString();
                AddAndUpdateProjectForm.initiativeRequestId = dataGridViewProject.CurrentRow.Cells["initiative_request_id"].Value.ToString();
                AddAndUpdateProjectForm.customerId = dataGridViewProject.CurrentRow.Cells["customer_id"].Value.ToString();
                AddAndUpdateProjectForm.productName = dataGridViewProject.CurrentRow.Cells["product_name"].Value.ToString();
                AddAndUpdateProjectForm.productNameGenitive = dataGridViewProject.CurrentRow.Cells["product_name_genitive"].Value.ToString();
                AddAndUpdateProjectForm.productNamePrepositional = dataGridViewProject.CurrentRow.Cells["product_name_prepositional"].Value.ToString();
                AddAndUpdateProjectForm.productShortName = dataGridViewProject.CurrentRow.Cells["product_short_name"].Value.ToString();
                AddAndUpdateProjectForm.startDate = dataGridViewProject.CurrentRow.Cells["start_date"].Value.ToString();
                AddAndUpdateProjectForm.endDate = dataGridViewProject.CurrentRow.Cells["end_date"].Value.ToString();
                AddAndUpdateProjectForm.url = dataGridViewProject.CurrentRow.Cells["url"].Value.ToString();
                AddAndUpdateProjectForm.ip = dataGridViewProject.CurrentRow.Cells["ip"].Value.ToString();
                AddAndUpdateProjectForm.adminPanelUrl = dataGridViewProject.CurrentRow.Cells["admin_panel_url"].Value.ToString();


                if (dataGridViewProject.CurrentRow.Cells["is_gis"].Value.ToString() == "Да")
                    AddAndUpdateProjectForm.isGis = true;
                else
                    AddAndUpdateProjectForm.isGis = false;
                if (dataGridViewProject.CurrentRow.Cells["is_pnd"].Value.ToString() == "Да")
                    AddAndUpdateProjectForm.isPnd = true;
                else
                    AddAndUpdateProjectForm.isPnd = false;
                if (dataGridViewProject.CurrentRow.Cells["is_internal"].Value.ToString() == "Да")
                    AddAndUpdateProjectForm.isInternal = true;
                else
                    AddAndUpdateProjectForm.isInternal = false;

                AddAndUpdateProjectForm.notes = dataGridViewProject.CurrentRow.Cells["notes"].Value.ToString();
                AddAndUpdateProjectForm.statusId = dataGridViewProject.CurrentRow.Cells["status_id"].Value.ToString();


                AddAndUpdateProjectForm addProjectForm = new AddAndUpdateProjectForm(true);
                addProjectForm.ShowDialog();
                UpdateData();
            }
            else if (dataGridViewProject.SelectedRows.Count > 1)
                Mes.Warning("Выберите один проект для изменения");
            else
                Mes.Warning("Выберите проект, в который нужно внести изменения");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Classes.Entities.Projects.searchSql = "true";
            Classes.Entities.Projects.filterSql1 = "true";
            Classes.Entities.Projects.filterSql2 = "true";
            comboBoxCustomer.SelectedIndex = 0;
            comboBoxStatus.SelectedIndex = 0;
            UpdateData();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string txt = txtSearch.Text;
            if(txt.Length > 0)
            {
                Classes.Entities.Projects.searchSql = $@"
projects.project_number LIKE '%{txt}%' or 
projects.project_name LIKE '%{txt}%' or
projects.project_short_name LIKE '%{txt}%' or
projects.product_name LIKE '%{txt}%' or
projects.product_short_name LIKE '%{txt}%' or
projects.notes LIKE '%{txt}%' or
projects.project_number LIKE '%{txt}%'";
            }
            else
            {
                Classes.Entities.Projects.searchSql = "true";
            }
            UpdateData();
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            if(dateStart.Value > dateEnd.Value) 
                dateEnd.Value = dateStart.Value;
            Classes.Entities.Projects.dateStart = dateStart.Value.ToString("yyyy-MM-dd");
            Classes.Entities.Projects.dateEnd = dateEnd.Value.ToString("yyyy-MM-dd");
            UpdateData();
        }

        private void настроитьОтображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SettingViewGridForm settingViewGridForm = new SettingViewGridForm(dataGridViewProject);
            settingViewGridForm.ShowDialog();
            var columns = SettingViewGridForm.columns;
            foreach (DataGridViewColumn column in dataGridViewProject.Columns)
            {
                if (columns.ContainsKey(column.Name))
                {
                    column.Visible = columns[column.Name];
                } 
            }
            
        }
    }
}
