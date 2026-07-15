using Google.Protobuf.WellKnownTypes;
using ispda.Classes.Entities;
using ispda.Entities;
using ispda.Forms.InfoForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ispda.Forms.Projects
{
    public partial class AddAndUpdateProjectForm : Form
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                if(edit)
                    InformationForm.item = "projectUpdate";
                else
                    InformationForm.item = "projectAdd";
                InformationForm form = new InformationForm();
                form.ShowDialog();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        public static string projectId;
        public static string projectNumber;
        public static string projectName;
        public static string projectShortName;
        public static string developerId;
        public static string initiativeRequestId;
        public static string customerId;
        public static string productName;
        public static string productNameGenitive;
        public static string productNamePrepositional;
        public static string productShortName;
        public static string startDate;
        public static string endDate;
        public static string url;
        public static string ip;
        public static string adminPanelUrl;
        public static bool isGis;
        public static bool isPnd;
        public static bool isInternal;
        public static string notes;
        public static string statusId;

        public static bool edit;

        public AddAndUpdateProjectForm(bool update)
        {
            InitializeComponent();

            edit = update;
            if (edit)
            {
                Text = "Изменение информации о проекте";
            }
            else
            {
                Text = "Добавление информации о проекте";
            }


        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void AddProjectForm_Load(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                Statuses.GetListForComboBox();
                comboBoxStatus.DataSource = Statuses.dtListForComboBox;
                comboBoxStatus.DisplayMember = "status_name";
                comboBoxStatus.ValueMember = "status_id";

                Organizations.GetListForComboBox();
                comboBoxDeveloper.DataSource = new DataView(Organizations.dtListForComboBox);
                comboBoxDeveloper.DisplayMember = "name";
                comboBoxDeveloper.ValueMember = "organization_id";
                comboBoxCustomer.DataSource = new DataView(Organizations.dtListForComboBox);
                comboBoxCustomer.DisplayMember = "name";
                comboBoxCustomer.ValueMember = "organization_id";



                if (edit)
                {
                    txtProjectNumber.Text = projectNumber;
                    txtProjectName.Text = projectName;
                    txtProjectShortName.Text = projectShortName;
                    txtProductName.Text = productName;
                    txtProductShortName.Text = productShortName;
                    txtProductNameGenitive.Text = productNameGenitive;
                    txtProductNamePrepositional.Text = productNamePrepositional;
                    txtURL.Text = url;
                    txtIP.Text = ip;
                    txtAdminPanelURL.Text = adminPanelUrl;
                    txtNotes.Text = notes;

                    checkBoxGis.Checked = isGis;
                    checkBoxInternal.Checked = isInternal;
                    checkBoxPnd.Checked = isPnd;
                    comboBoxDeveloper.SelectedValue = developerId;
                    comboBoxCustomer.SelectedValue = customerId;
                    comboBoxStatus.SelectedValue = statusId;

                    dateTimePickerStart.Value = Convert.ToDateTime(startDate);
                    dateTimePickerEnd.Value = Convert.ToDateTime(endDate);
                    comboBoxStatus.Enabled = true;
                    InitiativeRequests.GetListByCustomer(comboBoxCustomer.SelectedValue.ToString());
                    comboBoxInitiativeRequest.DataSource = InitiativeRequests.dtListByCustomer;
                    comboBoxInitiativeRequest.DisplayMember = "date_and_details";
                    comboBoxInitiativeRequest.ValueMember = "initiative_request_id";
                    comboBoxInitiativeRequest.SelectedValue = initiativeRequestId;
                }
                else
                {
                    comboBoxStatus.SelectedValue = 1;
                    comboBoxDeveloper.SelectedValue = 1;
                    InitiativeRequests.GetListByCustomer(comboBoxCustomer.SelectedValue.ToString());
                    comboBoxInitiativeRequest.DataSource = InitiativeRequests.dtListByCustomer;
                    comboBoxInitiativeRequest.DisplayMember = "date_and_details";
                    comboBoxInitiativeRequest.ValueMember = "initiative_request_id";
                }
            }
            catch { }
        }

        private void comboBoxCustomer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                InitiativeRequests.GetListByCustomer(comboBoxCustomer.SelectedValue.ToString());
                comboBoxInitiativeRequest.DataSource = InitiativeRequests.dtListByCustomer;
                comboBoxInitiativeRequest.DisplayMember = "date_and_details";
                comboBoxInitiativeRequest.ValueMember = "initiative_request_id";
                if(comboBoxInitiativeRequest.Text.Length == 0)
                {
                    btnSave.Enabled = false;
                    groupBoxInformationAboutTheSoftwareProduct.Enabled = false;
                    groupBoxAdditionalInformation.Enabled = false;
                    Mes.Warning("Не найдено заявок от выбранного заказчика!\r\nСначала добавьте заявку в реестр");
                }
                else
                {
                    btnSave.Enabled = true;
                    groupBoxInformationAboutTheSoftwareProduct.Enabled = true;
                    groupBoxAdditionalInformation.Enabled = true;
                }
            }
            catch { }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProjectNumber.Text != string.Empty && txtProjectName.Text != string.Empty && comboBoxCustomer.SelectedIndex != -1 && comboBoxDeveloper.SelectedIndex != -1 && comboBoxInitiativeRequest.SelectedIndex != -1)
                {
                    if(txtAdminPanelURL.Text == "admin.td-alpha.ru")
                    {
                        txtAdminPanelURL.Text = "";
                    }
                    if (edit)
                    {
                        if(Classes.Entities.Projects.CheckDuplicateNumber(txtProjectNumber.Text) || txtProjectNumber.Text.Trim() == projectNumber.Trim())
                        {
                            if (Classes.Entities.Projects.Update(projectId, comboBoxStatus.SelectedValue.ToString(), txtProjectNumber.Text.Trim(), txtProjectName.Text, txtProjectShortName.Text, comboBoxInitiativeRequest.SelectedValue.ToString(), comboBoxDeveloper.SelectedValue.ToString(), txtProductName.Text, txtProductNameGenitive.Text, txtProductNamePrepositional.Text, txtProductShortName.Text, dateTimePickerStart.Value.ToString("yyyy-MM-dd"), dateTimePickerEnd.Value.ToString("yyyy-MM-dd"), txtURL.Text, txtIP.Text, txtAdminPanelURL.Text, checkBoxGis.Checked, checkBoxPnd.Checked, checkBoxInternal.Checked, txtNotes.Text))
                            {
                                Mes.Info("Информация о проекте успешно изменена");
                                this.Close();
                            }
                            else
                            {
                                Mes.Error("Не получилось изменить информацию о проекте");
                            }
                        }
                        else
                        {
                            Mes.Warning($"Проект с номером '{txtProjectNumber.Text}' уже существует");
                        }
                        
                    }
                    else
                    {
                        if (Classes.Entities.Projects.Add(comboBoxStatus.SelectedValue.ToString(), txtProjectNumber.Text.Trim(), txtProjectName.Text, txtProjectShortName.Text, comboBoxInitiativeRequest.SelectedValue.ToString(), comboBoxDeveloper.SelectedValue.ToString(), txtProductName.Text, txtProductNameGenitive.Text, txtProductNamePrepositional.Text, txtProductShortName.Text, dateTimePickerStart.Value.ToString("yyyy-MM-dd"), dateTimePickerEnd.Value.ToString("yyyy-MM-dd"), txtURL.Text, txtIP.Text, txtAdminPanelURL.Text, checkBoxGis.Checked, checkBoxPnd.Checked, checkBoxInternal.Checked, txtNotes.Text))
                        {
                            Mes.Info("Информация о проекте успешно добавлена");
                            this.Close();
                        }
                        else
                        {
                            Mes.Error("Не получилось добавить информацию о проекте");
                        }
                    }
                }
                else
                {
                    Mes.Warning("Заполните все обязательные поля");
                }
            }
            catch(Exception ex) { Mes.Error(ex.Message); }
            
        }

        private void txtProjectNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtProjectName.Text.Length == 0 || txtProjectNumber.Text.Length == 0)
                btnSave.Enabled = false;
            else 
                btnSave.Enabled = true;
        }

        private void txtProjectName_TextChanged(object sender, EventArgs e)
        {
            if (txtProjectName.Text.Length == 0 || txtProjectNumber.Text.Length == 0)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
        }

        private void txtAdminPanelURL_Enter(object sender, EventArgs e)
        {
            if (txtAdminPanelURL.Text == "admin.td-alpha.ru")
            {
                txtAdminPanelURL.Text = "";
                txtAdminPanelURL.ForeColor = Color.Black;
            }
        }

        private void txtAdminPanelURL_Leave(object sender, EventArgs e)
        {
            if (txtAdminPanelURL.Text.Trim().Length == 0)
            {
                txtAdminPanelURL.Text = "admin.td-alpha.ru";
                txtAdminPanelURL.ForeColor = Color.Gray;
            }
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
            {
                dateTimePickerEnd.Value = dateTimePickerStart.Value;
                dateTimePickerEnd.Value = dateTimePickerEnd.Value.AddDays(1);
            }
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePickerEnd.Value < dateTimePickerStart.Value)
            {
                dateTimePickerStart.Value = dateTimePickerEnd.Value;
                dateTimePickerStart.Value = dateTimePickerStart.Value.AddDays(-1);
            }
        }
    }
}
