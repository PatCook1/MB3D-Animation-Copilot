using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB3D_Animation_Copilot.Models
{
    internal class ProjectModel
    {
        public int ID { get; set; }
        public string Project_Name { get; set; }
        public string Project_Notes { get; set; }
        public int SlideWalk_StepCount { get; set; }
        public int LookingRolling_Angle { get; set; }
        public int Frames_Between { get; set; }
        public int Key_Delay { get; set; }
        public int Total_Frames_Count { get; set; }
        public string Far_Plane { get; set; }
        public string Animation_Length_30 { get; set; }
        public string Animation_Length_60 { get; set; }
        public string M3PIFileLocation { get; set; }
        public string M3AFileLocation { get; set; }
    }
}
