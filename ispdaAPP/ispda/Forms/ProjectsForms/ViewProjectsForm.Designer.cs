using System.Drawing;

namespace ispda.Forms.Projects
{
    partial class ViewProjectsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewProjectsForm));
            this.menuStripProject = new System.Windows.Forms.MenuStrip();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.dataGridViewProject = new System.Windows.Forms.DataGridView();
            this.project_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.project_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.project_short_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_full_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.developer_full_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_name_genitive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_name_prepositional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_short_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual_start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual_end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.admin_panel_url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_gis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_pnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_internal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.developer_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.project_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initiative_request_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOptions = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.выгрузитьВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настроитьОтображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStripProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProject)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripProject
            // 
            this.menuStripProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.menuStripProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStripProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStripProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйToolStripMenuItem,
            this.изменитьToolStripMenuItem});
            this.menuStripProject.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStripProject.Location = new System.Drawing.Point(0, 0);
            this.menuStripProject.Name = "menuStripProject";
            this.menuStripProject.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStripProject.Size = new System.Drawing.Size(1280, 28);
            this.menuStripProject.TabIndex = 0;
            this.menuStripProject.Text = "menuStrip1";
            // 
            // новыйToolStripMenuItem
            // 
            this.новыйToolStripMenuItem.AutoToolTip = true;
            this.новыйToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.новыйToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.новыйToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            this.новыйToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.новыйToolStripMenuItem.Text = "Новый";
            this.новыйToolStripMenuItem.ToolTipText = "Нажмите, чтобы добавить информацию о новом проекте";
            this.новыйToolStripMenuItem.Click += new System.EventHandler(this.новыйПроектToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.AutoToolTip = true;
            this.изменитьToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.изменитьToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.изменитьToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.ToolTipText = "Нажмите, чтобы изменить информацию о выбранном проекте";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.comboBoxCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(688, 516);
            this.comboBoxCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(177, 24);
            this.comboBoxCustomer.TabIndex = 2;
            this.comboBoxCustomer.SelectionChangeCommitted += new System.EventHandler(this.comboBoxCustomer_SelectionChangeCommitted);
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(959, 516);
            this.comboBoxStatus.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(177, 24);
            this.comboBoxStatus.TabIndex = 1;
            this.comboBoxStatus.SelectionChangeCommitted += new System.EventHandler(this.comboBoxStatus_SelectionChangeCommitted);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(16, 516);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 32);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dataGridViewProject
            // 
            this.dataGridViewProject.AllowUserToAddRows = false;
            this.dataGridViewProject.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewProject.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewProject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewProject.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.dataGridViewProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.project_number,
            this.status_name,
            this.project_name,
            this.project_short_name,
            this.customer_full_name,
            this.developer_full_name,
            this.product_name,
            this.product_name_genitive,
            this.product_name_prepositional,
            this.product_short_name,
            this.start_date,
            this.end_date,
            this.actual_start_date,
            this.actual_end_date,
            this.url,
            this.ip,
            this.admin_panel_url,
            this.is_gis,
            this.is_pnd,
            this.is_internal,
            this.notes,
            this.is_active,
            this.status_id,
            this.developer_id,
            this.customer_id,
            this.project_id,
            this.initiative_request_id,
            this.btnOptions,
            this.btnDel});
            this.dataGridViewProject.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridViewProject.GridColor = System.Drawing.Color.PaleTurquoise;
            this.dataGridViewProject.Location = new System.Drawing.Point(0, 30);
            this.dataGridViewProject.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewProject.Name = "dataGridViewProject";
            this.dataGridViewProject.ReadOnly = true;
            this.dataGridViewProject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProject.Size = new System.Drawing.Size(1280, 479);
            this.dataGridViewProject.TabIndex = 2;
            this.dataGridViewProject.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProject_CellContentClick);
            // 
            // project_number
            // 
            this.project_number.DataPropertyName = "project_number";
            this.project_number.HeaderText = "Номер проекта";
            this.project_number.Name = "project_number";
            this.project_number.ReadOnly = true;
            this.project_number.Width = 121;
            // 
            // status_name
            // 
            this.status_name.DataPropertyName = "status_name";
            this.status_name.HeaderText = "Статус";
            this.status_name.Name = "status_name";
            this.status_name.ReadOnly = true;
            this.status_name.Width = 78;
            // 
            // project_name
            // 
            this.project_name.DataPropertyName = "project_name";
            this.project_name.HeaderText = "Наименование проекта";
            this.project_name.Name = "project_name";
            this.project_name.ReadOnly = true;
            this.project_name.Width = 171;
            // 
            // project_short_name
            // 
            this.project_short_name.DataPropertyName = "project_short_name";
            this.project_short_name.HeaderText = "Краткое наименование проекта";
            this.project_short_name.Name = "project_short_name";
            this.project_short_name.ReadOnly = true;
            this.project_short_name.Visible = false;
            this.project_short_name.Width = 221;
            // 
            // customer_full_name
            // 
            this.customer_full_name.DataPropertyName = "customer_full_name";
            this.customer_full_name.HeaderText = "Заказчик";
            this.customer_full_name.Name = "customer_full_name";
            this.customer_full_name.ReadOnly = true;
            this.customer_full_name.Width = 95;
            // 
            // developer_full_name
            // 
            this.developer_full_name.DataPropertyName = "developer_full_name";
            this.developer_full_name.HeaderText = "Разработчик";
            this.developer_full_name.Name = "developer_full_name";
            this.developer_full_name.ReadOnly = true;
            this.developer_full_name.Visible = false;
            this.developer_full_name.Width = 119;
            // 
            // product_name
            // 
            this.product_name.DataPropertyName = "product_name";
            this.product_name.HeaderText = "Наименование продукта";
            this.product_name.Name = "product_name";
            this.product_name.ReadOnly = true;
            this.product_name.Visible = false;
            this.product_name.Width = 178;
            // 
            // product_name_genitive
            // 
            this.product_name_genitive.DataPropertyName = "product_name_genitive";
            this.product_name_genitive.HeaderText = "Наименование продукта в родительном падеже";
            this.product_name_genitive.Name = "product_name_genitive";
            this.product_name_genitive.ReadOnly = true;
            this.product_name_genitive.Visible = false;
            this.product_name_genitive.Width = 272;
            // 
            // product_name_prepositional
            // 
            this.product_name_prepositional.DataPropertyName = "product_name_prepositional";
            this.product_name_prepositional.HeaderText = "Наименование продукта в предложном падеже";
            this.product_name_prepositional.Name = "product_name_prepositional";
            this.product_name_prepositional.ReadOnly = true;
            this.product_name_prepositional.Visible = false;
            this.product_name_prepositional.Width = 268;
            // 
            // product_short_name
            // 
            this.product_short_name.DataPropertyName = "product_short_name";
            this.product_short_name.HeaderText = "Краткое наименование продукта";
            this.product_short_name.Name = "product_short_name";
            this.product_short_name.ReadOnly = true;
            this.product_short_name.Visible = false;
            this.product_short_name.Width = 228;
            // 
            // start_date
            // 
            this.start_date.DataPropertyName = "start_date";
            this.start_date.HeaderText = "Планируемая дата открытия проекта";
            this.start_date.Name = "start_date";
            this.start_date.ReadOnly = true;
            this.start_date.Width = 203;
            // 
            // end_date
            // 
            this.end_date.DataPropertyName = "end_date";
            this.end_date.HeaderText = "Планируемая дата закрытия проекта";
            this.end_date.Name = "end_date";
            this.end_date.ReadOnly = true;
            this.end_date.Width = 204;
            // 
            // actual_start_date
            // 
            this.actual_start_date.DataPropertyName = "actual_start_date";
            this.actual_start_date.HeaderText = "Фактическая дата открытия проекта";
            this.actual_start_date.Name = "actual_start_date";
            this.actual_start_date.ReadOnly = true;
            this.actual_start_date.Width = 199;
            // 
            // actual_end_date
            // 
            this.actual_end_date.DataPropertyName = "actual_end_date";
            this.actual_end_date.HeaderText = "Фактическая дата закрытия проекта";
            this.actual_end_date.Name = "actual_end_date";
            this.actual_end_date.ReadOnly = true;
            this.actual_end_date.Width = 200;
            // 
            // url
            // 
            this.url.DataPropertyName = "url";
            this.url.HeaderText = "URL";
            this.url.Name = "url";
            this.url.ReadOnly = true;
            this.url.Visible = false;
            this.url.Width = 59;
            // 
            // ip
            // 
            this.ip.DataPropertyName = "ip";
            this.ip.HeaderText = "IP";
            this.ip.Name = "ip";
            this.ip.ReadOnly = true;
            this.ip.Visible = false;
            this.ip.Width = 44;
            // 
            // admin_panel_url
            // 
            this.admin_panel_url.DataPropertyName = "admin_panel_url";
            this.admin_panel_url.HeaderText = "Кабинет администратора";
            this.admin_panel_url.Name = "admin_panel_url";
            this.admin_panel_url.ReadOnly = true;
            this.admin_panel_url.Visible = false;
            this.admin_panel_url.Width = 182;
            // 
            // is_gis
            // 
            this.is_gis.DataPropertyName = "is_gis";
            this.is_gis.HeaderText = "ГИС";
            this.is_gis.Name = "is_gis";
            this.is_gis.ReadOnly = true;
            this.is_gis.Visible = false;
            this.is_gis.Width = 58;
            // 
            // is_pnd
            // 
            this.is_pnd.DataPropertyName = "is_pnd";
            this.is_pnd.HeaderText = "ПНд";
            this.is_pnd.Name = "is_pnd";
            this.is_pnd.ReadOnly = true;
            this.is_pnd.Visible = false;
            this.is_pnd.Width = 60;
            // 
            // is_internal
            // 
            this.is_internal.DataPropertyName = "is_internal";
            this.is_internal.HeaderText = "Для служебного пользования";
            this.is_internal.Name = "is_internal";
            this.is_internal.ReadOnly = true;
            this.is_internal.Visible = false;
            this.is_internal.Width = 205;
            // 
            // notes
            // 
            this.notes.DataPropertyName = "notes";
            this.notes.HeaderText = "Примечания к проекту";
            this.notes.Name = "notes";
            this.notes.ReadOnly = true;
            this.notes.Width = 116;
            // 
            // is_active
            // 
            this.is_active.DataPropertyName = "is_active";
            this.is_active.HeaderText = "Действующая запись";
            this.is_active.Name = "is_active";
            this.is_active.ReadOnly = true;
            this.is_active.Visible = false;
            this.is_active.Width = 155;
            // 
            // status_id
            // 
            this.status_id.DataPropertyName = "status_id";
            this.status_id.HeaderText = "status_id";
            this.status_id.Name = "status_id";
            this.status_id.ReadOnly = true;
            this.status_id.Visible = false;
            this.status_id.Width = 85;
            // 
            // developer_id
            // 
            this.developer_id.DataPropertyName = "developer_id";
            this.developer_id.HeaderText = "developer_id";
            this.developer_id.Name = "developer_id";
            this.developer_id.ReadOnly = true;
            this.developer_id.Visible = false;
            this.developer_id.Width = 112;
            // 
            // customer_id
            // 
            this.customer_id.DataPropertyName = "customer_id";
            this.customer_id.HeaderText = "customer_id";
            this.customer_id.Name = "customer_id";
            this.customer_id.ReadOnly = true;
            this.customer_id.Visible = false;
            this.customer_id.Width = 105;
            // 
            // project_id
            // 
            this.project_id.DataPropertyName = "project_id";
            this.project_id.HeaderText = "project_id";
            this.project_id.Name = "project_id";
            this.project_id.ReadOnly = true;
            this.project_id.Visible = false;
            this.project_id.Width = 91;
            // 
            // initiative_request_id
            // 
            this.initiative_request_id.DataPropertyName = "initiative_request_id";
            this.initiative_request_id.HeaderText = "initiative_request_id";
            this.initiative_request_id.Name = "initiative_request_id";
            this.initiative_request_id.ReadOnly = true;
            this.initiative_request_id.Visible = false;
            this.initiative_request_id.Width = 150;
            // 
            // btnOptions
            // 
            this.btnOptions.HeaderText = "";
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.ReadOnly = true;
            this.btnOptions.Text = "Подробнее";
            this.btnOptions.UseColumnTextForButtonValue = true;
            this.btnOptions.Width = 5;
            // 
            // btnDel
            // 
            this.btnDel.HeaderText = "";
            this.btnDel.Name = "btnDel";
            this.btnDel.ReadOnly = true;
            this.btnDel.Text = "Удалить";
            this.btnDel.UseColumnTextForButtonValue = true;
            this.btnDel.Width = 5;
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
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(1168, 516);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(96, 32);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(973, 2);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(305, 22);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(919, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Поиск";
            // 
            // dateStart
            // 
            this.dateStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateStart.Location = new System.Drawing.Point(172, 517);
            this.dateStart.Margin = new System.Windows.Forms.Padding(4);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(165, 22);
            this.dateStart.TabIndex = 6;
            this.dateStart.ValueChanged += new System.EventHandler(this.dateStart_ValueChanged);
            // 
            // dateEnd
            // 
            this.dateEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateEnd.Location = new System.Drawing.Point(387, 517);
            this.dateEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(165, 22);
            this.dateEnd.TabIndex = 7;
            this.dateEnd.ValueChanged += new System.EventHandler(this.dateStart_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 524);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "С";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 524);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "По";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(607, 523);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Заказчик";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(896, 523);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Статус";
            // 
            // ViewProjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1280, 554);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.comboBoxCustomer);
            this.Controls.Add(this.dataGridViewProject);
            this.Controls.Add(this.menuStripProject);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripProject;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1296, 593);
            this.Name = "ViewProjectsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Проекты";
            this.Load += new System.EventHandler(this.ViewProjectsForm_Load);
            this.menuStripProject.ResumeLayout(false);
            this.menuStripProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProject)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripProject;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewProject;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem выгрузитьВExcelToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem настроитьОтображениеToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn project_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn status_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn project_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn project_short_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_full_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn developer_full_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name_genitive;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name_prepositional;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_short_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn end_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual_start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual_end_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn url;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn admin_panel_url;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_gis;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_pnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_internal;
        private System.Windows.Forms.DataGridViewTextBoxColumn notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_active;
        private System.Windows.Forms.DataGridViewTextBoxColumn status_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn developer_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn project_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn initiative_request_id;
        private System.Windows.Forms.DataGridViewButtonColumn btnOptions;
        private System.Windows.Forms.DataGridViewButtonColumn btnDel;
    }
}