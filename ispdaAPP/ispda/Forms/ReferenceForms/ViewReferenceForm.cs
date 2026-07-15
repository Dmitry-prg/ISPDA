using ispda.Classes.Entities;
using ispda.Entities;
using ispda.Forms.ControlsForms;
using ispda.Forms.InfoForm;
using ispda.Forms.ReferenceForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ispda.Forms.Reference
{
    public partial class ViewReferenceForm : Form
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

        public static string nameTable;
        public static string search = "true";

        public ViewReferenceForm()
        {
            InitializeComponent();
        }

        private void UpdateData()
        {
            switch (nameTable)
            {
                case "organizations":
                    {
                        Organizations.GetList();
                        dataGridView.DataSource = Organizations.dtList;
                        break;
                    }
                case "positions":
                    {
                        Positions.GetList();
                        dataGridView.DataSource = Positions.dtList;
                        break;
                    }
                case "project_stages":
                    {
                        ProjectStages.GetList();
                        dataGridView.DataSource = ProjectStages.dtList;
                        break;
                    }
                case "document_types":
                    {
                        DocumentTypes.GetList();
                        dataGridView.DataSource = DocumentTypes.dtList;
                        break;
                    }
                case "stakeholder_types":
                    {
                        StakeholderTypes.GetList();
                        dataGridView.DataSource = StakeholderTypes.dtList;
                        break;
                    }
                case "statuses":
                    {
                        Statuses.GetList();
                        dataGridView.DataSource = Statuses.dtList;
                        break;
                    }
                case "decisions":
                    {
                        Decisions.GetList();
                        dataGridView.DataSource = Decisions.dtList;
                        break;
                    }
            }
        }



        private void ViewReferenceForm_Load(object sender, EventArgs e)
        {
            if(Users.role == "2")
                menuStripReference.Visible = false;
            else
                menuStripReference.Visible = true;
            switch (nameTable)
                {
                    case "organizations":
                        {
                            Text += "Организации";
                            dataGridView.Columns["id"].DataPropertyName = "organization_id";
                            dataGridView.Columns["name"].DataPropertyName = "full_name";
                            dataGridView.Columns["short_name"].Visible = true;
                            dataGridView.Columns["ogrn"].Visible = true;
                            dataGridView.Columns["inn"].Visible = true;
                            dataGridView.Columns["kpp"].Visible = true;
                            dataGridView.Columns["legal_address"].Visible = true;
                            dataGridView.Columns["phone"].Visible = true;
                            dataGridView.Columns["email"].Visible = true;
                            this.WindowState = FormWindowState.Maximized;
                            break;
                        }
                    case "positions":
                        {
                            Text += "Должности";
                            dataGridView.Columns["id"].DataPropertyName = "position_id";
                            dataGridView.Columns["name"].DataPropertyName = "position_name";

                            break;
                        }
                    case "project_stages":
                        {
                            Text += "Этапы проекта";
                            dataGridView.Columns["id"].DataPropertyName = "stage_id";
                            dataGridView.Columns["name"].DataPropertyName = "stage_name";
                            dataGridView.Columns["description"].Visible = true;

                        break;
                        }
                    case "document_types":
                        {
                            Text += "Виды документов";
                            dataGridView.Columns["id"].DataPropertyName = "document_type_id";
                            dataGridView.Columns["name"].DataPropertyName = "document_type_name";

                            break;
                        }
                    case "stakeholder_types":
                        {
                            Text += "Вид участника";
                            dataGridView.Columns["id"].DataPropertyName = "stakeholder_type_id";
                            dataGridView.Columns["name"].DataPropertyName = "stakeholder_type_name";

                            break;
                        }
                    case "statuses":
                        {
                            Text += "Статусы";
                            dataGridView.Columns["id"].DataPropertyName = "status_id";
                            dataGridView.Columns["name"].DataPropertyName = "status_name";

                            break;
                        }
                    case "decisions":
                        {
                            Text += "Решения";
                            dataGridView.Columns["id"].DataPropertyName = "decision_id";
                            dataGridView.Columns["name"].DataPropertyName = "decision_name";

                            break;
                        }
                }
            UpdateData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            search = "true";
            this.Close();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAndUpdateReferenceForm addAndUpdateReferenceForm = new AddAndUpdateReferenceForm(false);
            addAndUpdateReferenceForm.ShowDialog();
            UpdateData();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                AddAndUpdateReferenceForm.id = dataGridView.CurrentRow.Cells["id"].Value.ToString();
                AddAndUpdateReferenceForm.name = dataGridView.CurrentRow.Cells["name"].Value.ToString();
                if (dataGridView.CurrentRow.Cells["is_active"].Value.ToString() == "Да")
                    AddAndUpdateReferenceForm.isActive = true;
                else
                    AddAndUpdateReferenceForm.isActive = false;
                if (nameTable == "organizations")
                {
                    AddAndUpdateReferenceForm.shortName = dataGridView.CurrentRow.Cells["short_name"].Value.ToString();
                    AddAndUpdateReferenceForm.stakeholderTypeId = dataGridView.CurrentRow.Cells["stakeholder_type_id"].Value.ToString();
                    AddAndUpdateReferenceForm.ogrn = dataGridView.CurrentRow.Cells["ogrn"].Value.ToString();
                    AddAndUpdateReferenceForm.inn = dataGridView.CurrentRow.Cells["inn"].Value.ToString();
                    AddAndUpdateReferenceForm.kpp = dataGridView.CurrentRow.Cells["kpp"].Value.ToString();
                    AddAndUpdateReferenceForm.legalAddress = dataGridView.CurrentRow.Cells["legal_address"].Value.ToString();
                    AddAndUpdateReferenceForm.phone = dataGridView.CurrentRow.Cells["phone"].Value.ToString();
                    AddAndUpdateReferenceForm.email = dataGridView.CurrentRow.Cells["email"].Value.ToString();
                }
                if (nameTable == "project_stages")
                {
                    AddAndUpdateReferenceForm.stageDescription = dataGridView.CurrentRow.Cells["description"].Value.ToString();
                }

                AddAndUpdateReferenceForm addAndUpdateReferenceForm = new AddAndUpdateReferenceForm(true);
                addAndUpdateReferenceForm.ShowDialog();
                UpdateData();
            }
            else
            {
                Mes.Warning("Выберите одну запись, которую необходимо изменить");
            }


            
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (Mes.Question("Вы действительно хотите удалить запись?") == DialogResult.OK)
                {
                    string id = dataGridView.CurrentRow.Cells["id"].Value.ToString();
                    switch (nameTable)
                    {
                        case "organizations":
                            {
                                if (Organizations.Del(id))
                                {
                                    Mes.Info("Запись успешно удалена");
                                }
                                else
                                {
                                    Mes.Info("Не получилось удалить запись\r\nВозможно она используется в другом реестре");
                                }
                                break;
                            }
                        case "positions":
                            {
                                if (Positions.Del(id))
                                {
                                    Mes.Info("Запись успешно удалена");
                                }
                                else
                                {
                                    Mes.Info("Не получилось удалить запись\r\nВозможно она используется в другом реестре");
                                }
                                break;
                            }
                        case "project_stages":
                            {
                                if (ProjectStages.Del(id))
                                {
                                    Mes.Info("Запись успешно удалена");
                                }
                                else
                                {
                                    Mes.Info("Не получилось удалить запись\r\nВозможно она используется в другом реестре");
                                }
                                break;
                            }
                        case "document_types":
                            {
                                if (DocumentTypes.Del(id))
                                {
                                    Mes.Info("Запись успешно удалена");
                                }
                                else
                                {
                                    Mes.Info("Не получилось удалить запись\r\nВозможно она используется в другом реестре");
                                }
                                break;
                            }
                        case "stakeholder_types":
                            {
                                if (StakeholderTypes.Del(id))
                                {
                                    Mes.Info("Запись успешно удалена");
                                }
                                else
                                {
                                    Mes.Info("Не получилось удалить запись\r\nВозможно она используется в другом реестре");
                                }
                                break;
                            }
                        case "statuses":
                            {
                                if (Statuses.Del(id))
                                {
                                    Mes.Info("Запись успешно удалена");
                                }
                                else
                                {
                                    Mes.Info("Не получилось удалить запись\r\nВозможно она используется в другом реестре");
                                }
                                break;
                            }
                        case "decisions":
                            {
                                if (Decisions.Del(id))
                                {
                                    Mes.Info("Запись успешно удалена");
                                }
                                else
                                {
                                    Mes.Info("Не получилось удалить запись\r\nВозможно она используется в другом реестре");
                                }
                                break;
                            }
                    }
                    UpdateData();
                }
            }
            else
            {
                Mes.Warning("Выберите одну запись, которую необходимо удалить");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string txt = txtSearch.Text;
            if (txt.Length > 0)
            {
                switch (nameTable)
                {
                    case "organizations":
                        {
                            search = $@"full_name LIKE '%{txt}%' or short_name LIKE '%{txt}%' or 
                                        ogrn LIKE '%{txt}%' or inn LIKE '%{txt}%' or kpp LIKE '%{txt}%' or legal_address LIKE '%{txt}%' or phone LIKE '%{txt}%'  or 
                                            email LIKE '%{txt}%'";
                            break;
                        }
                    case "positions":
                        {
                            search = $@"position_name LIKE '%{txt}%'";
                            break;
                        }
                    case "project_stages":
                        {
                            search = $@"stage_name LIKE '%{txt}%'";
                            break;
                        }
                    case "document_types":
                        {
                            search = $@"document_type_name LIKE '%{txt}%'";
                            break;
                        }
                    case "stakeholder_types":
                        {
                            search = $@"stakeholder_type_name LIKE '%{txt}%'";
                            break;
                        }
                    case "statuses":
                        {
                            search = $@"status_name LIKE '%{txt}%'";
                            break;
                        }
                    case "decisions":
                        {
                            search = $@"position_name LIKE '%{txt}%'";
                            break;
                        }
                }
                UpdateData();
            }
            else
            {
                 search = "true";
            }
            UpdateData();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
