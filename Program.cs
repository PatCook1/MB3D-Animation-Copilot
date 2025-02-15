using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MB3D_Animation_Copilot
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            //Register Syncfusion license https://help.syncfusion.com/common/essential-studio/licensing/how-to-generate
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzcwODQ4NEAzMjM4MmUzMDJlMzBkSm9QSTRGdnhXQ2Z5c0o0VFNRM3VXMzJiNnJHK1ZrbC80ZUpmcHUwU3NJPQ==");

            SkinManager.LoadAssembly(typeof(HighContrastTheme).Assembly);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
