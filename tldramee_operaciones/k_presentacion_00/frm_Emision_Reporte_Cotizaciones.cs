//using DocumentFormat.OpenXml.Vml.Spreadsheet;
using k_negocio_00;
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
    public partial class frm_Emision_Reporte_Cotizaciones : Form
    {
        guardar_datos_login datos = guardar_datos_login.Instance();
        public frm_Emision_Reporte_Cotizaciones()
        {
            InitializeComponent();

            this.cboRazonSocial.SelectedIndexChanged -= new System.EventHandler(cboRazonSocial_SelectedIndexChanged);
            Iniciar();
            this.cboRazonSocial.SelectedIndexChanged += new System.EventHandler(cboRazonSocial_SelectedIndexChanged);
        }
        private void Iniciar()
        {
            cargarClientes();
            cargarRutas();

            this.datFechaDesde.Text= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString();
            this.datFechaHasta.Text= new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1).ToString();
        }
        private void cargarClientes()
        {
            funciones_Varias o = new funciones_Varias();
            DataTable r;
            DNTablas_Gral lista = new DNTablas_Gral();

            r = lista.DN_CargarDataTableGral("SP_Clientes_Get_All", 0, datos.g_idEmpresa);//u.DN_Clientes_Get(IsThe);
            o.CargarComboDataTable(this.cboRazonSocial, r, "id", "descripcion", false, true);



        }
        private void cargarRutas()
        {
            funciones_Varias o = new funciones_Varias();
            DataTable r;
            DNTablas_Gral lista = new DNTablas_Gral();

            r = lista.DN_CargarDataTableGral("SP_Corredores_Combo", 0, datos.g_idEmpresa);
            o.CargarComboDataTable(this.cboRutas, r, "id", "descripcion", false, true);
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            rpt_Cotizaciones_Reporte oRpt = new rpt_Cotizaciones_Reporte();

            oRpt.IntCliente = Convert.ToInt32(this.cboRazonSocial.SelectedValue);
            oRpt.IntRuta = Convert.ToInt32(this.cboRutas.SelectedValue);
            oRpt.DatFechaDesde = Convert.ToDateTime(this.datFechaDesde.Text);
            oRpt.DatFechaHasta = Convert.ToDateTime(this.datFechaHasta.Text);

            oRpt.Show();
        }
        private void cboRazonSocial_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.cboRazonSocial.Text==string.Empty )
            {
                cargarRutas();
            }
            else
            {
                cargarcombos_rutas();
            }
            
        }
        private void cargarcombos_rutas()
        {
            funciones_Varias o = new funciones_Varias();
            DN_ABM dn = new DN_ABM();
            DataTable r;
            DNTablas_Gral u = new DNTablas_Gral();
            this.cboRutas.SelectedIndexChanged -= new System.EventHandler(cboRutas_SelectedIndexChanged);

            int idCliente;
            idCliente = Convert.ToInt32(this.cboRazonSocial.SelectedValue);

            r = u.DN_CargarDataTableGral("SP_ACC_Select", idCliente, datos.g_idEmpresa);

            if (r.Rows.Count > 0)
            {
                o.CargarComboDataTable(this.cboRutas, r, "id", "descripcion", false, false, false, true);
            }
            else
            {
                MessageBox.Show("No hay rutas asociadas a este cliente", "Atención", MessageBoxButtons.OK);
            }


            this.cboRutas.SelectedIndexChanged += new System.EventHandler(cboRutas_SelectedIndexChanged);
        }

        private void cboRutas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
