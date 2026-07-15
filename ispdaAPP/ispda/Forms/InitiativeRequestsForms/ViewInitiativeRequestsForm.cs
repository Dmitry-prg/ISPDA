using ispda.Classes;
using ispda.Classes.Entities;
using ispda.Entities;
using ispda.Forms.ControlsForms;
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
using System.Windows.Forms.VisualStyles;

namespace ispda.Forms.InitiativeRequestsForms
{
    public partial class ViewInitiativeRequestsForm : Form
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                InformationForm.item = "initiativeRequests";
                InformationForm form = new InformationForm();
                form.ShowDialog();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public ViewInitiativeRequestsForm()
        {
            InitializeComponent();
        }
        private void UpdateData()
        {
            InitiativeRequests.GetList();
            dataGridViewInitiativeRequests.DataSource = InitiativeRequests.dtList;
            saveFileDialog.FileName = "initiative_requests_for_" + DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAndUpdateInitiativeRequestForm addAndUpdateInitiativeRequestForm = new AddAndUpdateInitiativeRequestForm(false);
            addAndUpdateInitiativeRequestForm.ShowDialog();
            UpdateData();
        }

        private void ViewInitiativeRequestsForm_Load(object sender, EventArgs e)
        {
            if (Users.role == "2")
                menuStripRequests.Visible = false;
            else
                menuStripRequests.Visible = true;
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

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridViewInitiativeRequests.SelectedRows.Count == 1)
            {
                AddAndUpdateInitiativeRequestForm.id = dataGridViewInitiativeRequests.CurrentRow.Cells["initiative_request_id"].Value.ToString();
                AddAndUpdateInitiativeRequestForm.customerId = dataGridViewInitiativeRequests.CurrentRow.Cells["customer_id"].Value.ToString();
                AddAndUpdateInitiativeRequestForm.decisionId = dataGridViewInitiativeRequests.CurrentRow.Cells["decision_id"].Value.ToString();
                AddAndUpdateInitiativeRequestForm.details = dataGridViewInitiativeRequests.CurrentRow.Cells["initiative_request_details"].Value.ToString();
                AddAndUpdateInitiativeRequestForm.date = dataGridViewInitiativeRequests.CurrentRow.Cells["created_at"].Value.ToString();
                AddAndUpdateInitiativeRequestForm.dateApproved = dataGridViewInitiativeRequests.CurrentRow.Cells["approved_at"].Value.ToString();

                AddAndUpdateInitiativeRequestForm addAndUpdateInitiativeRequestForm = new AddAndUpdateInitiativeRequestForm(true);
                addAndUpdateInitiativeRequestForm.ShowDialog();
                UpdateData();
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridViewInitiativeRequests.SelectedRows.Count == 1)
            {
                string id = dataGridViewInitiativeRequests.CurrentRow.Cells["initiative_request_id"].Value.ToString();
                if(Mes.Question($"Вы действительно хотите удалить заявку с номером '{id}'?") == DialogResult.OK)
                {
                    if (InitiativeRequests.Del(id))
                    {
                        Mes.Info("Заявка успешно удалена");
                        UpdateData();
                    }
                    else
                    {
                        Mes.Error("Не получилось удалить заявку");
                    }
                }

            }
            else
            {
                Mes.Warning("Выберите одну заявку, которую необходимо удалить");
            }
        }

        private void настроитьОтображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingViewGridForm settingViewGridForm = new SettingViewGridForm(dataGridViewInitiativeRequests);
            settingViewGridForm.ShowDialog();
            var columns = SettingViewGridForm.columns;
            foreach (DataGridViewColumn column in dataGridViewInitiativeRequests.Columns)
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
               

                if (InitiativeRequests.filter != "true")
                {
                    data.Add("Заказчик", comboBoxCustomer.Text);
                }
                if (Doc.CreateExcelFromDataTable(Doc.GetDataTableFromDataGridView(dataGridViewInitiativeRequests), saveFileDialog.FileName, $"Initiative_requests_for_{DateTime.Now:dd_MM_yyyy}", "Список инициативных заявок", data))
                {
                    Mes.Info("Файл excel успешно сформирован и сохранён");
                }
                else
                {
                    Mes.Error("Не удалось сформировать файл excel");
                }
            }
        }

        private void comboBoxCustomer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            InitiativeRequests.filter = $@"initiative_requests.customer_id = '{comboBoxCustomer.SelectedValue}'";
            UpdateData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            InitiativeRequests.filter = "true";
            comboBoxCustomer.SelectedIndex = 0;
            UpdateData();
        }
    }
}
