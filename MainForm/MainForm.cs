/*========================================================================================
File: MB3D_Animation_Copilot.Mainform
Description: This class performs functions of the application's primary form.
Original Author: Patrick C. Cook
Copyright: Patrick C. Cook 2025
License: GNU GENERAL PUBLIC LICENSE Version 3
========================================================================================*/

#region Using References Region =========================================

using MB3D_Animation_Copilot.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
using Microsoft.VisualBasic;
using TextBox = System.Windows.Forms.TextBox;
using System.Data;
using System.Windows.Controls;
using MB3D_Animation_Copilot.Classes;
using Syncfusion.Windows.Forms.Tools;
using Microsoft.Xaml.Behaviors;
using Microsoft.Extensions.Primitives;
using WinRT;
using Microsoft.Win32;
using MB3D_Animation_Copilot.Child_Forms;
using Syncfusion.WinForms.ListView;
using System.Windows.Controls.Primitives;
using Syncfusion.Windows.Forms;
using System.Data.Common;
using System.Configuration;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System.Linq.Expressions;
using Windows.Storage;
using Microsoft.VisualBasic.Logging;
using static Microsoft.DotNet.DesignTools.Protocol.Endpoints.Response;
using System.Windows.Shapes;
using Windows.Media.Protection.PlayReady;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

#endregion

namespace MB3D_Animation_Copilot
{
    public partial class MainForm : SfForm
    {
        #region Public Variables ==========================================

        public int intKeyEventThreadSleep = 1000; //The Sleep delay use in move sequences

        public StringBuilder m_sbMovesList = new StringBuilder(); //Move List
        public StringBuilder m_sbStepsList = new StringBuilder(); //Step (Sequence) List
        public string m_KeysStack = string.Empty; //KeyStack string variable
        public string m_MovesList = string.Empty; //Moive List string variable

        //Dictionaries and Lists
        Dictionary<string, Tuple<string, int, string, int>> m_MoveGroupTrackerDic = new Dictionary<string, Tuple<string, int, string, int>>();
        Dictionary<string, Tuple<int, string, int>> m_RecordSeqStepListDic = new Dictionary<string, Tuple<int, string, int>>();
        Dictionary<string, int> m_RestorePointDic = new Dictionary<string, int>();

        //Timers
        public static Timer ClearFooterMessageTmr = new Timer();
        public static int ClearFooterMessageInterval = 10000; //10 seconds
        public static Timer ClearManageSeqMessageTmr = new Timer();
        public static int ClearManageSeqFooterMessageInterval = 10000; //10 seconds

        //Move related variables
        public int m_WFCount = 0, m_WRCount = 0;
        public int m_LUCount = 0, m_LDCount = 0, m_LLCount = 0, m_LRCount = 0;
        public int m_SUCount = 0, m_SDCount = 0, m_SLCount = 0, m_SRCount = 0;
        public int m_RCCCount = 0, m_RCWCount = 0;

        //Various numeric variables
        public int m_SelectedProjectID = -1; //"-1" assumes no project selected
        public int m_NextKeyframeNumber = 1; //"1" assumes a new project that has no keyframes
        public int m_SWStepCount = 0;
        public int m_LRAngle = 0;
        public int m_Result = 0;
        public int m_TotalFramesCount = 0;
        public int m_AutoSaveCount = 0;
        public int m_StepAngleCountDefaultBypass = -1;

        public int m_SelectedMoveSequenceID = 0;
        public int m_SelectedMoveSeqStepID = 0;

        public int m_CurrentRowIndex_Keyframes = 0;
        public int m_CurrentRowIndex_MoveSteps = 0;

        //Various boolean variables
        public static bool m_HaveMovesToProcess = false;
        public bool m_ShiftKeyActive = false;
        public bool m_ShiftKeyActive_Record = false;
        public bool m_IsMoveSequence = false;
        public static bool m_SequenceRecordingOn = false;
        public static bool m_ProcessStop = false;
        public static bool m_EnableCapture = false;
        public static bool m_EnableAutoMove = false;
        public static bool m_UnsavedChanges = false;
        public static bool m_IsAppStarting = true;
        public static bool m_BlockInsertKeyframe = false;
        public static bool m_InKeyframeRepeatMode = false;

        #endregion

        #region Public Constants ==========================================

        public static int WH_KEYBOARD_LL = 13;
        public static int WM_KEYDOWN = 0x100;
        public static int WM_KEYUP = 0x101;

        public const string cMB3DMainClassName = "TMand3DForm";
        public const string cMB3DNavigatorClassName = "TFNavigator";
        public const string cMB3DAnimatorClassName = "TAnimationForm";
        public const string cJoyToKeyStartCaption = "joytokey";

        //Key Event Constants
        public const string cRLMk = "B"; //"RLM" = Repeat Last Move
        public const string cMNKk = "N"; //"MNK" = Make New Keyframe
        public const string cEAMk = "M"; //"EAM" = Enable/Disable Auto Move

        public const string cTRMk = "Oem3"; //"TRM" = Toggle Record Mode
        public const string cLShiftk = "LShiftKey"; //Shift key mapping
        public const string cRShiftk = "RShiftKey"; //Shift key mapping
        public const string cESCk = "ESC"; //ESC key mapping

        public const int cSlideWalkStepCountDefault = 500;
        public const int cLookingRollingAngleDefault = 5;
        public const int cFramesBetweenDefault = 50;
        public const int cKeyDelayDefault = 500;

        //Send Keys Constants

        //Note: cIKFk must be lower case "f" key
        //Note: Don't change cIKFk from "f" - an upper case "F" will create a LShiftKey key event
        public const string cIKFk_ = "f"; //"IKF" = Insert KeyFrame

        //Movement Groups
        private static readonly IReadOnlyList<string> cWalkFRGroup = Array.AsReadOnly(new string[] { "WFR", "WF", "WR" });
        private static readonly IReadOnlyList<string> cLookUDGroup = Array.AsReadOnly(new string[] { "LUD", "LU", "LD" });
        private static readonly IReadOnlyList<string> cLookRLGroup = Array.AsReadOnly(new string[] { "LRL", "LR", "LL" });
        private static readonly IReadOnlyList<string> cSlideUDGroup = Array.AsReadOnly(new string[] { "SUD", "SU", "SD" });
        private static readonly IReadOnlyList<string> cSlideRLGroup = Array.AsReadOnly(new string[] { "SRL", "SR", "SL" });
        private static readonly IReadOnlyList<string> cRollGroup = Array.AsReadOnly(new string[] { "ROLL", "RCC", "RCW" });

        //Movement Names
        public const string cWFn = "WF", cWRn = "WR",
                            cLUn = "LU", cLDn = "LD", cLLn = "LL", cLRn = "LR",
                            cSUn = "SU", cSDn = "SD", cSLn = "SL", cSRn = "SR",
                            cRCCn = "RCC", cRCWn = "RCW",
                            cNMKn = "IKF";

        //Movement Names - Full Name
        public const string cWFfn = "Walk Forward", cWRfn = "Walk Reverse",
                            cLUfn = "Look Up", cLDfn = "Look Down", cLLfn = "Look Left", cLRfn = "Look Right",
                            cSUfn = "Slide Up", cSDfn = "Slide Down", cSLfn = "Slide Left", cSRfn = "Slide Right",
                            cRCCfn = "Roll Counter Clockwise", cRCWfn = "Roll Clockwise",
                            cNMKfn = "No-Move Keyframe";

        //Movement KeyCodes - incomomg key codes from key events
        //Note: Incoming keycodes do not have a case attribute - they always appear as uppercase
        public const string cWFk = "W", cWRk = "S",
                            cLUk = "I", cLDk = "K", cLLk = "J", cLRk = "L",
                            cSUk = "E", cSDk = "Q", cSLk = "A", cSRk = "D",
                            cRCCk = "O", cRCWk = "U",
                            cNMKk = "X";

        //Movement Keys - outgoing key codes
        public const string cWFk_ = "w", cWRk_ = "s",
                            cLUk_ = "i", cLDk_ = "k", cLLk_ = "j", cLRk_ = "l",
                            cSUk_ = "e", cSDk_ = "q", cSLk_ = "a", cSRk_ = "d",
                            cRCCk_ = "o", cRCWk_ = "u",
                            cNMKk_ = "x";

        public const string cKeyStackLineChar_Manual = "M";
        public const string cKeyStackLineChar_Repeat = "R";
        public const string cKeyStackLineChar_Sequence = "S";
        public const string cKeyStackLineChar_Replicate = "P";

        public const string cManageKFCmd_Select = "Select Command";
        public const string cManageKFCmd_DeleteRange = "Delete Keyframes";
        public const string cManageKFCmd_ReplicateRange = "Replicate Keyframes";
        public const string cManageKFCmd_ApproveRange = "Approve Keyframes";
        public const string cManageKFCmd_DisApproveRange = "Disapprove Keyframes";
        public const string cManageKFCmd_FarPlaneRangeUpdate = "Update Far Plane";
        public const string cManageKFCmd_FramesBetweenRangeUpdate = "Update Frames Between";
        public const string cManageKFCmd_MakeMoveSequenceFromRange = "Make Move Sequence";

        public const string cSingleSpaceChar = " ";
        public const string cDoubleSpaceCharSequence = "  ";

        //Define the various children forms
        private frm_MakeMoveSequence frmMakeMoveSequence = null;
        private frm_Update_Keyframes_FarPlane frmUpdateKeyframesFarPlane = null;
        private frm_Update_Keyframes_LookLeft frmUpdateKeyframesLookLeft = null;
        private frm_Update_Keyframes_Parameter frmUpdateKeyframesParameter = null;
        private frm_ShowMoveSequenceInfo frmShowMoveSequenceInfo = null;

        #endregion

        #region WIN DLL's ==========================================

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookCallbackDelegate lpfn, IntPtr wParam, uint lParam);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        HookCallbackDelegate hcDelegate = HookCallback;
        public delegate IntPtr HookCallbackDelegate(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern bool ShowWindow(IntPtr handle, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        #endregion

        #region Main Program Startup and Form-related Methods ==========================================

        public MainForm()
        {
            InitializeComponent();
            SetStylesAndThemes();
            LoadAndInitMainForm();
        }

        private void SetStylesAndThemes()
        {
            this.ThemeName = "HighContrastTheme";

            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            MessageBoxAdv.ThemeName = "HighContrastTheme";

            //Sets the back color and fore color of the title bar.
            this.Style.TitleBar.BackColor = Color.Black;
            this.Style.TitleBar.ForeColor = Color.White;

            //Sets the fore color of the title bar buttons
            this.Style.TitleBar.CloseButtonForeColor = Color.White;
            this.Style.TitleBar.MinimizeButtonForeColor = Color.White;
            this.Style.TitleBar.MaximizeButtonForeColor = Color.White;

            //Sets the hover state back color of the title bar buttons
            this.Style.TitleBar.CloseButtonHoverBackColor = Color.DarkGray;
            this.Style.TitleBar.MinimizeButtonHoverBackColor = Color.DarkGray;
            this.Style.TitleBar.MaximizeButtonHoverBackColor = Color.DarkGray;

            //Sets the pressed state back color of the title bar buttons
            this.Style.TitleBar.CloseButtonPressedBackColor = Color.Gray;
            this.Style.TitleBar.MaximizeButtonPressedBackColor = Color.Gray;
            this.Style.TitleBar.MinimizeButtonPressedBackColor = Color.Gray;
        }

        private void LoadAndInitMainForm()
        {
            //Note: This method is called from Form1() and from "RestoreDatabase" methods

            SetCaptureMode(false); //Disable record mode

            mtbx_NextKeyframeNumber.Value = m_NextKeyframeNumber;
            lbl_ShiftIndicator.Visible = m_ShiftKeyActive;
            mtbx_KeyDelay.Text = intKeyEventThreadSleep.ToString();

            mtbx_SlidingWalkingCount.Value = cSlideWalkStepCountDefault;
            mtbx_LookingRollingAngle.Value = cLookingRollingAngleDefault;
            mtbx_FramesBetween.Value = cFramesBetweenDefault;
            mtbx_KeyDelay.Value = cKeyDelayDefault;

            //Expose the Keyframe Modifier Utilities group if Developer is true
            if (ConfigurationManager.AppSettings["Developer"] == "true")
            {
                grp_KeyframeModifierUtilities.Visible = true;
            }

            PopulateProjectList(-1);

            BuildKeyframesDatagrid(); //Build the keyframes datagrid before populating it below
            LoadProjectData(); //Note: Call PopulateProjectList first
            PopulateKeyframesDatagrid(true); //Note: Call this after calling LoadProjectData()

            PopulateUseSequenceList();
            PopulateAutoLastMoveDropdown();
            PopulateManageSeqStepNameList();
            PopulateManageKeyframeCommandList();
            InitializeTimers();
            UpdateKeyframeStackLineCharsLegend();
            LoadFooterMessage("Welcome to the Mandelbulb3D Animation Copilot!", true, false);

            BuildManageSeqDatagrid(); //Build the Move Sequence datagrid on the Move Designer tab

            string mainModuleName = Process.GetCurrentProcess().MainModule.ModuleName;
            IntPtr hook = SetWindowsHookEx(WH_KEYBOARD_LL, hcDelegate, GetModuleHandle(mainModuleName), 0);

            m_UnsavedChanges = false; //Turn off the UnsavedChanges flag once the UI settles down

            //Links to external resources
            ll_GithubRespository.Links.Add(23, 10, ConfigurationManager.AppSettings["GithubProjectURL"]);
            ll_GithubRespository_About.Links.Add(34, 10, ConfigurationManager.AppSettings["GithubProjectURL"]);
            ll_PCGithubURL.Links.Add(16, 18, ConfigurationManager.AppSettings["PatCook1GithubURL"]);
            ll_PCGithubURL_About.Links.Add(39, 18, ConfigurationManager.AppSettings["PatCook1GithubURL"]);
            ll_JoyToKey_About.Links.Add(0, 19, ConfigurationManager.AppSettings["JoyToKeyURL"]);

            drp_ProjectList.Focus(); //Set focus on the project dropdown
            drp_ProjectList.Select();

            ValidateMandelbulb3DRunning(); //validate if Mandelbulb3D application is running
            ValidateJoyToKeyRunning(); //validate if JoyToKey application is running

            //GetMousePos(); // for development purposes
        }

        private void PopulateManageKeyframeCommandList()
        {
            List<string> items = new List<string>();
            items.Add(cManageKFCmd_Select);
            items.Add(cManageKFCmd_DeleteRange);
            items.Add(cManageKFCmd_ReplicateRange);
            items.Add(cManageKFCmd_ApproveRange);
            items.Add(cManageKFCmd_DisApproveRange);
            items.Add(cManageKFCmd_FarPlaneRangeUpdate);
            items.Add(cManageKFCmd_FramesBetweenRangeUpdate);
            items.Add(cManageKFCmd_MakeMoveSequenceFromRange);
            drpKeyframeCommands.DataSource = items;
            drpKeyframeCommands.SelectedIndex = 0; //Set to no command selected
        }

        private void lbl_ApplicationMainTitle_Click(object sender, EventArgs e)
        {
            //Switch the tab control to the About page
            tabControl1.SelectedTab = page_About;
        }

        //GetMousePos() for development purposes
        private void GetMousePos()
        {
            bool bolDo = true;
            do
            {
              Console.WriteLine("x: " + System.Windows.Forms.Control.MousePosition.X + " y: " + System.Windows.Forms.Control.MousePosition.Y);
            } while (bolDo);
        }

        private void UpdateKeyframeStackLineCharsLegend()
        {
            lbl_KeyframeStackLineChars.Text = string.Concat("Manual:'", cKeyStackLineChar_Manual, "'   Repeat:'", cKeyStackLineChar_Repeat, "'   Move Seq:'", cKeyStackLineChar_Sequence, "'   Replicate Seq:'", cKeyStackLineChar_Replicate, "'");
        }

        private void PopulateProjectList(int ProjectID)
        {
            //If applicable, find the project list item that matches the Project ID
            List<ProjectListModel> lstProjectList = null;
            lstProjectList = Data_Access_Methods.LoadProjectsList();

            drp_ProjectList.Text = string.Empty; //Clear any previous text
            drp_ProjectList.DataSource = null; //Clear any previous binding

            drp_ProjectList.DataSource = lstProjectList;
            drp_ProjectList.DisplayMember = "Project_Name";
            drp_ProjectList.ValueMember = "ID";

            if (lstProjectList.Count == 0)
            {
                return; //Bail - no project records
            }

            if (ProjectID > 0)
            {
                //Loop across the project list and try to find a matching project ID

                var idx = 0;
                foreach (ProjectListModel item in lstProjectList)
                {
                    if (item.ID == ProjectID)
                    {
                        break;
                    }
                    idx += 1;
                }

                //And set the dropdown to the found item
                drp_ProjectList.SelectedIndex = idx;
            }
        }

        private void InitializeTimers()
        {
            ClearFooterMessageTmr.Interval = ClearFooterMessageInterval;
            ClearFooterMessageTmr.Tick += new EventHandler(ClearFooterMessage_Tick);
            ClearManageSeqMessageTmr.Tick += new EventHandler(ClearManageSeqMessage_Tick);
        }

        private void LoadFooterMessage(string strFooterMessage, bool bolLongDelay, bool ShowAsRed)
        {
            lbl_FooterMessage.Text = strFooterMessage;

            if (ShowAsRed)
            {
                lbl_FooterMessage.ForeColor = Color.Red;
            }
            else
            {
                lbl_FooterMessage.ForeColor = Color.White;
            }

            if (bolLongDelay)
            {
                ClearFooterMessageTmr.Interval = ClearFooterMessageInterval * 2;
            }
            else
            {
                ClearFooterMessageTmr.Interval = ClearFooterMessageInterval;
            }

            ClearFooterMessageTmr.Start(); //Start or re-start the footer message timer
        }

        private void ClearFooterMessage_Tick(object sender, EventArgs e)
        {
            lbl_FooterMessage.Text = string.Empty;
            lbl_FooterMessage.ForeColor = Color.White;
        }

        private void PopulateUseSequenceList()
        {
            drp_UseSequenceList.DataSource = Data_Access_Methods.LoadMoveSeqencesList();
            drp_UseSequenceList.DisplayMember = "SequenceName";
            drp_UseSequenceList.ValueMember = "ID";

            drp_UseSequenceList.SelectedItem = null; //Null so that nothing is selected
        }

        private void PopulateAutoLastMoveDropdown()
        {
            BindingSource binding1 = new BindingSource();

            var source = new Dictionary<string, string>();
            //Walking
            source.Add(cWFn, cWFk_);
            source.Add(cWRn, cWRk_);
            //Looking
            source.Add(cLUn, cLUk_);
            source.Add(cLDn, cLDk_);
            source.Add(cLLn, cLLk_);
            source.Add(cLRn, cLRk_);
            //Sliding
            source.Add(cSUn, cSUk_);
            source.Add(cSDn, cSDk_);
            source.Add(cSLn, cSLk_);
            source.Add(cSRn, cSRk_);
            //Rolling            
            source.Add(cRCCn, cRCCk_);
            source.Add(cRCWn, cRCWk_);
            binding1.DataSource = source;

            drp_AutoLastMove.DataSource = binding1;
            drp_AutoLastMove.DisplayMember = "Key";
            drp_AutoLastMove.ValueMember = "Value";

            drp_AutoLastMove.SelectedIndex = 0; //Set the drp_AutoLastMove to the first list item "None"
        }

        private void drpProjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_IsAppStarting == false)
            {
                LoadProjectData();
                PopulateKeyframesDatagrid(true); //Populate the Keyframes list and select the first datagrid row
            }
        }

        private void LoadProjectData()
        {
            try
            {
                List<ProjectModel> lstProjectData = null;
                List<ProjectListModel> lstProjectList = null;

                if (m_IsAppStarting)
                {
                    //Get the data for the selected project
                    lstProjectData = Data_Access_Methods.LoadProjectData_LastSaved();
                    lstProjectList = Data_Access_Methods.LoadProjectsList();

                    //Try to find the project list item that matches the Project Name
                    var ProjectIDToFind = lstProjectData[0].ID;

                    //Loop across the project list and try to find a matching project ID
                    var idx = 0;
                    foreach (ProjectListModel item in lstProjectList)
                    {
                        if (item.ID == ProjectIDToFind)
                        {
                            break;
                        }
                        idx += 1;
                    }

                    drp_ProjectList.SelectedIndex = idx;

                    ProjectListModel selectedProject = (ProjectListModel)drp_ProjectList.SelectedItem; //Get the selected project item
                    m_SelectedProjectID = selectedProject.ID; //Update the global m_SelectedProjectID var

                    m_IsAppStarting = false; //reset this boolean
                }
                else
                {
                    ProjectListModel selectedProject = (ProjectListModel)drp_ProjectList.SelectedItem; //Get the selected project item
                    if (selectedProject != null)
                    {
                        m_SelectedProjectID = selectedProject.ID; //Update the global m_SelectedProjectID var
                        //Get the data for the selected project
                        lstProjectData = Data_Access_Methods.LoadProjectData(selectedProject.ID);

                    }
                }

                if (lstProjectData != null) //If we have data
                {
                    if (lstProjectData.Count > 0) //If we have a record
                    {
                        tbx_AnimationName.Text = lstProjectData[0].Project_Name;
                        tbx_ProjectNotes.Text = lstProjectData[0].Project_Notes;
                        mtbx_SlidingWalkingCount.Value = Convert.ToDouble(lstProjectData[0].SlideWalk_StepCount);
                        mtbx_LookingRollingAngle.Value = Convert.ToDouble(lstProjectData[0].LookingRolling_Angle);
                        mtbx_FramesBetween.Value = Convert.ToDouble(lstProjectData[0].Frames_Between);
                        mtbx_KeyDelay.Value = lstProjectData[0].Key_Delay;
                        mtbx_FrameCount.Value = Convert.ToDouble(lstProjectData[0].Total_Frames_Count);
                        m_TotalFramesCount = (int)lstProjectData[0].Total_Frames_Count;
                        mtbx_FarPlane.Value = Convert.ToDouble(lstProjectData[0].Far_Plane);
                        lbl_30FPSTimeCalc.Text = lstProjectData[0].Animation_Length_30;
                        lbl_60FPSTimeCalc.Text = lstProjectData[0].Animation_Length_60;
                        tbx_M3PI_FileLocation.Text = lstProjectData[0].M3PIFileLocation;
                        tbx_M3A_FileLocation.Text = lstProjectData[0].M3AFileLocation;

                        m_UnsavedChanges = false; //Clear unsaved changes - we loaded new data
                    }

                    //Get the highest Keyframe number of the project and update the UI
                    m_NextKeyframeNumber = Data_Access_Methods.GetProjectNextKeyframeNumber(m_SelectedProjectID);
                    mtbx_NextKeyframeNumber.Text = m_NextKeyframeNumber.ToString();

                    //Update the UI to show the project's last saved date/time
                    DisplayProjectLastSavedDateTime();

                    CalculateAnimationTime();

                }
            }
            catch
            {
                //Do not throw - the dropdown control may not be bound yet
            }
        }

