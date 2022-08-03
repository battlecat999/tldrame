using System;
using System.Data;
using System.Windows.Forms;
using k_negocio_00;
using MySql.Data.MySqlClient;
using System.Globalization;
using k_mysql;

namespace k_presentacion_00
{
    public partial class frmConfirma_Anticipos : Form
    {
        int idEmpresa;
        guardar_datos_login datos = guardar_datos_login.Instance();

        public int IdEmpresa { get => idEmpresa; set => idEmpresa = value; }

        public frmConfirma_Anticipos()
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

                System.Data.DataSet dsAnticipos = new System.Data.DataSet("Anticipos_Pendientes");

                DataTable p;

                var parameters = new[]
                {
                    new MySqlParameter(){ ParameterName="intEmpresa", Value = datos.g_idEmpresa }
                };

                p = lista.Get_Datos("SP_Anticipos_Autorizacion", parameters);

                dsAnticipos.Tables.Add(p);

                bindingSource.DataSource = dsAnticipos.Tables[0];

                //this.lblOT.Text = "OT: " + _OT.ToString().PadLeft(11, '0');
                //this.lblDescripcion_Item.Text = _Descripcion_Item.ToString();
                //this.lblCosto.Text = "COSTO = " + _Costo.ToString();

                this.grdAnticipos.DataSource = dsAnticipos.Tables[0];

            
        }
        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            DataTable dtOT;
            DNTablas_Gral lista = new DNTablas_Gral();
            MySqlParameter[] Parametros = new MySqlParameter[1];

            //Empresa
            Parametros[0] = new MySqlParameter("intEmpresa", datos.g_idEmpresa);


            dtOT = lista.Get_Datos("SP_Anticipos_Autorizacion", Parametros); //, parameters);

            grdAnticipos.DataSource = dtOT;
            grdAnticipos.Columns[0].Width = 25;
            grdAnticipos.Columns[1].Width = 25;
            grdAnticipos.Columns[5].Width = 120;
            grdAnticipos.Columns[7].Width = 50;
            grdAnticipos.Columns[8].Width = 50;

