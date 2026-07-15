using ispda.Classes.Entities;
using ispda.Entities;
using ispda.Forms.InfoForm;
using ispda.Forms.Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ispda.Forms.ProjectsForms
{
    public partial class AddAndUpdateStageForProjectForm : Form
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
        public static string stageId;
        public static DateTime plannedStartDate;
        public static DateTime plannedEndDate;
        public static DateTime actualStartDate;
        public static DateTime actualEndDate;
        public static string turn;
        public static string notes;
        public static bool edit;


        public AddAndUpdateStageForProjectForm(bool update)
        {
            InitializeComponent();
            try
            {
                edit = update;
                if (edit)
                {
                    Text = "Изменение этапа";
                    Height = 306;

                }
                else
                {
                    Text = "Добавление этапа";
                    Height = 229;
                }
            }
            catch { }


        }


        private void AddAndUpdateStageForProjectForm_Load(object sender, EventArgs e)
        {
            try
            {
                dateTimePickerStart.MinDate = RoadMapForProject.projectStart;
                dateTimePickerEnd.MinDate = RoadMapForProject.projectStart;
                dateTimePickerActualStart.MinDate = RoadMapForProject.projectStart;
                dateTimePickerActualEnd.MinDate = RoadMapForProject.projectStart;

                dateTimePickerStart.MaxDate = RoadMapForProject.projectEnd;
                dateTimePickerEnd.MaxDate = RoadMapForProject.projectEnd;
                dateTimePickerActualStart.MaxDate = RoadMapForProject.projectEnd;
                dateTimePickerActualEnd.MaxDate = RoadMapForProject.projectEnd;
                if(!edit) turn = RoadMapItems.GetTurnForProject();


                if (turn != null)
                {
                    var p = RoadMapItems.GetDateTurnLimit(turn, RoadMapForProject.id, false);
                    var a = RoadMapItems.GetDateTurnLimit(turn, RoadMapForProject.id, true);
                    if (p.Item1 != "")
                    {
                        dateTimePickerStart.MinDate = Convert.ToDateTime(p.Item1);
                        dateTimePickerEnd.MinDate = Convert.ToDateTime(p.Item1);
                    }
                    if (p.Item2 != "")
                    {
                        dateTimePickerStart.MaxDate = Convert.ToDateTime(p.Item2);
                        dateTimePickerEnd.MaxDate = Convert.ToDateTime(p.Item2);       
                    }
                    if (a.Item1 != "")
                    {        
                        dateTimePickerActualStart.MinDate = Convert.ToDateTime(a.Item1);
                        dateTimePickerActualEnd.MinDate = Convert.ToDateTime(a.Item1);
                    }
                    if (a.Item2 != "")
                    {
                        dateTimePickerActualStart.MaxDate = Convert.ToDateTime(a.Item2);
                        dateTimePickerActualEnd.MaxDate = Convert.ToDateTime(a.Item2);
                    }

                }
                




                ProjectStages.GetListForComboBox();
                comboBoxStage.DataSource = ProjectStages.dtListForComboBox;
                comboBoxStage.DisplayMember = "stage_name";
                comboBoxStage.ValueMember = "stage_id";

                if (edit)
                {

                    comboBoxStage.SelectedValue = stageId;
                    txtNotes.Text = notes;
                    label4.Visible = true;
                    label3.Visible = true;
                    dateTimePickerActualStart.Visible = true;
                    dateTimePickerActualEnd.Visible = true;

                    dateTimePickerStart.Value = plannedStartDate;
                    dateTimePickerEnd.Value = plannedEndDate;
                    if(actualStartDate != null && actualEndDate != null)
                    {
                        dateTimePickerActualStart.Value = actualStartDate;
                        dateTimePickerActualEnd.Value = actualEndDate;
                    }
                }
                else
                {
                    label4.Visible = false;
                    label3.Visible = false;
                    dateTimePickerActualStart.Visible = false;
                    dateTimePickerActualEnd.Visible = false;
                }
                comboBoxStage_SelectionChangeCommitted(sender, e);
            }
            catch { }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (edit)
                {
                    if (RoadMapItems.CheckDuplicate(comboBoxStage.SelectedValue.ToString()) || comboBoxStage.SelectedValue.ToString() == stageId)
                    {
                        if (RoadMapItems.Update(id, comboBoxStage.SelectedValue.ToString(), dateTimePickerStart.Value.ToString("yyyy-MM-dd"), dateTimePickerEnd.Value.ToString("yyyy-MM-dd"),
                            dateTimePickerActualStart.Value.ToString("yyyy-MM-dd"),
                            dateTimePickerActualEnd.Value.ToString("yyyy-MM-dd"),
                           txtNotes.Text))
                        {

                            Mes.Info("Информация об этапе проекта успешно изменена");
                            if (comboBoxStage.SelectedValue.ToString() == "1")
                            {
                                Classes.Entities.Projects.UpdateActualStart(RoadMapForProject.id, dateTimePickerActualStart.Value.ToString("yyyy-MM-dd"));
                            }
                            else if (comboBoxStage.SelectedValue.ToString() == "8")
                            {
                                Classes.Entities.Projects.UpdateActualEnd(RoadMapForProject.id, dateTimePickerActualEnd.Value.ToString("yyyy-MM-dd"));
                            }
                            this.Close();
                        }
                        else
                        {
                            Mes.Error("Не удалось изменить информацию об этапе проекта");
                        }
                    }
                    else
                    {
                        Mes.Warning("Выбранный этап уже есть в дорожной карте проекта");
                    }
                }
                else
                {
                    if (RoadMapItems.CheckDuplicate(comboBoxStage.SelectedValue.ToString()))
                    {
                        if (RoadMapItems.Add(comboBoxStage.SelectedValue.ToString(), dateTimePickerStart.Value.ToString("yyyy-MM-dd"), dateTimePickerEnd.Value.ToString("yyyy-MM-dd"), txtNotes.Text))
                        {
                            Mes.Info("Информация об этапе проекта успешно добавлена");
                            
                            this.Close();
                        }
                        else
                        {
                            Mes.Error("Не удалось добавить информацию об этапе проекта");
                        }
                    }
                    else
                    {
                        Mes.Warning("Выбранный этап уже есть в проекте");
                    }
                }
            }
            catch { }
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePickerStart.Value < RoadMapForProject.projectStart)
                {
                    dateTimePickerStart.Value = RoadMapForProject.projectStart;
                }
                if (dateTimePickerStart.Value > RoadMapForProject.projectEnd)
                {
                    dateTimePickerStart.Value = RoadMapForProject.projectEnd.AddDays(-2);
                }
                if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
                {
                    dateTimePickerEnd.Value = dateTimePickerStart.Value.AddDays(1);
                }
            }
            catch { }

        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePickerEnd.Value < RoadMapForProject.projectStart)
                {
                    dateTimePickerEnd.Value = RoadMapForProject.projectStart.AddDays(2);
                }
                if (dateTimePickerEnd.Value > RoadMapForProject.projectEnd)
                {
                    dateTimePickerEnd.Value = RoadMapForProject.projectEnd.AddDays(-2);
                }
                if (dateTimePickerEnd.Value < dateTimePickerStart.Value)
                {
                    dateTimePickerEnd.Value = dateTimePickerStart.Value.AddDays(1);
                }
            }
            catch { }
            
        }
        private void dateTimePickerActualStart_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePickerActualStart.Value < RoadMapForProject.projectStart)
                {
                    dateTimePickerActualStart.Value = RoadMapForProject.projectStart;
                }
                if (dateTimePickerActualStart.Value > RoadMapForProject.projectEnd)
                {
                    dateTimePickerActualStart.Value = RoadMapForProject.projectEnd.AddDays(-2);
                }
                if (dateTimePickerActualStart.Value > dateTimePickerActualEnd.Value)
                {
                    dateTimePickerActualEnd.Value = dateTimePickerActualStart.Value.AddDays(1);
                }
            }
            catch {}
            
        }

        private void dateTimePickerActualEnd_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePickerActualEnd.Value < RoadMapForProject.projectStart)
                {
                    dateTimePickerActualEnd.Value = RoadMapForProject.projectStart.AddDays(2);
                }
                if (dateTimePickerActualEnd.Value > RoadMapForProject.projectEnd)
                {
                    dateTimePickerActualEnd.Value = RoadMapForProject.projectEnd.AddDays(-2);
                }
                if (dateTimePickerActualEnd.Value < dateTimePickerActualStart.Value)
                {
                    dateTimePickerActualEnd.Value = dateTimePickerActualStart.Value.AddDays(1);
                }
            }
            catch { }
        }

        private void comboBoxStage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {


                if (!edit)
                {
                    string description = ProjectStages.GetDescriptionById(comboBoxStage.SelectedValue.ToString());
                    if (description != "")
                    {
                        txtNotes.Text = description;
                    }
                }

            }
            catch { }
        }
    }
}
