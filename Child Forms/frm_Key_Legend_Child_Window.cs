/*========================================================================================
File: MB3D_Animation_Copilot.Key_Legend_Child_Window
Description: A child form of parent MainForm to display illustration images of controller
             and keyboard key mapping.
Original Author: Patrick C. Cook
Copyright: Patrick C. Cook 2025
License: GNU GENERAL PUBLIC LICENSE Version 3
========================================================================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MB3D_Animation_Copilot
{
    public partial class frm_Key_Legend_Child_Window : Form
    {
        public frm_Key_Legend_Child_Window()
        {
            InitializeComponent();
            this.CenterToParent();

            if (FindWindowByStartsWithCaption(MainForm.cJoyToKeyStartCaption) == false)
            {
                this.tabControl1.SelectedTab = tab_Keyboard;
            }

        }

        public bool FindWindowByStartsWithCaption(string strWindowStartCaption)
        {
            bool bolFoundWindow = false;

            Process[] processRunning = Process.GetProcesses();
            foreach (Process pr in processRunning)
            {
                if (pr.MainWindowTitle.ToLower().StartsWith(strWindowStartCaption))
                {
                    bolFoundWindow = true;
                }
            }
            return bolFoundWindow;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
