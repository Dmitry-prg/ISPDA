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
using static System.Resources.ResXFileRef;

namespace ispda.Forms.ProjectsForms
{
    public partial class SetDateForStageForm : Form
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
        public static DateTime start;
        public static DateTime end;
        public static string turn;
        public static bool actual = false;


        public SetDateForStageForm()
        {
            InitializeComponent();
            if (actual)
            {
                Text = "Выбор фактических дат";
            }
            else
            {
                Text = "Выбор планируемых дат";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
           
            if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
            {
                dateTimePickerEnd.Value = dateTimePickerStart.Value;
            }
        }

        private void dateTimePickeeEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerEnd.Value < dateTimePickerStart.Value)
            {
                dateTimePickerEnd.Value = dateTimePickerStart.Value;
            }
        }

        private void SetDateForStageForm_Load(object sender, EventArgs e)
        {
            try
            {
                dateTimePickerStart.MinDate = RoadMapForProject.projectStart;
                dateTimePickerEnd.MinDate = RoadMapForProject.projectStart;
                dateTimePickerStart.MaxDate = RoadMapForProject.projectEnd;
                dateTimePickerEnd.MaxDate = RoadMapForProject.projectEnd;
                var s = RoadMapItems.GetDateTurnLimit(turn, RoadMapForProject.id, actual);     
                if(s.Item1 != "")
                {
                    dateTimePickerStart.MinDate = Convert.ToDateTime(s.Item1);
                    dateTimePickerEnd.MinDate = Convert.ToDateTime(s.Item1);
                }
                if(s.Item2 != "")
                {
                    dateTimePickerStart.MaxDate = Convert.ToDateTime(s.Item2);
                    dateTimePickerEnd.MaxDate = Convert.ToDateTime(s.Item2);
                }
                dateTimePickerStart.Value = start;
                dateTimePickerEnd.Value = end;
        }
            catch
            {
            }
}

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(dateTimePickerStart.Value != dateTimePickerEnd.Value)
            {
                if (actual)
                {
                    if(RoadMapItems.SetDateActual(id, dateTimePickerStart.Value.ToString("yyyy-MM-dd"), dateTimePickerEnd.Value.ToString("yyyy-MM-dd")))
                    {
                        Mes.Info("Даты успешно установлены");
                        this.Close();
                    }
                    else
                    {
                        Mes.Error("Не удалось установить даты");
                    }
                }
                else
                {
                    if (RoadMapItems.SetDatePlanned(id, dateTimePickerStart.Value.ToString("yyyy-MM-dd"), dateTimePickerEnd.Value.ToString("yyyy-MM-dd")))
                    {
                        Mes.Info("Даты успешно установлены");
                        this.Close();
                    }
                    else
                    {
                        Mes.Error("Не удалось установить даты");
                    }
                }
            }
            else
            {
                Mes.Warning("Выберите корректный период");
            }
        }
    }
}
