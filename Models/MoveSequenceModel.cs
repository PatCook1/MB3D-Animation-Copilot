/*========================================================================================
File: MB3D_Animation_Copilot.Models.MoveSequenceModel
Description: This class provides the data structure for move sequences.
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
    internal class MoveSequenceModel
    {
        public int ID { get; set; }
        public string SequenceName { get; set; }
        public string SequenceDesc { get; set; }
    }
}
