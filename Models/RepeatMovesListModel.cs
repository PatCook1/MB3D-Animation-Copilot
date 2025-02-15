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