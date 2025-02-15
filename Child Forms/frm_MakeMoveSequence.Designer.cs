namespace MB3D_Animation_Copilot.Child_Forms
{
    partial class frm_MakeMoveSequence
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
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            tbx_MoveSequenceName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            tbx_MoveSequenceDesc = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            sfToolTip1 = new Syncfusion.Windows.Forms.SfToolTip(components);
            btn_SaveMoveSequence = new Syncfusion.WinForms.Controls.SfButton();
            btn_Close = new Syncfusion.WinForms.Controls.SfButton();
            dgv_KeyframeRangeList = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            panel_Datagrid = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            panel_lower = new System.Windows.Forms.Panel();
            panel_upper = new System.Windows.Forms.Panel();
            panel_Main = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)tbx_MoveSequenceName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbx_MoveSequenceDesc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_KeyframeRangeList).BeginInit();
            panel_Datagrid.SuspendLayout();
            panel_lower.SuspendLayout();
            panel_upper.SuspendLayout();
            panel_Main.SuspendLayout();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            autoLabel1.Location = new System.Drawing.Point(12, 10);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new System.Drawing.Size(160, 20);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Make Move Sequence";
            autoLabel1.ThemeName = "HighContrastTheme";
            // 
            // autoLabel2
            // 
            autoLabel2.AutoSize = false;
            autoLabel2.Location = new System.Drawing.Point(12, 33);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new System.Drawing.Size(470, 37);
            autoLabel2.TabIndex = 1;
            autoLabel2.Text = "The requested keyframes (and their respective Move Actions) listed below will be grouped into a new move sequence that is named and described below.";
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new System.Drawing.Point(10, 6);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new System.Drawing.Size(129, 15);
            autoLabel3.TabIndex = 2;
            autoLabel3.Text = "Move Sequence Name:";
            autoLabel3.ThemeName = "HighContrastTheme";
            // 
            // autoLabel4
            // 
            autoLabel4.Location = new System.Drawing.Point(10, 57);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new System.Drawing.Size(157, 15);
            autoLabel4.TabIndex = 3;
            autoLabel4.Text = "Move Sequence Description:";
            autoLabel4.ThemeName = "HighContrastTheme";
            // 
            // tbx_MoveSequenceName
            // 
            tbx_MoveSequenceName.BeforeTouchSize = new System.Drawing.Size(487, 23);
            tbx_MoveSequenceName.Location = new System.Drawing.Point(13, 24);
            tbx_MoveSequenceName.MaxLength = 50;
            tbx_MoveSequenceName.Name = "tbx_MoveSequenceName";
            tbx_MoveSequenceName.Size = new System.Drawing.Size(266, 23);
            tbx_MoveSequenceName.TabIndex = 4;
            tbx_MoveSequenceName.ThemeName = "HighContrastTheme";
            sfToolTip1.SetToolTip(tbx_MoveSequenceName, "Enter the name you would like to assign to this new Move Sequence");
            // 
            // tbx_MoveSequenceDesc
            // 
            tbx_MoveSequenceDesc.BeforeTouchSize = new System.Drawing.Size(487, 23);
            tbx_MoveSequenceDesc.Location = new System.Drawing.Point(13, 75);
            tbx_MoveSequenceDesc.MaxLength = 500;
            tbx_MoveSequenceDesc.Name = "tbx_MoveSequenceDesc";
            tbx_MoveSequenceDesc.Size = new System.Drawing.Size(487, 23);
            tbx_MoveSequenceDesc.TabIndex = 5;
            tbx_MoveSequenceDesc.ThemeName = "HighContrastTheme";
            sfToolTip1.SetToolTip(tbx_MoveSequenceDesc, "Enter a description for this new Move Sequence");
            // 
            // btn_SaveMoveSequence
            // 
            btn_SaveMoveSequence.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_SaveMoveSequence.Location = new System.Drawing.Point(163, 116);
            btn_SaveMoveSequence.Name = "btn_SaveMoveSequence";
            btn_SaveMoveSequence.Size = new System.Drawing.Size(177, 28);
            btn_SaveMoveSequence.TabIndex = 6;
            btn_SaveMoveSequence.Text = "Save New Move Sequence";
            btn_SaveMoveSequence.ThemeName = "HighContrastTheme";
            sfToolTip1.SetToolTip(btn_SaveMoveSequence, "Save the new Move Sequence");
            btn_SaveMoveSequence.Click += btn_SaveMoveSequence_Click;
            // 
            // btn_Close
            // 
            btn_Close.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_Close.ForeColor = System.Drawing.Color.Red;
            btn_Close.Location = new System.Drawing.Point(439, 116);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new System.Drawing.Size(58, 28);
            btn_Close.Style.ForeColor = System.Drawing.Color.Red;
            btn_Close.TabIndex = 7;
            btn_Close.Text = "Close";
            btn_Close.ThemeName = "HighContrastTheme";
            sfToolTip1.SetToolTip(btn_Close, "Close this form");
            btn_Close.Click += btn_Close_Click;
            // 
            // dgv_KeyframeRangeList
            // 
            dgv_KeyframeRangeList.AccessibleName = "Table";
            dgv_KeyframeRangeList.AllowEditing = false;
            dgv_KeyframeRangeList.AllowGrouping = false;
            dgv_KeyframeRangeList.AllowSorting = false;
            dgv_KeyframeRangeList.Dock = System.Windows.Forms.DockStyle.Fill;
            dgv_KeyframeRangeList.Location = new System.Drawing.Point(11, 0);
            dgv_KeyframeRangeList.Margin = new System.Windows.Forms.Padding(4);
            dgv_KeyframeRangeList.Name = "dgv_KeyframeRangeList";
            dgv_KeyframeRangeList.Padding = new System.Windows.Forms.Padding(4);
            dgv_KeyframeRangeList.Size = new System.Drawing.Size(488, 140);
            dgv_KeyframeRangeList.Style.BorderColor = System.Drawing.Color.FromArgb(100, 100, 100);
            dgv_KeyframeRangeList.Style.CheckBoxStyle.CheckedBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dgv_KeyframeRangeList.Style.CheckBoxStyle.CheckedBorderColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dgv_KeyframeRangeList.Style.CheckBoxStyle.IndeterminateBorderColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dgv_KeyframeRangeList.Style.HyperlinkStyle.DefaultLinkColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dgv_KeyframeRangeList.TabIndex = 8;
            dgv_KeyframeRangeList.Text = "sfDataGrid1";
            dgv_KeyframeRangeList.ThemeName = "HighContrastTheme";
            // 
            // panel_Datagrid
            // 
            panel_Datagrid.Controls.Add(dgv_KeyframeRangeList);
            panel_Datagrid.Controls.Add(panel3);
            panel_Datagrid.Controls.Add(panel2);
            panel_Datagrid.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_Datagrid.Location = new System.Drawing.Point(0, 73);
            panel_Datagrid.Name = "panel_Datagrid";
            panel_Datagrid.Size = new System.Drawing.Size(515, 140);
            panel_Datagrid.TabIndex = 9;
            // 
            // panel3
            // 
            panel3.Dock = System.Windows.Forms.DockStyle.Right;
            panel3.Location = new System.Drawing.Point(499, 0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(16, 140);
            panel3.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.Dock = System.Windows.Forms.DockStyle.Left;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(11, 140);
            panel2.TabIndex = 9;
            // 
            // autoLabel5
            // 
            autoLabel5.Location = new System.Drawing.Point(285, 29);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new System.Drawing.Size(196, 15);
            autoLabel5.TabIndex = 10;
            autoLabel5.Text = "Name must be 50 characters or less.";
            // 
            // panel_lower
            // 
            panel_lower.Controls.Add(tbx_MoveSequenceName);
            panel_lower.Controls.Add(autoLabel5);
            panel_lower.Controls.Add(autoLabel3);
            panel_lower.Controls.Add(autoLabel4);
            panel_lower.Controls.Add(btn_Close);
            panel_lower.Controls.Add(tbx_MoveSequenceDesc);
            panel_lower.Controls.Add(btn_SaveMoveSequence);
            panel_lower.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel_lower.Location = new System.Drawing.Point(0, 213);
            panel_lower.Name = "panel_lower";
            panel_lower.Size = new System.Drawing.Size(515, 160);
            panel_lower.TabIndex = 11;
            // 
            // panel_upper
            // 
            panel_upper.Controls.Add(autoLabel1);
            panel_upper.Controls.Add(autoLabel2);
            panel_upper.Dock = System.Windows.Forms.DockStyle.Top;
            panel_upper.Location = new System.Drawing.Point(0, 0);
            panel_upper.Name = "panel_upper";
            panel_upper.Size = new System.Drawing.Size(515, 73);
            panel_upper.TabIndex = 12;
            // 
            // panel_Main
            // 
            panel_Main.Controls.Add(panel_Datagrid);
            panel_Main.Controls.Add(panel_upper);
            panel_Main.Controls.Add(panel_lower);
            panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_Main.Location = new System.Drawing.Point(0, 0);
            panel_Main.Name = "panel_Main";
            panel_Main.Size = new System.Drawing.Size(515, 373);
            panel_Main.TabIndex = 13;
            // 
            // frm_MakeMoveSequence
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(515, 373);
            Controls.Add(panel_Main);
            ForeColor = System.Drawing.Color.White;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(528, 412);
            Name = "frm_MakeMoveSequence";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Make Move Sequence";
            FormClosing += frm_MakeMoveSequence_FormClosing;
            ((System.ComponentModel.ISupportInitialize)tbx_MoveSequenceName).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbx_MoveSequenceDesc).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_KeyframeRangeList).EndInit();
            panel_Datagrid.ResumeLayout(false);
            panel_lower.ResumeLayout(false);
            panel_lower.PerformLayout();
            panel_upper.ResumeLayout(false);
            panel_upper.PerformLayout();
            panel_Main.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt tbx_MoveSequenceName;
        private Syncfusion.Windows.Forms.SfToolTip sfToolTip1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt tbx_MoveSequenceDesc;
        private Syncfusion.WinForms.Controls.SfButton btn_SaveMoveSequence;
        private Syncfusion.WinForms.Controls.SfButton btn_Close;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgv_KeyframeRangeList;
        private System.Windows.Forms.Panel panel_Datagrid;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private System.Windows.Forms.Panel panel_lower;
        private System.Windows.Forms.Panel panel_upper;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_Main;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}