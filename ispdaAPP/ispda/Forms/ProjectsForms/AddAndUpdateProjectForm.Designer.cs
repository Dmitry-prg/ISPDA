namespace ispda.Forms.Projects
{
    partial class AddAndUpdateProjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAndUpdateProjectForm));
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.txtProjectNumber = new System.Windows.Forms.TextBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProjectShortName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductShortName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProductNamePrepositional = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProductNameGenitive = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelStar1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxInitiativeRequest = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxDeveloper = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBoxBasicInformationAboutTheProject = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBoxInformationAboutTheSoftwareProduct = new System.Windows.Forms.GroupBox();
            this.groupBoxAdditionalInformation = new System.Windows.Forms.GroupBox();
            this.checkBoxInternal = new System.Windows.Forms.CheckBox();
            this.checkBoxPnd = new System.Windows.Forms.CheckBox();
            this.checkBoxGis = new System.Windows.Forms.CheckBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtAdminPanelURL = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBoxBasicInformationAboutTheProject.SuspendLayout();
            this.groupBoxInformationAboutTheSoftwareProduct.SuspendLayout();
            this.groupBoxAdditionalInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(12, 469);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Отмена";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Номер проекта";
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.comboBoxCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(167, 87);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(158, 21);
            this.comboBoxCustomer.TabIndex = 3;
            this.comboBoxCustomer.SelectionChangeCommitted += new System.EventHandler(this.comboBoxCustomer_SelectionChangeCommitted);
            // 
            // txtProjectNumber
            // 
            this.txtProjectNumber.Location = new System.Drawing.Point(6, 38);
            this.txtProjectNumber.MaxLength = 100;
            this.txtProjectNumber.Name = "txtProjectNumber";
            this.txtProjectNumber.Size = new System.Drawing.Size(155, 20);
            this.txtProjectNumber.TabIndex = 5;
            this.txtProjectNumber.TextChanged += new System.EventHandler(this.txtProjectNumber_TextChanged);
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(6, 139);
            this.txtProjectName.MaxLength = 500;
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(319, 20);
            this.txtProjectName.TabIndex = 7;
            this.txtProjectName.TextChanged += new System.EventHandler(this.txtProjectName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Наименование проекта";
            // 
            // txtProjectShortName
            // 
            this.txtProjectShortName.Location = new System.Drawing.Point(344, 139);
            this.txtProjectShortName.MaxLength = 200;
            this.txtProjectShortName.Name = "txtProjectShortName";
            this.txtProjectShortName.Size = new System.Drawing.Size(319, 20);
            this.txtProjectShortName.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Сокращённое наименование проекта";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(6, 40);
            this.txtProductName.MaxLength = 500;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(319, 20);
            this.txtProductName.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Наименование продукта";
            // 
            // txtProductShortName
            // 
            this.txtProductShortName.Location = new System.Drawing.Point(344, 40);
            this.txtProductShortName.MaxLength = 200;
            this.txtProductShortName.Name = "txtProductShortName";
            this.txtProductShortName.Size = new System.Drawing.Size(319, 20);
            this.txtProductShortName.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(344, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Сокращённое наименование продукта";
            // 
            // txtProductNamePrepositional
            // 
            this.txtProductNamePrepositional.Location = new System.Drawing.Point(344, 93);
            this.txtProductNamePrepositional.MaxLength = 500;
            this.txtProductNamePrepositional.Name = "txtProductNamePrepositional";
            this.txtProductNamePrepositional.Size = new System.Drawing.Size(319, 20);
            this.txtProductNamePrepositional.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(344, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(249, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Наименование продукта в предложном падеже";
            // 
            // txtProductNameGenitive
            // 
            this.txtProductNameGenitive.Location = new System.Drawing.Point(6, 93);
            this.txtProductNameGenitive.MaxLength = 500;
            this.txtProductNameGenitive.Name = "txtProductNameGenitive";
            this.txtProductNameGenitive.Size = new System.Drawing.Size(319, 20);
            this.txtProductNameGenitive.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(252, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Наименование продукта в родительном падеже";
            // 
            // labelStar1
            // 
            this.labelStar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStar1.ForeColor = System.Drawing.Color.Red;
            this.labelStar1.Location = new System.Drawing.Point(129, 119);
            this.labelStar1.Name = "labelStar1";
            this.labelStar1.Size = new System.Drawing.Size(18, 16);
            this.labelStar1.TabIndex = 18;
            this.labelStar1.Text = "*";
            this.labelStar1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(341, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Дата открытия проекта";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(510, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Дата закрытия проекта";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(164, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Заказчик";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(344, 38);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(147, 20);
            this.dateTimePickerStart.TabIndex = 23;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(513, 38);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(147, 20);
            this.dateTimePickerEnd.TabIndex = 24;
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.dateTimePickerEnd_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(344, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Инициативная заявка";
            // 
            // comboBoxInitiativeRequest
            // 
            this.comboBoxInitiativeRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.comboBoxInitiativeRequest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInitiativeRequest.FormattingEnabled = true;
            this.comboBoxInitiativeRequest.Location = new System.Drawing.Point(344, 87);
            this.comboBoxInitiativeRequest.Name = "comboBoxInitiativeRequest";
            this.comboBoxInitiativeRequest.Size = new System.Drawing.Size(319, 21);
            this.comboBoxInitiativeRequest.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Разработчик";
            // 
            // comboBoxDeveloper
            // 
            this.comboBoxDeveloper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.comboBoxDeveloper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDeveloper.FormattingEnabled = true;
            this.comboBoxDeveloper.Location = new System.Drawing.Point(6, 87);
            this.comboBoxDeveloper.Name = "comboBoxDeveloper";
            this.comboBoxDeveloper.Size = new System.Drawing.Size(155, 21);
            this.comboBoxDeveloper.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(164, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Статус";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.Enabled = false;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(167, 37);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(158, 21);
            this.comboBoxStatus.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(214, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 16);
            this.label14.TabIndex = 31;
            this.label14.Text = "*";
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(73, 68);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 16);
            this.label15.TabIndex = 32;
            this.label15.Text = "*";
            this.label15.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(87, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(18, 16);
            this.label16.TabIndex = 33;
            this.label16.Text = "*";
            this.label16.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(157, 61);
            this.txtURL.MaxLength = 500;
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(250, 20);
            this.txtURL.TabIndex = 35;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(157, 45);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 13);
            this.label17.TabIndex = 34;
            this.label17.Text = "URL";
            // 
            // groupBoxBasicInformationAboutTheProject
            // 
            this.groupBoxBasicInformationAboutTheProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(247)))));
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.label21);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.comboBoxCustomer);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.label1);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.txtProjectNumber);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.label2);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.label16);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.txtProjectName);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.label15);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.label3);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.label14);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.txtProjectShortName);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.label13);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.labelStar1);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.comboBoxStatus);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.label8);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.label11);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.label9);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.comboBoxDeveloper);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.label10);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.label12);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.dateTimePickerStart);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.comboBoxInitiativeRequest);
            this.groupBoxBasicInformationAboutTheProject.Controls.Add(this.dateTimePickerEnd);
            this.groupBoxBasicInformationAboutTheProject.Location = new System.Drawing.Point(12, 12);
            this.groupBoxBasicInformationAboutTheProject.Name = "groupBoxBasicInformationAboutTheProject";
            this.groupBoxBasicInformationAboutTheProject.Size = new System.Drawing.Size(675, 165);
            this.groupBoxBasicInformationAboutTheProject.TabIndex = 36;
            this.groupBoxBasicInformationAboutTheProject.TabStop = false;
            this.groupBoxBasicInformationAboutTheProject.Text = "Основная информация о проекте";
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(458, 65);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(18, 16);
            this.label21.TabIndex = 34;
            this.label21.Text = "*";
            this.label21.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // groupBoxInformationAboutTheSoftwareProduct
            // 
            this.groupBoxInformationAboutTheSoftwareProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(247)))));
            this.groupBoxInformationAboutTheSoftwareProduct.Controls.Add(this.txtProductShortName);
            this.groupBoxInformationAboutTheSoftwareProduct.Controls.Add(this.label4);
            this.groupBoxInformationAboutTheSoftwareProduct.Controls.Add(this.txtProductName);
            this.groupBoxInformationAboutTheSoftwareProduct.Controls.Add(this.label5);
            this.groupBoxInformationAboutTheSoftwareProduct.Controls.Add(this.label7);
            this.groupBoxInformationAboutTheSoftwareProduct.Controls.Add(this.txtProductNameGenitive);
            this.groupBoxInformationAboutTheSoftwareProduct.Controls.Add(this.label6);
            this.groupBoxInformationAboutTheSoftwareProduct.Controls.Add(this.txtProductNamePrepositional);
            this.groupBoxInformationAboutTheSoftwareProduct.Location = new System.Drawing.Point(12, 183);
            this.groupBoxInformationAboutTheSoftwareProduct.Name = "groupBoxInformationAboutTheSoftwareProduct";
            this.groupBoxInformationAboutTheSoftwareProduct.Size = new System.Drawing.Size(675, 121);
            this.groupBoxInformationAboutTheSoftwareProduct.TabIndex = 37;
            this.groupBoxInformationAboutTheSoftwareProduct.TabStop = false;
            this.groupBoxInformationAboutTheSoftwareProduct.Text = "Информация о программном продукте";
            // 
            // groupBoxAdditionalInformation
            // 
            this.groupBoxAdditionalInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(240)))), ((int)(((byte)(247)))));
            this.groupBoxAdditionalInformation.Controls.Add(this.checkBoxInternal);
            this.groupBoxAdditionalInformation.Controls.Add(this.checkBoxPnd);
            this.groupBoxAdditionalInformation.Controls.Add(this.checkBoxGis);
            this.groupBoxAdditionalInformation.Controls.Add(this.txtNotes);
            this.groupBoxAdditionalInformation.Controls.Add(this.label20);
            this.groupBoxAdditionalInformation.Controls.Add(this.txtAdminPanelURL);
            this.groupBoxAdditionalInformation.Controls.Add(this.label19);
            this.groupBoxAdditionalInformation.Controls.Add(this.txtIP);
            this.groupBoxAdditionalInformation.Controls.Add(this.label18);
            this.groupBoxAdditionalInformation.Controls.Add(this.txtURL);
            this.groupBoxAdditionalInformation.Controls.Add(this.label17);
            this.groupBoxAdditionalInformation.Location = new System.Drawing.Point(12, 310);
            this.groupBoxAdditionalInformation.Name = "groupBoxAdditionalInformation";
            this.groupBoxAdditionalInformation.Size = new System.Drawing.Size(675, 153);
            this.groupBoxAdditionalInformation.TabIndex = 38;
            this.groupBoxAdditionalInformation.TabStop = false;
            this.groupBoxAdditionalInformation.Text = "Дополнительная информация";
            // 
            // checkBoxInternal
            // 
            this.checkBoxInternal.AutoSize = true;
            this.checkBoxInternal.Location = new System.Drawing.Point(119, 19);
            this.checkBoxInternal.Name = "checkBoxInternal";
            this.checkBoxInternal.Size = new System.Drawing.Size(179, 17);
            this.checkBoxInternal.TabIndex = 47;
            this.checkBoxInternal.Text = "Для служебного пользования";
            this.checkBoxInternal.UseVisualStyleBackColor = true;
            // 
            // checkBoxPnd
            // 
            this.checkBoxPnd.AutoSize = true;
            this.checkBoxPnd.Location = new System.Drawing.Point(65, 19);
            this.checkBoxPnd.Name = "checkBoxPnd";
            this.checkBoxPnd.Size = new System.Drawing.Size(48, 17);
            this.checkBoxPnd.TabIndex = 46;
            this.checkBoxPnd.Text = "ПНд";
            this.checkBoxPnd.UseVisualStyleBackColor = true;
            // 
            // checkBoxGis
            // 
            this.checkBoxGis.AutoSize = true;
            this.checkBoxGis.Location = new System.Drawing.Point(12, 19);
            this.checkBoxGis.Name = "checkBoxGis";
            this.checkBoxGis.Size = new System.Drawing.Size(47, 17);
            this.checkBoxGis.TabIndex = 45;
            this.checkBoxGis.Text = "ГИС";
            this.checkBoxGis.UseVisualStyleBackColor = true;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(6, 100);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(657, 47);
            this.txtNotes.TabIndex = 44;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 84);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(122, 13);
            this.label20.TabIndex = 43;
            this.label20.Text = "Примечания к проекту";
            // 
            // txtAdminPanelURL
            // 
            this.txtAdminPanelURL.ForeColor = System.Drawing.Color.Gray;
            this.txtAdminPanelURL.Location = new System.Drawing.Point(413, 61);
            this.txtAdminPanelURL.MaxLength = 500;
            this.txtAdminPanelURL.Name = "txtAdminPanelURL";
            this.txtAdminPanelURL.Size = new System.Drawing.Size(250, 20);
            this.txtAdminPanelURL.TabIndex = 39;
            this.txtAdminPanelURL.Text = "admin.td-alpha.ru";
            this.txtAdminPanelURL.Enter += new System.EventHandler(this.txtAdminPanelURL_Enter);
            this.txtAdminPanelURL.Leave += new System.EventHandler(this.txtAdminPanelURL_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(419, 45);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(192, 13);
            this.label19.TabIndex = 38;
            this.label19.Text = "Ссылка на кабинет администратора";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(6, 61);
            this.txtIP.MaxLength = 50;
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(141, 20);
            this.txtIP.TabIndex = 37;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 45);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 13);
            this.label18.TabIndex = 36;
            this.label18.Text = "IP";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(154)))), ((int)(((byte)(255)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(604, 469);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 23);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddAndUpdateProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(697, 492);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBoxAdditionalInformation);
            this.Controls.Add(this.groupBoxInformationAboutTheSoftwareProduct);
            this.Controls.Add(this.groupBoxBasicInformationAboutTheProject);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAndUpdateProjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление информации о проекте";
            this.Load += new System.EventHandler(this.AddProjectForm_Load);
            this.groupBoxBasicInformationAboutTheProject.ResumeLayout(false);
            this.groupBoxBasicInformationAboutTheProject.PerformLayout();
            this.groupBoxInformationAboutTheSoftwareProduct.ResumeLayout(false);
            this.groupBoxInformationAboutTheSoftwareProduct.PerformLayout();
            this.groupBoxAdditionalInformation.ResumeLayout(false);
            this.groupBoxAdditionalInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.TextBox txtProjectNumber;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProjectShortName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductShortName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProductNamePrepositional;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProductNameGenitive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelStar1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxInitiativeRequest;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxDeveloper;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBoxBasicInformationAboutTheProject;
        private System.Windows.Forms.GroupBox groupBoxInformationAboutTheSoftwareProduct;
        private System.Windows.Forms.GroupBox groupBoxAdditionalInformation;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtAdminPanelURL;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.CheckBox checkBoxInternal;
        private System.Windows.Forms.CheckBox checkBoxPnd;
        private System.Windows.Forms.CheckBox checkBoxGis;
        private System.Windows.Forms.Label label21;
    }
}