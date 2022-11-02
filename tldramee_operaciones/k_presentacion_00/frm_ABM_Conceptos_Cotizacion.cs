using k_negocio_00;
using k_mysql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

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

            if (validarControles() == false)
            {
                this.cboItem.Focus();
           
            }

            ConceptoCotizacion(0);
            btnNuevo_Click(sender, e);
            return;
        }

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            DNTablas_Gral lista = new DNTablas_Gral();
            DataTable p;
            
            var parameters = new[]
{
                new MySqlParameter(){ ParameterName="intEmpresa", Value = datos.g_idEmpresa},
                new MySqlParameter(){ ParameterName="intId", Value = this.cboItem.SelectedValue},
                new MySqlParameter(){ ParameterName="intAccion", Value = 1}
            };


            p = lista.Get_Datos("SP_Conceptos_Cotizaciones", parameters);

            try
            {
                if (p.Rows.Count > 0)
                {
                    DataRow dr;
                    dr = p.Rows[0];
                    this.txtDetalle.Text = dr["Detalle"].ToString();
                    this.cboEstado.SelectedValue= dr["IdEstado"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDetalle_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void ConceptoCotizacion(int intAccion)
        {

            DNTablas_Gral lista = new DNTablas_Gral();
            DataTable p;

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = datos.g_idEmpresa},                
                new MySqlParameter(){ ParameterName="intId", Value = this.cboItem.SelectedValue},
                new MySqlParameter(){ ParameterName="strItem", Value = this.cboItem.Text.ToUpper()},
                new MySqlParameter(){ ParameterName="strDetalle", Value = this.txtDetalle.Text},
                new MySqlParameter(){ ParameterName="idEstado", Value = this.cboEstado.SelectedValue},
                new MySqlParameter(){ ParameterName="intAccion", Value = intAccion }

            };


            p = lista.Get_Datos("SP_ConceptosCotizaciones_Trans", parameters);


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ConceptoCotizacion(1);
            btnNuevo_Click(sender, e);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frm_ABM_Conceptos_Cotizacion frm = new frm_ABM_Conceptos_Cotizacion();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.Show();
            this.Close();
        }

        //DED 2022/09/23 VALIDAMOS LOS CONTROLES
        private bool validarControles()
        {
            if (this.cboItem.Text == "")
            {
                MessageBox.Show("El Item Concepto no puede estar vacío", "Atención");
                this.cboItem.Focus();
                //return false;
            }
            if (this.txtDetalle.Text == "")
            {
                MessageBox.Show("El Detalle Del Concepto no puede estar vacío", "Atención");
                this.txtDetalle.Focus();
                //return false;
            }
            if (this.cboEstado.SelectedIndex == -1)
            {
                MessageBox.Show("El Estado Del Concepto no puede estar vacío", "Atención");
                this.cboEstado.Focus();
                //return false;
            }

            return  false;
            
        }

    }
}
