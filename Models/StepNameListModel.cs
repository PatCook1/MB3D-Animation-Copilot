/*========================================================================================
File: MB3D_Animation_Copilot.Models.StepNameListModel
Description: This class provides the data structure for a dropdown list of available moves (actions).
Original Author: Patrick C. Cook
Copyright: Patrick C. Cook 2025
License: GNU GENERAL PUBLIC LICENSE Version 3
========================================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB3D_Animation_Copilot.Models
{
    internal class StepNameListModel
    {
        public int Step_Group { get; set; }
        public string Step_Name { get; set; }
        public int Step_AngleCount { get; set; }
        public string Step_SendKey { get; set; }
        public string Step_Display
        {
            get
            {
                return string.Concat(Step_Name, " (", Step_AngleCount, ")");
            }
        }
    }
}

