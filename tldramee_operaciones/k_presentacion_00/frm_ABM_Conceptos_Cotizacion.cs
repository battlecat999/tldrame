using k_negocio_00;
using k_mysql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace k_presentacion_00
{
    //DED 2022/09/20 
    public partial class frm_ABM_Conceptos_Cotizacion : Form
    {
        guardar_datos_login datos = guardar_datos_login.Instance();
        public frm_ABM_Conceptos_Cotizacion()
        {
            InitializeComponent();
        }
        private void Iniciar()
        {
            this.cboItem.SelectedIndexChanged -= new System.EventHandler(cboItem_SelectedIndexChanged);
            this.cboEstado.SelectedIndexChanged -= new System.EventHandler(cboEstado_SelectedIndexChanged);

            CargaCombos();

            this.cboEstado.SelectedIndexChanged += new System.EventHandler(cboEstado_SelectedIndexChanged);
            this.cboItem.SelectedIndexChanged += new System.EventHandler(cboItem_SelectedIndexChanged);
        }

        private void CargaCombos()
        {
            
            //this.cboItem.Text = datos.g_Item;
            //this.cboEstado.Text = datos.g_IdEstado;

            //Cargamos los combos
            DNTablas_Gral lista = new DNTablas_Gral();

            DataTable p;
            funciones_Varias o = new funciones_Varias();

            var parameters = new[]
{
                new MySqlParameter(){ ParameterName="intEmpresa", Value = datos.g_idEmpresa},
                new MySqlParameter(){ ParameterName="intId", Value = 0},
                new MySqlParameter(){ ParameterName="intAccion", Value = 0}
            };


            p = lista.Get_Datos("SP_Conceptos_Cotizaciones", parameters);
            o.CargarComboDataTable(cboItem, p, "Id", "Item", false, true, false, false);


            p = lista.Get_Datos("SP_Get_Estados");
            o.CargarComboDataTable(cboEstado, p, "Id", "Descripcion", false, true, false, false);

            
        }
        

    private void form_TraerCotizaciones_Load(object sender, EventArgs e)
        {
            Iniciar();

        }

       

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
        }

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            

          

            
          
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDetalle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
