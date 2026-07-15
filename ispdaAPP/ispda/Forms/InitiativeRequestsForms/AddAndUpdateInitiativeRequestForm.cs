using ispda.Classes.Entities;
using ispda.Entities;
using ispda.Forms.InfoForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ispda.Forms.InitiativeRequestsForms
{
    public partial class AddAndUpdateInitiativeRequestForm : Form
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                InformationForm.item = "";
                InformationForm form = new InformationForm();
                form.ShowDialog();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public static string id;
        public static string customerId;
        public static string decisionId;
        public static string details;
        public static string date;
        public static string dateApproved;
        public static bool edit;

        public AddAndUpdateInitiativeRequestForm(bool update)
        {
            InitializeComponent();
            edit = update;
            if (edit)
            {
                Text = "Изменение инициативной заявки";
            }
            else
            {
                Text = "Добавление инициативной заявки";
            }
        }




        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddAndUpdateInitiativeRequestForm_Load(object sender, EventArgs e)
        {
            try
            {
                Decisions.GetListForComboBox();
                comboBoxDecisionId.DataSource = Decisions.dtListForComboBox;
                comboBoxDecisionId.DisplayMember = "decision_name";
                comboBoxDecisionId.ValueMember = "decision_id";

                Organizations.GetListForComboBox();
                comboBoxCustomer.DataSource = Organizations.dtListForComboBox;
                comboBoxCustomer.DisplayMember = "name";
                comboBoxCustomer.ValueMember = "organization_id";


                if (edit)
                {
                    comboBoxCustomer.SelectedValue = customerId;
                    comboBoxDecisionId.SelectedValue = decisionId;
                    txtDetails.Text = details;
                    dateTimePickerCreate.Value = Convert.ToDateTime(date);
                    dateTimePickerApproved.Visible = true;
                    label5.Visible = true;
                    if(dateApproved != null)
                    {
                        dateTimePickerApproved.Value = Convert.ToDateTime(dateApproved);
                    }
                    
                }
                else
                {
                    dateTimePickerApproved.Visible = false;
                    label5.Visible = false;
                    comboBoxDecisionId.SelectedValue = 3;
                    comboBoxDecisionId.Enabled = false;
                }

            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(comboBoxCustomer.SelectedIndex != -1 && comboBoxDecisionId.SelectedIndex != -1 && txtDetails.Text != string.Empty)
            {
                if (edit)
                {        
                    if (InitiativeRequests.Update(id, comboBoxCustomer.SelectedValue.ToString(), comboBoxDecisionId.SelectedValue.ToString(), txtDetails.Text, dateTimePickerCreate.Value.ToString("yyyy-MM-dd"), dateTimePickerApproved.Value.ToString("yyyy-MM-dd")))
                    {
                        Mes.Info("Информация о заявке успешно изменена");
                        this.Close();
                    }
                    else
                    {
                        Mes.Error("Не получилось изменить информацию о заявке");
                    }
                }
                else
                {
                    if(InitiativeRequests.Add(comboBoxCustomer.SelectedValue.ToString(), comboBoxDecisionId.SelectedValue.ToString(), txtDetails.Text, dateTimePickerCreate.Value.ToString("yyyy-MM-dd")))
                    {
                        Mes.Info("Информация о заявке успешно добавлена");
                        this.Close();
                    }
                    else
                    {
                        Mes.Error("Не получилось добавить информацию о заявке");
                    }
                }
            }
            else
            {
                Mes.Warning("Заполните все поля");
            }
        }

        private void dateTimePickerCreate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
