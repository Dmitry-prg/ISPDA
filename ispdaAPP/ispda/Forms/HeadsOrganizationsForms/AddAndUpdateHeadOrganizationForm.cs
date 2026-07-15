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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ispda.Forms.HeadsOrganizationsForms
{
    public partial class AddAndUpdateHeadOrganizationForm : Form
    {
        public static bool update;
        public static string id, fioHead, fioHeadGenitive, fioHeadDative, shortFioHead, organizationId, positionId, positionGenitive, actsOnTheBasisOf, periodValidityStart, periodValidityEnd;
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
        private bool CorrectShortFio(string fio)
        {
            Regex regex = new Regex(@"^[А-Я]\.[А-Я]\.\s+[А-ЯЁ][а-яё]+$");
            return regex.IsMatch(fio);
        }

        public AddAndUpdateHeadOrganizationForm(bool edit)
        {

            InitializeComponent();
            try
            {
                update = edit;
                if (update)
                {
                    Text = "Изменение информации о руководителе";

                }
                else
                {
                    Text = "Добавление информации о руководителе";

                }
            }
            catch { }
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
            {
                dateTimePickerEnd.Value = dateTimePickerStart.Value;
            }
        }
        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerEnd.Value < dateTimePickerStart.Value)
            {
                dateTimePickerEnd.Value = dateTimePickerStart.Value;
            }
        }
        private void AddAndUpdateHeadOrganizationForm_Load(object sender, EventArgs e)
        {
            try
            {
                Organizations.GetListForComboBox();
                comboBoxOrganizations.DataSource = Organizations.dtListForComboBox;
                comboBoxOrganizations.DisplayMember = "name";
                comboBoxOrganizations.ValueMember = "organization_id";

                Positions.GetListForComboBox();
                comboBoxPosition.DataSource = Positions.dtListForCombobox;
                comboBoxPosition.DisplayMember = "position_name";
                comboBoxPosition.ValueMember = "position_id";

                if (update)
                {
                    txtFioHead.Text = fioHead;
                    txtFioHeadGenitive.Text = fioHeadGenitive;
                    txtFioHeadDative.Text = fioHeadDative;
                    txtShortFioHead.Text = shortFioHead;
                    txtPositionGenitive.Text = positionGenitive;
                    txtActOfBasic.Text = actsOnTheBasisOf;
                    comboBoxOrganizations.SelectedValue = organizationId;
                    comboBoxPosition.SelectedValue = positionId;
                    dateTimePickerStart.Value = Convert.ToDateTime(periodValidityStart);
                    dateTimePickerEnd.Value = Convert.ToDateTime(periodValidityEnd);
                }
            }
            catch { }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFioHead.Text != string.Empty && txtShortFioHead.Text != string.Empty && txtFioHeadGenitive.Text != string.Empty && txtFioHeadDative.Text != string.Empty && txtPositionGenitive.Text != string.Empty && txtActOfBasic.Text != string.Empty)
            {
                if (CorrectShortFio(txtShortFioHead.Text))
                {

                    if (update)
                    {
                        if (HeadsOrganizations.Update(id, txtFioHead.Text, txtFioHeadGenitive.Text, txtFioHeadDative.Text, txtShortFioHead.Text, comboBoxOrganizations.SelectedValue.ToString(), comboBoxPosition.SelectedValue.ToString(), txtPositionGenitive.Text, txtActOfBasic.Text, dateTimePickerStart.Value.ToString("yyyy-MM-dd"), dateTimePickerEnd.Value.ToString("yyyy-MM-dd")))
                        {
                            Mes.Info("Информация о руководителе успешно изменена");
                            this.Close();
                        }
                        else
                        {
                            Mes.Error("Не получилось изменить информацию о руководителе");
                        }
                    }
                    else
                    {
                        if (HeadsOrganizations.Add(txtFioHead.Text, txtFioHeadGenitive.Text, txtFioHeadDative.Text, txtShortFioHead.Text, comboBoxOrganizations.SelectedValue.ToString(), comboBoxPosition.SelectedValue.ToString(), txtPositionGenitive.Text, txtActOfBasic.Text, dateTimePickerStart.Value.ToString("yyyy-MM-dd"), dateTimePickerEnd.Value.ToString("yyyy-MM-dd")))
                        {
                            Mes.Info("Информация о руководителе успешно добавлена");
                            this.Close();
                        }
                        else
                        {
                            Mes.Error("Не получилось добавить информацию о руководителе");
                        }
                    }
                }
                else
                {
                    Mes.Warning("Некорректное сокращённое ФИО руководителя\r\nОбразец: И.О. Фамилия");
                }
            }
            else
            {
                Mes.Warning("Заполните все поля!");
            }

        }

    }
}
