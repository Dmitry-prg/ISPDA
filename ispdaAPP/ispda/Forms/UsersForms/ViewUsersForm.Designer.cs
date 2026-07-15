namespace ispda.Forms
{
    partial class ViewUsersForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewUsersForm));
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.выгрузитьВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настроитьОтображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripUsers = new System.Windows.Forms.MenuStrip();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBack = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.first_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.organization_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.organization_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.role_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.role_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_superuser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDel = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.menuStripUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.AllowUserToDeleteRows = false;
            this.dataGridViewUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.login,
            this.user_id,
            this.fio,
            this.last_name,
            this.first_name,
            this.patronymic,
            this.organization_id,
            this.organization_name,
            this.position_id,
            this.position_name,
            this.role_id,
            this.role_name,
            this.email,
            this.phone,
            this.is_active,
            this.is_superuser,
            this.btnDel});
            this.dataGridViewUsers.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridViewUsers.GridColor = System.Drawing.Color.PaleTurquoise;
            this.dataGridViewUsers.Location = new System.Drawing.Point(0, 33);
            this.dataGridViewUsers.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.ReadOnly = true;
            this.dataGridViewUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsers.Size = new System.Drawing.Size(1228, 245);
            this.dataGridViewUsers.TabIndex = 0;
            this.dataGridViewUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsers_CellContentClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выгрузитьВExcelToolStripMenuItem,
            this.настроитьОтображениеToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(210, 48);
            // 
            // выгрузитьВExcelToolStripMenuItem
            // 
            this.выгрузитьВExcelToolStripMenuItem.Name = "выгрузитьВExcelToolStripMenuItem";
            this.выгрузитьВExcelToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.выгрузитьВExcelToolStripMenuItem.Text = "Выгрузить в Excel";
            this.выгрузитьВExcelToolStripMenuItem.Click += new System.EventHandler(this.выгрузитьВExcelToolStripMenuItem_Click);
            // 
            // настроитьОтображениеToolStripMenuItem
            // 
            this.настроитьОтображениеToolStripMenuItem.Name = "настроитьОтображениеToolStripMenuItem";
            this.настроитьОтображениеToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.настроитьОтображениеToolStripMenuItem.Text = "Настроить отображение";
            this.настроитьОтображениеToolStripMenuItem.Click += new System.EventHandler(this.настроитьОтображениеToolStripMenuItem_Click);
            // 
            // menuStripUsers
            // 
            this.menuStripUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.menuStripUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.изменитьToolStripMenuItem});
            this.menuStripUsers.Location = new System.Drawing.Point(0, 0);
            this.menuStripUsers.Name = "menuStripUsers";
            this.menuStripUsers.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStripUsers.Size = new System.Drawing.Size(1228, 28);
            this.menuStripUsers.TabIndex = 2;
            this.menuStripUsers.Text = "menuStrip1";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.добавитьToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.добавитьToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.изменитьToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.изменитьToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(0, 286);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 28);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            // 
            // login
            // 
            this.login.DataPropertyName = "login";
            this.login.HeaderText = "Логин";
            this.login.Name = "login";
            this.login.ReadOnly = true;
            // 
            // user_id
            // 
            this.user_id.DataPropertyName = "user_id";
            this.user_id.HeaderText = "user_id";
            this.user_id.Name = "user_id";
            this.user_id.ReadOnly = true;
            this.user_id.Visible = false;
            // 
            // fio
            // 
            this.fio.DataPropertyName = "fio";
            this.fio.HeaderText = "ФИО";
            this.fio.Name = "fio";
            this.fio.ReadOnly = true;
            // 
            // last_name
            // 
            this.last_name.DataPropertyName = "last_name";
            this.last_name.HeaderText = "last_name";
            this.last_name.Name = "last_name";
            this.last_name.ReadOnly = true;
            this.last_name.Visible = false;
            // 
            // first_name
            // 
            this.first_name.DataPropertyName = "first_name";
            this.first_name.HeaderText = "first_name";
            this.first_name.Name = "first_name";
            this.first_name.ReadOnly = true;
            this.first_name.Visible = false;
            // 
            // patronymic
            // 
            this.patronymic.DataPropertyName = "patronymic";
            this.patronymic.HeaderText = "patronymic";
            this.patronymic.Name = "patronymic";
            this.patronymic.ReadOnly = true;
            this.patronymic.Visible = false;
            // 
            // organization_id
            // 
            this.organization_id.DataPropertyName = "organization_id";
            this.organization_id.HeaderText = "organization_id";
            this.organization_id.Name = "organization_id";
            this.organization_id.ReadOnly = true;
            this.organization_id.Visible = false;
            // 
            // organization_name
            // 
            this.organization_name.DataPropertyName = "organization_name";
            this.organization_name.HeaderText = "Организация";
            this.organization_name.Name = "organization_name";
            this.organization_name.ReadOnly = true;
            // 
            // position_id
            // 
            this.position_id.DataPropertyName = "position_id";
            this.position_id.HeaderText = "position_id";
            this.position_id.Name = "position_id";
            this.position_id.ReadOnly = true;
            this.position_id.Visible = false;
            // 
            // position_name
            // 
            this.position_name.DataPropertyName = "position_name";
            this.position_name.HeaderText = "Должность";
            this.position_name.Name = "position_name";
            this.position_name.ReadOnly = true;
            // 
            // role_id
            // 
            this.role_id.DataPropertyName = "role_id";
            this.role_id.HeaderText = "role_id";
            this.role_id.Name = "role_id";
            this.role_id.ReadOnly = true;
            this.role_id.Visible = false;
            // 
            // role_name
            // 
            this.role_name.DataPropertyName = "role_name";
            this.role_name.HeaderText = "Роль";
            this.role_name.Name = "role_name";
            this.role_name.ReadOnly = true;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // phone
            // 
            this.phone.DataPropertyName = "phone";
            this.phone.HeaderText = "Телефон";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            // 
            // is_active
            // 
            this.is_active.DataPropertyName = "is_active";
            this.is_active.HeaderText = "Действующая запись";
            this.is_active.Name = "is_active";
            this.is_active.ReadOnly = true;
            // 
            // is_superuser
            // 
            this.is_superuser.DataPropertyName = "is_superuser";
            this.is_superuser.HeaderText = "Суперпользователь";
            this.is_superuser.Name = "is_superuser";
            this.is_superuser.ReadOnly = true;
            // 
            // btnDel
            // 
            this.btnDel.HeaderText = "";
            this.btnDel.Name = "btnDel";
            this.btnDel.ReadOnly = true;
            this.btnDel.Text = "Удалить";
            this.btnDel.UseColumnTextForButtonValue = true;
            // 
            // ViewUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1228, 313);
            this.Controls.Add(this.menuStripUsers);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dataGridViewUsers);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1244, 352);
            this.Name = "ViewUsersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пользователи";
            this.Load += new System.EventHandler(this.ViewUsersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.menuStripUsers.ResumeLayout(false);
            this.menuStripUsers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.MenuStrip menuStripUsers;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem выгрузитьВExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настроитьОтображениеToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn login;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fio;
        private System.Windows.Forms.DataGridViewTextBoxColumn last_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn first_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronymic;
        private System.Windows.Forms.DataGridViewTextBoxColumn organization_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn organization_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn position_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn position_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn role_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn role_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_active;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_superuser;
        private System.Windows.Forms.DataGridViewButtonColumn btnDel;
    }
}