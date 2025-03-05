/*========================================================================================
File: MB3D_Animation_Copilot.Models.SampleProjectKeyframesModel.cs
Description: This class provides the data structure for a inserting sample keyframe and actions.
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
    internal class SampleProjectKeyframesModel
    {
        public int SampleKeyframeID { get; set; }
        public string KeyframeType { get; set; }
        public int KeyframeNum { get; set; }
        public string KeyframeDisplay { get; set; }
        public int FramesBetween { get; set; }
        public int FrameCount { get; set; }
        public int FarPlane { get; set; }
        public Boolean KeyframeApproved { get; set; }
        public string KeyframeNote { get; set; }
    }
}
