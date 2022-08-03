using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using k_negocio_00;
using MySql.Data;
using MySql.Data.Types;
using MySql.Data.MySqlClient;

namespace k_presentacion_00
{
    public partial class frm_abm_seguros : Form
    {
        public frm_abm_seguros()
        {
            InitializeComponent();
        }

        private void frm_abm_seguros_Load(object sender, EventArgs e)
        {
            DNTablas_Gral lista = new DNTablas_Gral();

            DataTable p;
            funciones_Varias o = new funciones_Varias();

            p = lista.DN_CargarDataTableGral("SP_Seguros_Traer");
            o.CargarComboDataTable(cboSeguros, p, "id", "descripcion", false, true);
        }

        private void cmdGrabar_Click(object sender, EventArgs e)
        {

            DN_Eventos o = new DN_Eventos();
            int ok_trans;
            
            if (this.cboSeguros.SelectedIndex==-1)
            {
                o.PId = 0;
            }
            else
            {
                o.PId = (Int32)this.cboSeguros.SelectedValue;
            }
            o.PDescripcion = this.cboSeguros.Text.ToUpper();
            ok_trans = o.SegurosAlta();
            if (ok_trans == 1)
            {
                frm_abm_seguros ofrm = new frm_abm_seguros();
                ofrm.Show();
                this.Close();
            }
        }
    }
}
