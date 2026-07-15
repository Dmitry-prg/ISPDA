using ispda.Entities;
using ispda.Forms.ControlsForms;
using ispda.Forms.DocumentsForms;
using ispda.Forms.HeadsOrganizationsForms;
using ispda.Forms.InfoForm;
using ispda.Forms.InitiativeRequestsForms;
using ispda.Forms.Projects;
using ispda.Forms.Reference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ispda.Forms
{
    public partial class MainMenuUserForm : Form
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

        public MainMenuUserForm()
        {
            InitializeComponent();
        }

        private void MainMenuUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Users.id = null;
            Users.name = null;
            Users.role = null;

        }

        private void проектыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewProjectsForm viewProjectsForm = new ViewProjectsForm();
            viewProjectsForm.Show();
        }

        private void MainMenuUserForm_Load(object sender, EventArgs e)
        {
            if(Users.role == "1")
                пользователиToolStripMenuItem.Visible = true;
            else
                пользователиToolStripMenuItem.Visible = false;

        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfileUserForm profileUserForm = new ProfileUserForm();
            profileUserForm.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewUsersForm viewUsersForm = new ViewUsersForm();
            viewUsersForm.ShowDialog();

        }

        private void заявкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewInitiativeRequestsForm viewInitiativeRequestsForm = new ViewInitiativeRequestsForm();
            viewInitiativeRequestsForm.ShowDialog();
        }

        private void организацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewReferenceForm.nameTable = "organizations";
            ViewReferenceForm viewReferenceForm = new ViewReferenceForm();
            viewReferenceForm.ShowDialog();
        }

        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewReferenceForm.nameTable = "positions";
            ViewReferenceForm viewReferenceForm = new ViewReferenceForm();
            viewReferenceForm.ShowDialog();
        }

        private void этапыПроектToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewReferenceForm.nameTable = "project_stages";
            ViewReferenceForm viewReferenceForm = new ViewReferenceForm();
            viewReferenceForm.ShowDialog();
        }

        private void видыДокументовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewReferenceForm.nameTable = "document_types";
            ViewReferenceForm viewReferenceForm = new ViewReferenceForm();
            viewReferenceForm.ShowDialog();
        }

        private void стейкхолдерыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewReferenceForm.nameTable = "stakeholder_types";
            ViewReferenceForm viewReferenceForm = new ViewReferenceForm();
            viewReferenceForm.ShowDialog();
        }

        private void статусыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewReferenceForm.nameTable = "statuses";
            ViewReferenceForm viewReferenceForm = new ViewReferenceForm();
            viewReferenceForm.ShowDialog();
        }

        private void решенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewReferenceForm.nameTable = "decisions";
            ViewReferenceForm viewReferenceForm = new ViewReferenceForm();
            viewReferenceForm.ShowDialog();
        }

        private void документыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDocumentsForStageProjectForm form = new ViewDocumentsForStageProjectForm();
            form.ShowDialog();
        }


        private void руководителиtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewHeadsOrganizationsForm  viewHeadsOrganizationsForm = new ViewHeadsOrganizationsForm();
            viewHeadsOrganizationsForm.ShowDialog();

        }
    }
}
