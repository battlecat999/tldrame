using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k_presentacion_00
{
    public partial class frmAyuda : Form
    {
        public System.Data.DataTable _datDatos_Ayuda { get; set; }

        public string _strCodigo_Retorno { get; set; }
        public frmAyuda()
        {
            InitializeComponent();
        }

        private void Inicia()
        {
            grdAyuda.DataSource = _datDatos_Ayuda;
        }

        private void FrmAyuda_Load(object sender, EventArgs e)
        {
            Inicia();
        }

        private void Seleccionar(int intLinea)
        {

            //TENIENDO EN CUENTA QUE LA PRIMER COLUMNA ES EL CÓDIGO
            string strValor = this.grdAyuda.Rows[intLinea].Cells[0].FormattedValue.ToString();

            this._strCodigo_Retorno = strValor;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void GrdAyuda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar(e.RowIndex);
        }
    }
}
