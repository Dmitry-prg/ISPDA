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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ispda.Forms.ProjectsForms
{
    public partial class AddAndUpdateProjectTeamForm : Form
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
        public static string userId;
        public static string roleInProject;
        public static bool edit;


        public AddAndUpdateProjectTeamForm(bool update)
        {
            InitializeComponent();
            edit = update;
            if(edit)
            {
                Text = "Изменение участника проектной команды";
            }
            else
            {
                Text = "Добавление участника в проектную команду";
            }


        }

        private void AddAndUpdateProjectTeamForm_Load(object sender, EventArgs e)
        {
            Users.GetListForComboBox();
            comboBoxUser.DataSource = Users.dtListForComboBox;
            comboBoxUser.DisplayMember = "fio";
            comboBoxUser.ValueMember = "user_id";
            if(edit)
            {
                comboBoxUser.SelectedValue = userId;
                txtRole.Text = roleInProject;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(edit)
            {
                if(ProjectTeams.CheckDuplicate(comboBoxUser.SelectedValue.ToString()) || comboBoxUser.SelectedValue.ToString() == userId)
                {
                    if (ProjectTeams.Update(id, comboBoxUser.SelectedValue.ToString(), txtRole.Text))
                    {
                        Mes.Info("Информация об участнике проектной команды успешно изменена");
                        this.Close();
                    }
                    else
                    {
                        Mes.Error("Не получилось изменить информацию об участнике проектной команды");
                    }
                }
                else
                {
                    Mes.Warning("Такой участник уже есть в команде");
                }
                
            }
            else
            {
                if (ProjectTeams.CheckDuplicate(comboBoxUser.SelectedValue.ToString()))
                {
                    if (ProjectTeams.Add(comboBoxUser.SelectedValue.ToString(), txtRole.Text))
                    {
                        Mes.Info("Информация об участнике проектной команды успешно добавлена");
                        this.Close();
                    }
                    else
                    {
                        Mes.Error("Не получилось добавить информацию об участнике проектной команды");
                    }
                }
                else
                {
                    Mes.Warning("Такой участник уже есть в команде");
                }
            }
        }
    }
}
