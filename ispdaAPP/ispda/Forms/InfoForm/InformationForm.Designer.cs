namespace ispda.Forms.InfoForm
{
    partial class InformationForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("О программе");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Авторизация");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Дорожная карта проекта");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Проекты", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Руководители организаций");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformationForm));
            this.splitContainerInfo = new System.Windows.Forms.SplitContainer();
            this.treeViewInfo = new System.Windows.Forms.TreeView();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.tabControlInfo = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.tabPageProjects = new System.Windows.Forms.TabPage();
            this.tabControlProjects = new System.Windows.Forms.TabControl();
            this.tabPageViewProjects = new System.Windows.Forms.TabPage();
            this.tabPageRoadMap = new System.Windows.Forms.TabPage();
            this.tabPageHeadsOrganizations = new System.Windows.Forms.TabPage();
            this.richTextBoxWithRTFInfo = new ispda.Controls.RichTextBoxWithRTF();
            this.richTextBoxWithRTFLogin = new ispda.Controls.RichTextBoxWithRTF();
            this.richTextBoxWithRTFProjectView = new ispda.Controls.RichTextBoxWithRTF();
            this.richTextBoxWithRTF1 = new ispda.Controls.RichTextBoxWithRTF();
            this.richTextBoxWithRTF2 = new ispda.Controls.RichTextBoxWithRTF();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInfo)).BeginInit();
            this.splitContainerInfo.Panel1.SuspendLayout();
            this.splitContainerInfo.Panel2.SuspendLayout();
            this.splitContainerInfo.SuspendLayout();
            this.tabControlInfo.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.tabPageProjects.SuspendLayout();
            this.tabControlProjects.SuspendLayout();
            this.tabPageViewProjects.SuspendLayout();
            this.tabPageRoadMap.SuspendLayout();
            this.tabPageHeadsOrganizations.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerInfo
            // 
            this.splitContainerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerInfo.Location = new System.Drawing.Point(0, 0);
            this.splitContainerInfo.Name = "splitContainerInfo";
            // 
            // splitContainerInfo.Panel1
            // 
            this.splitContainerInfo.Panel1.Controls.Add(this.treeViewInfo);
            this.splitContainerInfo.Panel1MinSize = 40;
            // 
            // splitContainerInfo.Panel2
            // 
            this.splitContainerInfo.Panel2.Controls.Add(this.txtPath);
            this.splitContainerInfo.Panel2.Controls.Add(this.tabControlInfo);
            this.splitContainerInfo.Panel2MinSize = 700;
            this.splitContainerInfo.Size = new System.Drawing.Size(1112, 456);
            this.splitContainerInfo.SplitterDistance = 298;
            this.splitContainerInfo.TabIndex = 2;
            // 
            // treeViewInfo
            // 
            this.treeViewInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(248)))), ((int)(((byte)(254)))));
            this.treeViewInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeViewInfo.Location = new System.Drawing.Point(0, 0);
            this.treeViewInfo.Name = "treeViewInfo";
            treeNode1.Name = "main";
            treeNode1.Text = "О программе";
            treeNode2.Name = "login";
            treeNode2.Text = "Авторизация";
            treeNode3.Name = "roadMap";
            treeNode3.Text = "Дорожная карта проекта";
            treeNode4.Name = "projects";
            treeNode4.Text = "Проекты";
            treeNode5.Name = "headsOrganizations";
            treeNode5.Text = "Руководители организаций";
            this.treeViewInfo.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode4,
            treeNode5});
            this.treeViewInfo.Size = new System.Drawing.Size(298, 456);
            this.treeViewInfo.TabIndex = 1;
            this.treeViewInfo.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // txtPath
            // 
            this.txtPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPath.Location = new System.Drawing.Point(0, 0);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(810, 20);
            this.txtPath.TabIndex = 2;
            // 
            // tabControlInfo
            // 
            this.tabControlInfo.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlInfo.Controls.Add(this.tabPageMain);
            this.tabControlInfo.Controls.Add(this.tabPageLogin);
            this.tabControlInfo.Controls.Add(this.tabPageProjects);
            this.tabControlInfo.Controls.Add(this.tabPageHeadsOrganizations);
            this.tabControlInfo.ItemSize = new System.Drawing.Size(50, 20);
            this.tabControlInfo.Location = new System.Drawing.Point(3, 26);
            this.tabControlInfo.Multiline = true;
            this.tabControlInfo.Name = "tabControlInfo";
            this.tabControlInfo.SelectedIndex = 0;
            this.tabControlInfo.Size = new System.Drawing.Size(807, 430);
            this.tabControlInfo.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlInfo.TabIndex = 1;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.richTextBoxWithRTFInfo);
            this.tabPageMain.Location = new System.Drawing.Point(24, 4);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Size = new System.Drawing.Size(779, 422);
            this.tabPageMain.TabIndex = 6;
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.Controls.Add(this.richTextBoxWithRTFLogin);
            this.tabPageLogin.Location = new System.Drawing.Point(24, 4);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Size = new System.Drawing.Size(779, 422);
            this.tabPageLogin.TabIndex = 5;
            this.tabPageLogin.UseVisualStyleBackColor = true;
            // 
            // tabPageProjects
            // 
            this.tabPageProjects.AutoScroll = true;
            this.tabPageProjects.Controls.Add(this.tabControlProjects);
            this.tabPageProjects.Location = new System.Drawing.Point(24, 4);
            this.tabPageProjects.Name = "tabPageProjects";
            this.tabPageProjects.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProjects.Size = new System.Drawing.Size(779, 422);
            this.tabPageProjects.TabIndex = 0;
            this.tabPageProjects.UseVisualStyleBackColor = true;
            // 
            // tabControlProjects
            // 
            this.tabControlProjects.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlProjects.Controls.Add(this.tabPageViewProjects);
            this.tabControlProjects.Controls.Add(this.tabPageRoadMap);
            this.tabControlProjects.ItemSize = new System.Drawing.Size(50, 20);
            this.tabControlProjects.Location = new System.Drawing.Point(0, -4);
            this.tabControlProjects.Multiline = true;
            this.tabControlProjects.Name = "tabControlProjects";
            this.tabControlProjects.SelectedIndex = 0;
            this.tabControlProjects.Size = new System.Drawing.Size(783, 430);
            this.tabControlProjects.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlProjects.TabIndex = 2;
            // 
            // tabPageViewProjects
            // 
            this.tabPageViewProjects.Controls.Add(this.richTextBoxWithRTFProjectView);
            this.tabPageViewProjects.Location = new System.Drawing.Point(24, 4);
            this.tabPageViewProjects.Name = "tabPageViewProjects";
            this.tabPageViewProjects.Size = new System.Drawing.Size(755, 422);
            this.tabPageViewProjects.TabIndex = 3;
            this.tabPageViewProjects.UseVisualStyleBackColor = true;
            // 
            // tabPageRoadMap
            // 
            this.tabPageRoadMap.Controls.Add(this.richTextBoxWithRTF2);
            this.tabPageRoadMap.Location = new System.Drawing.Point(24, 4);
            this.tabPageRoadMap.Name = "tabPageRoadMap";
            this.tabPageRoadMap.Size = new System.Drawing.Size(755, 422);
            this.tabPageRoadMap.TabIndex = 4;
            this.tabPageRoadMap.UseVisualStyleBackColor = true;
            // 
            // tabPageHeadsOrganizations
            // 
            this.tabPageHeadsOrganizations.Controls.Add(this.richTextBoxWithRTF1);
            this.tabPageHeadsOrganizations.Location = new System.Drawing.Point(24, 4);
            this.tabPageHeadsOrganizations.Name = "tabPageHeadsOrganizations";
            this.tabPageHeadsOrganizations.Size = new System.Drawing.Size(779, 422);
            this.tabPageHeadsOrganizations.TabIndex = 7;
            this.tabPageHeadsOrganizations.UseVisualStyleBackColor = true;
            // 
            // richTextBoxWithRTFInfo
            // 
            this.richTextBoxWithRTFInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxWithRTFInfo.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxWithRTFInfo.Name = "richTextBoxWithRTFInfo";
            this.richTextBoxWithRTFInfo.RichText = resources.GetString("richTextBoxWithRTFInfo.RichText");
            this.richTextBoxWithRTFInfo.Size = new System.Drawing.Size(779, 422);
            this.richTextBoxWithRTFInfo.TabIndex = 1;
            this.richTextBoxWithRTFInfo.Text = " \n\nISPDA v1.0\nИнформационная система учёта выполнения проектных работ в отделе ра" +
    "зработки ГОБУ «ЦИТ МО».\n\n ©2026 Дмитрий Давыдов. Все права защищены.";
            // 
            // richTextBoxWithRTFLogin
            // 
            this.richTextBoxWithRTFLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxWithRTFLogin.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxWithRTFLogin.Name = "richTextBoxWithRTFLogin";
            this.richTextBoxWithRTFLogin.RichText = resources.GetString("richTextBoxWithRTFLogin.RichText");
            this.richTextBoxWithRTFLogin.Size = new System.Drawing.Size(779, 422);
            this.richTextBoxWithRTFLogin.TabIndex = 2;
            this.richTextBoxWithRTFLogin.Text = resources.GetString("richTextBoxWithRTFLogin.Text");
            // 
            // richTextBoxWithRTFProjectView
            // 
            this.richTextBoxWithRTFProjectView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxWithRTFProjectView.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxWithRTFProjectView.Name = "richTextBoxWithRTFProjectView";
            this.richTextBoxWithRTFProjectView.RichText = resources.GetString("richTextBoxWithRTFProjectView.RichText");
            this.richTextBoxWithRTFProjectView.Size = new System.Drawing.Size(755, 422);
            this.richTextBoxWithRTFProjectView.TabIndex = 0;
            this.richTextBoxWithRTFProjectView.Text = resources.GetString("richTextBoxWithRTFProjectView.Text");
            // 
            // richTextBoxWithRTF1
            // 
            this.richTextBoxWithRTF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxWithRTF1.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxWithRTF1.Name = "richTextBoxWithRTF1";
            this.richTextBoxWithRTF1.RichText = resources.GetString("richTextBoxWithRTF1.RichText");
            this.richTextBoxWithRTF1.Size = new System.Drawing.Size(779, 422);
            this.richTextBoxWithRTF1.TabIndex = 1;
            this.richTextBoxWithRTF1.Text = resources.GetString("richTextBoxWithRTF1.Text");
            // 
            // richTextBoxWithRTF2
            // 
            this.richTextBoxWithRTF2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxWithRTF2.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxWithRTF2.Name = "richTextBoxWithRTF2";
            this.richTextBoxWithRTF2.RichText = resources.GetString("richTextBoxWithRTF2.RichText");
            this.richTextBoxWithRTF2.Size = new System.Drawing.Size(755, 422);
            this.richTextBoxWithRTF2.TabIndex = 1;
            this.richTextBoxWithRTF2.Text = resources.GetString("richTextBoxWithRTF2.Text");
            // 
            // InformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 456);
            this.Controls.Add(this.splitContainerInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InformationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочная информация";
            this.Load += new System.EventHandler(this.InformationForm_Load);
            this.splitContainerInfo.Panel1.ResumeLayout(false);
            this.splitContainerInfo.Panel2.ResumeLayout(false);
            this.splitContainerInfo.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInfo)).EndInit();
            this.splitContainerInfo.ResumeLayout(false);
            this.tabControlInfo.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageLogin.ResumeLayout(false);
            this.tabPageProjects.ResumeLayout(false);
            this.tabControlProjects.ResumeLayout(false);
            this.tabPageViewProjects.ResumeLayout(false);
            this.tabPageRoadMap.ResumeLayout(false);
            this.tabPageHeadsOrganizations.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControlInfo;
        private System.Windows.Forms.TabPage tabPageProjects;
        private System.Windows.Forms.TreeView treeViewInfo;
        private System.Windows.Forms.SplitContainer splitContainerInfo;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageLogin;
        private Controls.RichTextBoxWithRTF richTextBoxWithRTFInfo;
        private Controls.RichTextBoxWithRTF richTextBoxWithRTFLogin;
        private System.Windows.Forms.TabControl tabControlProjects;
        private System.Windows.Forms.TabPage tabPageViewProjects;
        private Controls.RichTextBoxWithRTF richTextBoxWithRTFProjectView;
        private System.Windows.Forms.TabPage tabPageRoadMap;
        private System.Windows.Forms.TabPage tabPageHeadsOrganizations;
        private Controls.RichTextBoxWithRTF richTextBoxWithRTF1;
        private Controls.RichTextBoxWithRTF richTextBoxWithRTF2;
    }
}