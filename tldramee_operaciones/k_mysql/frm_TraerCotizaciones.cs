using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k_mysql
{
    //DED 2022/09/20 
    public partial class form_TraerCotizaciones : Form
    {
        guardar_datos_login datos = guardar_datos_login.Instance();
        public form_TraerCotizaciones()
        {
            InitializeComponent();
        }
        private void Iniciar()
        {
            CargaCombos();
        }

        private void CargaCombos()
        {

            //this.cboItem.Text = datos.g_Item;
            //this.cboEstado.Text = datos.g_IdEstado;

            //Cargamos los combos
            DBTablas_Gral lista = new DBTablas_Gral();

            DataTable p;
            funciones_Varias o = new funciones_Varias();

            p = lista.Get_Datos("SP_DatosCombo_Coti");
            o.CargarComboDataTable(cboItem, p, "Id", "Item", false, true, false, false);


            //var parameters = new[]
            //{
            //    new MySqlParameter(){ ParameterName="intEmpresa", Value = datos.g_idEmpresa}
            //};

            p = lista.Get_Datos("SP_DatosCombo_Coti");
            o.CargarComboDataTable(cboEstado, p, "IdEstado", "IdEstado", false, true, false, false);

            //
        }
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

        private void form_TraerCotizaciones_Load(object sender, EventArgs e)
        {
            Iniciar();

        }

        private void txtDetalle_TextChanged(object sender, EventArgs e)
        {
            this.txtDetalle.Focus();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //this.txtDetalle.Text = 
        }

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarEstado();
        }
        private void cargarEstado()
        {
            DBTablas_Gral lista = new DBTablas_Gral();
            funciones_Varias o = new funciones_Varias();
            DataTable r;

            //int intCliente;
            //intCliente = Convert.ToInt32(cboRazonSocial.SelectedValue);
            //int intCorredor;
            //intCorredor = Convert.ToInt32(this.cboRutas.SelectedValue);

            //cargo los presupuestos.

            //this.SelectedIndexChanged -= new System.EventHandler(cboPresupuesto_SelectedIndexChanged);

            //r = lista.DN_CargarDataTableGral("SP_PRESUPUESTO_POR_CLIENTE",ID , datos.g_idEmpresa );
            //o.CargarComboDataTable(this.cboPresupuesto, r, "id", "descripcion", false);

        //var parameters = new[]
        //{
        //    new MySqlParameter(){ ParameterName="intEmpresa", Value = datos.g_idEmpresa},
        //    new MySqlParameter(){ ParameterName="intCliente", Value = intCliente },
        //    new MySqlParameter(){ ParameterName="intCorredor", Value = intCorredor }
        //new MySqlParameter(){ ParameterName="intTransportista", Value = intTransportista },
        //new MySqlParameter(){ ParameterName="intTractor", Value = intTractor },
        //new MySqlParameter(){ ParameterName="intChasis", Value = intChasis },
        //new MySqlParameter(){ ParameterName="intChofer", Value = intChofer },
        //new MySqlParameter(){ ParameterName="intItem", Value = _Item }
        //};



            r = lista.Get_Datos("SP_DatosCombo_Coti");
            o.CargarComboDataTable(cboEstado, r, "IdEstado", "IdEstado", false, true, false, false);

            //this.cboPresupuesto.SelectedIndexChanged += new System.EventHandler(cboPresupuesto_SelectedIndexChanged);

        }
    }
}
