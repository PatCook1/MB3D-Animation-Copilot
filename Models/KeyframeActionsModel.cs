using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB3D_Animation_Copilot.Models
{
    internal class KeyframeActionsModel
    {
        public int ID { get; set; }
        public string ActionName { get; set; }
        public string SendKeyChar { get; set; }
        public int SendKeyQuantity { get; set; }
        public int StepAngleCount { get; set; }
    }
}
