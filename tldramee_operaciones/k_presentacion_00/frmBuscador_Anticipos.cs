using System;
using System.Data;
using System.Windows.Forms;
using k_negocio_00;
using MySql.Data.MySqlClient;
using System.Globalization;


namespace k_presentacion_00
{
    public partial class frmBuscador_Anticipos : Form
    {
        int idEmpresa;
        guardar_datos_login datos = guardar_datos_login.Instance();

        public int IdEmpresa { get => idEmpresa; set => idEmpresa = value; }

        public frmBuscador_Anticipos()
        {
            InitializeComponent();
            iniciar();
        }
        private void iniciar()
        {
            //cargo fechas en combo
            //DateTime fDesde = new DateTime(2000, 1, 1);
            //DateTime fHasta = new DateTime(2050, 12, 31);
            //this.mFechaDesde.Text = fDesde.ToString();
            //this.mFechaHasta.Text = fHasta.ToString();
        }
        private void cargar_clientes_transportistas()
        {
            funciones_Varias o = new funciones_Varias();
            DataTable r;
            DN_ABM u = new DN_ABM();

          

            r = u.DN_Traer_DataTable("SP_Transportistas_Get_All", 0, datos.g_idEmpresa);

            o.CargarComboDataTable(this.cboTransportista, r, "id", "descripcion", false, false,false, true);

        }
        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            DataTable dtOT;
            DNTablas_Gral lista = new DNTablas_Gral();
            MySqlParameter[] Parametros = new MySqlParameter[3];

            //Empresa
            Parametros[0] = new MySqlParameter("intEmpresa", datos.g_idEmpresa);
            //OT
            if (this.txtNroOT.Text != string.Empty)
            {
                Parametros[1] = new MySqlParameter("intOT", int.Parse(this.txtNroOT.Text));
            }
            else
            {
                Parametros[1] = new MySqlParameter("intOT", DBNull.Value);
            }
            //Transporte
            if (this.cboTransportista.SelectedIndex != -1)
            {
                Parametros[2] = new MySqlParameter("intTransportista", Convert.ToInt32(this.cboTransportista.SelectedValue));
            }
            else
            {
                Parametros[2] = new MySqlParameter("intTransportista", DBNull.Value);
            }
            //Fechas
            //DateTime fDesde;
            //DateTime fHasta;
            //fDesde = DateTime.Parse(this.mFechaDesde.Text);
            //fHasta = DateTime.Parse(this.mFechaHasta.Text);
            //Parametros[4] = new MySqlParameter("datFechaDesde", fDesde.ToString("yyyy-MM-dd"));
            //Parametros[5] = new MySqlParameter("datFechaHasta", fHasta.ToString("yyyy-MM-dd"));
            //Nro de contenedor
            //if (this.txtContenedor.Text != string.Empty)
            //{
            //    Parametros[6] = new MySqlParameter("strNroCont", this.txtContenedor.Text);
            //}
            //else
            //{
            //    Parametros[6] = new MySqlParameter("strNroCont", DBNull.Value);
            //}
            //Nro Booking
            //if (this.txtBL.Text != string.Empty)
            //{
            //    Parametros[7] = new MySqlParameter("strBooking", (this.txtBL.Text));
            //}
            //else
            //{
            //    Parametros[7] = new MySqlParameter("strBooking", DBNull.Value);
            //}

            dtOT = lista.Get_Datos("SP_Buscador_Anticipos", Parametros); //, parameters);

            dgv.DataSource = dtOT;
            dgv.Columns[0].Width = 40;
            dgv.Columns[1].Width = 40;
            dgv.Columns[2].Width = 40*3; 
            dgv.Columns[3].Width = 40*3; 
            dgv.Columns[4].Width = 40*6;
            dgv.Columns[5].Width = 50;
            dgv.Columns[6].Width = 40*2;
            dgv.Columns[7].Width = 40*2;
            dgv.Columns[8].Width = 40 * 2;
            dgv.Columns[9].Width = 40*2;
            dgv.Columns[10].Width = 40*2;
            dgv.Columns[11].Width = 40*2;
            dgv.Columns[12].Width = 70;
            dgv.Columns[13].Width = 70;
            dgv.Columns[14].Width = 70;
            dgv.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv.Columns[15].Width = 40;

            if (MessageBox.Show("¿Desea Exportar a Excel?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataTable dt = (DataTable)this.dgv.DataSource;
                funciones_Varias.ExportToExcel(dt,"Exportacion_Anticipos");
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
