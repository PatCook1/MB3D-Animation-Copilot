/*========================================================================================
File: MB3D_Animation_Copilot.Child_Forms.frm_ShowMoveSequences
Description: A child form of parent MainForm to display moves (actions) that were selected
             at the Mainform to become a move sequence.
Original Author: Patrick C. Cook
Copyright: Patrick C. Cook 2025
License: GNU GENERAL PUBLIC LICENSE Version 3
========================================================================================*/

using MB3D_Animation_Copilot.Classes;
using MB3D_Animation_Copilot.Models;
using Syncfusion.Styles;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MB3D_Animation_Copilot.Child_Forms
{
    public partial class frm_ShowMoveSequenceInfo : Form
    {

        public frm_ShowMoveSequenceInfo(int argMoveSeqID, string argSequenceName, string argSequenceDesc) //Passing in the selected Move Sequence ID
        {
            InitializeComponent();
            PopulateLabels(argSequenceName, argSequenceDesc);
            BuildMoveStepsDatagrid();
            BindMoveSequenceDatagrid(argMoveSeqID);
        }

        private void PopulateLabels(string argSequenceName, string argSequenceDesc)
        {
            lbl_MoveSequenceName.Text = argSequenceName;
            lbl_MoveSequenceDesc.Text = argSequenceDesc;
        }

        private void BuildMoveStepsDatagrid()
        {
            //Datagrid configuation
            dgv_MoveSequenceSteps.AutoGenerateColumns = false;
            dgv_MoveSequenceSteps.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            dgv_MoveSequenceSteps.RowHeight = 21;

            //Column definitions
            dgv_MoveSequenceSteps.Columns.Add(new GridNumericColumn() { MappingName = "Step_ID", HeaderText = "Step ID", Width = 50, AllowEditing = false, Visible=false, Format = "0.#####" });
            dgv_MoveSequenceSteps.Columns.Add(new GridNumericColumn() { MappingName = "Step_Group", HeaderText = "Step Group", MinimumWidth = 8, Width = 95, AllowEditing = false, Visible = false, Format = "0.#####" });
            dgv_MoveSequenceSteps.Columns.Add(new GridNumericColumn() { MappingName = "Step_Name", HeaderText = "Step Name", MinimumWidth = 8, Width = 95, AllowEditing = false });
            dgv_MoveSequenceSteps.Columns.Add(new GridTextColumn() { MappingName = "Step_SendKeyQty", HeaderText = "Send Qty", MinimumWidth = 8, Width = 95, AllowEditing = false, Visible = true, Format = "0.#####" });
            dgv_MoveSequenceSteps.Columns.Add(new GridTextColumn() { MappingName = "Step_SendKey", HeaderText = "Send Key", MinimumWidth = 8, Width = 95, AllowEditing = false, Visible=false });
            dgv_MoveSequenceSteps.Columns.Add(new GridTextColumn() { MappingName = "Step_AngleCount", HeaderText = "Angle/Count", MinimumWidth = 8, Width = 95, AllowEditing = false, Format = "0.#####" });
            dgv_MoveSequenceSteps.Columns.Add(new GridTextColumn() { MappingName = "Step_Display", HeaderText = "Step Display", MinimumWidth = 8, Width = 95, AllowEditing = false });

            dgv_MoveSequenceSteps.AllowEditing = false;
        }

        private void BindMoveSequenceDatagrid(int MoveSeqID)
        {

            //Fetch the data for the move sequence steps
            List<StepSequenceModel> lstSeqSteps = new List<StepSequenceModel>();
            lstSeqSteps = Data_Access_Methods.LoadSequenceStepList(MoveSeqID);
            if (lstSeqSteps.Count > 0) //If we have records
            {
                dgv_MoveSequenceSteps.DataSource = lstSeqSteps; //We rebind the datagrid
                dgv_MoveSequenceSteps.SelectedIndex = 0; //Set to first (top most) row
            }
            else //No records
            {
                dgv_MoveSequenceSteps.DataSource = lstSeqSteps; //We still rebind the datagrid anyway
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
