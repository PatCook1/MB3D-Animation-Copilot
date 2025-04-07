/*========================================================================================
File: MB3D_Animation_Copilot.Key_Legend_Child_Window
Description: A child form of parent MainForm to display illustration images of controller
             and keyboard key mapping.
Original Author: Patrick C. Cook
Copyright: Patrick C. Cook 2025
License: GNU GENERAL PUBLIC LICENSE Version 3
========================================================================================*/

using MB3D_Animation_Copilot.Properties;
using Microsoft.VisualBasic;
using Syncfusion.Windows.Forms.Tools.Win32API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Reflection.Metadata;
using System.Resources;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using Windows.ApplicationModel.Resources.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ResourceManager = System.Resources.ResourceManager;

namespace MB3D_Animation_Copilot
{
    public partial class frm_Key_Legend_Child_Window : Form
    {
        //Key Event Constants
        public const string cRLMk = "B"; //"RLM" = Repeat Last Move
        public const string cMNKk = "N"; //"MNK" = Make New Keyframe
        public const string cEAMk = "M"; //"EAM" = Enable/Disable Auto Move

        //Movement (Action) KeyCodes - incoming key codes from key events
        //Note: Incoming keycodes do not have a case attribute - they always appear as uppercase
        public const string cWFk = "W", cWRk = "S",
                            cLUk = "I", cLDk = "K", cLLk = "J", cLRk = "L",
                            cSUk = "E", cSDk = "Q", cSLk = "A", cSRk = "D",
                            cRCCk = "O", cRCWk = "U",
                            cNMKk = "X";

        //Timer
        public Timer ClearMoveSymbolxTmr = new Timer();
        public int ClearMoveSymbolxTmr_Interval = 10000; //10 seconds

        //Public variables
        public string PreviousKeyEvent = string.Empty;

