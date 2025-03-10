namespace MB3D_Animation_Copilot.Child_Forms
{
    partial class frm_Update_Keyframes_Parameter
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
            gb_UpdateFarPlaneValues = new System.Windows.Forms.GroupBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            rb_AddParamValue = new System.Windows.Forms.RadioButton();
            rb_SubtractParamValue = new System.Windows.Forms.RadioButton();
            tbx_ParamValuesList = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            dtbx_ParameterChangeValue = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            dtbx_ParameterStartValue = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            label36 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            lbl_WorkingOnKeyframeNum = new System.Windows.Forms.Label();
            label32 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btn_UpdateParameter = new System.Windows.Forms.Button();
            mtbx_NumberKeyframesCount = new System.Windows.Forms.MaskedTextBox();
            label33 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            label34 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            lbl_EscapeIndicator_UpdateFarPlane = new System.Windows.Forms.Label();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            num_SleepTime = new Syncfusion.WinForms.Input.SfNumericTextBox();
            gb_UpdateFarPlaneValues.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbx_ParamValuesList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtbx_ParameterChangeValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtbx_ParameterStartValue).BeginInit();
            SuspendLayout();
            // 
            // gb_UpdateFarPlaneValues
            // 
            gb_UpdateFarPlaneValues.BackColor = System.Drawing.Color.Transparent;
            gb_UpdateFarPlaneValues.Controls.Add(num_SleepTime);
            gb_UpdateFarPlaneValues.Controls.Add(autoLabel2);
            gb_UpdateFarPlaneValues.Controls.Add(groupBox1);
            gb_UpdateFarPlaneValues.Controls.Add(tbx_ParamValuesList);
            gb_UpdateFarPlaneValues.Controls.Add(dtbx_ParameterChangeValue);
            gb_UpdateFarPlaneValues.Controls.Add(dtbx_ParameterStartValue);
            gb_UpdateFarPlaneValues.Controls.Add(autoLabel1);
            gb_UpdateFarPlaneValues.Controls.Add(label36);
            gb_UpdateFarPlaneValues.Controls.Add(lbl_WorkingOnKeyframeNum);
            gb_UpdateFarPlaneValues.Controls.Add(label32);
            gb_UpdateFarPlaneValues.Controls.Add(btn_UpdateParameter);
            gb_UpdateFarPlaneValues.Controls.Add(mtbx_NumberKeyframesCount);
            gb_UpdateFarPlaneValues.Controls.Add(label33);
            gb_UpdateFarPlaneValues.Controls.Add(label34);
            gb_UpdateFarPlaneValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            gb_UpdateFarPlaneValues.Location = new System.Drawing.Point(13, 13);
            gb_UpdateFarPlaneValues.Margin = new System.Windows.Forms.Padding(4);
            gb_UpdateFarPlaneValues.Name = "gb_UpdateFarPlaneValues";
            gb_UpdateFarPlaneValues.Padding = new System.Windows.Forms.Padding(4);
            gb_UpdateFarPlaneValues.Size = new System.Drawing.Size(281, 522);
            gb_UpdateFarPlaneValues.TabIndex = 7;
            gb_UpdateFarPlaneValues.TabStop = false;
            gb_UpdateFarPlaneValues.Text = "Update Keyframe Parameter Values";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rb_AddParamValue);
            groupBox1.Controls.Add(rb_SubtractParamValue);
            groupBox1.Location = new System.Drawing.Point(22, 112);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(234, 43);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add/Subtract Parameter Value";
            // 
            // rb_AddParamValue
            // 
            rb_AddParamValue.AutoSize = true;
            rb_AddParamValue.Checked = true;
            rb_AddParamValue.Location = new System.Drawing.Point(22, 19);
            rb_AddParamValue.Name = "rb_AddParamValue";
            rb_AddParamValue.Size = new System.Drawing.Size(74, 17);
            rb_AddParamValue.TabIndex = 19;
            rb_AddParamValue.TabStop = true;
            rb_AddParamValue.Text = "Add Value";
            rb_AddParamValue.UseVisualStyleBackColor = true;
            // 
            // rb_SubtractParamValue
            // 
            rb_SubtractParamValue.AutoSize = true;
            rb_SubtractParamValue.Location = new System.Drawing.Point(102, 19);
            rb_SubtractParamValue.Name = "rb_SubtractParamValue";
            rb_SubtractParamValue.Size = new System.Drawing.Size(95, 17);
            rb_SubtractParamValue.TabIndex = 18;
            rb_SubtractParamValue.Text = "Subtract Value";
            rb_SubtractParamValue.UseVisualStyleBackColor = true;
            // 
            // tbx_ParamValuesList
            // 
            tbx_ParamValuesList.BeforeTouchSize = new System.Drawing.Size(238, 202);
            tbx_ParamValuesList.Location = new System.Drawing.Point(18, 303);
            tbx_ParamValuesList.Multiline = true;
            tbx_ParamValuesList.Name = "tbx_ParamValuesList";
            tbx_ParamValuesList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            tbx_ParamValuesList.Size = new System.Drawing.Size(238, 202);
            tbx_ParamValuesList.TabIndex = 15;
            // 
            // dtbx_ParameterChangeValue
            // 
            dtbx_ParameterChangeValue.AccessibilityEnabled = true;
            dtbx_ParameterChangeValue.BeforeTouchSize = new System.Drawing.Size(238, 202);
            dtbx_ParameterChangeValue.DoubleValue = 1D;
            dtbx_ParameterChangeValue.Location = new System.Drawing.Point(156, 164);
            dtbx_ParameterChangeValue.Name = "dtbx_ParameterChangeValue";
            dtbx_ParameterChangeValue.NumberDecimalDigits = 6;
            dtbx_ParameterChangeValue.Size = new System.Drawing.Size(100, 20);
            dtbx_ParameterChangeValue.TabIndex = 14;
            dtbx_ParameterChangeValue.Text = "1.000000";
            // 
            // dtbx_ParameterStartValue
            // 
            dtbx_ParameterStartValue.AccessibilityEnabled = true;
            dtbx_ParameterStartValue.BeforeTouchSize = new System.Drawing.Size(238, 202);
            dtbx_ParameterStartValue.DoubleValue = 0D;
            dtbx_ParameterStartValue.Location = new System.Drawing.Point(158, 85);
            dtbx_ParameterStartValue.Name = "dtbx_ParameterStartValue";
            dtbx_ParameterStartValue.NumberDecimalDigits = 10;
            dtbx_ParameterStartValue.Size = new System.Drawing.Size(100, 20);
            dtbx_ParameterStartValue.TabIndex = 13;
            dtbx_ParameterStartValue.Text = "0.0000000000";
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new System.Drawing.Point(22, 166);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new System.Drawing.Size(137, 13);
            autoLabel1.TabIndex = 12;
            autoLabel1.Text = "Parameter Change Amount:";
            // 
            // label36
            // 
            label36.Location = new System.Drawing.Point(8, 29);
            label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label36.Name = "label36";
            label36.Size = new System.Drawing.Size(212, 13);
            label36.TabIndex = 9;
            label36.Text = "Updates the Parameter value of Keyframes.";
            // 
            // lbl_WorkingOnKeyframeNum
            // 
            lbl_WorkingOnKeyframeNum.AutoSize = true;
            lbl_WorkingOnKeyframeNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_WorkingOnKeyframeNum.Location = new System.Drawing.Point(169, 265);
            lbl_WorkingOnKeyframeNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_WorkingOnKeyframeNum.Name = "lbl_WorkingOnKeyframeNum";
            lbl_WorkingOnKeyframeNum.Size = new System.Drawing.Size(21, 24);
            lbl_WorkingOnKeyframeNum.TabIndex = 7;
            lbl_WorkingOnKeyframeNum.Text = "0";
            // 
            // label32
            // 
            label32.Location = new System.Drawing.Point(53, 270);
            label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label32.Name = "label32";
            label32.Size = new System.Drawing.Size(114, 13);
            label32.TabIndex = 6;
            label32.Text = "Working On Keyframe:";
            // 
            // btn_UpdateParameter
            // 
            btn_UpdateParameter.Location = new System.Drawing.Point(67, 226);
            btn_UpdateParameter.Margin = new System.Windows.Forms.Padding(4);
            btn_UpdateParameter.Name = "btn_UpdateParameter";
            btn_UpdateParameter.Size = new System.Drawing.Size(140, 26);
            btn_UpdateParameter.TabIndex = 1;
            btn_UpdateParameter.Text = "Update Parameter";
            btn_UpdateParameter.UseVisualStyleBackColor = true;
            btn_UpdateParameter.Click += btn_UpdateParameter_Click;
            // 
            // mtbx_NumberKeyframesCount
            // 
            mtbx_NumberKeyframesCount.Location = new System.Drawing.Point(160, 56);
            mtbx_NumberKeyframesCount.Margin = new System.Windows.Forms.Padding(4);
            mtbx_NumberKeyframesCount.Mask = "0000";
            mtbx_NumberKeyframesCount.Name = "mtbx_NumberKeyframesCount";
            mtbx_NumberKeyframesCount.Size = new System.Drawing.Size(70, 20);
            mtbx_NumberKeyframesCount.TabIndex = 5;
            mtbx_NumberKeyframesCount.Text = "0";
            // 
            // label33
            // 
            label33.Location = new System.Drawing.Point(44, 90);
            label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label33.Name = "label33";
            label33.Size = new System.Drawing.Size(113, 13);
            label33.TabIndex = 2;
            label33.Text = "Start Parameter Value:";
            // 
            // label34
            // 
            label34.Location = new System.Drawing.Point(1, 59);
            label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label34.Name = "label34";
            label34.Size = new System.Drawing.Size(156, 13);
            label34.TabIndex = 3;
            label34.Text = "Number of Keyframe to Update:";
            // 
            // lbl_EscapeIndicator_UpdateFarPlane
            // 
            lbl_EscapeIndicator_UpdateFarPlane.AutoSize = true;
            lbl_EscapeIndicator_UpdateFarPlane.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_EscapeIndicator_UpdateFarPlane.ForeColor = System.Drawing.Color.Red;
            lbl_EscapeIndicator_UpdateFarPlane.Location = new System.Drawing.Point(33, 548);
            lbl_EscapeIndicator_UpdateFarPlane.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_EscapeIndicator_UpdateFarPlane.Name = "lbl_EscapeIndicator_UpdateFarPlane";
            lbl_EscapeIndicator_UpdateFarPlane.Size = new System.Drawing.Size(236, 13);
            lbl_EscapeIndicator_UpdateFarPlane.TabIndex = 8;
            lbl_EscapeIndicator_UpdateFarPlane.Text = "Press ESC to Halt the Parameter Update";
            lbl_EscapeIndicator_UpdateFarPlane.Visible = false;
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new System.Drawing.Point(31, 196);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new System.Drawing.Size(56, 13);
            autoLabel2.TabIndex = 19;
            autoLabel2.Text = "Sleep MS:";
            // 
            // num_SleepTime
            // 
            num_SleepTime.ForeColor = System.Drawing.SystemColors.WindowText;
            num_SleepTime.HideTrailingZeros = true;
            num_SleepTime.Location = new System.Drawing.Point(95, 191);
            num_SleepTime.MaxValue = 5000D;
            num_SleepTime.MinValue = 0D;
            num_SleepTime.Name = "num_SleepTime";
            num_SleepTime.Size = new System.Drawing.Size(72, 20);
            num_SleepTime.Style.FocusBorderColor = System.Drawing.Color.FromArgb(0, 120, 215);
            num_SleepTime.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            num_SleepTime.TabIndex = 20;
            num_SleepTime.Text = "1,000";
            num_SleepTime.Value = 1000D;
            // 
            // frm_Update_Keyframes_Parameter
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(310, 570);
            Controls.Add(gb_UpdateFarPlaneValues);
            Controls.Add(lbl_EscapeIndicator_UpdateFarPlane);
            Name = "frm_Update_Keyframes_Parameter";
            Text = "Parameter Keyframe Updater";
            gb_UpdateFarPlaneValues.ResumeLayout(false);
            gb_UpdateFarPlaneValues.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbx_ParamValuesList).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtbx_ParameterChangeValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtbx_ParameterStartValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox gb_UpdateFarPlaneValues;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label36;
        private System.Windows.Forms.Label lbl_EscapeIndicator_UpdateFarPlane;
        private System.Windows.Forms.Label lbl_WorkingOnKeyframeNum;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label32;
        private System.Windows.Forms.Button btn_UpdateParameter;
        private System.Windows.Forms.MaskedTextBox mtbx_NumberKeyframesCount;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label33;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label34;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox dtbx_ParameterStartValue;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox dtbx_ParameterChangeValue;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt tbx_ParamValuesList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_AddParamValue;
        private System.Windows.Forms.RadioButton rb_SubtractParamValue;
        private Syncfusion.WinForms.Input.SfNumericTextBox num_SleepTime;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
    }
}