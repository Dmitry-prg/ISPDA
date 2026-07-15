using ispda.Classes.Entities;
using ispda.Entities;
using ispda.Forms.InfoForm;
using ispda.Forms.Reference;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ispda.Forms.ReferenceForms
{
    public partial class AddAndUpdateReferenceForm : Form
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
        public static string name;
        public static bool isActive;

        public static string shortName;
        public static string stakeholderTypeId;
        public static string ogrn;
        public static string inn;
        public static string kpp;
        public static string legalAddress;
        public static string phone;
        public static string email;

        public static string stageDescription;

        public static bool edit;


        public AddAndUpdateReferenceForm(bool update)
        {
            InitializeComponent();
            edit = update;
            if (edit)
            {
                Text = "Изменение информации в справочнике '";
                
            }
            else
            {
                Text = "Добавление информации в справочник '";
                
            }
            Height = 122;
            Width = 435;
            switch (ViewReferenceForm.nameTable)
            {
                case "organizations":
                    {
                        Text += "Организации'";
                        Height = 358;
                        StakeholderTypes.GetListForComboBox();
                        comboBoxStakeholder.DataSource = StakeholderTypes.dtListForComboBox;
                        comboBoxStakeholder.DisplayMember = "stakeholder_type_name";
                        comboBoxStakeholder.ValueMember = "stakeholder_type_id";
                        break;
                    }
                case "positions":
                    {
                        Text += "Должности'";
                        break;
                    }
                case "project_stages":
                    {
                        Text += "Этапы проекта'";
                        Width = 792;
                        break;
                    }
                case "document_types":
                    {
                        Text += "Виды документов'";
                        break;
                    }
                case "stakeholder_types":
                    {
                        Text += "Вид участника'";
                        break;
                    }
                case "statuses":
                    {
                        Text += "Статусы'";
                        break;
                    }
                case "decisions":
                    {
                        Text += "Решения'";
                        break;
                    }
            }
        }

        private void AddAndUpdateReferenceForm_Load(object sender, EventArgs e)
        {
            if (edit)
            {
                if (ViewReferenceForm.nameTable == "organizations")
                {
                    txtName.Text = name;
                    txtShortName.Text = shortName;
                    comboBoxStakeholder.SelectedValue = stakeholderTypeId;
                    txtOgrn.Text = ogrn;
                    txtInn.Text = inn;
                    txtKpp.Text = kpp;
                    txtLegalAddress.Text = legalAddress;
                    txtEmail.Text = email;
                    txtPhone.Text = phone;
                    checkBoxIsActive.Checked = isActive;
                }
                else
                {
                    txtName.Text = name;
                    checkBoxIsActive.Checked = isActive;
                    if (ViewReferenceForm.nameTable == "project_stages")
                    {
                        txtStageDescription.Text = stageDescription;
                    }
                }

            }
            else
            {
                checkBoxIsActive.Checked = true;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Text != string.Empty)
            {
                if (edit)
                {
                    switch (ViewReferenceForm.nameTable)
                    {
                        case "organizations":
                            {
                                if (txtInn.Text.Length == 10 && txtKpp.Text.Length == 9 && txtLegalAddress.Text != string.Empty && txtEmail.Text != string.Empty)
                                {
                                    if (Organizations.CheckDuplicate(txtName.Text, txtInn.Text, txtEmail.Text) || (txtName.Text == name || txtInn.Text == inn))
                                    {
                                        if (Organizations.Update(id, txtName.Text, txtShortName.Text, comboBoxStakeholder.SelectedValue.ToString(), txtOgrn.Text, txtInn.Text, txtKpp.Text, txtLegalAddress.Text, txtPhone.Text, txtEmail.Text, checkBoxIsActive.Checked))
                                        {
                                            Mes.Info("Информация об организации успешно изменена");
                                            this.Close();
                                        }
                                        else
                                        {
                                            Mes.Error("Не получилось изменить информацию об организации");
                                        }
                                    }
                                    else
                                    {
                                        Mes.Warning("Организация с такими данными уже существует");
                                    }
                                }
                                else
                                {
                                    Mes.Warning("Заполните обязательные поля");
                                }
                                break;
                            }
                        case "positions":
                            {
                                if (Positions.CheckDuplicate(txtName.Text) || txtName.Text == name)
                                {
                                    if (Positions.Update(id, txtName.Text, checkBoxIsActive.Checked))
                                    {
                                        Mes.Info("Информация о должности успешно изменена");
                                        this.Close();
                                    }
                                    else
                                    {
                                        Mes.Error("Не получилось изменить информацию о должности");
                                    }
                                }
                                else
                                {
                                    Mes.Warning("Должность с таким наименованием уже существует");
                                }
                                break;
                            }
                        case "project_stages":
                            {
                                if (ProjectStages.CheckDuplicate(txtName.Text) || txtName.Text == name)
                                {
                                    if (ProjectStages.Update(id, txtName.Text, txtStageDescription.Text, checkBoxIsActive.Checked))
                                    {
                                        Mes.Info("Информация об этапе проекта успешно изменена");
                                        this.Close();
                                    }
                                    else
                                    {
                                        Mes.Error("Не получилось изменить информацию об этапе проекта");
                                    }
                                }
                                else
                                {
                                    Mes.Warning("Этап проекта с таким наименованием уже существует");
                                }
                                break;
                            }
                        case "document_types":
                            {
                                if (DocumentTypes.CheckDuplicate(txtName.Text) || txtName.Text == name)
                                {
                                    if (DocumentTypes.Update(id, txtName.Text, checkBoxIsActive.Checked))
                                    {
                                        Mes.Info("Информация о виде документа успешно изменена");
                                        this.Close();
                                    }
                                    else
                                    {
                                        Mes.Error("Не получилось изменить информацию о виде документа");
                                    }
                                }
                                else
                                {
                                    Mes.Warning("Вид документа с таким наименованием уже существует");
                                }
                                break;
                            }
                        case "stakeholder_types":
                            {
                                if (StakeholderTypes.CheckDuplicate(txtName.Text) || txtName.Text == name)
                                {
                                    if (StakeholderTypes.Update(id, txtName.Text, checkBoxIsActive.Checked))
                                    {
                                        Mes.Info("Информация о виде участника успешно изменена");
                                        this.Close();
                                    }
                                    else
                                    {
                                        Mes.Error("Не получилось изменить информацию о виде участника");
                                    }
                                }
                                else
                                {
                                    Mes.Warning("Вид участника с таким наименованием уже существует");
                                }
                                break;
                            }
                        case "statuses":
                            {

                                if (Statuses.CheckDuplicate(txtName.Text) || txtName.Text == name)
                                {
                                    if (Statuses.Update(id, txtName.Text, checkBoxIsActive.Checked))
                                    {
                                        Mes.Info("Информация о статусе успешно изменена");
                                        this.Close();
                                    }
                                    else
                                    {
                                        Mes.Error("Не получилось изменить информацию о статусе");
                                    }
                                }
                                else
                                {
                                    Mes.Warning("Статус с таким наименованием уже существует");
                                }
                                break;
                            }
                        case "decisions":
                            {
                                if (Decisions.CheckDuplicate(txtName.Text) || txtName.Text == name)
                                {
                                    if (Decisions.Update(id, txtName.Text, checkBoxIsActive.Checked))
                                    {
                                        Mes.Info("Информация о решении успешно изменена");
                                        this.Close();
                                    }
                                    else
                                    {
                                        Mes.Error("Не получилось изменить информацию о решении");
                                    }
                                }
                                else
                                {
                                    Mes.Warning("Решение с таким наименованием уже существует");
                                }
                                break;
                            }
                    }
                }
                else
                {
                    switch (ViewReferenceForm.nameTable)
                    {
                        case "organizations":
                            {
                                if (txtInn.Text != string.Empty && txtKpp.Text != string.Empty && txtLegalAddress.Text != string.Empty && txtEmail.Text != string.Empty)
                                {
                                    if (Organizations.CheckDuplicate(txtName.Text, txtInn.Text, txtEmail.Text))
                                    {
                                        if (Organizations.Add(txtName.Text, txtShortName.Text, comboBoxStakeholder.SelectedValue.ToString(), txtOgrn.Text, txtInn.Text, txtKpp.Text, txtLegalAddress.Text, txtPhone.Text, txtEmail.Text, checkBoxIsActive.Checked))
                                        {
                                            Mes.Info("Информация об организации успешно добавлена");
                                            this.Close();
                                        }
                                        else
                                        {
                                            Mes.Error("Не получилось добавить информацию об организации");
                                        }
                                    }
                                    else
                                    {
                                        Mes.Warning("Организация с такими данными уже существует");
                                    }
                                }
                                else
                                {
                                    Mes.Warning("Заполните обязательные поля");
                                }
                                break;
                            }
                        case "positions":
                            {
                                if (Positions.CheckDuplicate(txtName.Text))
                                {
                                    if (Positions.Add(txtName.Text, checkBoxIsActive.Checked))
                                    {
                                        Mes.Info("Информация о должности успешно добавлена");
                                        this.Close();
                                    }
                                    else
                                    {
                                        Mes.Error("Не получилось добавить информацию о должности");
                                    }
                                }
                                else
                                {
                                    Mes.Warning("Должность с таким наименованием уже существует");
                                }
                                break;
                            }
                        case "project_stages":
                            {
                                if (ProjectStages.CheckDuplicate(txtName.Text))
                                {
                                    if (ProjectStages.Add(txtName.Text, txtStageDescription.Text, checkBoxIsActive.Checked))
                                    {
                                        Mes.Info("Информация об этапе проекта успешно добавлена");
                                        this.Close();
                                    }
                                    else
                                    {
                                        Mes.Error("Не получилось добавить информацию об этапе проекта");
                                    }
                                }
                                else
                                {
                                    Mes.Warning("Этап проекта с таким наименованием уже существует");
                                }
                                break;
                            }
                        case "document_types":
                            {
                                if (DocumentTypes.CheckDuplicate(txtName.Text))
                                {
                                    if (DocumentTypes.Add(txtName.Text, checkBoxIsActive.Checked))
                                    {
                                        Mes.Info("Информация о виде документа успешно добавлена");
                                        this.Close();
                                    }
                                    else
                                    {
                                        Mes.Error("Не получилось добавить информацию о виде документа");
                                    }
                                }
                                else
                                {
                                    Mes.Warning("Вид документа с таким наименованием уже существует");
                                }
                                break;
                            }
                        case "stakeholder_types":
                            {
                                if (StakeholderTypes.CheckDuplicate(txtName.Text))
                                {
                                    if (StakeholderTypes.Add(txtName.Text, checkBoxIsActive.Checked))
                                    {
                                        Mes.Info("Информация о виде участника успешно добавлена");
                                        this.Close();
                                    }
                                    else
                                    {
                                        Mes.Error("Не получилось добавить информацию о виде участника");
                                    }
                                }
                                else
                                {
                                    Mes.Warning("Вид участника с таким наименованием уже существует");
                                }
                                break;
                            }
                        case "statuses":
                            {

                                if (Statuses.CheckDuplicate(txtName.Text))
                                {
                                    if (Statuses.Add(txtName.Text, checkBoxIsActive.Checked))
                                    {
                                        Mes.Info("Информация о статусе успешно добавлена");
                                        this.Close();
                                    }
                                    else
                                    {
                                        Mes.Error("Не получилось добавить информацию о статусе");
                                    }
                                }
                                else
                                {
                                    Mes.Warning("Статус с таким наименованием уже существует");
                                }
                                break;
                            }
                        case "decisions":
                            {
                                if (Decisions.CheckDuplicate(txtName.Text))
                                {
                                    if (Decisions.Add(txtName.Text, checkBoxIsActive.Checked))
                                    {
                                        Mes.Info("Информация о решении успешно добавлена");
                                        this.Close();
                                    }
                                    else
                                    {
                                        Mes.Error("Не получилось добавить информацию о решении");
                                    }
                                }
                                else
                                {
                                    Mes.Warning("Решение с таким наименованием уже существует");
                                }
                                break;
                            }
                    }

                }
                    
            }
            else
            {
                Mes.Warning("Заполните обязательные поля");
            }
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtInn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void txtStageDescription_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(txtStageDescription, txtStageDescription.Text);

        }
    }
}
