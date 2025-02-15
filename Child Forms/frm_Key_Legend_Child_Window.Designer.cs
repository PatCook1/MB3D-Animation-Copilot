namespace MB3D_Animation_Copilot
{
    partial class frm_Key_Legend_Child_Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Key_Legend_Child_Window));
            tabControl1 = new System.Windows.Forms.TabControl();
            tab_xBoxController = new System.Windows.Forms.TabPage();
            tab_Keyboard = new System.Windows.Forms.TabPage();
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            btn_Close = new Syncfusion.WinForms.Controls.SfButton();
            tabControl1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tab_xBoxController);
            tabControl1.Controls.Add(tab_Keyboard);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(617, 334);
            tabControl1.TabIndex = 0;
            // 
            // tab_xBoxController
            // 
            tab_xBoxController.BackgroundImage = (System.Drawing.Image)resources.GetObject("tab_xBoxController.BackgroundImage");
            tab_xBoxController.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            tab_xBoxController.Location = new System.Drawing.Point(4, 24);
            tab_xBoxController.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tab_xBoxController.Name = "tab_xBoxController";
            tab_xBoxController.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tab_xBoxController.Size = new System.Drawing.Size(609, 306);
            tab_xBoxController.TabIndex = 0;
            tab_xBoxController.Text = "   xBox Controller   ";
            tab_xBoxController.UseVisualStyleBackColor = true;
            // 
            // tab_Keyboard
            // 
            tab_Keyboard.BackgroundImage = (System.Drawing.Image)resources.GetObject("tab_Keyboard.BackgroundImage");
            tab_Keyboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            tab_Keyboard.Location = new System.Drawing.Point(4, 24);
            tab_Keyboard.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tab_Keyboard.Name = "tab_Keyboard";
            tab_Keyboard.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tab_Keyboard.Size = new System.Drawing.Size(609, 306);
            tab_Keyboard.TabIndex = 1;
            tab_Keyboard.Text = "     Keyboard     ";
            tab_Keyboard.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_Close);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 334);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(617, 43);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(tabControl1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(617, 334);
            panel2.TabIndex = 2;
            // 
            // btn_Close
            // 
            btn_Close.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            btn_Close.Location = new System.Drawing.Point(539, 9);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new System.Drawing.Size(70, 25);
            btn_Close.TabIndex = 1;
            btn_Close.Text = "Close";
            btn_Close.ThemeName = "HighContrastTheme";
            btn_Close.Click += btn_Close_Click;
            // 
            // frm_Key_Legend_Child_Window
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(617, 377);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frm_Key_Legend_Child_Window";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Mandelbulb3D Animation Copilot Key Mapping Legend";
            tabControl1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_xBoxController;
        private System.Windows.Forms.TabPage tab_Keyboard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Syncfusion.WinForms.Controls.SfButton btn_Close;
    }
}