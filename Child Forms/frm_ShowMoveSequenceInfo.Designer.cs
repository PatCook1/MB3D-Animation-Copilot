namespace MB3D_Animation_Copilot.Child_Forms
{
    partial class frm_ShowMoveSequenceInfo
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
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            lbl_MoveSequenceName = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            lbl_MoveSequenceDesc = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            dgv_MoveSequenceSteps = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            btn_Close = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            panel_bottom = new System.Windows.Forms.Panel();
            autoLabel17 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            panel_DataGrid = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            panel1 = new System.Windows.Forms.Panel();
            panel_Top = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)dgv_MoveSequenceSteps).BeginInit();
            panel_bottom.SuspendLayout();
            panel_DataGrid.SuspendLayout();
            panel_Top.SuspendLayout();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            autoLabel1.Location = new System.Drawing.Point(6, 11);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new System.Drawing.Size(207, 20);
            autoLabel1.TabIndex = 1;
            autoLabel1.Text = "Move Sequence Information";
            autoLabel1.ThemeName = "HighContrastTheme";
            autoLabel1.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new System.Drawing.Point(39, 41);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new System.Drawing.Size(42, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Name:";
            autoLabel2.ThemeName = "HighContrastTheme";
            // 
            // lbl_MoveSequenceName
            // 
            lbl_MoveSequenceName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lbl_MoveSequenceName.Location = new System.Drawing.Point(83, 42);
            lbl_MoveSequenceName.Name = "lbl_MoveSequenceName";
            lbl_MoveSequenceName.Size = new System.Drawing.Size(119, 15);
            lbl_MoveSequenceName.TabIndex = 3;
            lbl_MoveSequenceName.Text = "--Move Seq Name--";
            lbl_MoveSequenceName.ThemeName = "HighContrastTheme";
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new System.Drawing.Point(12, 62);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new System.Drawing.Size(70, 15);
            autoLabel3.TabIndex = 4;
            autoLabel3.Text = "Description:";
            autoLabel3.ThemeName = "HighContrastTheme";
            // 
            // lbl_MoveSequenceDesc
            // 
            lbl_MoveSequenceDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lbl_MoveSequenceDesc.Location = new System.Drawing.Point(82, 62);
            lbl_MoveSequenceDesc.Name = "lbl_MoveSequenceDesc";
            lbl_MoveSequenceDesc.Size = new System.Drawing.Size(113, 15);
            lbl_MoveSequenceDesc.TabIndex = 5;
            lbl_MoveSequenceDesc.Text = "--Move Seq Desc--";
            lbl_MoveSequenceDesc.ThemeName = "HighContrastTheme";
            // 
            // dgv_MoveSequenceSteps
            // 
            dgv_MoveSequenceSteps.AccessibleName = "Table";
            dgv_MoveSequenceSteps.AllowEditing = false;
            dgv_MoveSequenceSteps.AllowGrouping = false;
            dgv_MoveSequenceSteps.AllowSorting = false;
            dgv_MoveSequenceSteps.AutoGenerateColumns = false;
            dgv_MoveSequenceSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            dgv_MoveSequenceSteps.Location = new System.Drawing.Point(14, 0);
            dgv_MoveSequenceSteps.Margin = new System.Windows.Forms.Padding(4);
            dgv_MoveSequenceSteps.Name = "dgv_MoveSequenceSteps";
            dgv_MoveSequenceSteps.Padding = new System.Windows.Forms.Padding(4);
            dgv_MoveSequenceSteps.Size = new System.Drawing.Size(432, 261);
            dgv_MoveSequenceSteps.Style.BorderColor = System.Drawing.Color.FromArgb(100, 100, 100);
            dgv_MoveSequenceSteps.Style.CheckBoxStyle.CheckedBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dgv_MoveSequenceSteps.Style.CheckBoxStyle.CheckedBorderColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dgv_MoveSequenceSteps.Style.CheckBoxStyle.IndeterminateBorderColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dgv_MoveSequenceSteps.Style.HyperlinkStyle.DefaultLinkColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dgv_MoveSequenceSteps.TabIndex = 9;
            dgv_MoveSequenceSteps.ThemeName = "HighContrastTheme";
            // 
            // btn_Close
            // 
            btn_Close.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_Close.ForeColor = System.Drawing.Color.Red;
            btn_Close.Location = new System.Drawing.Point(385, 21);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new System.Drawing.Size(58, 28);
            btn_Close.Style.ForeColor = System.Drawing.Color.Red;
            btn_Close.TabIndex = 10;
            btn_Close.Text = "Close";
            btn_Close.ThemeName = "HighContrastTheme";
            btn_Close.Click += btn_Close_Click;
            // 
            // autoLabel4
            // 
            autoLabel4.Location = new System.Drawing.Point(11, 85);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new System.Drawing.Size(92, 15);
            autoLabel4.TabIndex = 11;
            autoLabel4.Text = "Sequence Steps:";
            // 
            // panel_bottom
            // 
            panel_bottom.Controls.Add(autoLabel17);
            panel_bottom.Controls.Add(btn_Close);
            panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel_bottom.Location = new System.Drawing.Point(0, 365);
            panel_bottom.Name = "panel_bottom";
            panel_bottom.Size = new System.Drawing.Size(457, 60);
            panel_bottom.TabIndex = 12;
            // 
            // autoLabel17
            // 
            autoLabel17.AutoSize = false;
            autoLabel17.Location = new System.Drawing.Point(11, 5);
            autoLabel17.Name = "autoLabel17";
            autoLabel17.Size = new System.Drawing.Size(328, 52);
            autoLabel17.TabIndex = 37;
            autoLabel17.Text = "Walking and sliding steps use the 'Sliding+Walking step' setting of the Mandlebulb3D Navigator while looking and rolling steps use the 'Looking+Rolling angle' setting.";
            // 
            // panel_DataGrid
            // 
            panel_DataGrid.Controls.Add(dgv_MoveSequenceSteps);
            panel_DataGrid.Controls.Add(panel2);
            panel_DataGrid.Controls.Add(panel1);
            panel_DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_DataGrid.Location = new System.Drawing.Point(0, 104);
            panel_DataGrid.Name = "panel_DataGrid";
            panel_DataGrid.Size = new System.Drawing.Size(457, 261);
            panel_DataGrid.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.Dock = System.Windows.Forms.DockStyle.Right;
            panel2.Location = new System.Drawing.Point(446, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(11, 261);
            panel2.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.Dock = System.Windows.Forms.DockStyle.Left;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(14, 261);
            panel1.TabIndex = 10;
            // 
            // panel_Top
            // 
            panel_Top.Controls.Add(autoLabel1);
            panel_Top.Controls.Add(autoLabel4);
            panel_Top.Controls.Add(autoLabel2);
            panel_Top.Controls.Add(lbl_MoveSequenceName);
            panel_Top.Controls.Add(lbl_MoveSequenceDesc);
            panel_Top.Controls.Add(autoLabel3);
            panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            panel_Top.Location = new System.Drawing.Point(0, 0);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new System.Drawing.Size(457, 104);
            panel_Top.TabIndex = 14;
            // 
            // frm_ShowMoveSequenceInfo
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(457, 425);
            Controls.Add(panel_DataGrid);
            Controls.Add(panel_bottom);
            Controls.Add(panel_Top);
            ForeColor = System.Drawing.Color.White;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(440, 464);
            Name = "frm_ShowMoveSequenceInfo";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Move Sequence Information";
            ((System.ComponentModel.ISupportInitialize)dgv_MoveSequenceSteps).EndInit();
            panel_bottom.ResumeLayout(false);
            panel_DataGrid.ResumeLayout(false);
            panel_Top.ResumeLayout(false);
            panel_Top.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbl_MoveSequenceName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbl_MoveSequenceDesc;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgv_MoveSequenceSteps;
        private Syncfusion.WinForms.Controls.SfButton btn_Close;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Panel panel_DataGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Panel panel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel17;
    }
}