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

namespace ispda.Forms.HeadsOrganizationsForms
{
    public partial class ViewHeadsOrganizationsForm : Form
    {
        public ViewHeadsOrganizationsForm()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                InformationForm.item = "headsOrganizations";
                InformationForm form = new InformationForm();
                form.ShowDialog();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void UpdateData()
        {
            HeadsOrganizations.GetList();
            dataGridViewHead.DataSource = HeadsOrganizations.dtList;

            for (int i = 0; i < dataGridViewHead.Rows.Count; i++)
            {
                if (Convert.ToDateTime(dataGridViewHead.Rows[i].Cells["period_validity_end"].Value.ToString()) < DateTime.Now)
                {
                    dataGridViewHead.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                }
                else if (Convert.ToDateTime(dataGridViewHead.Rows[i].Cells["period_validity_start"].Value.ToString()) > DateTime.Now)
                {
                    dataGridViewHead.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                }
                else
                {
                    dataGridViewHead.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
            
        }

        private void ViewHeadsOrganizationsForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (Users.role == "2")
                {
                    menuStripHeadsOrg.Visible = false;
                }
                else
                {
                    menuStripHeadsOrg.Visible = true;
                }
                Organizations.GetListForComboBox();
                comboBoxOrganizations.DataSource = Organizations.dtListForComboBox;
                comboBoxOrganizations.DisplayMember = "name";
                comboBoxOrganizations.ValueMember = "organization_id";
                comboBoxStatus.SelectedIndex = 0;
                UpdateData();
            }
            catch { }
        }

        private void comboBoxOrganizations_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                HeadsOrganizations.filterOrg = $@"heads_organizations.organization_id = '{comboBoxOrganizations.SelectedValue}'";
                UpdateData();
            }
            catch { }
        }

        private void comboBoxStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                switch (comboBoxStatus.SelectedIndex)
                {
                    case 0:
                        {
                            HeadsOrganizations.filter = "heads_organizations.period_validity_start <= CURRENT_DATE() AND heads_organizations.period_validity_end >= CURRENT_DATE()";
                            break;
                        }
                    case 1:
                        {
                            HeadsOrganizations.filter = "heads_organizations.period_validity_start > CURRENT_DATE() OR heads_organizations.period_validity_end < CURRENT_DATE()";
                            break;
                        }
                    case 2:
                        {
                            HeadsOrganizations.filter = "true";
                            break;
                        }
                }
                UpdateData();
            }
            catch { }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            HeadsOrganizations.filter = "heads_organizations.period_validity_start <= CURRENT_DATE() AND heads_organizations.period_validity_end >= CURRENT_DATE()";
            HeadsOrganizations.filterOrg = "true";
            comboBoxStatus.SelectedIndex = 0;
            UpdateData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void выгрузитьВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Dictionary<string, string> data = new Dictionary<string, string>();


                if (HeadsOrganizations.filterOrg != "true")
                {
                    data.Add("Организация", comboBoxOrganizations.Text);
                }
                if (Doc.CreateExcelFromDataTable(Doc.GetDataTableFromDataGridView(dataGridViewHead), saveFileDialog.FileName, $"Head_organizations_for_{DateTime.Now:dd_MM_yyyy}", "Список руководителей организаций", data))
                {
                    Mes.Info("Файл excel успешно сформирован и сохранён");
                }
                else
                {
                    Mes.Error("Не удалось сформировать файл excel");
                }
            }
        }

        private void настроитьОтображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingViewGridForm settingViewGridForm = new SettingViewGridForm(dataGridViewHead);
            settingViewGridForm.ShowDialog();
            var columns = SettingViewGridForm.columns;
            foreach (DataGridViewColumn column in dataGridViewHead.Columns)
            {
                if (columns.ContainsKey(column.Name))
                {
                    column.Visible = columns[column.Name];
                }
            }
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAndUpdateHeadOrganizationForm addAndUpdateHeadOrganizationForm = new AddAndUpdateHeadOrganizationForm(false);
            addAndUpdateHeadOrganizationForm.ShowDialog();
            UpdateData();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {



            AddAndUpdateHeadOrganizationForm.id = dataGridViewHead.CurrentRow.Cells["head_organization_id"].Value.ToString();
            AddAndUpdateHeadOrganizationForm.fioHead = dataGridViewHead.CurrentRow.Cells["fio_head"].Value.ToString();
            AddAndUpdateHeadOrganizationForm.fioHeadGenitive = dataGridViewHead.CurrentRow.Cells["fio_head_genitive"].Value.ToString();
            AddAndUpdateHeadOrganizationForm.fioHeadDative = dataGridViewHead.CurrentRow.Cells["fio_head_dative"].Value.ToString();
            AddAndUpdateHeadOrganizationForm.shortFioHead = dataGridViewHead.CurrentRow.Cells["short_fio_head"].Value.ToString();
            AddAndUpdateHeadOrganizationForm.organizationId = dataGridViewHead.CurrentRow.Cells["organization_id"].Value.ToString();
            AddAndUpdateHeadOrganizationForm.positionId = dataGridViewHead.CurrentRow.Cells["position_id"].Value.ToString();
            AddAndUpdateHeadOrganizationForm.positionGenitive = dataGridViewHead.CurrentRow.Cells["position_genitive"].Value.ToString();
            AddAndUpdateHeadOrganizationForm.actsOnTheBasisOf = dataGridViewHead.CurrentRow.Cells["acts_on_the_basis_of"].Value.ToString();
            AddAndUpdateHeadOrganizationForm.periodValidityStart = dataGridViewHead.CurrentRow.Cells["period_validity_start"].Value.ToString();
            AddAndUpdateHeadOrganizationForm.periodValidityEnd = dataGridViewHead.CurrentRow.Cells["period_validity_end"].Value.ToString();
            AddAndUpdateHeadOrganizationForm addAndUpdateHeadOrganizationForm = new AddAndUpdateHeadOrganizationForm(true);
            addAndUpdateHeadOrganizationForm.ShowDialog();
            UpdateData();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewHead.SelectedRows.Count == 1)
            {
                string id = dataGridViewHead.CurrentRow.Cells["head_organization_id"].Value.ToString();
                if (Mes.Question($"Вы действительно хотите удалить руководителя организации?") == DialogResult.OK)
                {
                    if (HeadsOrganizations.Del(id))
                    {
                        Mes.Info("Руководитель успешно удалён");
                        UpdateData();
                    }
                    else
                    {
                        Mes.Error("Не получилось удалить руководителя");
                    }
                }

            }
            else
            {
                Mes.Warning("Выберите одного руководителя, которого необходимо удалить");
            }
        }
    }
}
