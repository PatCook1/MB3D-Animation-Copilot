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
        public int Step_Count { get; set; }
        public int Step_SendKeyQty { get; set; }
        public string Step_SendKey { get; set; }
        public string Step_Display
        {
            get
            {
                return string.Concat(Step_Name, Step_SendKeyQty.ToString(), " (", Step_Count.ToString(), ")");
            }
        }
    }
}
