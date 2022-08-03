using k_negocio_00;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
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
    public partial class rpt_Cotizaciones_Reporte : Form
    {
        int intCliente;
        int intRuta;
        DateTime datFechaDesde;
        DateTime datFechaHasta;

        public int IntCliente { get => intCliente; set => intCliente = value; }
        public int IntRuta { get => intRuta; set => intRuta = value; }
        public DateTime DatFechaDesde { get => datFechaDesde; set => datFechaDesde = value; }
        public DateTime DatFechaHasta { get => datFechaHasta; set => datFechaHasta = value; }

        public rpt_Cotizaciones_Reporte()
        {
            InitializeComponent();
        }

        private void rpt_Cotizaciones_Reporte_Load(object sender, EventArgs e)
        {
            CargarReporte();
            this.rpt_Cotizaciones_Viewer.RefreshReport();
            this.rpt_Cotizaciones_Viewer.RefreshReport();
        }
        private void CargarReporte()
        {
            guardar_datos_login datos = guardar_datos_login.Instance();
            DataTable dtCotizaciones;
            DNTablas_Gral lista = new DNTablas_Gral();
            MySqlParameter[] Parametros = new MySqlParameter[5];

            //Empresa
            Parametros[0] = new MySqlParameter("intEmpresa", datos.g_idEmpresa);
            if (IntCliente==0)
            {
                Parametros[1] = new MySqlParameter("intCliente", null);
            }
            else
            {
                Parametros[1] = new MySqlParameter("intCliente", IntCliente);
            }
            if (IntRuta == 0)
            {
                Parametros[2] = new MySqlParameter("intRuta", null);
            }
            else
            {
                Parametros[2] = new MySqlParameter("intRuta", IntRuta);
            }

            //Fechas
            DateTime fDesde;
            DateTime fHasta;
            fDesde = datFechaDesde;
            fHasta = datFechaHasta;

            Parametros[3] = new MySqlParameter("datFechaDesde", MySqlDbType.DateTime);
            Parametros[4] = new MySqlParameter("datFechaHasta", MySqlDbType.DateTime);

            Parametros[3].Value = fDesde.ToString("yyyy-MM-dd");
            Parametros[4].Value = fHasta.ToString("yyyy-MM-dd");

            dtCotizaciones = lista.Get_Datos("SP_Cotizaciones_Reporte", Parametros); //, parameters);


            List<rpt_Cotizaciones_Clase> Listar = new List<rpt_Cotizaciones_Clase>();
            foreach (DataRow dr in dtCotizaciones.Rows)
            {
                Listar.Add(new rpt_Cotizaciones_Clase
                {
                    Cotizacion = dr["Cotizacion"].ToString(),
                    diasValidez = dr["diasValidez"].ToString(),
                    FechaVencimiento = dr["FechaVencimiento"].ToString(),
                    Razon_Social = dr["Razon_Social"].ToString(),
                    TipoServicio = dr["TipoServicio"].ToString(),
                    TipoModalidad = dr["TipoModalidad"].ToString(),
                    Vendedor = dr["Vendedor"].ToString(),
                    Ruta = dr["Ruta"].ToString(),
                    Mercaderia = dr["Mercaderia"].ToString(),
                    Contenedor = dr["Contenedor"].ToString(),
                    dias_operacion = dr["dias_operacion"].ToString(),
                    Estadia = dr["Estadia"].ToString(),
                    Tarifa = dr["Tarifa"].ToString()
                });
            }


            ///Mostrar datos en el reporte
            this.rpt_Cotizaciones_Viewer.ProcessingMode = ProcessingMode.Local;
            //rpt_Cotizaciones_Viewer.LocalReport.ReportEmbeddedResource = "k_presentaciones_00.rpt_Cotizaciones.rdlc";
            ReportDataSource rds1 = new ReportDataSource("DS_Cotizaciones", Listar);
            this.rpt_Cotizaciones_Viewer.LocalReport.DataSources.Clear();
            this.rpt_Cotizaciones_Viewer.LocalReport.DataSources.Add(rds1);
            
            this.rpt_Cotizaciones_Viewer.RefreshReport();
        }
    }
}