        private void BuildKeyframesDatagrid()
        {
            //Datagrid configuation
            dgv_Keyframes_sf.AutoGenerateColumns = false;
            dgv_Keyframes_sf.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            dgv_Keyframes_sf.RowHeight = 32;

            //Column definitions
            dgv_Keyframes_sf.Columns.Add(new GridNumericColumn() { MappingName = "ID", HeaderText = "ID", Width = 20, AllowEditing = false, Visible = false });
            dgv_Keyframes_sf.Columns.Add(new GridTextColumn() { MappingName = "KeyframeType", HeaderText = "T", Width = 20, AllowEditing = false });
            dgv_Keyframes_sf.Columns.Add(new GridNumericColumn() { MappingName = "KeyframeNum", HeaderText = "KF#", MinimumWidth = 8, Width = 38, AllowEditing = false, Format = "0.#####" });
            dgv_Keyframes_sf.Columns.Add(new GridTextColumn() { MappingName = "KeyframeDisplay", HeaderText = "Keyframe Summary", Width = 350, AllowEditing = false });
            dgv_Keyframes_sf.Columns.Add(new GridNumericColumn() { MappingName = "FramesBetween", HeaderText = "FB", MinimumWidth = 8, Width = 45, AllowEditing = false, Format = "0.#####" });
            dgv_Keyframes_sf.Columns.Add(new GridNumericColumn() { MappingName = "FrameCount", HeaderText = "TF", MinimumWidth = 8, Width = 45, AllowEditing = false, Format = "0.#####" });
            dgv_Keyframes_sf.Columns.Add(new GridNumericColumn() { MappingName = "FarPlane", HeaderText = "FP", MinimumWidth = 8, Width = 45, AllowEditing = false, Format = "0.#####" });
            dgv_Keyframes_sf.Columns.Add(new GridCheckBoxColumn() { MappingName = "KeyframeApproved", HeaderText = "Apr", MinimumWidth = 8, Width = 35, AllowEditing = false });
            dgv_Keyframes_sf.Columns.Add(new GridTextColumn() { MappingName = "KeyframeNote", HeaderText = "Keyframe Note", Width = 400, AllowEditing = true });

            //Column appearance
            dgv_Keyframes_sf.Columns["KeyframeDisplay"].CellStyle.Font.Size = 12; //Make the font of the keyframe summary column larger
            dgv_Keyframes_sf.Columns["KeyframeDisplay"].CellStyle.Font.Bold = true; //Make the keyframe summary column cells be bold
            dgv_Keyframes_sf.Columns["KeyframeDisplay"].AllowResizing = true; //Allow the keyframe summary column to be resized

            //Frozen columns
            dgv_Keyframes_sf.FrozenColumnCount = 3;

            //Various datagrid settings
            dgv_Keyframes_sf.AllowEditing = true;
            dgv_Keyframes_sf.Columns["KeyframeApproved"].AllowEditing = true;
            dgv_Keyframes_sf.Columns["KeyframeNote"].AllowEditing = true;
            dgv_Keyframes_sf.EditMode = EditMode.SingleClick;
            dgv_Keyframes_sf.EditorSelectionBehavior = EditorSelectionBehavior.SelectAll;

            //Datagrid Events
            dgv_Keyframes_sf.CurrentCellEndEdit += sfDataGrid_CurrentCellEndEdit;

        }

