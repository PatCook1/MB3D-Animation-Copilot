using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB3D_Animation_Copilot.Classes
{
    internal class DataGridHelper
    {
        public static object GetCellValue(SfDataGrid sfDataGrid, int recordIndex, int columnindex, string argMappingName)
        {
            if (recordIndex >= 0)
            {
                try
                {
                    object cellValue = null;

                    var record1 = sfDataGrid.View.Records.GetItemAt(recordIndex);

                    if (argMappingName != string.Empty)
                    {
                        cellValue = record1.GetType().GetProperty(argMappingName).GetValue(record1, null);
                    }
                    else
                    {
                        var mappingName = sfDataGrid.Columns[columnindex].MappingName;
                        cellValue = record1.GetType().GetProperty(mappingName).GetValue(record1, null);
                    }

                    if (cellValue != null)
                    {
                        return cellValue;
                    }
                }
                catch
                {
                    //Do not throw - it's possible that there is no project data to load and thus no datagrid rows            
                }
            }

            return null;
        }
    }
}
