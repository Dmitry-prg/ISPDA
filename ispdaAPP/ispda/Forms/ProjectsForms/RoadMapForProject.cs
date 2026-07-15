using GanttChart;
using ispda.Classes;
using ispda.Classes.Entities;
using ispda.Entities;
using ispda.Forms.DocumentsForms;
using ispda.Forms.InfoForm;
using ispda.Forms.ProjectsForms;
using Mysqlx;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ispda.Forms.Projects
{
    public partial class RoadMapForProject : Form
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
        public static string number;
        public static string name;
        public static string notes;
        public static DateTime projectStart;
        public static DateTime projectEnd;
        public static int countStage;
        public static string select;

        public RoadMapForProject()
        {
            InitializeComponent();
 
        }
        /// <summary>
        /// Форма
        /// </summary>
        private void UpdateData()
        {
            try
            {
                panelRoadMap.Controls.Clear();
                chart = RoadMapItems.GetList(id, projectStart, projectEnd);
                if (chart != null)
                {
                    countStage = chart.Rows.Count;
                    panelRoadMap.Controls.Add(chart);
                    chart.RowRightClick += Chart_RowRightClick;
                }

                ProjectTeams.GetList(id);
                dataGridViewProjectTeam.DataSource = ProjectTeams.dtList;

                



            }
            catch { }

        }

        private void UpdateData2()
        {
            try
            {
                RequiredDocsStageProject.GetList(id);
                dataGridViewRequiredDoc.DataSource = RequiredDocsStageProject.dtReqiredDoc;
                for (int i = 0; i < dataGridViewRequiredDoc.Rows.Count; i++)
                {
                    if (dataGridViewRequiredDoc.Rows[i].Cells["complete"].Value.ToString() == "1")
                    {
                        dataGridViewRequiredDoc.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                        dataGridViewRequiredDoc.Rows[i].DefaultCellStyle.SelectionBackColor = Color.DarkGreen;
                    }
                    else
                    {
                        dataGridViewRequiredDoc.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        dataGridViewRequiredDoc.Rows[i].DefaultCellStyle.SelectionBackColor = Color.DarkRed;
                    }
                    dataGridViewRequiredDoc.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }

                RoadMapItems.GetListForComboBox(id);
                comboBoxItems.DataSource = RoadMapItems.dtItems;
                comboBoxItems.DisplayMember = "stage_name";
                comboBoxItems.ValueMember = "roadmap_item_id";

            }
            catch { }

        }
        private void RoadMapForProject_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                Text += $" '{number}'";
                UpdateData();
                UpdateData2();
            }
            catch { }
        }
        private void splitContainerRoadMap_Panel1_SizeChanged(object sender, EventArgs e)
        {
            if (splitContainerRoadMap.Panel1.Width <= 160)
            {
                groupBoxTeam.Visible = false;
            }
            else
            {
                groupBoxTeam.Visible = true;
            }

        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (splitContainerRoadMap.Panel1Collapsed)
            {
                splitContainerRoadMap.Panel1Collapsed = false;
            }
            else
            {
                splitContainerRoadMap.Panel1Collapsed = true;
            }
        }
        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Экспорт дорожной карты в PNG
        /// </summary>
        /// <param name="control"></param>
        /// <param name="fileName"></param>
        private void SaveControlToImage(Control control, string fileName)
        {
            try
            {

                Bitmap bmp = new Bitmap(control.Width, control.Height);

                control.DrawToBitmap(bmp, new Rectangle(0, 0, control.Width, control.Height));

                bmp.Save(fileName, ImageFormat.Png);

                bmp.Dispose();
            }
            catch { }
        }
        private void экспортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialogImage.ShowDialog() == DialogResult.OK)
                {
                    (int, int) currentSize = (panelRoadMap.Width, panelRoadMap.Height);
                    panelRoadMap.Width = 25 * (projectEnd - projectStart).Days;
                    panelRoadMap.Height = 30 * countStage + 40;
                    SaveControlToImage(panelRoadMap, saveFileDialogImage.FileName);
                    panelRoadMap.Width = currentSize.Item1;
                    panelRoadMap.Height = currentSize.Item2;
                    Mes.Info("Файл сформирован");
                }
            }
            catch { }
        }


        /// <summary>
        /// Этапы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void добавитьЭтапToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddAndUpdateStageForProjectForm addAndUpdateStageForProjectForm = new AddAndUpdateStageForProjectForm(false);
                addAndUpdateStageForProjectForm.ShowDialog();
                UpdateData();
                UpdateData2();
            }
            catch {}
        }
        private void Chart_RowRightClick(RowClickedEventArgs e)
        {
            try
            {
                var chart = (Chart)panelRoadMap.Controls[0];
                List<Row> rows = new List<Row>();
                foreach (var row in chart.Rows)
                {
                    if (row.TimeBlocks.Count > 0)
                    {
                        if (row.type == e.ClickedRow.type)
                        {
                            rows.Add(row);
                        }
                    }

                }
                AddAndUpdateStageForProjectForm.id = e.ClickedRow.id;
                AddAndUpdateDocumentForm.itemId = e.ClickedRow.id;
                AddAndUpdateStageForProjectForm.stageId = e.ClickedRow.type;
                AddAndUpdateStageForProjectForm.turn = e.ClickedRow.turn;
                if (rows.Count > 0)
                {
                    AddAndUpdateStageForProjectForm.plannedStartDate = rows[0].TimeBlocks[0].StartTime;
                    AddAndUpdateStageForProjectForm.plannedEndDate = rows[0].TimeBlocks[0].EndTime;
                    AddAndUpdateStageForProjectForm.notes = rows[0].notes;
                }
                if (rows.Count == 2)
                {
                    AddAndUpdateStageForProjectForm.actualStartDate = rows[1].TimeBlocks[0].StartTime;
                    AddAndUpdateStageForProjectForm.actualEndDate = rows[1].TimeBlocks[0].EndTime;
                }

                rowStageMenu.Show(panelRoadMap, e.CursorLocation);
            }
            catch { }
        }
        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddAndUpdateStageForProjectForm addAndUpdateStageForProjectForm = new AddAndUpdateStageForProjectForm(true);
                addAndUpdateStageForProjectForm.ShowDialog();
                UpdateData();
                UpdateData2();
            }
            catch { }
        }
        private void добавитьДокументToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddAndUpdateDocumentForm addAndUpdateDocumentForm = new AddAndUpdateDocumentForm();
                addAndUpdateDocumentForm.ShowDialog();
            }
            catch { }
        }
        private void планируемыйПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (RoadMapItems.SetDatePlanned(AddAndUpdateStageForProjectForm.id, null, null))
                    Mes.Info("Успешно");
                else
                    Mes.Error("Не удалось очистить даты");

                UpdateData();
            }
            catch { }
        }
        private void фактическийПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (RoadMapItems.SetDateActual(AddAndUpdateStageForProjectForm.id, null, null))
                    Mes.Info("Успешно");
                else
                    Mes.Error("Не удалось очистить даты");

                UpdateData();
            }
            catch { }
        }
        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Mes.Question("Вы действительно хотите удалить этап из проекта?") == DialogResult.OK)
                {
                    if (RoadMapItems.Del(AddAndUpdateStageForProjectForm.id))
                    {
                        Mes.Info("Этап удалён из проекта");
                        UpdateData();
                        UpdateData2();
                    }
                    else
                    {
                        Mes.Error("Не получилось удалить этап из проекта");
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Проектная команда
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddAndUpdateProjectTeamForm addAndUpdateProjectTeamForm = new AddAndUpdateProjectTeamForm(false);
                addAndUpdateProjectTeamForm.ShowDialog();
                UpdateData();
            }
            catch { }
        }
        private void изменитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridViewProjectTeam.SelectedRows.Count == 1)
                {
                    AddAndUpdateProjectTeamForm.id = dataGridViewProjectTeam.CurrentRow.Cells["project_team_id"].Value.ToString();
                    AddAndUpdateProjectTeamForm.userId = dataGridViewProjectTeam.CurrentRow.Cells["user_id"].Value.ToString();
                    AddAndUpdateProjectTeamForm.roleInProject = dataGridViewProjectTeam.CurrentRow.Cells["role_in_project"].Value.ToString();
                    AddAndUpdateProjectTeamForm addAndUpdateProjectTeamForm = new AddAndUpdateProjectTeamForm(true);
                    addAndUpdateProjectTeamForm.ShowDialog();
                    UpdateData();
                }
            }
            catch { }
        }
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewProjectTeam.SelectedRows.Count == 1)
                {
                    if (Mes.Question("Вы действительно хотите удалить участника проектной команды?") == DialogResult.OK)
                    {
                        if (ProjectTeams.Del(dataGridViewProjectTeam.CurrentRow.Cells["project_team_id"].Value.ToString()))
                        {
                            Mes.Info("Участник успешно удалён");
                            UpdateData();
                        }
                        else
                        {
                            Mes.Error("Не получилось удалить участника");
                        }
                    }
                }
            }
            catch { }
        }
        private void dataGridViewProjectTeam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewProjectTeam.Columns[e.ColumnIndex].Name == "btnViewAllProjectForUser")
                {
                    if (e.RowIndex >= 0)
                    {
                        Classes.Entities.Projects.GetListByUser(dataGridViewProjectTeam.Rows[e.RowIndex].Cells["user_id"].Value.ToString());
                        if (Classes.Entities.Projects.dtProjectsbyUser.Rows.Count > 1)
                        {
                            DataTable dt = Classes.Entities.Projects.dtProjectsbyUser;
                            string mes = "Текущие проекты сотрудника\r\nНомер | Наименование\r\n";
                            foreach (DataRow row in dt.Rows)
                            {
                                mes += row[0].ToString() + " | " + row[1].ToString() + "\r\n";
                            }
                            Mes.Info(mes);
                        }
                        else
                        {
                            Mes.Info("У данного участника нет проектов со статусом 'в работе' ");
                        }

                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Документы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void актЗавершенияРаботToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Doc.CreateActCompleteWork(DateTime.Now, saveFileDialog.FileName))
                    {
                        Mes.Info("Файл успешно сформирован");
                    }
                    else
                    {
                        Mes.Error("Не получилось сформировать файл");
                    }

                }
            }
            catch { }
        }

        private void журналОпытнойЭксплуатацииToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Doc.CreateTrialOperationLog(DateTime.Now, saveFileDialog.FileName))
                    {
                        Mes.Info("Файл успешно сформирован");
                    }
                    else
                    {
                        Mes.Error("Не получилось сформировать файл");
                    }

                }
            }
            catch { }
        }

        private void актПриемапередачиВОпытнуюЭксплуатациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Doc.CreateActAcceptanceTransferIntoTrialOperation(DateTime.Now, saveFileDialog.FileName))
                    {
                        Mes.Info("Файл успешно сформирован");
                    }
                    else
                    {
                        Mes.Error("Не получилось сформировать файл");
                    }

                }
            }
            catch { }
        }

        private void календарныйПланToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Doc.CreateCalendarPlanProject(DateTime.Now, saveFileDialog.FileName))
                        Mes.Info("Файл сформирован");
                    else
                        Mes.Error("Не удалось сформировать файл");
                }
            }
            catch { }
        }

        private void уставПроектаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Doc.CreateProjectCharter(DateTime.Now, saveFileDialog.FileName))
                        Mes.Info("Файл сформирован");
                    else
                        Mes.Error("Не удалось сформировать файл");
                }
            }
            catch { }
        }

        private void тЗToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Doc.CreateTechnicalSpecification(DateTime.Now, saveFileDialog.FileName))
                        Mes.Info("Файл сформирован");
                    else
                        Mes.Error("Не удалось сформировать файл");
                }
            }
            catch { }
        }

        private void приказОНачалеПроектныхРаботToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Doc.CreateOrderBeginningProjectWork(DateTime.Now, saveFileDialog.FileName))
                        Mes.Info("Файл сформирован");
                    else
                        Mes.Error("Не удалось сформировать файл");
                }
            }
            catch { }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewRequiredDoc.SelectedRows.Count == 1)
                {
                    string id = dataGridViewRequiredDoc.CurrentRow.Cells["required_docs_stage_project_id"].Value.ToString();
                    if (Mes.Question($"Вы действительно хотите удалить обязательный документ?") == DialogResult.OK)
                    {
                        if (RequiredDocsStageProject.Del(id))
                        {
                            Mes.Info("Обязательный документ успешно удалён");
                            UpdateData();
                        }
                        else
                        {
                            Mes.Error("Не получилось удалить обязательный документ");
                        }
                    }

                }
                else
                {
                    Mes.Warning("Выберите один обязательный документ, который необходимо удалить");
                }
            }
            catch { }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                AddAndUpdateRequiredDocForm addAndUpdateRequiredDocForm = new AddAndUpdateRequiredDocForm(false);
                addAndUpdateRequiredDocForm.ShowDialog();
                UpdateData();
            }
            catch { }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewRequiredDoc.SelectedRows.Count == 1)
                {
                    AddAndUpdateRequiredDocForm.id = dataGridViewRequiredDoc.CurrentRow.Cells["required_docs_stage_project_id"].Value.ToString();
                    AddAndUpdateRequiredDocForm.itemId = dataGridViewRequiredDoc.CurrentRow.Cells["roadmap_item_id"].Value.ToString();
                    AddAndUpdateRequiredDocForm.docTypeId = dataGridViewRequiredDoc.CurrentRow.Cells["document_type_id"].Value.ToString();

                    AddAndUpdateRequiredDocForm addAndUpdateRequiredDocForm = new AddAndUpdateRequiredDocForm(true);
                    addAndUpdateRequiredDocForm.ShowDialog();
                    UpdateData();
                }
                else
                {
                    Mes.Warning("Выберите один обязательный документ, который необходимо изменить");
                }
            }
            catch { }
        }

        private void dataGridViewRequiredDoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBoxItems_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                RequiredDocsStageProject.filter = $@"ri.stage_id = '{comboBoxItems.SelectedValue}'";
                UpdateData();
            }
            catch { }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            RequiredDocsStageProject.filter = "true";
            UpdateData();
            UpdateData2();
        }
    }
}
