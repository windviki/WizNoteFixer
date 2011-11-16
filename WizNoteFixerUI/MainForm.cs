//####################################################################
//	Created:	2011/03/18   11:33
//	Filename: 	MainForm
//	Author:		viki
//	Email:		windviki@gmail.com
//********************************************************************
//	Comments:	beautify note formats
//
//	UpdateLogs:	
//####################################################################

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using WizKMCoreLib;
using WizKMControlsLib;

using log4net;

namespace WizNoteFixerUI
{
    public partial class MainForm : Form
    {
        private string strInfo = "";
        private WalkNotesThread m_thdWalkNotes = null;
        private BackupDBThread m_thdBackupDB = null;
        private bool m_bisstopbutton = false;

        //private WizCommonUI m_wizui = new WizCommonUI();
        private WizDatabase m_wdb = new WizDatabaseClass();

        private AxWizKMControlsLib.AxWizFolderTreeCtrl axWizFolderTreeCtrl1;
        private AxWizKMControlsLib.AxWizDocumentListCtrl axWizDocumentListCtrl1;

        private string m_strSelectedPath = "";

        //日志记录
        private log4net.ILog m_log4net = null;

        public MainForm()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;

            // Test ParameterList
            //ParameterList pl = new ParameterList();
            //pl.Parse("  a =  1; b= true ; c:text  ; d; e:");
            //pl.Dict["b"] = "false";
            //pl.Dict["new"] = "2011";
            //String str1 = pl.Value();

            strInfo = labelInfo.Text;
            checkBoxFixImg.Checked = true;

            this.linkLabelAuthor.Links[0].LinkData = "mailto:windviki@gmail.com";

            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(Path.Combine(Environment.CurrentDirectory, "FixerLog.xml")));
            m_log4net = LogManager.GetLogger("WizNoteFixer");

            try
            {
                m_wdb.Open("");
            }
            catch (System.Exception ex)
            {
                labelInfo.Text = ex.ToString();
                return;
            }

            //this.axWizFolderTreeCtrl1.Database = m_wdb;

            m_thdWalkNotes = new WalkNotesThread();
            m_thdWalkNotes.DataBase = m_wdb;
            m_thdWalkNotes.OnProgress += new WalkNotesThread.ProgressHandler(OnWalkNotesProgress);

