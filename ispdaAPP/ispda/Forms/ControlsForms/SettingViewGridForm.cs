using ispda.Entities;
using ispda.Forms.InfoForm;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ispda.Forms.ControlsForms
{

    public partial class SettingViewGridForm : Form
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

        public static Dictionary<string, bool> columns = new Dictionary<string, bool>();

        public SettingViewGridForm(DataGridView data)
        {
            InitializeComponent();
            foreach (DataGridViewColumn col in data.Columns)
            {
                if ((col.HeaderText.IsCyrillic() || col.HeaderText.All(char.IsUpper)) && col.HeaderText.Length > 0)
                {
                    CheckBox c = new CheckBox();
                    c.Name = col.Name;
                    c.Text = col.HeaderText;
                    c.Width = flowLayoutPanelFields.Width - 25;
                    if (col.Visible)
                    {
                        c.Checked = true;
                    }
                    flowLayoutPanelFields.Controls.Add(c);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingViewGridForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            columns = new Dictionary<string, bool>();
            foreach (CheckBox c in flowLayoutPanelFields.Controls)
            {
                try
                {
                    columns.Add(c.Name, c.Checked);
                }
                catch { Mes.Error(c.Name); }

            }
            if (columns.ContainsValue(true))
            {
                this.Close();
            }
            else
            {
                Mes.Warning("Для сохранения полного функционала программы необходимо оставить видимым как минимум одно поле");
                columns.Clear();
            }

        }
    }

    public static class StringExtensions
    {
        public static bool IsCyrillic(this string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"^[а-яёА-ЯЁ\s]+$");
        }
    }
}
