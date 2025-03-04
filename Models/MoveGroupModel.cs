/*========================================================================================
File: MB3D_Animation_Copilot.Models.MoveGroupTrackerModel
Description: This class provides the data structure for movement (actions) of a keyframe
             during the capturing of movements (actions).
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
    internal class MoveGroupTrackerModel
    {
        public string ActionMoveName { get; set; }
        public int SendKeyCount { get; set; }
        public int StepAngleCount { get; set; }
    }
}