        public frm_Key_Legend_Child_Window()
        {
            InitializeComponent();
            this.CenterToParent();

            if (FindWindowByStartsWithCaption(MainForm.cJoyToKeyStartCaption) == false)
            {
                this.tabControl1.SelectedTab = tab_Keyboard;
            }

            //Lay in the symbol clear timer interval
            ClearMoveSymbolxTmr.Interval = ClearMoveSymbolxTmr_Interval;
            ClearMoveSymbolxTmr.Tick += new EventHandler(ClearMoveSymbolsTmr_Tick);
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

        private void cbx_ShowMoveSymbols_CheckedChanged(object sender, EventArgs e)
        {
            ClearMoveSymbols_All(); //Clear all for a clean presentation
        }

        public void ReceiveMovementChar(string strKey)
        {
            //Set the visible state of the appropriate picturebox
            //Note: The Symbol timer will set all pictureboxs visible to false when it times out
            if (tabControl1.TabIndex == 0) //Allow symbol graphics only on the controller tab
            {
                if (cbx_ShowMoveSymbols.Checked && strKey != string.Empty && strKey != null)
                {
                    //This if prevents the acting on the same key right after another of the same key
                    if (strKey != PreviousKeyEvent)
                    {
                        PreviousKeyEvent = string.Empty;

                        if (SetSymbolByKeyChar(strKey))
                        {
                            //SetSymbolByKeyChar returns true if a symbol was found and made visible
                            ClearMoveSymbolxTmr.Start();
                        }
                    }
                }
            }
        }

        private bool SetSymbolByKeyChar(string strKey)
        {
            byte[] byteArrow = null;
            Image imgArrow = null;

            //Set the image and visible state of the appropriate picturebox based on incoming key action
            switch (strKey)
            {
                //Walking
                case cWFk: //Walk Forward
                    ClearMoveSymbols_All(); //Clear all symbols with this new move
                    byteArrow = Properties.Resource_Legend.Arrow_WalkFwd;
                    imgArrow = byteArrayToImage(byteArrow);
                    pbx_WalkFwdSymbol.Image = imgArrow;
                    pbx_WalkFwdSymbol.Refresh();
                    pbx_WalkFwdSymbol.Visible = true;
                    break;
                case cWRk: //Walk Reverse
                    ClearMoveSymbols_All(); //Clear all symbols with this new move
                    byteArrow = Properties.Resource_Legend.Arrow_WalkRev;
                    imgArrow = byteArrayToImage(byteArrow);
                    pbx_WalkReverse.Image = imgArrow;
                    pbx_WalkReverse.Refresh();
                    pbx_WalkReverse.Visible = true;
                    break;

                //Looking
                case cLUk: //Look UP
                    ClearMoveSymbols_All(); //Clear all symbols with this new move
                    byteArrow = Properties.Resource_Legend.Arrow_LookUp;
                    imgArrow = byteArrayToImage(byteArrow);
                    pbx_LookSymbol_Multi.Image = imgArrow;
                    pbx_LookSymbol_Multi.Refresh();
                    pbx_LookSymbol_Multi.Visible = true;
                    break;
                case cLDk: //Look Down
                    ClearMoveSymbols_All(); //Clear all symbols with this new move
                    byteArrow = Properties.Resource_Legend.Arrow_LookDown;
                    imgArrow = byteArrayToImage(byteArrow);
                    pbx_LookSymbol_Multi.Image = imgArrow;
                    pbx_LookSymbol_Multi.Refresh();
                    pbx_LookSymbol_Multi.Visible = true;
                    break;
                case cLRk: //Look Right
                    ClearMoveSymbols_All(); //Clear all symbols with this new move
                    byteArrow = Properties.Resource_Legend.Arrow_LookRight;
                    imgArrow = byteArrayToImage(byteArrow);
                    pbx_LookSymbol_Multi.Image = imgArrow;
                    pbx_LookSymbol_Multi.Refresh();
                    pbx_LookSymbol_Multi.Visible = true;
                    break;
                case cLLk: //Look Left
                    ClearMoveSymbols_All(); //Clear all symbols with this new move
                    byteArrow = Properties.Resource_Legend.Arrow_LookLeft;
                    imgArrow = byteArrayToImage(byteArrow);
                    pbx_LookSymbol_Multi.Image = imgArrow;
                    pbx_LookSymbol_Multi.Refresh();
                    pbx_LookSymbol_Multi.Visible = true;
                    break;

                //Sliding
                case cSUk: //Slide UP
                    ClearMoveSymbols_All(); //Clear all symbols with this new move
                    byteArrow = Properties.Resource_Legend.Arrow_SlideUp;
                    imgArrow = byteArrayToImage(byteArrow);
                    pbx_SlideSymbol_Multi.Image = imgArrow;
                    pbx_SlideSymbol_Multi.Refresh();
                    pbx_SlideSymbol_Multi.Visible = true;
                    break;
                case cSDk: //Slide Down
                    ClearMoveSymbols_All(); //Clear all symbols with this new move
                    byteArrow = Properties.Resource_Legend.Arrow_SlideDown;
                    imgArrow = byteArrayToImage(byteArrow);
                    pbx_SlideSymbol_Multi.Image = imgArrow;
                    pbx_SlideSymbol_Multi.Refresh();
                    pbx_SlideSymbol_Multi.Visible = true;
                    break;
                case cSRk: //Slide Right
                    ClearMoveSymbols_All(); //Clear all symbols with this new move
                    byteArrow = Properties.Resource_Legend.Arrow_SlideRight;
                    imgArrow = byteArrayToImage(byteArrow);
                    pbx_SlideSymbol_Multi.Image = imgArrow;
                    pbx_SlideSymbol_Multi.Refresh();
                    pbx_SlideSymbol_Multi.Visible = true;
                    break;
                case cSLk: //Slide Left
                    ClearMoveSymbols_All(); //Clear all symbols with this new move
                    byteArrow = Properties.Resource_Legend.Arrow_SlideLeft;
                    imgArrow = byteArrayToImage(byteArrow);
                    pbx_SlideSymbol_Multi.Image = imgArrow;
                    pbx_SlideSymbol_Multi.Refresh();
                    pbx_SlideSymbol_Multi.Visible = true;
                    break;

                //Rolling
                case cRCCk: //Rotate Counter-Clockwise
                    ClearMoveSymbols_All(); //Clear all symbols with this new move
                    byteArrow = Properties.Resource_Legend.Arrow_RotateCCW;
                    imgArrow = byteArrayToImage(byteArrow);
                    pbx_RollSymbol_CCW.Image = imgArrow;
                    pbx_RollSymbol_CCW.Refresh();
                    pbx_RollSymbol_CCW.Visible = true;
                    break;
                case cRCWk: //Rotate Clockwise
                    ClearMoveSymbols_All(); //Clear all symbols with this new move
                    byteArrow = Properties.Resource_Legend.Arrow_RotateCW;
                    imgArrow = byteArrayToImage(byteArrow);
                    pbx_RollSymbol_CW.Image = imgArrow;
                    pbx_RollSymbol_CW.Refresh();
                    pbx_RollSymbol_CW.Visible = true;
                    break;

                //Make New Keyframe
                case cMNKk:
                    ClearMoveSymbols_All(); //Clear all symbols with this new event
                    byteArrow = Properties.Resource_Legend.MakeNewKeyframe;
                    imgArrow = byteArrayToImage(byteArrow);
                    pbx_MakeNewKeyframe_Symbol.Image = imgArrow;
                    pbx_MakeNewKeyframe_Symbol.Refresh();
                    pbx_MakeNewKeyframe_Symbol.Visible = true;
                    break;

                //Repeat Last Move
                case cRLMk:
                    ClearMoveSymbols_All(); //Clear all symbols with this new event
                    byteArrow = Properties.Resource_Legend.Arrow_RepeatLast;
                    imgArrow = byteArrayToImage(byteArrow);
                    pbx_RepeatLast_Symbol.Image = imgArrow;
                    pbx_RepeatLast_Symbol.Refresh();
                    pbx_RepeatLast_Symbol.Visible = true;
                    break;

                //Toggle Capture Mode
                case cEAMk:
                    ClearMoveSymbols_All(); //Clear all symbols with this new event
                    byteArrow = Properties.Resource_Legend.Arrow_ToggleCapture;
                    imgArrow = byteArrayToImage(byteArrow);
                    pbx_ToggleCapture_Symbol.Image = imgArrow;
                    pbx_ToggleCapture_Symbol.Refresh();
                    pbx_ToggleCapture_Symbol.Visible = true;
                    break;

                default:
                    //If none of the above cases were met, there were no moves to process
                    return false; //No symbol found - return false
            }

            return true;
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
                ms.Write(byteArrayIn, 0, byteArrayIn.Length);
                return Image.FromStream(ms, true);//Exception occurs here
            }
            catch { }
            return null;
        }


        private void ClearMoveSymbolsTmr_Tick(object sender, EventArgs e)
        {
            ClearMoveSymbols_All();
        }

        private void ClearMoveSymbols_All()
        {
            //Assemble a list of all {ictureBox controls (the symbol controls)
            List<Control> pbx_List = new List<Control>();
            GetControlsOfType(typeof(PictureBox), this.Controls, ref pbx_List);

            foreach (var pictureBox in pbx_List)
            {
                pictureBox.Visible = false;
            }
        }

        private void GetControlsOfType(Type type, Control.ControlCollection formControls, ref List<Control> controls)
        {
            foreach (Control control in formControls)
            {
                if (control.GetType() == type)
                    controls.Add(control);
                if (control.Controls.Count > 0)
                    GetControlsOfType(type, control.Controls, ref controls);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}