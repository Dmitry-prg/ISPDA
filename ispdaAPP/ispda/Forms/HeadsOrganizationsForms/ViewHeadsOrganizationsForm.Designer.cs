namespace ispda.Forms.HeadsOrganizationsForms
{
    partial class ViewHeadsOrganizationsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewHeadsOrganizationsForm));
            this.btnBack = new System.Windows.Forms.Button();
            this.dataGridViewHead = new System.Windows.Forms.DataGridView();
            this.head_organization_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fio_head = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fio_head_genitive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fio_head_dative = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.short_fio_head = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.short_fio_head_reverse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.organization_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.full_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position_genitive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acts_on_the_basis_of = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.period_validity_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.period_validity_end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStripHeadsOrg = new System.Windows.Forms.MenuStrip();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.comboBoxOrganizations = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.выгрузитьВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настроитьОтображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHead)).BeginInit();
            this.menuStripHeadsOrg.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(3, 304);
            this.btnBack.Margin = new System.Windows.Forms.Padding(5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(107, 31);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dataGridViewHead
            // 
            this.dataGridViewHead.AllowUserToAddRows = false;
            this.dataGridViewHead.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewHead.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewHead.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewHead.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHead.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.dataGridViewHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHead.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.head_organization_id,
            this.fio_head,
            this.fio_head_genitive,
            this.fio_head_dative,
            this.short_fio_head,
            this.short_fio_head_reverse,
            this.organization_id,
            this.full_name,
            this.position_id,
            this.position_name,
            this.position_genitive,
            this.acts_on_the_basis_of,
            this.period_validity_start,
            this.period_validity_end});
            this.dataGridViewHead.GridColor = System.Drawing.Color.PaleTurquoise;
            this.dataGridViewHead.Location = new System.Drawing.Point(3, 33);
            this.dataGridViewHead.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridViewHead.Name = "dataGridViewHead";
            this.dataGridViewHead.ReadOnly = true;
            this.dataGridViewHead.RowHeadersWidth = 51;
            this.dataGridViewHead.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHead.Size = new System.Drawing.Size(961, 261);
            this.dataGridViewHead.TabIndex = 16;
            // 
            // head_organization_id
            // 
            this.head_organization_id.DataPropertyName = "head_organization_id";
            this.head_organization_id.HeaderText = "head_organization_id";
            this.head_organization_id.Name = "head_organization_id";
            this.head_organization_id.ReadOnly = true;
            this.head_organization_id.Visible = false;
            // 
            // fio_head
            // 
            this.fio_head.DataPropertyName = "fio_head";
            this.fio_head.HeaderText = "ФИО руководителя";
            this.fio_head.Name = "fio_head";
            this.fio_head.ReadOnly = true;
            // 
            // fio_head_genitive
            // 
            this.fio_head_genitive.DataPropertyName = "fio_head_genitive";
            this.fio_head_genitive.HeaderText = "ФИО руководителя в родительном падеже";
            this.fio_head_genitive.Name = "fio_head_genitive";
            this.fio_head_genitive.ReadOnly = true;
            this.fio_head_genitive.Visible = false;
            // 
            // fio_head_dative
            // 
            this.fio_head_dative.DataPropertyName = "fio_head_dative";
            this.fio_head_dative.HeaderText = "ФИО руководителя в дательном падеже";
            this.fio_head_dative.Name = "fio_head_dative";
            this.fio_head_dative.ReadOnly = true;
            this.fio_head_dative.Visible = false;
            // 
            // short_fio_head
            // 
            this.short_fio_head.DataPropertyName = "short_fio_head";
            this.short_fio_head.HeaderText = "Сокращённое ФИО руководителя";
            this.short_fio_head.Name = "short_fio_head";
            this.short_fio_head.ReadOnly = true;
            this.short_fio_head.Visible = false;
            // 
            // short_fio_head_reverse
            // 
            this.short_fio_head_reverse.DataPropertyName = "short_fio_head_reverse";
            this.short_fio_head_reverse.HeaderText = "short_fio_head_reverse";
            this.short_fio_head_reverse.Name = "short_fio_head_reverse";
            this.short_fio_head_reverse.ReadOnly = true;
            this.short_fio_head_reverse.Visible = false;
            // 
            // organization_id
            // 
            this.organization_id.DataPropertyName = "organization_id";
            this.organization_id.HeaderText = "organization_id";
            this.organization_id.Name = "organization_id";
            this.organization_id.ReadOnly = true;
            this.organization_id.Visible = false;
            // 
            // full_name
            // 
            this.full_name.DataPropertyName = "full_name";
            this.full_name.HeaderText = "Наименование организации";
            this.full_name.Name = "full_name";
            this.full_name.ReadOnly = true;
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
            this.position_name.HeaderText = "Наименование должности";
            this.position_name.Name = "position_name";
            this.position_name.ReadOnly = true;
            // 
            // position_genitive
            // 
            this.position_genitive.DataPropertyName = "position_genitive";
            this.position_genitive.HeaderText = "position_genitive";
            this.position_genitive.Name = "position_genitive";
            this.position_genitive.ReadOnly = true;
            this.position_genitive.Visible = false;
            // 
            // acts_on_the_basis_of
            // 
            this.acts_on_the_basis_of.DataPropertyName = "acts_on_the_basis_of";
            this.acts_on_the_basis_of.HeaderText = "Действует на основании";
            this.acts_on_the_basis_of.Name = "acts_on_the_basis_of";
            this.acts_on_the_basis_of.ReadOnly = true;
            // 
            // period_validity_start
            // 
            this.period_validity_start.DataPropertyName = "period_validity_start";
            this.period_validity_start.HeaderText = "Действует с ";
            this.period_validity_start.Name = "period_validity_start";
            this.period_validity_start.ReadOnly = true;
            // 
            // period_validity_end
            // 
            this.period_validity_end.DataPropertyName = "period_validity_end";
            this.period_validity_end.HeaderText = "Действует по";
            this.period_validity_end.Name = "period_validity_end";
            this.period_validity_end.ReadOnly = true;
            // 
            // menuStripHeadsOrg
            // 
            this.menuStripHeadsOrg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.menuStripHeadsOrg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStripHeadsOrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStripHeadsOrg.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripHeadsOrg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.menuStripHeadsOrg.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStripHeadsOrg.Location = new System.Drawing.Point(0, 0);
            this.menuStripHeadsOrg.Name = "menuStripHeadsOrg";
            this.menuStripHeadsOrg.Padding = new System.Windows.Forms.Padding(10, 2, 0, 2);
            this.menuStripHeadsOrg.Size = new System.Drawing.Size(966, 28);
            this.menuStripHeadsOrg.TabIndex = 17;
            this.menuStripHeadsOrg.Text = "menuStrip1";
            // 
            // новыйToolStripMenuItem
            // 
            this.новыйToolStripMenuItem.AutoToolTip = true;
            this.новыйToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.новыйToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.новыйToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            this.новыйToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.новыйToolStripMenuItem.Text = "Добавить";
            this.новыйToolStripMenuItem.ToolTipText = "Нажмите, чтобы добавить информацию о документе";
            this.новыйToolStripMenuItem.Click += new System.EventHandler(this.новыйToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.изменитьToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.изменитьToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.удалитьToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.удалитьToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(634, 313);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Статус";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 314);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Организация";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "Действующие",
            "Недействующие",
            "Все "});
            this.comboBoxStatus.Location = new System.Drawing.Point(683, 310);
            this.comboBoxStatus.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(177, 21);
            this.comboBoxStatus.TabIndex = 18;
            this.comboBoxStatus.SelectionChangeCommitted += new System.EventHandler(this.comboBoxStatus_SelectionChangeCommitted);
            // 
            // comboBoxOrganizations
            // 
            this.comboBoxOrganizations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOrganizations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.comboBoxOrganizations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrganizations.FormattingEnabled = true;
            this.comboBoxOrganizations.Location = new System.Drawing.Point(457, 310);
            this.comboBoxOrganizations.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxOrganizations.Name = "comboBoxOrganizations";
            this.comboBoxOrganizations.Size = new System.Drawing.Size(169, 21);
            this.comboBoxOrganizations.TabIndex = 19;
            this.comboBoxOrganizations.SelectionChangeCommitted += new System.EventHandler(this.comboBoxOrganizations_SelectionChangeCommitted);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(868, 303);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(96, 32);
            this.btnReset.TabIndex = 22;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            // 
            // ViewHeadsOrganizationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(966, 339);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.comboBoxOrganizations);
            this.Controls.Add(this.menuStripHeadsOrg);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dataGridViewHead);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(982, 378);
            this.Name = "ViewHeadsOrganizationsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Руководители организаций";
            this.Load += new System.EventHandler(this.ViewHeadsOrganizationsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHead)).EndInit();
            this.menuStripHeadsOrg.ResumeLayout(false);
            this.menuStripHeadsOrg.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dataGridViewHead;
        private System.Windows.Forms.MenuStrip menuStripHeadsOrg;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.ComboBox comboBoxOrganizations;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem выгрузитьВExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настроитьОтображениеToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn head_organization_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fio_head;
        private System.Windows.Forms.DataGridViewTextBoxColumn fio_head_genitive;
        private System.Windows.Forms.DataGridViewTextBoxColumn fio_head_dative;
        private System.Windows.Forms.DataGridViewTextBoxColumn short_fio_head;
        private System.Windows.Forms.DataGridViewTextBoxColumn short_fio_head_reverse;
        private System.Windows.Forms.DataGridViewTextBoxColumn organization_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn full_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn position_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn position_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn position_genitive;
        private System.Windows.Forms.DataGridViewTextBoxColumn acts_on_the_basis_of;
        private System.Windows.Forms.DataGridViewTextBoxColumn period_validity_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn period_validity_end;
    }
}