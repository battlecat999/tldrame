using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using System.Collections;
using MySql.Data.MySqlClient;
using k_negocio_00;
using k_mysql;

namespace k_presentacion_00
{
   public partial class frmInicialFinal : Form
    {
        ArrayList gRutas = new ArrayList();
        ArrayList gRutas_Cant = new ArrayList();

        ArrayList gDias = new ArrayList();
        ArrayList gDias_Cant = new ArrayList();

        int VerChar;
        guardar_datos_login datos = guardar_datos_login.Instance();
        public frmInicialFinal()
        {
            InitializeComponent();
            
          

            this.Location = new Point(0, 0);
            this.Size = SystemInformation.PrimaryMonitorMaximizedWindowSize;
  
            this.st_Version.Text= "Versión del Sistema: " + Application.ProductVersion.ToString();
            this.st_Fecha_Version.Text = "Fecha de Versión: 11/08/2022";

            this.Text = datos.g_idUser + " " + datos.g_lastName;
            this.lblTitulo.Text = datos.g_nomEmpresa;
            VerChar = 0;
            chartViajesPorMes.Visible = false;
            chartViajesDiarios.Visible = false;
            this.dt.Visible = false;
            this.cmdAprobarCambios.Visible = false;
            if (datos.g_permiso<=2)
            {
                VerChar = 1;
                chartViajesPorMes.Visible = true;
                chartViajesDiarios.Visible = true;
                cargarGrafico();
            }
            if (datos.g_permiso == 3)
            {
                this.dt.Visible = true;
                this.cmdAprobarCambios.Visible = true;
                cargarGrilla_CambioNominacion();
            }
            

        }
        private void cargarGrilla_CambioNominacion()
        {
            DataTable dtOT;
            MySqlParameter[] Parametros = new MySqlParameter[1];
            DNTablas_Gral lista = new DNTablas_Gral();

            Parametros[0] = new MySqlParameter("intEmpresa", datos.g_idEmpresa);
            dtOT = lista.Get_Datos("SP_cambio_nominacion_grilla", Parametros);
            dt.AutoGenerateColumns = false;
            dt.DataSource = dtOT;


            this.dt.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue;
        }
        private void cargarGrafico()
        {
            DNTablas_Gral lista = new DNTablas_Gral();
            DataTable  dt;
            DateTime fechatemp;
            DateTime datFecha_Desde;
            DateTime datFecha_Hasta;

            //chartViajesDiarios.Series.Clear();
            //chartViajesPorMes.Series.Clear();

            //chartViajesDiarios.Series.Add("Diarios");
            //chartViajesPorMes.Series.Add("Meses");

            gRutas.Clear();
            gRutas_Cant.Clear();
            gDias.Clear();
            gDias_Cant.Clear();

            fechatemp = DateTime.Today;
            datFecha_Desde = new DateTime(fechatemp.Year, fechatemp.Month, 1).AddDays(0);
            if ((fechatemp.Month + 1) == 13)
            {
                datFecha_Hasta = new DateTime(fechatemp.Year + 1, 1, 1).AddDays(-1);
            }
            else
            {
                datFecha_Hasta = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1);
            }

            var parameters = new[]
                {
                    new MySqlParameter(){ ParameterName="intEmpresa", Value = datos.g_idEmpresa },
                    new MySqlParameter(){ ParameterName="datFecha_Desde", Value = datFecha_Desde },
                    new MySqlParameter(){ ParameterName="datFecha_Hasta", Value = datFecha_Hasta }
                };

            dt = lista.Get_Datos("SP_Grafico_Viajes_Mensuales", parameters);
            foreach (DataRow dr in dt.Rows)
            {

                gRutas.Add(dr[0].ToString());
                gRutas_Cant.Add(Convert.ToInt32(dr[1]));
            }
            
            chartViajesPorMes.Series[0].Points.DataBindXY(gRutas, gRutas_Cant);

