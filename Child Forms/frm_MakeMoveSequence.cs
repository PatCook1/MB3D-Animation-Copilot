using MB3D_Animation_Copilot.Classes;
using MB3D_Animation_Copilot.Models;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using System.Windows;

namespace MB3D_Animation_Copilot.Child_Forms
{
    public partial class frm_MakeMoveSequence : Form
    {
        public int ProjectID;
        public int FromKeyframeNumber;
        public int ToKeyframeNumber;

        public delegate void MakeMoveSeqFormCloseEvent();
        public MakeMoveSeqFormCloseEvent MakeMoveSeqWindowClosed;

        public frm_MakeMoveSequence(int argProjectID, int argFromKeyframeNumber, int argToKeyframeNumber)
        {
            InitializeComponent();

            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            MessageBoxAdv.ThemeName = "HighContrastTheme";

            ProjectID = argProjectID;
            FromKeyframeNumber = argFromKeyframeNumber;
            ToKeyframeNumber = argToKeyframeNumber;

            BuildMoveSequenceDatagrid();
            LoadKeyframesByFromToRange();
        }

        private void BuildMoveSequenceDatagrid()
        {
            //Datagrid configuation
            dgv_KeyframeRangeList.AutoGenerateColumns = false;
            dgv_KeyframeRangeList.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            dgv_KeyframeRangeList.RowHeight = 21;

            //Column definitions
            dgv_KeyframeRangeList.Columns.Add(new GridNumericColumn() { MappingName = "ID", HeaderText = "ID", Width = 20, AllowEditing = false, Visible = false });
            dgv_KeyframeRangeList.Columns.Add(new GridNumericColumn() { MappingName = "KeyframeNum", HeaderText = "KF#", MinimumWidth = 8, Width = 38, AllowEditing = false, Format = "0.#####" });
            dgv_KeyframeRangeList.Columns.Add(new GridTextColumn() { MappingName = "KeyframeDisplay", HeaderText = "Keyframe Summary", Width = 425, AllowEditing = false });

            //Column appearance
            dgv_KeyframeRangeList.Columns["KeyframeDisplay"].CellStyle.Font.Size = 10; //Make the font of the keyframe summary column larger
            dgv_KeyframeRangeList.Columns["KeyframeDisplay"].CellStyle.Font.Bold = false; //Make the keyframe summary column cells be bold
            dgv_KeyframeRangeList.Columns["KeyframeDisplay"].AllowResizing = true; //Allow the keyframe summary column to be resized

            dgv_KeyframeRangeList.AllowEditing = false;
        }

        private void LoadKeyframesByFromToRange()
        {
            List<KeyframeModel> lstKeyframes = new List<KeyframeModel>();
            lstKeyframes = Data_Access_Methods.LoadKeyframeRangeForMoveSequence(ProjectID, FromKeyframeNumber, ToKeyframeNumber);
            if (lstKeyframes.Count > 0) //If we have records
            {
                dgv_KeyframeRangeList.DataSource = lstKeyframes; //Bind the datagrid now

                dgv_KeyframeRangeList.ClearSelection();
                dgv_KeyframeRangeList.SelectedIndex = -1;
            }
            else //No records
            {
                dgv_KeyframeRangeList.DataSource = lstKeyframes; //We still rebind the datagrid
            }
        }

        private void btn_SaveMoveSequence_Click(object sender, EventArgs e)
        {
            if (tbx_MoveSequenceName.TextLength == 0)
            {
                MessageBoxAdv.Show(this, "Please enter a Move Sequence name.", "Name Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //>>>>>>>>>>>>> Check if move seq name already exists

            var dialogResult = MessageBoxAdv.Show(this, string.Concat("This will create a new Move Sequence named '", tbx_MoveSequenceName.Text, "'."), "Proceed?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //==========================================
                //Save the new Move Sequence to the database
                //==========================================

                try
                {
                    //Create a new Move Sequence parent record
                    int SeqParentID = Data_Access_Methods.AddNewSequenceParent(tbx_MoveSequenceName.Text, tbx_MoveSequenceDesc.Text);

                    if (SeqParentID > 0) //If we got a greater-than-zero parent ID back
                    {
                        //Insert the Move Sequence record for each of the specified keyframes
                        Data_Access_Methods.InsertMoveSeqStepsByKeyframeRange(ProjectID, SeqParentID, FromKeyframeNumber, ToKeyframeNumber);
                    }

                    MessageBoxAdv.Show(this, string.Concat("The new Move Sequence '", tbx_MoveSequenceName.Text, "' has been saved. You may close this window."), "Success?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    //var message = ex;
                    MessageBoxAdv.Show(this, string.Concat("There was a problem saving the new Move Sequence '", tbx_MoveSequenceName.Text, "' which was not saved. You may close this window."), "Failure?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                return;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_MakeMoveSequence_FormClosing(object sender, FormClosingEventArgs e)
        {
            MakeMoveSeqWindowClosed();
        }
    }
}
