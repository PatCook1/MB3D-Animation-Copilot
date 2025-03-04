/*========================================================================================
File: MB3D_Animation_Copilot.Models.RepeatMoveListModel
Description: This class provides the data structure for list of pre-designed move sequences.
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
    internal class RepeatMovesListModel
    {
        public string MoveName { get; set; }
        public int MoveStepCount { get; set; }
        public string SendKeyCode { get; set; }
        public int StepAngleCount { get; set; }
    }
}