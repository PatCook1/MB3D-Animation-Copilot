/*========================================================================================
File: MB3D_Animation_Copilot.Models.StepSequenceModel
Description: This class provides the data structure the details of keyframe steps.
Original Author: Patrick C. Cook
Copyright: Patrick C. Cook 2025
License: GNU GENERAL PUBLIC LICENSE Version 3
========================================================================================*/

using MB3D_Animation_Copilot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB3D_Animation_Copilot.Models
{
    internal class StepSequenceModel
    {
        public int Step_ID { get; set; }
        public int Step_Group {get; set; }
        public string Step_Name { get; set; }
        public int Step_AngleCount { get; set; }
        public int Step_SendKeyQty { get; set; }
        public string Step_SendKey { get; set; }
        public string Step_Display
        {
            get
            {
                //Assemble the Step Display
                return string.Concat(Step_Name, Step_SendKeyQty.ToString(), " (", Step_AngleCount.ToString(), ")");
            }
        }
        public string Step_Display_Calc
        {
            get
            {
                //Assemble the Step Display
                return string.Concat(Step_Name, Step_SendKeyQty.ToString(), " (", (Step_SendKeyQty * Step_AngleCount).ToString(), ")");
            }
        }
    }

}
