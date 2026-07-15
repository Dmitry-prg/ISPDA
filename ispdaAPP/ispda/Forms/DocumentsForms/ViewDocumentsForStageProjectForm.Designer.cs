namespace ispda.Forms.DocumentsForms
{
    partial class ViewDocumentsForStageProjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewDocumentsForStageProjectForm));
            this.btnReset = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.comboBoxProject = new System.Windows.Forms.ComboBox();
            this.dataGridViewDocuments = new System.Windows.Forms.DataGridView();
            this.document_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.document_type_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stage_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.created_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.project_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scan_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.document_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOpen = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.выгрузитьВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настроитьОтображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripDocuments = new System.Windows.Forms.MenuStrip();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocuments)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.menuStripDocuments.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(1201, 369);
            this.btnReset.Margin = new System.Windows.Forms.Padding(5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 40);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(14, 369);
            this.btnBack.Margin = new System.Windows.Forms.Padding(5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(125, 40);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // comboBoxProject
            // 
            this.comboBoxProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.comboBoxProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxProject.FormattingEnabled = true;
            this.comboBoxProject.Location = new System.Drawing.Point(915, 377);
            this.comboBoxProject.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxProject.Name = "comboBoxProject";
            this.comboBoxProject.Size = new System.Drawing.Size(251, 26);
            this.comboBoxProject.TabIndex = 7;
            this.comboBoxProject.SelectionChangeCommitted += new System.EventHandler(this.comboBoxProject_SelectionChangeCommitted);
            // 
            // dataGridViewDocuments
            // 
            this.dataGridViewDocuments.AllowUserToAddRows = false;
            this.dataGridViewDocuments.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewDocuments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDocuments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDocuments.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.dataGridViewDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDocuments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.document_number,
            this.document_type_name,
            this.stage_name,
            this.created_at,
            this.project_name,
            this.scan_path,
            this.document_id,
            this.btnOpen,
            this.btnDel});
            this.dataGridViewDocuments.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridViewDocuments.GridColor = System.Drawing.Color.PaleTurquoise;
            this.dataGridViewDocuments.Location = new System.Drawing.Point(0, 29);
            this.dataGridViewDocuments.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridViewDocuments.Name = "dataGridViewDocuments";
            this.dataGridViewDocuments.ReadOnly = true;
            this.dataGridViewDocuments.RowHeadersWidth = 51;
            this.dataGridViewDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDocuments.Size = new System.Drawing.Size(1321, 338);
            this.dataGridViewDocuments.TabIndex = 8;
            this.dataGridViewDocuments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDocuments_CellContentClick);
            // 
            // document_number
            // 
            this.document_number.DataPropertyName = "document_number";
            this.document_number.HeaderText = "Номер документа";
            this.document_number.MinimumWidth = 6;
            this.document_number.Name = "document_number";
            this.document_number.ReadOnly = true;
            // 
            // document_type_name
            // 
            this.document_type_name.DataPropertyName = "document_type_name";
            this.document_type_name.HeaderText = "Вид документа";
            this.document_type_name.MinimumWidth = 6;
            this.document_type_name.Name = "document_type_name";
            this.document_type_name.ReadOnly = true;
            // 
            // stage_name
            // 
            this.stage_name.DataPropertyName = "stage_name";
            this.stage_name.HeaderText = "Наименование этапа";
            this.stage_name.MinimumWidth = 6;
            this.stage_name.Name = "stage_name";
            this.stage_name.ReadOnly = true;
            // 
            // created_at
            // 
            this.created_at.DataPropertyName = "created_at";
            this.created_at.HeaderText = "Дата создания";
            this.created_at.MinimumWidth = 6;
            this.created_at.Name = "created_at";
            this.created_at.ReadOnly = true;
            // 
            // project_name
            // 
            this.project_name.DataPropertyName = "project_name";
            this.project_name.HeaderText = "Проект";
            this.project_name.MinimumWidth = 6;
            this.project_name.Name = "project_name";
            this.project_name.ReadOnly = true;
            // 
            // scan_path
            // 
            this.scan_path.DataPropertyName = "scan_path";
            this.scan_path.HeaderText = "scan_path";
            this.scan_path.MinimumWidth = 6;
            this.scan_path.Name = "scan_path";
            this.scan_path.ReadOnly = true;
            this.scan_path.Visible = false;
            // 
            // document_id
            // 
            this.document_id.DataPropertyName = "document_id";
            this.document_id.HeaderText = "document_id";
            this.document_id.MinimumWidth = 6;
            this.document_id.Name = "document_id";
            this.document_id.ReadOnly = true;
            this.document_id.Visible = false;
            // 
            // btnOpen
            // 
            this.btnOpen.HeaderText = "";
            this.btnOpen.MinimumWidth = 6;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.ReadOnly = true;
            this.btnOpen.Text = "Открыть";
            this.btnOpen.UseColumnTextForButtonValue = true;
            // 
            // btnDel
            // 
            this.btnDel.HeaderText = "";
            this.btnDel.MinimumWidth = 6;
            this.btnDel.Name = "btnDel";
            this.btnDel.ReadOnly = true;
            this.btnDel.Text = "Удалить";
            this.btnDel.UseColumnTextForButtonValue = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            // 
            // настроитьОтображениеToolStripMenuItem
            // 
            this.настроитьОтображениеToolStripMenuItem.Name = "настроитьОтображениеToolStripMenuItem";
            this.настроитьОтображениеToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.настроитьОтображениеToolStripMenuItem.Text = "Настроить отображение";
            this.настроитьОтображениеToolStripMenuItem.Click += new System.EventHandler(this.настроитьОтображениеToolStripMenuItem_Click);
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
            // menuStripDocuments
            // 
            this.menuStripDocuments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.menuStripDocuments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStripDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStripDocuments.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripDocuments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйToolStripMenuItem});
            this.menuStripDocuments.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStripDocuments.Location = new System.Drawing.Point(0, 0);
            this.menuStripDocuments.Name = "menuStripDocuments";
            this.menuStripDocuments.Padding = new System.Windows.Forms.Padding(10, 2, 0, 2);
            this.menuStripDocuments.Size = new System.Drawing.Size(1321, 28);
            this.menuStripDocuments.TabIndex = 5;
            this.menuStripDocuments.Text = "menuStrip1";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(846, 385);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Проект";
            // 
            // ViewDocumentsForStageProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1321, 415);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.comboBoxProject);
            this.Controls.Add(this.dataGridViewDocuments);
            this.Controls.Add(this.menuStripDocuments);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ViewDocumentsForStageProjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Документы";
            this.Load += new System.EventHandler(this.ViewDocumentsForStageProjectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocuments)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.menuStripDocuments.ResumeLayout(false);
            this.menuStripDocuments.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox comboBoxProject;
        private System.Windows.Forms.DataGridView dataGridViewDocuments;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStripDocuments;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem выгрузитьВExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настроитьОтображениеToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn document_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn document_type_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn stage_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn created_at;
        private System.Windows.Forms.DataGridViewTextBoxColumn project_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn scan_path;
        private System.Windows.Forms.DataGridViewTextBoxColumn document_id;
        private System.Windows.Forms.DataGridViewButtonColumn btnOpen;
        private System.Windows.Forms.DataGridViewButtonColumn btnDel;
    }
}