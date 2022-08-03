using System;
using System.Data;
using System.Windows.Forms;
using k_negocio_00;
using MySql.Data.MySqlClient;
using System.Globalization;


namespace k_presentacion_00
{
    public partial class frmCM2 : Form
    {
        int idEmpresa;
        guardar_datos_login datos = guardar_datos_login.Instance();

        public int IdEmpresa { get => idEmpresa; set => idEmpresa = value; }

        public frmCM2()
        {
            InitializeComponent();
            iniciar();
        }
        private void iniciar()
        {
            //cargo fechas en combo

            DateTime fechatemp;
            DateTime fDesde;
            DateTime fHasta;

            fechatemp = DateTime.Today;
            fechatemp = fechatemp.AddMonths(-1);
            fDesde = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            //fHasta = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1);
            if ((fechatemp.Month + 1) == 13)
            {
                fHasta = new DateTime(fechatemp.Year + 1, 1, 1).AddDays(-1);
            }
            else
            {
                fHasta = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1);
            }


            this.mFechaDesde.Text = fDesde.ToString();
            this.mFechaHasta.Text = fHasta.ToString();

            

        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            DataTable dtOT;
            DNTablas_Gral lista = new DNTablas_Gral();
            MySqlParameter[] Parametros = new MySqlParameter[3];

            //Empresa
            Parametros[0] = new MySqlParameter("intEmpresa", datos.g_idEmpresa);

            DateTime fDesde;
            DateTime fHasta;
            fDesde = DateTime.Parse(this.mFechaDesde.Text);
            fHasta = DateTime.Parse(this.mFechaHasta.Text);
            Parametros[1] = new MySqlParameter("datFechaDesde", fDesde.ToString("yyyy-MM-dd"));
            Parametros[2] = new MySqlParameter("datFechaHasta", fHasta.ToString("yyyy-MM-dd"));
           

            dtOT = lista.Get_Datos("SP_CM2", Parametros); //, parameters);

            //if (MessageBox.Show("¿Desea Exportar a Excel?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
           // {
                funciones_Varias.ExportToExcel(dtOT, "CM2");
            //}
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmCM2_Load(object sender, EventArgs e)
        {

        }
    }
}
