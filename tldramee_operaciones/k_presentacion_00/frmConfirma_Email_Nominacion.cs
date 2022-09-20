using System;
using System.Data;
using System.Windows.Forms;
using k_negocio_00;
using MySql.Data.MySqlClient;
using System.Globalization;
using k_mysql;

namespace k_presentacion_00
{
    public partial class frmConfirma_Email_Nominacion : Form
    {
        int idEmpresa;
        guardar_datos_login datos = guardar_datos_login.Instance();

        public int IdEmpresa { get => idEmpresa; set => idEmpresa = value; }

        public frmConfirma_Email_Nominacion()
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
            Configurar_Grilla();
            Cargar_Datos();
            this.Tiempo.Enabled = true;
            this.Tiempo.Interval = 1000 * 60;
        }
       private void Cargar_Datos()
        {
                       

                funciones_Varias o = new funciones_Varias();
                DNTablas_Gral lista = new DNTablas_Gral();

                BindingSource bindingSource = new BindingSource();

                System.Data.DataSet dsAnticipos = new System.Data.DataSet("Email_Nominacion");

                DataTable p;
                DateTime fechatemp;
                DateTime datFecha_Desde;
                DateTime datFecha_Hasta;


                fechatemp = DateTime.Today;
                datFecha_Desde = new DateTime(fechatemp.Year, fechatemp.Month, 1).AddDays(-5);
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
                    new MySqlParameter(){ ParameterName="intOpcion", Value = 0 },
                    new MySqlParameter(){ ParameterName="datFechaDesde", Value = datFecha_Desde },
                    new MySqlParameter(){ ParameterName="datFechaHasta", Value = datFecha_Hasta }
                };

                p = lista.Get_Datos("SP_Email_Nominacion", parameters);

                dsAnticipos.Tables.Add(p);

                bindingSource.DataSource = dsAnticipos.Tables[0];

                //this.lblOT.Text = "OT: " + _OT.ToString().PadLeft(11, '0');
                //this.lblDescripcion_Item.Text = _Descripcion_Item.ToString();
                //this.lblCosto.Text = "COSTO = " + _Costo.ToString();

