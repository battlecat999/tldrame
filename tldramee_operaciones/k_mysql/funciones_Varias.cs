using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k_mysql
{
    //DED 2022/09/20 
    internal class funciones_Varias
    {
        public void CargarComboDataTable(ComboBox cbo, DataTable dt, String campoValue, String compoDisplay, bool Cadena, bool agrega_linea_vacia, bool tres_campos, bool boolAutoCompletado)
        {
            DataRow row = dt.NewRow();
            if (Cadena == true)
            {
                row[(0)] = String.Empty;
            }
            else
            {
                row[(0)] = 0;
            }
            row[1] = String.Empty;
            if (tres_campos == true)
            {
                row[2] = 0;
            }

            if (agrega_linea_vacia == true)
            {
                dt.Rows.Add(row);
            }

            cbo.DisplayMember = compoDisplay;
            cbo.ValueMember = campoValue;
            cbo.DataSource = dt;

            cbo.SelectedIndex = -1;
            if (boolAutoCompletado == true)
            {
                cbo.AutoCompleteCustomSource = funciones_Varias.LoadAutoComplete(dt, compoDisplay);
                cbo.AutoCompleteMode = AutoCompleteMode.Suggest;
                cbo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }
        public static AutoCompleteStringCollection LoadAutoComplete(DataTable dt_param, string campo)
        {
            DataTable dt = dt_param;

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringCol.Add(Convert.ToString(row[campo]));
            }

            return stringCol;
        }
    }
}
