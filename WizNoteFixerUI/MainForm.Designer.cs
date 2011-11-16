namespace WizNoteFixerUI
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.checkBoxFixFont = new System.Windows.Forms.CheckBox();
            this.textBoxNewFont = new System.Windows.Forms.TextBox();
            this.labelTips = new System.Windows.Forms.Label();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeSubDir = new System.Windows.Forms.CheckBox();
            this.linkLabelAuthor = new System.Windows.Forms.LinkLabel();
            this.textBoxOldFont = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxFixDiv = new System.Windows.Forms.CheckBox();
            this.checkBoxFixImg = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(267, 342);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(192, 342);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(75, 23);
            this.btnBackup.TabIndex = 1;
            this.btnBackup.Text = "备份";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.Location = new System.Drawing.Point(19, 9);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(504, 36);
            this.labelInfo.TabIndex = 2;
            this.labelInfo.Text = "本插件将对笔记中的图片进行重置到原始大小的处理。请无此需求的朋友慎用。";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(22, 48);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(501, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // checkBoxFixFont
            // 
            this.checkBoxFixFont.AutoSize = true;
            this.checkBoxFixFont.Location = new System.Drawing.Point(22, 79);
            this.checkBoxFixFont.Name = "checkBoxFixFont";
            this.checkBoxFixFont.Size = new System.Drawing.Size(122, 17);
            this.checkBoxFixFont.TabIndex = 4;
            this.checkBoxFixFont.Text = "强制替换所有字体";
            this.checkBoxFixFont.UseVisualStyleBackColor = true;
            this.checkBoxFixFont.CheckedChanged += new System.EventHandler(this.checkBoxFixFont_CheckedChanged);
            // 
            // textBoxNewFont
            // 
            this.textBoxNewFont.Enabled = false;
            this.textBoxNewFont.Location = new System.Drawing.Point(362, 77);
            this.textBoxNewFont.Name = "textBoxNewFont";
            this.textBoxNewFont.Size = new System.Drawing.Size(161, 20);
            this.textBoxNewFont.TabIndex = 5;
            this.textBoxNewFont.Text = "微软雅黑";
            // 
            // labelTips
            // 
            this.labelTips.AutoSize = true;
            this.labelTips.Location = new System.Drawing.Point(19, 128);
            this.labelTips.Name = "labelTips";
            this.labelTips.Size = new System.Drawing.Size(103, 13);
            this.labelTips.TabIndex = 8;
            this.labelTips.Text = "您选中的文档为：";
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(247, 104);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(74, 17);
            this.checkBoxSelectAll.TabIndex = 9;
            this.checkBoxSelectAll.Text = "全选文档";
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.checkBoxSelectAll_CheckedChanged);
            // 
            // checkBoxIncludeSubDir
            // 
            this.checkBoxIncludeSubDir.AutoSize = true;
            this.checkBoxIncludeSubDir.Location = new System.Drawing.Point(323, 104);
            this.checkBoxIncludeSubDir.Name = "checkBoxIncludeSubDir";
            this.checkBoxIncludeSubDir.Size = new System.Drawing.Size(86, 17);
            this.checkBoxIncludeSubDir.TabIndex = 10;
            this.checkBoxIncludeSubDir.Text = "包括子目录";
            this.checkBoxIncludeSubDir.UseVisualStyleBackColor = true;
            this.checkBoxIncludeSubDir.CheckedChanged += new System.EventHandler(this.checkBoxIncludeSubDir_CheckedChanged);
            // 
            // linkLabelAuthor
            // 
            this.linkLabelAuthor.AutoSize = true;
            this.linkLabelAuthor.Location = new System.Drawing.Point(419, 104);
            this.linkLabelAuthor.Name = "linkLabelAuthor";
            this.linkLabelAuthor.Size = new System.Drawing.Size(103, 13);
            this.linkLabelAuthor.TabIndex = 11;
            this.linkLabelAuthor.TabStop = true;
            this.linkLabelAuthor.Text = "windviki@gmail.com";
            this.linkLabelAuthor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAuthor_LinkClicked);
            // 
            // textBoxOldFont
            // 
            this.textBoxOldFont.Enabled = false;
            this.textBoxOldFont.Location = new System.Drawing.Point(149, 77);
            this.textBoxOldFont.Name = "textBoxOldFont";
            this.textBoxOldFont.Size = new System.Drawing.Size(158, 20);
            this.textBoxOldFont.TabIndex = 12;
            this.textBoxOldFont.Text = "宋体";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "替换为";
            // 
            // checkBoxFixDiv
            // 
            this.checkBoxFixDiv.AutoSize = true;
            this.checkBoxFixDiv.Location = new System.Drawing.Point(122, 104);
            this.checkBoxFixDiv.Name = "checkBoxFixDiv";
            this.checkBoxFixDiv.Size = new System.Drawing.Size(123, 17);
            this.checkBoxFixDiv.TabIndex = 14;
            this.checkBoxFixDiv.Text = "修复OneNote的DIV";
            this.checkBoxFixDiv.UseVisualStyleBackColor = true;
            this.checkBoxFixDiv.CheckedChanged += new System.EventHandler(this.checkBoxFixDiv_CheckedChanged);
            // 
            // checkBoxFixImg
            // 
            this.checkBoxFixImg.AutoSize = true;
            this.checkBoxFixImg.Location = new System.Drawing.Point(22, 104);
            this.checkBoxFixImg.Name = "checkBoxFixImg";
            this.checkBoxFixImg.Size = new System.Drawing.Size(98, 17);
            this.checkBoxFixImg.TabIndex = 15;
            this.checkBoxFixImg.Text = "去除图片宽高";
            this.checkBoxFixImg.UseVisualStyleBackColor = true;
            this.checkBoxFixImg.CheckedChanged += new System.EventHandler(this.checkBoxFixImg_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 362);
            this.Controls.Add(this.checkBoxFixImg);
            this.Controls.Add(this.checkBoxFixDiv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOldFont);
            this.Controls.Add(this.linkLabelAuthor);
            this.Controls.Add(this.checkBoxIncludeSubDir);
            this.Controls.Add(this.checkBoxSelectAll);
            this.Controls.Add(this.labelTips);
            this.Controls.Add(this.textBoxNewFont);
            this.Controls.Add(this.checkBoxFixFont);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnStart);
            this.MaximumSize = new System.Drawing.Size(543, 400);
            this.MinimumSize = new System.Drawing.Size(543, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WizNoteFixer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox checkBoxFixFont;
        private System.Windows.Forms.TextBox textBoxNewFont;
        //private AxWizKMControlsLib.AxWizFolderTreeCtrl axWizFolderTreeCtrl1;
        //private AxWizKMControlsLib.AxWizDocumentListCtrl axWizDocumentListCtrl1;
        private System.Windows.Forms.Label labelTips;
        private System.Windows.Forms.CheckBox checkBoxSelectAll;
        private System.Windows.Forms.CheckBox checkBoxIncludeSubDir;
        private System.Windows.Forms.LinkLabel linkLabelAuthor;
        private System.Windows.Forms.TextBox textBoxOldFont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxFixDiv;
        private System.Windows.Forms.CheckBox checkBoxFixImg;
    }
}