            //if (MessageBox.Show("¿Desea Exportar a Excel?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    funciones_Varias.ExportToExcel(this.dgv,"Exportacion_Anticipos");
            //}
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            grdAnticipos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (e.ColumnIndex == 9)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)grdAnticipos.CurrentCell;
                bool isChecked = (bool)checkbox.EditedFormattedValue;
                int intOT;
                int intItem;
                if (isChecked)
                {
                    intOT = (Int32)grdAnticipos[0, e.RowIndex].Value;
                    intItem = (Int32)grdAnticipos[1, e.RowIndex].Value;
                    Grabar("SP_Anticipos_Confirma",intOT,intItem);
                    //Cargar_Datos();
                    grdAnticipos[9, e.RowIndex].ReadOnly = true;
                    grdAnticipos[10, e.RowIndex].ReadOnly = true;
                }
            }
            if (e.ColumnIndex ==10)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)grdAnticipos.CurrentCell;
                bool isChecked = (bool)checkbox.EditedFormattedValue;
                int intOT;
                int intItem;
                if (isChecked)
                {
                    intOT = (Int32)grdAnticipos[0, e.RowIndex].Value;
                    intItem = (Int32)grdAnticipos[1, e.RowIndex].Value;
                    Grabar("SP_Anticipos_Delete", intOT, intItem);
                    grdAnticipos[9, e.RowIndex].ReadOnly = true;
                    grdAnticipos[10, e.RowIndex].ReadOnly = true;
                    //Cargar_Datos();

                }
            }
        }
        private void Grabar(string SP,int intOT, int intItem)
        {
            clsConn cnMarco = new clsConn();

            string strConnection_String;

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
                cmdCommand.CommandText = SP;

                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intOT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intItem_OT", MySqlDbType.Int32);

                cmdCommand.Parameters["intEmpresa"].Value = datos.g_idEmpresa ;

                cmdCommand.Parameters["intOT"].Value = intOT;
                cmdCommand.Parameters["intItem_OT"].Value = intItem;
                cmdCommand.ExecuteNonQuery();
                trsTransaccion.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    trsTransaccion.Rollback();
                }
                catch (MySqlException ex)
                {
                    if (trsTransaccion.Connection != null)
                    {
                        Console.WriteLine("Error" + ex.GetType());
                    }
                }

                Console.WriteLine("Error" + e.GetType());
            }
            finally
            {
                cnnConnection.Close();
            }
        }
        public void Configurar_Grilla()
        {
            DataGridViewColumn colIdOT = new DataGridViewTextBoxColumn();
            DataGridViewColumn colItem = new DataGridViewTextBoxColumn();

            DataGridViewColumn colRazonSocial = new DataGridViewTextBoxColumn();
            DataGridViewColumn colBLBooking = new DataGridViewTextBoxColumn();

            DataGridViewColumn colRuta = new DataGridViewTextBoxColumn();
            DataGridViewColumn colTransportista = new DataGridViewTextBoxColumn();

            DataGridViewColumn colChofer = new DataGridViewTextBoxColumn();
            DataGridViewColumn colFechaPago = new DataGridViewTextBoxColumn();

            DataGridViewColumn colTotalAnticipo = new DataGridViewTextBoxColumn();
            DataGridViewColumn colConfirma = new DataGridViewCheckBoxColumn();
            DataGridViewColumn colAnula = new DataGridViewCheckBoxColumn();

            grdAnticipos.AutoGenerateColumns = false;

            grdAnticipos.Columns.Add(colIdOT);
            grdAnticipos.Columns.Add(colItem);
            grdAnticipos.Columns.Add(colRazonSocial);
            grdAnticipos.Columns.Add(colBLBooking);
            grdAnticipos.Columns.Add(colRuta);
            grdAnticipos.Columns.Add(colTransportista);
            grdAnticipos.Columns.Add(colChofer);

            grdAnticipos.Columns.Add(colFechaPago);
            grdAnticipos.Columns.Add(colTotalAnticipo);
            grdAnticipos.Columns.Add(colConfirma);
            grdAnticipos.Columns.Add(colAnula);



            //grdConceptos.ColumnCount = 5;
            grdAnticipos.Columns[0].Name = "IdOT";
            grdAnticipos.Columns[1].Name = "Item";
            grdAnticipos.Columns[2].Name = "RazonSocial";
            grdAnticipos.Columns[3].Name = "BLBooking";
            grdAnticipos.Columns[4].Name = "Ruta";
            grdAnticipos.Columns[5].Name = "Transportista";
            grdAnticipos.Columns[6].Name = "Chofer";

            grdAnticipos.Columns[7].Name = "Fecha_Pago";
            grdAnticipos.Columns[8].Name = "Total_Anticipo";
            grdAnticipos.Columns[9].Name = "Confirma";
            grdAnticipos.Columns[10].Name = "Anula";



            grdAnticipos.Columns[8].DefaultCellStyle.Format = "N2";


            //grdConceptos.Columns[10].DefaultCellStyle.Format = "HH:mm";
            //grdConceptos.Columns[12].DefaultCellStyle.Format = "HH:mm";

            grdAnticipos.Columns[0].HeaderText = "O.T";
            grdAnticipos.Columns[1].HeaderText = "Item";
            grdAnticipos.Columns[2].HeaderText = "Cliente";
            grdAnticipos.Columns[3].HeaderText = "Bl/Booking";
            grdAnticipos.Columns[4].HeaderText = "Ruta";
            grdAnticipos.Columns[5].HeaderText = "Transportista";
            grdAnticipos.Columns[6].HeaderText = "Chofer";

            grdAnticipos.Columns[7].HeaderText = "Fecha Pago";
            grdAnticipos.Columns[8].HeaderText = "Total";
            grdAnticipos.Columns[9].HeaderText = "¿Confirma?";
            grdAnticipos.Columns[10].HeaderText = "¿Anulas?";


            //grdConceptos.Columns[6].HeaderText = "Estado";

            grdAnticipos.Columns[0].DataPropertyName = "IdOT";
            grdAnticipos.Columns[1].DataPropertyName = "item";
            grdAnticipos.Columns[2].DataPropertyName = "Razon_Social";
            grdAnticipos.Columns[3].DataPropertyName = "BLBooking";
            grdAnticipos.Columns[4].DataPropertyName = "Ruta";
            grdAnticipos.Columns[5].DataPropertyName = "transportista";

            grdAnticipos.Columns[6].DataPropertyName = "chofer";
            grdAnticipos.Columns[7].DataPropertyName = "Fecha_Pago";
            grdAnticipos.Columns[8].DataPropertyName = "Total_Anticipo";
            grdAnticipos.Columns[9].DataPropertyName = "Confirma";
            grdAnticipos.Columns[10].DataPropertyName = "Anula";

            grdAnticipos.Columns[0].Width = 35;
            grdAnticipos.Columns[1].Width = 35;
            grdAnticipos.Columns[2].Width = 55;
            grdAnticipos.Columns[3].Width = 65;
            grdAnticipos.Columns[4].Width = 200;
            grdAnticipos.Columns[6].Width = 200;
            for (int i = 0; i < 9; i++)
            {
                this.grdAnticipos.Columns[i].ReadOnly = true;
            }
            

        
        }

        private void Tiempo_Tick(object sender, EventArgs e)
        {
            Cargar_Datos();
        }
    }
}
