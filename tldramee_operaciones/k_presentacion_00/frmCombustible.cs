using System;
using System.Data;
using System.Windows.Forms;
using k_negocio_00;
using MySql.Data.MySqlClient;
using System.Globalization;


namespace k_presentacion_00
{
    public partial class frmCombustible : Form
    {
        int idEmpresa;
        guardar_datos_login datos = guardar_datos_login.Instance();

        public int IdEmpresa { get => idEmpresa; set => idEmpresa = value; }

        public frmCombustible()
        {
            InitializeComponent();
            iniciar();
        }
        private void iniciar()
        {
            //cargo fechas en combo
            DateTime fDesde = new DateTime(2000, 1, 1);
            DateTime fHasta = new DateTime(2050, 12, 31);
        //    this.mFechaDesde.Text = fDesde.ToString();
        //    this.mFechaHasta.Text = fHasta.ToString();
        //    cargar_clientes_transportistas();

        //}
        //private void cargar_clientes_transportistas()
        //{
        //    funciones_Varias o = new funciones_Varias();
        //    DataTable r;
        //    DN_ABM u = new DN_ABM();

        //    r = u.DN_Traer_DataTable("SP_Clientes_Get_All", 0, datos.g_idEmpresa);

        //    o.CargarComboDataTable(this.cboClientes, r, "id", "descripcion", false,false,false, true);

        //    r = u.DN_Traer_DataTable("SP_Transportistas_Get_All", 0, datos.g_idEmpresa);

        //    o.CargarComboDataTable(this.cboTransportista, r, "id", "descripcion", false, false,false, true);

        }
        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            DataTable dtOT;
            DNTablas_Gral lista = new DNTablas_Gral();
            MySqlParameter[] Parametros = new MySqlParameter[1];

            //Empresa
            Parametros[0] = new MySqlParameter("intEmpresa", datos.g_idEmpresa);
            //OT
            //if (this.txtNroOT.Text != string.Empty)
            //{
            //    Parametros[1] = new MySqlParameter("intOT", int.Parse(this.txtNroOT.Text));
            //}
            //else
            //{
            //    Parametros[1] = new MySqlParameter("intOT", 0);
            //}
            ////Clientes
            //if (this.cboClientes.SelectedIndex !=-1)
            //{
            //    Parametros[2] = new MySqlParameter("intCliente", Convert.ToInt32(this.cboClientes.SelectedValue));
            //}
            //else
            //{
            //    Parametros[2] = new MySqlParameter("intCliente", 0);
            //}
            ////Transporte
            //if (this.cboTransportista.SelectedIndex != -1)
            //{
            //    Parametros[3] = new MySqlParameter("intTransportista", Convert.ToInt32(this.cboTransportista.SelectedValue));
            //}
            //else
            //{
            //    Parametros[3] = new MySqlParameter("intTransportista", 0);
            //}
            ////Fechas
            //DateTime fDesde;
            //DateTime fHasta;
            //fDesde = DateTime.Parse(this.mFechaDesde.Text);
            //fHasta = DateTime.Parse(this.mFechaHasta.Text);
            //    Parametros[4] = new MySqlParameter("datFechaDesde", fDesde.ToString("yyyy-MM-dd"));
            //    Parametros[5] = new MySqlParameter("datFechaHasta", fHasta.ToString("yyyy-MM-dd"));
            ////Nro de contenedor
            //if (this.txtContenedor.Text != string.Empty)
            //{
            //    Parametros[6] = new MySqlParameter("strNroCont",this.txtContenedor.Text);
            //}
            //else
            //{
            //    Parametros[6] = new MySqlParameter("strNroCont", DBNull.Value);
            //}
            ////Nro Booking
            //if (this.txtBL.Text != string.Empty)
            //{
            //    Parametros[7] = new MySqlParameter("strBooking", (this.txtBL.Text));
            //}
            //else
            //{
            //    Parametros[7] = new MySqlParameter("strBooking", DBNull.Value);
            //}

            dtOT = lista.Get_Datos("SP_Combustible_Informe", Parametros); //, parameters);

            dgv.DataSource = dtOT;
            dgv.Columns[0].Width = 85;
            dgv.Columns[1].Width = 65;
            dgv.Columns[1].DefaultCellStyle.Format = "c";
            dgv.Columns[2].Width = 100;
            dgv.Columns[2].DefaultCellStyle.Format = "n2";
            dgv.Columns[3].Width = 100;
            dgv.Columns[3].DefaultCellStyle.Format = "c";
            dgv.Columns[4].Width = 100;
            dgv.Columns[4].DefaultCellStyle.Format = "n2";
            dgv.Columns[5].Width = 100;
            dgv.Columns[5].DefaultCellStyle.Format = "n2";

            for (int i = 0; i <= 5; i++)
            {
                dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (MessageBox.Show("¿Desea Exportar a Excel?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataTable dt = (DataTable)this.dgv.DataSource;
                funciones_Varias.ExportToExcel(dt,"ExportacionOT");
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
