using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MB3D_Animation_Copilot.Child_Forms
{
    public partial class frm_Update_Keyframes_LookLeft : Form
    {

        #region Public Constants ==========================================

        public static int WH_KEYBOARD_LL = 13;
        public static int WM_KEYDOWN = 0x100;
        public static int WM_KEYUP = 0x101;

        public const string cMB3DMainClassName = "TMand3DForm";
        public const string cMB3DNavigatorClassName = "TFNavigator";
        public const string cMB3DAnimatorClassName = "TAnimationForm";

        public static bool m_ProcessStop = false;

        #endregion

        #region WIN DLL's ==========================================

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

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

        #region Main Program Code =================================================

        public frm_Update_Keyframes_LookLeft()
        {
            InitializeComponent();
        }

        private void BringFocusToThisApplication()
        {
            this.Focus(); //Set focus to this application
        }

        private void btn_UpdateKeyframes_LookLeft_Click(object sender, EventArgs e)
        {
            var NL = Environment.NewLine;

            StringBuilder sb = new StringBuilder();
            sb.Append("1. Be sure the Mandelbulb3D application is running and not in an error state.");
            sb.Append(NL);
            sb.Append(NL);
            sb.Append("2. Be sure the starting keyframe is selected.");
            sb.Append(NL);
            sb.Append(NL);
            sb.Append("3. Be sure that the Navigator is open and its panel is expanded that contains the Walking/Looking entryfield and has the desired value.");
            sb.Append(NL);
            sb.Append(NL);
            sb.Append("4. Be sure that the Animation and Navigator windows are covered.");
            sb.Append(NL);
            sb.Append(NL);
            sb.Append("5. Do not use the mouse until this process completes.");
            sb.Append(NL);
            sb.Append(NL);
            sb.Append("Proceed with the Look Left update?");

            //Confirm that the Mandelbulb3D application is running
            DialogResult result = MessageBoxAdv.Show(sb.ToString(), "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UpdateKeyframes_LookLeftUpdate();
            }
        }

        private bool UpdateKeyframes_LookLeftUpdate()
        {
            //Provide entries
            //1. Number of keyframe to modify the Look Left

            //The steps:
            //1. Set focus on the animation window
            //2. Position mouse at X/Y position, which is the Send to Main arrow button
            //3. Left click the mouse - this pushes the keyframe to the Navigator window
            //4. Set focus on the navigator window
            //5. Position mouse at X position - the "Parameter" button (no window handle for this button)
            //6. Set focus on the Look Left button
            //7. Left click the mouse to actuate the Look Left button
            //8. Send Key "F" to update the keyframe (no window handle for the Send Anim button)
            //      This will advance the keyfarame in the Anaimation Window IF "Go to Next Keyframe" is check
            //9. Repeat steps 1-8 for all keyframes up to the number of keyframes entered

            try
            {
                BringFocusToThisApplication(); //Bring focus back to this application; //Bring focus to this application

                //Collect the needed data
                int intKeyframeQuantity = Convert.ToInt32(mtbx_NumberKeyframes_UpdateLook.Text);

                lbl_EscapeIndicator_UpdateLookLeft.Visible = true;
                bool bolEndThisLoop = false;

                for (int i = 1; i < (intKeyframeQuantity + 1); i++)
                {
                    if (bolEndThisLoop) { break; } //Was stop detected in the inner loop?

                    lbl_WorkingOnKeyframeNum_LookLeft.Text = i.ToString();

                    if (PerformAnimationActions_LookUpdate())
                    {
                        System.Threading.Thread.Sleep(2000); //Time to breath
                        if (PerformNavigatorActions_LookUpdate())
                        {
                            if (m_ProcessStop) { bolEndThisLoop = true; } //Check if user has requested stop
                            System.Threading.Thread.Sleep(4000); //Hold on Nelly!
                        }
                    }
                }

                BringFocusToThisApplication(); //Bring focus back to this application;

                System.Threading.Thread.Sleep(2000); //Let the last far Plane fix settle down
                if (m_ProcessStop == false)
                {
                    MessageBoxAdv.Show(String.Concat("Updating of the Look Left has completed for ", intKeyframeQuantity.ToString(), " keyframes. Be sure to save the Animation."), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxAdv.Show(String.Concat("Updating of the Look Left has been halted."), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                lbl_WorkingOnKeyframeNum_LookLeft.Text = "0";
                lbl_EscapeIndicator_UpdateLookLeft.Visible = false;
                m_ProcessStop = false;

                return true;
            }
            catch (Exception ex)
            {
                //string error = ex.Message;
                MessageBoxAdv.Show(ex.Message, "Error @ UpdateKeyframes_LookLeftUpdate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private bool PerformAnimationActions_LookUpdate()
        {
            try
            {
                //Get the handle of the Mandelbulb3D Animator window
                IntPtr hWnd = FindWindow(cMB3DAnimatorClassName, null);

                //Get the Top/Left position of the window
                RECT rct = new RECT();
                GetWindowRect(hWnd, ref rct);

                //Calculate the mouse position to place the mouse cursor over the keyframe "Send parameter to main" arrow button2288
                int NewX = rct.Left + 427;
                int NewY = rct.Top + 41;

                //Ge the calculated mouse cooridinates into a Point object
                Point NewPoint = new Point();
                NewPoint.X = NewX;
                NewPoint.Y = NewY;

                //Set the cursor position
                SetCursorPos(NewX, NewY);

                //Call the SendMouseEvent sub
                //This clicks the arrow button to get the selected Keyframe into the Main Editor
                SendMouseEvent();

                return true;
            }
            catch (Exception ex)
            {
                //string error = ex.Message;
                MessageBoxAdv.Show(ex.Message, "Error @ PerformAnimationActions_LookUpdate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private bool PerformNavigatorActions_LookUpdate()
        {
            try
            {

                //Get the handle of the Mandelbulb3D Navigator window
                IntPtr hWnd = FindWindow(cMB3DNavigatorClassName, null);

                //Get the Top/Left position of the window
                RECT rct = new RECT();
                GetWindowRect(hWnd, ref rct);

                //Calculate the mouse position to place the mouse cursor over the "Parameter" button
                int NewX = rct.Left + 607;
                int NewY = rct.Top + 538;

                //Set the cursor position
                SetCursorPos(NewX, NewY);

                //Call the SendMouseEvent sub
                //This clicks the "Parameters" button to get the selected Keyframe into the Navigator
                SendMouseEvent();

                //Calculate the mouse position to place the mouse cursor over the "Look Left" button
                NewX = rct.Left + 333;
                NewY = rct.Top + 558;

                //Set the cursor position
                SetCursorPos(NewX, NewY);

                //Send the mouse Left click twice to click the "Look Left" button
                SendMouseEvent();

                //Calculate the mouse position to place the mouse cursor over the Ani Key" button
                NewX = rct.Left + 35;
                NewY = rct.Top + 575;

                //Set the cursor position
                SetCursorPos(NewX, NewY);

                //Send the mouse Left click 
                SendMouseEvent();

                return true;
            }
            catch (Exception ex)
            {
                //string error = ex.Message;
                MessageBoxAdv.Show(ex.Message, "Error @ PerformNavigatorActions_LookUpdate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        #endregion
    }
}
