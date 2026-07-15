using DocumentFormat.OpenXml.Wordprocessing;
using ispda.Classes.Entities;
using ispda.Entities;
using ispda.Forms.ControlsForms;
using ispda.Forms.InfoForm;
using ispda.Forms.Projects;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ispda.Forms.DocumentsForms
{
    public partial class ViewDocumentsForStageProjectForm : Form
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

        public ViewDocumentsForStageProjectForm()
        {
            InitializeComponent();
        }

        private void UpdateData()
        {
            Documents.GetList();
            dataGridViewDocuments.DataSource = Documents.dtDocuments;
        }

        private void ViewDocumentsForStageProjectForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (Users.role == "2")
                {
                    menuStripDocuments.Visible = false;
                }
                else
                {
                    menuStripDocuments.Visible = true;
                }

                Classes.Entities.Projects.GetListForComboBox();
                comboBoxProject.DataSource = Classes.Entities.Projects.dtProjectsForComboBox;
                comboBoxProject.DisplayMember = "Name";
                comboBoxProject.ValueMember = "project_id";
                UpdateData();
            }
            catch { }
        }

        private void comboBoxProject_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Documents.filterSql = $@"projects.project_id = '{comboBoxProject.SelectedValue}'";
            UpdateData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Documents.filterSql = "true";
            UpdateData();
        }

        private void dataGridViewDocuments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dataGridViewDocuments.Columns["btnOpen"].Index == e.ColumnIndex)
                {
                    try
                    {
                        string path = dataGridViewDocuments.Rows[e.RowIndex].Cells["scan_path"].Value.ToString();
                        //  Получаем путь к папке
                        string currentPath = AppDomain.CurrentDomain.BaseDirectory;
                        string relativePath = Path.Combine(currentPath, "SRC", "Scans", path);

                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(relativePath) { UseShellExecute = true });                        
                    }
                    catch (Exception ex) {Mes.Error(ex.Message); }                    
                }
                if (dataGridViewDocuments.Columns["btnDel"].Index == e.ColumnIndex)
                {
                    string number = dataGridViewDocuments.Rows[e.RowIndex].Cells["document_number"].Value.ToString();
                    string id = dataGridViewDocuments.Rows[e.RowIndex].Cells["document_id"].Value.ToString();
                    if (Mes.Question($"Вы действительно хотите безвозвратно удалить документ с номером '{number}' ?") == DialogResult.OK)
                    {
                        if (Documents.Del(id))
                        {
                            Mes.Info("Документ успешно удален");
                            UpdateData();
                        }
                        else
                        {
                            Mes.Error("Не получилось удалить документ");
                        }
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAndUpdateDocumentForm addAndUpdateDocumentForm = new AddAndUpdateDocumentForm();
            addAndUpdateDocumentForm.ShowDialog();
            UpdateData();
        }

        private void настроитьОтображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingViewGridForm settingViewGridForm = new SettingViewGridForm(dataGridViewDocuments);
            settingViewGridForm.ShowDialog();
            var columns = SettingViewGridForm.columns;
            foreach (DataGridViewColumn column in dataGridViewDocuments.Columns)
            {
                if (columns.ContainsKey(column.Name))
                {
                    column.Visible = columns[column.Name];
                }
            }
        }
    }
}
