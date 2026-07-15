using ispda.Classes.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ispda.Forms;
using ispda.Forms.Projects;
using ispda.Entities;

namespace ispda.Forms.ProjectsForms
{
    public partial class AddAndUpdateRequiredDocForm : Form
    {
        public static string id, itemId, docTypeId;
        public static bool update;
        public AddAndUpdateRequiredDocForm(bool edit)
        {
            InitializeComponent();
            update = edit;
            if (update)
            {
                Text = "Изменение обязательного документа";
            }
            else
            {
                Text = "Добавление обязательного документа";
            }
        }

        private void AddAndUpdateRequiredDocForm_Load(object sender, EventArgs e)
        {
            RoadMapItems.GetListForComboBox(RoadMapForProject.id);
            if(RoadMapItems.dtItems.Rows.Count == 0)
            {
                Mes.Warning("Перед указанием обязательных документов для этапов добавьте этапы в дорожную карту проекта");
                this.Close();
            }
            comboBoxItems.DataSource = RoadMapItems.dtItems;
            comboBoxItems.DisplayMember = "stage_name";
            comboBoxItems.ValueMember = "roadmap_item_id";
            

            DocumentTypes.GetListForComboBox();
            comboBoxDocTypes.DataSource = DocumentTypes.dtListForComboBox;
            comboBoxDocTypes.DisplayMember = "document_type_name";
            comboBoxDocTypes.ValueMember = "document_type_id";

            if (update)
            {
                comboBoxItems.SelectedValue = itemId;
                comboBoxDocTypes.SelectedValue = docTypeId;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (update)
            {
                if(RequiredDocsStageProject.Update(id, comboBoxItems.SelectedValue.ToString(), comboBoxDocTypes.SelectedValue.ToString()))
                {
                    Mes.Info("Обязательный документ успешно изменён");
                    this.Close();
                }
                else
                {
                    Mes.Error("Не получилось изменить обязательный документ");
                }
            }
            else
            {
                if (RequiredDocsStageProject.Add(comboBoxItems.SelectedValue.ToString(), comboBoxDocTypes.SelectedValue.ToString()))
                {
                    Mes.Info("Обязательный документ успешно добавлен");
                    this.Close();
                }
                else
                {
                    Mes.Error("Не получилось добавить обязательный документ");
                }
            }
        }
    }
}