            //viajes diarios

            dt = lista.Get_Datos("SP_Grafico_Viajes_Diarios", parameters);
            foreach (DataRow dr in dt.Rows)
            {

                gDias.Add(dr[0].ToString());
                gDias_Cant.Add(Convert.ToInt32(dr[1]));
            }

            chartViajesDiarios.Series[0].Points.DataBindXY(gDias, gDias_Cant);


        }
        private void administraciónDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if ( p.Permiso_Access(datos.g_idEmpresa, "frm_abm_clientes",datos.g_idUser)== 1)
            {
                frm_abm_clientes ofrm = new frm_abm_clientes();
                ofrm.Show();
            }
        }

        private void asignarRutasAClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_CorredorClientes", datos.g_idUser) == 1)
            {
                frm_CorredorClientes ofrm = new frm_CorredorClientes();
                ofrm.Show();
            }
        }

        private void contactosParaClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_abm_contactos", datos.g_idUser) == 1)
            {
                frm_abm_contactos ofrm = new frm_abm_contactos();
                ofrm.Show();
            }
        }

        private void administraciónDeTransportistasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_abm_proveedores", datos.g_idUser) == 1)
            {
                frm_abm_proveedores ofrm = new frm_abm_proveedores();
                ofrm.Show();
            }
        }

        private void contactosParaTransportistasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_abm_contactos_transportes", datos.g_idUser) == 1)
            {
                frm_abm_contactos_transportes ofrm = new frm_abm_contactos_transportes();
                ofrm.Show();
            }

        }

        private void asignarRutasATransportistasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_CorredorTransportes", datos.g_idUser) == 1)
            {
                frm_CorredorTransportes ofrm = new frm_CorredorTransportes();
                ofrm.Show();
            }
        }

        private void registrarTractoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_abm_tractores", datos.g_idUser) == 1)
            {
                frm_abm_tractores ofrm = new frm_abm_tractores();
                ofrm.Show();
            }
        }

        private void registrarChasisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_abm_chasis", datos.g_idUser) == 1)
            {
                frm_abm_chasis ofrm = new frm_abm_chasis();
                ofrm.Show();
            }
        }

        private void registrarChoferesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_abm_choferes", datos.g_idUser) == 1)
            {
                frm_abm_choferes ofrm = new frm_abm_choferes();
                ofrm.Show();
            }
        }

        private void cargaDeEventosParaEmailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_abm_eventos", datos.g_idUser) == 1)
            {
                frm_abm_eventos ofrm = new frm_abm_eventos();
                ofrm.Show();
            }
        }

        private void altaDePresupuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_Comerciales_Alta_Presupuestos", datos.g_idUser) == 1)
            {
                frm_Comerciales_Alta_Presupuestos ofrm = new frm_Comerciales_Alta_Presupuestos();
                ofrm.Show();
            }
        }

        private void altaDeOrdenesDeTransportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_Comerciales_OT", datos.g_idUser) == 1)
            {
                frm_Comerciales_OT ofrm = new frm_Comerciales_OT();
                ofrm.Location = new Point(10, 10);
                ofrm.Show();
            }
            //funciones_Varias fv = new funciones_Varias();
            //fv.Abrir_Form_OT(datos.g_permiso);

        }

        private void viajesADesignarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_Trafico_a_Designar", datos.g_idUser) == 1)
            {
                frm_Trafico_a_Designar ofrm = new frm_Trafico_a_Designar();
                ofrm._Empresa = datos.g_idEmpresa;
                //ofrm._Nominados = 0; //CAMBIAR DE 0 A 1 SEGÚN CORRESPONDA
                //ofrm._Concepto = 0;
                ofrm.Text = "Viajes a Designar.";
                ofrm.Show();
            }
        }

        private void seguimientoDeViajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_Trafico_En_Transito", datos.g_idUser) == 1)
            {
                frm_Trafico_En_Transito ofrm = new frm_Trafico_En_Transito();
                ofrm._Empresa = datos.g_idEmpresa;
                ofrm.Text = "SALIENDO DE TERMINAL";
                ofrm._Nominados = 1; //CAMBIAR DE 0 A 1 SEGÚN CORRESPONDA
                ofrm._Concepto = (Int32)funciones_Varias.TipoConcepto.C_SALE_TERMINAL;
                ofrm.Show();
            }
        }

        private void buscadorDeOrdenesDeTransportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frmBuscador_OT", datos.g_idUser) == 1)
            {
                frmBuscador_OT ofrm = new frmBuscador_OT();
                ofrm.IdEmpresa = datos.g_idEmpresa;
                ofrm.Show();
            }
        }

        private void altaDeRutasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_abm_corredores", datos.g_idUser) == 1)
            {
                frm_abm_corredores ofrm = new frm_abm_corredores();
                ofrm.Show();
            }
        }

        private void frmInicialFinal_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            //string tipo;

            foreach(ToolStripMenuItem item in this.barraPrincipal.Items)
            {
                item.BackColor = Color.LightBlue ;
                item.ForeColor = Color.Black;

                recorrerItems(item);

            }
        }
        private void recorrerItems(ToolStripMenuItem oneItem)
        {
            //foreach(ToolStripMenuItem subItem in oneItem.DropDownItems)
            //{
            //    subItem.BackColor = Color.MediumAquamarine;
            //    subItem.ForeColor = Color.White;
            //}
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Tag = "Sigue";
            Application.Exit();
            this.Dispose();
            this.Close();
        }

        private void frmInicialFinal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Tag.ToString() != "Sigue")
            {
                MessageBox.Show("Cierre el Sistema desde la opción de Menú 'Salir'", "Atención", MessageBoxButtons.OK);
                e.Cancel = true;
              
            }
        }

        private void minimizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void asociarEventosAEmailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PanelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }
        int count;
        private void FechaHoraActual_Tick(object sender, EventArgs e)
        {
            count++;
            this.st_Fecha.Text = DateTime.Now.ToString("dd MMM yyyy");
            this.st_Hora.Text= DateTime.Now.ToString("HH:mm:ss");
            if (count==100)
            {
                if (VerChar == 1)
                {
                    cargarGrafico();
                    cargarGrilla_CambioNominacion();
                    count = 0;
                }
            }
        }
        public void Alert(String msg)
        {
            frm_Form_Alert frm = new frm_Form_Alert();
            frm.showAlert(msg);
        }


        private void asociarEmailsAAdministraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_asoc_admin_email", datos.g_idUser) == 1)
            {
                frm_asoc_admin_email ofrm = new frm_asoc_admin_email();
                ofrm.Show();
            }
        }



        private void buscadorDeAnticiposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frmBuscador_Anticipos", datos.g_idUser) == 1)
            {
                frmBuscador_Anticipos ofrm = new frmBuscador_Anticipos();
                ofrm.IdEmpresa = datos.g_idEmpresa;
                ofrm.Show();
            }
        }

        private void confirmarAnticiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frmConfirma_Anticipos", datos.g_idUser) == 1)
            {
                frmConfirma_Anticipos ofrm = new frmConfirma_Anticipos();
                ofrm.IdEmpresa = datos.g_idEmpresa;
                ofrm.Show();
            }
        }

        private void informeCM2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frmCM2", datos.g_idUser) == 1)
            {
                frmCM2 ofrm = new frmCM2();
                ofrm.IdEmpresa = datos.g_idEmpresa;
                ofrm.Show();
            }

        }

        private void inicioDeViajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_Trafico_Designado", datos.g_idUser) == 1)
            {
                frm_Trafico_Designado ofrm = new frm_Trafico_Designado();
                ofrm._Empresa = datos.g_idEmpresa;
                ofrm.Text = "VIAJES DESIGNADOS";
                //ofrm._Nominados = 1; //CAMBIAR DE 0 A 1 SEGÚN CORRESPONDA
                //ofrm._Concepto = 0; //(Int32)funciones_Varias.TipoConcepto.C_INICIA_VIAJE ;
                ofrm.Show();
            }
        }

        private void enPuertoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_Trafico_En_Transito", datos.g_idUser) == 1)
            {
                frm_Trafico_En_Transito ofrm = new frm_Trafico_En_Transito();
                ofrm._Empresa = datos.g_idEmpresa;
                ofrm.Text = "EN PUERTO";
                ofrm._Nominados = 1; //CAMBIAR DE 0 A 1 SEGÚN CORRESPONDA
                ofrm._Concepto = (Int32)funciones_Varias.TipoConcepto.C_EN_PUERTO;
                ofrm.Show();
            }
        }

        private void enTránsitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_Trafico_En_Transito", datos.g_idUser) == 1)
            {
                frm_Trafico_En_Transito ofrm = new frm_Trafico_En_Transito();
                ofrm._Empresa = datos.g_idEmpresa;
                ofrm.Text = "EN TRANSITO";
                ofrm._Nominados = 1; //CAMBIAR DE 0 A 1 SEGÚN CORRESPONDA
                ofrm._Concepto = (Int32)funciones_Varias.TipoConcepto.C_EN_TRANSITO;
                ofrm.Show();
            }
        }

        private void enPlantaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_Trafico_En_Transito", datos.g_idUser) == 1)
            {
                frm_Trafico_En_Transito ofrm = new frm_Trafico_En_Transito();
                ofrm._Empresa = datos.g_idEmpresa;
                ofrm.Text = "EN PLANTA";
                ofrm._Nominados = 1; //CAMBIAR DE 0 A 1 SEGÚN CORRESPONDA
                ofrm._Concepto = (Int32)funciones_Varias.TipoConcepto.C_EN_PLANTA;
                ofrm.Show();
            }
        }

        private void retornoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_Trafico_En_Transito", datos.g_idUser) == 1)
            {
                frm_Trafico_En_Transito ofrm = new frm_Trafico_En_Transito();
                ofrm._Empresa = datos.g_idEmpresa;
                ofrm.Text = "RETORNO";
                ofrm._Nominados = 1; //CAMBIAR DE 0 A 1 SEGÚN CORRESPONDA
                ofrm._Concepto = (Int32)funciones_Varias.TipoConcepto.C_RETORNO;
                ofrm.Show();
            }
        }

        private void emailsDeViajesNominadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frmConfirma_Email_Nominacion", datos.g_idUser) == 1)
            {
                frmConfirma_Email_Nominacion ofrm = new frmConfirma_Email_Nominacion();
                ofrm.Show();
            }
        }

        private void estadoDeCombustibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frmCombustible", datos.g_idUser) == 1)
            {
                frmCombustible ofrm = new frmCombustible();
                ofrm.IdEmpresa = datos.g_idEmpresa;
                ofrm.Show();
            }
        }

        private void Modulo_Permisos_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frmPermisos", datos.g_idUser) == 1)
            {
                frmPermisos ofrm = new frmPermisos();
                ofrm.Show();
            }
        }

        private void reporteDeCotizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frmPermisos", datos.g_idUser) == 1)
            {
                frm_Emision_Reporte_Cotizaciones ofrm = new frm_Emision_Reporte_Cotizaciones();
                ofrm.Show();
            }
        }
        public class fila
        {
            public int xidd { get; set; }
            public int xitemd { get; set; }
            public int xcd { get; set; }

        };
        private void cmdAprobarCambios_Click(object sender, EventArgs e)
        {
            IList<fila> lista = new List<fila>();

            foreach (DataGridViewRow row in dt.Rows)
            {
                if (row.Cells["Confirmado"].Value.Equals(1))
                {
                    fila f = new fila();

                    f.xidd = (int)row.Cells["IdOt"].Value;
                    f.xitemd = (int)row.Cells["Item"].Value;
                    f.xcd = (int)row.Cells["Confirmado"].Value;

                    lista.Add(f);

                }

            }

            var xl = lista
                .Select(r => new { r.xidd, r.xitemd })
                .Distinct();

            Boolean bandera = false;
            foreach (var p in xl)

                bandera = procesar(p.xidd, p.xitemd, datos.g_idEmpresa);

            if (bandera)
                MessageBox.Show("Se procesaron los  Cambios de Nominación.");
            else MessageBox.Show("No se  procesaron todos los datos.");


            //Form1_Load(null, null);
            cargarGrilla_CambioNominacion();
        }

        private Boolean procesar(Int32 xitop, Int32 xitem, Int32 xidempresa)
        {


            clsConn cnMarco = new clsConn();

            String strConnection_String;

            strConnection_String = cnMarco.Cadena_Conexion();

            MySqlConnection cnnConnection = new MySqlConnection(strConnection_String);
            cnnConnection.Open();

            MySqlCommand cmdCommand = cnnConnection.CreateCommand();
            MySqlTransaction trsTransaccion;



            trsTransaccion = cnnConnection.BeginTransaction();

            cmdCommand.Connection = cnnConnection;
            cmdCommand.Transaction = trsTransaccion;
            cmdCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                cmdCommand.CommandText = "SP_cambio_nominacion_grilla_baja";

                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intOT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intItem", MySqlDbType.Int32);





                cmdCommand.Parameters["intEmpresa"].Value = xidempresa;
                cmdCommand.Parameters["intOT"].Value = xitop;
                cmdCommand.Parameters["intItem"].Value = xitem;

                cmdCommand.ExecuteNonQuery();

                trsTransaccion.Commit();

                cnnConnection.Close();
                return true;


            }
            catch (Exception ex)
            {
                trsTransaccion.Rollback();
                cnnConnection.Close();
                MessageBox.Show(ex.ToString());
                return false;
            }


            
            //Form1_Load(null,null);
        }

        private void dt_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            Int32 xid;
            Int32 xitem;
            Boolean xe;


            if (e.ColumnIndex == dt.Columns["Confirmado"].Index)
            {
                //dt.Rows[e.RowIndex].Cells["Confirmado"].Value
                xid = Convert.ToInt32(dt.Rows[e.RowIndex].Cells["IdOt"].Value);
                xitem = Convert.ToInt32(dt.Rows[e.RowIndex].Cells["Item"].Value);
                try
                {
                    xe = Convert.ToBoolean(dt.Rows[e.RowIndex].Cells["Confirmado"].Value);
                    check_item(xid, xitem, xe);
                }
                catch (Exception)
                {



                    xe = false;
                    check_item(xid, xitem, xe);

                }




            }

            #region com

            #endregion

        }

        private void dt_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dt.Columns["Confirmado"].Index)
            {
                dt.EndEdit();
            }
        }

        private void check_item(int id, int item, Boolean xe)
        {

            foreach (DataGridViewRow row in dt.Rows)
            {
                if ((Convert.ToInt32(row.Cells["IdOt"].Value) == id) && (Convert.ToInt32(row.Cells["Item"].Value) == item))
                {
                    row.Cells["Confirmado"].Value = xe;
                }


            }


        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ABM_Conceptos_Cotizacion ofrm = new frm_ABM_Conceptos_Cotizacion();
            ofrm.Show();
        }

        private void compañíasDeSeguroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DNTablas_Gral p = new DNTablas_Gral();

            if (p.Permiso_Access(datos.g_idEmpresa, "frm_abm_seguros", datos.g_idUser) == 1)
            {
                frm_abm_seguros ofrm = new frm_abm_seguros();
                ofrm.Show();
            }
        }

        private void dt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
