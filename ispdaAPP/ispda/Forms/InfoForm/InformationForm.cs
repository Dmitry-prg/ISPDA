using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ispda.Forms.InfoForm
{
    public partial class InformationForm : Form
    {
        public static string item = "all";
        public InformationForm()
        {
            InitializeComponent();
        }
        private static void SetTabControlItemSize(System.Windows.Forms.Control parent, Size newItemSize)
        {
            foreach (System.Windows.Forms.Control control in parent.Controls)
            {
                if (control is TabControl tabControl)
                {
                    // Изменяем размер вкладок
                    tabControl.ItemSize = newItemSize;
                    
                }

                // Рекурсивно обходим дочерние элементы текущего контрола
                if (control.HasChildren)
                {
                    SetTabControlItemSize(control, newItemSize);
                }
            }
        }

        private void InformationForm_Load(object sender, EventArgs e)
        {
            SetTabControlItemSize(this, new Size(0, 1));
            if(item != "all")
            {
                treeView_AfterSelect(treeViewInfo, new TreeViewEventArgs(treeViewInfo.Nodes.Find(item, true)[0]));
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "main":
                    {
                        tabControlInfo.SelectedTab = tabPageMain;
                        txtPath.Text = "О программе";
                        break;
                    }
                case "login":
                    {
                        tabControlInfo.SelectedTab = tabPageLogin;
                        txtPath.Text = "Авторизация";
                        break;
                    }

                case "projects":
                    {
                        tabControlInfo.SelectedTab = tabPageProjects;
                        tabControlProjects.SelectedTab = tabPageViewProjects;
                        txtPath.Text = "Проекты";
                        break;
                    }  
                case "roadMap":
                    {
                        tabControlInfo.SelectedTab = tabPageProjects;
                        tabControlProjects.SelectedTab = tabPageRoadMap;
                        txtPath.Text = "Проекты/Дорожная карта проекта";
                        break;
                    } 

                case "headsOrganizations":
                    {
                        tabControlInfo.SelectedTab = tabPageHeadsOrganizations;
                        txtPath.Text = "Руководители организаций";
                        break;
                    }

              
            }
        }
    }
}
