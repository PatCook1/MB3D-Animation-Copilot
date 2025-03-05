using Syncfusion.WinForms.DataGrid;
using System.Reflection.PortableExecutable;

namespace MB3D_Animation_Copilot
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            lbl_RecordingLabel = new System.Windows.Forms.Label();
            btn_StartOver = new Syncfusion.WinForms.Controls.SfButton();
            btn_SaveToFile = new Syncfusion.WinForms.Controls.SfButton();
            label3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            label4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            label6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            lbl_SavedFilePathName = new System.Windows.Forms.Label();
            pnl_Bottom = new System.Windows.Forms.Panel();
            num_AutoSaveTrigger = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            grp_FooterMessageArea = new System.Windows.Forms.GroupBox();
            lbl_FooterMessage = new System.Windows.Forms.Label();
            btn_Exit = new Syncfusion.WinForms.Controls.SfButton();
            label30 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            label29 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            mtbx_KeyDelay = new Syncfusion.WinForms.Input.SfNumericTextBox();
            autoLabel11 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            lbl_ProjectSavingIndicator = new System.Windows.Forms.Label();
            btn_RestorePointInfo = new Syncfusion.WinForms.Controls.SfButton();
            btn_ClearRestorePoint = new Syncfusion.WinForms.Controls.SfButton();
            btn_PerformRestorePoint = new Syncfusion.WinForms.Controls.SfButton();
            btn_SetRestorePoint = new Syncfusion.WinForms.Controls.SfButton();
            lbl_LastKeyEvent = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            pnl_Top = new System.Windows.Forms.Panel();
            ll_GithubRespository = new System.Windows.Forms.LinkLabel();
            ll_PCGithubURL = new System.Windows.Forms.LinkLabel();
            btn_FindM3AFile = new Syncfusion.WinForms.Controls.SfButton();
            btn_FindM3PIFile = new Syncfusion.WinForms.Controls.SfButton();
            tbx_M3A_FileLocation = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            tbx_M3PI_FileLocation = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel14 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel13 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            drp_ProjectList = new Syncfusion.WinForms.ListView.SfComboBox();
            btn_DeleteProject = new Syncfusion.WinForms.Controls.SfButton();
            mtbx_FramesBetween = new Syncfusion.WinForms.Input.SfNumericTextBox();
            mtbx_LookingRollingAngle = new Syncfusion.WinForms.Input.SfNumericTextBox();
            mtbx_SlidingWalkingCount = new Syncfusion.WinForms.Input.SfNumericTextBox();
            mtbx_FarPlane = new Syncfusion.WinForms.Input.SfNumericTextBox();
            mtbx_FrameCount = new Syncfusion.WinForms.Input.SfNumericTextBox();
            tbx_AnimationName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            tbx_ProjectNotes = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            btn_SaveCurrentProject = new Syncfusion.WinForms.Controls.SfButton();
            lbl_60FPSTimeCalc = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            lbl_30FPSTimeCalc = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel12 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel10 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            lbl_ProjectAsOfDateTime = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel9 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel8 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel7 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btn_DisableCapture = new Syncfusion.WinForms.Controls.SfButton();
            btn_EnableCapture = new Syncfusion.WinForms.Controls.SfButton();
            btn_NewProject = new Syncfusion.WinForms.Controls.SfButton();
            label48 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            lbl_ApplicationMainTitle = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            lbl_ShiftIndicator = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            lbl_KeyframeStackLineChars = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            label31 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            lbl_MB3D_AppRun_Warn = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            pnl_MovesList = new System.Windows.Forms.Panel();
            btn_ShowKeyLegendWindow = new Syncfusion.WinForms.Controls.SfButton();
            panel3 = new System.Windows.Forms.Panel();
            lbl_MovesList = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            panel5 = new System.Windows.Forms.Panel();
            nup_AutoMoveQuantity = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            btn_InsertAutoMove = new Syncfusion.WinForms.Controls.SfButton();
            cbx_EnableAutoMove = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            cbx_AutoMoveShift = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            label14 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            label13 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            drp_AutoLastMove = new Syncfusion.WinForms.ListView.SfComboBox();
            pnl_KeyStack = new System.Windows.Forms.Panel();
            panel14 = new System.Windows.Forms.Panel();
            dgv_Keyframes_sf = new SfDataGrid();
            panel12 = new System.Windows.Forms.Panel();
            grpManageKeyframes = new System.Windows.Forms.GroupBox();
            btn_ManageKeyframeCommandGo = new Syncfusion.WinForms.Controls.SfButton();
            drpKeyframeCommands = new Syncfusion.WinForms.ListView.SfComboBox();
            btn_DeleteKeyframe = new Syncfusion.WinForms.Controls.SfButton();
            lbl_KeyframesRange_Start = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            num_EndDeleteKeyframe = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            lbl_KeyframesRange_End = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            num_StartDeleteKeyframe = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            grpKeyframeActions = new System.Windows.Forms.GroupBox();
            drp_KeyframeActions = new Syncfusion.WinForms.ListView.SfComboBox();
            num_SendKeyStepAngleCount = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            btn_KeyframeAction_Delete = new Syncfusion.WinForms.Controls.SfButton();
            label43 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            num_SendKeyQuantity = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            tbx_SendKeyChar = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label44 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            label42 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            label41 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            tbx_KeyframeAction_Name = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            btn_KeyframeAction_Update = new Syncfusion.WinForms.Controls.SfButton();
            tabControl1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            page_AnimationCopilot = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            panel8 = new System.Windows.Forms.Panel();
            panel7 = new System.Windows.Forms.Panel();
            lbl_JTK_AppRun_Warn = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btn_ShowMoveSequenceInfo = new Syncfusion.WinForms.Controls.SfButton();
            mtbx_NextKeyframeNumber = new Syncfusion.WinForms.Input.SfNumericTextBox();
            label46 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            label45 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            lbl_BusyLabel = new System.Windows.Forms.Label();
            lbl_MoveSequenceDesc = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btn_UseImmediateSeq = new Syncfusion.WinForms.Controls.SfButton();
            label22 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            drp_UseSequenceList = new Syncfusion.WinForms.ListView.SfComboBox();
            page_MoveDesigner = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            panel9 = new System.Windows.Forms.Panel();
            splitContainer_ManageSeq = new System.Windows.Forms.SplitContainer();
            dgv_ManageMoveSequence = new SfDataGrid();
            panel6 = new System.Windows.Forms.Panel();
            panel4 = new System.Windows.Forms.Panel();
            autoLabel17 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btn_ManageSeqAddStep = new Syncfusion.WinForms.Controls.SfButton();
            lbl_ManageSeqFooterMsgArea = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btn_ManageSeqDeleteStep = new Syncfusion.WinForms.Controls.SfButton();
            btn_ManageSeqUpdateStep = new Syncfusion.WinForms.Controls.SfButton();
            drp_ManageSeqStepNameList = new Syncfusion.WinForms.ListView.SfComboBox();
            num_ManageSeqSendKeyQty = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            autoLabel19 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel18 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            lbl_ManageSeqSelected = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel16 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            panel_ManageSeqTop = new System.Windows.Forms.Panel();
            btn_ManageSeqDeleteSequence = new Syncfusion.WinForms.Controls.SfButton();
            tbx_SequenceDesc_Manage = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            drp_ManageSeqMoveSequences = new Syncfusion.WinForms.ListView.SfComboBox();
            label20 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel15 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            label18 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            label24 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            page_Utilities = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            panel_UtilitiesPage = new System.Windows.Forms.Panel();
            btn_FarPlaneUpdater = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel20 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btn_LookLeftUpdater = new Syncfusion.WinForms.Controls.SfButton();
            page_Library = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            panel10 = new System.Windows.Forms.Panel();
            autoLabel23 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel21 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            label10 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            label40 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            page_Admin = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            panel11 = new System.Windows.Forms.Panel();
            groupBox2 = new System.Windows.Forms.GroupBox();
            btn_CreateSampleProject = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel35 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            btn_EraseAllDatabaseRecords_KeepMS = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel34 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btn_EraseAllDatabaseRecords = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel24 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            gb_DBAdmin_Restore = new System.Windows.Forms.GroupBox();
            btn_DBAdmin_RestoreDBFile = new Syncfusion.WinForms.Controls.SfButton();
            tbx_DBAdmin_Restore_DBFolder = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label55 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btn_DBAdmin_Restore = new Syncfusion.WinForms.Controls.SfButton();
            gb_DBAdmin_Backup = new System.Windows.Forms.GroupBox();
            lbl_DatabaseFileInUse = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel22 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            label52 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            tbx_DBAdmin_Backup_DBNewFileName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label56 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btn_DBAdmin_BackupFolder = new Syncfusion.WinForms.Controls.SfButton();
            tbx_DBAdmin_Backup_FolderName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label53 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btn_DBAdmin_Backup = new Syncfusion.WinForms.Controls.SfButton();
            page_About = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            panel13 = new System.Windows.Forms.Panel();
            btn_ErrorLogLocation = new Syncfusion.WinForms.Controls.SfButton();
            btn_CopyLog = new Syncfusion.WinForms.Controls.SfButton();
            btn_EraseLog = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel33 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            tbx_ErrorLogContent = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            ll_GithubRespository_About = new System.Windows.Forms.LinkLabel();
            ll_PCGithubURL_About = new System.Windows.Forms.LinkLabel();
            grp_Admin_JoytoKey = new System.Windows.Forms.GroupBox();
            autoLabel32 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            ll_JoyToKey_About = new System.Windows.Forms.LinkLabel();
            lbl_Admin_JoyToKey_Loc = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            lbl_Admin_JoyToKey_Intro = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel31 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel30 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel29 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel28 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            label2 = new System.Windows.Forms.Label();
            autoLabel27 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel26 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel25 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            openFileDialog_BackupFindFile = new System.Windows.Forms.OpenFileDialog();
            folderBrowserDialog_DBBackupFolder = new System.Windows.Forms.FolderBrowserDialog();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            contextMenuStripEx1 = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            openFileDialog_M3PIFileLoc = new System.Windows.Forms.OpenFileDialog();
            openFileDialog_M3AFileLoc = new System.Windows.Forms.OpenFileDialog();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            pnl_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_AutoSaveTrigger).BeginInit();
            grp_FooterMessageArea.SuspendLayout();
            pnl_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbx_M3A_FileLocation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbx_M3PI_FileLocation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)drp_ProjectList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbx_AnimationName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbx_ProjectNotes).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            pnl_MovesList.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nup_AutoMoveQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbx_EnableAutoMove).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbx_AutoMoveShift).BeginInit();
            ((System.ComponentModel.ISupportInitialize)drp_AutoLastMove).BeginInit();
            pnl_KeyStack.SuspendLayout();
            panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Keyframes_sf).BeginInit();
            panel12.SuspendLayout();
            grpManageKeyframes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)drpKeyframeCommands).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_EndDeleteKeyframe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_StartDeleteKeyframe).BeginInit();
            grpKeyframeActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)drp_KeyframeActions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_SendKeyStepAngleCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_SendKeyQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbx_SendKeyChar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbx_KeyframeAction_Name).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabControl1).BeginInit();
            tabControl1.SuspendLayout();
            page_AnimationCopilot.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)drp_UseSequenceList).BeginInit();
            page_MoveDesigner.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_ManageSeq).BeginInit();
            splitContainer_ManageSeq.Panel1.SuspendLayout();
            splitContainer_ManageSeq.Panel2.SuspendLayout();
            splitContainer_ManageSeq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ManageMoveSequence).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)drp_ManageSeqStepNameList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_ManageSeqSendKeyQty).BeginInit();
            panel_ManageSeqTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbx_SequenceDesc_Manage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)drp_ManageSeqMoveSequences).BeginInit();
            page_Utilities.SuspendLayout();
            panel_UtilitiesPage.SuspendLayout();
            page_Library.SuspendLayout();
            panel10.SuspendLayout();
            page_Admin.SuspendLayout();
            panel11.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            gb_DBAdmin_Restore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbx_DBAdmin_Restore_DBFolder).BeginInit();
            gb_DBAdmin_Backup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbx_DBAdmin_Backup_DBNewFileName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbx_DBAdmin_Backup_FolderName).BeginInit();
            page_About.SuspendLayout();
            panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbx_ErrorLogContent).BeginInit();
            grp_Admin_JoytoKey.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_RecordingLabel
            // 
            lbl_RecordingLabel.AutoSize = true;
            lbl_RecordingLabel.BackColor = System.Drawing.Color.DarkGreen;
            lbl_RecordingLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lbl_RecordingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            lbl_RecordingLabel.ForeColor = System.Drawing.Color.Yellow;
            lbl_RecordingLabel.Location = new System.Drawing.Point(19, 91);
            lbl_RecordingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_RecordingLabel.Name = "lbl_RecordingLabel";
            lbl_RecordingLabel.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            lbl_RecordingLabel.Size = new System.Drawing.Size(280, 38);
            lbl_RecordingLabel.TabIndex = 3;
            lbl_RecordingLabel.Text = "  CAPTURING   ";
            lbl_RecordingLabel.Visible = false;
            // 
            // btn_StartOver
            // 
            btn_StartOver.AllowWrapText = true;
            btn_StartOver.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btn_StartOver.Location = new System.Drawing.Point(388, 9);
            btn_StartOver.Margin = new System.Windows.Forms.Padding(4);
            btn_StartOver.Name = "btn_StartOver";
            btn_StartOver.Size = new System.Drawing.Size(58, 57);
            btn_StartOver.TabIndex = 10;
            btn_StartOver.Text = "Start Over";
            btn_StartOver.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_StartOver, "Delete all keyframes of the currentlly selected project - Start Over");
            btn_StartOver.UseVisualStyleBackColor = true;
            btn_StartOver.Click += btn_StartOver_Click;
            // 
            // btn_SaveToFile
            // 
            btn_SaveToFile.AllowWrapText = true;
            btn_SaveToFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btn_SaveToFile.Location = new System.Drawing.Point(397, 8);
            btn_SaveToFile.Margin = new System.Windows.Forms.Padding(4);
            btn_SaveToFile.Name = "btn_SaveToFile";
            btn_SaveToFile.Size = new System.Drawing.Size(127, 46);
            btn_SaveToFile.TabIndex = 11;
            btn_SaveToFile.Text = "Export Project && Keyframes to File";
            btn_SaveToFile.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_SaveToFile, "Export project data and Keystack to a text file");
            btn_SaveToFile.UseVisualStyleBackColor = true;
            btn_SaveToFile.Click += btn_SaveToFile_Click;
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label3.ForeColor = System.Drawing.Color.White;
            label3.Location = new System.Drawing.Point(8, 14);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(125, 20);
            label3.TabIndex = 12;
            label3.Text = "Keyframe Stack:";
            label3.ThemeName = "HighContrastTheme";
            // 
            // label4
            // 
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label4.ForeColor = System.Drawing.Color.White;
            label4.Location = new System.Drawing.Point(5, 14);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(116, 20);
            label4.TabIndex = 13;
            label4.Text = "Current Moves:";
            label4.ThemeName = "HighContrastTheme";
            // 
            // label6
            // 
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label6.ForeColor = System.Drawing.Color.White;
            label6.Location = new System.Drawing.Point(467, 16);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(32, 15);
            label6.TabIndex = 16;
            label6.Text = "Next";
            label6.ThemeName = "HighContrastTheme";
            // 
            // lbl_SavedFilePathName
            // 
            lbl_SavedFilePathName.AutoSize = true;
            lbl_SavedFilePathName.Location = new System.Drawing.Point(106, 15);
            lbl_SavedFilePathName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_SavedFilePathName.Name = "lbl_SavedFilePathName";
            lbl_SavedFilePathName.Size = new System.Drawing.Size(0, 13);
            lbl_SavedFilePathName.TabIndex = 27;
            // 
            // pnl_Bottom
            // 
            pnl_Bottom.Controls.Add(num_AutoSaveTrigger);
            pnl_Bottom.Controls.Add(grp_FooterMessageArea);
            pnl_Bottom.Controls.Add(btn_Exit);
            pnl_Bottom.Controls.Add(label30);
            pnl_Bottom.Controls.Add(label29);
            pnl_Bottom.Controls.Add(btn_SaveToFile);
            pnl_Bottom.Controls.Add(mtbx_KeyDelay);
            pnl_Bottom.Controls.Add(autoLabel11);
            pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnl_Bottom.Location = new System.Drawing.Point(4, 476);
            pnl_Bottom.Margin = new System.Windows.Forms.Padding(4);
            pnl_Bottom.Name = "pnl_Bottom";
            pnl_Bottom.Size = new System.Drawing.Size(1276, 60);
            pnl_Bottom.TabIndex = 28;
            // 
            // num_AutoSaveTrigger
            // 
            num_AutoSaveTrigger.BeforeTouchSize = new System.Drawing.Size(44, 23);
            num_AutoSaveTrigger.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            num_AutoSaveTrigger.Location = new System.Drawing.Point(100, 21);
            num_AutoSaveTrigger.Margin = new System.Windows.Forms.Padding(4);
            num_AutoSaveTrigger.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            num_AutoSaveTrigger.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_AutoSaveTrigger.Name = "num_AutoSaveTrigger";
            num_AutoSaveTrigger.Size = new System.Drawing.Size(44, 23);
            num_AutoSaveTrigger.TabIndex = 46;
            num_AutoSaveTrigger.ThemeName = "HighContrastTheme";
            num_AutoSaveTrigger.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            toolTip1.SetToolTip(num_AutoSaveTrigger, "Edit Step Quantity");
            num_AutoSaveTrigger.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // grp_FooterMessageArea
            // 
            grp_FooterMessageArea.Controls.Add(lbl_FooterMessage);
            grp_FooterMessageArea.ForeColor = System.Drawing.Color.White;
            grp_FooterMessageArea.Location = new System.Drawing.Point(534, 4);
            grp_FooterMessageArea.Margin = new System.Windows.Forms.Padding(4);
            grp_FooterMessageArea.Name = "grp_FooterMessageArea";
            grp_FooterMessageArea.Padding = new System.Windows.Forms.Padding(4);
            grp_FooterMessageArea.Size = new System.Drawing.Size(628, 51);
            grp_FooterMessageArea.TabIndex = 45;
            grp_FooterMessageArea.TabStop = false;
            grp_FooterMessageArea.Text = "Message Area";
            // 
            // lbl_FooterMessage
            // 
            lbl_FooterMessage.AutoSize = true;
            lbl_FooterMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lbl_FooterMessage.Location = new System.Drawing.Point(6, 17);
            lbl_FooterMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_FooterMessage.Name = "lbl_FooterMessage";
            lbl_FooterMessage.Size = new System.Drawing.Size(0, 20);
            lbl_FooterMessage.TabIndex = 41;
            // 
            // btn_Exit
            // 
            btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btn_Exit.Location = new System.Drawing.Point(1174, 8);
            btn_Exit.Margin = new System.Windows.Forms.Padding(4);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new System.Drawing.Size(88, 46);
            btn_Exit.TabIndex = 17;
            btn_Exit.Text = "Exit";
            btn_Exit.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_Exit, "Exit the Mandelbulb3D Animation Copilot");
            btn_Exit.UseVisualStyleBackColor = true;
            btn_Exit.Click += btn_Exit_Click;
            // 
            // label30
            // 
            label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label30.ForeColor = System.Drawing.Color.White;
            label30.Location = new System.Drawing.Point(145, 25);
            label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(65, 15);
            label30.TabIndex = 16;
            label30.Text = "Keyframes";
            label30.ThemeName = "HighContrastTheme";
            // 
            // label29
            // 
            label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label29.ForeColor = System.Drawing.Color.White;
            label29.Location = new System.Drawing.Point(6, 23);
            label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(93, 15);
            label29.TabIndex = 14;
            label29.Text = "Auto Save Every";
            label29.ThemeName = "HighContrastTheme";
            // 
            // mtbx_KeyDelay
            // 
            mtbx_KeyDelay.ForeColor = System.Drawing.SystemColors.WindowText;
            mtbx_KeyDelay.HideTrailingZeros = true;
            mtbx_KeyDelay.Location = new System.Drawing.Point(313, 24);
            mtbx_KeyDelay.MaxLength = 3;
            mtbx_KeyDelay.MaxValue = 1000D;
            mtbx_KeyDelay.MinValue = 0D;
            mtbx_KeyDelay.Name = "mtbx_KeyDelay";
            mtbx_KeyDelay.Size = new System.Drawing.Size(61, 20);
            mtbx_KeyDelay.Style.FocusBorderColor = System.Drawing.Color.FromArgb(0, 120, 215);
            mtbx_KeyDelay.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            mtbx_KeyDelay.TabIndex = 74;
            mtbx_KeyDelay.Text = "0";
            mtbx_KeyDelay.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(mtbx_KeyDelay, "Key Delay (0-1,000)");
            mtbx_KeyDelay.TabStopChanged += mtbx_KeyDelay_TabStopChanged;
            mtbx_KeyDelay.TextChanged += mtbx_KeyDelay_TextChanged;
            mtbx_KeyDelay.Enter += mtbx_KeyDelay_Enter;
            // 
            // autoLabel11
            // 
            autoLabel11.BackColor = System.Drawing.Color.Transparent;
            autoLabel11.ForeColor = System.Drawing.Color.White;
            autoLabel11.Location = new System.Drawing.Point(231, 28);
            autoLabel11.Name = "autoLabel11";
            autoLabel11.Size = new System.Drawing.Size(80, 13);
            autoLabel11.TabIndex = 60;
            autoLabel11.Text = "Key Delay (ms):";
            autoLabel11.ThemeName = "HighContrastTheme";
            // 
            // lbl_ProjectSavingIndicator
            // 
            lbl_ProjectSavingIndicator.AutoSize = true;
            lbl_ProjectSavingIndicator.BackColor = System.Drawing.Color.DarkGreen;
            lbl_ProjectSavingIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_ProjectSavingIndicator.ForeColor = System.Drawing.Color.Yellow;
            lbl_ProjectSavingIndicator.Location = new System.Drawing.Point(928, 21);
            lbl_ProjectSavingIndicator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_ProjectSavingIndicator.Name = "lbl_ProjectSavingIndicator";
            lbl_ProjectSavingIndicator.Padding = new System.Windows.Forms.Padding(6);
            lbl_ProjectSavingIndicator.Size = new System.Drawing.Size(91, 37);
            lbl_ProjectSavingIndicator.TabIndex = 15;
            lbl_ProjectSavingIndicator.Text = "Saving";
            lbl_ProjectSavingIndicator.Visible = false;
            // 
            // btn_RestorePointInfo
            // 
            btn_RestorePointInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btn_RestorePointInfo.Location = new System.Drawing.Point(1216, 9);
            btn_RestorePointInfo.Margin = new System.Windows.Forms.Padding(4);
            btn_RestorePointInfo.Name = "btn_RestorePointInfo";
            btn_RestorePointInfo.Size = new System.Drawing.Size(24, 26);
            btn_RestorePointInfo.TabIndex = 27;
            btn_RestorePointInfo.Text = "?";
            btn_RestorePointInfo.ThemeName = "HighContrastTheme";
            btn_RestorePointInfo.UseVisualStyleBackColor = true;
            btn_RestorePointInfo.Click += btn_RestorePointInfo_Click;
            // 
            // btn_ClearRestorePoint
            // 
            btn_ClearRestorePoint.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btn_ClearRestorePoint.Location = new System.Drawing.Point(1244, 9);
            btn_ClearRestorePoint.Margin = new System.Windows.Forms.Padding(4);
            btn_ClearRestorePoint.Name = "btn_ClearRestorePoint";
            btn_ClearRestorePoint.Size = new System.Drawing.Size(24, 26);
            btn_ClearRestorePoint.TabIndex = 26;
            btn_ClearRestorePoint.Text = "C";
            btn_ClearRestorePoint.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_ClearRestorePoint, "Clear the last Set Restore Point");
            btn_ClearRestorePoint.UseVisualStyleBackColor = true;
            btn_ClearRestorePoint.Click += btn_ClearRestorePoint_Click;
            // 
            // btn_PerformRestorePoint
            // 
            btn_PerformRestorePoint.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btn_PerformRestorePoint.Location = new System.Drawing.Point(1074, 41);
            btn_PerformRestorePoint.Margin = new System.Windows.Forms.Padding(4);
            btn_PerformRestorePoint.Name = "btn_PerformRestorePoint";
            btn_PerformRestorePoint.Size = new System.Drawing.Size(194, 26);
            btn_PerformRestorePoint.TabIndex = 25;
            btn_PerformRestorePoint.Text = "Perform Restore Point";
            btn_PerformRestorePoint.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_PerformRestorePoint, "Perform a restore of last Set Restore Point");
            btn_PerformRestorePoint.UseVisualStyleBackColor = true;
            btn_PerformRestorePoint.Click += btn_PerformRestorePoint_Click;
            // 
            // btn_SetRestorePoint
            // 
            btn_SetRestorePoint.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btn_SetRestorePoint.ForeColor = System.Drawing.Color.White;
            btn_SetRestorePoint.Location = new System.Drawing.Point(1074, 9);
            btn_SetRestorePoint.Margin = new System.Windows.Forms.Padding(4);
            btn_SetRestorePoint.Name = "btn_SetRestorePoint";
            btn_SetRestorePoint.Size = new System.Drawing.Size(138, 26);
            btn_SetRestorePoint.Style.ForeColor = System.Drawing.Color.White;
            btn_SetRestorePoint.TabIndex = 24;
            btn_SetRestorePoint.Text = "Set Restore Point";
            btn_SetRestorePoint.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_SetRestorePoint, "Set a new Restore Point at the currently selected keyframe");
            btn_SetRestorePoint.UseVisualStyleBackColor = true;
            btn_SetRestorePoint.Click += btn_SetRestorePoint_Click;
            // 
            // lbl_LastKeyEvent
            // 
            lbl_LastKeyEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lbl_LastKeyEvent.ForeColor = System.Drawing.Color.White;
            lbl_LastKeyEvent.Location = new System.Drawing.Point(238, 15);
            lbl_LastKeyEvent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_LastKeyEvent.Name = "lbl_LastKeyEvent";
            lbl_LastKeyEvent.Size = new System.Drawing.Size(92, 15);
            lbl_LastKeyEvent.TabIndex = 23;
            lbl_LastKeyEvent.Text = "Last Key Event: ";
            lbl_LastKeyEvent.ThemeName = "HighContrastTheme";
            // 
            // pnl_Top
            // 
            pnl_Top.BackColor = System.Drawing.Color.Black;
            pnl_Top.Controls.Add(ll_GithubRespository);
            pnl_Top.Controls.Add(ll_PCGithubURL);
            pnl_Top.Controls.Add(btn_FindM3AFile);
            pnl_Top.Controls.Add(btn_FindM3PIFile);
            pnl_Top.Controls.Add(tbx_M3A_FileLocation);
            pnl_Top.Controls.Add(tbx_M3PI_FileLocation);
            pnl_Top.Controls.Add(autoLabel14);
            pnl_Top.Controls.Add(autoLabel13);
            pnl_Top.Controls.Add(drp_ProjectList);
            pnl_Top.Controls.Add(btn_DeleteProject);
            pnl_Top.Controls.Add(mtbx_FramesBetween);
            pnl_Top.Controls.Add(mtbx_LookingRollingAngle);
            pnl_Top.Controls.Add(mtbx_SlidingWalkingCount);
            pnl_Top.Controls.Add(mtbx_FarPlane);
            pnl_Top.Controls.Add(mtbx_FrameCount);
            pnl_Top.Controls.Add(tbx_AnimationName);
            pnl_Top.Controls.Add(tbx_ProjectNotes);
            pnl_Top.Controls.Add(btn_SaveCurrentProject);
            pnl_Top.Controls.Add(lbl_60FPSTimeCalc);
            pnl_Top.Controls.Add(lbl_30FPSTimeCalc);
            pnl_Top.Controls.Add(autoLabel12);
            pnl_Top.Controls.Add(autoLabel10);
            pnl_Top.Controls.Add(lbl_ProjectAsOfDateTime);
            pnl_Top.Controls.Add(autoLabel9);
            pnl_Top.Controls.Add(autoLabel8);
            pnl_Top.Controls.Add(autoLabel7);
            pnl_Top.Controls.Add(autoLabel6);
            pnl_Top.Controls.Add(autoLabel5);
            pnl_Top.Controls.Add(autoLabel4);
            pnl_Top.Controls.Add(autoLabel3);
            pnl_Top.Controls.Add(autoLabel2);
            pnl_Top.Controls.Add(autoLabel1);
            pnl_Top.Controls.Add(btn_DisableCapture);
            pnl_Top.Controls.Add(btn_EnableCapture);
            pnl_Top.Controls.Add(btn_NewProject);
            pnl_Top.Controls.Add(label48);
            pnl_Top.Controls.Add(lbl_ApplicationMainTitle);
            pnl_Top.Controls.Add(lbl_RecordingLabel);
            pnl_Top.Dock = System.Windows.Forms.DockStyle.Top;
            pnl_Top.Location = new System.Drawing.Point(2, 2);
            pnl_Top.Margin = new System.Windows.Forms.Padding(4);
            pnl_Top.Name = "pnl_Top";
            pnl_Top.Size = new System.Drawing.Size(1290, 184);
            pnl_Top.TabIndex = 31;
            // 
            // ll_GithubRespository
            // 
            ll_GithubRespository.ActiveLinkColor = System.Drawing.Color.White;
            ll_GithubRespository.ForeColor = System.Drawing.Color.White;
            ll_GithubRespository.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            ll_GithubRespository.LinkColor = System.Drawing.Color.White;
            ll_GithubRespository.Location = new System.Drawing.Point(1088, 144);
            ll_GithubRespository.Name = "ll_GithubRespository";
            ll_GithubRespository.Size = new System.Drawing.Size(189, 21);
            ll_GithubRespository.TabIndex = 85;
            ll_GithubRespository.Text = "The Copilot Project at Github.com";
            ll_GithubRespository.VisitedLinkColor = System.Drawing.Color.Yellow;
            ll_GithubRespository.LinkClicked += ll_GithubRespository_LinkClicked;
            // 
            // ll_PCGithubURL
            // 
            ll_PCGithubURL.ActiveLinkColor = System.Drawing.Color.White;
            ll_PCGithubURL.ForeColor = System.Drawing.Color.White;
            ll_PCGithubURL.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            ll_PCGithubURL.LinkColor = System.Drawing.Color.White;
            ll_PCGithubURL.Location = new System.Drawing.Point(1086, 165);
            ll_PCGithubURL.Name = "ll_PCGithubURL";
            ll_PCGithubURL.Size = new System.Drawing.Size(194, 21);
            ll_PCGithubURL.TabIndex = 84;
            ll_PCGithubURL.Text = "Support Site at PatCook1.Github.io";
            ll_PCGithubURL.VisitedLinkColor = System.Drawing.Color.Yellow;
            ll_PCGithubURL.LinkClicked += ll_PCGithubURL_LinkClicked;
            // 
            // btn_FindM3AFile
            // 
            btn_FindM3AFile.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_FindM3AFile.Location = new System.Drawing.Point(649, 88);
            btn_FindM3AFile.Name = "btn_FindM3AFile";
            btn_FindM3AFile.Size = new System.Drawing.Size(42, 23);
            btn_FindM3AFile.TabIndex = 83;
            btn_FindM3AFile.Text = "Find";
            btn_FindM3AFile.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_FindM3AFile, "Location this project's Mandelbulb3D animation (M3A) file");
            btn_FindM3AFile.Click += btn_FindM3AFile_Click;
            // 
            // btn_FindM3PIFile
            // 
            btn_FindM3PIFile.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_FindM3PIFile.Location = new System.Drawing.Point(649, 58);
            btn_FindM3PIFile.Name = "btn_FindM3PIFile";
            btn_FindM3PIFile.Size = new System.Drawing.Size(42, 23);
            btn_FindM3PIFile.TabIndex = 82;
            btn_FindM3PIFile.Text = "Find";
            btn_FindM3PIFile.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_FindM3PIFile, "Location this project's Mandelbulb3D parameter (M3P or M3I) file");
            btn_FindM3PIFile.Click += btn_FindM3PIFile_Click;
            // 
            // tbx_M3A_FileLocation
            // 
            tbx_M3A_FileLocation.BeforeTouchSize = new System.Drawing.Size(478, 276);
            tbx_M3A_FileLocation.Location = new System.Drawing.Point(385, 88);
            tbx_M3A_FileLocation.Name = "tbx_M3A_FileLocation";
            tbx_M3A_FileLocation.Size = new System.Drawing.Size(257, 23);
            tbx_M3A_FileLocation.TabIndex = 81;
            tbx_M3A_FileLocation.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(tbx_M3A_FileLocation, "The project's Mandelbulb3D animation file (M3A) location");
            // 
            // tbx_M3PI_FileLocation
            // 
            tbx_M3PI_FileLocation.BeforeTouchSize = new System.Drawing.Size(478, 276);
            tbx_M3PI_FileLocation.Location = new System.Drawing.Point(385, 58);
            tbx_M3PI_FileLocation.Name = "tbx_M3PI_FileLocation";
            tbx_M3PI_FileLocation.Size = new System.Drawing.Size(257, 23);
            tbx_M3PI_FileLocation.TabIndex = 80;
            tbx_M3PI_FileLocation.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(tbx_M3PI_FileLocation, "The project's Mandelbulb3D paramater file (M3p or M3i) location");
            // 
            // autoLabel14
            // 
            autoLabel14.ForeColor = System.Drawing.Color.White;
            autoLabel14.Location = new System.Drawing.Point(325, 90);
            autoLabel14.Name = "autoLabel14";
            autoLabel14.Size = new System.Drawing.Size(56, 15);
            autoLabel14.TabIndex = 79;
            autoLabel14.Text = "M3A File:";
            autoLabel14.ThemeName = "HighContrastTheme";
            // 
            // autoLabel13
            // 
            autoLabel13.ForeColor = System.Drawing.Color.White;
            autoLabel13.Location = new System.Drawing.Point(319, 62);
            autoLabel13.Name = "autoLabel13";
            autoLabel13.Size = new System.Drawing.Size(63, 15);
            autoLabel13.TabIndex = 78;
            autoLabel13.Text = "M3P/I File:";
            autoLabel13.ThemeName = "HighContrastTheme";
            // 
            // drp_ProjectList
            // 
            drp_ProjectList.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            drp_ProjectList.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            drp_ProjectList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            drp_ProjectList.Location = new System.Drawing.Point(19, 28);
            drp_ProjectList.MaxDropDownItems = 20;
            drp_ProjectList.Name = "drp_ProjectList";
            drp_ProjectList.Size = new System.Drawing.Size(281, 26);
            drp_ProjectList.Style.EditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            drp_ProjectList.Style.ReadOnlyEditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            drp_ProjectList.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            drp_ProjectList.Style.TokenStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            drp_ProjectList.TabIndex = 77;
            drp_ProjectList.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(drp_ProjectList, "Select an existing animation project");
            drp_ProjectList.SelectedIndexChanged += drpProjectList_SelectedIndexChanged;
            // 
            // btn_DeleteProject
            // 
            btn_DeleteProject.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            btn_DeleteProject.ForeColor = System.Drawing.Color.Red;
            btn_DeleteProject.Location = new System.Drawing.Point(225, 59);
            btn_DeleteProject.Name = "btn_DeleteProject";
            btn_DeleteProject.Size = new System.Drawing.Size(75, 25);
            btn_DeleteProject.Style.ForeColor = System.Drawing.Color.Red;
            btn_DeleteProject.TabIndex = 76;
            btn_DeleteProject.Text = "Delete";
            btn_DeleteProject.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_DeleteProject, "Delete the currently selected animation project");
            btn_DeleteProject.Click += btn_DeleteProject_Click;
            // 
            // mtbx_FramesBetween
            // 
            mtbx_FramesBetween.ForeColor = System.Drawing.SystemColors.WindowText;
            mtbx_FramesBetween.HideTrailingZeros = true;
            mtbx_FramesBetween.Location = new System.Drawing.Point(1017, 156);
            mtbx_FramesBetween.MaxLength = 4;
            mtbx_FramesBetween.MaxValue = 5000D;
            mtbx_FramesBetween.MinValue = 1D;
            mtbx_FramesBetween.Name = "mtbx_FramesBetween";
            mtbx_FramesBetween.Size = new System.Drawing.Size(52, 23);
            mtbx_FramesBetween.Style.FocusBorderColor = System.Drawing.Color.FromArgb(0, 120, 215);
            mtbx_FramesBetween.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            mtbx_FramesBetween.TabIndex = 75;
            mtbx_FramesBetween.Text = "1";
            mtbx_FramesBetween.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(mtbx_FramesBetween, "Frame Between (1-5,000)");
            mtbx_FramesBetween.Value = 1D;
            mtbx_FramesBetween.TextChanged += mtbx_FramesBetween_TextChanged;
            mtbx_FramesBetween.Enter += mtbx_FramesBetween_Enter;
            // 
            // mtbx_LookingRollingAngle
            // 
            mtbx_LookingRollingAngle.ForeColor = System.Drawing.SystemColors.WindowText;
            mtbx_LookingRollingAngle.HideTrailingZeros = true;
            mtbx_LookingRollingAngle.Location = new System.Drawing.Point(867, 156);
            mtbx_LookingRollingAngle.MaxLength = 3;
            mtbx_LookingRollingAngle.MaxValue = 360D;
            mtbx_LookingRollingAngle.MinValue = 1D;
            mtbx_LookingRollingAngle.Name = "mtbx_LookingRollingAngle";
            mtbx_LookingRollingAngle.Size = new System.Drawing.Size(43, 23);
            mtbx_LookingRollingAngle.Style.FocusBorderColor = System.Drawing.Color.FromArgb(0, 120, 215);
            mtbx_LookingRollingAngle.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            mtbx_LookingRollingAngle.TabIndex = 73;
            mtbx_LookingRollingAngle.Text = "1";
            mtbx_LookingRollingAngle.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(mtbx_LookingRollingAngle, "Looking/Rolling Angle (1-360)");
            mtbx_LookingRollingAngle.Value = 1D;
            mtbx_LookingRollingAngle.TextAlignChanged += mtbx_LookingRollingAngle_TextChanged;
            mtbx_LookingRollingAngle.Enter += mtbx_LookingRollingAngle_Enter;
            // 
            // mtbx_SlidingWalkingCount
            // 
            mtbx_SlidingWalkingCount.ForeColor = System.Drawing.SystemColors.WindowText;
            mtbx_SlidingWalkingCount.HideTrailingZeros = true;
            mtbx_SlidingWalkingCount.Location = new System.Drawing.Point(867, 131);
            mtbx_SlidingWalkingCount.MaxLength = 5;
            mtbx_SlidingWalkingCount.MaxValue = 10000D;
            mtbx_SlidingWalkingCount.MinValue = 1D;
            mtbx_SlidingWalkingCount.Name = "mtbx_SlidingWalkingCount";
            mtbx_SlidingWalkingCount.Size = new System.Drawing.Size(89, 23);
            mtbx_SlidingWalkingCount.Style.FocusBorderColor = System.Drawing.Color.FromArgb(0, 120, 215);
            mtbx_SlidingWalkingCount.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            mtbx_SlidingWalkingCount.TabIndex = 72;
            mtbx_SlidingWalkingCount.Text = "1";
            mtbx_SlidingWalkingCount.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(mtbx_SlidingWalkingCount, "Sliding/Walking Count (1-10,000)");
            mtbx_SlidingWalkingCount.Value = 1D;
            mtbx_SlidingWalkingCount.TextChanged += mtbx_SlidingWalkingCount_TextChanged;
            mtbx_SlidingWalkingCount.Enter += mtbx_SlidingWalkingCount_Enter;
            // 
            // mtbx_FarPlane
            // 
            mtbx_FarPlane.BackColor = System.Drawing.Color.Black;
            mtbx_FarPlane.Font = new System.Drawing.Font("Segoe UI", 26F);
            mtbx_FarPlane.ForeColor = System.Drawing.Color.White;
            mtbx_FarPlane.HideTrailingZeros = true;
            mtbx_FarPlane.Location = new System.Drawing.Point(1110, 76);
            mtbx_FarPlane.MaxLength = 5;
            mtbx_FarPlane.MaxValue = 10000D;
            mtbx_FarPlane.MinValue = 0D;
            mtbx_FarPlane.Name = "mtbx_FarPlane";
            mtbx_FarPlane.Size = new System.Drawing.Size(165, 54);
            mtbx_FarPlane.Style.BackColor = System.Drawing.Color.Black;
            mtbx_FarPlane.Style.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            mtbx_FarPlane.Style.NegativeForeColor = System.Drawing.Color.White;
            mtbx_FarPlane.Style.PositiveForeColor = System.Drawing.Color.White;
            mtbx_FarPlane.Style.ZeroForeColor = System.Drawing.Color.White;
            mtbx_FarPlane.TabIndex = 71;
            mtbx_FarPlane.Text = "0";
            mtbx_FarPlane.ThemeName = "Edit the far Plane Setting (0-10,000)";
            mtbx_FarPlane.Enter += mtbx_FarPlane_Enter;
            mtbx_FarPlane.KeyUp += mtbx_FrameCount_KeyUp;
            // 
            // mtbx_FrameCount
            // 
            mtbx_FrameCount.BackColor = System.Drawing.Color.Black;
            mtbx_FrameCount.Font = new System.Drawing.Font("Segoe UI", 26F);
            mtbx_FrameCount.ForeColor = System.Drawing.Color.White;
            mtbx_FrameCount.HideTrailingZeros = true;
            mtbx_FrameCount.Location = new System.Drawing.Point(710, 75);
            mtbx_FrameCount.MaxLength = 6;
            mtbx_FrameCount.MaxValue = 100000D;
            mtbx_FrameCount.MinValue = 0D;
            mtbx_FrameCount.Name = "mtbx_FrameCount";
            mtbx_FrameCount.Size = new System.Drawing.Size(155, 54);
            mtbx_FrameCount.Style.BackColor = System.Drawing.Color.Black;
            mtbx_FrameCount.Style.DisabledBackColor = System.Drawing.Color.Black;
            mtbx_FrameCount.Style.DisabledBorderColor = System.Drawing.Color.Blue;
            mtbx_FrameCount.Style.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            mtbx_FrameCount.Style.NegativeForeColor = System.Drawing.Color.White;
            mtbx_FrameCount.Style.PositiveForeColor = System.Drawing.Color.White;
            mtbx_FrameCount.Style.ZeroForeColor = System.Drawing.Color.White;
            mtbx_FrameCount.TabIndex = 0;
            mtbx_FrameCount.Text = "0";
            mtbx_FrameCount.ThemeName = "";
            toolTip1.SetToolTip(mtbx_FrameCount, "The current total frame count of the project.");
            mtbx_FrameCount.KeyUp += mtbx_FrameCount_KeyUp;
            // 
            // tbx_AnimationName
            // 
            tbx_AnimationName.BeforeTouchSize = new System.Drawing.Size(478, 276);
            tbx_AnimationName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            tbx_AnimationName.Location = new System.Drawing.Point(321, 29);
            tbx_AnimationName.Name = "tbx_AnimationName";
            tbx_AnimationName.Size = new System.Drawing.Size(370, 23);
            tbx_AnimationName.TabIndex = 68;
            tbx_AnimationName.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(tbx_AnimationName, "Edit the name of the selected animation project");
            tbx_AnimationName.TextChanged += tbx_AnimationName_TextChanged;
            tbx_AnimationName.Leave += tbx_AnimationName_Leave;
            // 
            // tbx_ProjectNotes
            // 
            tbx_ProjectNotes.BeforeTouchSize = new System.Drawing.Size(478, 276);
            tbx_ProjectNotes.Location = new System.Drawing.Point(385, 118);
            tbx_ProjectNotes.Multiline = true;
            tbx_ProjectNotes.Name = "tbx_ProjectNotes";
            tbx_ProjectNotes.Size = new System.Drawing.Size(306, 40);
            tbx_ProjectNotes.TabIndex = 66;
            tbx_ProjectNotes.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(tbx_ProjectNotes, "Notes for the selected animation project");
            // 
            // btn_SaveCurrentProject
            // 
            btn_SaveCurrentProject.AllowWrapText = true;
            btn_SaveCurrentProject.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            btn_SaveCurrentProject.ForeColor = System.Drawing.Color.Green;
            btn_SaveCurrentProject.Location = new System.Drawing.Point(103, 60);
            btn_SaveCurrentProject.Name = "btn_SaveCurrentProject";
            btn_SaveCurrentProject.Size = new System.Drawing.Size(75, 25);
            btn_SaveCurrentProject.Style.ForeColor = System.Drawing.Color.Green;
            btn_SaveCurrentProject.TabIndex = 65;
            btn_SaveCurrentProject.Text = "Update";
            btn_SaveCurrentProject.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_SaveCurrentProject, "Update the Selected Project");
            btn_SaveCurrentProject.Click += btn_SaveCurrentProject_Click;
            // 
            // lbl_60FPSTimeCalc
            // 
            lbl_60FPSTimeCalc.BackColor = System.Drawing.Color.Transparent;
            lbl_60FPSTimeCalc.Font = new System.Drawing.Font("Segoe UI", 15F);
            lbl_60FPSTimeCalc.ForeColor = System.Drawing.Color.White;
            lbl_60FPSTimeCalc.Location = new System.Drawing.Point(996, 101);
            lbl_60FPSTimeCalc.Name = "lbl_60FPSTimeCalc";
            lbl_60FPSTimeCalc.Size = new System.Drawing.Size(60, 28);
            lbl_60FPSTimeCalc.TabIndex = 63;
            lbl_60FPSTimeCalc.Text = "00:00";
            lbl_60FPSTimeCalc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl_60FPSTimeCalc.ThemeName = "HighContrastTheme";
            // 
            // lbl_30FPSTimeCalc
            // 
            lbl_30FPSTimeCalc.BackColor = System.Drawing.Color.Transparent;
            lbl_30FPSTimeCalc.Font = new System.Drawing.Font("Segoe UI", 15F);
            lbl_30FPSTimeCalc.ForeColor = System.Drawing.Color.White;
            lbl_30FPSTimeCalc.Location = new System.Drawing.Point(916, 100);
            lbl_30FPSTimeCalc.Name = "lbl_30FPSTimeCalc";
            lbl_30FPSTimeCalc.Size = new System.Drawing.Size(60, 28);
            lbl_30FPSTimeCalc.TabIndex = 62;
            lbl_30FPSTimeCalc.Text = "00:00";
            lbl_30FPSTimeCalc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl_30FPSTimeCalc.ThemeName = "HighContrastTheme";
            // 
            // autoLabel12
            // 
            autoLabel12.BackColor = System.Drawing.Color.Transparent;
            autoLabel12.ForeColor = System.Drawing.Color.White;
            autoLabel12.Location = new System.Drawing.Point(919, 161);
            autoLabel12.Name = "autoLabel12";
            autoLabel12.Size = new System.Drawing.Size(96, 15);
            autoLabel12.TabIndex = 61;
            autoLabel12.Text = "Frames Between:";
            autoLabel12.ThemeName = "HighContrastTheme";
            // 
            // autoLabel10
            // 
            autoLabel10.BackColor = System.Drawing.Color.Transparent;
            autoLabel10.ForeColor = System.Drawing.Color.White;
            autoLabel10.Location = new System.Drawing.Point(1108, 59);
            autoLabel10.Name = "autoLabel10";
            autoLabel10.Size = new System.Drawing.Size(58, 15);
            autoLabel10.TabIndex = 59;
            autoLabel10.Text = "Far Plane:";
            autoLabel10.ThemeName = "HighContrastTheme";
            // 
            // lbl_ProjectAsOfDateTime
            // 
            lbl_ProjectAsOfDateTime.BackColor = System.Drawing.Color.Transparent;
            lbl_ProjectAsOfDateTime.ForeColor = System.Drawing.Color.White;
            lbl_ProjectAsOfDateTime.Location = new System.Drawing.Point(320, 162);
            lbl_ProjectAsOfDateTime.Name = "lbl_ProjectAsOfDateTime";
            lbl_ProjectAsOfDateTime.Size = new System.Drawing.Size(105, 15);
            lbl_ProjectAsOfDateTime.TabIndex = 58;
            lbl_ProjectAsOfDateTime.Text = "Project Last Saved:";
            lbl_ProjectAsOfDateTime.ThemeName = "HighContrastTheme";
            // 
            // autoLabel9
            // 
            autoLabel9.BackColor = System.Drawing.Color.Transparent;
            autoLabel9.ForeColor = System.Drawing.Color.White;
            autoLabel9.Location = new System.Drawing.Point(996, 86);
            autoLabel9.Name = "autoLabel9";
            autoLabel9.Size = new System.Drawing.Size(49, 15);
            autoLabel9.TabIndex = 57;
            autoLabel9.Text = "@ 60fps";
            autoLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            autoLabel9.ThemeName = "HighContrastTheme";
            // 
            // autoLabel8
            // 
            autoLabel8.BackColor = System.Drawing.Color.Transparent;
            autoLabel8.ForeColor = System.Drawing.Color.White;
            autoLabel8.Location = new System.Drawing.Point(917, 85);
            autoLabel8.Name = "autoLabel8";
            autoLabel8.Size = new System.Drawing.Size(49, 15);
            autoLabel8.TabIndex = 56;
            autoLabel8.Text = "@ 30fps";
            autoLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            autoLabel8.ThemeName = "HighContrastTheme";
            // 
            // autoLabel7
            // 
            autoLabel7.BackColor = System.Drawing.Color.Transparent;
            autoLabel7.ForeColor = System.Drawing.Color.White;
            autoLabel7.Location = new System.Drawing.Point(900, 63);
            autoLabel7.Name = "autoLabel7";
            autoLabel7.Size = new System.Drawing.Size(170, 15);
            autoLabel7.TabIndex = 55;
            autoLabel7.Text = "Est. Animation Length (mm:ss)";
            autoLabel7.ThemeName = "HighContrastTheme";
            // 
            // autoLabel6
            // 
            autoLabel6.BackColor = System.Drawing.Color.Transparent;
            autoLabel6.ForeColor = System.Drawing.Color.White;
            autoLabel6.Location = new System.Drawing.Point(707, 160);
            autoLabel6.Name = "autoLabel6";
            autoLabel6.Size = new System.Drawing.Size(155, 15);
            autoLabel6.TabIndex = 54;
            autoLabel6.Text = "Looking/Rolling Step Angle:";
            autoLabel6.ThemeName = "HighContrastTheme";
            // 
            // autoLabel5
            // 
            autoLabel5.BackColor = System.Drawing.Color.Transparent;
            autoLabel5.ForeColor = System.Drawing.Color.White;
            autoLabel5.Location = new System.Drawing.Point(707, 136);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new System.Drawing.Size(156, 15);
            autoLabel5.TabIndex = 53;
            autoLabel5.Text = "Sliding/Walking Step Count:";
            autoLabel5.ThemeName = "HighContrastTheme";
            // 
            // autoLabel4
            // 
            autoLabel4.BackColor = System.Drawing.Color.Transparent;
            autoLabel4.ForeColor = System.Drawing.Color.White;
            autoLabel4.Location = new System.Drawing.Point(705, 57);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new System.Drawing.Size(112, 15);
            autoLabel4.TabIndex = 52;
            autoLabel4.Text = "Total Frames Count:";
            autoLabel4.ThemeName = "HighContrastTheme";
            // 
            // autoLabel3
            // 
            autoLabel3.AutoSize = false;
            autoLabel3.BackColor = System.Drawing.Color.Transparent;
            autoLabel3.ForeColor = System.Drawing.Color.White;
            autoLabel3.Location = new System.Drawing.Point(330, 119);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new System.Drawing.Size(51, 34);
            autoLabel3.TabIndex = 51;
            autoLabel3.Text = "Project Notes:";
            autoLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            autoLabel3.ThemeName = "HighContrastTheme";
            // 
            // autoLabel2
            // 
            autoLabel2.BackColor = System.Drawing.Color.Transparent;
            autoLabel2.ForeColor = System.Drawing.Color.White;
            autoLabel2.Location = new System.Drawing.Point(320, 12);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new System.Drawing.Size(82, 15);
            autoLabel2.TabIndex = 50;
            autoLabel2.Text = "Project Name:";
            autoLabel2.ThemeName = "HighContrastTheme";
            // 
            // autoLabel1
            // 
            autoLabel1.BackColor = System.Drawing.Color.Transparent;
            autoLabel1.ForeColor = System.Drawing.Color.White;
            autoLabel1.Location = new System.Drawing.Point(17, 12);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new System.Drawing.Size(111, 15);
            autoLabel1.TabIndex = 49;
            autoLabel1.Text = "Animation Projects:";
            autoLabel1.ThemeName = "HighContrastTheme";
            // 
            // btn_DisableCapture
            // 
            btn_DisableCapture.BackColor = System.Drawing.Color.Firebrick;
            btn_DisableCapture.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            btn_DisableCapture.Location = new System.Drawing.Point(158, 134);
            btn_DisableCapture.Name = "btn_DisableCapture";
            btn_DisableCapture.Size = new System.Drawing.Size(142, 40);
            btn_DisableCapture.Style.BackColor = System.Drawing.Color.Firebrick;
            btn_DisableCapture.TabIndex = 48;
            btn_DisableCapture.Text = "Disable Capture";
            btn_DisableCapture.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_DisableCapture, "Disable Keyframe Move Captures");
            btn_DisableCapture.UseVisualStyleBackColor = false;
            btn_DisableCapture.Click += btn_DisableCapture_Click;
            // 
            // btn_EnableCapture
            // 
            btn_EnableCapture.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            btn_EnableCapture.Location = new System.Drawing.Point(18, 134);
            btn_EnableCapture.Name = "btn_EnableCapture";
            btn_EnableCapture.Size = new System.Drawing.Size(133, 40);
            btn_EnableCapture.Style.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
            btn_EnableCapture.TabIndex = 47;
            btn_EnableCapture.Text = "Enable Capture";
            btn_EnableCapture.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_EnableCapture, "Enable Keyframe Move Captures");
            btn_EnableCapture.Click += btn_EnableCapture_Click;
            // 
            // btn_NewProject
            // 
            btn_NewProject.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            btn_NewProject.Location = new System.Drawing.Point(19, 60);
            btn_NewProject.Name = "btn_NewProject";
            btn_NewProject.Size = new System.Drawing.Size(75, 25);
            btn_NewProject.TabIndex = 45;
            btn_NewProject.Text = "New";
            btn_NewProject.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_NewProject, "Prepare the application for a new animation project");
            btn_NewProject.Click += btn_NewProject_Click;
            // 
            // label48
            // 
            label48.BackColor = System.Drawing.Color.Transparent;
            label48.Font = new System.Drawing.Font("Segoe UI", 8F);
            label48.ForeColor = System.Drawing.Color.White;
            label48.Location = new System.Drawing.Point(1215, 53);
            label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label48.Name = "label48";
            label48.Size = new System.Drawing.Size(57, 13);
            label48.TabIndex = 40;
            label48.Text = "2/24/2025";
            label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_ApplicationMainTitle
            // 
            lbl_ApplicationMainTitle.AutoSize = true;
            lbl_ApplicationMainTitle.BackColor = System.Drawing.Color.Transparent;
            lbl_ApplicationMainTitle.Font = new System.Drawing.Font("Times New Roman", 29F, System.Drawing.FontStyle.Bold);
            lbl_ApplicationMainTitle.ForeColor = System.Drawing.Color.White;
            lbl_ApplicationMainTitle.Location = new System.Drawing.Point(697, 8);
            lbl_ApplicationMainTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_ApplicationMainTitle.Name = "lbl_ApplicationMainTitle";
            lbl_ApplicationMainTitle.Size = new System.Drawing.Size(582, 44);
            lbl_ApplicationMainTitle.TabIndex = 30;
            lbl_ApplicationMainTitle.Text = "Mandelbulb3D Animation Copilot";
            lbl_ApplicationMainTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            toolTip1.SetToolTip(lbl_ApplicationMainTitle, "A Mandelbulb3D animation helper application by Patrick C. Cook. Click for About.");
            lbl_ApplicationMainTitle.Click += lbl_ApplicationMainTitle_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lbl_ShiftIndicator);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(lbl_LastKeyEvent);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(383, 34);
            panel1.TabIndex = 14;
            // 
            // lbl_ShiftIndicator
            // 
            lbl_ShiftIndicator.AutoSize = true;
            lbl_ShiftIndicator.BackColor = System.Drawing.Color.DarkGreen;
            lbl_ShiftIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_ShiftIndicator.ForeColor = System.Drawing.Color.Yellow;
            lbl_ShiftIndicator.Location = new System.Drawing.Point(139, 2);
            lbl_ShiftIndicator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_ShiftIndicator.Name = "lbl_ShiftIndicator";
            lbl_ShiftIndicator.Size = new System.Drawing.Size(75, 25);
            lbl_ShiftIndicator.TabIndex = 14;
            lbl_ShiftIndicator.Text = "SHIFT";
            lbl_ShiftIndicator.Visible = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(lbl_KeyframeStackLineChars);
            panel2.Controls.Add(label31);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(lbl_SavedFilePathName);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Margin = new System.Windows.Forms.Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(888, 34);
            panel2.TabIndex = 0;
            // 
            // lbl_KeyframeStackLineChars
            // 
            lbl_KeyframeStackLineChars.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lbl_KeyframeStackLineChars.ForeColor = System.Drawing.Color.White;
            lbl_KeyframeStackLineChars.Location = new System.Drawing.Point(245, 17);
            lbl_KeyframeStackLineChars.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_KeyframeStackLineChars.Name = "lbl_KeyframeStackLineChars";
            lbl_KeyframeStackLineChars.Size = new System.Drawing.Size(63, 15);
            lbl_KeyframeStackLineChars.TabIndex = 29;
            lbl_KeyframeStackLineChars.Text = "LineChars";
            lbl_KeyframeStackLineChars.ThemeName = "HighContrastTheme";
            // 
            // label31
            // 
            label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label31.ForeColor = System.Drawing.Color.White;
            label31.Location = new System.Drawing.Point(150, 17);
            label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(97, 15);
            label31.TabIndex = 28;
            label31.Text = "Keyframe Types:";
            label31.ThemeName = "HighContrastTheme";
            // 
            // lbl_MB3D_AppRun_Warn
            // 
            lbl_MB3D_AppRun_Warn.AutoSize = false;
            lbl_MB3D_AppRun_Warn.BackColor = System.Drawing.Color.Yellow;
            lbl_MB3D_AppRun_Warn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            lbl_MB3D_AppRun_Warn.ForeColor = System.Drawing.Color.Red;
            lbl_MB3D_AppRun_Warn.Location = new System.Drawing.Point(681, 17);
            lbl_MB3D_AppRun_Warn.Name = "lbl_MB3D_AppRun_Warn";
            lbl_MB3D_AppRun_Warn.Size = new System.Drawing.Size(213, 19);
            lbl_MB3D_AppRun_Warn.TabIndex = 30;
            lbl_MB3D_AppRun_Warn.Text = "Mandelbulb3D Application Not Detected";
            lbl_MB3D_AppRun_Warn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbl_MB3D_AppRun_Warn.ThemeName = "";
            lbl_MB3D_AppRun_Warn.ThemeStyle.BackColor = System.Drawing.Color.Yellow;
            lbl_MB3D_AppRun_Warn.ThemeStyle.ForeColor = System.Drawing.Color.Red;
            lbl_MB3D_AppRun_Warn.Visible = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pnl_MovesList);
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pnl_KeyStack);
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Size = new System.Drawing.Size(1276, 397);
            splitContainer1.SplitterDistance = 383;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 32;
            // 
            // pnl_MovesList
            // 
            pnl_MovesList.Controls.Add(btn_ShowKeyLegendWindow);
            pnl_MovesList.Controls.Add(panel3);
            pnl_MovesList.Dock = System.Windows.Forms.DockStyle.Fill;
            pnl_MovesList.Location = new System.Drawing.Point(0, 34);
            pnl_MovesList.Margin = new System.Windows.Forms.Padding(4);
            pnl_MovesList.Name = "pnl_MovesList";
            pnl_MovesList.Padding = new System.Windows.Forms.Padding(6);
            pnl_MovesList.Size = new System.Drawing.Size(383, 363);
            pnl_MovesList.TabIndex = 15;
            // 
            // btn_ShowKeyLegendWindow
            // 
            btn_ShowKeyLegendWindow.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btn_ShowKeyLegendWindow.Location = new System.Drawing.Point(108, 329);
            btn_ShowKeyLegendWindow.Margin = new System.Windows.Forms.Padding(4);
            btn_ShowKeyLegendWindow.Name = "btn_ShowKeyLegendWindow";
            btn_ShowKeyLegendWindow.Size = new System.Drawing.Size(164, 26);
            btn_ShowKeyLegendWindow.TabIndex = 42;
            btn_ShowKeyLegendWindow.Text = "Show Key Legend";
            btn_ShowKeyLegendWindow.ThemeName = "HighContrastTheme";
            btn_ShowKeyLegendWindow.UseVisualStyleBackColor = true;
            btn_ShowKeyLegendWindow.Click += btn_ShowKeyLegendWindow_Click;
            // 
            // panel3
            // 
            panel3.BackColor = System.Drawing.Color.Transparent;
            panel3.Controls.Add(lbl_MovesList);
            panel3.Controls.Add(panel5);
            panel3.Location = new System.Drawing.Point(6, 6);
            panel3.Margin = new System.Windows.Forms.Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(377, 315);
            panel3.TabIndex = 11;
            // 
            // lbl_MovesList
            // 
            lbl_MovesList.AutoSize = false;
            lbl_MovesList.Dock = System.Windows.Forms.DockStyle.Fill;
            lbl_MovesList.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_MovesList.ForeColor = System.Drawing.Color.White;
            lbl_MovesList.Location = new System.Drawing.Point(0, 0);
            lbl_MovesList.Name = "lbl_MovesList";
            lbl_MovesList.Size = new System.Drawing.Size(377, 259);
            lbl_MovesList.TabIndex = 15;
            lbl_MovesList.ThemeName = "HighContrastTheme";
            lbl_MovesList.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            // 
            // panel5
            // 
            panel5.BackColor = System.Drawing.Color.Transparent;
            panel5.Controls.Add(nup_AutoMoveQuantity);
            panel5.Controls.Add(btn_InsertAutoMove);
            panel5.Controls.Add(cbx_EnableAutoMove);
            panel5.Controls.Add(cbx_AutoMoveShift);
            panel5.Controls.Add(label14);
            panel5.Controls.Add(label13);
            panel5.Controls.Add(drp_AutoLastMove);
            panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel5.Location = new System.Drawing.Point(0, 259);
            panel5.Margin = new System.Windows.Forms.Padding(4);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(377, 56);
            panel5.TabIndex = 13;
            // 
            // nup_AutoMoveQuantity
            // 
            nup_AutoMoveQuantity.BeforeTouchSize = new System.Drawing.Size(55, 23);
            nup_AutoMoveQuantity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            nup_AutoMoveQuantity.Location = new System.Drawing.Point(78, 26);
            nup_AutoMoveQuantity.Margin = new System.Windows.Forms.Padding(4);
            nup_AutoMoveQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nup_AutoMoveQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nup_AutoMoveQuantity.Name = "nup_AutoMoveQuantity";
            nup_AutoMoveQuantity.Size = new System.Drawing.Size(55, 23);
            nup_AutoMoveQuantity.TabIndex = 43;
            nup_AutoMoveQuantity.ThemeName = "HighContrastTheme";
            nup_AutoMoveQuantity.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            toolTip1.SetToolTip(nup_AutoMoveQuantity, "Edit Frames Between value of selected keyframe");
            nup_AutoMoveQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btn_InsertAutoMove
            // 
            btn_InsertAutoMove.AllowWrapText = true;
            btn_InsertAutoMove.Enabled = false;
            btn_InsertAutoMove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btn_InsertAutoMove.Location = new System.Drawing.Point(282, 10);
            btn_InsertAutoMove.Margin = new System.Windows.Forms.Padding(4);
            btn_InsertAutoMove.Name = "btn_InsertAutoMove";
            btn_InsertAutoMove.Size = new System.Drawing.Size(87, 40);
            btn_InsertAutoMove.TabIndex = 37;
            btn_InsertAutoMove.Text = "Insert Auto Move";
            btn_InsertAutoMove.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_InsertAutoMove, "Manually insert a configured Auto Move");
            btn_InsertAutoMove.UseVisualStyleBackColor = true;
            btn_InsertAutoMove.Click += btn_InsertAutoMove_Click;
            // 
            // cbx_EnableAutoMove
            // 
            cbx_EnableAutoMove.AccessibilityEnabled = true;
            cbx_EnableAutoMove.AutoSize = true;
            cbx_EnableAutoMove.BeforeTouchSize = new System.Drawing.Size(121, 18);
            cbx_EnableAutoMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cbx_EnableAutoMove.ForeColor = System.Drawing.Color.White;
            cbx_EnableAutoMove.Location = new System.Drawing.Point(145, 15);
            cbx_EnableAutoMove.Margin = new System.Windows.Forms.Padding(4);
            cbx_EnableAutoMove.Name = "cbx_EnableAutoMove";
            cbx_EnableAutoMove.Size = new System.Drawing.Size(121, 18);
            cbx_EnableAutoMove.TabIndex = 36;
            cbx_EnableAutoMove.Text = "Enable Auto Move";
            cbx_EnableAutoMove.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(cbx_EnableAutoMove, "Check to Enable Keyframe Auto Move");
            cbx_EnableAutoMove.CheckedChanged += cbx_EnableAutoMove_CheckedChanged;
            // 
            // cbx_AutoMoveShift
            // 
            cbx_AutoMoveShift.AccessibilityEnabled = true;
            cbx_AutoMoveShift.AutoSize = true;
            cbx_AutoMoveShift.BeforeTouchSize = new System.Drawing.Size(92, 18);
            cbx_AutoMoveShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cbx_AutoMoveShift.ForeColor = System.Drawing.Color.White;
            cbx_AutoMoveShift.Location = new System.Drawing.Point(145, 34);
            cbx_AutoMoveShift.Margin = new System.Windows.Forms.Padding(4);
            cbx_AutoMoveShift.Name = "cbx_AutoMoveShift";
            cbx_AutoMoveShift.Size = new System.Drawing.Size(92, 18);
            cbx_AutoMoveShift.TabIndex = 35;
            cbx_AutoMoveShift.Text = "Set Key Shift";
            cbx_AutoMoveShift.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(cbx_AutoMoveShift, "Check to apply Shift to Auto Move");
            // 
            // label14
            // 
            label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label14.ForeColor = System.Drawing.Color.White;
            label14.Location = new System.Drawing.Point(76, 9);
            label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(51, 15);
            label14.TabIndex = 33;
            label14.Text = "Quanity:";
            label14.ThemeName = "HighContrastTheme";
            // 
            // label13
            // 
            label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label13.ForeColor = System.Drawing.Color.White;
            label13.Location = new System.Drawing.Point(5, 8);
            label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(67, 15);
            label13.TabIndex = 32;
            label13.Text = "Auto Move:";
            label13.ThemeName = "HighContrastTheme";
            // 
            // drp_AutoLastMove
            // 
            drp_AutoLastMove.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            drp_AutoLastMove.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            drp_AutoLastMove.Location = new System.Drawing.Point(6, 27);
            drp_AutoLastMove.Margin = new System.Windows.Forms.Padding(4);
            drp_AutoLastMove.Name = "drp_AutoLastMove";
            drp_AutoLastMove.Size = new System.Drawing.Size(64, 21);
            drp_AutoLastMove.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            drp_AutoLastMove.TabIndex = 3;
            drp_AutoLastMove.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(drp_AutoLastMove, "Select a Keyframe Action to Auto Move");
            // 
            // pnl_KeyStack
            // 
            pnl_KeyStack.Controls.Add(panel14);
            pnl_KeyStack.Controls.Add(panel12);
            pnl_KeyStack.Dock = System.Windows.Forms.DockStyle.Fill;
            pnl_KeyStack.Location = new System.Drawing.Point(0, 34);
            pnl_KeyStack.Margin = new System.Windows.Forms.Padding(4);
            pnl_KeyStack.Name = "pnl_KeyStack";
            pnl_KeyStack.Padding = new System.Windows.Forms.Padding(6);
            pnl_KeyStack.Size = new System.Drawing.Size(888, 363);
            pnl_KeyStack.TabIndex = 1;
            // 
            // panel14
            // 
            panel14.Controls.Add(dgv_Keyframes_sf);
            panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            panel14.Location = new System.Drawing.Point(6, 6);
            panel14.Margin = new System.Windows.Forms.Padding(4);
            panel14.Name = "panel14";
            panel14.Size = new System.Drawing.Size(664, 351);
            panel14.TabIndex = 16;
            // 
            // dgv_Keyframes_sf
            // 
            dgv_Keyframes_sf.AccessibleName = "Table";
            dgv_Keyframes_sf.AutoGenerateColumns = false;
            dgv_Keyframes_sf.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            dgv_Keyframes_sf.Dock = System.Windows.Forms.DockStyle.Fill;
            dgv_Keyframes_sf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dgv_Keyframes_sf.Location = new System.Drawing.Point(0, 0);
            dgv_Keyframes_sf.Name = "dgv_Keyframes_sf";
            dgv_Keyframes_sf.RowHeight = 35;
            dgv_Keyframes_sf.Size = new System.Drawing.Size(664, 351);
            dgv_Keyframes_sf.Style.BorderColor = System.Drawing.Color.FromArgb(100, 100, 100);
            dgv_Keyframes_sf.Style.CheckBoxStyle.CheckedBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dgv_Keyframes_sf.Style.CheckBoxStyle.CheckedBorderColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dgv_Keyframes_sf.Style.CheckBoxStyle.IndeterminateBorderColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dgv_Keyframes_sf.Style.HyperlinkStyle.DefaultLinkColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dgv_Keyframes_sf.TabIndex = 2;
            dgv_Keyframes_sf.Text = "Keyframe Stack";
            dgv_Keyframes_sf.ThemeName = "HighContrastTheme";
            dgv_Keyframes_sf.SelectionChanged += dgv_Keyframes_sf_SelectionChanged;
            dgv_Keyframes_sf.CellCheckBoxClick += dgv_Keyframes_sf_CellCheckBoxClick;
            // 
            // panel12
            // 
            panel12.Controls.Add(grpManageKeyframes);
            panel12.Controls.Add(grpKeyframeActions);
            panel12.Dock = System.Windows.Forms.DockStyle.Right;
            panel12.Location = new System.Drawing.Point(670, 6);
            panel12.Margin = new System.Windows.Forms.Padding(4);
            panel12.Name = "panel12";
            panel12.Size = new System.Drawing.Size(212, 351);
            panel12.TabIndex = 15;
            // 
            // grpManageKeyframes
            // 
            grpManageKeyframes.AllowDrop = true;
            grpManageKeyframes.BackColor = System.Drawing.Color.Transparent;
            grpManageKeyframes.CausesValidation = false;
            grpManageKeyframes.Controls.Add(btn_ManageKeyframeCommandGo);
            grpManageKeyframes.Controls.Add(drpKeyframeCommands);
            grpManageKeyframes.Controls.Add(btn_DeleteKeyframe);
            grpManageKeyframes.Controls.Add(lbl_KeyframesRange_Start);
            grpManageKeyframes.Controls.Add(num_EndDeleteKeyframe);
            grpManageKeyframes.Controls.Add(lbl_KeyframesRange_End);
            grpManageKeyframes.Controls.Add(num_StartDeleteKeyframe);
            grpManageKeyframes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            grpManageKeyframes.ForeColor = System.Drawing.Color.White;
            grpManageKeyframes.Location = new System.Drawing.Point(10, 220);
            grpManageKeyframes.Margin = new System.Windows.Forms.Padding(4);
            grpManageKeyframes.Name = "grpManageKeyframes";
            grpManageKeyframes.Padding = new System.Windows.Forms.Padding(4);
            grpManageKeyframes.Size = new System.Drawing.Size(190, 127);
            grpManageKeyframes.TabIndex = 25;
            grpManageKeyframes.TabStop = false;
            grpManageKeyframes.Text = "Manage Keyframes";
            // 
            // btn_ManageKeyframeCommandGo
            // 
            btn_ManageKeyframeCommandGo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btn_ManageKeyframeCommandGo.Location = new System.Drawing.Point(147, 91);
            btn_ManageKeyframeCommandGo.Margin = new System.Windows.Forms.Padding(4);
            btn_ManageKeyframeCommandGo.Name = "btn_ManageKeyframeCommandGo";
            btn_ManageKeyframeCommandGo.Size = new System.Drawing.Size(35, 26);
            btn_ManageKeyframeCommandGo.TabIndex = 24;
            btn_ManageKeyframeCommandGo.Text = "Go";
            btn_ManageKeyframeCommandGo.ThemeName = "HighContrastTheme";
            btn_ManageKeyframeCommandGo.UseVisualStyleBackColor = true;
            btn_ManageKeyframeCommandGo.Click += btn_ManageKeyframeCommandGo_Click;
            // 
            // drpKeyframeCommands
            // 
            drpKeyframeCommands.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            drpKeyframeCommands.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            drpKeyframeCommands.Location = new System.Drawing.Point(7, 92);
            drpKeyframeCommands.Margin = new System.Windows.Forms.Padding(4);
            drpKeyframeCommands.MaxDropDownItems = 8;
            drpKeyframeCommands.Name = "drpKeyframeCommands";
            drpKeyframeCommands.Size = new System.Drawing.Size(135, 23);
            drpKeyframeCommands.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            drpKeyframeCommands.TabIndex = 23;
            drpKeyframeCommands.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(drpKeyframeCommands, "Select a Manage Keyframe command");
            drpKeyframeCommands.Watermark = "Select Command";
            // 
            // btn_DeleteKeyframe
            // 
            btn_DeleteKeyframe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btn_DeleteKeyframe.ForeColor = System.Drawing.Color.Red;
            btn_DeleteKeyframe.Location = new System.Drawing.Point(8, 23);
            btn_DeleteKeyframe.Margin = new System.Windows.Forms.Padding(4);
            btn_DeleteKeyframe.Name = "btn_DeleteKeyframe";
            btn_DeleteKeyframe.Size = new System.Drawing.Size(174, 26);
            btn_DeleteKeyframe.Style.ForeColor = System.Drawing.Color.Red;
            btn_DeleteKeyframe.TabIndex = 14;
            btn_DeleteKeyframe.Text = "Delete Seleted Keyframe";
            btn_DeleteKeyframe.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_DeleteKeyframe, "Delete selected keyframe");
            btn_DeleteKeyframe.UseVisualStyleBackColor = true;
            btn_DeleteKeyframe.Click += btn_DeleteKeyframe_Click;
            // 
            // lbl_KeyframesRange_Start
            // 
            lbl_KeyframesRange_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lbl_KeyframesRange_Start.Location = new System.Drawing.Point(9, 63);
            lbl_KeyframesRange_Start.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_KeyframesRange_Start.Name = "lbl_KeyframesRange_Start";
            lbl_KeyframesRange_Start.Size = new System.Drawing.Size(17, 13);
            lbl_KeyframesRange_Start.TabIndex = 21;
            lbl_KeyframesRange_Start.Text = "S:";
            lbl_KeyframesRange_Start.Click += lbl_KeyframesRange_Start_Click;
            // 
            // num_EndDeleteKeyframe
            // 
            num_EndDeleteKeyframe.BeforeTouchSize = new System.Drawing.Size(57, 23);
            num_EndDeleteKeyframe.Location = new System.Drawing.Point(125, 58);
            num_EndDeleteKeyframe.Margin = new System.Windows.Forms.Padding(4);
            num_EndDeleteKeyframe.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            num_EndDeleteKeyframe.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_EndDeleteKeyframe.Name = "num_EndDeleteKeyframe";
            num_EndDeleteKeyframe.Size = new System.Drawing.Size(57, 23);
            num_EndDeleteKeyframe.TabIndex = 20;
            num_EndDeleteKeyframe.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(num_EndDeleteKeyframe, "Edit ending keyframe number of keyframe range");
            num_EndDeleteKeyframe.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lbl_KeyframesRange_End
            // 
            lbl_KeyframesRange_End.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lbl_KeyframesRange_End.Location = new System.Drawing.Point(108, 63);
            lbl_KeyframesRange_End.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_KeyframesRange_End.Name = "lbl_KeyframesRange_End";
            lbl_KeyframesRange_End.Size = new System.Drawing.Size(17, 13);
            lbl_KeyframesRange_End.TabIndex = 22;
            lbl_KeyframesRange_End.Text = "E:";
            lbl_KeyframesRange_End.Click += label51_Click;
            // 
            // num_StartDeleteKeyframe
            // 
            num_StartDeleteKeyframe.BeforeTouchSize = new System.Drawing.Size(57, 23);
            num_StartDeleteKeyframe.Location = new System.Drawing.Point(29, 58);
            num_StartDeleteKeyframe.Margin = new System.Windows.Forms.Padding(4);
            num_StartDeleteKeyframe.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            num_StartDeleteKeyframe.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_StartDeleteKeyframe.Name = "num_StartDeleteKeyframe";
            num_StartDeleteKeyframe.Size = new System.Drawing.Size(57, 23);
            num_StartDeleteKeyframe.TabIndex = 19;
            num_StartDeleteKeyframe.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(num_StartDeleteKeyframe, "Edit starting keyframe number of keyframe range");
            num_StartDeleteKeyframe.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // grpKeyframeActions
            // 
            grpKeyframeActions.BackColor = System.Drawing.Color.Transparent;
            grpKeyframeActions.CausesValidation = false;
            grpKeyframeActions.Controls.Add(drp_KeyframeActions);
            grpKeyframeActions.Controls.Add(num_SendKeyStepAngleCount);
            grpKeyframeActions.Controls.Add(btn_KeyframeAction_Delete);
            grpKeyframeActions.Controls.Add(label43);
            grpKeyframeActions.Controls.Add(num_SendKeyQuantity);
            grpKeyframeActions.Controls.Add(tbx_SendKeyChar);
            grpKeyframeActions.Controls.Add(label44);
            grpKeyframeActions.Controls.Add(label42);
            grpKeyframeActions.Controls.Add(label41);
            grpKeyframeActions.Controls.Add(tbx_KeyframeAction_Name);
            grpKeyframeActions.Controls.Add(btn_KeyframeAction_Update);
            grpKeyframeActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            grpKeyframeActions.ForeColor = System.Drawing.Color.White;
            grpKeyframeActions.Location = new System.Drawing.Point(10, 1);
            grpKeyframeActions.Margin = new System.Windows.Forms.Padding(4);
            grpKeyframeActions.Name = "grpKeyframeActions";
            grpKeyframeActions.Padding = new System.Windows.Forms.Padding(4);
            grpKeyframeActions.Size = new System.Drawing.Size(190, 208);
            grpKeyframeActions.TabIndex = 24;
            grpKeyframeActions.TabStop = false;
            grpKeyframeActions.Text = "Keyframe Actions";
            // 
            // drp_KeyframeActions
            // 
            drp_KeyframeActions.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            drp_KeyframeActions.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            drp_KeyframeActions.Location = new System.Drawing.Point(10, 22);
            drp_KeyframeActions.Margin = new System.Windows.Forms.Padding(4);
            drp_KeyframeActions.MaxDropDownItems = 8;
            drp_KeyframeActions.Name = "drp_KeyframeActions";
            drp_KeyframeActions.Size = new System.Drawing.Size(171, 23);
            drp_KeyframeActions.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            drp_KeyframeActions.TabIndex = 2;
            drp_KeyframeActions.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(drp_KeyframeActions, "Select available Keyframe Action");
            drp_KeyframeActions.Watermark = "Select Keyframe Action";
            drp_KeyframeActions.SelectedIndexChanged += drp_KeyframeActions_SelectedIndexChanged;
            // 
            // num_SendKeyStepAngleCount
            // 
            num_SendKeyStepAngleCount.BeforeTouchSize = new System.Drawing.Size(68, 23);
            num_SendKeyStepAngleCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            num_SendKeyStepAngleCount.Location = new System.Drawing.Point(110, 124);
            num_SendKeyStepAngleCount.Margin = new System.Windows.Forms.Padding(4);
            num_SendKeyStepAngleCount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            num_SendKeyStepAngleCount.Name = "num_SendKeyStepAngleCount";
            num_SendKeyStepAngleCount.Size = new System.Drawing.Size(68, 23);
            num_SendKeyStepAngleCount.TabIndex = 23;
            num_SendKeyStepAngleCount.ThemeName = "HighContrastTheme";
            num_SendKeyStepAngleCount.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            toolTip1.SetToolTip(num_SendKeyStepAngleCount, "Edit Step Quantity");
            num_SendKeyStepAngleCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btn_KeyframeAction_Delete
            // 
            btn_KeyframeAction_Delete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btn_KeyframeAction_Delete.ForeColor = System.Drawing.Color.Red;
            btn_KeyframeAction_Delete.Location = new System.Drawing.Point(111, 167);
            btn_KeyframeAction_Delete.Margin = new System.Windows.Forms.Padding(4);
            btn_KeyframeAction_Delete.Name = "btn_KeyframeAction_Delete";
            btn_KeyframeAction_Delete.Size = new System.Drawing.Size(68, 26);
            btn_KeyframeAction_Delete.Style.ForeColor = System.Drawing.Color.Red;
            btn_KeyframeAction_Delete.TabIndex = 13;
            btn_KeyframeAction_Delete.Text = "Delete";
            btn_KeyframeAction_Delete.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_KeyframeAction_Delete, "Delete selected Keyframe Action");
            btn_KeyframeAction_Delete.UseVisualStyleBackColor = true;
            btn_KeyframeAction_Delete.Click += btn_KeyframeAction_Delete_Click;
            // 
            // label43
            // 
            label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label43.ForeColor = System.Drawing.Color.White;
            label43.Location = new System.Drawing.Point(9, 106);
            label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label43.Name = "label43";
            label43.Size = new System.Drawing.Size(82, 15);
            label43.TabIndex = 8;
            label43.Text = "Step Quantity:";
            // 
            // num_SendKeyQuantity
            // 
            num_SendKeyQuantity.BeforeTouchSize = new System.Drawing.Size(75, 23);
            num_SendKeyQuantity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            num_SendKeyQuantity.Location = new System.Drawing.Point(13, 124);
            num_SendKeyQuantity.Margin = new System.Windows.Forms.Padding(4);
            num_SendKeyQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            num_SendKeyQuantity.Name = "num_SendKeyQuantity";
            num_SendKeyQuantity.Size = new System.Drawing.Size(75, 23);
            num_SendKeyQuantity.TabIndex = 9;
            num_SendKeyQuantity.ThemeName = "HighContrastTheme";
            num_SendKeyQuantity.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            toolTip1.SetToolTip(num_SendKeyQuantity, "Edit Step Quantity");
            num_SendKeyQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // tbx_SendKeyChar
            // 
            tbx_SendKeyChar.BeforeTouchSize = new System.Drawing.Size(478, 276);
            tbx_SendKeyChar.Location = new System.Drawing.Point(122, 74);
            tbx_SendKeyChar.Margin = new System.Windows.Forms.Padding(4);
            tbx_SendKeyChar.Name = "tbx_SendKeyChar";
            tbx_SendKeyChar.ReadOnly = true;
            tbx_SendKeyChar.Size = new System.Drawing.Size(55, 21);
            tbx_SendKeyChar.TabIndex = 7;
            tbx_SendKeyChar.ThemeName = "HighContrastTheme";
            // 
            // label44
            // 
            label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label44.ForeColor = System.Drawing.Color.White;
            label44.Location = new System.Drawing.Point(106, 106);
            label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label44.Name = "label44";
            label44.Size = new System.Drawing.Size(69, 15);
            label44.TabIndex = 10;
            label44.Text = "Step/Angle:";
            label44.ThemeName = "HighContrastTheme";
            // 
            // label42
            // 
            label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label42.ForeColor = System.Drawing.Color.White;
            label42.Location = new System.Drawing.Point(118, 55);
            label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label42.Name = "label42";
            label42.Size = new System.Drawing.Size(63, 15);
            label42.TabIndex = 6;
            label42.Text = "Charactor:";
            label42.ThemeName = "HighContrastTheme";
            // 
            // label41
            // 
            label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label41.ForeColor = System.Drawing.Color.White;
            label41.Location = new System.Drawing.Point(9, 55);
            label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label41.Name = "label41";
            label41.Size = new System.Drawing.Size(80, 15);
            label41.TabIndex = 4;
            label41.Text = "Action Name:";
            label41.ThemeName = "HighContrastTheme";
            // 
            // tbx_KeyframeAction_Name
            // 
            tbx_KeyframeAction_Name.BeforeTouchSize = new System.Drawing.Size(478, 276);
            tbx_KeyframeAction_Name.Location = new System.Drawing.Point(13, 73);
            tbx_KeyframeAction_Name.Margin = new System.Windows.Forms.Padding(4);
            tbx_KeyframeAction_Name.Name = "tbx_KeyframeAction_Name";
            tbx_KeyframeAction_Name.ReadOnly = true;
            tbx_KeyframeAction_Name.Size = new System.Drawing.Size(98, 21);
            tbx_KeyframeAction_Name.TabIndex = 5;
            tbx_KeyframeAction_Name.ThemeName = "HighContrastTheme";
            // 
            // btn_KeyframeAction_Update
            // 
            btn_KeyframeAction_Update.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btn_KeyframeAction_Update.Location = new System.Drawing.Point(12, 167);
            btn_KeyframeAction_Update.Margin = new System.Windows.Forms.Padding(4);
            btn_KeyframeAction_Update.Name = "btn_KeyframeAction_Update";
            btn_KeyframeAction_Update.Size = new System.Drawing.Size(77, 26);
            btn_KeyframeAction_Update.TabIndex = 12;
            btn_KeyframeAction_Update.Text = "Update";
            btn_KeyframeAction_Update.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_KeyframeAction_Update, "Update selected Keyframe Action");
            btn_KeyframeAction_Update.UseVisualStyleBackColor = true;
            btn_KeyframeAction_Update.Click += btn_KeyframeAction_Update_Click;
            // 
            // tabControl1
            // 
            tabControl1.ActiveTabColor = System.Drawing.Color.Green;
            tabControl1.ActiveTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            tabControl1.BackColor = System.Drawing.Color.Black;
            tabControl1.BeforeTouchSize = new System.Drawing.Size(1290, 573);
            tabControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tabControl1.Controls.Add(page_AnimationCopilot);
            tabControl1.Controls.Add(page_MoveDesigner);
            tabControl1.Controls.Add(page_Utilities);
            tabControl1.Controls.Add(page_Library);
            tabControl1.Controls.Add(page_Admin);
            tabControl1.Controls.Add(page_About);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            tabControl1.InactiveTabColor = System.Drawing.Color.Silver;
            tabControl1.Location = new System.Drawing.Point(2, 186);
            tabControl1.Margin = new System.Windows.Forms.Padding(4);
            tabControl1.Name = "tabControl1";
            tabControl1.Size = new System.Drawing.Size(1290, 573);
            tabControl1.TabIndex = 33;
            tabControl1.TabPanelBackColor = System.Drawing.Color.Black;
            tabControl1.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.OneNoteStyleRenderer);
            tabControl1.TextAlignment = System.Drawing.StringAlignment.Near;
            tabControl1.ThemeName = "OneNoteStyleRenderer";
            tabControl1.ThemesEnabled = true;
            tabControl1.ThemeStyle.BorderFillColor = System.Drawing.Color.FromArgb(210, 210, 210);
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // page_AnimationCopilot
            // 
            page_AnimationCopilot.Controls.Add(panel8);
            page_AnimationCopilot.Controls.Add(panel7);
            page_AnimationCopilot.Controls.Add(pnl_Bottom);
            page_AnimationCopilot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            page_AnimationCopilot.Image = null;
            page_AnimationCopilot.ImageSize = new System.Drawing.Size(16, 16);
            page_AnimationCopilot.Location = new System.Drawing.Point(3, 30);
            page_AnimationCopilot.Margin = new System.Windows.Forms.Padding(4);
            page_AnimationCopilot.Name = "page_AnimationCopilot";
            page_AnimationCopilot.Padding = new System.Windows.Forms.Padding(4);
            page_AnimationCopilot.ShowCloseButton = true;
            page_AnimationCopilot.Size = new System.Drawing.Size(1284, 540);
            page_AnimationCopilot.TabIndex = 1;
            page_AnimationCopilot.Text = "     Animation Copilot     ";
            page_AnimationCopilot.ThemesEnabled = true;
            toolTip1.SetToolTip(page_AnimationCopilot, "Animation helper tools");
            // 
            // panel8
            // 
            panel8.Controls.Add(splitContainer1);
            panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            panel8.Location = new System.Drawing.Point(4, 79);
            panel8.Margin = new System.Windows.Forms.Padding(4);
            panel8.Name = "panel8";
            panel8.Size = new System.Drawing.Size(1276, 397);
            panel8.TabIndex = 34;
            // 
            // panel7
            // 
            panel7.Controls.Add(lbl_JTK_AppRun_Warn);
            panel7.Controls.Add(btn_ShowMoveSequenceInfo);
            panel7.Controls.Add(mtbx_NextKeyframeNumber);
            panel7.Controls.Add(lbl_MB3D_AppRun_Warn);
            panel7.Controls.Add(label46);
            panel7.Controls.Add(lbl_ProjectSavingIndicator);
            panel7.Controls.Add(btn_StartOver);
            panel7.Controls.Add(label45);
            panel7.Controls.Add(btn_RestorePointInfo);
            panel7.Controls.Add(lbl_BusyLabel);
            panel7.Controls.Add(btn_ClearRestorePoint);
            panel7.Controls.Add(btn_PerformRestorePoint);
            panel7.Controls.Add(lbl_MoveSequenceDesc);
            panel7.Controls.Add(btn_SetRestorePoint);
            panel7.Controls.Add(btn_UseImmediateSeq);
            panel7.Controls.Add(label22);
            panel7.Controls.Add(drp_UseSequenceList);
            panel7.Controls.Add(label6);
            panel7.Dock = System.Windows.Forms.DockStyle.Top;
            panel7.Location = new System.Drawing.Point(4, 4);
            panel7.Margin = new System.Windows.Forms.Padding(4);
            panel7.Name = "panel7";
            panel7.Size = new System.Drawing.Size(1276, 75);
            panel7.TabIndex = 33;
            // 
            // lbl_JTK_AppRun_Warn
            // 
            lbl_JTK_AppRun_Warn.AutoSize = false;
            lbl_JTK_AppRun_Warn.BackColor = System.Drawing.Color.Yellow;
            lbl_JTK_AppRun_Warn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            lbl_JTK_AppRun_Warn.ForeColor = System.Drawing.Color.Red;
            lbl_JTK_AppRun_Warn.Location = new System.Drawing.Point(681, 41);
            lbl_JTK_AppRun_Warn.Name = "lbl_JTK_AppRun_Warn";
            lbl_JTK_AppRun_Warn.Size = new System.Drawing.Size(213, 19);
            lbl_JTK_AppRun_Warn.TabIndex = 31;
            lbl_JTK_AppRun_Warn.Text = "JoyToKey Key Mapper Not Detected";
            lbl_JTK_AppRun_Warn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbl_JTK_AppRun_Warn.ThemeName = "";
            lbl_JTK_AppRun_Warn.ThemeStyle.BackColor = System.Drawing.Color.Yellow;
            lbl_JTK_AppRun_Warn.ThemeStyle.ForeColor = System.Drawing.Color.Red;
            lbl_JTK_AppRun_Warn.Visible = false;
            // 
            // btn_ShowMoveSequenceInfo
            // 
            btn_ShowMoveSequenceInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_ShowMoveSequenceInfo.Location = new System.Drawing.Point(280, 28);
            btn_ShowMoveSequenceInfo.Name = "btn_ShowMoveSequenceInfo";
            btn_ShowMoveSequenceInfo.Size = new System.Drawing.Size(25, 21);
            btn_ShowMoveSequenceInfo.TabIndex = 44;
            btn_ShowMoveSequenceInfo.Text = "?";
            btn_ShowMoveSequenceInfo.ThemeName = "HighContrastTheme";
            btn_ShowMoveSequenceInfo.Click += btn_ShowMoveSequenceInfo_Click;
            // 
            // mtbx_NextKeyframeNumber
            // 
            mtbx_NextKeyframeNumber.BackColor = System.Drawing.Color.Black;
            mtbx_NextKeyframeNumber.Font = new System.Drawing.Font("Segoe UI", 28F);
            mtbx_NextKeyframeNumber.ForeColor = System.Drawing.Color.White;
            mtbx_NextKeyframeNumber.HideTrailingZeros = true;
            mtbx_NextKeyframeNumber.Location = new System.Drawing.Point(532, 9);
            mtbx_NextKeyframeNumber.MaxLength = 5;
            mtbx_NextKeyframeNumber.MaxValue = 10000D;
            mtbx_NextKeyframeNumber.MinValue = 1D;
            mtbx_NextKeyframeNumber.Name = "mtbx_NextKeyframeNumber";
            mtbx_NextKeyframeNumber.Size = new System.Drawing.Size(106, 57);
            mtbx_NextKeyframeNumber.Style.BackColor = System.Drawing.Color.Black;
            mtbx_NextKeyframeNumber.Style.DisabledBackColor = System.Drawing.Color.Black;
            mtbx_NextKeyframeNumber.Style.DisabledBorderColor = System.Drawing.Color.Blue;
            mtbx_NextKeyframeNumber.Style.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            mtbx_NextKeyframeNumber.Style.NegativeForeColor = System.Drawing.Color.White;
            mtbx_NextKeyframeNumber.Style.PositiveForeColor = System.Drawing.Color.White;
            mtbx_NextKeyframeNumber.Style.ZeroForeColor = System.Drawing.Color.White;
            mtbx_NextKeyframeNumber.TabIndex = 43;
            mtbx_NextKeyframeNumber.Text = "1";
            mtbx_NextKeyframeNumber.ThemeName = "";
            toolTip1.SetToolTip(mtbx_NextKeyframeNumber, "View/Edit the Next Keyframe Number");
            mtbx_NextKeyframeNumber.Value = 1D;
            mtbx_NextKeyframeNumber.TextChanged += mtbx_NextKeyframeNumber_TextChanged;
            mtbx_NextKeyframeNumber.KeyUp += mtbx_NextKeyframeNumber_KeyUp;
            // 
            // label46
            // 
            label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label46.ForeColor = System.Drawing.Color.White;
            label46.Location = new System.Drawing.Point(467, 43);
            label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label46.Name = "label46";
            label46.Size = new System.Drawing.Size(55, 15);
            label46.TabIndex = 42;
            label46.Text = "Number:";
            label46.ThemeName = "HighContrastTheme";
            // 
            // label45
            // 
            label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label45.ForeColor = System.Drawing.Color.White;
            label45.Location = new System.Drawing.Point(467, 29);
            label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label45.Name = "label45";
            label45.Size = new System.Drawing.Size(59, 15);
            label45.TabIndex = 41;
            label45.Text = "Keyframe";
            label45.ThemeName = "HighContrastTheme";
            // 
            // lbl_BusyLabel
            // 
            lbl_BusyLabel.AutoSize = true;
            lbl_BusyLabel.BackColor = System.Drawing.Color.Firebrick;
            lbl_BusyLabel.Font = new System.Drawing.Font("Blackoak Std", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_BusyLabel.ForeColor = System.Drawing.Color.Yellow;
            lbl_BusyLabel.Location = new System.Drawing.Point(660, 14);
            lbl_BusyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_BusyLabel.Name = "lbl_BusyLabel";
            lbl_BusyLabel.Padding = new System.Windows.Forms.Padding(29, 8, 29, 5);
            lbl_BusyLabel.Size = new System.Drawing.Size(260, 49);
            lbl_BusyLabel.TabIndex = 15;
            lbl_BusyLabel.Text = "BUSY";
            lbl_BusyLabel.Visible = false;
            // 
            // lbl_MoveSequenceDesc
            // 
            lbl_MoveSequenceDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lbl_MoveSequenceDesc.ForeColor = System.Drawing.Color.White;
            lbl_MoveSequenceDesc.Location = new System.Drawing.Point(13, 55);
            lbl_MoveSequenceDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_MoveSequenceDesc.Name = "lbl_MoveSequenceDesc";
            lbl_MoveSequenceDesc.Size = new System.Drawing.Size(0, 15);
            lbl_MoveSequenceDesc.TabIndex = 40;
            lbl_MoveSequenceDesc.ThemeName = "HighContrastTheme";
            lbl_MoveSequenceDesc.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            // 
            // btn_UseImmediateSeq
            // 
            btn_UseImmediateSeq.AllowWrapText = true;
            btn_UseImmediateSeq.Enabled = false;
            btn_UseImmediateSeq.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btn_UseImmediateSeq.Location = new System.Drawing.Point(315, 28);
            btn_UseImmediateSeq.Margin = new System.Windows.Forms.Padding(4);
            btn_UseImmediateSeq.Name = "btn_UseImmediateSeq";
            btn_UseImmediateSeq.Size = new System.Drawing.Size(49, 21);
            btn_UseImmediateSeq.TabIndex = 32;
            btn_UseImmediateSeq.Text = "Apply";
            btn_UseImmediateSeq.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_UseImmediateSeq, "Immediatley apply the selected Move Sequence");
            btn_UseImmediateSeq.UseVisualStyleBackColor = true;
            btn_UseImmediateSeq.Click += btn_UseImmediateSeq_Click;
            // 
            // label22
            // 
            label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label22.ForeColor = System.Drawing.Color.White;
            label22.Location = new System.Drawing.Point(7, 9);
            label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(224, 15);
            label22.TabIndex = 31;
            label22.Text = "Move Sequences (See Move Designer):";
            label22.ThemeName = "HighContrastTheme";
            // 
            // drp_UseSequenceList
            // 
            drp_UseSequenceList.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            drp_UseSequenceList.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            drp_UseSequenceList.Location = new System.Drawing.Point(10, 28);
            drp_UseSequenceList.Margin = new System.Windows.Forms.Padding(4);
            drp_UseSequenceList.MaxDropDownItems = 12;
            drp_UseSequenceList.Name = "drp_UseSequenceList";
            drp_UseSequenceList.Size = new System.Drawing.Size(262, 21);
            drp_UseSequenceList.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            drp_UseSequenceList.TabIndex = 30;
            drp_UseSequenceList.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(drp_UseSequenceList, "Select a pre-made Move Sequence");
            drp_UseSequenceList.Watermark = "Select Move Sequence";
            drp_UseSequenceList.SelectedIndexChanged += drp_UseSequenceList_SelectedIndexChanged;
            // 
            // page_MoveDesigner
            // 
            page_MoveDesigner.Controls.Add(panel9);
            page_MoveDesigner.ForeColor = System.Drawing.Color.White;
            page_MoveDesigner.Image = null;
            page_MoveDesigner.ImageSize = new System.Drawing.Size(16, 16);
            page_MoveDesigner.Location = new System.Drawing.Point(3, 30);
            page_MoveDesigner.Margin = new System.Windows.Forms.Padding(4);
            page_MoveDesigner.Name = "page_MoveDesigner";
            page_MoveDesigner.Padding = new System.Windows.Forms.Padding(4);
            page_MoveDesigner.ShowCloseButton = true;
            page_MoveDesigner.Size = new System.Drawing.Size(1284, 540);
            page_MoveDesigner.TabIndex = 1;
            page_MoveDesigner.Text = "     Move Designer     ";
            page_MoveDesigner.ThemesEnabled = true;
            toolTip1.SetToolTip(page_MoveDesigner, "Design move sequences");
            // 
            // panel9
            // 
            panel9.BackColor = System.Drawing.Color.Transparent;
            panel9.Controls.Add(splitContainer_ManageSeq);
            panel9.Controls.Add(panel_ManageSeqTop);
            panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            panel9.Location = new System.Drawing.Point(4, 4);
            panel9.Margin = new System.Windows.Forms.Padding(4);
            panel9.Name = "panel9";
            panel9.Size = new System.Drawing.Size(1276, 532);
            panel9.TabIndex = 19;
            // 
            // splitContainer_ManageSeq
            // 
            splitContainer_ManageSeq.BackColor = System.Drawing.Color.Black;
            splitContainer_ManageSeq.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer_ManageSeq.Location = new System.Drawing.Point(0, 111);
            splitContainer_ManageSeq.Name = "splitContainer_ManageSeq";
            // 
            // splitContainer_ManageSeq.Panel1
            // 
            splitContainer_ManageSeq.Panel1.Controls.Add(dgv_ManageMoveSequence);
            splitContainer_ManageSeq.Panel1.Controls.Add(panel6);
            // 
            // splitContainer_ManageSeq.Panel2
            // 
            splitContainer_ManageSeq.Panel2.BackColor = System.Drawing.Color.Transparent;
            splitContainer_ManageSeq.Panel2.Controls.Add(panel4);
            splitContainer_ManageSeq.Size = new System.Drawing.Size(1276, 421);
            splitContainer_ManageSeq.SplitterDistance = 429;
            splitContainer_ManageSeq.TabIndex = 22;
            // 
            // dgv_ManageMoveSequence
            // 
            dgv_ManageMoveSequence.AccessibleName = "Table";
            dgv_ManageMoveSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            dgv_ManageMoveSequence.Location = new System.Drawing.Point(12, 0);
            dgv_ManageMoveSequence.Name = "dgv_ManageMoveSequence";
            dgv_ManageMoveSequence.Padding = new System.Windows.Forms.Padding(3);
            dgv_ManageMoveSequence.Size = new System.Drawing.Size(417, 421);
            dgv_ManageMoveSequence.Style.BorderColor = System.Drawing.Color.FromArgb(100, 100, 100);
            dgv_ManageMoveSequence.Style.CheckBoxStyle.CheckedBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dgv_ManageMoveSequence.Style.CheckBoxStyle.CheckedBorderColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dgv_ManageMoveSequence.Style.CheckBoxStyle.IndeterminateBorderColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dgv_ManageMoveSequence.Style.HyperlinkStyle.DefaultLinkColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dgv_ManageMoveSequence.TabIndex = 19;
            dgv_ManageMoveSequence.ThemeName = "HighContrastTheme";
            dgv_ManageMoveSequence.SelectionChanged += dgv_ManageMoveSequence_SelectionChanged;
            // 
            // panel6
            // 
            panel6.Dock = System.Windows.Forms.DockStyle.Left;
            panel6.Location = new System.Drawing.Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(12, 421);
            panel6.TabIndex = 20;
            // 
            // panel4
            // 
            panel4.Controls.Add(autoLabel17);
            panel4.Controls.Add(btn_ManageSeqAddStep);
            panel4.Controls.Add(lbl_ManageSeqFooterMsgArea);
            panel4.Controls.Add(btn_ManageSeqDeleteStep);
            panel4.Controls.Add(btn_ManageSeqUpdateStep);
            panel4.Controls.Add(drp_ManageSeqStepNameList);
            panel4.Controls.Add(num_ManageSeqSendKeyQty);
            panel4.Controls.Add(autoLabel19);
            panel4.Controls.Add(autoLabel18);
            panel4.Controls.Add(lbl_ManageSeqSelected);
            panel4.Controls.Add(autoLabel16);
            panel4.Dock = System.Windows.Forms.DockStyle.Left;
            panel4.Location = new System.Drawing.Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(405, 421);
            panel4.TabIndex = 21;
            // 
            // autoLabel17
            // 
            autoLabel17.AutoSize = false;
            autoLabel17.Location = new System.Drawing.Point(26, 118);
            autoLabel17.Name = "autoLabel17";
            autoLabel17.Size = new System.Drawing.Size(351, 67);
            autoLabel17.TabIndex = 36;
            autoLabel17.Text = resources.GetString("autoLabel17.Text");
            // 
            // btn_ManageSeqAddStep
            // 
            btn_ManageSeqAddStep.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_ManageSeqAddStep.Location = new System.Drawing.Point(28, 269);
            btn_ManageSeqAddStep.Name = "btn_ManageSeqAddStep";
            btn_ManageSeqAddStep.Size = new System.Drawing.Size(203, 33);
            btn_ManageSeqAddStep.TabIndex = 35;
            btn_ManageSeqAddStep.Text = "Add as New Move Step";
            btn_ManageSeqAddStep.ThemeName = "HighContrastTheme";
            btn_ManageSeqAddStep.Click += btn_ManageSeqAddStep_Click;
            // 
            // lbl_ManageSeqFooterMsgArea
            // 
            lbl_ManageSeqFooterMsgArea.AutoSize = false;
            lbl_ManageSeqFooterMsgArea.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_ManageSeqFooterMsgArea.Location = new System.Drawing.Point(28, 314);
            lbl_ManageSeqFooterMsgArea.Name = "lbl_ManageSeqFooterMsgArea";
            lbl_ManageSeqFooterMsgArea.Size = new System.Drawing.Size(345, 89);
            lbl_ManageSeqFooterMsgArea.TabIndex = 34;
            lbl_ManageSeqFooterMsgArea.ThemeName = "HighContrastTheme";
            lbl_ManageSeqFooterMsgArea.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            // 
            // btn_ManageSeqDeleteStep
            // 
            btn_ManageSeqDeleteStep.AllowWrapText = true;
            btn_ManageSeqDeleteStep.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_ManageSeqDeleteStep.ForeColor = System.Drawing.Color.Red;
            btn_ManageSeqDeleteStep.Location = new System.Drawing.Point(295, 196);
            btn_ManageSeqDeleteStep.Name = "btn_ManageSeqDeleteStep";
            btn_ManageSeqDeleteStep.Size = new System.Drawing.Size(78, 73);
            btn_ManageSeqDeleteStep.Style.ForeColor = System.Drawing.Color.Red;
            btn_ManageSeqDeleteStep.TabIndex = 33;
            btn_ManageSeqDeleteStep.Text = "Delete Selected Move Step";
            btn_ManageSeqDeleteStep.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_ManageSeqDeleteStep, "Delete the selected Move Step");
            btn_ManageSeqDeleteStep.Click += btn_ManageSeqDeleteStep_Click;
            // 
            // btn_ManageSeqUpdateStep
            // 
            btn_ManageSeqUpdateStep.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_ManageSeqUpdateStep.Location = new System.Drawing.Point(28, 196);
            btn_ManageSeqUpdateStep.Name = "btn_ManageSeqUpdateStep";
            btn_ManageSeqUpdateStep.Size = new System.Drawing.Size(203, 55);
            btn_ManageSeqUpdateStep.TabIndex = 32;
            btn_ManageSeqUpdateStep.Text = "Update Selected Move Step";
            btn_ManageSeqUpdateStep.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_ManageSeqUpdateStep, "Update the selected Move Step");
            btn_ManageSeqUpdateStep.Click += btn_ManageSeqUpdateStep_Click;
            // 
            // drp_ManageSeqStepNameList
            // 
            drp_ManageSeqStepNameList.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            drp_ManageSeqStepNameList.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            drp_ManageSeqStepNameList.Location = new System.Drawing.Point(98, 85);
            drp_ManageSeqStepNameList.Margin = new System.Windows.Forms.Padding(4);
            drp_ManageSeqStepNameList.MaxDropDownItems = 12;
            drp_ManageSeqStepNameList.Name = "drp_ManageSeqStepNameList";
            drp_ManageSeqStepNameList.Size = new System.Drawing.Size(87, 21);
            drp_ManageSeqStepNameList.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            drp_ManageSeqStepNameList.TabIndex = 31;
            drp_ManageSeqStepNameList.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(drp_ManageSeqStepNameList, "Select a pre-made Move Sequence");
            drp_ManageSeqStepNameList.Watermark = "Select Move Sequence";
            // 
            // num_ManageSeqSendKeyQty
            // 
            num_ManageSeqSendKeyQty.BeforeTouchSize = new System.Drawing.Size(73, 20);
            num_ManageSeqSendKeyQty.Location = new System.Drawing.Point(295, 86);
            num_ManageSeqSendKeyQty.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            num_ManageSeqSendKeyQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_ManageSeqSendKeyQty.Name = "num_ManageSeqSendKeyQty";
            num_ManageSeqSendKeyQty.Size = new System.Drawing.Size(73, 20);
            num_ManageSeqSendKeyQty.TabIndex = 24;
            num_ManageSeqSendKeyQty.ThemeName = "HighContrastTheme";
            num_ManageSeqSendKeyQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // autoLabel19
            // 
            autoLabel19.Location = new System.Drawing.Point(236, 90);
            autoLabel19.Name = "autoLabel19";
            autoLabel19.Size = new System.Drawing.Size(54, 13);
            autoLabel19.TabIndex = 23;
            autoLabel19.Text = "Send Qty:";
            autoLabel19.ThemeName = "HighContrastTheme";
            // 
            // autoLabel18
            // 
            autoLabel18.Location = new System.Drawing.Point(28, 90);
            autoLabel18.Name = "autoLabel18";
            autoLabel18.Size = new System.Drawing.Size(63, 13);
            autoLabel18.TabIndex = 22;
            autoLabel18.Text = "Step Name:";
            autoLabel18.ThemeName = "HighContrastTheme";
            // 
            // lbl_ManageSeqSelected
            // 
            lbl_ManageSeqSelected.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_ManageSeqSelected.Location = new System.Drawing.Point(17, 47);
            lbl_ManageSeqSelected.Name = "lbl_ManageSeqSelected";
            lbl_ManageSeqSelected.Size = new System.Drawing.Size(117, 21);
            lbl_ManageSeqSelected.TabIndex = 21;
            lbl_ManageSeqSelected.Text = "Selected Step:";
            lbl_ManageSeqSelected.ThemeName = "HighContrastTheme";
            // 
            // autoLabel16
            // 
            autoLabel16.Location = new System.Drawing.Point(9, 15);
            autoLabel16.Name = "autoLabel16";
            autoLabel16.Size = new System.Drawing.Size(140, 13);
            autoLabel16.TabIndex = 20;
            autoLabel16.Text = "Edit Move Sequence Steps:";
            autoLabel16.ThemeName = "HighContrastTheme";
            // 
            // panel_ManageSeqTop
            // 
            panel_ManageSeqTop.AutoSize = true;
            panel_ManageSeqTop.BackColor = System.Drawing.Color.Black;
            panel_ManageSeqTop.Controls.Add(btn_ManageSeqDeleteSequence);
            panel_ManageSeqTop.Controls.Add(tbx_SequenceDesc_Manage);
            panel_ManageSeqTop.Controls.Add(drp_ManageSeqMoveSequences);
            panel_ManageSeqTop.Controls.Add(label20);
            panel_ManageSeqTop.Controls.Add(autoLabel15);
            panel_ManageSeqTop.Controls.Add(label18);
            panel_ManageSeqTop.Controls.Add(label24);
            panel_ManageSeqTop.Dock = System.Windows.Forms.DockStyle.Top;
            panel_ManageSeqTop.ForeColor = System.Drawing.Color.White;
            panel_ManageSeqTop.Location = new System.Drawing.Point(0, 0);
            panel_ManageSeqTop.Name = "panel_ManageSeqTop";
            panel_ManageSeqTop.Size = new System.Drawing.Size(1276, 111);
            panel_ManageSeqTop.TabIndex = 22;
            // 
            // btn_ManageSeqDeleteSequence
            // 
            btn_ManageSeqDeleteSequence.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_ManageSeqDeleteSequence.ForeColor = System.Drawing.Color.Red;
            btn_ManageSeqDeleteSequence.Location = new System.Drawing.Point(669, 53);
            btn_ManageSeqDeleteSequence.Name = "btn_ManageSeqDeleteSequence";
            btn_ManageSeqDeleteSequence.Size = new System.Drawing.Size(143, 28);
            btn_ManageSeqDeleteSequence.Style.ForeColor = System.Drawing.Color.Red;
            btn_ManageSeqDeleteSequence.TabIndex = 34;
            btn_ManageSeqDeleteSequence.Text = "Delete Move Sequence";
            btn_ManageSeqDeleteSequence.ThemeName = "HighContrastTheme";
            btn_ManageSeqDeleteSequence.Click += btn_ManageSeqDeleteSequence_Click;
            // 
            // tbx_SequenceDesc_Manage
            // 
            tbx_SequenceDesc_Manage.BeforeTouchSize = new System.Drawing.Size(478, 276);
            tbx_SequenceDesc_Manage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            tbx_SequenceDesc_Manage.Location = new System.Drawing.Point(272, 55);
            tbx_SequenceDesc_Manage.Name = "tbx_SequenceDesc_Manage";
            tbx_SequenceDesc_Manage.ReadOnly = true;
            tbx_SequenceDesc_Manage.Size = new System.Drawing.Size(380, 23);
            tbx_SequenceDesc_Manage.TabIndex = 33;
            tbx_SequenceDesc_Manage.ThemeName = "HighContrastTheme";
            // 
            // drp_ManageSeqMoveSequences
            // 
            drp_ManageSeqMoveSequences.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            drp_ManageSeqMoveSequences.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            drp_ManageSeqMoveSequences.Location = new System.Drawing.Point(12, 56);
            drp_ManageSeqMoveSequences.Margin = new System.Windows.Forms.Padding(4);
            drp_ManageSeqMoveSequences.MaxDropDownItems = 20;
            drp_ManageSeqMoveSequences.Name = "drp_ManageSeqMoveSequences";
            drp_ManageSeqMoveSequences.Size = new System.Drawing.Size(238, 21);
            drp_ManageSeqMoveSequences.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            drp_ManageSeqMoveSequences.TabIndex = 32;
            drp_ManageSeqMoveSequences.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(drp_ManageSeqMoveSequences, "Select a pre-made Move Sequence");
            drp_ManageSeqMoveSequences.Watermark = "Select Move Sequence";
            drp_ManageSeqMoveSequences.SelectedIndexChanged += drp_ManageSeqMoveSequences_SelectedIndexChanged;
            // 
            // label20
            // 
            label20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label20.Location = new System.Drawing.Point(8, 7);
            label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(125, 21);
            label20.TabIndex = 12;
            label20.Text = "Move Designer";
            // 
            // autoLabel15
            // 
            autoLabel15.Location = new System.Drawing.Point(11, 93);
            autoLabel15.Margin = new System.Windows.Forms.Padding(5);
            autoLabel15.Name = "autoLabel15";
            autoLabel15.Size = new System.Drawing.Size(116, 13);
            autoLabel15.TabIndex = 20;
            autoLabel15.Text = "Move Sequence Steps";
            // 
            // label18
            // 
            label18.Location = new System.Drawing.Point(10, 37);
            label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(140, 13);
            label18.TabIndex = 7;
            label18.Text = "Available Move Sequences:";
            // 
            // label24
            // 
            label24.Location = new System.Drawing.Point(271, 38);
            label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(145, 13);
            label24.TabIndex = 17;
            label24.Text = "Move Sequence Description:";
            // 
            // page_Utilities
            // 
            page_Utilities.Controls.Add(panel_UtilitiesPage);
            page_Utilities.ForeColor = System.Drawing.Color.Black;
            page_Utilities.Image = null;
            page_Utilities.ImageSize = new System.Drawing.Size(16, 16);
            page_Utilities.Location = new System.Drawing.Point(3, 30);
            page_Utilities.Margin = new System.Windows.Forms.Padding(4);
            page_Utilities.Name = "page_Utilities";
            page_Utilities.ShowCloseButton = true;
            page_Utilities.Size = new System.Drawing.Size(1284, 540);
            page_Utilities.TabIndex = 2;
            page_Utilities.Text = "       Utilities         ";
            page_Utilities.ThemesEnabled = true;
            toolTip1.SetToolTip(page_Utilities, "Various utilities to assist with Mandlebulb3D animations");
            // 
            // panel_UtilitiesPage
            // 
            panel_UtilitiesPage.Controls.Add(btn_FarPlaneUpdater);
            panel_UtilitiesPage.Controls.Add(autoLabel20);
            panel_UtilitiesPage.Controls.Add(btn_LookLeftUpdater);
            panel_UtilitiesPage.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_UtilitiesPage.Location = new System.Drawing.Point(0, 0);
            panel_UtilitiesPage.Name = "panel_UtilitiesPage";
            panel_UtilitiesPage.Size = new System.Drawing.Size(1284, 540);
            panel_UtilitiesPage.TabIndex = 11;
            // 
            // btn_FarPlaneUpdater
            // 
            btn_FarPlaneUpdater.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_FarPlaneUpdater.Location = new System.Drawing.Point(20, 51);
            btn_FarPlaneUpdater.Name = "btn_FarPlaneUpdater";
            btn_FarPlaneUpdater.Size = new System.Drawing.Size(245, 28);
            btn_FarPlaneUpdater.TabIndex = 8;
            btn_FarPlaneUpdater.Text = "Far Plane Keyframe Updater";
            btn_FarPlaneUpdater.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_FarPlaneUpdater, "A utility that updates the Far Plane value of each keyframe of a Mandelbulb3D animation ");
            btn_FarPlaneUpdater.Click += btn_FarPlaneUpdater_Click;
            // 
            // autoLabel20
            // 
            autoLabel20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            autoLabel20.ForeColor = System.Drawing.Color.White;
            autoLabel20.Location = new System.Drawing.Point(9, 9);
            autoLabel20.Name = "autoLabel20";
            autoLabel20.Size = new System.Drawing.Size(70, 21);
            autoLabel20.TabIndex = 10;
            autoLabel20.Text = "Utilities";
            // 
            // btn_LookLeftUpdater
            // 
            btn_LookLeftUpdater.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_LookLeftUpdater.Location = new System.Drawing.Point(20, 100);
            btn_LookLeftUpdater.Name = "btn_LookLeftUpdater";
            btn_LookLeftUpdater.Size = new System.Drawing.Size(245, 28);
            btn_LookLeftUpdater.TabIndex = 9;
            btn_LookLeftUpdater.Text = "Look Left Keyframe Updater";
            btn_LookLeftUpdater.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_LookLeftUpdater, "A utility that updates the look orientation of each keyframe of a Mandelbulb3D animation ");
            btn_LookLeftUpdater.Click += btn_LookLeftUpdater_Click;
            // 
            // page_Library
            // 
            page_Library.Controls.Add(panel10);
            page_Library.Image = null;
            page_Library.ImageSize = new System.Drawing.Size(16, 16);
            page_Library.Location = new System.Drawing.Point(3, 30);
            page_Library.Margin = new System.Windows.Forms.Padding(4);
            page_Library.Name = "page_Library";
            page_Library.ShowCloseButton = true;
            page_Library.Size = new System.Drawing.Size(1284, 540);
            page_Library.TabIndex = 4;
            page_Library.Text = "     Mandelbulb3D Library     ";
            page_Library.ThemesEnabled = true;
            toolTip1.SetToolTip(page_Library, "Mandelbulb3D Project Library");
            // 
            // panel10
            // 
            panel10.Controls.Add(autoLabel23);
            panel10.Controls.Add(autoLabel21);
            panel10.Controls.Add(label10);
            panel10.Controls.Add(label40);
            panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            panel10.Location = new System.Drawing.Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new System.Drawing.Size(1284, 540);
            panel10.TabIndex = 3;
            // 
            // autoLabel23
            // 
            autoLabel23.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            autoLabel23.ForeColor = System.Drawing.Color.White;
            autoLabel23.Location = new System.Drawing.Point(10, 9);
            autoLabel23.Name = "autoLabel23";
            autoLabel23.Size = new System.Drawing.Size(182, 21);
            autoLabel23.TabIndex = 11;
            autoLabel23.Text = "Mandelbulb3D Library";
            // 
            // autoLabel21
            // 
            autoLabel21.AutoSize = false;
            autoLabel21.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            autoLabel21.ForeColor = System.Drawing.Color.White;
            autoLabel21.Location = new System.Drawing.Point(152, 202);
            autoLabel21.Name = "autoLabel21";
            autoLabel21.Size = new System.Drawing.Size(1000, 88);
            autoLabel21.TabIndex = 3;
            autoLabel21.Text = resources.GetString("autoLabel21.Text");
            autoLabel21.ThemeName = "HighContrastTheme";
            // 
            // label10
            // 
            label10.BackColor = System.Drawing.Color.Transparent;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label10.ForeColor = System.Drawing.Color.White;
            label10.Location = new System.Drawing.Point(145, 99);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(857, 39);
            label10.TabIndex = 0;
            label10.Text = "The Future Home of the Mandelbulb3D Project Library!";
            // 
            // label40
            // 
            label40.BackColor = System.Drawing.Color.Transparent;
            label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label40.ForeColor = System.Drawing.Color.White;
            label40.Location = new System.Drawing.Point(152, 155);
            label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label40.Name = "label40";
            label40.Size = new System.Drawing.Size(109, 26);
            label40.TabIndex = 1;
            label40.Text = "Overview:";
            // 
            // page_Admin
            // 
            page_Admin.Controls.Add(panel11);
            page_Admin.Image = null;
            page_Admin.ImageSize = new System.Drawing.Size(16, 16);
            page_Admin.Location = new System.Drawing.Point(3, 30);
            page_Admin.Margin = new System.Windows.Forms.Padding(4);
            page_Admin.Name = "page_Admin";
            page_Admin.ShowCloseButton = true;
            page_Admin.Size = new System.Drawing.Size(1284, 540);
            page_Admin.TabIndex = 3;
            page_Admin.Text = "        Admin        ";
            page_Admin.ThemesEnabled = true;
            toolTip1.SetToolTip(page_Admin, "Application administration tools");
            // 
            // panel11
            // 
            panel11.Controls.Add(groupBox2);
            panel11.Controls.Add(groupBox1);
            panel11.Controls.Add(autoLabel24);
            panel11.Controls.Add(gb_DBAdmin_Restore);
            panel11.Controls.Add(gb_DBAdmin_Backup);
            panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            panel11.Location = new System.Drawing.Point(0, 0);
            panel11.Name = "panel11";
            panel11.Size = new System.Drawing.Size(1284, 540);
            panel11.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btn_CreateSampleProject);
            groupBox2.Controls.Add(autoLabel35);
            groupBox2.ForeColor = System.Drawing.Color.White;
            groupBox2.Location = new System.Drawing.Point(724, 283);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(514, 238);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Create Sample Project";
            // 
            // btn_CreateSampleProject
            // 
            btn_CreateSampleProject.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_CreateSampleProject.Location = new System.Drawing.Point(140, 178);
            btn_CreateSampleProject.Margin = new System.Windows.Forms.Padding(4);
            btn_CreateSampleProject.Name = "btn_CreateSampleProject";
            btn_CreateSampleProject.Size = new System.Drawing.Size(218, 44);
            btn_CreateSampleProject.TabIndex = 15;
            btn_CreateSampleProject.Text = "Create Sample Animation Project";
            btn_CreateSampleProject.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_CreateSampleProject, "Create a sample animation project");
            btn_CreateSampleProject.UseVisualStyleBackColor = true;
            btn_CreateSampleProject.Click += btn_CreateSampleProject_Click;
            // 
            // autoLabel35
            // 
            autoLabel35.AutoSize = false;
            autoLabel35.BackColor = System.Drawing.Color.Black;
            autoLabel35.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            autoLabel35.Location = new System.Drawing.Point(13, 21);
            autoLabel35.Name = "autoLabel35";
            autoLabel35.Size = new System.Drawing.Size(489, 154);
            autoLabel35.TabIndex = 2;
            autoLabel35.Text = resources.GetString("autoLabel35.Text");
            autoLabel35.ThemeName = "HighContrastTheme";
            autoLabel35.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            autoLabel35.ThemeStyle.ForeColor = System.Drawing.Color.White;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_EraseAllDatabaseRecords_KeepMS);
            groupBox1.Controls.Add(autoLabel34);
            groupBox1.Controls.Add(btn_EraseAllDatabaseRecords);
            groupBox1.ForeColor = System.Drawing.Color.White;
            groupBox1.Location = new System.Drawing.Point(22, 283);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(491, 238);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Erase Database Records";
            // 
            // btn_EraseAllDatabaseRecords_KeepMS
            // 
            btn_EraseAllDatabaseRecords_KeepMS.AllowWrapText = true;
            btn_EraseAllDatabaseRecords_KeepMS.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_EraseAllDatabaseRecords_KeepMS.ForeColor = System.Drawing.Color.Red;
            btn_EraseAllDatabaseRecords_KeepMS.Location = new System.Drawing.Point(291, 178);
            btn_EraseAllDatabaseRecords_KeepMS.Name = "btn_EraseAllDatabaseRecords_KeepMS";
            btn_EraseAllDatabaseRecords_KeepMS.Size = new System.Drawing.Size(185, 44);
            btn_EraseAllDatabaseRecords_KeepMS.Style.ForeColor = System.Drawing.Color.Red;
            btn_EraseAllDatabaseRecords_KeepMS.TabIndex = 2;
            btn_EraseAllDatabaseRecords_KeepMS.Text = "Purge Database of All Records Except Move Sequences";
            btn_EraseAllDatabaseRecords_KeepMS.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_EraseAllDatabaseRecords_KeepMS, "Erase all database records but keep Move Sequence r5ecords");
            btn_EraseAllDatabaseRecords_KeepMS.Click += btn_EraseAllDatabaseRecords_KeepMS_Click;
            // 
            // autoLabel34
            // 
            autoLabel34.AutoSize = false;
            autoLabel34.BackColor = System.Drawing.Color.Black;
            autoLabel34.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            autoLabel34.Location = new System.Drawing.Point(9, 21);
            autoLabel34.Name = "autoLabel34";
            autoLabel34.Size = new System.Drawing.Size(467, 154);
            autoLabel34.TabIndex = 1;
            autoLabel34.Text = resources.GetString("autoLabel34.Text");
            autoLabel34.ThemeName = "HighContrastTheme";
            autoLabel34.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            autoLabel34.ThemeStyle.ForeColor = System.Drawing.Color.White;
            // 
            // btn_EraseAllDatabaseRecords
            // 
            btn_EraseAllDatabaseRecords.AllowWrapText = true;
            btn_EraseAllDatabaseRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_EraseAllDatabaseRecords.ForeColor = System.Drawing.Color.Red;
            btn_EraseAllDatabaseRecords.Location = new System.Drawing.Point(9, 178);
            btn_EraseAllDatabaseRecords.Name = "btn_EraseAllDatabaseRecords";
            btn_EraseAllDatabaseRecords.Size = new System.Drawing.Size(181, 44);
            btn_EraseAllDatabaseRecords.Style.ForeColor = System.Drawing.Color.Red;
            btn_EraseAllDatabaseRecords.TabIndex = 0;
            btn_EraseAllDatabaseRecords.Text = "Purge Database of All Records";
            btn_EraseAllDatabaseRecords.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_EraseAllDatabaseRecords, "Erase all database records");
            btn_EraseAllDatabaseRecords.Click += btn_EraseAllDatabaseRecords_Click;
            // 
            // autoLabel24
            // 
            autoLabel24.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            autoLabel24.ForeColor = System.Drawing.Color.White;
            autoLabel24.Location = new System.Drawing.Point(9, 7);
            autoLabel24.Name = "autoLabel24";
            autoLabel24.Size = new System.Drawing.Size(185, 21);
            autoLabel24.TabIndex = 12;
            autoLabel24.Text = "Copliot Administration";
            // 
            // gb_DBAdmin_Restore
            // 
            gb_DBAdmin_Restore.BackColor = System.Drawing.Color.Transparent;
            gb_DBAdmin_Restore.Controls.Add(btn_DBAdmin_RestoreDBFile);
            gb_DBAdmin_Restore.Controls.Add(tbx_DBAdmin_Restore_DBFolder);
            gb_DBAdmin_Restore.Controls.Add(label55);
            gb_DBAdmin_Restore.Controls.Add(btn_DBAdmin_Restore);
            gb_DBAdmin_Restore.ForeColor = System.Drawing.Color.White;
            gb_DBAdmin_Restore.Location = new System.Drawing.Point(22, 175);
            gb_DBAdmin_Restore.Margin = new System.Windows.Forms.Padding(4);
            gb_DBAdmin_Restore.Name = "gb_DBAdmin_Restore";
            gb_DBAdmin_Restore.Padding = new System.Windows.Forms.Padding(4);
            gb_DBAdmin_Restore.Size = new System.Drawing.Size(1216, 93);
            gb_DBAdmin_Restore.TabIndex = 1;
            gb_DBAdmin_Restore.TabStop = false;
            gb_DBAdmin_Restore.Text = "Database Restore";
            // 
            // btn_DBAdmin_RestoreDBFile
            // 
            btn_DBAdmin_RestoreDBFile.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_DBAdmin_RestoreDBFile.Location = new System.Drawing.Point(725, 38);
            btn_DBAdmin_RestoreDBFile.Margin = new System.Windows.Forms.Padding(4);
            btn_DBAdmin_RestoreDBFile.Name = "btn_DBAdmin_RestoreDBFile";
            btn_DBAdmin_RestoreDBFile.Size = new System.Drawing.Size(278, 26);
            btn_DBAdmin_RestoreDBFile.TabIndex = 14;
            btn_DBAdmin_RestoreDBFile.Text = "Select Database File to Restore";
            btn_DBAdmin_RestoreDBFile.ThemeName = "HighContrastTheme";
            btn_DBAdmin_RestoreDBFile.UseVisualStyleBackColor = true;
            btn_DBAdmin_RestoreDBFile.Click += btn_DBAdmin_RestoreDBFile_Click;
            // 
            // tbx_DBAdmin_Restore_DBFolder
            // 
            tbx_DBAdmin_Restore_DBFolder.BeforeTouchSize = new System.Drawing.Size(478, 276);
            tbx_DBAdmin_Restore_DBFolder.Location = new System.Drawing.Point(146, 43);
            tbx_DBAdmin_Restore_DBFolder.Margin = new System.Windows.Forms.Padding(4);
            tbx_DBAdmin_Restore_DBFolder.Name = "tbx_DBAdmin_Restore_DBFolder";
            tbx_DBAdmin_Restore_DBFolder.Size = new System.Drawing.Size(549, 20);
            tbx_DBAdmin_Restore_DBFolder.TabIndex = 13;
            tbx_DBAdmin_Restore_DBFolder.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(tbx_DBAdmin_Restore_DBFolder, "Enter or select the database file to Restore");
            // 
            // label55
            // 
            label55.Location = new System.Drawing.Point(9, 46);
            label55.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label55.Name = "label55";
            label55.Size = new System.Drawing.Size(128, 13);
            label55.TabIndex = 7;
            label55.Text = "Database Name && Folder:";
            // 
            // btn_DBAdmin_Restore
            // 
            btn_DBAdmin_Restore.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_DBAdmin_Restore.Location = new System.Drawing.Point(1031, 17);
            btn_DBAdmin_Restore.Margin = new System.Windows.Forms.Padding(4);
            btn_DBAdmin_Restore.Name = "btn_DBAdmin_Restore";
            btn_DBAdmin_Restore.Size = new System.Drawing.Size(164, 62);
            btn_DBAdmin_Restore.TabIndex = 0;
            btn_DBAdmin_Restore.Text = "Restore Database";
            btn_DBAdmin_Restore.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_DBAdmin_Restore, "Perform a restore of the database from the named file");
            btn_DBAdmin_Restore.UseVisualStyleBackColor = true;
            btn_DBAdmin_Restore.Click += btn_DBAdmin_Restore_Click;
            // 
            // gb_DBAdmin_Backup
            // 
            gb_DBAdmin_Backup.BackColor = System.Drawing.Color.Transparent;
            gb_DBAdmin_Backup.Controls.Add(lbl_DatabaseFileInUse);
            gb_DBAdmin_Backup.Controls.Add(autoLabel22);
            gb_DBAdmin_Backup.Controls.Add(label52);
            gb_DBAdmin_Backup.Controls.Add(tbx_DBAdmin_Backup_DBNewFileName);
            gb_DBAdmin_Backup.Controls.Add(label56);
            gb_DBAdmin_Backup.Controls.Add(btn_DBAdmin_BackupFolder);
            gb_DBAdmin_Backup.Controls.Add(tbx_DBAdmin_Backup_FolderName);
            gb_DBAdmin_Backup.Controls.Add(label53);
            gb_DBAdmin_Backup.Controls.Add(btn_DBAdmin_Backup);
            gb_DBAdmin_Backup.ForeColor = System.Drawing.Color.White;
            gb_DBAdmin_Backup.Location = new System.Drawing.Point(22, 41);
            gb_DBAdmin_Backup.Margin = new System.Windows.Forms.Padding(4);
            gb_DBAdmin_Backup.Name = "gb_DBAdmin_Backup";
            gb_DBAdmin_Backup.Padding = new System.Windows.Forms.Padding(4);
            gb_DBAdmin_Backup.Size = new System.Drawing.Size(1216, 126);
            gb_DBAdmin_Backup.TabIndex = 0;
            gb_DBAdmin_Backup.TabStop = false;
            gb_DBAdmin_Backup.Text = "Database Backup";
            // 
            // lbl_DatabaseFileInUse
            // 
            lbl_DatabaseFileInUse.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_DatabaseFileInUse.Location = new System.Drawing.Point(146, 18);
            lbl_DatabaseFileInUse.Name = "lbl_DatabaseFileInUse";
            lbl_DatabaseFileInUse.Size = new System.Drawing.Size(0, 25);
            lbl_DatabaseFileInUse.TabIndex = 11;
            // 
            // autoLabel22
            // 
            autoLabel22.Location = new System.Drawing.Point(30, 26);
            autoLabel22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            autoLabel22.Name = "autoLabel22";
            autoLabel22.Size = new System.Drawing.Size(109, 13);
            autoLabel22.TabIndex = 10;
            autoLabel22.Text = "Database File In Use:";
            // 
            // label52
            // 
            label52.Location = new System.Drawing.Point(41, 93);
            label52.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label52.Name = "label52";
            label52.Size = new System.Drawing.Size(98, 13);
            label52.TabIndex = 9;
            label52.Text = "Backup File Folder:";
            // 
            // tbx_DBAdmin_Backup_DBNewFileName
            // 
            tbx_DBAdmin_Backup_DBNewFileName.BeforeTouchSize = new System.Drawing.Size(478, 276);
            tbx_DBAdmin_Backup_DBNewFileName.Location = new System.Drawing.Point(146, 58);
            tbx_DBAdmin_Backup_DBNewFileName.Margin = new System.Windows.Forms.Padding(4);
            tbx_DBAdmin_Backup_DBNewFileName.Name = "tbx_DBAdmin_Backup_DBNewFileName";
            tbx_DBAdmin_Backup_DBNewFileName.Size = new System.Drawing.Size(263, 20);
            tbx_DBAdmin_Backup_DBNewFileName.TabIndex = 8;
            tbx_DBAdmin_Backup_DBNewFileName.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(tbx_DBAdmin_Backup_DBNewFileName, "Enter a name for the database backup file");
            // 
            // label56
            // 
            label56.Location = new System.Drawing.Point(42, 63);
            label56.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label56.Name = "label56";
            label56.Size = new System.Drawing.Size(97, 13);
            label56.TabIndex = 7;
            label56.Text = "Backup File Name:";
            // 
            // btn_DBAdmin_BackupFolder
            // 
            btn_DBAdmin_BackupFolder.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_DBAdmin_BackupFolder.Location = new System.Drawing.Point(725, 88);
            btn_DBAdmin_BackupFolder.Margin = new System.Windows.Forms.Padding(4);
            btn_DBAdmin_BackupFolder.Name = "btn_DBAdmin_BackupFolder";
            btn_DBAdmin_BackupFolder.Size = new System.Drawing.Size(278, 26);
            btn_DBAdmin_BackupFolder.TabIndex = 6;
            btn_DBAdmin_BackupFolder.Text = "Select Folder for the Database Backup File";
            btn_DBAdmin_BackupFolder.ThemeName = "HighContrastTheme";
            btn_DBAdmin_BackupFolder.UseVisualStyleBackColor = true;
            btn_DBAdmin_BackupFolder.Click += btn_DBAdmin_BackupFolder_Click;
            // 
            // tbx_DBAdmin_Backup_FolderName
            // 
            tbx_DBAdmin_Backup_FolderName.BeforeTouchSize = new System.Drawing.Size(478, 276);
            tbx_DBAdmin_Backup_FolderName.Location = new System.Drawing.Point(146, 91);
            tbx_DBAdmin_Backup_FolderName.Margin = new System.Windows.Forms.Padding(4);
            tbx_DBAdmin_Backup_FolderName.Name = "tbx_DBAdmin_Backup_FolderName";
            tbx_DBAdmin_Backup_FolderName.Size = new System.Drawing.Size(549, 20);
            tbx_DBAdmin_Backup_FolderName.TabIndex = 5;
            tbx_DBAdmin_Backup_FolderName.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(tbx_DBAdmin_Backup_FolderName, "Enter or select the folder for the database backup file");
            // 
            // label53
            // 
            label53.Location = new System.Drawing.Point(8, 96);
            label53.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label53.Name = "label53";
            label53.Size = new System.Drawing.Size(0, 13);
            label53.TabIndex = 4;
            // 
            // btn_DBAdmin_Backup
            // 
            btn_DBAdmin_Backup.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_DBAdmin_Backup.Location = new System.Drawing.Point(1031, 56);
            btn_DBAdmin_Backup.Margin = new System.Windows.Forms.Padding(4);
            btn_DBAdmin_Backup.Name = "btn_DBAdmin_Backup";
            btn_DBAdmin_Backup.Size = new System.Drawing.Size(164, 59);
            btn_DBAdmin_Backup.TabIndex = 0;
            btn_DBAdmin_Backup.Text = "Backup Database";
            btn_DBAdmin_Backup.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_DBAdmin_Backup, "Perform a backup of the database to the named file/folder");
            btn_DBAdmin_Backup.UseVisualStyleBackColor = true;
            btn_DBAdmin_Backup.Click += btn_DBAdmin_Backup_Click;
            // 
            // page_About
            // 
            page_About.Controls.Add(panel13);
            page_About.Image = null;
            page_About.ImageSize = new System.Drawing.Size(16, 16);
            page_About.Location = new System.Drawing.Point(3, 30);
            page_About.Name = "page_About";
            page_About.ShowCloseButton = true;
            page_About.Size = new System.Drawing.Size(1284, 540);
            page_About.TabIndex = 5;
            page_About.Text = "       About       ";
            page_About.ThemesEnabled = true;
            // 
            // panel13
            // 
            panel13.Controls.Add(btn_ErrorLogLocation);
            panel13.Controls.Add(btn_CopyLog);
            panel13.Controls.Add(btn_EraseLog);
            panel13.Controls.Add(autoLabel33);
            panel13.Controls.Add(tbx_ErrorLogContent);
            panel13.Controls.Add(ll_GithubRespository_About);
            panel13.Controls.Add(ll_PCGithubURL_About);
            panel13.Controls.Add(grp_Admin_JoytoKey);
            panel13.Controls.Add(autoLabel31);
            panel13.Controls.Add(autoLabel30);
            panel13.Controls.Add(autoLabel29);
            panel13.Controls.Add(autoLabel28);
            panel13.Controls.Add(label2);
            panel13.Controls.Add(autoLabel27);
            panel13.Controls.Add(autoLabel26);
            panel13.Controls.Add(autoLabel25);
            panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            panel13.Location = new System.Drawing.Point(0, 0);
            panel13.Name = "panel13";
            panel13.Size = new System.Drawing.Size(1284, 540);
            panel13.TabIndex = 0;
            // 
            // btn_ErrorLogLocation
            // 
            btn_ErrorLogLocation.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_ErrorLogLocation.ForeColor = System.Drawing.Color.White;
            btn_ErrorLogLocation.Location = new System.Drawing.Point(957, 509);
            btn_ErrorLogLocation.Name = "btn_ErrorLogLocation";
            btn_ErrorLogLocation.Size = new System.Drawing.Size(129, 18);
            btn_ErrorLogLocation.Style.ForeColor = System.Drawing.Color.White;
            btn_ErrorLogLocation.TabIndex = 92;
            btn_ErrorLogLocation.Text = "Error Log Location";
            btn_ErrorLogLocation.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_ErrorLogLocation, "Display the location of the Error Log file");
            btn_ErrorLogLocation.Click += btn_ErrorLogLocation_Click;
            // 
            // btn_CopyLog
            // 
            btn_CopyLog.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_CopyLog.ForeColor = System.Drawing.Color.White;
            btn_CopyLog.Location = new System.Drawing.Point(779, 509);
            btn_CopyLog.Name = "btn_CopyLog";
            btn_CopyLog.Size = new System.Drawing.Size(129, 18);
            btn_CopyLog.Style.ForeColor = System.Drawing.Color.White;
            btn_CopyLog.TabIndex = 91;
            btn_CopyLog.Text = "Copy Error Log Text";
            btn_CopyLog.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_CopyLog, "Copt the text of the Error Log to Windows Clipboard");
            btn_CopyLog.Click += btn_CopyLog_Click;
            // 
            // btn_EraseLog
            // 
            btn_EraseLog.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_EraseLog.ForeColor = System.Drawing.Color.Red;
            btn_EraseLog.Location = new System.Drawing.Point(1130, 509);
            btn_EraseLog.Name = "btn_EraseLog";
            btn_EraseLog.Size = new System.Drawing.Size(129, 18);
            btn_EraseLog.Style.ForeColor = System.Drawing.Color.Red;
            btn_EraseLog.TabIndex = 90;
            btn_EraseLog.Text = "Erase Error Log";
            btn_EraseLog.ThemeName = "HighContrastTheme";
            toolTip1.SetToolTip(btn_EraseLog, "Erase the content of the Error Log file");
            btn_EraseLog.Click += btn_EraseLog_Click;
            // 
            // autoLabel33
            // 
            autoLabel33.ForeColor = System.Drawing.Color.White;
            autoLabel33.Location = new System.Drawing.Point(778, 210);
            autoLabel33.Name = "autoLabel33";
            autoLabel33.Size = new System.Drawing.Size(53, 13);
            autoLabel33.TabIndex = 89;
            autoLabel33.Text = "Error Log:";
            autoLabel33.ThemeName = "HighContrastTheme";
            // 
            // tbx_ErrorLogContent
            // 
            tbx_ErrorLogContent.BackColor = System.Drawing.Color.Black;
            tbx_ErrorLogContent.BeforeTouchSize = new System.Drawing.Size(478, 276);
            tbx_ErrorLogContent.BorderColor = System.Drawing.Color.White;
            tbx_ErrorLogContent.ForeColor = System.Drawing.Color.White;
            tbx_ErrorLogContent.Location = new System.Drawing.Point(780, 227);
            tbx_ErrorLogContent.Multiline = true;
            tbx_ErrorLogContent.Name = "tbx_ErrorLogContent";
            tbx_ErrorLogContent.ReadOnly = true;
            tbx_ErrorLogContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            tbx_ErrorLogContent.Size = new System.Drawing.Size(478, 276);
            tbx_ErrorLogContent.TabIndex = 88;
            tbx_ErrorLogContent.Text = "No Log File Found";
            tbx_ErrorLogContent.ThemeName = "HighContrastTheme";
            // 
            // ll_GithubRespository_About
            // 
            ll_GithubRespository_About.ActiveLinkColor = System.Drawing.Color.White;
            ll_GithubRespository_About.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ll_GithubRespository_About.ForeColor = System.Drawing.Color.White;
            ll_GithubRespository_About.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            ll_GithubRespository_About.LinkColor = System.Drawing.Color.White;
            ll_GithubRespository_About.Location = new System.Drawing.Point(26, 373);
            ll_GithubRespository_About.Name = "ll_GithubRespository_About";
            ll_GithubRespository_About.Size = new System.Drawing.Size(325, 27);
            ll_GithubRespository_About.TabIndex = 87;
            ll_GithubRespository_About.Text = "The Copilot Project is located at Github.com";
            ll_GithubRespository_About.VisitedLinkColor = System.Drawing.Color.Yellow;
            ll_GithubRespository_About.LinkClicked += ll_GithubRespository_About_LinkClicked;
            // 
            // ll_PCGithubURL_About
            // 
            ll_PCGithubURL_About.ActiveLinkColor = System.Drawing.Color.White;
            ll_PCGithubURL_About.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ll_PCGithubURL_About.ForeColor = System.Drawing.Color.White;
            ll_PCGithubURL_About.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            ll_PCGithubURL_About.LinkColor = System.Drawing.Color.White;
            ll_PCGithubURL_About.Location = new System.Drawing.Point(26, 410);
            ll_PCGithubURL_About.Name = "ll_PCGithubURL_About";
            ll_PCGithubURL_About.Size = new System.Drawing.Size(414, 27);
            ll_PCGithubURL_About.TabIndex = 86;
            ll_PCGithubURL_About.Text = "The project support site is located at PatCook1.Github.io";
            ll_PCGithubURL_About.VisitedLinkColor = System.Drawing.Color.Yellow;
            ll_PCGithubURL_About.LinkClicked += ll_PCGithubURL_About_LinkClicked;
            // 
            // grp_Admin_JoytoKey
            // 
            grp_Admin_JoytoKey.Controls.Add(autoLabel32);
            grp_Admin_JoytoKey.Controls.Add(ll_JoyToKey_About);
            grp_Admin_JoytoKey.Controls.Add(lbl_Admin_JoyToKey_Loc);
            grp_Admin_JoytoKey.Controls.Add(lbl_Admin_JoyToKey_Intro);
            grp_Admin_JoytoKey.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            grp_Admin_JoytoKey.ForeColor = System.Drawing.Color.White;
            grp_Admin_JoytoKey.Location = new System.Drawing.Point(780, 15);
            grp_Admin_JoytoKey.Name = "grp_Admin_JoytoKey";
            grp_Admin_JoytoKey.Size = new System.Drawing.Size(478, 188);
            grp_Admin_JoytoKey.TabIndex = 22;
            grp_Admin_JoytoKey.TabStop = false;
            grp_Admin_JoytoKey.Text = "JoyToKey Mapping";
            // 
            // autoLabel32
            // 
            autoLabel32.AutoSize = false;
            autoLabel32.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            autoLabel32.Location = new System.Drawing.Point(11, 132);
            autoLabel32.Name = "autoLabel32";
            autoLabel32.Size = new System.Drawing.Size(451, 48);
            autoLabel32.TabIndex = 88;
            autoLabel32.Text = "The JoyToKey app mapping Configuration file is located in your installation folder and is named 'MB3D_JoyToKey.cfg'.";
            autoLabel32.ThemeName = "HighContrastTheme";
            autoLabel32.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            // 
            // ll_JoyToKey_About
            // 
            ll_JoyToKey_About.ActiveLinkColor = System.Drawing.Color.White;
            ll_JoyToKey_About.AutoSize = true;
            ll_JoyToKey_About.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ll_JoyToKey_About.ForeColor = System.Drawing.Color.White;
            ll_JoyToKey_About.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            ll_JoyToKey_About.LinkColor = System.Drawing.Color.White;
            ll_JoyToKey_About.Location = new System.Drawing.Point(299, 99);
            ll_JoyToKey_About.Name = "ll_JoyToKey_About";
            ll_JoyToKey_About.Size = new System.Drawing.Size(160, 21);
            ll_JoyToKey_About.TabIndex = 87;
            ll_JoyToKey_About.Text = "JoyToKey Key Mapper";
            ll_JoyToKey_About.VisitedLinkColor = System.Drawing.Color.Yellow;
            ll_JoyToKey_About.LinkClicked += ll_JoyToKey_About_LinkClicked;
            // 
            // lbl_Admin_JoyToKey_Loc
            // 
            lbl_Admin_JoyToKey_Loc.AutoSize = false;
            lbl_Admin_JoyToKey_Loc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lbl_Admin_JoyToKey_Loc.Location = new System.Drawing.Point(10, 99);
            lbl_Admin_JoyToKey_Loc.Name = "lbl_Admin_JoyToKey_Loc";
            lbl_Admin_JoyToKey_Loc.Size = new System.Drawing.Size(301, 21);
            lbl_Admin_JoyToKey_Loc.TabIndex = 1;
            lbl_Admin_JoyToKey_Loc.Text = "The JoyToKey app can be downloaded at:";
            lbl_Admin_JoyToKey_Loc.ThemeName = "HighContrastTheme";
            lbl_Admin_JoyToKey_Loc.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            // 
            // lbl_Admin_JoyToKey_Intro
            // 
            lbl_Admin_JoyToKey_Intro.AutoSize = false;
            lbl_Admin_JoyToKey_Intro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lbl_Admin_JoyToKey_Intro.Location = new System.Drawing.Point(10, 26);
            lbl_Admin_JoyToKey_Intro.Name = "lbl_Admin_JoyToKey_Intro";
            lbl_Admin_JoyToKey_Intro.Size = new System.Drawing.Size(462, 73);
            lbl_Admin_JoyToKey_Intro.TabIndex = 0;
            lbl_Admin_JoyToKey_Intro.Text = "The JoyToKey app provides mapping of a game controller or standard PC keyboard to the movement keys of the Mandelbulb3D Navigator.";
            lbl_Admin_JoyToKey_Intro.ThemeName = "HighContrastTheme";
            lbl_Admin_JoyToKey_Intro.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            // 
            // autoLabel31
            // 
            autoLabel31.AutoSize = false;
            autoLabel31.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            autoLabel31.ForeColor = System.Drawing.Color.White;
            autoLabel31.Location = new System.Drawing.Point(24, 251);
            autoLabel31.Name = "autoLabel31";
            autoLabel31.Size = new System.Drawing.Size(621, 52);
            autoLabel31.TabIndex = 21;
            autoLabel31.Text = "The various features of the Mandelbulb3D Animation Copilot facilitate creating Mandelbulb3D animations that are complex in movement as well as longer.";
            autoLabel31.ThemeName = "HighContrastTheme";
            autoLabel31.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            // 
            // autoLabel30
            // 
            autoLabel30.AutoSize = false;
            autoLabel30.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            autoLabel30.ForeColor = System.Drawing.Color.White;
            autoLabel30.Location = new System.Drawing.Point(24, 312);
            autoLabel30.Name = "autoLabel30";
            autoLabel30.Size = new System.Drawing.Size(587, 47);
            autoLabel30.TabIndex = 20;
            autoLabel30.Text = "This open source application was originally developed by, and is managed by, Patrick C. Cook.";
            autoLabel30.ThemeName = "HighContrastTheme";
            autoLabel30.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            // 
            // autoLabel29
            // 
            autoLabel29.AutoSize = false;
            autoLabel29.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            autoLabel29.ForeColor = System.Drawing.Color.White;
            autoLabel29.Location = new System.Drawing.Point(26, 189);
            autoLabel29.Name = "autoLabel29";
            autoLabel29.Size = new System.Drawing.Size(644, 48);
            autoLabel29.TabIndex = 19;
            autoLabel29.Text = "This Copilot facilitates reverting to earlier keyframes as well as modifying keyframe actions in the event that a Mandelbulb3D animation keyframe sequence needs to be corrected.";
            autoLabel29.ThemeName = "HighContrastTheme";
            autoLabel29.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            // 
            // autoLabel28
            // 
            autoLabel28.AutoSize = false;
            autoLabel28.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            autoLabel28.ForeColor = System.Drawing.Color.White;
            autoLabel28.Location = new System.Drawing.Point(26, 125);
            autoLabel28.Name = "autoLabel28";
            autoLabel28.Size = new System.Drawing.Size(607, 50);
            autoLabel28.TabIndex = 18;
            autoLabel28.Text = "This Copilot also automates keyframe creation with pre-designed move sequences and keyframe replication features.";
            autoLabel28.ThemeName = "HighContrastTheme";
            autoLabel28.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(511, 251);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(35, 13);
            label2.TabIndex = 17;
            label2.Text = "label2";
            // 
            // autoLabel27
            // 
            autoLabel27.AutoSize = false;
            autoLabel27.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            autoLabel27.ForeColor = System.Drawing.Color.White;
            autoLabel27.Location = new System.Drawing.Point(26, 42);
            autoLabel27.Name = "autoLabel27";
            autoLabel27.Size = new System.Drawing.Size(623, 73);
            autoLabel27.TabIndex = 15;
            autoLabel27.Text = resources.GetString("autoLabel27.Text");
            autoLabel27.ThemeName = "HighContrastTheme";
            autoLabel27.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            // 
            // autoLabel26
            // 
            autoLabel26.AutoSize = false;
            autoLabel26.Location = new System.Drawing.Point(93, 62);
            autoLabel26.Name = "autoLabel26";
            autoLabel26.Size = new System.Drawing.Size(394, 98);
            autoLabel26.TabIndex = 14;
            autoLabel26.Text = resources.GetString("autoLabel26.Text");
            // 
            // autoLabel25
            // 
            autoLabel25.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            autoLabel25.ForeColor = System.Drawing.Color.White;
            autoLabel25.Location = new System.Drawing.Point(9, 8);
            autoLabel25.Name = "autoLabel25";
            autoLabel25.Size = new System.Drawing.Size(352, 21);
            autoLabel25.TabIndex = 13;
            autoLabel25.Text = "About this Mandelbulb3D Animation Copilot";
            // 
            // openFileDialog_BackupFindFile
            // 
            openFileDialog_BackupFindFile.DefaultExt = "db";
            openFileDialog_BackupFindFile.FileName = "Database";
            openFileDialog_BackupFindFile.Filter = "Database Files|*.db|All Files|*.*";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStripEx1
            // 
            contextMenuStripEx1.MetroColor = System.Drawing.Color.FromArgb(204, 236, 249);
            contextMenuStripEx1.Name = "contextMenuStripEx1";
            contextMenuStripEx1.Size = new System.Drawing.Size(61, 4);
            // 
            // openFileDialog_M3PIFileLoc
            // 
            openFileDialog_M3PIFileLoc.FileName = "Mandelbulb3D Paramater File";
            openFileDialog_M3PIFileLoc.Filter = "Mandelbulb3D M3p Files|*.m3p|Mandelbulb3D M3i Files|*.m3i|All Files|*.*";
            // 
            // openFileDialog_M3AFileLoc
            // 
            openFileDialog_M3AFileLoc.FileName = "Mandelbulb3D Animation File";
            openFileDialog_M3AFileLoc.Filter = "Mandelbulb3D Files|*.m3a|All Files|*.*";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Gainsboro;
            ClientSize = new System.Drawing.Size(1294, 761);
            Controls.Add(tabControl1);
            Controls.Add(pnl_Top);
            IsMdiContainer = true;
            Margin = new System.Windows.Forms.Padding(4);
            MinimumSize = new System.Drawing.Size(1310, 800);
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Style.BackColor = System.Drawing.Color.Gainsboro;
            Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Style.TitleBar.BackColor = System.Drawing.Color.White;
            Text = "Mandelbulb3D Animation Copilot";
            ThemeName = "HighContrastTheme";
            Activated += Form1_Activated;
            FormClosing += Form1_FormClosing;
            Shown += MainForm_Shown;
            pnl_Bottom.ResumeLayout(false);
            pnl_Bottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_AutoSaveTrigger).EndInit();
            grp_FooterMessageArea.ResumeLayout(false);
            grp_FooterMessageArea.PerformLayout();
            pnl_Top.ResumeLayout(false);
            pnl_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbx_M3A_FileLocation).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbx_M3PI_FileLocation).EndInit();
            ((System.ComponentModel.ISupportInitialize)drp_ProjectList).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbx_AnimationName).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbx_ProjectNotes).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            pnl_MovesList.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nup_AutoMoveQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbx_EnableAutoMove).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbx_AutoMoveShift).EndInit();
            ((System.ComponentModel.ISupportInitialize)drp_AutoLastMove).EndInit();
            pnl_KeyStack.ResumeLayout(false);
            panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_Keyframes_sf).EndInit();
            panel12.ResumeLayout(false);
            grpManageKeyframes.ResumeLayout(false);
            grpManageKeyframes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)drpKeyframeCommands).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_EndDeleteKeyframe).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_StartDeleteKeyframe).EndInit();
            grpKeyframeActions.ResumeLayout(false);
            grpKeyframeActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)drp_KeyframeActions).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_SendKeyStepAngleCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_SendKeyQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbx_SendKeyChar).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbx_KeyframeAction_Name).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabControl1).EndInit();
            tabControl1.ResumeLayout(false);
            page_AnimationCopilot.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)drp_UseSequenceList).EndInit();
            page_MoveDesigner.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            splitContainer_ManageSeq.Panel1.ResumeLayout(false);
            splitContainer_ManageSeq.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_ManageSeq).EndInit();
            splitContainer_ManageSeq.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_ManageMoveSequence).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)drp_ManageSeqStepNameList).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_ManageSeqSendKeyQty).EndInit();
            panel_ManageSeqTop.ResumeLayout(false);
            panel_ManageSeqTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbx_SequenceDesc_Manage).EndInit();
            ((System.ComponentModel.ISupportInitialize)drp_ManageSeqMoveSequences).EndInit();
            page_Utilities.ResumeLayout(false);
            panel_UtilitiesPage.ResumeLayout(false);
            panel_UtilitiesPage.PerformLayout();
            page_Library.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            page_Admin.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            gb_DBAdmin_Restore.ResumeLayout(false);
            gb_DBAdmin_Restore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbx_DBAdmin_Restore_DBFolder).EndInit();
            gb_DBAdmin_Backup.ResumeLayout(false);
            gb_DBAdmin_Backup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbx_DBAdmin_Backup_DBNewFileName).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbx_DBAdmin_Backup_FolderName).EndInit();
            page_About.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbx_ErrorLogContent).EndInit();
            grp_Admin_JoytoKey.ResumeLayout(false);
            grp_Admin_JoytoKey.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label lbl_RecordingLabel;
        private Syncfusion.WinForms.Controls.SfButton btn_StartOver;
        private Syncfusion.WinForms.Controls.SfButton btn_SaveToFile;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label4;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label6;
        private System.Windows.Forms.Label lbl_SavedFilePathName;
        private System.Windows.Forms.Panel pnl_Bottom;
        private System.Windows.Forms.Panel pnl_Top;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnl_MovesList;
        private System.Windows.Forms.Panel pnl_KeyStack;
        private System.Windows.Forms.Label lbl_ShiftIndicator;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbl_LastKeyEvent;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_ApplicationMainTitle;
        private System.Windows.Forms.Panel panel5;
        private Syncfusion.WinForms.ListView.SfComboBox drp_AutoLastMove;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label14;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label13;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv cbx_AutoMoveShift;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv cbx_EnableAutoMove;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label15;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv TabControl1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv page_MoveDesigner;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv page_AnimationCopilot;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label18;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label20;
        private Syncfusion.WinForms.Controls.SfButton btn_UseImmediateSeq;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label22;
        private Syncfusion.WinForms.ListView.SfComboBox drp_UseSequenceList;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label24;
        private System.Windows.Forms.Panel panel9;
        private Syncfusion.WinForms.Controls.SfButton btn_NewProject;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label30;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label29;
        private System.Windows.Forms.Label lbl_ProjectSavingIndicator;
        private Syncfusion.WinForms.Controls.SfButton btn_Exit;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbl_KeyframeStackLineChars;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label31;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv page_Utilities;
        private System.Windows.Forms.Button sbtn_DeleteProject;
        private Syncfusion.WinForms.ListView.SfComboBox drp_KeyframeActions;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt tbx_KeyframeAction_Name;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label41;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt tbx_SendKeyChar;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label42;
        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt num_SendKeyQuantity;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label43;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label44;
        private Syncfusion.WinForms.Controls.SfButton btn_KeyframeAction_Delete;
        private Syncfusion.WinForms.Controls.SfButton btn_KeyframeAction_Update;
        private Syncfusion.WinForms.Controls.SfButton btn_DeleteKeyframe;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel14;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label48;
        private Syncfusion.WinForms.Controls.SfButton btn_SetRestorePoint;
        private Syncfusion.WinForms.Controls.SfButton btn_PerformRestorePoint;
        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt num_StartDeleteKeyframe;
        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt num_EndDeleteKeyframe;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbl_KeyframesRange_End;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbl_KeyframesRange_Start;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv page_Admin;
        private System.Windows.Forms.GroupBox gb_DBAdmin_Restore;
        private Syncfusion.WinForms.Controls.SfButton btn_DBAdmin_Restore;
        private System.Windows.Forms.GroupBox gb_DBAdmin_Backup;
        private Syncfusion.WinForms.Controls.SfButton btn_DBAdmin_Backup;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt tbx_DBAdmin_Backup_FolderName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label53;
        private Syncfusion.WinForms.Controls.SfButton btn_DBAdmin_BackupFolder;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label55;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt tbx_DBAdmin_Restore_DBFolder;
        private System.Windows.Forms.OpenFileDialog openFileDialog_BackupFindFile;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt tbx_DBAdmin_Backup_DBNewFileName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label56;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_DBBackupFolder;
        private Syncfusion.WinForms.Controls.SfButton btn_DBAdmin_RestoreDBFile;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label52;
        private System.Windows.Forms.ToolTip toolTip1;
        private Syncfusion.WinForms.Controls.SfButton btn_InsertAutoMove;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbl_MoveSequenceDesc;
        private System.Windows.Forms.Label lbl_FooterMessage;
        private Syncfusion.WinForms.Controls.SfButton btn_ClearRestorePoint;
        private Syncfusion.WinForms.Controls.SfButton btn_RestorePointInfo;
        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt num_SendKeyStepAngleCount;
        private System.Windows.Forms.Label lbl_BusyLabel;
        private Syncfusion.WinForms.Controls.SfButton btn_ShowKeyLegendWindow;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label54;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label12;
        private System.Windows.Forms.GroupBox grpManageKeyframes;
        private System.Windows.Forms.GroupBox grpKeyframeActions;
        private Syncfusion.WinForms.Controls.SfButton btn_ManageKeyframeCommandGo;
        private Syncfusion.WinForms.ListView.SfComboBox drpKeyframeCommands;
        private System.Windows.Forms.GroupBox grp_FooterMessageArea;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv page_Library;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label40;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label10;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label46;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label45;
        private Syncfusion.WinForms.Controls.SfButton btn_DisableCapture;
        private Syncfusion.WinForms.Controls.SfButton btn_EnableCapture;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbl_ProjectAsOfDateTime;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel9;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel8;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel7;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel12;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel11;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel10;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbl_30FPSTimeCalc;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbl_60FPSTimeCalc;
        private Syncfusion.WinForms.Controls.SfButton btn_SaveCurrentProject;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt tbx_ProjectNotes;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt tbx_AnimationName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Syncfusion.WinForms.Input.SfNumericTextBox mtbx_FrameCount;
        private Syncfusion.WinForms.Input.SfNumericTextBox mtbx_FarPlane;
        private Syncfusion.WinForms.Input.SfNumericTextBox mtbx_FramesBetween;
        private Syncfusion.WinForms.Input.SfNumericTextBox mtbx_KeyDelay;
        private Syncfusion.WinForms.Input.SfNumericTextBox mtbx_LookingRollingAngle;
        private Syncfusion.WinForms.Input.SfNumericTextBox mtbx_SlidingWalkingCount;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControl1;
        private Syncfusion.Windows.Forms.Tools.ContextMenuStripEx contextMenuStripEx1;
        private Syncfusion.WinForms.Input.SfNumericTextBox mtbx_NextKeyframeNumber;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgv_Keyframes_sf;
        private Syncfusion.WinForms.Controls.SfButton btn_DeleteProject;
        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt nup_AutoMoveQuantity;
        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt num_AutoSaveTrigger;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbl_MovesList;
        private Syncfusion.WinForms.ListView.SfComboBox drp_ProjectList;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel14;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel13;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt tbx_M3A_FileLocation;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt tbx_M3PI_FileLocation;
        private System.Windows.Forms.OpenFileDialog openFileDialog_M3PIFileLoc;
        private Syncfusion.WinForms.Controls.SfButton btn_FindM3PIFile;
        private Syncfusion.WinForms.Controls.SfButton btn_FindM3AFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog_M3AFileLoc;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel15;
        private System.Windows.Forms.Panel panel4;
        private SfDataGrid dgv_ManageMoveSequence;
        private System.Windows.Forms.Panel panel_ManageSeqTop;
        private System.Windows.Forms.SplitContainer splitContainer_ManageSeq;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel19;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel18;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbl_ManageSeqSelected;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel16;
        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt num_ManageSeqSendKeyQty;
        private Syncfusion.WinForms.ListView.SfComboBox drp_ManageSeqStepNameList;
        private Syncfusion.WinForms.Controls.SfButton btn_ManageSeqUpdateStep;
        private Syncfusion.WinForms.Controls.SfButton btn_ManageSeqDeleteStep;
        private System.Windows.Forms.Panel panel6;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbl_ManageSeqFooterMsgArea;
        private Syncfusion.WinForms.ListView.SfComboBox drp_ManageSeqMoveSequences;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt tbx_SequenceDesc_Manage;
        private Syncfusion.WinForms.Controls.SfButton btn_ManageSeqDeleteSequence;
        private Syncfusion.WinForms.Controls.SfButton btn_ManageSeqAddStep;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel17;
        private Syncfusion.WinForms.Controls.SfButton btn_FarPlaneUpdater;
        private Syncfusion.WinForms.Controls.SfButton btn_LookLeftUpdater;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel20;
        private System.Windows.Forms.Panel panel_UtilitiesPage;
        private System.Windows.Forms.Panel panel10;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel21;
        private System.Windows.Forms.Panel panel11;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbl_DatabaseFileInUse;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel22;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel23;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel24;
        private Syncfusion.WinForms.Controls.SfButton btn_ShowMoveSequenceInfo;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv page_About;
        private System.Windows.Forms.Panel panel13;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel25;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel26;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel27;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel28;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel30;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel29;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel31;
        private System.Windows.Forms.LinkLabel ll_PCGithubURL;
        private System.Windows.Forms.LinkLabel ll_GithubRespository;
        private System.Windows.Forms.GroupBox grp_Admin_JoytoKey;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbl_Admin_JoyToKey_Loc;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbl_Admin_JoyToKey_Intro;
        private System.Windows.Forms.LinkLabel ll_GithubRespository_About;
        private System.Windows.Forms.LinkLabel ll_PCGithubURL_About;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel32;
        private System.Windows.Forms.LinkLabel ll_JoyToKey_About;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbl_MB3D_AppRun_Warn;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbl_JTK_AppRun_Warn;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel33;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt tbx_ErrorLogContent;
        private Syncfusion.WinForms.Controls.SfButton btn_CopyLog;
        private Syncfusion.WinForms.Controls.SfButton btn_EraseLog;
        private Syncfusion.WinForms.Controls.SfButton btn_ErrorLogLocation;
        private System.Windows.Forms.GroupBox groupBox1;
        private Syncfusion.WinForms.Controls.SfButton btn_EraseAllDatabaseRecords;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel34;
        private Syncfusion.WinForms.Controls.SfButton btn_EraseAllDatabaseRecords_KeepMS;
        private System.Windows.Forms.GroupBox groupBox2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel35;
        private Syncfusion.WinForms.Controls.SfButton btn_CreateSampleProject;
    }
}

