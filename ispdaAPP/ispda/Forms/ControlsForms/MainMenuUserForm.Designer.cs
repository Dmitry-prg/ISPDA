namespace ispda.Forms
{
    partial class MainMenuUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuUserForm));
            this.menuStripUser = new System.Windows.Forms.MenuStrip();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проектыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заявкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.руководителиtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пользователиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.организацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.должностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.этапыПроектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видыДокументовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стейкхолдерыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статусыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.решенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogBD = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogBD = new System.Windows.Forms.SaveFileDialog();
            this.menuStripUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripUser
            // 
            this.menuStripUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.menuStripUser.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStripUser.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem,
            this.документыToolStripMenuItem,
            this.проектыToolStripMenuItem,
            this.заявкиToolStripMenuItem,
            this.руководителиtoolStripMenuItem,
            this.пользователиToolStripMenuItem,
            this.справочникиToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStripUser.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStripUser.Location = new System.Drawing.Point(0, 0);
            this.menuStripUser.Name = "menuStripUser";
            this.menuStripUser.Padding = new System.Windows.Forms.Padding(10, 2, 0, 2);
            this.menuStripUser.Size = new System.Drawing.Size(945, 28);
            this.menuStripUser.TabIndex = 0;
            this.menuStripUser.Text = "menu";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.profileToolStripMenuItem.Image = global::ispda.Properties.Resources.avatar_user;
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(32, 24);
            this.profileToolStripMenuItem.Click += new System.EventHandler(this.profileToolStripMenuItem_Click);
            // 
            // документыToolStripMenuItem
            // 
            this.документыToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.документыToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.документыToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.документыToolStripMenuItem.Name = "документыToolStripMenuItem";
            this.документыToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.документыToolStripMenuItem.Text = "Документы";
            this.документыToolStripMenuItem.Click += new System.EventHandler(this.документыToolStripMenuItem_Click);
            // 
            // проектыToolStripMenuItem
            // 
            this.проектыToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.проектыToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.проектыToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.проектыToolStripMenuItem.Name = "проектыToolStripMenuItem";
            this.проектыToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.проектыToolStripMenuItem.Text = "Проекты";
            this.проектыToolStripMenuItem.Click += new System.EventHandler(this.проектыToolStripMenuItem_Click);
            // 
            // заявкиToolStripMenuItem
            // 
            this.заявкиToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.заявкиToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.заявкиToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.заявкиToolStripMenuItem.Name = "заявкиToolStripMenuItem";
            this.заявкиToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.заявкиToolStripMenuItem.Text = "Заявки";
            this.заявкиToolStripMenuItem.Click += new System.EventHandler(this.заявкиToolStripMenuItem_Click);
            // 
            // руководителиtoolStripMenuItem
            // 
            this.руководителиtoolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.руководителиtoolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.руководителиtoolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.руководителиtoolStripMenuItem.Name = "руководителиtoolStripMenuItem";
            this.руководителиtoolStripMenuItem.Size = new System.Drawing.Size(254, 24);
            this.руководителиtoolStripMenuItem.Text = "Руководители организаций";
            this.руководителиtoolStripMenuItem.Click += new System.EventHandler(this.руководителиtoolStripMenuItem_Click);
            // 
            // пользователиToolStripMenuItem
            // 
            this.пользователиToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.пользователиToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.пользователиToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.пользователиToolStripMenuItem.Name = "пользователиToolStripMenuItem";
            this.пользователиToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.пользователиToolStripMenuItem.Text = "Пользователи";
            this.пользователиToolStripMenuItem.Click += new System.EventHandler(this.пользователиToolStripMenuItem_Click);
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.организацииToolStripMenuItem,
            this.должностиToolStripMenuItem,
            this.этапыПроектToolStripMenuItem,
            this.видыДокументовToolStripMenuItem,
            this.стейкхолдерыToolStripMenuItem,
            this.статусыToolStripMenuItem,
            this.решенияToolStripMenuItem});
            this.справочникиToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.справочникиToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // организацииToolStripMenuItem
            // 
            this.организацииToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.организацииToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.организацииToolStripMenuItem.Name = "организацииToolStripMenuItem";
            this.организацииToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.организацииToolStripMenuItem.Text = "Организации";
            this.организацииToolStripMenuItem.Click += new System.EventHandler(this.организацииToolStripMenuItem_Click);
            // 
            // должностиToolStripMenuItem
            // 
            this.должностиToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.должностиToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.должностиToolStripMenuItem.Name = "должностиToolStripMenuItem";
            this.должностиToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.должностиToolStripMenuItem.Text = "Должности";
            this.должностиToolStripMenuItem.Click += new System.EventHandler(this.должностиToolStripMenuItem_Click);
            // 
            // этапыПроектToolStripMenuItem
            // 
            this.этапыПроектToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.этапыПроектToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.этапыПроектToolStripMenuItem.Name = "этапыПроектToolStripMenuItem";
            this.этапыПроектToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.этапыПроектToolStripMenuItem.Text = "Этапы проектов";
            this.этапыПроектToolStripMenuItem.Click += new System.EventHandler(this.этапыПроектToolStripMenuItem_Click_1);
            // 
            // видыДокументовToolStripMenuItem
            // 
            this.видыДокументовToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.видыДокументовToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.видыДокументовToolStripMenuItem.Name = "видыДокументовToolStripMenuItem";
            this.видыДокументовToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.видыДокументовToolStripMenuItem.Text = "Виды документов";
            this.видыДокументовToolStripMenuItem.Click += new System.EventHandler(this.видыДокументовToolStripMenuItem_Click);
            // 
            // стейкхолдерыToolStripMenuItem
            // 
            this.стейкхолдерыToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.стейкхолдерыToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.стейкхолдерыToolStripMenuItem.Name = "стейкхолдерыToolStripMenuItem";
            this.стейкхолдерыToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.стейкхолдерыToolStripMenuItem.Text = "Виды участников";
            this.стейкхолдерыToolStripMenuItem.Click += new System.EventHandler(this.стейкхолдерыToolStripMenuItem_Click);
            // 
            // статусыToolStripMenuItem
            // 
            this.статусыToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.статусыToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.статусыToolStripMenuItem.Name = "статусыToolStripMenuItem";
            this.статусыToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.статусыToolStripMenuItem.Text = "Статусы";
            this.статусыToolStripMenuItem.Click += new System.EventHandler(this.статусыToolStripMenuItem_Click);
            // 
            // решенияToolStripMenuItem
            // 
            this.решенияToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.решенияToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.решенияToolStripMenuItem.Name = "решенияToolStripMenuItem";
            this.решенияToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.решенияToolStripMenuItem.Text = "Решения";
            this.решенияToolStripMenuItem.Click += new System.EventHandler(this.решенияToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.выходToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.выходToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // openFileDialogBD
            // 
            this.openFileDialogBD.Filter = "\"SQL files (*.sql)|*.sql\"";
            this.openFileDialogBD.Title = "Выберите SQL‑файл";
            // 
            // saveFileDialogBD
            // 
            this.saveFileDialogBD.Filter = "\"SQL files (*.sql)|*.sql\"";
            this.saveFileDialogBD.Title = "Сохранить SQL‑файл";
            // 
            // MainMenuUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(945, 425);
            this.Controls.Add(this.menuStripUser);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripUser;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenuUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenuUserForm_FormClosed);
            this.Load += new System.EventHandler(this.MainMenuUserForm_Load);
            this.menuStripUser.ResumeLayout(false);
            this.menuStripUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStripUser;
        private System.Windows.Forms.ToolStripMenuItem проектыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заявкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пользователиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem организацииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem должностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem этапыПроектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видыДокументовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статусыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem решенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стейкхолдерыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem руководителиtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogBD;
        private System.Windows.Forms.SaveFileDialog saveFileDialogBD;
    }
}