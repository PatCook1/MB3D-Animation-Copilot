namespace MB3D_Animation_Copilot.Child_Forms
{
    partial class frm_Update_Keyframes_FarPlane
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
            gb_UpdateFarPlaneValues = new System.Windows.Forms.GroupBox();
            label36 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            lbl_EscapeIndicator_UpdateFarPlane = new System.Windows.Forms.Label();
            lbl_WorkingOnKeyframeNum = new System.Windows.Forms.Label();
            label32 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btn_FixFarPlane = new System.Windows.Forms.Button();
            mtbx_NumberKeyframes_UpdateFarPlane = new System.Windows.Forms.MaskedTextBox();
            label33 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            mtbx_TargetValue_UpdateFarPlane = new System.Windows.Forms.MaskedTextBox();
            label34 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            gb_UpdateFarPlaneValues.SuspendLayout();
            SuspendLayout();
            // 
            // gb_UpdateFarPlaneValues
            // 
            gb_UpdateFarPlaneValues.BackColor = System.Drawing.Color.Transparent;
            gb_UpdateFarPlaneValues.Controls.Add(label36);
            gb_UpdateFarPlaneValues.Controls.Add(lbl_EscapeIndicator_UpdateFarPlane);
            gb_UpdateFarPlaneValues.Controls.Add(lbl_WorkingOnKeyframeNum);
            gb_UpdateFarPlaneValues.Controls.Add(label32);
            gb_UpdateFarPlaneValues.Controls.Add(btn_FixFarPlane);
            gb_UpdateFarPlaneValues.Controls.Add(mtbx_NumberKeyframes_UpdateFarPlane);
            gb_UpdateFarPlaneValues.Controls.Add(label33);
            gb_UpdateFarPlaneValues.Controls.Add(mtbx_TargetValue_UpdateFarPlane);
            gb_UpdateFarPlaneValues.Controls.Add(label34);
            gb_UpdateFarPlaneValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            gb_UpdateFarPlaneValues.Location = new System.Drawing.Point(13, 13);
            gb_UpdateFarPlaneValues.Margin = new System.Windows.Forms.Padding(4);
            gb_UpdateFarPlaneValues.Name = "gb_UpdateFarPlaneValues";
            gb_UpdateFarPlaneValues.Padding = new System.Windows.Forms.Padding(4);
            gb_UpdateFarPlaneValues.Size = new System.Drawing.Size(285, 219);
            gb_UpdateFarPlaneValues.TabIndex = 7;
            gb_UpdateFarPlaneValues.TabStop = false;
            gb_UpdateFarPlaneValues.Text = "Update Keyframe Far Plane Values";
            // 
            // label36
            // 
            label36.Location = new System.Drawing.Point(8, 29);
            label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label36.Name = "label36";
            label36.Size = new System.Drawing.Size(209, 13);
            label36.TabIndex = 9;
            label36.Text = "Updates the Far Plane value of Keyframes.";
            // 
            // lbl_EscapeIndicator_UpdateFarPlane
            // 
            lbl_EscapeIndicator_UpdateFarPlane.AutoSize = true;
            lbl_EscapeIndicator_UpdateFarPlane.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_EscapeIndicator_UpdateFarPlane.ForeColor = System.Drawing.Color.Red;
            lbl_EscapeIndicator_UpdateFarPlane.Location = new System.Drawing.Point(24, 192);
            lbl_EscapeIndicator_UpdateFarPlane.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_EscapeIndicator_UpdateFarPlane.Name = "lbl_EscapeIndicator_UpdateFarPlane";
            lbl_EscapeIndicator_UpdateFarPlane.Size = new System.Drawing.Size(233, 13);
            lbl_EscapeIndicator_UpdateFarPlane.TabIndex = 8;
            lbl_EscapeIndicator_UpdateFarPlane.Text = "Press ESC to Halt the Far Plane Update";
            lbl_EscapeIndicator_UpdateFarPlane.Visible = false;
            // 
            // lbl_WorkingOnKeyframeNum
            // 
            lbl_WorkingOnKeyframeNum.AutoSize = true;
            lbl_WorkingOnKeyframeNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_WorkingOnKeyframeNum.Location = new System.Drawing.Point(175, 158);
            lbl_WorkingOnKeyframeNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_WorkingOnKeyframeNum.Name = "lbl_WorkingOnKeyframeNum";
            lbl_WorkingOnKeyframeNum.Size = new System.Drawing.Size(21, 24);
            lbl_WorkingOnKeyframeNum.TabIndex = 7;
            lbl_WorkingOnKeyframeNum.Text = "0";
            // 
            // label32
            // 
            label32.Location = new System.Drawing.Point(47, 164);
            label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label32.Name = "label32";
            label32.Size = new System.Drawing.Size(114, 13);
            label32.TabIndex = 6;
            label32.Text = "Working On Keyframe:";
            // 
            // btn_FixFarPlane
            // 
            btn_FixFarPlane.Location = new System.Drawing.Point(58, 122);
            btn_FixFarPlane.Margin = new System.Windows.Forms.Padding(4);
            btn_FixFarPlane.Name = "btn_FixFarPlane";
            btn_FixFarPlane.Size = new System.Drawing.Size(140, 26);
            btn_FixFarPlane.TabIndex = 1;
            btn_FixFarPlane.Text = "Update Far Plane";
            btn_FixFarPlane.UseVisualStyleBackColor = true;
            // 
            // mtbx_NumberKeyframes_UpdateFarPlane
            // 
            mtbx_NumberKeyframes_UpdateFarPlane.Location = new System.Drawing.Point(196, 52);
            mtbx_NumberKeyframes_UpdateFarPlane.Margin = new System.Windows.Forms.Padding(4);
            mtbx_NumberKeyframes_UpdateFarPlane.Mask = "0000";
            mtbx_NumberKeyframes_UpdateFarPlane.Name = "mtbx_NumberKeyframes_UpdateFarPlane";
            mtbx_NumberKeyframes_UpdateFarPlane.Size = new System.Drawing.Size(70, 20);
            mtbx_NumberKeyframes_UpdateFarPlane.TabIndex = 5;
            mtbx_NumberKeyframes_UpdateFarPlane.Text = "0";
            // 
            // label33
            // 
            label33.Location = new System.Drawing.Point(33, 85);
            label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label33.Name = "label33";
            label33.Size = new System.Drawing.Size(135, 13);
            label33.TabIndex = 2;
            label33.Text = "Update to Far Plane Value:";
            // 
            // mtbx_TargetValue_UpdateFarPlane
            // 
            mtbx_TargetValue_UpdateFarPlane.Location = new System.Drawing.Point(196, 81);
            mtbx_TargetValue_UpdateFarPlane.Margin = new System.Windows.Forms.Padding(4);
            mtbx_TargetValue_UpdateFarPlane.Mask = "000000";
            mtbx_TargetValue_UpdateFarPlane.Name = "mtbx_TargetValue_UpdateFarPlane";
            mtbx_TargetValue_UpdateFarPlane.Size = new System.Drawing.Size(70, 20);
            mtbx_TargetValue_UpdateFarPlane.TabIndex = 4;
            mtbx_TargetValue_UpdateFarPlane.Text = "0";
            // 
            // label34
            // 
            label34.Location = new System.Drawing.Point(8, 57);
            label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label34.Name = "label34";
            label34.Size = new System.Drawing.Size(156, 13);
            label34.TabIndex = 3;
            label34.Text = "Number of Keyframe to Update:";
            // 
            // frm_Update_Keyframes_FarPlane
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(320, 239);
            Controls.Add(gb_UpdateFarPlaneValues);
            Name = "frm_Update_Keyframes_FarPlane";
            Text = "Far Plane Keyframe Updater";
            gb_UpdateFarPlaneValues.ResumeLayout(false);
            gb_UpdateFarPlaneValues.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gb_UpdateFarPlaneValues;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label36;
        private System.Windows.Forms.Label lbl_EscapeIndicator_UpdateFarPlane;
        private System.Windows.Forms.Label lbl_WorkingOnKeyframeNum;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label32;
        private System.Windows.Forms.Button btn_FixFarPlane;
        private System.Windows.Forms.MaskedTextBox mtbx_NumberKeyframes_UpdateFarPlane;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label33;
        private System.Windows.Forms.MaskedTextBox mtbx_TargetValue_UpdateFarPlane;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label34;
    }
}