            m_thdBackupDB = new BackupDBThread();
            m_thdBackupDB.DataBase = m_wdb;
            m_thdBackupDB.OnProgress += new BackupDBThread.ProgressHandler(OnBackupDBProgress);
        }

        private void EnableUI(bool bEnable)
        {
            btnStart.Enabled = bEnable;
            btnBackup.Enabled = bEnable;
            checkBoxFixFont.Enabled = bEnable;
            checkBoxFixImg.Enabled = bEnable;
            checkBoxFixDiv.Enabled = bEnable;
            if (!bEnable)
            {
                textBoxOldFont.Enabled = false;
                textBoxNewFont.Enabled = false;
                checkBoxSelectAll.Enabled = false;
                axWizFolderTreeCtrl1.Enabled = false;
                axWizDocumentListCtrl1.Enabled = false;
                checkBoxIncludeSubDir.Enabled = false;
            }
            else
            {
                textBoxOldFont.Enabled = checkBoxFixFont.Checked;
                textBoxNewFont.Enabled = checkBoxFixFont.Checked;
                checkBoxSelectAll.Enabled = true;
                axWizFolderTreeCtrl1.Enabled = !checkBoxSelectAll.Checked;
                axWizDocumentListCtrl1.Enabled = !checkBoxSelectAll.Checked;
                checkBoxIncludeSubDir.Enabled = !checkBoxSelectAll.Checked;
            }
        }

        //修改html
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (m_thdWalkNotes.Docs == null || m_thdWalkNotes.Docs.Count == 0)
            {
                MessageBox.Show("请先选择待操作的目录或者文档！");
                return;
            }

            EnableUI(false);
            if (m_bisstopbutton) //当前显示为停止
            {
                //停止
                m_thdWalkNotes.Stop();
                m_bisstopbutton = false;
            }
            else //当前显示为开始
            {
                m_thdWalkNotes.ReplaceFont = checkBoxFixFont.Checked;
                m_thdWalkNotes.FixImg = checkBoxFixImg.Checked;
                m_thdWalkNotes.FixOneNoteDIV = checkBoxFixDiv.Checked;

                string[] oldfonts = textBoxOldFont.Text.Split(';');
                string[] newfonts = textBoxNewFont.Text.Split(';');

                m_thdWalkNotes.Fonts.Clear();

                for (int i = 0; i != oldfonts.Length; i++)
                {
                    m_thdWalkNotes.Fonts.Add(oldfonts[i], 
                        (i >= newfonts.Length) ? newfonts[newfonts.Length-1] : newfonts[i]);
                }

                //开始
                m_thdWalkNotes.Start();
            }
        }

        //备份
        private void btnBackup_Click(object sender, EventArgs e)
        {
            EnableUI(false);
            //开始
            m_thdBackupDB.Start();
        }

        private void checkBoxFixFont_CheckedChanged(object sender, EventArgs e)
        {
            textBoxOldFont.Enabled = checkBoxFixFont.Checked;
            textBoxNewFont.Enabled = checkBoxFixFont.Checked;
        }

        private void OnWalkNotesProgress(object sender, ProgressEventArgs e)
        {
            switch (e.State)
            {
                case FixerStatus.None:
                    break;

                case FixerStatus.Started:
                    progressBar1.Maximum = m_thdWalkNotes.NotesCount;
                    progressBar1.Step = 1;
                    progressBar1.Value = 0;

                    m_log4net.InfoFormat("笔记总数为：{0}", m_thdWalkNotes.NotesCount);
                    btnStart.Enabled = true;

                    btnStart.Text = "停止";
                    m_bisstopbutton = true;
                    break;

                case FixerStatus.Process:
                    m_log4net.Info(e.StrInfo);
                    progressBar1.PerformStep();
                    break;

                case FixerStatus.Skip:
                    //m_log4net.Info(e.StrInfo);
                    progressBar1.PerformStep();
                    break;

                case FixerStatus.Error:
                    m_log4net.Error(e.StrInfo);
                    progressBar1.PerformStep();
                    break;

                case FixerStatus.Done:
                case FixerStatus.UserCancel:
                    m_log4net.Info(e.StrInfo);

                    EnableUI(true);

                    btnStart.Text = "开始";
                    m_bisstopbutton = false;
                    break;

                case FixerStatus.FatalEnd:
                    m_log4net.Fatal(e.StrInfo);

                    EnableUI(true);

                    btnStart.Text = "开始";
                    m_bisstopbutton = false;
                    break;
            }
            labelInfo.Text = e.StrInfo;
        }

        private void OnBackupDBProgress(object sender, ProgressEventArgs e)
        {
            switch(e.State)
            {
                case FixerStatus.None:
                case FixerStatus.Started:
                case FixerStatus.Process:
                case FixerStatus.Skip:
                    break;
                case FixerStatus.Done:
                case FixerStatus.UserCancel:
                case FixerStatus.Error:
                case FixerStatus.FatalEnd:
                    EnableUI(true);
                    break;
            }
            labelInfo.Text = e.StrInfo;
            m_log4net.Info(e.StrInfo);
        }

        private IWizDocumentCollection GetWizNoteCountInDir(IWizFolder wf)
        {
            IWizDocumentCollection wdc = (IWizDocumentCollection)wf.Documents;
            foreach (IWizFolder wsubf in (IWizFolderCollection)wf.Folders)
            {
                IWizDocumentCollection wdctmp = GetWizNoteCountInDir(wsubf);
                foreach (IWizDocument wd in wdctmp)
                {
                    wdc.Add(wd);
                }
            }
            return wdc;
        }

        private void axWizFolderTreeCtrl1_SelChanged(object sender, EventArgs e)
        {
            IWizFolder wf = axWizFolderTreeCtrl1.SelectedFolder as IWizFolder;
            IWizDocumentCollection wdc = wf.Documents as IWizDocumentCollection;
            if (checkBoxIncludeSubDir.Checked)
            {
                m_thdWalkNotes.Docs = GetWizNoteCountInDir(wf);
            }
            else
            {
                m_thdWalkNotes.Docs = wdc;
            }
            this.axWizDocumentListCtrl1.SetDocuments(m_thdWalkNotes.Docs);
            m_strSelectedPath = wf.Location;
            labelTips.Text = String.Format("当前选中目录 {0} 下的所有文档({1}个)", m_strSelectedPath, m_thdWalkNotes.Docs.Count);
        }

        private void axWizDocumentListCtrl1_SelChanged(object sender, EventArgs e)
        {
            m_thdWalkNotes.Docs = axWizDocumentListCtrl1.SelectedDocuments as IWizDocumentCollection;
            labelTips.Text = String.Format("当前选中目录 {0} 下的{1}个文档", m_strSelectedPath, m_thdWalkNotes.Docs.Count);
        }

        private void checkBoxFixImg_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBoxFixDiv_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            axWizFolderTreeCtrl1.Enabled = !checkBoxSelectAll.Checked;
            axWizDocumentListCtrl1.Enabled = !checkBoxSelectAll.Checked;
            checkBoxIncludeSubDir.Enabled = !checkBoxSelectAll.Checked;
            if (checkBoxSelectAll.Checked)
            {
                m_thdWalkNotes.Docs = (IWizDocumentCollection)m_wdb.GetAllDocuments();
                labelTips.Text = String.Format("当前选中所有的{1}个文档", m_strSelectedPath, m_thdWalkNotes.Docs.Count);
            }
            else
            {
                axWizFolderTreeCtrl1_SelChanged(axWizFolderTreeCtrl1, null);
            }
        }

        private void checkBoxIncludeSubDir_CheckedChanged(object sender, EventArgs e)
        {
            axWizFolderTreeCtrl1_SelChanged(axWizFolderTreeCtrl1, null);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_wdb != null)
            {
                m_wdb.Close();
            }
        }

        private void linkLabelAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        //延迟创建AX控件，避免64位系统下窗体设计器崩溃
        private void MainForm_Load(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));

            this.axWizFolderTreeCtrl1 = new AxWizKMControlsLib.AxWizFolderTreeCtrl();
            this.axWizDocumentListCtrl1 = new AxWizKMControlsLib.AxWizDocumentListCtrl();

            ((System.ComponentModel.ISupportInitialize)(this.axWizFolderTreeCtrl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWizDocumentListCtrl1)).BeginInit();

            this.SuspendLayout();

            // 
            // axWizFolderTreeCtrl1
            // 
            this.axWizFolderTreeCtrl1.Enabled = true;
            this.axWizFolderTreeCtrl1.Location = new System.Drawing.Point(22, 146);
            this.axWizFolderTreeCtrl1.Name = "axWizFolderTreeCtrl1";
            this.axWizFolderTreeCtrl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWizFolderTreeCtrl1.OcxState")));
            this.axWizFolderTreeCtrl1.Size = new System.Drawing.Size(237, 192);
            this.axWizFolderTreeCtrl1.TabIndex = 6;
            this.axWizFolderTreeCtrl1.SelChanged += new System.EventHandler(this.axWizFolderTreeCtrl1_SelChanged);
            // 
            // axWizDocumentListCtrl1
            // 
            this.axWizDocumentListCtrl1.Enabled = true;
            this.axWizDocumentListCtrl1.Location = new System.Drawing.Point(265, 146);
            this.axWizDocumentListCtrl1.Name = "axWizDocumentListCtrl1";
            this.axWizDocumentListCtrl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWizDocumentListCtrl1.OcxState")));
            this.axWizDocumentListCtrl1.Size = new System.Drawing.Size(258, 192);
            this.axWizDocumentListCtrl1.TabIndex = 7;
            this.axWizDocumentListCtrl1.SelChanged += new System.EventHandler(this.axWizDocumentListCtrl1_SelChanged);

            this.Controls.Add(this.axWizDocumentListCtrl1);
            this.Controls.Add(this.axWizFolderTreeCtrl1);

            ((System.ComponentModel.ISupportInitialize)(this.axWizFolderTreeCtrl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWizDocumentListCtrl1)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();

            this.axWizFolderTreeCtrl1.Database = m_wdb;
        }
    }
}