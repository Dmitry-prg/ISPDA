namespace ispda
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.panelLogInfo = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.checkBoxViewPassword = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.menuStripSet = new System.Windows.Forms.MenuStrip();
            this.btnSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиПодключенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.серверToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelStatus = new System.Windows.Forms.Label();
            this.saveFileDialogBD = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogBD = new System.Windows.Forms.OpenFileDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelLogInfo.SuspendLayout();
            this.menuStripSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelLogin
            // 
            this.labelLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLogin.AutoSize = true;
            this.labelLogin.ForeColor = System.Drawing.Color.Black;
            this.labelLogin.Location = new System.Drawing.Point(156, 73);
            this.labelLogin.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(47, 17);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Логин";
            // 
            // labelPassword
            // 
            this.labelPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPassword.AutoSize = true;
            this.labelPassword.ForeColor = System.Drawing.Color.Black;
            this.labelPassword.Location = new System.Drawing.Point(156, 164);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(57, 17);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Пароль";
            // 
            // txtLogin
            // 
            this.txtLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLogin.Location = new System.Drawing.Point(161, 104);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(5);
            this.txtLogin.MaxLength = 100;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(330, 23);
            this.txtLogin.TabIndex = 0;
            this.txtLogin.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // panelLogInfo
            // 
            this.panelLogInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.panelLogInfo.Controls.Add(this.progressBar);
            this.panelLogInfo.Controls.Add(this.checkBoxViewPassword);
            this.panelLogInfo.Controls.Add(this.btnLogin);
            this.panelLogInfo.Controls.Add(this.btnBack);
            this.panelLogInfo.Controls.Add(this.txtPassword);
            this.panelLogInfo.Controls.Add(this.txtLogin);
            this.panelLogInfo.Controls.Add(this.labelPassword);
            this.panelLogInfo.Controls.Add(this.labelLogin);
            this.panelLogInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogInfo.ForeColor = System.Drawing.Color.White;
            this.panelLogInfo.Location = new System.Drawing.Point(0, 28);
            this.panelLogInfo.Margin = new System.Windows.Forms.Padding(5);
            this.panelLogInfo.Name = "panelLogInfo";
            this.panelLogInfo.Size = new System.Drawing.Size(656, 374);
            this.panelLogInfo.TabIndex = 4;
            this.panelLogInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLogInfo_Paint);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 355);
            this.progressBar.Margin = new System.Windows.Forms.Padding(5);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(656, 19);
            this.progressBar.Step = 100;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 5;
            // 
            // checkBoxViewPassword
            // 
            this.checkBoxViewPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxViewPassword.AutoSize = true;
            this.checkBoxViewPassword.ForeColor = System.Drawing.Color.Black;
            this.checkBoxViewPassword.Location = new System.Drawing.Point(161, 229);
            this.checkBoxViewPassword.Margin = new System.Windows.Forms.Padding(5);
            this.checkBoxViewPassword.Name = "checkBoxViewPassword";
            this.checkBoxViewPassword.Size = new System.Drawing.Size(140, 21);
            this.checkBoxViewPassword.TabIndex = 2;
            this.checkBoxViewPassword.Text = "Показать пароль";
            this.checkBoxViewPassword.UseVisualStyleBackColor = true;
            this.checkBoxViewPassword.CheckedChanged += new System.EventHandler(this.checkBoxViewPassword_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(370, 267);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(125, 35);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Войти";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(161, 267);
            this.btnBack.Margin = new System.Windows.Forms.Padding(5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(125, 35);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Выйти";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Location = new System.Drawing.Point(161, 189);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassword.MaxLength = 255;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(330, 23);
            this.txtPassword.TabIndex = 1;
            // 
            // menuStripSet
            // 
            this.menuStripSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.menuStripSet.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStripSet.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripSet.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSettings});
            this.menuStripSet.Location = new System.Drawing.Point(0, 0);
            this.menuStripSet.Name = "menuStripSet";
            this.menuStripSet.Padding = new System.Windows.Forms.Padding(10, 2, 0, 2);
            this.menuStripSet.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStripSet.Size = new System.Drawing.Size(656, 28);
            this.menuStripSet.TabIndex = 5;
            this.menuStripSet.Text = "menuStrip1";
            // 
            // btnSettings
            // 
            this.btnSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиПодключенияToolStripMenuItem,
            this.серверToolStripMenuItem});
            this.btnSettings.Image = global::ispda.Properties.Resources.icon_settings;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(32, 24);
            this.btnSettings.DropDownOpening += new System.EventHandler(this.btnSettings_DropDownOpening);
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // настройкиПодключенияToolStripMenuItem
            // 
            this.настройкиПодключенияToolStripMenuItem.Name = "настройкиПодключенияToolStripMenuItem";
            this.настройкиПодключенияToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.настройкиПодключенияToolStripMenuItem.Text = "Подключение";
            this.настройкиПодключенияToolStripMenuItem.Click += new System.EventHandler(this.настройкиПодключенияToolStripMenuItem_Click);
            // 
            // серверToolStripMenuItem
            // 
            this.серверToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.импортToolStripMenuItem,
            this.экспортToolStripMenuItem});
            this.серверToolStripMenuItem.Name = "серверToolStripMenuItem";
            this.серверToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.серверToolStripMenuItem.Text = "Сервер";
            // 
            // импортToolStripMenuItem
            // 
            this.импортToolStripMenuItem.Name = "импортToolStripMenuItem";
            this.импортToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.импортToolStripMenuItem.Text = "Импорт";
            this.импортToolStripMenuItem.Click += new System.EventHandler(this.импортToolStripMenuItem_Click);
            // 
            // экспортToolStripMenuItem
            // 
            this.экспортToolStripMenuItem.Name = "экспортToolStripMenuItem";
            this.экспортToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.экспортToolStripMenuItem.Text = "Экспорт";
            this.экспортToolStripMenuItem.Click += new System.EventHandler(this.экспортToolStripMenuItem_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.labelStatus.Location = new System.Drawing.Point(0, 0);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(46, 17);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "status";
            // 
            // saveFileDialogBD
            // 
            this.saveFileDialogBD.Filter = "SQL files | *.sql";
            this.saveFileDialogBD.Title = "Сохранить SQL‑файл";
            // 
            // openFileDialogBD
            // 
            this.openFileDialogBD.Filter = "SQL files | *.sql";
            this.openFileDialogBD.Title = "Выберите SQL‑файл";
            // 
            // timer
            // 
            this.timer.Interval = 5;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(656, 402);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.panelLogInfo);
            this.Controls.Add(this.menuStripSet);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripSet;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panelLogInfo.ResumeLayout(false);
            this.panelLogInfo.PerformLayout();
            this.menuStripSet.ResumeLayout(false);
            this.menuStripSet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Panel panelLogInfo;
        private System.Windows.Forms.MenuStrip menuStripSet;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ToolStripMenuItem btnSettings;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox checkBoxViewPassword;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ToolStripMenuItem настройкиПодключенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem серверToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem импортToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экспортToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogBD;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.OpenFileDialog openFileDialogBD;
        private System.Windows.Forms.Timer timer;
    }
}