        void sfDataGrid_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs e)
        {
            if (e.DataColumn.ColumnIndex == 0)
            {
                return;
            }

            var rowIndex = e.DataRow.RowIndex;
            var recordIndex = dgv_Keyframes_sf.TableControl.ResolveToRecordIndex(rowIndex);

            var cellValue_ID = DataGridHelper.GetCellValue(dgv_Keyframes_sf, recordIndex, -1, "ID"); //Get the ID column value
            var cellValue_KeyframeNote = DataGridHelper.GetCellValue(dgv_Keyframes_sf, recordIndex, -1, "KeyframeNote"); //Get the Note column value

            //Update the database for this keyframe note edit
            Data_Access_Methods.UpdateNoteByKeyframeID(cellValue_KeyframeNote.ToString(), m_SelectedProjectID, (int)cellValue_ID);
        }

        private void PopulateKeyframesDatagrid(bool bolSetToFirstRow)
        {
            List<KeyframeModel> lstKeyframes = new List<KeyframeModel>();
            lstKeyframes = Data_Access_Methods.LoadKeyframes(m_SelectedProjectID, false);
            if (lstKeyframes.Count > 0) //If we have records
            {
                //If bolSetToFirstRow is false 
                if (bolSetToFirstRow == false)
                {
                    //The idea here is to highlight (select) the same row that was selected before the re-bind
                    m_CurrentRowIndex_Keyframes = (dgv_Keyframes_sf.SelectedIndex);

                    dgv_Keyframes_sf.DataSource = lstKeyframes; //Rebind the datagrid now

                    dgv_Keyframes_sf.ClearSelection();
                    dgv_Keyframes_sf.SelectedIndex = m_CurrentRowIndex_Keyframes;
                }
                else
                {
                    dgv_Keyframes_sf.DataSource = lstKeyframes; //We rebind the datagrid
                    dgv_Keyframes_sf.SelectedIndex = 0; //Select the top most row
                }
            }
            else //No records
            {
                ClearKeyframeActionControls(); //Clear the Keyframe Move Actions UI control
                dgv_Keyframes_sf.DataSource = lstKeyframes; //We still rebind the datagrid
            }
            //Update the total frame count display
            if (lstKeyframes.Count > 0) //If we have records
            {
                mtbx_FrameCount.Value = lstKeyframes[0].FrameCount; //Display the total frame count
            }
            else
            {
                mtbx_FrameCount.Value = 0;
            }
        }

        private void dgv_Keyframes_sf_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            //This procedure writes various values into Keyframe Move Actions controls when a datagrid row is selected.

            try
            {
                //Fetch the currently selected datagrid row
                var rowIndex = this.dgv_Keyframes_sf.SelectionController.DataGrid.CurrentCell.RowIndex;
                var recordIndex = dgv_Keyframes_sf.TableControl.ResolveToRecordIndex(rowIndex);

                var cellValue_ID = DataGridHelper.GetCellValue(dgv_Keyframes_sf, recordIndex, -1, "ID"); //Get the ID column value
                PopulateKeframeActionsList((int)cellValue_ID);

                //Update the StartKeyframeRange and num_EndDeleteKeyframe numeric entries
                var cellValue = DataGridHelper.GetCellValue(dgv_Keyframes_sf, recordIndex, -1, "KeyframeNum"); //Get the Keyframe # column value
                num_StartDeleteKeyframe.Value = (int)cellValue;
                num_EndDeleteKeyframe.Value = (int)Data_Access_Methods.GetHighestKeyframeNumberByProjectID(m_SelectedProjectID);
            }
            catch
            {
                //Do not throw - datagrid may not be bound
            }
        }

        private void PopulateKeframeActionsList(int intKeyframeID)
        {
            List<KeyframeActionsModel> lstKeyframeActions = new List<KeyframeActionsModel>();
            lstKeyframeActions = Data_Access_Methods.LoadKeyframeActionsList(intKeyframeID);

            List<KeyframeActionsModel> lstKeyframeActions_Distinct = new List<KeyframeActionsModel>();
            var DistinctItems = lstKeyframeActions.GroupBy(x => x.ActionName).Select(y => y.First());

            //Replace the list's abreviated action names with the full action name
            foreach (KeyframeActionsModel item in DistinctItems)
            {
                item.ActionName = GetActionItemFullName(item.ActionName);
                lstKeyframeActions_Distinct.Add(item);
            }

            //Try to databind the Keyframe Action dropdown even if no records - this has the effect of clearing the list
            drp_KeyframeActions.DataSource = null; //Clear the datasource binding
            drp_KeyframeActions.DataSource = lstKeyframeActions_Distinct; //Bind the distinct list
            drp_KeyframeActions.DisplayMember = "ActionName";
            drp_KeyframeActions.ValueMember = "ID";

            //Disable the Keyframe Move Actions groupbox if no action records (WF, LR, etc. for example)
            if (lstKeyframeActions.Count > 0)
            {
                drp_KeyframeActions.SelectedItem = lstKeyframeActions[0];

                //If we are in Capture mode, don't change the grpKeyframeActions enabled state
                if (!m_EnableCapture)
                {
                    grpKeyframeActions.Enabled = true;
                }
            }
            else
            {
                //If we are in Capture mode, don't change the grpKeyframeActions enabled state
                if (!m_EnableCapture)
                {
                    grpKeyframeActions.Enabled = false;
                }
            }
        }

        private void btn_FindM3PIFile_Click(object sender, EventArgs e)
        {
            string dirApp = AppDomain.CurrentDomain.BaseDirectory; //Get the root folder of the application's exe
            openFileDialog_M3PIFileLoc.InitialDirectory = dirApp;

            if (openFileDialog_M3PIFileLoc.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    tbx_M3PI_FileLocation.Text = openFileDialog_M3PIFileLoc.FileName;
                    SaveAnimationProject(false, false);
                }
                catch (Exception ex)
                {
                    LogException("btn_FindM3PIFile_Click", ex); //Log this error
                    MessageBoxAdv.Show(ex.Message, "Error @ btn_FindM3PIFile_Click. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_FindM3AFile_Click(object sender, EventArgs e)
        {
            string dirApp = AppDomain.CurrentDomain.BaseDirectory; //Get the root folder of the application's exe
            openFileDialog_M3PIFileLoc.InitialDirectory = dirApp;

            if (openFileDialog_M3AFileLoc.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    tbx_M3A_FileLocation.Text = openFileDialog_M3AFileLoc.FileName;
                    SaveAnimationProject(false, false);
                }
                catch (Exception ex)
                {
                    LogException("btn_FindM3AFile_Click", ex); //Log this error
                    MessageBoxAdv.Show(ex.Message, "Error @ btn_FindM3A_Click. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetActionItemFullName(string argActionName)
        {

            string strActionFullName = string.Empty;

            switch (argActionName)
            {
                case cWFn:
                    strActionFullName = cWFfn;
                    break;
                case cWRn:
                    strActionFullName = cWRfn;
                    break;
                case cLUn:
                    strActionFullName = cLUfn;
                    break;
                case cLDn:
                    strActionFullName = cLDfn;
                    break;
                case cLLn:
                    strActionFullName = cLLfn;
                    break;
                case cLRn:
                    strActionFullName = cLRfn;
                    break;
                case cSUn:
                    strActionFullName = cSUfn;
                    break;
                case cSDn:
                    strActionFullName = cSDfn;
                    break;
                case cSLn:
                    strActionFullName = cSLfn;
                    break;
                case cSRn:
                    strActionFullName = cSRfn;
                    break;
                case cRCCn:
                    strActionFullName = cRCCfn;
                    break;
                case cRCWn:
                    strActionFullName = cRCWfn;
                    break;
                case cNMKn:
                    strActionFullName = cNMKfn;
                    break;
            }

            return strActionFullName;
        }

        private string GetKeyCodeByActionName(string argActionName)
        {

            string strActionKeyCode = string.Empty;

            switch (argActionName)
            {
                case cWFn:
                    strActionKeyCode = cWFk_;
                    break;
                case cWRn:
                    strActionKeyCode = cWRk_;
                    break;
                case cLUn:
                    strActionKeyCode = cLUk_;
                    break;
                case cLDn:
                    strActionKeyCode = cLDk_;
                    break;
                case cLLn:
                    strActionKeyCode = cLLk_;
                    break;
                case cLRn:
                    strActionKeyCode = cLRk_;
                    break;
                case cSUn:
                    strActionKeyCode = cSUk_;
                    break;
                case cSDn:
                    strActionKeyCode = cSDk_;
                    break;
                case cSLn:
                    strActionKeyCode = cSLk_;
                    break;
                case cSRn:
                    strActionKeyCode = cSRk_;
                    break;
                case cRCCn:
                    strActionKeyCode = cRCCk_;
                    break;
                case cRCWn:
                    strActionKeyCode = cRCWk_;
                    break;
                case cNMKk:
                    strActionKeyCode = cNMKk_;
                    break;
            }

            return strActionKeyCode;
        }

        private string GetActionGroupNameByActionName(string argActionName)
        {

            string strActionGroupName = string.Empty;

            switch (argActionName)
            {
                case "WF":
                    strActionGroupName = cWalkFRGroup[0];
                    break;
                case "WR":
                    strActionGroupName = cWalkFRGroup[1];
                    break;
                case "LU":
                    strActionGroupName = cLookUDGroup[0];
                    break;
                case "LD":
                    strActionGroupName = cLookUDGroup[1];
                    break;
                case "LR":
                    strActionGroupName = cLookRLGroup[0];
                    break;
                case "LL":
                    strActionGroupName = cLookRLGroup[1];
                    break;
                case "SU":
                    strActionGroupName = cSlideUDGroup[0];
                    break;
                case "SD":
                    strActionGroupName = cSlideUDGroup[1];
                    break;
                case "SL":
                    strActionGroupName = cSlideRLGroup[0];
                    break;
                case "SR":
                    strActionGroupName = cSlideRLGroup[1];
                    break;
                case "RCC":
                    strActionGroupName = cRollGroup[0];
                    break;
                case "RCW":
                    strActionGroupName = cRollGroup[1];
                    break;
            }

            return strActionGroupName;
        }

        private void drp_KeyframeActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyframeActionsModel selectedAction = (KeyframeActionsModel)drp_KeyframeActions.SelectedItem;
            if (selectedAction != null) //If drp_KeyframeActions has a selectable row
            {
                List<KeyframeActionsModel> lstKeyframeAction = new List<KeyframeActionsModel>();
                lstKeyframeAction = Data_Access_Methods.LoadKeyframeAction(selectedAction.ID);
                if (lstKeyframeAction.Count > 0) //If we have at least one Keyframe Action record
                {
                    //If the selected keyframe does NOT have the No-Move Action
                    if (lstKeyframeAction[0].ActionName != cNMKn)
                    {
                        tbx_KeyframeAction_Name.Text = lstKeyframeAction[0].ActionName;
                        tbx_SendKeyChar.Text = lstKeyframeAction[0].SendKeyChar;
                        num_SendKeyQuantity.Value = lstKeyframeAction[0].SendKeyQuantity;
                        num_SendKeyStepAngleCount.Value = lstKeyframeAction[0].StepAngleCount;

                        //Enable the UI controls that may have been disabled by a previous No-Move Action selection
                        num_SendKeyQuantity.Enabled = true;
                        num_SendKeyStepAngleCount.Enabled = true;
                        btn_KeyframeAction_Update.Enabled = true;
                    }
                    else
                    {
                        //If the selected keyframe has the No-Move Action

                        tbx_KeyframeAction_Name.Text = lstKeyframeAction[0].ActionName;
                        tbx_SendKeyChar.Text = lstKeyframeAction[0].SendKeyChar;
                        num_SendKeyQuantity.Value = 0; //Override - there is no send quantity
                        num_SendKeyStepAngleCount.Value = 0; //Override - there is no step/anle count

                        //Disable the UI controls that are not applicable
                        num_SendKeyQuantity.Enabled = false;
                        num_SendKeyStepAngleCount.Enabled = false;
                        btn_KeyframeAction_Update.Enabled = false;
                    }

                }
                else
                {
                    ClearKeyframeActionControls();
                }
            }
        }

        private void ClearKeyframeActionControls()
        {
            //Clear the Keyframe Move Actions UI control
            //We do this in case there are no keyframe records for the selected project
            drp_KeyframeActions.DataSource = null;
            tbx_KeyframeAction_Name.Clear();
            tbx_SendKeyChar.Clear();
            num_SendKeyQuantity.Value = 1;
            num_SendKeyStepAngleCount.Value = 1;
        }

        private void btn_KeyframeAction_Update_Click(object sender, EventArgs e)
        {
            if (num_SendKeyQuantity.Value > 0 & num_SendKeyStepAngleCount.Value > 0)
            {
                //Fetch the currently selected dropdown selection
                KeyframeActionsModel selectedAction = (KeyframeActionsModel)drp_KeyframeActions.SelectedItem;

                KeyframeActionsModel itemKeyframeAction = new KeyframeActionsModel();
                itemKeyframeAction.ActionName = tbx_KeyframeAction_Name.Text;
                itemKeyframeAction.SendKeyChar = tbx_SendKeyChar.Text;
                itemKeyframeAction.SendKeyQuantity = (int)num_SendKeyQuantity.Value;
                itemKeyframeAction.StepAngleCount = (int)num_SendKeyStepAngleCount.Value;

                Data_Access_Methods.UpdateKeyframeAction(selectedAction.ID, itemKeyframeAction);

                //Repopulate the Keyframe Move Actions list
                var rowIndex = this.dgv_Keyframes_sf.SelectionController.DataGrid.CurrentCell.RowIndex;
                var recordIndex = dgv_Keyframes_sf.TableControl.ResolveToRecordIndex(rowIndex);

                var cellValue_ID = DataGridHelper.GetCellValue(dgv_Keyframes_sf, recordIndex, -1, "ID"); //Get the ID column value
                var intKeyframeID = (int)cellValue_ID;

                //Repopulate the Actions dropdown list
                PopulateKeframeActionsList(intKeyframeID);

                //Reconstruct the Keyframe Summary string and update the keyframe record in the database

                //Fetch a list of all Keyframe Move Actions of the keyframe selected in the datagridview
                List<KeyframeActionsModel> lstKeyframeAction = new List<KeyframeActionsModel>();
                lstKeyframeAction = Data_Access_Methods.LoadKeyframeActionsList((int)cellValue_ID);

                List<KeyframeActionsModel> lstKeyframeActions_Distinct = new List<KeyframeActionsModel>();
                var DistinctItems = lstKeyframeAction.GroupBy(x => x.ActionName).Select(y => y.First());

                //Build the Keyframe display string
                StringBuilder sb = new StringBuilder();
                foreach (KeyframeActionsModel itemAction in DistinctItems)
                {   //Loop over the lstKeyframeAction
                    sb.Append(itemAction.ActionName);
                    sb.Append(itemAction.SendKeyQuantity.ToString());

                    //Calculate the Step/Angle count for the Keyframe display ONLY
                    int intStepAngleResult = (itemAction.SendKeyQuantity * itemAction.StepAngleCount);
                    sb.Append(string.Concat(" (", intStepAngleResult.ToString(), ") "));
                }

                Data_Access_Methods.UpdateKeyframeDisplay(intKeyframeID, sb.ToString());
                PopulateKeyframesDatagrid(false); //Repopulate the Keyframe datagrid - do not change selected row

                //Set these number inputs to zero to protect the user from indvertently changing the action
                num_SendKeyQuantity.Value = 0;
                num_SendKeyStepAngleCount.Value = 0;

                LoadFooterMessage("Keyframe Move Action updated. Adjust your Mandelbulb3D keyframes accordingly.", true, true);
            }
            else
            {
                MessageBoxAdv.Show("The Step Quantity value must be greater than zero.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_KeyframeAction_Delete_Click(object sender, EventArgs e)
        {
            //Fetch the currently selected datagrid row
            var rowIndex = this.dgv_Keyframes_sf.SelectionController.DataGrid.CurrentCell.RowIndex;
            var recordIndex = dgv_Keyframes_sf.TableControl.ResolveToRecordIndex(rowIndex);

            var cellValue_ID = DataGridHelper.GetCellValue(dgv_Keyframes_sf, recordIndex, -1, "ID"); //Get the ID column value
            var intKeyframeID = (int)cellValue_ID;

            if (Data_Access_Methods.GetKeyframeMoveActionsQuantity(m_SelectedProjectID, intKeyframeID) <= 1)
            {
                MessageBoxAdv.Show(string.Concat("You can't delete the only Move Action of a keyframe."), "No Can Do", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            KeyframeActionsModel selectedAction = (KeyframeActionsModel)drp_KeyframeActions.SelectedItem;

            DialogResult result = MessageBoxAdv.Show(string.Concat("Are you sure you want to delete Keyframe Move Action '", selectedAction.ActionName, "'? This cannot be reversed!"), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                Data_Access_Methods.DeleteKeyframeAction(selectedAction.ID);

                //Repopulate the Keyframe Move Actions list
                PopulateKeframeActionsList(intKeyframeID); //intKeyframeID was determined at head of this procedure

                //Reconstruct the Keyframe Display string and update the keyframe record in the database

                //Fetch a list of all Keyframe Move Actions of the keyframe selected in the datagridview
                List<KeyframeActionsModel> lstKeyframeAction = new List<KeyframeActionsModel>();
                lstKeyframeAction = Data_Access_Methods.LoadKeyframeActionsList(intKeyframeID);

                //Build the Keyframe display string
                StringBuilder sb = new StringBuilder();
                foreach (KeyframeActionsModel itemAction in lstKeyframeAction)
                {   //Loop over the lstKeyframeAction
                    sb.Append(itemAction.ActionName);
                    sb.Append(itemAction.SendKeyQuantity.ToString());
                    sb.Append(string.Concat(" {", itemAction.StepAngleCount.ToString(), "} "));
                }

                Data_Access_Methods.UpdateKeyframeDisplay(intKeyframeID, sb.ToString());
                PopulateKeyframesDatagrid(false); //Repopulate the Keyframe datagrid - do not change selected row

                LoadFooterMessage("Keyframe Move Action deleted. Adjust your Mandelbulb3D keyframes accordingly.", true, true);
            }
        }

        private void btn_DeleteKeyframe_Click(object sender, EventArgs e)
        {
            //Fetch the currently selected datagrid row
            var rowIndex = this.dgv_Keyframes_sf.SelectionController.DataGrid.CurrentCell.RowIndex;
            var recordIndex = dgv_Keyframes_sf.TableControl.ResolveToRecordIndex(rowIndex);

            var cellValue_ID = DataGridHelper.GetCellValue(dgv_Keyframes_sf, recordIndex, -1, "ID"); //Get the ID column value
            var cellValue_KFNum = DataGridHelper.GetCellValue(dgv_Keyframes_sf, recordIndex, -1, "KeyframeNum"); //Get the Keyframe Number column value
            var cellValue_Approved = DataGridHelper.GetCellValue(dgv_Keyframes_sf, recordIndex, -1, "KeyframeApproved"); //Get the KeyframeAproved column checkbox value

            try
            {
                if (Convert.ToBoolean(cellValue_Approved))
                {
                    DialogResult result1 = MessageBoxAdv.Show(string.Concat("Keyframe #'", cellValue_KFNum, "' is Approved. Are you sure you want to delete the keyframe?"), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result1 != DialogResult.Yes)
                    {
                        return; //Bail
                    }
                }

                if (recordIndex < 0) //Note: No row relected is a -1 value. A zero value is the first (top most) row selected
                {
                    MessageBoxAdv.Show(string.Concat("Please select a keyframe to be deleted."), "Select Keyframe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; //Bail
                }

                DialogResult result2 = MessageBoxAdv.Show(string.Concat("Are you sure you want to delete Keyframe #", cellValue_KFNum, " and all of its Keyframe Move Actions? This can not be reversed!"), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result2 == DialogResult.Yes)
                {
                    //Delete the keyframe by Keyframe ID
                    Data_Access_Methods.DeleteKeyframeAndKeyframeActions((int)cellValue_ID);

                    //Reclaculate the keyframe numbers since a keframe has just been deleted
                    Data_Access_Methods.RecalculateKeyframeNumberingAllRecords(m_SelectedProjectID);

                    //Recalculate the Frame Count for each keyframe record of the Project ID
                    Data_Access_Methods.RecalculateFrameCountAllRecords(m_SelectedProjectID);

                    //Update and display the next Keyframe number
                    m_NextKeyframeNumber = Data_Access_Methods.GetProjectNextKeyframeNumber(m_SelectedProjectID);
                    mtbx_NextKeyframeNumber.Value = m_NextKeyframeNumber;

                    CalculateAnimationTime(); //Recalc animation times as mm:ss

                    PopulateKeyframesDatagrid(true); //Repopulate the Keyframe datagrid - set selected row to first

                    //Select the top (latest keyframe number) keyframe row
                    dgv_Keyframes_sf.SelectedIndex = 0;

                    if (cbx_MngKFMessages.Checked)
                    {
                        MessageBoxAdv.Show(string.Concat("Keyframe #'", cellValue_KFNum, "' and its Move Actions were deleted? Keyframe numbers have been renumbered to reflect the deleted keyframe."), "Please Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LoadFooterMessage("Keyframe deleted. Adjust your Mandelbulb3D keyframes accordingly.", true, true);
                }
            }
            catch (Exception ex)
            {
                LogException("btn_DeleteKeyframe_Click", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ btn_DeleteKeyframe_Click. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label51_Click(object sender, EventArgs e)
        {
            //Load the last keyframe number (in the database) into the control's value property
            num_EndDeleteKeyframe.Value = Data_Access_Methods.GetProjectLastKeyframeNumber(m_SelectedProjectID);
        }

        private void lbl_KeyframesRange_Start_Click(object sender, EventArgs e)
        {
            //Load the first keyframe number (in the database) into the control's value property
            num_StartDeleteKeyframe.Value = Data_Access_Methods.GetProjectFirstKeyframeNumber(m_SelectedProjectID);
        }

        private void btn_ManageKeyframeCommandGo_Click(object sender, EventArgs e)
        {
            string strSelectedManageKFCommand = drpKeyframeCommands.SelectedItem.ToString();

            //Note: cManageKFCmd_Select is ignnored, of course
            switch (strSelectedManageKFCommand)
            {
                case cManageKFCmd_DeleteRange:
                    DeleteKeyframeRange();
                    break;

                case cManageKFCmd_ReplicateRange:
                    ReplicateKeyframeRange();
                    break;

                case cManageKFCmd_ApproveRange:
                    ApproveKeyframeRange(true);
                    break;

                case cManageKFCmd_DisApproveRange:
                    ApproveKeyframeRange(false);
                    break;

                case cManageKFCmd_FarPlaneRangeUpdate:
                    UpdateFarPlaneRange();
                    break;

                case cManageKFCmd_FramesBetweenRangeUpdate:
                    UpdateFramesBetweenRange();
                    break;

                case cManageKFCmd_MakeMoveSequenceFromRange:
                    MakeMoveSequenceFromRange();
                    break;

                    //Others in the future
            }

            drpKeyframeCommands.SelectedIndex = 0; //Return dropdown to no command selected
        }

        private void DeleteKeyframeRange()
        {
            try
            {
                int intStartKeyframeNum = (int)num_StartDeleteKeyframe.Value;

                int intEndKeyframeNum = (int)num_EndDeleteKeyframe.Value;
                int intHighestKFNumber = Data_Access_Methods.GetHighestKeyframeNumberByProjectID(m_SelectedProjectID);
                //If the user's End Keyframe number is higher that the last keyframe of the project, overwride the user's value
                if (intEndKeyframeNum > intHighestKFNumber) { intEndKeyframeNum = intHighestKFNumber; }

                if (intStartKeyframeNum == intEndKeyframeNum)
                {
                    MessageBoxAdv.Show("The Start and End keyframe values cannot be the same.", "Start/End Values", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (intStartKeyframeNum > intEndKeyframeNum)
                {
                    MessageBoxAdv.Show("The Start keyframe value must be smaller than the End keyframe value.", "Start/End Values", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBoxAdv.Show(string.Concat("Are you sure you want to delete keyframes ", intStartKeyframeNum.ToString(), " through ", intEndKeyframeNum.ToString(), "?"), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //Delete the keyframe by Keyframe ID
                    Data_Access_Methods.DeleteRangeOfKeyframeAndKeyframeActions(m_SelectedProjectID, intStartKeyframeNum, intEndKeyframeNum);

                    //Reclaculate the keyframe numbers since a keframe(s) has just been deleted
                    Data_Access_Methods.RecalculateKeyframeNumberingAllRecords(m_SelectedProjectID);

                    //Recalculate the Frame Count for each keyframe record of the Project ID
                    Data_Access_Methods.RecalculateFrameCountAllRecords(m_SelectedProjectID);

                    //Update and display the next Keyframe number
                    m_NextKeyframeNumber = Data_Access_Methods.GetProjectNextKeyframeNumber(m_SelectedProjectID);
                    mtbx_NextKeyframeNumber.Value = m_NextKeyframeNumber;

                    CalculateAnimationTime(); //Recalc animation times as mm:ss

                    PopulateKeyframesDatagrid(true); //Repopulate the Keyframe datagrid - set selected row to first

                    LoadFooterMessage("Keyframes deleted. Adjust your Mandelbulb3D keyframes according.", true, true);
                }
            }
            catch (Exception ex)
            {
                LogException("DeleteKeyframeRange", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DeleteKeyframeRange. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReplicateKeyframeRange()
        {

            //Try to set focus to the Mandelbulb3D Navigator
            if (BringFocusToMB3DNavigator() == false)
            {
                return; //Bail out of MakeNewKeyframe - there is nothing we can do without Mandelbulb3D assets running
            }

            try
            {
                var NL = Environment.NewLine;

                int intFromKeyframe = (int)num_StartDeleteKeyframe.Value;
                int intToKeyframe = (int)num_EndDeleteKeyframe.Value;
                int intHighestKFNumber = Data_Access_Methods.GetHighestKeyframeNumberByProjectID(m_SelectedProjectID);
                //If the user's End Keyframe number is higher that the last keyframe of the project, overwride the user's value
                if (intToKeyframe > intHighestKFNumber) { intToKeyframe = intHighestKFNumber; }

                //Verify the entries
                if (intToKeyframe < intFromKeyframe) //Example: To:15  From:22
                {
                    MessageBoxAdv.Show("The 'From' Keyframe number must be lower than the 'To' keyframe number. Please correct.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; //Bail
                }

                //Verify the 'From' keyframe entry
                int intFirstKeyframeNumber = Data_Access_Methods.GetProjectFirstKeyframeNumber(m_SelectedProjectID);
                if (intFromKeyframe < intFirstKeyframeNumber)
                {
                    MessageBoxAdv.Show(string.Concat("The 'From' Keyframe number is lower than the project's first keyframe number of ", intFirstKeyframeNumber.ToString(), ". Please correct."), "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; //Bail
                }

                //Verify the 'To' keyframe entry
                int intLastKeyframeNumber = Data_Access_Methods.GetProjectLastKeyframeNumber(m_SelectedProjectID);
                if (intToKeyframe > intLastKeyframeNumber)
                {
                    MessageBoxAdv.Show(string.Concat("The 'To' Keyframe number is higher than the project's last keyframe number of ", intLastKeyframeNumber.ToString(), ". Please correct."), "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; //Bail
                }

                //Determine the dialog message text
                string strConfirmationMessageText = string.Empty;
                if (intFromKeyframe == intToKeyframe)
                {
                    //If replicating just one keyframe
                    strConfirmationMessageText = string.Concat("This will replicate keyframe ", intFromKeyframe.ToString(), ", creating a new keyframe for it and will performing each of the Move Actions of the replicated keyframe.", NL, "Do you want to proceed with the replication of this keyframe and its Move Actions?");
                }
                else
                {
                    //Else replicating more than one keyframe
                    strConfirmationMessageText = string.Concat("This will replicate keyframes ", intFromKeyframe.ToString(), " to ", intToKeyframe.ToString(), ", creating a new keyframe for each and performing the Move Action for each replicated keyframe.", NL, "Do you want to proceed with the replication of these keyframes and the Move Actions of each keyframe?");
                }

                //Get user confirmation
                DialogResult result = MessageBoxAdv.Show(strConfirmationMessageText, "Confirm Replication", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ClearMoveList(); //Be sure the Move List is cleared
                    goto PerformSequenceReplicate;
                }
                else
                {
                    return; //Bail
                }

            PerformSequenceReplicate:

                //Retrieve a list of Keyframe Move Actions for each of the keyframes within the From/To range
                //and send those key actions to the MB3D Navigator, recording the moves into the database as usual

                m_InKeyframeRepeatMode = true;
                int intReplicatedKeyframeQty = 0;
                string DisplaySummary = string.Empty;

                ClearMoveList(); //Make sure any moves are cleared out

                m_InKeyframeRepeatMode = true; //Turn off InKeyframeRepeatMode flag

                SetBusyIndicator(true); //Show the Busy Indicator

                //Loop across the intFromKeyframe and intToKeyframe values
                //Increment idxKeyframe from intFromKeyframe while idxKeyframe is less or equal to intToKeyframe
                for (int idxKeyframeNumber = intFromKeyframe; idxKeyframeNumber <= intToKeyframe; idxKeyframeNumber++)
                {
                    //Get the Keyframe Move Actions for the specified keyframe number
                    List<KeyframeActionsModel> lstKeyframeAction = new List<KeyframeActionsModel>();
                    lstKeyframeAction = Data_Access_Methods.LoadKeyframeActionsList_ForKeyframeReplicate(m_SelectedProjectID, idxKeyframeNumber);
                    if (lstKeyframeAction.Count > 0)
                    {
                        LoadFooterMessage(string.Concat("Replicating keyframe #", idxKeyframeNumber.ToString()), true, false);

                        ClearMoveList(); //Make sure any moves are cleared out.

                        m_InKeyframeRepeatMode = true; //Turn on InKeyframeRepeatMode flag

                        SetBusyIndicator(true); //Show the Busy Indicator

                        //Create a distinct list of the moves of the keyframe to be repeated
                        List<KeyframeActionsModel> lstKeyframeActions_Distinct = new List<KeyframeActionsModel>();
                        var DistinctItems = lstKeyframeAction.GroupBy(x => x.ActionName).Select(y => y.First());

                        //Loop the Distinct moves list to build a visual summary and send the keys
                        StringBuilder sbDisplaySummary = new StringBuilder();

                        Int32 intSendKeyQuantity = 0;
                        Int32 intStepAngleCount = 0;

                        foreach (KeyframeActionsModel itemDistinct in DistinctItems)
                        {
                            intSendKeyQuantity = 0;
                            intStepAngleCount = 0;

                            //Loop the lstKeyframeAction to build the move summary
                            foreach (var itemAction in lstKeyframeAction)
                            {
                                if (itemAction.ActionName == itemDistinct.ActionName)
                                {
                                    intSendKeyQuantity += itemAction.SendKeyQuantity;
                                    intStepAngleCount += itemDistinct.StepAngleCount;
                                }
                            }

                            sbDisplaySummary.Append(string.Concat(itemDistinct.ActionName, intSendKeyQuantity.ToString(), " (", intStepAngleCount.ToString(), ")", NL));
                            DisplaySummary = sbDisplaySummary.ToString();

                            //Update the UI with the MovesList of this loop cycle
                            lbl_MovesList.Text = String.Concat(sbDisplaySummary.ToString());
                            this.Refresh();

                            //Set focus to the MB3D Navigator
                            BringFocusToMB3DNavigator(); //This was validated at the head of this procedure

                            //Now, send the keychar out as many times as specified by intSendKeyQuantity with their StepAngleCount values
                            for (int i = 0; i < intSendKeyQuantity; i++)
                            {
                                m_StepAngleCountDefaultBypass = itemDistinct.StepAngleCount; //This passes the Step/Angle count to the UpdateKeyStepList procedure

                                //Note: A SendKeyChar that has a '+' appended to it will be treated by the SendKeys.Send method as a shift
                                //      character. As such, we do not need to handle the Shift functions of a keyframe SendKeyChar value here.

                                SendKeys.Send(itemDistinct.SendKeyChar); //Send the key, examples: "w", "+w"

                                System.Threading.Thread.Sleep(intKeyEventThreadSleep); //Let's not get ahead of ourselves
                                                                                       //Console.WriteLine(String.Concat($"SENDKEY=", string.Concat(step.Step_SendKey)));

                            }

                            m_HaveMovesToProcess = true;

                        }

                        intReplicatedKeyframeQty += 1; //For the final display to the UI

                    }

                    //Call MakeNewKeyframe
                    MakeNewKeyframe(true, false, false, DisplaySummary, true, string.Concat("Copy of Keyframe #", idxKeyframeNumber.ToString()));

                    ClearMoveList(); //Make sure any moves are cleared out
                }

                m_InKeyframeRepeatMode = false; //Turn off InKeyframeRepeatMode flag
                m_HaveMovesToProcess = false;

                SetBusyIndicator(false); //Hide the Busy Indicator

                if (intReplicatedKeyframeQty > 0)
                {
                    if (intReplicatedKeyframeQty == 1)
                    {
                        LoadFooterMessage(String.Concat("Keyframe replication completed. 1 new keyframe was created."), false, true);
                    }
                    else
                    {
                        LoadFooterMessage(String.Concat("Keyframe replication completed. ", intReplicatedKeyframeQty.ToString(), " new keyframes were created."), false, true);
                    }
                }
                else
                {
                    LoadFooterMessage("No keyframes were found to replicate.", false, false);
                }
            }
            catch (Exception ex)
            {
                LogException("ReplicateKeyframeRange/PerformSequenceReplicate", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ ReplicateKeyframeRange/PerformSequenceReplicate. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApproveKeyframeRange(bool bolApprove)
        {
            try
            {
                int intStartKeyframeNum = (int)num_StartDeleteKeyframe.Value;
                int intEndKeyframeNum = (int)num_EndDeleteKeyframe.Value;
                int intHighestKFNumber = Data_Access_Methods.GetHighestKeyframeNumberByProjectID(m_SelectedProjectID);
                //If the user's End Keyframe number is higher that the last keyframe of the project, overwride the user's value
                if (intEndKeyframeNum > intHighestKFNumber) { intEndKeyframeNum = intHighestKFNumber; }

                //Note: Here the start and end keyframe numbers can be the same value

                if (intStartKeyframeNum > intEndKeyframeNum)
                {
                    MessageBoxAdv.Show("The Start keyframe value must be smaller than the End keyframe value.", "Start/End Values", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (bolApprove)
                {
                    DialogResult result = MessageBoxAdv.Show(string.Concat("This will approve keyframes ", intStartKeyframeNum.ToString(), " through ", intEndKeyframeNum.ToString(), ". Proceed?"), "Confirm Approve", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        //Update the keyframe approve bit by keyframe range
                        Data_Access_Methods.ApproveRangeOfKeyframe(bolApprove, m_SelectedProjectID, intStartKeyframeNum, intEndKeyframeNum);

                        PopulateKeyframesDatagrid(true); //Repopulate the Keyframe datagrid - set selected row to first
                    }
                }
                else
                {
                    DialogResult result = MessageBoxAdv.Show(string.Concat("This will disapprove keyframes ", intStartKeyframeNum.ToString(), " through ", intEndKeyframeNum.ToString(), ". Proceed?"), "Confirm Disapprove", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        //Delete the keyframe by Keyframe ID
                        Data_Access_Methods.ApproveRangeOfKeyframe(bolApprove, m_SelectedProjectID, intStartKeyframeNum, intEndKeyframeNum);

                        PopulateKeyframesDatagrid(true); //Repopulate the Keyframe datagrid - set selected row to first
                    }
                }
            }
            catch (Exception ex)
            {
                LogException("ApproveKeyframeRange", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ ApproveKeyframeRange. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateFarPlaneRange()
        {
            try
            {
                int intFarPlane = (int)mtbx_FarPlane.Value;
                int intStartKeyframeNum = (int)num_StartDeleteKeyframe.Value;
                int intEndKeyframeNum = (int)num_EndDeleteKeyframe.Value;
                int intHighestKFNumber = Data_Access_Methods.GetHighestKeyframeNumberByProjectID(m_SelectedProjectID);
                //If the user's End Keyframe number is higher that the last keyframe of the project, overwride the user's value
                if (intEndKeyframeNum > intHighestKFNumber) { intEndKeyframeNum = intHighestKFNumber; }

                //Note: Here the start and end keyframe numbers can be the same value

                if (intStartKeyframeNum > intEndKeyframeNum)
                {
                    MessageBoxAdv.Show("The Start keyframe value must be smaller than the End keyframe value.", "Start/End Values", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBoxAdv.Show(string.Concat("This will update the Far Plane value of ", intFarPlane.ToString(), " for Keyframes ", intStartKeyframeNum.ToString(), " through ", intEndKeyframeNum.ToString(), ". Proceed?"), "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //Update the Far Plane by keyframe range
                    Data_Access_Methods.UpdateFarPlaneRangeOfKeyframe(intFarPlane, m_SelectedProjectID, intStartKeyframeNum, intEndKeyframeNum);

                    PopulateKeyframesDatagrid(true); //Repopulate the Keyframe datagrid - set selected row to first
                }

            }
            catch (Exception ex)
            {
                LogException("UpdateFarPlaneRange", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ UpdateFarPlaneRange. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateFramesBetweenRange()
        {
            try
            {
                int intFramesBetween = (int)mtbx_FramesBetween.Value;
                int intStartKeyframeNum = (int)num_StartDeleteKeyframe.Value;
                int intEndKeyframeNum = (int)num_EndDeleteKeyframe.Value;
                int intHighestKFNumber = Data_Access_Methods.GetHighestKeyframeNumberByProjectID(m_SelectedProjectID);
                //If the user's End Keyframe number is higher that the last keyframe of the project, overwride the user's value
                if (intEndKeyframeNum > intHighestKFNumber) { intEndKeyframeNum = intHighestKFNumber; }

                //Note: Here the start and end keyframe numbers can be the same value

                if (intStartKeyframeNum > intEndKeyframeNum)
                {
                    MessageBoxAdv.Show("The Start keyframe value must be smaller than the End keyframe value.", "Start/End Values", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBoxAdv.Show(string.Concat("This will update the Frames Between value of ", intFramesBetween.ToString(), " for Keyframes ", intStartKeyframeNum.ToString(), " through ", intEndKeyframeNum.ToString(), ". Proceed?"), "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    SaveAnimationProject(false, false); //Save the project because Frame Between value probably changed

                    //Update the Far Plane by keyframe range
                    Data_Access_Methods.UpdateFramesBetweenRangeOfKeyframe(intFramesBetween, m_SelectedProjectID, intStartKeyframeNum, intEndKeyframeNum);

                    //Recalculate the Total Frames
                    Data_Access_Methods.RecalculateFrameCountAllRecords(m_SelectedProjectID);

                    //Reload the project data to get our re-calculated total frames count onto the UI
                    //Note: LoadProjectData call recalc animation times as mm:ss
                    LoadProjectData();

                    //Repopulate the Keyframe datagrid - do not change the selected row
                    PopulateKeyframesDatagrid(false);
                }

            }
            catch (Exception ex)
            {
                LogException("UpdateFramesBetweenRange", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ UpdateFramesBetweenRange. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MakeMoveSequenceFromRange()
        {
            try
            {
                //Collect the keyframe range data
                int intFromKeyframe = (int)num_StartDeleteKeyframe.Value;
                int intToKeyframe = (int)num_EndDeleteKeyframe.Value;
                int intHighestKFNumber = Data_Access_Methods.GetHighestKeyframeNumberByProjectID(m_SelectedProjectID);
                //If the user's End Keyframe number is higher that the last keyframe of the project, overwride the user's value
                if (intToKeyframe > intHighestKFNumber) { intToKeyframe = intHighestKFNumber; }

                //Verify the entries
                if (intToKeyframe == intFromKeyframe) //Example: To:1  From:1
                {
                    MessageBoxAdv.Show("You must select multiple different keyframes. Please correct.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; //Bail
                }

                //Verify the entries
                if (intToKeyframe < intFromKeyframe) //Example: To:15  From:22
                {
                    MessageBoxAdv.Show("The 'From' Keyframe number must be lower than the 'To' keyframe number. Please correct.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; //Bail
                }

                //Verify the 'From' keyframe entry
                int intFirstKeyframeNumber = Data_Access_Methods.GetProjectFirstKeyframeNumber(m_SelectedProjectID);
                if (intFromKeyframe < intFirstKeyframeNumber)
                {
                    MessageBoxAdv.Show(string.Concat("The 'From' Keyframe number is lower than the project's first keyframe number of ", intFirstKeyframeNumber.ToString(), ". Please correct."), "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; //Bail
                }

                //Verify the 'To' keyframe entry
                int intLastKeyframeNumber = Data_Access_Methods.GetProjectLastKeyframeNumber(m_SelectedProjectID);
                if (intToKeyframe > intLastKeyframeNumber)
                {
                    MessageBoxAdv.Show(string.Concat("The 'To' Keyframe number is higher than the project's last keyframe number of ", intLastKeyframeNumber.ToString(), ". Please correct."), "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; //Bail
                }

                //If we made it this far, open the MakeMoveSequence form
                frmMakeMoveSequence = new frm_MakeMoveSequence(m_SelectedProjectID, intFromKeyframe, intToKeyframe);

                //Check if the child form is already open
                if (System.Windows.Forms.Application.OpenForms.OfType<frm_MakeMoveSequence>().Count() == 0)
                {
                    //Set the parent form of this child window
                    frmMakeMoveSequence.Owner = this;

                    //Callback event
                    frmMakeMoveSequence.MakeMoveSeqWindowClosed += MakeMoveSeqWindowClosed;

                    //Display the Make Sequence form
                    frmMakeMoveSequence.ShowDialog();

                }
                else
                {
                    frmMakeMoveSequence.Focus();
                }

            }
            catch (Exception ex)
            {
                LogException("MakeMoveSequenceFromRange", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ MakeMoveSequenceFromRange. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MakeMoveSeqWindowClosed()
        {
            frmMakeMoveSequence = null;
            PopulateUseSequenceList(); //Re-bind the Move Sequence dropdown list
        }


        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveAnimationProject(false, false); //Not a new project record, no beep
        }

        private void SetBusyIndicator(bool bolBusyIndicatorState)
        {
            lbl_BusyLabel.Visible = bolBusyIndicatorState;
            if (bolBusyIndicatorState)
            {
                lbl_BusyLabel.BringToFront();
            }
            else
            {
                lbl_BusyLabel.SendToBack();
            }
            this.Refresh();
        }

        #endregion

        #region Global and Misc Methods ==========================================

        private void btn_EnableCapture_Click(object sender, EventArgs e)
        {
            dgv_Keyframes_sf.ClearSorting();
            SetCaptureMode(true); //Enable record mode
        }

        private void btn_DisableCapture_Click(object sender, EventArgs e)
        {
            SetCaptureMode(false); //Disable record mode
        }

        private void SetControlsStateForCapture(bool m_EnableCapture)
        {
            if (Data_Access_Methods.GetProjectRecordCount() == 0)
            {
                MessageBoxAdv.Show("You will need to create a new project to use this application.", "Need Project", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!m_EnableCapture == true & mtbx_FarPlane.Value == 0)
                {
                    MessageBoxAdv.Show("Reminder: The Far Plane value is zero.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            //Note: m_EnableCapture comes is as !m_EnableCapture

            //Project Related Controls - disabled while capturing
            drp_ProjectList.Enabled = m_EnableCapture;
            btn_NewProject.Enabled = m_EnableCapture;
            btn_SaveCurrentProject.Enabled = m_EnableCapture;
            btn_DeleteProject.Enabled = m_EnableCapture;
            tbx_AnimationName.Enabled = m_EnableCapture;
            tbx_M3PI_FileLocation.Enabled = m_EnableCapture;
            btn_FindM3PIFile.Enabled = m_EnableCapture;
            tbx_M3A_FileLocation.Enabled = m_EnableCapture;
            btn_FindM3AFile.Enabled = m_EnableCapture;
            tbx_ProjectNotes.Enabled = m_EnableCapture;

            //Project Information Controls - disabled while capturing
            mtbx_SlidingWalkingCount.Enabled = m_EnableCapture;
            mtbx_LookingRollingAngle.Enabled = m_EnableCapture;
            mtbx_FramesBetween.Enabled = m_EnableCapture;
            mtbx_KeyDelay.Enabled = m_EnableCapture;
            mtbx_FrameCount.Enabled = m_EnableCapture;

            //Status Control - disabled while capturing
            mtbx_NextKeyframeNumber.Enabled = m_EnableCapture;
            lbl_RecordingLabel.Visible = !m_EnableCapture;

            //TabControl - disable tabs while capturing
            if (!m_EnableCapture)
            {
                tabControl1.SelectedTab = page_AnimationCopilot;
            }
            page_MoveDesigner.TabEnabled = m_EnableCapture;
            page_Utilities.TabEnabled = m_EnableCapture;
            page_Library.TabEnabled = m_EnableCapture;
            page_Admin.TabEnabled = m_EnableCapture;

            //App Move Sequence button
            btn_UseImmediateSeq.Enabled = !m_EnableCapture;

            //Restore Point Controls - disabled while capturing
            btn_SetRestorePoint.Enabled = m_EnableCapture;
            btn_ClearRestorePoint.Enabled = m_EnableCapture;
            btn_PerformRestorePoint.Enabled = m_EnableCapture;

            //Keyframe Manage controls
            grpKeyframeActions.Enabled = m_EnableCapture;
            grpManageKeyframes.Enabled = m_EnableCapture;

            //Keyframe Stack Datagrid - as set
            dgv_Keyframes_sf.Columns["KeyframeApproved"].AllowEditing = m_EnableCapture;
            dgv_Keyframes_sf.AllowSorting = m_EnableCapture; //Don't allow sorting during capture

            //Misc Controls - disabled while capturing
            btn_StartOver.Enabled = m_EnableCapture;
            btn_SaveToFile.Enabled = m_EnableCapture;

            if (m_EnableCapture)
            {
                tabControl1.SelectedIndex = 0;
            }

            if (!m_EnableCapture == false & m_HaveMovesToProcess == true)
            {
                var NL = Environment.NewLine;
                MessageBoxAdv.Show(string.Concat("You disabled capture after you had made moves that did not become a Mandelbulb3D keyframe.", NL, NL, "To correct this you should pull the most recent Mandlebulb3D keyframe into the Mandelbulb3D Navigator."), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            m_HaveMovesToProcess = false; //Set to false any time the Capture state changes
        }

        private void mtbx_NextKeyframeNumber_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            m_NextKeyframeNumber = (int)mtbx_NextKeyframeNumber.Value; //Capture the new keyframe number
            ClearMoveList(); //Clear MovesList textbox and other
        }

        #endregion

        #region Animation Project Methods ==========================================

        private void btn_NewProject_Click(object sender, EventArgs e)
        {
            var NL = Environment.NewLine;

            DialogResult result = MessageBoxAdv.Show("This clears the form for a new Animation Project and loads default values. Proceed?", "New Project?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                tbx_AnimationName.Clear(); //Clear the Project Name entryfield
                tbx_ProjectNotes.Clear(); //Clear the Project Notes entryfield
                m_NextKeyframeNumber = 1; //Reset the next keyframe number
                mtbx_NextKeyframeNumber.Value = m_NextKeyframeNumber;
                mtbx_FrameCount.Value = 0;
                mtbx_SlidingWalkingCount.Value = cSlideWalkStepCountDefault;
                mtbx_LookingRollingAngle.Value = cLookingRollingAngleDefault;
                mtbx_FramesBetween.Value = cFramesBetweenDefault;
                mtbx_KeyDelay.Value = cKeyDelayDefault;
                mtbx_FarPlane.Value = 0;

                tbx_M3PI_FileLocation.Text = string.Empty;
                tbx_M3A_FileLocation.Text = string.Empty;

                lbl_30FPSTimeCalc.Text = string.Empty;
                lbl_60FPSTimeCalc.Text = string.Empty;

                m_TotalFramesCount = 0; //Reset the frames total count
                mtbx_FrameCount.Value = m_TotalFramesCount;
                CalculateAnimationTime(); //Recalc will result in mm:ss

                lbl_MovesList.Text = String.Empty; //Clear MovesList label
                m_sbMovesList.Clear(); //Clear MovesList stringbuilder
                m_MovesList = string.Empty; //Clear Moves List
                m_AutoSaveCount = 0; //Reset Auto Save counter
                m_KeysStack = string.Empty; //Clear strKeysList
                ClearKeyStack();

                m_MoveGroupTrackerDic.Clear(); //Clear the Current Move List dictionary

                //Reset the ShiftKeyActive switch and UI
                m_ShiftKeyActive = false;
                lbl_ShiftIndicator.Visible = m_ShiftKeyActive;

                //Note: Don't change the drp_AutoLastMove settings

                drp_UseSequenceList.SelectedItem = null; //Deselect the project list

                //This is an important setting
                drp_ProjectList.SelectedItem = null;
                drp_ProjectList.SelectedIndex = -1;

                //Give the project a name
                Random rnd = new Random();
                int rNum = rnd.Next(99);
                tbx_AnimationName.Text = string.Concat("Unnamed Project ", rNum.ToString());

                //Call the project save sub to get this new project into the database
                //This also repopulates the project dropdown list and selects the new project record
                SaveAnimationProject(true, false); //Is a new project record, no beep

                //Prepare a message for the new project
                StringBuilder sv = new StringBuilder();
                m_sbMovesList.Append(string.Concat("Be sure to modify the various entries of this new project to reflect the Mandelbulb3D application settings.", NL, NL));
                m_sbMovesList.Append(string.Concat("New Project Checklist:", NL));
                m_sbMovesList.Append(string.Concat("1. Provide Project Name and Description", NL));
                m_sbMovesList.Append(string.Concat("2. Set Mandelbulb3D File Locations", NL));
                m_sbMovesList.Append(string.Concat("3. Set Sliding/Walking Step Count", NL));
                m_sbMovesList.Append(string.Concat("4. Set Looking/Rolling Angle", NL));
                m_sbMovesList.Append(string.Concat("5. Set Frames Between", NL));
                m_sbMovesList.Append(string.Concat("6. Set Far Plane value", NL));
                m_sbMovesList.Append("7. Update the project and begin keyframing.");

                MessageBoxAdv.Show(m_sbMovesList.ToString(), "New Project", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_DeleteProject_Click(object sender, EventArgs e)
        {
            DeleteAnimationProject();
        }

        private void DeleteAnimationProject()
        {
            var NL = Environment.NewLine;

            if (drp_ProjectList.SelectedItem != null)
            {
                ProjectListModel selectedProject = (ProjectListModel)drp_ProjectList.SelectedItem; //Get the selected project item
                if (selectedProject.ID >= 0)
                {
                    DialogResult result = MessageBoxAdv.Show(string.Concat("Are you sure you want to delete animation project '", selectedProject.Project_Name, "'?", NL, "This will also delete all keyframe and keyframe action records."), "Confirm Delete?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            //Delete Project's Keyframe and Keyframe Move Actions
                            Data_Access_Methods.DeleteAllKeyframeAndKeyframeActions(selectedProject.ID);

                            //Delete the Project record
                            Data_Access_Methods.DeleteAnimationProject(selectedProject.ID);
                        }
                        catch (Exception ex)
                        {
                            LogException("DeleteAnimationProject", ex); //Log this error
                            MessageBoxAdv.Show(ex.Message, "Error @ DeleteAnimationProject. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //Repopulate the project dropdown
                        //Note: Keyframe and Keyframe Move Actions also get reloaded
                        m_IsAppStarting = true; //Treat this like an app start so that LoadProjectData fetches the last saved
                        PopulateProjectList(-1); //Populate the Project dropdown without a pointer
                        LoadProjectData(); //LoadProjectData also re-loads and positions the project list
                        PopulateKeyframesDatagrid(true); //Populate the Keyframes list and select the first datagrid row
                    }
                }
            }
        }

        private void btn_SaveCurrentProject_Click(object sender, EventArgs e)
        {
            SaveAnimationProject(false, false); //Not a new project record, no beep
        }

        private void SaveAnimationProject(bool isNewRecord, bool bolBeepSound)
        {
            //If there are no project records (such as new install) be sure we handle this as a new project record
            if (Data_Access_Methods.GetProjectRecordCount() == 0)
            {
                isNewRecord = true;
            }

            if (tbx_AnimationName.Text.Length == 0)
            {
                DialogResult result = MessageBoxAdv.Show("Please provide a project name.", "Project Name Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    return; //Bail
                }
            }
            try
            {
                lbl_ProjectSavingIndicator.Visible = true;
                this.Refresh();

                //Collect the project data into a collection object
                Collection<ProjectModel> colProjectData = new Collection<ProjectModel>();
                colProjectData.Add(new ProjectModel());

                colProjectData[0].Project_Name = tbx_AnimationName.Text;
                colProjectData[0].Project_Notes = tbx_ProjectNotes.Text;
                colProjectData[0].SlideWalk_StepCount = (int)mtbx_SlidingWalkingCount.Value;
                colProjectData[0].LookingRolling_Angle = (int)mtbx_LookingRollingAngle.Value;
                colProjectData[0].Frames_Between = (int)mtbx_FramesBetween.Value;
                colProjectData[0].Key_Delay = (int)mtbx_KeyDelay.Value;
                colProjectData[0].Total_Frames_Count = (int)mtbx_FrameCount.Value;
                colProjectData[0].Far_Plane = mtbx_FarPlane.Value.ToString();
                colProjectData[0].Animation_Length_30 = lbl_30FPSTimeCalc.Text;
                colProjectData[0].Animation_Length_60 = lbl_60FPSTimeCalc.Text;
                colProjectData[0].M3PIFileLocation = tbx_M3PI_FileLocation.Text;
                colProjectData[0].M3AFileLocation = tbx_M3A_FileLocation.Text;

                if (isNewRecord == false) //If not a new record, do a database update
                {
                    ProjectListModel selectedProject = (ProjectListModel)drp_ProjectList.SelectedItem; //Get the selected project item
                    if (selectedProject.ID >= 0)
                    {
                        colProjectData[0].ID = selectedProject.ID; //Get the ID of the selected project into the list object

                        //Grab the dropdown's current index so that we can restore
                        int drpDownIndex = drp_ProjectList.SelectedIndex;

                        //A project is selected from the drp_ProjectList dropdown, so this will be a record UPDATE
                        Data_Access_Methods.UpdateProjectData(colProjectData);

                        //Repopulate the dropdown (the project name may have changed)
                        PopulateProjectList(colProjectData[0].ID);
                    }
                }
                else //A new record, so do a database INSERT
                {
                    //Insert the record into the database returning the new record's ID value
                    int NewRecordID = Data_Access_Methods.InsertProjectData(colProjectData);

                    //Repopulate the dropdown (there's a new project or the project name was changed)
                    PopulateProjectList(NewRecordID);
                }

                //Update the UI to show the project's last saved date/time
                DisplayProjectLastSavedDateTime();

                if (bolBeepSound)
                {
                    System.Media.SystemSounds.Asterisk.Play();
                }

                m_UnsavedChanges = false; //Turn off the UnsavedChanges flag

                lbl_ProjectSavingIndicator.Visible = false;
                this.Refresh();

            }
            catch (Exception ex)
            {
                LogException("SaveAnimationProject", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ SaveAnimationProject. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayProjectLastSavedDateTime()
        {
            ProjectListModel selectedProject = (ProjectListModel)drp_ProjectList.SelectedItem; //Get the selected project item
            if (selectedProject != null)
            {
                if (selectedProject.ID >= 0)
                {
                    //Fetch the project's last saved date/time and display it on the UI
                    DateTime dteLastSavedDateTime = Data_Access_Methods.GetProjectLastSavedDateTime(m_SelectedProjectID);
                    lbl_ProjectAsOfDateTime.Text = String.Concat("Project Last Saved: ", dteLastSavedDateTime.ToString());
                }
            }
        }

        #endregion

        #region Save Project to File Methods ==========================================

        private void btn_SaveToFile_Click(object sender, EventArgs e)
        {
            if (tbx_AnimationName.Text.Length == 0)
            {
                DialogResult result = MessageBoxAdv.Show("Would you like to name this animation project before saving?", "Name Project?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    return; //Bail
                }
            }
            try
            {
                bool SortAscending = false;
                DialogResult result = MessageBoxAdv.Show("Would you like the keyframe list to be sorted in ascending order, i.e., lowest to highest keyframe number?", "Sort Descending?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SortAscending = true;
                }

                System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.Title = "Save Project Keyframes to a File";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog1.FileName.ToString());
                    file.WriteLine("Mandelbulb3D Animation Copilot");
                    file.WriteLine("------------------------------");

                    string strDateTime = (String.Concat(DateTime.Now.ToShortDateString(), " @ ", DateTime.Now.ToShortTimeString()));
                    file.WriteLine(strDateTime);

                    file.WriteLine("");

                    file.WriteLine("Project Info:");
                    file.WriteLine(string.Concat("   Name:", tbx_AnimationName.Text));
                    file.WriteLine(string.Concat("   Notes:", tbx_ProjectNotes.Text));
                    file.WriteLine(string.Concat("   M3P/I File::", tbx_M3PI_FileLocation.Text));
                    file.WriteLine(string.Concat("   M3A File::", tbx_M3A_FileLocation.Text));
                    file.WriteLine(string.Concat("   ", lbl_ProjectAsOfDateTime.Text)); //Last saved (includes prefix text)

                    file.WriteLine("");

                    file.WriteLine("Project Settings:");
                    file.WriteLine(string.Concat("   Next Frame Number:", mtbx_NextKeyframeNumber.Value.ToString()));
                    file.WriteLine(string.Concat("   Default Sliding/Walking Steps:", mtbx_SlidingWalkingCount.Value.ToString()));
                    file.WriteLine(string.Concat("   Default Looking/Rolling Angle:", mtbx_LookingRollingAngle.Value.ToString()));
                    file.WriteLine(string.Concat("   Default Frames Between:", mtbx_FramesBetween.Value.ToString()));
                    file.WriteLine(string.Concat("   Total Frames Count:", mtbx_FrameCount.Value.ToString()));
                    file.WriteLine(string.Concat("   Estimated Length @ 30FPS:", lbl_30FPSTimeCalc.Text));
                    file.WriteLine(string.Concat("   Estimated Length @ 60FPS::", lbl_60FPSTimeCalc.Text));
                    file.WriteLine(string.Concat("   Far Plane:", mtbx_FarPlane.Value.ToString()));

                    file.WriteLine("");

                    file.WriteLine("Keyframes:");

                    string strKeyframeTypes = (String.Concat("   Types: Manual='", cKeyStackLineChar_Manual, "' Repeat='", cKeyStackLineChar_Repeat, "' Move Seq='", cKeyStackLineChar_Sequence, "' Relicate Seq='", cKeyStackLineChar_Replicate, "'"));
                    file.WriteLine(strKeyframeTypes);

                    string strKeyframeLegend = (String.Concat("   Number,Type,Moves,Frames Between,Frame Count,Far Plane,Approved,Note")); //The legend
                    file.WriteLine(strKeyframeLegend);

                    List<KeyframeModel> lstKeyframes = new List<KeyframeModel>();
                    lstKeyframes = Data_Access_Methods.LoadKeyframes(m_SelectedProjectID, SortAscending);

                    string strKeyframe;
                    foreach (KeyframeModel item in lstKeyframes)
                    {
                        strKeyframe = string.Concat(item.KeyframeNum.ToString().TrimEnd(), ",",
                                                    item.KeyframeType.TrimEnd(), ",",
                                                    item.KeyframeDisplay.TrimEnd(), ",",
                                                    item.FramesBetween.ToString().TrimEnd(), ",",
                                                    item.FrameCount.ToString().TrimEnd(), ",",
                                                    item.FarPlane.ToString().TrimEnd(), ",",
                                                    (item.KeyframeApproved) ? "Y" : "N", ",",
                                                    item.KeyframeNote.ToString());

                        strKeyframe = strKeyframe.Replace(" ", ""); //Replace spaces
                        strKeyframe = strKeyframe.Replace(System.Environment.NewLine, ""); //Replace line terminations if any
                        strKeyframe = string.Concat("   ", strKeyframe); //Indent the keyframe line

                        file.WriteLine(strKeyframe);
                    }

                    file.Close();

                    LoadFooterMessage(string.Concat("File saved to ", saveFileDialog1.FileName.ToString()), false, false);

                }

            }
            catch (Exception ex)
            {
                LogException("btn_SaveToFile_Click", ex); //Log this error
                MessageBoxAdv.Show(string.Concat("There was an error saving the project keyframes to a file. Error was logged.", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int GetStepAngleCountValue_FromMainForm(string Step_Name)
        {
            switch (Step_Name)
            {
                case cWFn or cWRn or cSUn or cSDn or cSLn or cSRn:
                    return (int)mtbx_SlidingWalkingCount.Value;
                case cLUn or cLDn or cLLn or cLRn or cRCCn or cRCWn:
                    return (int)mtbx_LookingRollingAngle.Value;
                default:
                    return 0;
            }
        }

        #endregion

        #region Animation Copilot Methods ==========================================

        private void tbx_AnimationName_TextChanged(object sender, EventArgs e)
        {
            m_UnsavedChanges = true; //Turn on the UnsavedChanges flag
        }

        private void tbx_AnimationName_Leave(object sender, EventArgs e)
        {
            SaveAnimationProject(false, false); //Save the project
        }

        private void mtbx_SlidingWalkingCount_TextChanged(object sender, EventArgs e)
        {
            m_UnsavedChanges = true; //Turn on the UnsavedChanges flag
        }

        private void mtbx_LookingRollingAngle_TextChanged(object sender, EventArgs e)
        {
            m_UnsavedChanges = true; //Turn on the UnsavedChanges flag
        }

        private void mtbx_FramesBetween_TextChanged(object sender, EventArgs e)
        {
            m_UnsavedChanges = true; //Turn on the UnsavedChanges flag
        }

        private void mtbx_KeyDelay_TabStopChanged(object sender, EventArgs e)
        {
            m_UnsavedChanges = true; //Turn on the UnsavedChanges flag
        }

        private void mtbx_FrameCount_TextChanged(object sender, EventArgs e)
        {
            m_UnsavedChanges = true; //Turn on the UnsavedChanges flag

            m_TotalFramesCount = (int)mtbx_FrameCount.Value; //Set the frames total count to the entry
            CalculateAnimationTime(); //Recalc will result in mm:ss
        }

        private void mtbx_FarPlane_TextChanged(object sender, EventArgs e)
        {
            m_UnsavedChanges = true; //Turn on the UnsavedChanges flag
        }

        private void mtbx_NextKeyframeNumber_TextChanged(object sender, EventArgs e)
        {
            //The TextChanged event on this control should suffice for changes that occur
            //from keyevents initiated by Manual, Repeat or MoveSeq key events.
            m_UnsavedChanges = true; //Turn on the UnsavedChanges flag
        }

        private void drp_UseSequenceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Bail if a move sequence is not selected
            if (drp_UseSequenceList.SelectedIndex < 0)
            {
                lbl_MoveSequenceDesc.Text = string.Empty;
                return; //Bail
            }

            //Check if the child form to display Move Step Info has been created (is open)
            if (frmShowMoveSequenceInfo != null)
            {
                //Close the form if its open (because the user changed the selected Move Sequence)
                frmShowMoveSequenceInfo.Close();
            }
        }

        private void btn_ShowMoveSequenceInfo_Click(object sender, EventArgs e)
        {
            ShowMoveSequenceInfo();
        }

        private void ShowMoveSequenceInfo()
        {
            //Fetch the data for the selected move sequence
            MoveSequenceModel selectedSeq = (MoveSequenceModel)drp_UseSequenceList.SelectedItem;

            //If we have Move Steps
            if (selectedSeq != null)
            {
                //Open the frm_ShowMoveSequenceInfo form
                frmShowMoveSequenceInfo = new frm_ShowMoveSequenceInfo((int)selectedSeq.ID, selectedSeq.SequenceName, selectedSeq.SequenceDesc);

                //Check if the child form is already open
                if (System.Windows.Forms.Application.OpenForms.OfType<frm_ShowMoveSequenceInfo>().Count() == 0)
                {
                    //Set the parent form of this child window
                    frmShowMoveSequenceInfo.Owner = this;

                    //Display the form but not as a dialog
                    frmShowMoveSequenceInfo.Show();
                }
                else
                {
                    frmShowMoveSequenceInfo.Focus();
                }
            }
            else
            {
                MessageBoxAdv.Show("Please select a Move Sequence.", "Select Move Sequence", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btn_UseImmediateSeq_Click(object sender, EventArgs e)
        {
            ApplyImmediateSeq();
        }

        private void ApplyImmediateSeq()
        {

            //Try to set focus to the Mandelbulb3D Navigator
            if (BringFocusToMB3DNavigator() == false)
            {
                return; //Bail out of MakeNewKeyframe - there is nothing we can do without Mandelbulb3D assets running
            }

            //Bail if a sequence is not selected
            if (drp_UseSequenceList.SelectedIndex < 0)
            {
                LoadFooterMessage("Select a Move Sequence.", true, false);
                return; //Bail
            }

            if (m_HaveMovesToProcess)
            {
                LoadFooterMessage("Can't do that - you have moves pending.", false, true);
                return; //Bail
            }

            int SlidingWalkingCount = (int)mtbx_SlidingWalkingCount.Value; //Get the project's Sliding/Walking Count
            int LookingRollingAngle = (int)mtbx_LookingRollingAngle.Value; //Get the project's Look/Rolling Angle

            if (SlidingWalkingCount <= 0)
            {
                mtbx_SlidingWalkingCount.Select();
                LoadFooterMessage("Check that the Sliding/Walking step count is greater than 0", true, true);
                return; //Bail
            }

            if (LookingRollingAngle <= 0)
            {
                mtbx_LookingRollingAngle.Select();
                LoadFooterMessage("Check that the Looking/Rolling step angle is greater than 0", true, true);
                return; //Bail
            }

            if (m_EnableCapture == false)
            {
                MessageBoxAdv.Show(string.Concat("Capturing is NOT enabled. Please enable capturing mode to apply a Move Sequence"), "Can't Proceed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                //Fetch the data for the selected move sequence
                MoveSequenceModel selectedSeq = (MoveSequenceModel)drp_UseSequenceList.SelectedItem;
                List<MoveSequenceModel> lstMoveSeq = Data_Access_Methods.LoadMoveSeqenceByParentID(selectedSeq.ID);

                //Fetch the MOVE STEPS for the selected move sequence
                List<StepSequenceModel> lstStepsList = Data_Access_Methods.LoadSequenceStepList(lstMoveSeq[0].ID);

                //If we have Move Steps
                if (lstStepsList.Count > 0)
                {

                    var NL = Environment.NewLine;
                    int CountAngleValue = 1;
                    bool CanMakeNewKeframe = false;
                    int LoopIndex = 0;

                    m_HaveMovesToProcess = true;
                    m_IsMoveSequence = true;
                    ClearMoveList(); //Make sure any moves are cleared out
                    SetBusyIndicator(true); //Show the Busy Indicator

                    //Set focus to the MB3D Navigator
                    BringFocusToMB3DNavigator(); //This was validated at the head of this procedure

                    //Loop the Distinct moves list to build a visual summary and send the keys
                    StringBuilder sbDisplaySummary = new StringBuilder();

                    //Loop across the lstStepsList
                    foreach (StepSequenceModel MoveStep in lstStepsList)
                    {
                        //Note: We don't care about the Step_ID here

                        //Build the move display summary
                        //Note: The "or" in the case statements below is c# 9.
                        switch (MoveStep.Step_Name)
                        {
                            case cWFn or cWRn or cSUn or cSDn or cSLn or cSRn:
                                CountAngleValue = (MoveStep.Step_SendKeyQty * SlidingWalkingCount);
                                break;
                            case cLUn or cLDn or cLLn or cLRn or cRCCn or cRCWn:
                                CountAngleValue = (MoveStep.Step_SendKeyQty * LookingRollingAngle);
                                break;
                        }
                        sbDisplaySummary.Append(string.Concat(MoveStep.Step_Name, MoveStep.Step_SendKeyQty.ToString(), " (", CountAngleValue.ToString(), ")", NL));

                        //Update the UI with the MovesList of this loop cycle
                        lbl_MovesList.Text = sbDisplaySummary.ToString();
                        this.Refresh();

                        //Loop for the number of times specified by Step_SendKeyQty
                        for (int i = 0; i < MoveStep.Step_SendKeyQty; i++)
                        {
                            m_StepAngleCountDefaultBypass = (int)MoveStep.Step_Count; //This passes the Step/Angle count to the UpdateKeyStepList procedure

                            //Note: A SendKeyChar that has a '+' appended to it will be treated by the SendKeys.Send method as a shift
                            //      character. As such, we do not need to handle the Shift functions of a keyframe SendKeyChar value here.

                            SendKeys.Send(MoveStep.Step_SendKey); //Send the key, examples: "w", "+w"

                            System.Threading.Thread.Sleep(intKeyEventThreadSleep); //Let's not rush things
                                                                                   //Console.WriteLine(String.Concat($"SENDKEY=", string.Concat(step.Step_SendKey)));
                        }

                        //Look ahead in the lstStepsList collection to see if the next element is a different Step_Group number.
                        //If it is, that indicates that the steps of the current group are complete and we can make this a
                        //keyframe and advance to the next group of move steps.
                        //Note: The collection in lstStepsList comes in as sorted by Step_Group

                        CanMakeNewKeframe = false; //Assume we are not at the end of a group
                        try
                        {
                            //Look ahead to see if we have more steps in the group
                            if (lstStepsList[LoopIndex + 1].Step_Group != (int)MoveStep.Step_Group)
                            {
                                //If the group has ended, then set the MakeNewKeyframe flag to true
                                CanMakeNewKeframe = true;
                            }
                        }
                        catch
                        {
                            //If we throw an error because there is not a next element of lstStepsList
                            //then set the MakeNewKeyframe flag to true.
                            CanMakeNewKeframe = true;
                        }

                        if (CanMakeNewKeframe)
                        {
                            //Call MakeNewKeyframe
                            MakeNewKeyframe(false, true, false, sbDisplaySummary.ToString(), true, string.Concat("Move Sequence: ", selectedSeq.SequenceName));
                            ClearMoveList(); //Make sure any moves are cleared out
                            sbDisplaySummary.Clear();
                            this.Refresh();
                        }

                        LoopIndex += 1;

                    }

                    //All of the Move Steps have been processed, so clean up and end this procedure
                    m_HaveMovesToProcess = false;
                    m_IsMoveSequence = false;
                    SetBusyIndicator(false); //Hide the Busy Indicator
                }
            }
            catch (Exception ex)
            {
                LogException("ApplyImmediateSeq", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ ApplyImmediateSeq. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbx_AnimationName_Enter(object sender, EventArgs e)
        {
            SetCaptureMode(false); //When user enters tbx_AnimationName drop out of record mode
        }

        private void mtbx_FarPlane_Enter(object sender, EventArgs e)
        {
            SetCaptureMode(false); //When user enters mtbx_FarPlane drop out of record mode
        }

        private void mtbx_SlidingWalkingCount_Enter(object sender, EventArgs e)
        {
            SetCaptureMode(false); //When user enters mtbx_SlidingWalkingCount drop out of record mode
        }

        private void mtbx_KeyDelay_TextChanged(object sender, EventArgs e)
        {
            intKeyEventThreadSleep = (int)mtbx_KeyDelay.Value;
        }

        private void mtbx_FramesBetween_Enter(object sender, EventArgs e)
        {
            SetCaptureMode(false); //When user enters  mtbx_FramesBetween drop out of record mode
        }

        private void mtbx_LookingRollingAngle_Enter(object sender, EventArgs e)
        {
            SetCaptureMode(false); //When user enters mtbx_LookingRollingAngle drop out of record mode
        }

        private void tbx_KeyStack_Enter(object sender, EventArgs e)
        {
            SetCaptureMode(false); //When user enters tbx_KeyStack drop out of record mode
        }

        private void mtbx_KeyDelay_Enter(object sender, EventArgs e)
        {
            SetCaptureMode(false); //When user enters mtbx_KeyDelay drop out of record mode
        }

        private void btn_StartOver_Click(object sender, EventArgs e)
        {
            ClearProject(false);
        }

        private void ClearProject(bool bolIsFullClear)
        {
            //Check if the project have keyframes
            if (Data_Access_Methods.GetProjectKeyframeQuantity(m_SelectedProjectID) <= 0)
            {
                MessageBoxAdv.Show("This project does not have any keyframes yet.", "Nothing To Do", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ProjectListModel selectedProject = (ProjectListModel)drp_ProjectList.SelectedItem; //Get the selected project item
            m_SelectedProjectID = selectedProject.ID; //Update the global m_SelectedProjectID var
            string strSelectedProjectName = selectedProject.Project_Name; //Update the global m_SelectedProjectID var

            DialogResult result1 = MessageBoxAdv.Show(string.Concat("This function is intended to restart a project. It will delete all project Keyframes for project '", strSelectedProjectName, "'. This action cannot be undone! Proceed?"), "Confirm Start Over", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
            {
                DialogResult result2 = MessageBoxAdv.Show(string.Concat("Are you VERY sure? This will DELETE all of the Keyframes for project '", strSelectedProjectName, "'. This action cannot be undone!"), "Confirm Start Over", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result2 == DialogResult.Yes)
                {
                    ClearKeyStack();
                    m_NextKeyframeNumber = 1; //Reset the keyframe number
                    mtbx_NextKeyframeNumber.Value = m_NextKeyframeNumber;

                    m_TotalFramesCount = 0; //Reset the frames total count
                    mtbx_FrameCount.Value = m_TotalFramesCount;
                    CalculateAnimationTime(); //Recalc will result in mm:ss

                    lbl_MovesList.Text = String.Empty; //Clear MovesList label
                    m_sbMovesList.Clear(); //Clear MovesList stringbuilder
                    m_MovesList = string.Empty; //Clear Moves List
                    m_AutoSaveCount = 0; //Reset Auto Save counter
                    m_KeysStack = string.Empty; //Clear strKeysList
                    m_MoveGroupTrackerDic.Clear(); //Clear the Current Move List dictionary

                    //Reset the ShiftKeyActive switch and UI
                    m_ShiftKeyActive = false;
                    lbl_ShiftIndicator.Visible = m_ShiftKeyActive;
                    m_AutoSaveCount = 0; //Reset Auto Save counter

                    lbl_MovesList.Text = String.Empty; //Clear MovesList label
                    m_sbMovesList.Clear(); //Clear MovesList stringbuilder
                    m_MovesList = string.Empty; //Clear Moves List

                    //Reset the Restore Point
                    m_RestorePointDic.Clear();
                    btn_SetRestorePoint.ForeColor = Color.White;

                    //Note: Don't change the drp_AutoLastMove settings

                    //This SQL call deletes ALL keyframe records for the selected project,
                    //and ALL of the Keyframe Move Actions for the deleted Keframes
                    Data_Access_Methods.DeleteAllKeyframeAndKeyframeActions(m_SelectedProjectID);

                    PopulateKeyframesDatagrid(true); //Repopulate the Keyframe list (although there are no keyframe records)
                }
            }

            if (bolIsFullClear)
            {
                //Reload the defaul values
                mtbx_SlidingWalkingCount.Value = cSlideWalkStepCountDefault;
                mtbx_LookingRollingAngle.Value = cLookingRollingAngleDefault;
                mtbx_FramesBetween.Value = cFramesBetweenDefault;
                mtbx_KeyDelay.Value = cKeyDelayDefault;
            }
            else
            {
                //Don't clear or reset the following:
                //tbx_AnimationName entry
                //mtbx_FarPlane
                //mtbx_SlidingWalkingCount
                //mtbx_LookingRollingAngle
                //mtbx_FramesBetween
                //mtbx_KeyDelay
                //AutoMove entries
            }

        }

        private void mtbx_FrameCount_KeyUp(object sender, KeyEventArgs e)
        {
            ClearMoveList();
        }

        private void ClearMoveList()
        {
            lbl_MovesList.Text = String.Empty; //Clear MovesList label
            m_sbMovesList.Clear(); //Clear MovesList stringbuilder
            m_MovesList = string.Empty; //Clear Moves List
            ClearKeyStack(); //Clear the keystack variable
            m_MoveGroupTrackerDic.Clear(); //Clear the Current Moves dictionary
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            //No code here at this time
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (Data_Access_Methods.GetProjectRecordCount() == 0)
            {
                MessageBoxAdv.Show("You will need to create a new project to use this application.", "Need Project", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool ValidateMandelbulb3DRunning()
        {
            //Note: We can't use the MB3D window caption because the window caption changes - not a good design, but that's how it is

            //Get the handle of the Mandelbulb3D Navigator
            IntPtr hWnd = FindWindow(cMB3DMainClassName, null);

            //If the Mandelbulb3D Navigator window is NOT found
            if (hWnd == IntPtr.Zero)
            {
                lbl_MB3D_AppRun_Warn.Visible = true;
                lbl_MB3D_AppRun_Warn.BringToFront();

                var NL = Environment.NewLine;
                MessageBoxAdv.Show(string.Concat("This application is an animation helper toolset for the Mandelbulb3D application", NL, " and therefore requires that the Mandelbulb3D application be running."), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                lbl_MB3D_AppRun_Warn.Visible = false;
                lbl_MB3D_AppRun_Warn.SendToBack();
                return true;
            }
        }

        private bool ValidateJoyToKeyRunning()
        {
            if (FindWindowByStartsWithCaption(cJoyToKeyStartCaption) == false)
            {
                lbl_JTK_AppRun_Warn.Visible = true;
                lbl_JTK_AppRun_Warn.BringToFront();

                var NL = Environment.NewLine;
                MessageBoxAdv.Show(string.Concat("This application requires the JoyToKey application to map a hand-held game controller or standard", NL, "PC keboard to the keys used for Mandlebulb3D animation. See the 'About' tab of this", NL, "application for instructions running the JoyToKey application with the appropriate configuration."), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                lbl_JTK_AppRun_Warn.Visible = false;
                lbl_JTK_AppRun_Warn.SendToBack();
                return true;
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

        private bool BringFocusToMB3DNavigator()
        {
            //Get the handle of the Mandelbulb3D Navigator
            IntPtr hWnd = FindWindow(cMB3DNavigatorClassName, null);

            //If the Mandelbulb3D Navigator window is NOT found
            if (hWnd == IntPtr.Zero)
            {
                MessageBoxAdv.Show("This application requires that the Mandelbulb3D application be running with its Navigator and Animation windows open.", "Critical", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; //Exit method and return false
            }
            else
            {
                ShowWindow(hWnd, 9);
                //Bring the application to focus
                SetForegroundWindow(hWnd);
                return true;
            }
        }

        private bool BringFocusToMB3DAnimator()
        {
            //Get the handle of the Mandelbulb3D Animator
            IntPtr hWnd = FindWindow(cMB3DAnimatorClassName, null);

            //If the Mandelbulb3D Animation window is NOT found
            if (hWnd == IntPtr.Zero)
            {
                MessageBoxAdv.Show("This application requires that the Mandelbulb3D application be running with its Navigator and Animation windows open.", "Critical", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; //Exit method and return false
            }
            else
            {
                ShowWindow(hWnd, 9);
                //Bring the application to focus
                SetForegroundWindow(hWnd);
                return true;
            }
        }

        private void BringFocusToThisApplication()
        {
            this.Focus(); //Set focus to this application
        }

        private void ClearKeyStack()
        {
            //Walking
            m_WFCount = 0; m_WRCount = 0;
            //Looking
            m_LUCount = 0; m_LDCount = 0; m_LLCount = 0; m_LRCount = 0;
            //Sliding
            m_SUCount = 0; m_SDCount = 0; m_SLCount = 0; m_SRCount = 0;
            //Rotating
            m_RCCCount = 0; m_RCWCount = 0;

            m_KeysStack = string.Empty; //Clear m_KeysStack
        }

        private void MakeNewKeyframe(bool bolIsRepeatMove, bool bolIsSequenceMove, bool bolIsNoActionMove, string strMoveSummary, bool bolBypassBusyIndicator, string strKeyframeNote)
        {
            //Try to set focus to the Mandelbulb3D Navigator
            if (BringFocusToMB3DNavigator() == false)
            {
                return; //Bail out of MakeNewKeyframe - there is nothing we can do without Mandelbulb3D assets running
            }

            var NL = Environment.NewLine;
            string m_MovesList = string.Empty;

            try
            {
                //Bail this key event if there are no moves to process
                if (m_HaveMovesToProcess == false) { return; }

                if (bolBypassBusyIndicator == false)
                {
                    SetBusyIndicator(true); //Show the Busy Indicator unless bupassed with bolBypassBusyIndicator=true
                }

                ClearKeyStack();

                //Calculate and display frames total count
                int intFramesBetween = (int)mtbx_FramesBetween.Value;
                m_TotalFramesCount = (m_TotalFramesCount += intFramesBetween);
                mtbx_FrameCount.Value = m_TotalFramesCount;
                CalculateAnimationTime();

                //Determine the KeyStack line character
                string strKeyStackLineChar = cKeyStackLineChar_Manual;
                if (m_IsMoveSequence)
                {
                    strKeyStackLineChar = cKeyStackLineChar_Sequence;
                }
                else if (bolIsRepeatMove)
                {
                    strKeyStackLineChar = cKeyStackLineChar_Repeat;
                }
                else if (m_InKeyframeRepeatMode)
                {
                    strKeyStackLineChar = cKeyStackLineChar_Replicate;
                }

                //Check if the move was a repeat of last keyframe Move Action
                if (bolIsRepeatMove | bolIsSequenceMove)
                {
                    //If this is a last move repeat, use the incoming strMoveSummary because the repeat code created the summary
                    m_MovesList = strMoveSummary;
                }
                else
                {
                    //If this is a standard (manual) move sequence, use the move summary from m_sbMovesList
                    m_MovesList = m_sbMovesList.ToString();
                }

                //Clean up the m_sbMovesList content to get a non-wrapping keyframe record
                m_MovesList = m_MovesList.Replace(System.Environment.NewLine, cSingleSpaceChar); //Replace line breaks
                m_MovesList = m_MovesList.Replace(cDoubleSpaceCharSequence, cSingleSpaceChar); //Replace double spaces with single

                //=====================================================
                //Insert the Keyframe data into the database
                //=====================================================

                //Insert a record into the Keyframes table
                KeyframeModel itemKeyframe = new KeyframeModel();
                itemKeyframe.KeyframeType = strKeyStackLineChar;
                itemKeyframe.KeyframeNum = m_NextKeyframeNumber;
                itemKeyframe.KeyframeDisplay = m_MovesList;
                itemKeyframe.FramesBetween = intFramesBetween;
                itemKeyframe.FrameCount = m_TotalFramesCount;
                itemKeyframe.FarPlane = (int)mtbx_FarPlane.Value;
                itemKeyframe.KeyframeNote = strKeyframeNote;

                //Insert into the DB which returns the ID of the newly inserted record
                int intKeyframeID = Data_Access_Methods.InsertKeyframeData(m_SelectedProjectID, itemKeyframe);

                //Update and display the next Keyframe number
                m_NextKeyframeNumber = Data_Access_Methods.GetProjectNextKeyframeNumber(m_SelectedProjectID);
                mtbx_NextKeyframeNumber.Value = m_NextKeyframeNumber;

                //=====================================================
                //Insert the keyframe's Action data into the database
                //=====================================================

                string ActionName = String.Empty;
                int SendKeyQuantity_abs = 0;
                string SendKeyChar = String.Empty;
                int StepAngleCount_abs = 0;

                //Insert records into the Keyframe_Action table
                KeyframeActionsModel KeyframeAction_Out = new KeyframeActionsModel();

                //If the m_MoveGroupTrackerDic collection has elements (move actions)
                if (m_MoveGroupTrackerDic.Count > 0)
                {
                    BringFocusToMB3DNavigator(); //This was validated in the head of this procedure

                    foreach (var itemAction in m_MoveGroupTrackerDic)
                    {
                        //Note: See constructor of m_MoveGroupTrackerDic for Tuple structure

                        //Collection the tuple values
                        ActionName = itemAction.Value.Item1;

                        //Note: We always want the positive value of a SendKeyQuantity
                        SendKeyQuantity_abs = Math.Abs(itemAction.Value.Item2);

                        SendKeyChar = itemAction.Value.Item3;

                        //Note: We always want the positive value of a SendKeyQuantity
                        StepAngleCount_abs = Math.Abs(itemAction.Value.Item4);

                        //ID
                        KeyframeAction_Out.ID = 0; //We don't need ID - just populating with a placeholder value

                        //Action Name
                        KeyframeAction_Out.ActionName = ActionName;

                        //Send Key Quantity
                        KeyframeAction_Out.SendKeyQuantity = SendKeyQuantity_abs;

                        //Send Key Char
                        KeyframeAction_Out.SendKeyChar = SendKeyChar;

                        //Step/Angle Count
                        KeyframeAction_Out.StepAngleCount = StepAngleCount_abs;

                        //Update the database if the Move Action has a non-zero SendKeyQuantity, else ignore the Move Action element
                        if (SendKeyQuantity_abs > 0)
                        {
                            //Insert move action data into the DB
                            Data_Access_Methods.InsertKeyframeActionData(intKeyframeID, KeyframeAction_Out);
                        }
                    }
                }
                else
                {
                    //Note: m_MoveGroupTrackerDic.Count is empty (no elements) then we can assume that is a no-move keyframe

                    //ID
                    KeyframeAction_Out.ID = 0; //We don't need ID - just populating with a placeholder value

                    //Action Name
                    KeyframeAction_Out.ActionName = cNMKn;

                    //Send Key Quantity
                    KeyframeAction_Out.SendKeyQuantity = 0;

                    //Send Key Char
                    KeyframeAction_Out.SendKeyChar = GetKeyCodeByActionName(cNMKk);

                    //Step/Angle Count
                    KeyframeAction_Out.StepAngleCount = 0;

                    //Insert no-move action data into the DB
                    Data_Access_Methods.InsertKeyframeActionData(intKeyframeID, KeyframeAction_Out);

                }

                PopulateKeyframesDatagrid(true);  //Populate the Keyframes list and select the first datagrid row

                //=======================================
                // Trigger the MB3D app's Insert Keyframe
                //=======================================

                BringFocusToMB3DNavigator(); //This was validated in the head of this procedure

                SendKeys.Send(cIKFk_); //Send the "f" key out to insert the keyframe in the animation keyframes
                System.Threading.Thread.Sleep(intKeyEventThreadSleep); //Delay to give MB time to insert the keyframe

                BringFocusToThisApplication(); //Bring focus back to this application

                //=======================================
                // Clean Up & Prep for Next Move Sequence
                //=======================================

                lbl_MovesList.Text = String.Empty; //Clear MovesList label

                //Display the moves from the last move dictionary that have movement
                StringBuilder sbLastMove = new StringBuilder();
                foreach (var item in m_MoveGroupTrackerDic)
                {
                    //Tuple<string, int, int> = MoveName, KeyActionCount, StepCountAngle
                    sbLastMove.Append(string.Concat(item.Value.Item1, item.Value.Item2, "(", item.Value.Item3.ToString(), ") "));
                }

                sbLastMove.Clear(); //Clear the string builder for re-use below

                m_MoveGroupTrackerDic.Clear(); //Clear the CurrentMoveList dictionary
                sbLastMove.Clear(); //Clear the string builder for next cycle
                m_sbMovesList.Clear(); //Clear the cycle

                //Set m_HaveMovesToProcess to false to disable the "A" button ("f" key) without real moves
                m_HaveMovesToProcess = false;
                m_BlockInsertKeyframe = false;

                if (bolBypassBusyIndicator == false)
                {
                    SetBusyIndicator(false); //Hide the Busy Indicator (unless bypassed)
                }

                //=======================================
                // Perform the Auto Move (if enabled)
                //=======================================
                ProcessAutoLastMove(); //Process the AutoLastMove if a move is selected from the dropdown control

                //=======================================
                // Save to the database if applicable
                //=======================================
                m_AutoSaveCount += 1;
                if (m_AutoSaveCount >= num_AutoSaveTrigger.Value)
                {
                    //Update database. Not a new project record so no beep
                    SaveAnimationProject(false, false);

                    //Footer Message
                    LoadFooterMessage(string.Concat("Reminder: Save your Mandelbulb3D project!"), true, false);

                    m_AutoSaveCount = 0;
                }
            }
            catch (Exception ex)
            {
                LogException("MakeNewKeyframe", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ MakeNewKeyframe. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CalculateAnimationTime()
        {

            if (m_TotalFramesCount == 0)
            {
                lbl_30FPSTimeCalc.Text = "00:00";
                lbl_60FPSTimeCalc.Text = "00:00";
                return;
            }

            //Fetch the current project's Total Anaimation Time, in seconds
            double intTotalProjectSeconds = Data_Access_Methods.GetProjectTotalSeconds(m_SelectedProjectID);

            //30 fps
            TimeSpan ts30 = TimeSpan.FromSeconds(intTotalProjectSeconds);
            lbl_30FPSTimeCalc.Text = ts30.ToString(@"mm\:ss");

            //60 fps
            TimeSpan ts60 = TimeSpan.FromSeconds(intTotalProjectSeconds / 2);
            lbl_60FPSTimeCalc.Text = ts60.ToString(@"mm\:ss");
        }

        private void btn_InsertAutoMove_Click(object sender, EventArgs e)
        {
            //This function inserts the AutoMove values if the app is in record mode
            //This handles situations where the AutoMove is enabled when the record mode turns off
            if (m_EnableCapture)
            {
                if (m_EnableAutoMove & drp_AutoLastMove.SelectedIndex >= 0 & nup_AutoMoveQuantity.Value > 0)
                {
                    ProcessAutoLastMove();
                }
            }
        }

        private void ProcessAutoLastMove()
        {
            //Set focus on the Mandelbulb3D Navigator window
            if (BringFocusToMB3DNavigator() == false)
            {
                return; //Bail out of MakeNewKeyframe - there is nothing we can do without Mandelbulb3D assets running
            }

            //If m_EnableAutoMove is true and a move is selected from the dropdown control
            //and a Step is selected and the Step quantity is greater than zero
            if (m_EnableAutoMove & drp_AutoLastMove.SelectedIndex >= 0 & nup_AutoMoveQuantity.Value > 0)
            {
                SetBusyIndicator(true); //Show the Busy Indicator

                //Note: We don't need the selected text of drp_AutoLastMove here
                string strSelectedValue = drp_AutoLastMove.SelectedValue.ToString();

                int StepAngleCount = 0;

                int intAutoLastStepQuantity = (int)nup_AutoMoveQuantity.Value;

                //If the move quantity is greater than zero
                if (intAutoLastStepQuantity > 0)
                {

                    //If Walking or Sliding
                    if (strSelectedValue.StartsWith("W") | strSelectedValue.StartsWith("S"))
                    {
                        StepAngleCount = (int)mtbx_SlidingWalkingCount.Value;
                    }
                    else
                    {
                        //If Looking or Rolling
                        StepAngleCount = (int)mtbx_LookingRollingAngle.Value;
                    }

                    BringFocusToMB3DNavigator(); //This was validated at the head of this procedure

                    for (int i = 0; i < intAutoLastStepQuantity; i++)
                    {
                        if (cbx_AutoMoveShift.Checked)
                        {
                            m_StepAngleCountDefaultBypass = StepAngleCount / 2;

                            SendKeys.Send(string.Concat("+", strSelectedValue)); //Send the key, example "+w"\
                            //Console.WriteLine(String.Concat($"SENDKEY=", string.Concat("+", strSelectedValue)));
                        }
                        else
                        {

                            m_StepAngleCountDefaultBypass = StepAngleCount;

                            SendKeys.Send(strSelectedValue); //Send the key, example "w"
                            //Console.WriteLine(String.Concat($"SENDKEY=", strSelectedValue));
                        }
                        System.Threading.Thread.Sleep(intKeyEventThreadSleep); //Let's not get too rambunctious
                    }
                }

                BringFocusToThisApplication(); //Bring focus back to this application
                SetBusyIndicator(false); //Hide the Busy Indicator
            }
        }

        private void RepeatLastMove()
        {
            //Set focus on the Mandelbulb3D Navigator window
            if (BringFocusToMB3DNavigator() == false)
            {
                return; //Bail out of MakeNewKeyframe - there is nothing we can do without Mandelbulb3D assets running
            }

            //Check if the project have keyframes
            if (Data_Access_Methods.GetProjectKeyframeQuantity(m_SelectedProjectID) <= 0)
            {
                MessageBoxAdv.Show("This project does not have any keyframes yet.", "Nothing To Do", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (m_HaveMovesToProcess)
            {
                LoadFooterMessage("Can't do that - you have moves pending.", false, true);
                return;
            }

            try
            {
                //Retrieve a list of Keyframe Move Actions for the most recent keyframe and send those key
                //actions to the MB3D Navigator, recording the moves into the database as usual

                //Get the Keyframe Move Actions for the LAST keyframe in the database
                List<KeyframeActionsModel> lstKeyframeAction = new List<KeyframeActionsModel>();
                lstKeyframeAction = Data_Access_Methods.LoadLastKeyframeActionsList_ForKeyframeRepeat(m_SelectedProjectID);
                if (lstKeyframeAction.Count > 0)
                {
                    var NL = Environment.NewLine;

                    LoadFooterMessage("Repeating the moves of the last keyframe.", true, false);

                    ClearMoveList(); //Make sure any moves are cleared out.

                    m_InKeyframeRepeatMode = true; //Turn on InKeyframeRepeatMode flag

                    SetBusyIndicator(true); //Show the Busy Indicator

                    //Create a distinct list of the moves of the last keyframe to be repeated
                    List<KeyframeActionsModel> lstKeyframeActions_Distinct = new List<KeyframeActionsModel>();
                    var DistinctItems = lstKeyframeAction.GroupBy(x => x.ActionName).Select(y => y.First());

                    //Loop the Distinct moves list to build a visual summary and send the keys
                    StringBuilder sbDisplaySummary = new StringBuilder();

                    Int32 intSendKeyQuantity = 0;
                    Int32 intStepAngleCount = 0;

                    foreach (KeyframeActionsModel itemDistinct in DistinctItems)
                    {
                        intSendKeyQuantity = 0;
                        intStepAngleCount = 0;

                        //Loop the lstKeyframeAction to build the move summary
                        foreach (var itemAction in lstKeyframeAction)
                        {
                            if (itemAction.ActionName == itemDistinct.ActionName)
                            {
                                intSendKeyQuantity += itemAction.SendKeyQuantity;
                                intStepAngleCount += itemDistinct.StepAngleCount;
                            }
                        }

                        sbDisplaySummary.Append(string.Concat(itemDistinct.ActionName, intSendKeyQuantity.ToString(), " (", intStepAngleCount.ToString(), ")", NL));

                        //Update the UI with the MovesList of this loop cycle
                        lbl_MovesList.Text = String.Concat(sbDisplaySummary.ToString());
                        this.Refresh();

                        //Now, send the keychar out as many times as specified by intSendKeyQuantity with their StepAngleCount values
                        for (int i = 0; i < intSendKeyQuantity; i++)
                        {
                            m_StepAngleCountDefaultBypass = itemDistinct.StepAngleCount; //This passes the Step/Angle count to the UpdateKeyStepList procedure

                            //Note: A SendKeyChar that has a '+' appended to it will be treated by the SendKeys.Send method as a shift
                            //      character. As such, we do not need to handle the Shift functions of a keyframe SendKeyChar value here.

                            SendKeys.Send(itemDistinct.SendKeyChar); //Send the key, examples: "w", "+w"

                            System.Threading.Thread.Sleep(intKeyEventThreadSleep); //Let's not get ahead of ourselves
                            //Console.WriteLine(String.Concat($"SENDKEY=", string.Concat(step.Step_SendKey)));

                        }
                    }

                    //Call MakeNewKeyframe
                    MakeNewKeyframe(true, false, false, sbDisplaySummary.ToString(), true, "Repeat last Move");

                    ClearMoveList(); //Make sure any moves are cleared out

                    m_InKeyframeRepeatMode = false; //Turn off InKeyframeRepeatMode flag

                    SetBusyIndicator(false); //Hide the Busy Indicator

                    LoadFooterMessage(string.Empty, false, false);
                }
            }
            catch (Exception ex)
            {
                LogException("RepeatLastMove", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ RepeatLastMove. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Keystack Datagrid Events & Methods ==========================================

        private void dgv_Keyframes_sf_CellCheckBoxClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellCheckBoxClickEventArgs e)
        {
            if (e.Column.MappingName == "KeyframeApproved")
            {
                //Fetch the currently selected datagrid row
                var rowIndex = this.dgv_Keyframes_sf.SelectionController.DataGrid.CurrentCell.RowIndex;
                var recordIndex = dgv_Keyframes_sf.TableControl.ResolveToRecordIndex(rowIndex);
                var cellValue_ID = DataGridHelper.GetCellValue(dgv_Keyframes_sf, recordIndex, -1, "ID"); //Get the ID column value

                //Get the boolean state of the Approve/Disapprove checkbox
                bool CheckState = Convert.ToBoolean(e.NewValue);

                //Update the database with the new Approve/Disapprove checkbox state
                Data_Access_Methods.ApproveByKeyframeID(CheckState, m_SelectedProjectID, (int)cellValue_ID);

                //Note: There is no need to refresh the datagrid in this case
            }
        }

        #endregion

        #region Restore Point Methods ==========================================

        private void btn_SetRestorePoint_Click(object sender, EventArgs e)
        {
            SetRestorePoint();
        }

        private void btn_ClearRestorePoint_Click(object sender, EventArgs e)
        {
            //Reset the Restore Point
            m_RestorePointDic.Clear();
            btn_SetRestorePoint.ForeColor = Color.White;
        }

        private void btn_RestorePointInfo_Click(object sender, EventArgs e)
        {
            if (m_RestorePointDic.Count > 0)
            {
                string strNextKeyframe = m_RestorePointDic["NextKeyframe"].ToString();
                string strTotalFrameCount = m_RestorePointDic["TotalFrameCount"].ToString();
                string strLastKeyframeNumber = m_RestorePointDic["LastKeyFrameNumber"].ToString();

                var NL = Environment.NewLine;
                MessageBoxAdv.Show(string.Concat("The Restore Point is:", NL, NL, "Next KeyFrame # = ", strNextKeyframe, NL, "Total Frame Count = ", strTotalFrameCount, NL, "Last Keyframe = ", strLastKeyframeNumber), "Restore Point", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxAdv.Show("A Restore Point is not currently set.", "Restore Point", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SetRestorePoint()
        {

            //Check if the project have keyframes
            if (Data_Access_Methods.GetProjectKeyframeQuantity(m_SelectedProjectID) <= 0)
            {
                MessageBoxAdv.Show("This project does not have any keyframes yet - there is nothing to do.", "Nothing To Do", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Fetch the currently selected datagrid row
            var rowIndex = this.dgv_Keyframes_sf.SelectionController.DataGrid.CurrentCell.RowIndex;
            var recordIndex = dgv_Keyframes_sf.TableControl.ResolveToRecordIndex(rowIndex);

            //Check if keyframes has been selected
            if (recordIndex < 0)
            {
                MessageBoxAdv.Show("Please select the keyframe that will be a restore point.", "Nothing To Do", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SaveAnimationProject(false, false); //Save to the project's database first

            m_RestorePointDic.Clear();

            //Determine the selected keyframe positions
            var SelectedDatagridKeyframeNumber = DataGridHelper.GetCellValue(dgv_Keyframes_sf, recordIndex, -1, "KeyframeNum"); //Get the keyframe number column value
            m_RestorePointDic.Add("NextKeyframe", (int)SelectedDatagridKeyframeNumber + 1); //Record the next keyframe value
            m_RestorePointDic.Add("LastKeyFrameNumber", (int)SelectedDatagridKeyframeNumber); //Record the selected keyframe number

            //Determine the frame count at the selected keyframe position
            var intSelectedDatagridTotalFrameCount = DataGridHelper.GetCellValue(dgv_Keyframes_sf, recordIndex, -1, "FrameCount"); //Get the frame count column value            
            m_RestorePointDic.Add("TotalFrameCount", (int)intSelectedDatagridTotalFrameCount); //Record the current Total Frame Count

            //Obtain values for message display
            int intRPKeyframeNumber = m_RestorePointDic["NextKeyframe"]; //The next keyframe value
            int intRPFrameCount = m_RestorePointDic["TotalFrameCount"]; //The Total Frame Count
            int intRPLastKeyframeNumber = m_RestorePointDic["LastKeyFrameNumber"]; //The selected keyframe value

            btn_SetRestorePoint.ForeColor = Color.Green;

            //Footer message
            LoadFooterMessage(string.Concat("Restore Point:", "Next KeyFrame # = ", intRPKeyframeNumber.ToString(), ", Total Frame Count = ", intRPFrameCount.ToString(), ", Last Keyframe = ", intRPLastKeyframeNumber.ToString()), false, false);

            //Return focus to the selected Keyframe Stack datagrid row
            dgv_Keyframes_sf.SelectedIndex = recordIndex;
        }

        private void btn_PerformRestorePoint_Click(object sender, EventArgs e)
        {
            PerformRestorePoint();
        }

        private void PerformRestorePoint()
        {
            var NL = Environment.NewLine;

            if (m_RestorePointDic.Count > 0)
            {
                int intRPNextKeyframeNumber = m_RestorePointDic["NextKeyframe"]; //The next keyframe value
                int intRPFrameCount = m_RestorePointDic["TotalFrameCount"]; //The Total Frame Count
                int intRPLastKeyframeNumber = m_RestorePointDic["LastKeyFrameNumber"]; //The selected keyframe value

                DialogResult result = MessageBoxAdv.Show(string.Concat("This will reset your keyframe work to the last Set Restore Point as described below.", NL, "The last Set Restore Point is as follows:", NL, NL, "Next KeyFrame # = ", intRPNextKeyframeNumber.ToString(), NL, "Total Frame Count = ", intRPFrameCount.ToString(), NL, "Last Keyframe = ", intRPLastKeyframeNumber.ToString(), NL, NL, "Do you want to proceed?"), "Confirm Restore Point", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //Restore the next keyframe value

                    int intNextKeyframeNumber = intRPLastKeyframeNumber + 1;
                    mtbx_NextKeyframeNumber.Value = intRPNextKeyframeNumber;
                    m_NextKeyframeNumber = intRPLastKeyframeNumber;

                    //Restore the current Total Frame Count
                    mtbx_FrameCount.Value = intRPFrameCount;

                    //Delete the keyframes to be discarded
                    Data_Access_Methods.DeleteRangeOfKeyframeAndKeyframeActions(m_SelectedProjectID, intNextKeyframeNumber, -1);

                    //Restore the keystack datagrid up to the keyframe of the restore
                    PopulateKeyframesDatagrid(true); //bolSetToFirstRow=true

                    ClearMoveList();

                    MessageBoxAdv.Show(string.Concat("The Restore Point has completed. Be sure to delete all of the keyframes of the Mandelbulb3D animation after keyframe number ", intRPLastKeyframeNumber.ToString(), "."), "Restore Point Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Footer message
                    LoadFooterMessage(string.Concat(string.Concat("Restore Point completed. Be sure to delete Mandelbulb3D keyframes after keyframe #", intRPLastKeyframeNumber.ToString(), ".")), true, true);

                    DialogResult result2 = MessageBoxAdv.Show("Do you want to keep the Restore Point that was last set?", "Keep Restore Point?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result2 == DialogResult.No)
                    {
                        m_RestorePointDic.Clear(); //Clear the previous Restore Point dictionary
                        btn_SetRestorePoint.ForeColor = Color.White;
                    }
                }
            }
            else
            {
                MessageBoxAdv.Show(string.Concat("There is no Restore Point set."), "No Restore Point", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Key Event Handling ======================================================

        public static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            try
            {
                //Used for Normal Move Recording
                //This is KEYDOWN
                if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    //Console.WriteLine($"KEYDOWN=[{(Keys)vkCode}]");

                    Keys keyKey = (Keys)vkCode;
                    string strKey = keyKey.ToString(); //Convert keyKey to string

                    //Test if the key is allowed to be processed
                    if (ValidateCanProcessKeyEvent(strKey))
                    {
                        //If the incoming key is NOT MakeNewKeyframe (cMNKk) ...
                        if (strKey != cMNKk) { m_BlockInsertKeyframe = true; } //...block an Insert Keyframe command
                        Program._MainForm.ProcessKeyDownEvent(strKey); //...and pass the incoming key command
                    }
                    else
                    {
                        //If key can NOT be processed, return now to disallow the key event
                        return IntPtr.Zero;
                    }
                }

                //Used to detect the ESC key command
                //This is KEYUP
                if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    Keys keyKey = (Keys)vkCode;
                    string strKey = keyKey.ToString(); //Convert keyKey to string
                    if ((Keys)vkCode == Keys.Escape)
                    {
                        m_ProcessStop = true;
                    }
                    else
                    {
                        Program._MainForm.ProcessKeyUpEvent(strKey);
                    }
                }

                return IntPtr.Zero;

            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("HookCallback", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ HookCallback. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return IntPtr.Zero;
            }
        }

        private static bool ValidateCanProcessKeyEvent(string strKey)
        {
            bool bolCanProcessKeyEvent = true;

            //==========================================================
            //This method is not used at this time. Keep for future use.
            //=============nn=============================================

            return bolCanProcessKeyEvent;
        }

        //Note: Do not call this sub - let only HookCallback call it
        private void ProcessKeyDownEvent(string strKey)
        {
            var NL = Environment.NewLine;

            //Display this key event
            lbl_LastKeyEvent.Text = String.Concat("Last Key Event:", strKey);

            //===========================
            //Toggle Capture Mode
            //===========================

            if (strKey == cTRMk) //Note: m_EnableCapture state is of no concern here
            {
                //Toggle the current state of m_EnableCapture
                SetCaptureMode(!m_EnableCapture);
                return; //Halt code execution here
            }

            //===========================
            //Repeat last move
            //===========================

            if (m_EnableCapture & strKey == cRLMk)
            {
                RepeatLastMove();
                return; //Halt code execut here
            }

            //===========================
            //Make new keyframe
            //===========================

            if (m_EnableCapture & strKey == cMNKk)
            {
                //Only allow this key event if there are moves to process
                //so that a new keyframe isn't made in the animator window
                if (m_HaveMovesToProcess & m_MoveGroupTrackerDic.Count > 0)
                {
                    MakeNewKeyframe(false, false, false, string.Empty, false, string.Empty);
                }
                else
                {
                    LoadFooterMessage("There are no moves for a new keyframe.", false, true);
                }
                return; //Halt code execution here
            }

            //===========================
            //Insert a no-move keyframe
            //===========================

            if (m_EnableCapture & strKey == cNMKk)
            {
                //We there are no existing moves pending
                if (m_HaveMovesToProcess == false)
                {
                    m_HaveMovesToProcess = true; //Flag moves to capture
                    m_KeysStack += strKey; //Capture the key

                    m_sbMovesList.Append(string.Concat(cNMKfn, NL));
                    lbl_MovesList.Text = String.Concat(m_sbMovesList.ToString()); //Write this MovesList to the UI (with the newline "NL")

                    MakeNewKeyframe(false, false, true, string.Empty, false, "No Move Keyframe"); //Call the MakeNewKeyframe immediately
                }
                else
                {
                    LoadFooterMessage("Inserting no-move keyframes is not allowed with other moves.", false, true);
                }
                return; //Halt code execution here
            }

            //===========================
            //Left/Right Shift Key event
            //===========================

            if (strKey == "RShiftKey" | strKey == "LShiftKey")
            {
                //Toggle shift mode - turn OFF the shift mode
                m_ShiftKeyActive = !m_ShiftKeyActive;
                lbl_ShiftIndicator.Visible = m_ShiftKeyActive;
                return; //Halt code execution heref
            }

            //===========================
            //Toggle AutoMove
            //===========================

            if (strKey == cEAMk)
            {
                m_EnableAutoMove = !m_EnableAutoMove;
                cbx_EnableAutoMove.Checked = m_EnableAutoMove;
                return; //Halt code execution here
            }

            //===========================
            //Movement key events
            //===========================

            if (m_EnableCapture)
            {
                m_HaveMovesToProcess = true; //Flag as moves to capture
                m_KeysStack += strKey; //Capture the key
                string strFinalKeyCode = strKey;

                //Determine the source of the Step/Angle values
                if (m_InKeyframeRepeatMode)
                {
                    //Use the Step/Angle bypass values
                    m_SWStepCount = m_StepAngleCountDefaultBypass;
                    m_LRAngle = m_StepAngleCountDefaultBypass;
                }
                else
                {
                    //Use the project's default Step/Angle values
                    m_SWStepCount = (int)mtbx_SlidingWalkingCount.Value;
                    m_LRAngle = (int)mtbx_LookingRollingAngle.Value;
                }

                //If Shift is active (m_ShiftKeyActive=true)
                if (m_ShiftKeyActive)
                {
                    m_SWStepCount = m_SWStepCount / 2; //Cut the StepCount in half
                    m_LRAngle = m_LRAngle / 2; //Cut the StepAnle in half
                }

                //Determine the method to call based on the key action
                switch (strKey)
                {
                    //Walking
                    case cWFk: //Walk Forward
                        UpdateKeyStepList(cWalkFRGroup, cWFn, cWFk_, 1, m_SWStepCount);
                        break;
                    case cWRk: //Walk Reverse
                        UpdateKeyStepList(cWalkFRGroup, cWRn, cWRk_, 2, m_SWStepCount);
                        break;

                    //Looking
                    case cLUk: //Look UP  *** Pass in the Looking/Rolling Angle value ***
                        UpdateKeyStepList(cLookUDGroup, cLUn, cLUk_, 1, m_LRAngle);
                        break;
                    case cLDk: //Look Down *** Pass in the Looking/Rolling Angle value ***
                        UpdateKeyStepList(cLookUDGroup, cLDn, cLDk_, 2, m_LRAngle);
                        break;
                    case cLRk: //Look Right *** Pass in the Looking/Rolling Angle value ***
                        UpdateKeyStepList(cLookRLGroup, cLRn, cLRk_, 1, m_LRAngle);
                        break;
                    case cLLk: //Look Left *** Pass in the Looking/Rolling Angle value ***
                        UpdateKeyStepList(cLookRLGroup, cLLn, cLLk_, 2, m_LRAngle);
                        break;

                    //Sliding
                    case cSUk: //Slide UP
                        UpdateKeyStepList(cSlideUDGroup, cSUn, cSUk_, 1, m_SWStepCount);
                        break;
                    case cSDk: //Slide Down
                        UpdateKeyStepList(cSlideUDGroup, cSDn, cSDk_, 2, m_SWStepCount);
                        break;
                    case cSRk: //Slide Right
                        UpdateKeyStepList(cSlideRLGroup, cSRn, cSRk_, 1, m_SWStepCount);
                        break;
                    case cSLk: //Slide Left
                        UpdateKeyStepList(cSlideRLGroup, cSLn, cSLk_, 2, m_SWStepCount);
                        break;

                    //Rolling
                    case cRCCk: //Rotate Counter-Clockwise *** Pass in the Looking/Rolling Angle value ***
                        UpdateKeyStepList(cRollGroup, cRCCn, cRCCk_, 1, m_LRAngle);
                        break;
                    case cRCWk: //Rotate C *** Pass in the Looking/Rolling Angle value ***
                        UpdateKeyStepList(cRollGroup, cRCWn, cRCWk_, 2, m_LRAngle);
                        break;

                    default:
                        //If none of the above cases were mey, there were no moves to process
                        return; //Do nothing
                }
            }
        }

        private void UpdateKeyStepList(IReadOnlyList<string> strKeyActionGroup, string strMoveName, string strSendKeyChar, int intKeyActionGroupIndex, int intStepCountAngle)
        {

            //Try to set focus to the Mandelbulb3D Navigator
            if (BringFocusToMB3DNavigator() == false)
            {
                return; //Bail out of MakeNewKeyframe - there is nothing we can do without Mandelbulb3D assets running
            }

            var NL = Environment.NewLine;

            //Clear m_sbMovesList from the last keyframe
            m_sbMovesList.Clear();
            //Note: Do not clear the Repeat Moves list dictionary (dicRepeatMoveList)

            int intKeyActionCount = 1;  //Every step has just one key send event

            //Create an empty Tuple to hold OUTPUT set of values from TryGetValue below
            //Tuple<string, int, int> = MoveName, ModeStepCount, SendKeyCode, StepCountAngle
            Tuple<string, int, string, int> tplOut = new Tuple<string, int, string, int>(string.Empty, 0, string.Empty, 0);

            //Try to get a tuple set of move step group that is already in the m_MoveGroupTrackerDic collection
            if (m_MoveGroupTrackerDic.TryGetValue(strKeyActionGroup[0], out tplOut))
            {
                //If the move group element exists in the m_MoveGroupTrackerDic collection, get a tuple of its values
                string strMoveName_out = tplOut.Item1;
                int intKeyActionCount_out = tplOut.Item2;
                string strSendKeyChar_out = tplOut.Item3;
                int intStepCountAngle_out = tplOut.Item4;

                if (intKeyActionGroupIndex == 1)
                {
                    //...increase the existing key count by 1(step)
                    intKeyActionCount = intKeyActionCount_out += 1;

                    //If the Key Action count reaches zero, zero out the StepAngle count
                    if (intKeyActionCount == 0)
                    {
                        intStepCountAngle = 0;
                    }
                    else
                    {
                        //Add the current step/ angle count to the previous step / angle count
                        intStepCountAngle = intStepCountAngle_out + intStepCountAngle;
                    }
                }

                if (intKeyActionGroupIndex == 2)
                {
                    //Set the move name based on move direction
                    strMoveName = strKeyActionGroup[intKeyActionGroupIndex];

                    //...decrease the existing key count by 1(step)
                    intKeyActionCount = intKeyActionCount_out -= 1;

                    //If the Key Action count reaches zero, zero out the StepAngle count
                    if (intKeyActionCount == 0)
                    {
                        intStepCountAngle = 0;
                    }
                    else
                    {
                        //Subtract the current step/ angle count from the previous step / angle count
                        intStepCountAngle = intStepCountAngle_out - intStepCountAngle;
                    }
                }

                //Set the move name based on move direction
                if (intKeyActionCount > 0)
                {
                    strMoveName = strKeyActionGroup[1];
                }
                else
                {
                    strMoveName = strKeyActionGroup[2];
                }

                //Update the Move Group Tracker dictionary(m_MoveGroupTrackerDic) with the new key step count and step/ angle values
                //Tuple<string, int, int> = MoveName, KeyActionCount, StepCountAngle
                m_MoveGroupTrackerDic[strKeyActionGroup[0]] = new Tuple<string, int, string, int>(strMoveName, intKeyActionCount, strSendKeyChar, intStepCountAngle);
            }
            else
            {
                //The move step group is NOT in the m_MoveGroupTrackerDic collection

                //Set the move name and key count based on the move direction
                if (intKeyActionGroupIndex == 1)
                {
                    strMoveName = strKeyActionGroup[1];
                }

                if (intKeyActionGroupIndex == 2)
                {
                    strMoveName = strKeyActionGroup[2];
                    intKeyActionCount = Math.Abs(intKeyActionCount) * (-1);
                    intStepCountAngle = Math.Abs(intStepCountAngle) * (-1);
                }

                //If there is NOT an existing dictionary element for the incoming move group item...
                //...append the Move Group Tracker dictionary (m_MoveGroupTrackerDic) with the new key step count and step/angle values
                //Tuple<string, int, string, int> = MoveName, KeyActionCount, SendKeyChar, StepCountAngle
                m_MoveGroupTrackerDic[strKeyActionGroup[0]] = new Tuple<string, int, string, int>(strMoveName, intKeyActionCount, strSendKeyChar, intStepCountAngle);
            }

            //Now, let's get all this Goodness to the UI!
            foreach (var step in m_MoveGroupTrackerDic)
            {
                //Tuple<string, int, int> = MoveName, KeyActionCount, StepCountAngle
                string strMoveName_Display = step.Value.Item1; //Move Name, ex: WF, SU, LL, etc.
                int intKeyActionCount_Display = step.Value.Item2; //Key Action Count, ex: 3
                //Note: We don't need the Send Key Char on the UI
                int intStepCountAngle_Display = step.Value.Item4; //Step Count/Angle. ex: 2000

                //If intKeyActionCount_Display is less than zero, convert to positive values only for purposes of display
                if (intKeyActionCount_Display < 0)
                {
                    intKeyActionCount_Display = Math.Abs(intKeyActionCount_Display);
                    //Note: The intStepCountAngle_Display value should never be a negative value
                }

                //If intStepCountAngle_Display is less than zero, convert to positive values only for purposes of display
                if (intStepCountAngle_Display < 0)
                {
                    intStepCountAngle_Display = Math.Abs(intStepCountAngle_Display);
                }

                if (intKeyActionCount_Display == 0) // If the Key Action count is zero, don't display the move
                {
                    m_sbMovesList.Append(string.Empty);
                }
                else
                {
                    m_sbMovesList.Append(string.Concat(strMoveName_Display, intKeyActionCount_Display.ToString(), " (", intStepCountAngle_Display.ToString(), ") ", NL));
                }
            }

            lbl_MovesList.Text = String.Concat(m_sbMovesList.ToString()); //Write this MovesList to the UI (with the newlines "NL")

            BringFocusToMB3DNavigator(); //End the processing of a key by insuring focus is on the MB3D Navigator
        }

        private void btn_ShowKeyLegendWindow_Click(object sender, EventArgs e)
        {
            frm_Key_Legend_Child_Window frmKeyLegend = new frm_Key_Legend_Child_Window();

            //Check if the child form is already open
            if (System.Windows.Forms.Application.OpenForms.OfType<frm_Key_Legend_Child_Window>().Count() == 0)
            {
                //Set the parent form of this child window
                frmKeyLegend.Owner = this;

                //Display the Key Legend form
                frmKeyLegend.Show();
            }
            else
            {
                frmKeyLegend.Focus();
            }
        }

        private void cbx_EnableAutoMove_CheckedChanged(object sender, EventArgs e)
        {
            m_EnableAutoMove = cbx_EnableAutoMove.Checked;
            btn_InsertAutoMove.Enabled = m_EnableAutoMove;
        }

        private void SetCaptureMode(bool bolRequestedCaptureState)
        {
            //If the capture state being requested is the same as current state
            if (bolRequestedCaptureState == m_EnableCapture)
            {
                return; //Bail
            }
            else
            {
                //Set the m_EnableCapture state to the requested state
                m_EnableCapture = bolRequestedCaptureState;
            }

            //If attempting to ENABLE recording mode...
            if (m_EnableCapture)
            {
                //Test if the Mandelbulb3D application (Main Editor) is running
                if (ValidateMandelbulb3DRunning() == false)
                {
                    //Do not enable recording if the Mandelbulb3D application (Main Editor) is not running
                    return; //Leave this method
                }
            }

            SetControlsStateForCapture(!m_EnableCapture);  //Set the UI controls as needed

            if (m_EnableCapture)
            {
                //Set focus on the Mandelbulb3D Navigator window if going INTO record mode
                if (BringFocusToMB3DNavigator() == false)
                {
                    m_EnableCapture = false; //Revert to not be in Capture mode
                    SetControlsStateForCapture(!m_EnableCapture); //Set the UI controls as needed
                    return; //Bail out of this proc - there is nothing we can do without Mandelbulb3D assets running
                }

                ClearMoveList(); //Be sure the Move List is cleared

            }
            else
            {
                //When dropping out of capture mode, erase any current moves info
                lbl_MovesList.Text = String.Empty; //Clear MovesList label
                m_sbMovesList.Clear(); //Clear MovesList stringbuilder
                m_MovesList = string.Empty; //Clear Moves List
                m_KeysStack = string.Empty; //Clear strKeysList
                m_MoveGroupTrackerDic.Clear(); //Clear the Current Move List dictionary

                //Reset the ShiftKeyActive switch and UI
                m_ShiftKeyActive = false;
                lbl_ShiftIndicator.Visible = m_ShiftKeyActive;
                m_AutoSaveCount = 0; //Reset Auto Save counter

                lbl_MovesList.Text = String.Empty; //Clear MovesList label
                m_sbMovesList.Clear(); //Clear MovesList stringbuilder
                m_MovesList = string.Empty; //Clear Moves List

                //And switch the focus to this application
                BringFocusToThisApplication();
            }

            //Set UI focus on the Keyframe Stack datagrid
            dgv_Keyframes_sf.Focus();
            dgv_Keyframes_sf.Select();
            dgv_Keyframes_sf.SelectedIndex = 0;
        }

        //Note: Do not call this sub - let only HookCallback call it
        //This is key UP event
        private void ProcessKeyUpEvent(string strKey)
        {
            if (strKey == cLShiftk | strKey == cRShiftk)
            {
                //Key UP turns shift mode ON
                m_ShiftKeyActive = !m_ShiftKeyActive;
                lbl_ShiftIndicator.Visible = m_ShiftKeyActive;

                //Also turn record mode shift mode OFF
                m_ShiftKeyActive_Record = !m_ShiftKeyActive_Record;

                return;
            }
        }

        #endregion

        #region Manage Move Sequence Methods =============================================================== 

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab.Name == "page_AnimationCopilot")
            {
                //No code here at this time
            }

            if (tabControl1.SelectedTab.Name == "page_MoveDesigner")
            {
                try
                {
                    m_SelectedMoveSequenceID = 0;
                    m_SelectedMoveSeqStepID = 0;

                    PopulateAvailableSeqDropdown();

                    MoveSequenceModel selectedSeq = (MoveSequenceModel)drp_ManageSeqMoveSequences.SelectedItem;
                    if (selectedSeq != null)
                    {
                        tbx_SequenceDesc_Manage.Text = selectedSeq.SequenceDesc;
                        LoadSequenceSteps(selectedSeq.ID, true);
                    }
                }
                catch
                {
                    //Do not hrow - there may be no Move Sequence records
                }
            }

            if (tabControl1.SelectedTab.Name == "page_Utilities")
            {
                //No code here at this time
            }

            if (tabControl1.SelectedTab.Name == "page_library")
            {
                //No code here at this time
            }

            if (tabControl1.SelectedTab.Name == "page_Admin")
            {
                //Call the proc to locate and display path and file name of the Sqlite db file in use
                GetDatabaseFilePathName();

                //Call the proc to load the error file content into the About textbox
                LoadErrorFileTextbox();
            }

            if (tabControl1.SelectedTab.Name == "page_About")
            {
                string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location; //Get location of executable
                string workPath = System.IO.Path.GetDirectoryName(exePath);
                string ReadMeInstallFilePathName = string.Concat(workPath, @"\README Install.rtf");
                string LicenseInstallFilePathName = string.Concat(workPath, @"\LICENSE Install.rtf");

                if (File.Exists(ReadMeInstallFilePathName))
                {
                    rtbx_ReadMeRTF.LoadFile(ReadMeInstallFilePathName);
                    rtbx_LicenseRTF.LoadFile(LicenseInstallFilePathName);
                }
                else
                {
                    rtbx_ReadMeRTF.Text = "The README file for this application was not found.";
                    rtbx_LicenseRTF.Text = "The LICENSE file for this application was not found.";
                }

            }
        }

        private void PopulateManageSeqStepNameList()
        {
            List<StepNameListModel> StepNameList = new List<StepNameListModel>();

            StepNameList.Add(new StepNameListModel() { Step_Name = "--", Step_SendKey = "" });
            StepNameList.Add(new StepNameListModel() { Step_Name = cWFn, Step_SendKey = cWFk_ });
            StepNameList.Add(new StepNameListModel() { Step_Name = cWRn, Step_SendKey = cWRk_ });
            StepNameList.Add(new StepNameListModel() { Step_Name = cLUn, Step_SendKey = cLUk_ });
            StepNameList.Add(new StepNameListModel() { Step_Name = cLDn, Step_SendKey = cLDk_ });
            StepNameList.Add(new StepNameListModel() { Step_Name = cLLn, Step_SendKey = cLLk_ });
            StepNameList.Add(new StepNameListModel() { Step_Name = cLRn, Step_SendKey = cLRk_ });
            StepNameList.Add(new StepNameListModel() { Step_Name = cSUn, Step_SendKey = cSUk_ });
            StepNameList.Add(new StepNameListModel() { Step_Name = cSDn, Step_SendKey = cSDk_ });
            StepNameList.Add(new StepNameListModel() { Step_Name = cSLn, Step_SendKey = cSRk_ });
            StepNameList.Add(new StepNameListModel() { Step_Name = cRCCn, Step_SendKey = cRCCk_ });
            StepNameList.Add(new StepNameListModel() { Step_Name = cRCWn, Step_SendKey = cRCWk_ });

            drp_ManageSeqStepNameList.DataSource = StepNameList;
            drp_ManageSeqStepNameList.DisplayMember = "Step_Name";
            drp_ManageSeqStepNameList.ValueMember = "Step_SendKey";
            drp_ManageSeqStepNameList.SelectedIndex = 0; //Set the drp_StepNameList_Edit to the first list item "---"
        }

        private void PopulateAvailableSeqDropdown()
        {
            drp_ManageSeqMoveSequences.DataSource = null;

            drp_ManageSeqMoveSequences.DataSource = Data_Access_Methods.LoadMoveSeqencesList();
            drp_ManageSeqMoveSequences.DisplayMember = "SequenceName";
            drp_ManageSeqMoveSequences.ValueMember = "ID";

            try
            {
                drp_ManageSeqMoveSequences.SelectedIndex = 0; //Select the first row
            }
            catch
            {
                //do not throw - there may be no Move Sequence records"
            };
        }

        private void drp_ManageSeqMoveSequences_SelectedIndexChanged(object sender, EventArgs e)
        {
            MoveSequenceModel selectedSeq = (MoveSequenceModel)drp_ManageSeqMoveSequences.SelectedItem;
            tbx_SequenceDesc_Manage.Text = selectedSeq.SequenceDesc;
            m_SelectedMoveSequenceID = selectedSeq.ID;
            LoadSequenceSteps(selectedSeq.ID, true);
        }

        private void btn_ManageSeqDeleteSequence_Click(object sender, EventArgs e)
        {

            MoveSequenceModel selectedSeq = (MoveSequenceModel)drp_ManageSeqMoveSequences.SelectedItem;
            if (selectedSeq == null)
            {
                MessageBoxAdv.Show("Please select a Move Sequence.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; //Bail
            }

            //Collect the data values for the sequence deletion
            string SeqParentID = selectedSeq.ID.ToString(); //Get the selected sequence parent ID
            string SeqName = selectedSeq.SequenceName; //Get the selected sequence name

            //Get delete confirmation
            DialogResult result = MessageBoxAdv.Show(string.Concat("Do you want to delete the Move Sequence '", SeqName, "' and all of it's steps? This deletion cannot be undone."), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Data_Access_Methods.DeleteSequence(SeqParentID);

                PopulateUseSequenceList();
                PopulateAvailableSeqDropdown();
            }
        }

        private void BuildManageSeqDatagrid()
        {
            //Datagrid configuation
            dgv_ManageMoveSequence.AutoGenerateColumns = false;
            dgv_ManageMoveSequence.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            dgv_ManageMoveSequence.RowHeight = 21;

            //Column definitions
            dgv_ManageMoveSequence.Columns.Add(new GridNumericColumn() { MappingName = "Step_ID", HeaderText = "Step ID", Width = 50, AllowEditing = false, Visible = false, Format = "0.#####" });
            dgv_ManageMoveSequence.Columns.Add(new GridTextColumn() { MappingName = "Step_Group", HeaderText = "Step Group", MinimumWidth = 8, Width = 75, AllowEditing = false, Visible = false, Format = "0.#####" });
            dgv_ManageMoveSequence.Columns.Add(new GridTextColumn() { MappingName = "Step_Name", HeaderText = "Step Name", MinimumWidth = 8, Width = 75, AllowEditing = false });
            dgv_ManageMoveSequence.Columns.Add(new GridNumericColumn() { MappingName = "Step_SendKeyQty", HeaderText = "Send Qty", MinimumWidth = 8, Width = 75, AllowEditing = false, Format = "0.#####" });
            dgv_ManageMoveSequence.Columns.Add(new GridNumericColumn() { MappingName = "Step_Count", HeaderText = "Step Count", MinimumWidth = 8, Width = 75, AllowEditing = false, Format = "0.#####" });
            dgv_ManageMoveSequence.Columns.Add(new GridTextColumn() { MappingName = "Step_SendKey", HeaderText = "Send Key", MinimumWidth = 8, Width = 75, AllowEditing = false, Visible = false });
            dgv_ManageMoveSequence.Columns.Add(new GridTextColumn() { MappingName = "Step_Display", HeaderText = "Step Display", MinimumWidth = 8, Width = 100, AllowEditing = false });

            dgv_ManageMoveSequence.AllowEditing = false;
        }

        private void LoadSequenceSteps(int MoveSeqParentID, bool SetToFirstRow)
        {
            List<StepSequenceModel> lstSeqSteps = new List<StepSequenceModel>();
            lstSeqSteps = Data_Access_Methods.LoadSequenceStepList(MoveSeqParentID);
            if (lstSeqSteps.Count > 0) //If we have records
            {
                //If SetToFirstRow is false 
                if (SetToFirstRow == false)
                {
                    //The idea here is to highlight (select) the same row that was selected before the re-bind
                    m_CurrentRowIndex_MoveSteps = (dgv_ManageMoveSequence.SelectedIndex);

                    dgv_ManageMoveSequence.DataSource = lstSeqSteps; //Rebind the datagrid now

                    dgv_ManageMoveSequence.ClearSelection();
                    dgv_ManageMoveSequence.SelectedIndex = m_CurrentRowIndex_MoveSteps;
                }
                else
                {
                    dgv_ManageMoveSequence.DataSource = lstSeqSteps; //We rebind the datagrid
                    dgv_ManageMoveSequence.SelectedIndex = 0; //Set to first (top most) row
                }
            }
            else //No records
            {
                dgv_ManageMoveSequence.DataSource = lstSeqSteps; //We still rebind the datagrid
            }
        }

        private void dgv_ManageMoveSequence_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            try
            {
                //Fetch the currently selected datagrid row
                var rowIndex = this.dgv_ManageMoveSequence.SelectionController.DataGrid.CurrentCell.RowIndex;
                var recordIndex = dgv_ManageMoveSequence.TableControl.ResolveToRecordIndex(rowIndex);

                var cellValue_StepID = DataGridHelper.GetCellValue(dgv_ManageMoveSequence, recordIndex, -1, "Step_ID"); //Get the Step_ID column value
                m_SelectedMoveSeqStepID = (int)cellValue_StepID; //Update the global variable value
                var cellValue_Step_Name = DataGridHelper.GetCellValue(dgv_ManageMoveSequence, recordIndex, -1, "Step_Name"); //Get the Step_Name column value
                var cellValue_Step_SendKey = DataGridHelper.GetCellValue(dgv_ManageMoveSequence, recordIndex, -1, "Step_SendKey"); //Get the Step_SendKey column value
                var cellValue_Step_SendKeyQty = DataGridHelper.GetCellValue(dgv_ManageMoveSequence, recordIndex, -1, "Step_SendKeyQty"); //Get the Step_SendKeyQty column value
                var cellValue_Step_Count = DataGridHelper.GetCellValue(dgv_ManageMoveSequence, recordIndex, -1, "Step_Count"); //Get the Step_ID column value

                //Show which step is selected for possible editing
                lbl_ManageSeqSelected.Text = string.Concat("Selected Step is Step ID:", m_SelectedMoveSeqStepID.ToString(), ", Step Name:", cellValue_Step_Name.ToString(), " Step/Angle Count:", cellValue_Step_Count.ToString());

                //Set the controls per the selected Move Step values
                drp_ManageSeqStepNameList.SelectedValue = cellValue_Step_SendKey;
                num_ManageSeqSendKeyQty.Value = (int)cellValue_Step_SendKeyQty;
            }
            catch (Exception ex)
            {
                LogException("dgv_ManageMoveSequence_SelectionChanged", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ dgv_ManageMoveSequence_SelectionChanged. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ManageSeqUpdateStep_Click(object sender, EventArgs e)
        {
            MoveSequenceModel selectedSeq = (MoveSequenceModel)drp_ManageSeqMoveSequences.SelectedItem;
            if (selectedSeq == null)
            {
                MessageBoxAdv.Show("Please select a Move Sequence.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; //Bail
            }

            //Fetch the currently selected datagrid row
            var rowIndex = this.dgv_ManageMoveSequence.SelectionController.DataGrid.CurrentCell.RowIndex;
            var recordIndex = dgv_ManageMoveSequence.TableControl.ResolveToRecordIndex(rowIndex);

            var cellValue_StepID = DataGridHelper.GetCellValue(dgv_ManageMoveSequence, recordIndex, -1, "Step_ID"); //Get the Step_ID column value
            var cellValue_StepGroup = DataGridHelper.GetCellValue(dgv_ManageMoveSequence, recordIndex, -1, "Step_Group"); //Get the Step_Group column value
            var cellValue_Step_Display = DataGridHelper.GetCellValue(dgv_ManageMoveSequence, recordIndex, -1, "Step_Display"); //Get the Step_Display column value

            if (recordIndex < 0) //If we do not have a record selected (recordIndex = -1)
            {
                MessageBoxAdv.Show(string.Concat("Please select a Move Sequence."), "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Let's make sure the user has selected a Seq Step name from the dropdown list
            if (drp_ManageSeqStepNameList.SelectedValue.ToString() == "")
            {
                MessageBoxAdv.Show(this, "Please select a Step Name.", "Move Step Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                drp_ManageSeqStepNameList.Select();
                return;
            }

            //Get modify confirmation
            DialogResult result = MessageBoxAdv.Show(string.Concat("Are you sure you want to modify Move Step '", cellValue_Step_Display, "'? This cannot be undone!"), "Confirm Step Change", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //Collect the data values for the step addition
                MoveSequenceModel selectedSeqName = (MoveSequenceModel)drp_ManageSeqMoveSequences.SelectedItem;
                string SeqParentID = selectedSeqName.ID.ToString(); //Get the selected sequence parent ID

                StepNameListModel selectedStepNameList = (StepNameListModel)drp_ManageSeqStepNameList.SelectedItem;

                //Get the step values from the selectedStepNameList object
                string StepName = selectedStepNameList.Step_Name.ToString(); //Get the selected step StepName (ex WF)
                string StepSendKey = selectedStepNameList.Step_SendKey.ToString(); //Get the selected step SendKey (ex w)

                //Get the entered send key count
                //Minimum value of control is one so no need to check for zero entry
                int SendKeyQtyUserEntry = (int)num_ManageSeqSendKeyQty.Value;

                //Fetch the appropriate value from mtbx_SlidingWalkingCount or mtbx_LookingRollingAngle
                int CountAngleMainformEntry = GetStepAngleCountValue_FromMainForm(StepName);

                //Call the update to the Step per Step_ID
                Data_Access_Methods.ManageSeqUpdateStep((int)cellValue_StepID, (int)cellValue_StepGroup, StepName, SendKeyQtyUserEntry, StepSendKey, CountAngleMainformEntry);

                num_ManageSeqSendKeyQty.Value = 1; //Restore the step count entry to 1 after this step update

                //Reload the Steps dataggrid
                LoadSequenceSteps(m_SelectedMoveSequenceID, false);

                SetManageSeqFooterMessage("Be sure the affected Mandelbulb3D keyframe is updated according to the Move Step changes you just made.");
            }
        }

        private void btn_ManageSeqDeleteStep_Click(object sender, EventArgs e)
        {
            MoveSequenceModel selectedSeq = (MoveSequenceModel)drp_ManageSeqMoveSequences.SelectedItem;
            if (selectedSeq == null)
            {
                MessageBoxAdv.Show("Please select a Move Sequence.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; //Bail
            }

            //Fetch the currently selected datagrid row
            var rowIndex = this.dgv_ManageMoveSequence.SelectionController.DataGrid.CurrentCell.RowIndex;
            var recordIndex = dgv_ManageMoveSequence.TableControl.ResolveToRecordIndex(rowIndex);

            var cellValue_StepID = DataGridHelper.GetCellValue(dgv_ManageMoveSequence, recordIndex, -1, "Step_ID"); //Get the Step_ID column value
            var cellValue_Step_Display = DataGridHelper.GetCellValue(dgv_ManageMoveSequence, recordIndex, -1, "Step_Display"); //Get the Step_Display column value

            if (recordIndex < 0) //If we do not have a record selected
            {
                MessageBoxAdv.Show(string.Concat("Please select a Move Sequence."), "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if ((int)cellValue_StepID > 0) //If we have a record selected (just double checking)
            {
                //Get delete confirmation
                DialogResult result = MessageBoxAdv.Show(string.Concat("Are you sure you want to delete Move Step '", cellValue_Step_Display, "'? This cannot be undone!"), "Confirm Step Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //Call the Move Step delete proc
                    Data_Access_Methods.DeleteStep(m_SelectedMoveSequenceID, (int)cellValue_StepID);

                    //Reload the steps for the selected sequence
                    LoadSequenceSteps(m_SelectedMoveSequenceID, false);

                    //Footer Message
                    SetManageSeqFooterMessage("Be sure that the Mandelbulb3D keyframe is updated according to the Move Step changes you just made.");
                }
            }
        }

        private void btn_ManageSeqAddStep_Click(object sender, EventArgs e)
        {
            MoveSequenceModel selectedSeq = (MoveSequenceModel)drp_ManageSeqMoveSequences.SelectedItem;
            if (selectedSeq == null)
            {
                MessageBoxAdv.Show("Please select a Move Sequence.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; //Bail
            }

            //Let's make sure the user has selected a Seq Step name from the dropdown list
            if (drp_ManageSeqStepNameList.SelectedValue.ToString() == "")
            {
                MessageBoxAdv.Show(this, "Please select a Move Step.", "Move Step Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                drp_ManageSeqStepNameList.Select();
                return;
            }

            //Collect the data values for the step addition
            int MoveSeqParentID = selectedSeq.ID; //Get the selected sequence parent ID

            //Get the selected Step Name List item
            StepNameListModel selectedStepNameList = (StepNameListModel)drp_ManageSeqStepNameList.SelectedItem;
            string MoveStepName = selectedStepNameList.Step_Name; //Get the selected step StepName (ex WF)
            int MoveStepGroup = selectedStepNameList.Step_Group; //Get the selected step StepGroup value
            string MoveStepSendKey = selectedStepNameList.Step_SendKey; //Get the selected step SendKey (ex w)

            //Get the entered step count
            int MoveStepCount = (int)num_ManageSeqSendKeyQty.Value;

            //Call the add Move Step proc
            Data_Access_Methods.ManageSeqAddMoveStep(MoveSeqParentID, MoveStepGroup, MoveStepName, MoveStepCount, MoveStepSendKey);

            //Reload the steps for the selected sequence
            LoadSequenceSteps(MoveSeqParentID, false);

            //Footer Message
            SetManageSeqFooterMessage("Be sure that the Mandelbulb3D keyframe is updated according to the Move Step changes you just made.");
        }

        private void SetManageSeqFooterMessage(string FooterMessage)
        {
            lbl_ManageSeqFooterMsgArea.Text = FooterMessage;
            ClearManageSeqMessageTmr.Interval = ClearManageSeqFooterMessageInterval;
            ClearManageSeqMessageTmr.Start(); //Start or re-start the footer message timer
        }

        private void ClearManageSeqMessage_Tick(object sender, EventArgs e)
        {
            lbl_ManageSeqFooterMsgArea.Text = string.Empty;
        }

        #endregion

        #region Utility Methods =============================================================== 

        private void btn_FarPlaneUpdater_Click(object sender, EventArgs e)
        {

            //Open the frmUpdateKeyframesFarPlane form
            frmUpdateKeyframesFarPlane = new frm_Update_Keyframes_FarPlane();

            //Check if the child form is already open
            if (System.Windows.Forms.Application.OpenForms.OfType<frm_MakeMoveSequence>().Count() == 0)
            {
                //Set the parent form of this child window
                frmUpdateKeyframesFarPlane.Owner = this;

                //Display the form as dialog
                frmUpdateKeyframesFarPlane.ShowDialog();
            }
            else
            {
                frmUpdateKeyframesFarPlane.Focus();
            }
        }

        private void btn_LookLeftUpdater_Click(object sender, EventArgs e)
        {
            //Open the frm_Update_Keyframes_LookLeft form
            frmUpdateKeyframesLookLeft = new frm_Update_Keyframes_LookLeft();

            //Check if the child form is already open
            if (System.Windows.Forms.Application.OpenForms.OfType<frm_Update_Keyframes_LookLeft>().Count() == 0)
            {
                //Set the parent form of this child window
                frmUpdateKeyframesLookLeft.Owner = this;

                //Display the form as dialog
                frmUpdateKeyframesLookLeft.ShowDialog();
            }
            else
            {
                frmUpdateKeyframesLookLeft.Focus();
            }
        }

        private void btn_ParameterUpdater_Click(object sender, EventArgs e)
        {
            //Open the frm_Update_Keyframes_Parameter form
            frmUpdateKeyframesParameter = new frm_Update_Keyframes_Parameter();

            //Check if the child form is already open
            if (System.Windows.Forms.Application.OpenForms.OfType<frm_Update_Keyframes_Parameter>().Count() == 0)
            {
                //Set the parent form of this child window
                frmUpdateKeyframesParameter.Owner = this;

                //Display the form as dialog
                frmUpdateKeyframesParameter.ShowDialog();
            }
            else
            {
                frmUpdateKeyframesParameter.Focus();
            }
        }

        #endregion

        #region Application Admin Methods =============================================================================== 

        private void GetDatabaseFilePathName()
        {
            string dbFilePathName = string.Empty;

            try
            {
                string strAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                dbFilePathName = string.Concat(strAppDataFolder, @"\MB3D Copilot\MB3DAnimationCopilot.db");
            }
            catch (Exception ex)
            {
                LogException("GetDatabaseFilePathName", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ GetDatabaseFilePathName. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lbl_DatabaseFileInUse.Text = dbFilePathName;
        }

        private void btn_DBAdmin_BackupFolder_Click(object sender, EventArgs e)
        {
            string dirApp = AppDomain.CurrentDomain.BaseDirectory; //Get the root folder of the application's exe

            using (FolderBrowserDialog folderBrowserDialog_DBBackupFolder = new FolderBrowserDialog())
            {
                folderBrowserDialog_DBBackupFolder.SelectedPath = dirApp;

                folderBrowserDialog_DBBackupFolder.ShowNewFolderButton = true;

                if (folderBrowserDialog_DBBackupFolder.ShowDialog() == DialogResult.OK)
                {
                    tbx_DBAdmin_Backup_FolderName.Text = string.Concat(folderBrowserDialog_DBBackupFolder.SelectedPath, @"\");
                }
            }
        }

        private void btn_DBAdmin_Backup_Click(object sender, EventArgs e)
        {
            try
            {

                //Test entries
                if (tbx_DBAdmin_Backup_DBNewFileName.Text.Length == 0 | tbx_DBAdmin_Backup_FolderName.Text.Length == 0)
                {
                    MessageBoxAdv.Show("You must provide a destination database file name and folder.", "Entry Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; //Bail
                }

                string strNewDBFileName = tbx_DBAdmin_Backup_DBNewFileName.Text;
                string strNewDBFolderName = tbx_DBAdmin_Backup_FolderName.Text;

                //Check for .db file extension and append if missing
                if (strNewDBFileName.EndsWith(".db") == false)
                {
                    strNewDBFileName = string.Concat(strNewDBFileName, ".db");
                }

                //Assemble the database destination file/path
                string strDBBackupFileNamePath = string.Concat(strNewDBFolderName, @"\", strNewDBFileName); //The backup TO folder and file name

                //Perform the database backup                
                bool bolBackupResult = Data_Access_Methods.BackupDatabase(strDBBackupFileNamePath); //Perforn the backup

                if (bolBackupResult)
                {
                    MessageBoxAdv.Show(string.Concat("The database was successfully backed up to ", strDBBackupFileNamePath), "Backup Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxAdv.Show(string.Concat("The database did not back up. Please check that the destination is correct: ", strDBBackupFileNamePath), "Backup Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogException("btn_DBAdmin_Backup_Click", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ btn_DBAdmin_Backup_Click. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_DBAdmin_RestoreDBFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog_BackupFindFile.ShowDialog() == DialogResult.OK)
            {
                //Check for .db file extension
                if (openFileDialog_BackupFindFile.FileName.EndsWith(".db") == false)
                {
                    MessageBoxAdv.Show("The selected file does not appear to be a database file (with an 'db' file extension.", "Incorrect File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; //Bail
                }

                tbx_DBAdmin_Restore_DBFolder.Text = openFileDialog_BackupFindFile.FileName;
            }
        }

        private void btn_DBAdmin_Restore_Click(object sender, EventArgs e)
        {
            try
            {
                //Test entries
                if (tbx_DBAdmin_Restore_DBFolder.Text.Length == 0 | tbx_DBAdmin_Restore_DBFolder.Text.Length == 0)
                {
                    MessageBoxAdv.Show("You must select a database file to restore from.", "Entry Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; //Bail
                }
                string strDBBackupFileNamePath = tbx_DBAdmin_Restore_DBFolder.Text; //The backup From file path name

                //Perform the database resore                
                bool bolRestoreResult = Data_Access_Methods.RestoreDatabase(strDBBackupFileNamePath); //Perforn the restore

                if (bolRestoreResult)
                {
                    LoadAndInitMainForm();
                    MessageBoxAdv.Show(string.Concat("The database was successfully restored from ", strDBBackupFileNamePath, "."), "Restore Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxAdv.Show(string.Concat("The database did not restore. Please check that the restore file is correct: ", strDBBackupFileNamePath), "Backup Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogException("btn_DBAdmin_Restore_Click", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ btn_DBAdmin_Restore_Click. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_EraseAllDatabaseRecords_Click(object sender, EventArgs e)
        {
            var NL = Environment.NewLine;

            //Get database purge confirmation
            DialogResult result1 = MessageBoxAdv.Show(string.Concat("You are about to delete all of the records of your database!", NL, NL, "This can only be undone if you restore the database from a backup.", NL, NL, "Proceed"), "Confirm Database Purge", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
            {
                //Get database purge confirmation
                DialogResult result2 = MessageBoxAdv.Show(string.Concat("Are you very sure?", NL, NL, "This will delete all projects, all keyframes and all Move Sequence records.", NL, NL, "This can only be undone if you restore the database from a backup.", NL, NL, "Proceed?"), "Confirm Database Purge", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result2 == DialogResult.Yes)
                {
                    //Perform the database purge                
                    if (Data_Access_Methods.EraseAllDatabaseRecords(true))
                    {
                        PrepareMainformPostPurge();
                        MessageBoxAdv.Show("Your database has been purged of all records.", "Purge Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btn_EraseAllDatabaseRecords_KeepMS_Click(object sender, EventArgs e)
        {
            var NL = Environment.NewLine;

            //Get database purge confirmation
            DialogResult result1 = MessageBoxAdv.Show(string.Concat("You are about to delete all of the records of your database except Move Sequence records!", NL, NL, "This can only be undone if you restore the database from a backup.", NL, NL, "Proceed"), "Confirm Database Purge", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
            {
                //Get database purge confirmation
                DialogResult result2 = MessageBoxAdv.Show(string.Concat("Are you very sure?", NL, NL, "This will delete all projects and all keyframes (keeping Move Sequence records).", NL, NL, "This can only be undone if you restore the database from a backup.", NL, NL, "Proceed?"), "Confirm Database Purge", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result2 == DialogResult.Yes)
                {
                    //Perform the database purge                
                    if (Data_Access_Methods.EraseAllDatabaseRecords(false))
                    {
                        PrepareMainformPostPurge();
                        MessageBoxAdv.Show("Your database has been purged of all records except Move Sequence records.", "Purge Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void PrepareMainformPostPurge()
        {
            PopulateProjectList(-1);

            tbx_AnimationName.Text = string.Empty;
            tbx_ProjectNotes.Text = string.Empty;
            mtbx_SlidingWalkingCount.Value = cSlideWalkStepCountDefault;
            mtbx_LookingRollingAngle.Value = cLookingRollingAngleDefault;
            mtbx_FramesBetween.Value = cFramesBetweenDefault;
            mtbx_KeyDelay.Value = cKeyDelayDefault;
            mtbx_FrameCount.Value = 0;
            m_TotalFramesCount = 0;
            mtbx_FarPlane.Value = 0;
            lbl_30FPSTimeCalc.Text = "00:00";
            lbl_60FPSTimeCalc.Text = "00:00";
            tbx_M3PI_FileLocation.Text = string.Empty;
            tbx_M3A_FileLocation.Text = string.Empty;

            PopulateKeyframesDatagrid(false);
            PopulateUseSequenceList();
            PopulateManageSeqStepNameList();
        }

        private void btn_CreateSampleProject_Click(object sender, EventArgs e)
        {
            var NL = Environment.NewLine;
            string SampleProjectName = ConfigurationManager.AppSettings["SampleProjectName"];

            if (Data_Access_Methods.ProjectRecordExistByProjectName(SampleProjectName) > 0)
            {
                DialogResult result = MessageBoxAdv.Show(string.Concat("A sample animation project already exists and will need to be replaced.", NL, NL, "Proceed with replacing the existing sample project?"), "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    goto CreateSampleProject;
                }
                return; //Bail
            }

            //Get user confirmation
            DialogResult result1 = MessageBoxAdv.Show(string.Concat("You are about to create a sample animation project named '", SampleProjectName, "'.", NL, NL, "Proceed"), "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
            {
                goto CreateSampleProject;
            }
            return; //Bail

        CreateSampleProject:

            if (Data_Access_Methods.CreateSampleAnimationProject(SampleProjectName))
            {
                mtbx_FarPlane.Value = 500; //Update the UI to be consistent with the value of FarPlane for the sample records

                PopulateProjectList(-1);

                List<ProjectListModel> lstProjectList = null;
                lstProjectList = Data_Access_Methods.LoadProjectsList();

                var idx = 0;
                //Loop across the project list and try to find a matching project ID
                foreach (ProjectListModel item in lstProjectList)
                {
                    if (item.Project_Name == SampleProjectName)
                    {
                        break;
                    }
                    idx += 1;
                }

                //And set the dropdown to the found item
                //Note: The Change event of drp_ProjectList will fire LoadProjectData and PopulateKeyframesDatagrid to populate the UI
                drp_ProjectList.SelectedIndex = idx;

                MessageBoxAdv.Show(string.Concat("A sample animation project named '", SampleProjectName, "' has been created."), "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        #endregion

        #region External Link Methods =============================================================================== 

        private void ll_GithubRespository_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Change the color of the link text by setting LinkVisited to true.
                ll_GithubRespository.LinkVisited = true;

                //Call the Process.Start method to open the default browser with a URL:
                Process.Start(new ProcessStartInfo(e.Link.LinkData.ToString()) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                LogException("ll_GithubRespository_LinkClicked", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ ll_GithubRespository_LinkClicked. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ll_GithubRespository_About_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Change the color of the link text by setting LinkVisited to true.
                ll_GithubRespository_About.LinkVisited = true;

                //Call the Process.Start method to open the default browser with a URL:
                Process.Start(new ProcessStartInfo(e.Link.LinkData.ToString()) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                LogException("ll_GithubRespository_About_LinkClicked", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ ll_GithubRespository_About_LinkClicked. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ll_PCGithubURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Change the color of the link text by setting LinkVisited to true.
                ll_PCGithubURL.LinkVisited = true;

                //Call the Process.Start method to open the default browser with a URL:
                Process.Start(new ProcessStartInfo(e.Link.LinkData.ToString()) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                LogException("ll_PCGithubURL_LinkClicked", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ ll_PCGithubURL_LinkClicked. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ll_PCGithubURL_About_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Change the color of the link text by setting LinkVisited to true.
                ll_PCGithubURL_About.LinkVisited = true;

                //Call the Process.Start method to open the default browser with a URL:
                Process.Start(new ProcessStartInfo(e.Link.LinkData.ToString()) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                LogException("ll_PCGithubURL_About_LinkClicked", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ ll_PCGithubURL_About_LinkClicked. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ll_JoyToKey_About_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Change the color of the link text by setting LinkVisited to true.
                ll_JoyToKey_About.LinkVisited = true;

                //Call the Process.Start method to open the default browser with a URL:
                Process.Start(new ProcessStartInfo(e.Link.LinkData.ToString()) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                LogException("ll_JoyToKey_About_LinkClicked", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ ll_JoyToKey_About_LinkClicked. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtbx_ReadMeRTF_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            //Call the Process.Start method to open the default browser with a URL:
            Process.Start(new ProcessStartInfo(e.LinkText) { UseShellExecute = true });
        }

        private void rtbx_LicenseRTF_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            //Call the Process.Start method to open the default browser with a URL:
            Process.Start(new ProcessStartInfo(e.LinkText) { UseShellExecute = true });
        }

        #endregion

        #region Send Key & Mouse Event =============================================================================== 

        private void SendKeyEvent(ushort strKeyCode)
        {

            //Reference for below: https://www.codeproject.com/Articles/5264831/How-to-Send-Inputs-using-Csharp

            //############### THIS EVENT HANDLER IS NOT USED AT THIS TIME #########################

            Input[] inputs = new Input[]
            {
                new Input
                {
                    type = (int)InputType.Keyboard,
                    u = new InputUnion
                    {
                        ki = new KeyboardInput
                        {
                            wVk = 0,
                            wScan = strKeyCode,
                            dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                            dwExtraInfo = GetMessageExtraInfo()
                        }
                    }
                },
                new Input
                {
                    type = (int)InputType.Keyboard,
                    u = new InputUnion
                    {
                        ki = new KeyboardInput
                        {
                            wVk = 0,
                            wScan = strKeyCode,
                            dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.Scancode),
                            dwExtraInfo = GetMessageExtraInfo()
                        }
                    }
                }
            };

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
        }

        private void SendMouseEvent()
        {
            //Reference for below: https://www.codeproject.com/Articles/5264831/How-to-Send-Inputs-using-Csharp

            Input[] inputs = new Input[]
            {
                new Input
                {
                    type = (int) InputType.Mouse,
                    u = new InputUnion
                    {
                        mi = new MouseInput
                        {
                            dx = 0,
                            dy = 0,
                            dwFlags = (uint)(MouseEventF.Move | MouseEventF.LeftDown),
                            dwExtraInfo = GetMessageExtraInfo()
                        }
                    }
                },
                new Input
                {
                    type = (int) InputType.Mouse,
                    u = new InputUnion
                    {
                        mi = new MouseInput
                        {
                            dwFlags = (uint)MouseEventF.LeftUp,
                            dwExtraInfo = GetMessageExtraInfo()
                        }
                    }
                }
            };

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));

        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MouseInput
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KeyboardInput
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [Flags]
        public enum KeyEventF
        {
            KeyDown = 0x0000,
            ExtendedKey = 0x0001,
            KeyUp = 0x0002,
            Unicode = 0x0004,
            Scancode = 0x0008
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HardwareInput
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        public struct Input
        {
            public int type;
            public InputUnion u;
        }

        [Flags]
        public enum InputType
        {
            Mouse = 0,
            Keyboard = 1,
            Hardware = 2
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)] public MouseInput mi;
            [FieldOffset(0)] public KeyboardInput ki;
            [FieldOffset(0)] public HardwareInput hi;
        }

        [Flags]
        public enum MouseEventF
        {
            Absolute = 0x8000,
            HWheel = 0x01000,
            Move = 0x0001,
            MoveNoCoalesce = 0x2000,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            VirtualDesk = 0x4000,
            Wheel = 0x0800,
            XDown = 0x0080,
            XUp = 0x0100
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        [DllImport("User32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        #endregion

        #region Error Handling and Logging =========================================================================== 

        public void LogException(string argProcedureName, Exception ex)
        {

            string ErrorFilePathName = GetErrorLogPathName();

            string ExistingErrorText = string.Empty;
            if (File.Exists(ErrorFilePathName))
            {
                ExistingErrorText = File.ReadAllText(ErrorFilePathName);
            }

            using (StreamWriter writer = new StreamWriter(ErrorFilePathName, false))
            {
                writer.WriteLine("Date/Time : " + DateTime.Now.ToString());
                writer.WriteLine("Error @ " + argProcedureName);
                writer.WriteLine();
                while (ex != null)
                {
                    writer.WriteLine(ex.GetType().FullName);
                    writer.WriteLine("Message : " + ex.Message);
                    writer.WriteLine("StackTrace : " + ex.StackTrace);

                    ex = ex.InnerException;
                }
                writer.WriteLine("============================================================================");

                if (ExistingErrorText.Length > 0)
                {
                    writer.WriteLine(ExistingErrorText);
                }
            }

            //If the Admin page is open, load the Error Log textbox immediately
            if (tabControl1.SelectedTab.Name == "page_Admin")
            {
                LoadErrorFileTextbox();
            }

        }

        public void LoadErrorFileTextbox()
        {
            string ErrorFilePathName = GetErrorLogPathName();

            if (File.Exists(ErrorFilePathName))
            {
                using (StreamReader reader = new StreamReader(ErrorFilePathName))
                {
                    tbx_ErrorLogContent.Text = reader.ReadToEnd();
                }
            }
            else
            {
                tbx_ErrorLogContent.Text = "No Log File Found";
            }
        }

        private void btn_CopyLog_Click(object sender, EventArgs e)
        {
            string ErrorFilePathName = GetErrorLogPathName();

            if (File.Exists(ErrorFilePathName))
            {
                string ErrorText = String.Empty;
                using (StreamReader reader = new StreamReader(ErrorFilePathName))
                {
                    ErrorText = reader.ReadToEnd();
                    reader.Dispose();
                }

                Clipboard.Clear();

                //Ref: Clipboard.SetDataObject(object data, bool copy, int retryTimes, int retryDelay)
                Clipboard.SetDataObject(ErrorText, true, 10, 100);

                MessageBoxAdv.Show("The Error Log was copied to your Windows Clipboard.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxAdv.Show("No Error Log was found.", "Nothing to Copy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_ErrorLogLocation_Click(object sender, EventArgs e)
        {

            string ErrorFilePathName = GetErrorLogPathName();

            if (File.Exists(ErrorFilePathName))
            {
                MessageBoxAdv.Show(string.Concat("The Error Log file is located at:", Environment.NewLine, Environment.NewLine, ErrorFilePathName), "Error Log", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxAdv.Show(string.Concat("When an Error Log file exists, it's location will be:", Environment.NewLine, Environment.NewLine, ErrorFilePathName), "Error Log", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_EraseLog_Click(object sender, EventArgs e)
        {
            string ErrorFilePathName = GetErrorLogPathName();

            if (File.Exists(ErrorFilePathName))
            {
                DialogResult result = MessageBoxAdv.Show("Are you sure you want to erase the Error Log?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    File.Delete(ErrorFilePathName);
                    LoadErrorFileTextbox();
                    MessageBoxAdv.Show("The Error Log was erased.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBoxAdv.Show("No Error Log was found.", "Nothing to Erase", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GetErrorLogPathName()
        {
            return string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"\", ConfigurationManager.AppSettings["AppDataPathSub"], @"\", ConfigurationManager.AppSettings["ErrorLogFileName"]);
        }

        #endregion

    }
}