                this.grdEmails.DataSource = dsAnticipos.Tables[0];

            
        }
        //private void cmdBuscar_Click(object sender, EventArgs e)
        //{
        //    DataTable dtOT;
        //    DNTablas_Gral lista = new DNTablas_Gral();
        //    MySqlParameter[] Parametros = new MySqlParameter[1];

        //    //Empresa
        //    Parametros[0] = new MySqlParameter("intEmpresa", datos.g_idEmpresa);


        //    dtOT = lista.Get_Datos("SP_Anticipos_Autorizacion", Parametros); //, parameters);

        //    grdEmails.DataSource = dtOT;
        //    grdEmails.Columns[0].Width = 25;
        //    grdEmails.Columns[1].Width = 25;
        //    grdEmails.Columns[5].Width = 120;
        //    grdEmails.Columns[7].Width = 50;
        //    grdEmails.Columns[8].Width = 50;

        //    //if (MessageBox.Show("¿Desea Exportar a Excel?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //    //{
        //    //    funciones_Varias.ExportToExcel(this.dgv,"Exportacion_Anticipos");
        //    //}
        //}

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            grdEmails.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //if (e.ColumnIndex == 9)
            //{
            //    DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)grdEmails.CurrentCell;
            //    bool isChecked = (bool)checkbox.EditedFormattedValue;
            //    int intOT;
            //    int intItem;
            //    if (isChecked)
            //    {
            //        intOT = (Int32)grdEmails[0, e.RowIndex].Value;
            //        intItem = (Int32)grdEmails[1, e.RowIndex].Value;
            //        Grabar("SP_Anticipos_Confirma",intOT,intItem);
            //        //Cargar_Datos();
            //        grdEmails[9, e.RowIndex].ReadOnly = true;
            //        grdEmails[10, e.RowIndex].ReadOnly = true;
            //    }
            //}
            if (e.ColumnIndex ==11)
            {
                //DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)grdEmails.CurrentCell;
               // bool isChecked = (bool)checkbox.EditedFormattedValue;
                int intOT;
                int intEmpresa;
                string strBooking;
                int intIdCliente;
                //if (isChecked)
               // {
                    intEmpresa = (Int32)grdEmails[0, e.RowIndex].Value;
                    intOT = (Int32)grdEmails[3, e.RowIndex].Value;
                    intIdCliente = (Int32)grdEmails[1, e.RowIndex].Value;
                    strBooking = grdEmails[6, e.RowIndex].Value.ToString();

                    funciones_envio_emails fee = new funciones_envio_emails();
                    fee.Envio_Email_Cuadro_Control(intEmpresa, intOT, strBooking, intIdCliente, 0, 0, 0, (Int32)funciones_envio_emails.TipoArchivos.E_NOMINACION,"lightblue");
                    Cargar_Datos();
                //}
            }
        }
        //private void Grabar(string SP,int intOT, int intItem)
        //{
        //    clsConn cnMarco = new clsConn();

        //    string strConnection_String;

        //    strConnection_String = cnMarco.Cadena_Conexion();

        //    MySqlConnection cnnConnection = new MySqlConnection(strConnection_String);
        //    cnnConnection.Open();

        //    MySqlCommand cmdCommand = cnnConnection.CreateCommand();
        //    MySqlTransaction trsTransaccion;
        //    trsTransaccion = cnnConnection.BeginTransaction();

        //    cmdCommand.Connection = cnnConnection;
        //    cmdCommand.Transaction = trsTransaccion;
        //    cmdCommand.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        cmdCommand.CommandText = SP;

        //        cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
        //        cmdCommand.Parameters.Add("intOT", MySqlDbType.Int32);
        //        cmdCommand.Parameters.Add("intItem_OT", MySqlDbType.Int32);

        //        cmdCommand.Parameters["intEmpresa"].Value = datos.g_idEmpresa ;

        //        cmdCommand.Parameters["intOT"].Value = intOT;
        //        cmdCommand.Parameters["intItem_OT"].Value = intItem;
        //        cmdCommand.ExecuteNonQuery();
        //        trsTransaccion.Commit();
        //    }
        //    catch (Exception e)
        //    {
        //        try
        //        {
        //            trsTransaccion.Rollback();
        //        }
        //        catch (MySqlException ex)
        //        {
        //            if (trsTransaccion.Connection != null)
        //            {
        //                Console.WriteLine("Error" + ex.GetType());
        //            }
        //        }

        //        Console.WriteLine("Error" + e.GetType());
        //    }
        //    finally
        //    {
        //        cnnConnection.Close();
        //    }
        //}
        public void Configurar_Grilla()
        {
            DataGridViewColumn colIdEmpresa = new DataGridViewTextBoxColumn();
            DataGridViewColumn colIdCliente = new DataGridViewTextBoxColumn();
            DataGridViewColumn colIdCorredor = new DataGridViewTextBoxColumn();

            DataGridViewColumn colIdOT = new DataGridViewTextBoxColumn();

            DataGridViewColumn colRazonSocial = new DataGridViewTextBoxColumn();

            DataGridViewColumn colFecha = new DataGridViewTextBoxColumn();


            DataGridViewColumn colBLBooking = new DataGridViewTextBoxColumn();

            DataGridViewColumn colServicio = new DataGridViewTextBoxColumn();

            DataGridViewColumn colRuta = new DataGridViewTextBoxColumn();


            DataGridViewColumn colViajes = new DataGridViewTextBoxColumn();

            DataGridViewColumn colEmail = new DataGridViewTextBoxColumn();

            DataGridViewColumn colBtnEnvia = new DataGridViewButtonColumn();

            grdEmails.AutoGenerateColumns = false;
            grdEmails.AllowUserToAddRows = false;


            grdEmails.Columns.Add(colIdEmpresa);
            grdEmails.Columns.Add(colIdCliente);
            grdEmails.Columns.Add(colIdCorredor);
            grdEmails.Columns.Add(colIdOT);
            grdEmails.Columns.Add(colRazonSocial);

            grdEmails.Columns.Add(colFecha);

            grdEmails.Columns.Add(colBLBooking);
            grdEmails.Columns.Add(colServicio);
            grdEmails.Columns.Add(colRuta);
            grdEmails.Columns.Add(colViajes);
            grdEmails.Columns.Add(colEmail);
            grdEmails.Columns.Add(colBtnEnvia);
            

            //grdConceptos.ColumnCount = 5;
            grdEmails.Columns[0].Name = "IdEmpresa";
            grdEmails.Columns[1].Name = "IdCliente";
            grdEmails.Columns[2].Name = "IdCorredor";
            grdEmails.Columns[3].Name = "IdOT";
            grdEmails.Columns[4].Name = "RazonSocial";

            grdEmails.Columns[5].Name = "Fecha";

            grdEmails.Columns[6].Name = "BLBooking";
            grdEmails.Columns[7].Name = "Servicio";

            grdEmails.Columns[8].Name = "Ruta";
            grdEmails.Columns[9].Name = "Viajes";
            grdEmails.Columns[10].Name = "Email";
            grdEmails.Columns[11].Name = "Envia";

            //grdAnticipos.Columns[10].Name = "Anula";



            //grdAnticipos.Columns[8].DefaultCellStyle.Format = "N2";


            //grdConceptos.Columns[10].DefaultCellStyle.Format = "HH:mm";
            //grdConceptos.Columns[12].DefaultCellStyle.Format = "HH:mm";

            grdEmails.Columns[0].HeaderText = "IdEmpresa";
            grdEmails.Columns[1].HeaderText = "IdCliente";
            grdEmails.Columns[2].HeaderText = "IdCorredor";
            grdEmails.Columns[3].HeaderText = "OT";
            grdEmails.Columns[4].HeaderText = "RazonSocial";
            grdEmails.Columns[5].HeaderText = "Fecha";
            grdEmails.Columns[6].HeaderText = "BLBooking";
            grdEmails.Columns[7].HeaderText = "Servicio";

            grdEmails.Columns[8].HeaderText = "Ruta";
            grdEmails.Columns[9].HeaderText = "Viajes";
            grdEmails.Columns[10].HeaderText = "Fecha Email";
            grdEmails.Columns[11].HeaderText = "Envia";
            


            //grdConceptos.Columns[6].HeaderText = "Estado";

            grdEmails.Columns[0].DataPropertyName = "IdEmpresa";
            grdEmails.Columns[1].DataPropertyName = "Id";
            grdEmails.Columns[2].DataPropertyName = "IdCorredor";
            grdEmails.Columns[3].DataPropertyName = "IdOT";
            grdEmails.Columns[4].DataPropertyName = "RazonSocial"; 
            
            grdEmails.Columns[5].DataPropertyName = "Fecha";
            
            grdEmails.Columns[6].DataPropertyName = "BLBooking";
            grdEmails.Columns[7].DataPropertyName = "Tipo_Servicio";

            grdEmails.Columns[8].DataPropertyName = "Ruta";
            grdEmails.Columns[9].DataPropertyName = "Cantidad_Viajes";
            grdEmails.Columns[10].DataPropertyName = "Nominacion";


            grdEmails.Columns[0].Visible  = false;
            grdEmails.Columns[1].Visible = false;
            grdEmails.Columns[2].Visible = false;
            grdEmails.Columns[3].Width = 40;
            grdEmails.Columns[4].Width=150;
            grdEmails.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            grdEmails.Columns[5].Width = 150;
            grdEmails.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            grdEmails.Columns[6].Width = 150;
            grdEmails.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdEmails.Columns[7].Width = 60;
            grdEmails.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grdEmails.Columns[8].Width = 250;
            grdEmails.Columns[9].Width = 100;
            grdEmails.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdEmails.Columns[10].Width = 150;

            //grdAnticipos.Columns[4].Width = 200;
            //grdAnticipos.Columns[6].Width = 200;
            for (int i = 0; i < 11; i++)
            {
                this.grdEmails.Columns[i].ReadOnly = true;
            }



        }

        private void Tiempo_Tick(object sender, EventArgs e)
        {
            Cargar_Datos();
        }

        private void grdEmails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {

            
                string valor;
                if (e.Value.GetType() != typeof(System.DBNull))
                {


                    if (this.grdEmails.Columns[e.ColumnIndex].Name == "Email")
                    {

                        valor = e.Value is DBNull ? "" : e.Value.ToString();
                        if (valor == "")
                        {
                            this.grdEmails.Rows[e.RowIndex].Cells["Envia"].Value = "Enviar";
                        }
                        else
                        {
                            this.grdEmails.Rows[e.RowIndex].Cells["Envia"].Value = "Re - Enviar";
                        }
                    }
                }

                }
            catch (NullReferenceException)
            {
                //MessageBox.Show("" + ex);
               // throw;
            }
        }
    }
}
