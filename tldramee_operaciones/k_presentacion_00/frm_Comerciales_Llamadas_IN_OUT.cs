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
    public partial class frm_Comerciales_Llamadas_IN_OUT : Form
    {

        guardar_datos_login datos = guardar_datos_login.Instance();
        public frm_Comerciales_Llamadas_IN_OUT(int tipoForm)
        {
            InitializeComponent();

            
            this.lblUsuario.Text =  " El Usuario " + datos.g_lastName +" escribe...";

            iniciarForm(tipoForm);
        }

        private void iniciarForm(int tipoForm)
        {
            this.rVentas.Checked = true;

            if (tipoForm == 0)//0 es IN
            {
                this.lblFormulario.Text = "Carga de llamadas Entrantes";
            }
            else //1 es OUT
            {
                this.lblFormulario.Text = "Carga de llamadas Salientes";
            }
            this.txtFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }

        private void pClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

        private void txtDetalle_Enter(object sender, EventArgs e)
        {
            this.txtDetalle.Text = string.Empty;
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if(this.txtDetalle.Text==string.Empty || this.txtDetalle.Text== "Escriba Aquí....")
            {
                MessageBox.Show("No olvide informar un detalle de la charla", "Atención", MessageBoxButtons.OK);
                return;
            }
            DialogResult = DialogResult.Yes;
            this.Hide();


        }

        private void Selec_op_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rVentas.Checked == true)
            {
                this.txtTipoLlamado.Text = "S";
            }else if (rOperaciones.Checked == true)
            {
                this.txtTipoLlamado.Text = "O";
            }
            else
            {
                txtTipoLlamado.Text = "X";
            }
        }
    }
}
