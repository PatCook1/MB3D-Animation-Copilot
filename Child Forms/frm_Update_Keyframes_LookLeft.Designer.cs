namespace MB3D_Animation_Copilot.Child_Forms
{
    partial class frm_Update_Keyframes_LookLeft
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
            gb_UpdateLookDirection = new System.Windows.Forms.GroupBox();
            label38 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            label35 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            lbl_EscapeIndicator_UpdateLookLeft = new System.Windows.Forms.Label();
            lbl_WorkingOnKeyframeNum_LookLeft = new System.Windows.Forms.Label();
            label37 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btn_UpdateKeyframes_LookLeft = new System.Windows.Forms.Button();
            mtbx_NumberKeyframes_UpdateLook = new System.Windows.Forms.MaskedTextBox();
            label39 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            gb_UpdateLookDirection.SuspendLayout();
            SuspendLayout();
            // 
            // gb_UpdateLookDirection
            // 
            gb_UpdateLookDirection.BackColor = System.Drawing.Color.Transparent;
            gb_UpdateLookDirection.Controls.Add(label38);
            gb_UpdateLookDirection.Controls.Add(label35);
            gb_UpdateLookDirection.Controls.Add(lbl_EscapeIndicator_UpdateLookLeft);
            gb_UpdateLookDirection.Controls.Add(lbl_WorkingOnKeyframeNum_LookLeft);
            gb_UpdateLookDirection.Controls.Add(label37);
            gb_UpdateLookDirection.Controls.Add(btn_UpdateKeyframes_LookLeft);
            gb_UpdateLookDirection.Controls.Add(mtbx_NumberKeyframes_UpdateLook);
            gb_UpdateLookDirection.Controls.Add(label39);
            gb_UpdateLookDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            gb_UpdateLookDirection.Location = new System.Drawing.Point(13, 13);
            gb_UpdateLookDirection.Margin = new System.Windows.Forms.Padding(4);
            gb_UpdateLookDirection.Name = "gb_UpdateLookDirection";
            gb_UpdateLookDirection.Padding = new System.Windows.Forms.Padding(4);
            gb_UpdateLookDirection.Size = new System.Drawing.Size(285, 219);
            gb_UpdateLookDirection.TabIndex = 8;
            gb_UpdateLookDirection.TabStop = false;
            gb_UpdateLookDirection.Text = "Update Keyframe Look Left Direction";
            // 
            // label38
            // 
            label38.Location = new System.Drawing.Point(11, 48);
            label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label38.Name = "label38";
            label38.Size = new System.Drawing.Size(170, 13);
            label38.TabIndex = 10;
            label38.Text = "Used to change the look direction.";
            // 
            // label35
            // 
            label35.Location = new System.Drawing.Point(13, 29);
            label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label35.Name = "label35";
            label35.Size = new System.Drawing.Size(178, 13);
            label35.TabIndex = 9;
            label35.Text = "Modifies the Look Left of keyframes.";
            // 
            // lbl_EscapeIndicator_UpdateLookLeft
            // 
            lbl_EscapeIndicator_UpdateLookLeft.AutoSize = true;
            lbl_EscapeIndicator_UpdateLookLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_EscapeIndicator_UpdateLookLeft.ForeColor = System.Drawing.Color.Red;
            lbl_EscapeIndicator_UpdateLookLeft.Location = new System.Drawing.Point(23, 194);
            lbl_EscapeIndicator_UpdateLookLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_EscapeIndicator_UpdateLookLeft.Name = "lbl_EscapeIndicator_UpdateLookLeft";
            lbl_EscapeIndicator_UpdateLookLeft.Size = new System.Drawing.Size(233, 13);
            lbl_EscapeIndicator_UpdateLookLeft.TabIndex = 8;
            lbl_EscapeIndicator_UpdateLookLeft.Text = "Press ESC to Halt the Far Plane Update";
            lbl_EscapeIndicator_UpdateLookLeft.Visible = false;
            // 
            // lbl_WorkingOnKeyframeNum_LookLeft
            // 
            lbl_WorkingOnKeyframeNum_LookLeft.AutoSize = true;
            lbl_WorkingOnKeyframeNum_LookLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_WorkingOnKeyframeNum_LookLeft.Location = new System.Drawing.Point(175, 159);
            lbl_WorkingOnKeyframeNum_LookLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_WorkingOnKeyframeNum_LookLeft.Name = "lbl_WorkingOnKeyframeNum_LookLeft";
            lbl_WorkingOnKeyframeNum_LookLeft.Size = new System.Drawing.Size(21, 24);
            lbl_WorkingOnKeyframeNum_LookLeft.TabIndex = 7;
            lbl_WorkingOnKeyframeNum_LookLeft.Text = "0";
            // 
            // label37
            // 
            label37.Location = new System.Drawing.Point(47, 165);
            label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label37.Name = "label37";
            label37.Size = new System.Drawing.Size(114, 13);
            label37.TabIndex = 6;
            label37.Text = "Working On Keyframe:";
            // 
            // btn_UpdateKeyframes_LookLeft
            // 
            btn_UpdateKeyframes_LookLeft.Location = new System.Drawing.Point(58, 124);
            btn_UpdateKeyframes_LookLeft.Margin = new System.Windows.Forms.Padding(4);
            btn_UpdateKeyframes_LookLeft.Name = "btn_UpdateKeyframes_LookLeft";
            btn_UpdateKeyframes_LookLeft.Size = new System.Drawing.Size(150, 26);
            btn_UpdateKeyframes_LookLeft.TabIndex = 1;
            btn_UpdateKeyframes_LookLeft.Text = "Update Look Left Direction";
            btn_UpdateKeyframes_LookLeft.UseVisualStyleBackColor = true;
            // 
            // mtbx_NumberKeyframes_UpdateLook
            // 
            mtbx_NumberKeyframes_UpdateLook.Location = new System.Drawing.Point(202, 81);
            mtbx_NumberKeyframes_UpdateLook.Margin = new System.Windows.Forms.Padding(4);
            mtbx_NumberKeyframes_UpdateLook.Mask = "0000";
            mtbx_NumberKeyframes_UpdateLook.Name = "mtbx_NumberKeyframes_UpdateLook";
            mtbx_NumberKeyframes_UpdateLook.Size = new System.Drawing.Size(70, 20);
            mtbx_NumberKeyframes_UpdateLook.TabIndex = 5;
            mtbx_NumberKeyframes_UpdateLook.Text = "0";
            // 
            // label39
            // 
            label39.Location = new System.Drawing.Point(14, 86);
            label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label39.Name = "label39";
            label39.Size = new System.Drawing.Size(156, 13);
            label39.TabIndex = 3;
            label39.Text = "Number of Keyframe to Update:";
            // 
            // frm_Update_Keyframes_LookLeft
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(314, 248);
            Controls.Add(gb_UpdateLookDirection);
            Name = "frm_Update_Keyframes_LookLeft";
            Text = "Look Left Keyframe Updater";
            gb_UpdateLookDirection.ResumeLayout(false);
            gb_UpdateLookDirection.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gb_UpdateLookDirection;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label38;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label35;
        private System.Windows.Forms.Label lbl_EscapeIndicator_UpdateLookLeft;
        private System.Windows.Forms.Label lbl_WorkingOnKeyframeNum_LookLeft;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label37;
        private System.Windows.Forms.Button btn_UpdateKeyframes_LookLeft;
        private System.Windows.Forms.MaskedTextBox mtbx_NumberKeyframes_UpdateLook;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label39;
    }
}