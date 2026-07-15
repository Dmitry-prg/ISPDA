using DocumentFormat.OpenXml.Office2021.MipLabelMetaData;
using ispda.Classes.Entities;
using ispda.Entities;
using ispda.Forms.InfoForm;
using ispda.Forms.Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ispda.Forms.DocumentsForms
{
    public partial class AddAndUpdateDocumentForm : Form
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

        public AddAndUpdateDocumentForm()
        {
            InitializeComponent();
        }
        public static string path;
        public static string itemId = null;
        
        
      
        private void btnActive_Click(object sender, EventArgs e)
        {
            if (btnActive.Text == "Добавить")
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                    txtFileName.Text = openFileDialog.SafeFileName;
                    btnActive.Text = "Удалить";
                }
            }
            else
            {
                txtFileName.Text = path = null;
            }
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddAndUpdateDocumentForm_Load(object sender, EventArgs e)
        {
            

            Classes.Entities.Projects.GetListForComboBox();
            comboBoxProjects.DataSource = Classes.Entities.Projects.dtProjectsForComboBox;
            comboBoxProjects.DisplayMember = "name";
            comboBoxProjects.ValueMember = "project_id";
            if(RoadMapForProject.id != null)
            {
                comboBoxProjects.SelectedValue = RoadMapForProject.id;
            }
            else
            {
                comboBoxProjects.SelectedIndex = 0;
            }
            DocumentTypes.GetListForComboBox();
            comboBoxDocTypes.DataSource = DocumentTypes.dtListForComboBox;
            comboBoxDocTypes.DisplayMember = "document_type_name";
            comboBoxDocTypes.ValueMember = "document_type_id";
            comboBoxDocTypes.SelectedIndex = 0;

            RoadMapItems.GetListForComboBox(comboBoxProjects.SelectedValue.ToString());
            comboBoxItems.DataSource = RoadMapItems.dtItems;
            comboBoxItems.DisplayMember = "stage_name";
            comboBoxItems.ValueMember = "roadmap_item_id";
            if (comboBoxItems.Items.Count > 0)
            {
                if (itemId != null)
                {
                    comboBoxItems.SelectedValue = itemId;
                }
                else
                {
                    comboBoxItems.SelectedIndex = 0;
                }
            }

        }

        private void comboBoxProjects_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RoadMapItems.GetListForComboBox(comboBoxProjects.SelectedValue.ToString());
            comboBoxItems.DataSource = RoadMapItems.dtItems;
            comboBoxItems.DisplayMember = "stage_name";
            comboBoxItems.ValueMember = "roadmap_item_id";
            if(comboBoxItems.Items.Count > 0)
            {
                if(itemId != null)
                {
                    comboBoxItems.SelectedValue = itemId;
                }
                else
                {
                    comboBoxItems.SelectedIndex = 0;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(comboBoxProjects.SelectedIndex != -1 &&  comboBoxItems.SelectedIndex != -1 && comboBoxDocTypes.SelectedIndex != -1 && txtNumber.Text != string.Empty)
            {
                if(txtFileName.Text.Length > 0)
                {
                    if(Documents.Add(comboBoxItems.SelectedValue.ToString(), comboBoxDocTypes.SelectedValue.ToString(), txtNumber.Text, txtFileName.Text, DateTime.Now.ToString("yyyy-MM-dd")))
                    {
                        if (File.Exists($@"./SRC/Scans/{txtFileName.Text}"))
                        {
                            File.Delete($@"./SRC/Scans/{txtFileName.Text}");
                        }
                        File.Copy(path, $@"./SRC/Scans/{txtFileName.Text}");
                        Mes.Info("Документ успешно добавлен");
                        this.Close();
                    }
                    else
                    {
                        Mes.Error("Не получилось добавить документ");
                    }
                }
                else
                {
                    Mes.Warning("Файл не выбран");
                }
            }
            else
            {
                Mes.Warning("Заполните все поля");
            }
        }
    }
}
