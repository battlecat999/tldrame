using k_mysql;
using k_negocio_00;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace k_presentacion_00
{
    //EDD 08/09/22 declaramos objetos traemos sus datos _FechaPosicion _FechaRetiro _HoraPosicion// 
    public partial class frmCambioNominacion : Form
    {
        bool IsBlackList = false;
        int intFlag = 0;
        int intRepeticiones = 0;
        string lblLeyenda = "XXX SE ENCUENTRA BLOQUEADO PARA REALIZAR VIAJES. COMUNICARSE CON MAXIMILIANO RUATA.";

        public int _Empresa { get; set; }
        public int _OT { get; set; }
        public int _Item { get; set; }
        public int _codigo_Transportista { get; set; }
        public string _nombre_Transportista { get; set; }
        public string _FechaPosicion { get; set; }
        public string _FechaRetiro { get; set; }
        public string _HoraPosicion { get; set; }

        public int _codigo_Tractor { get; set; }
        public string _nombre_Tractor { get; set; }
        public int _codigo_Chasis { get; set; }
        public string _nombre_Chasis { get; set; }
        public int _codigo_Chofer { get; set; }
        public string _nombre_Chofer { get; set; }
        public int _tiene_Anticipo { get; set; }
        public int _tiene_Factura { get; set; }
        public int _Corredor { get; set; }
        public Decimal _Costo { get; set; }
        public int _IdCliente { get; set; }
        public string _BLBooking { get; set; }
        public string _groupBox1 { get; set; }

        guardar_datos_login datos = guardar_datos_login.Instance();

        public frmCambioNominacion()
        {
            InitializeComponent();
            funciones_Varias fv = new funciones_Varias();
            //fv.ColorearGradientPanel(this, this.Panel);
        }

        private void Frm_PopUp_Designa_Viaje_Load(object sender, EventArgs e)
        {

            Inicia();

        }

        //DDE 08/09/22 agregamos datfechaposic/datfecharetiro/cboHoraPosicion//
        private void Inicia()
        {
            
            this.lblOT.Text = string.Empty;
            this.lblItem.Text = string.Empty;
      
            this.lbl_Codigo_Transportista.Text = string.Empty;
            this.lbl_Codigo_Tractor.Text = string.Empty;
            this.lbl_Codigo_Chasis.Text = string.Empty;
            this.lbl_Codigo_Chofer.Text = string.Empty;

            this.lbl_Nombre_Transportista.Text = string.Empty;
            this.lbl_Nombre_Tractor.Text = string.Empty;
            this.lbl_Nombre_Chasis.Text = string.Empty;
            this.lbl_Nombre_Chofer.Text = string.Empty;

            //dde 08/09/22 llamamos al metodo;
            Carga_Horarios();
            this.datFechaPosic.Text = _FechaPosicion.ToString();
            this.datFechaRetiro.Text = _FechaRetiro.ToString();
            this.cboHoraPosicion.Text = _HoraPosicion.ToString();
            this.lblOT.Text = _OT.ToString();
            this.lblItem.Text = _Item.ToString();


            this.lbl_Codigo_Transportista.Text = _codigo_Transportista.ToString();
            this.lbl_Codigo_Tractor.Text = _codigo_Tractor.ToString();
            this.lbl_Codigo_Chasis.Text = _codigo_Chasis.ToString();
            this.lbl_Codigo_Chofer.Text = _codigo_Chofer.ToString();

            this.lbl_Nombre_Transportista.Text = _nombre_Transportista.ToString();
            this.lbl_Nombre_Tractor.Text = _nombre_Tractor.ToString();
            this.lbl_Nombre_Chasis.Text = _nombre_Chasis.ToString();
            this.lbl_Nombre_Chofer.Text = _nombre_Chofer.ToString();

            this.lblCostoEmpresa.Text = _Costo.ToString();
            this.lblCostoProveedor.Text = "0,00";

            this.lbl_BL_Booking.Text = _BLBooking.ToString();

            Cursor.Current = Cursors.WaitCursor;
            //dde 08/09/22 llamaos al metodo;
            
            Carga_Combo_Transportistas();
            Verifico_Existe_Anticipo();
            //Carga_Combo_Choferes();

            IsBlackList = false;

            Cursor.Current = Cursors.Default;
        }
        private void Verifico_Existe_Anticipo()
        {
            funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            string strTieneAnticipo;
            string strTieneFactura;

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = _Empresa },
                new MySqlParameter(){ ParameterName="intOT", Value = _OT },
                new MySqlParameter(){ ParameterName="intItem", Value = _Item }
            };

            DataTable p;

            p = lista.Get_Datos("SP_ItemOT_Tiene_Anticipo_Factura", parameters);
            if(p.Rows.Count >0)
                {
                strTieneAnticipo = p.Rows[0][0].ToString();
                strTieneFactura = p.Rows[0][1].ToString();
                if (strTieneAnticipo == "NO" && strTieneFactura == "NO" && strTieneAnticipo == null && strTieneFactura == null)
                {
                    this.lbl_Aviso_Anticipo.Visible = false;
                }
                else
                {
                    this.lbl_Aviso_Anticipo.Visible = true;
                }
            }
            

        }
        private void Carga_Combo_Transportistas()
        {

            funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="pIdEmpresa", Value = _Empresa },
                new MySqlParameter(){ ParameterName="pIdCorredor", Value = _Corredor },
                new MySqlParameter(){ ParameterName="pCosto", Value = _Costo }
            };

            DataTable p;

            p = lista.Get_Transportistas("SP_Proveedor_A_Designar", parameters);

            this.cboTransportista.SelectedValueChanged -= new EventHandler(this.CboTransportista_SelectedValueChanged);

            o.CargarComboDataTable(this.cboTransportista, p, "id", "Descripcion", false, true, true, false);

            this.cboTransportista.SelectedValueChanged += new EventHandler(this.CboTransportista_SelectedValueChanged);

        }
        //dde 08/09/22 llamamos al storeprocedure para cargar horarios;
        private void Carga_Horarios()
        {

            funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="pIdEmpresa", Value = _Empresa },
                new MySqlParameter(){ ParameterName="pIdCorredor", Value = _Corredor },
                new MySqlParameter(){ ParameterName="pCosto", Value = _Costo }
            };

            DataTable p;

            p = lista.Get_Datos("SP_CargaHorarios", parameters);

        

            o.CargarComboDataTable(this.cboHoraPosicion, p, "Codigo_Hora", "Descripcion", false, false, false, false);

           

        }

        private void Carga_Combo_Tractores(int intEmpresa, int intTransportista)
        {

            funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = intEmpresa },
                new MySqlParameter(){ ParameterName="intTransportista", Value = intTransportista }
            };

            DataTable p;

            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;

            p = lista.Get_Datos("SP_Get_Tractor_Transportista", parameters);

            o.CargarComboDataTable(this.cboTractores, p, "id", "Patente", false, false);

            Cursor.Current = Cursors.Default;

        }

        private void Carga_Combo_Chasis(int intEmpresa, int intTransportista)
        {

            funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = intEmpresa },
                new MySqlParameter(){ ParameterName="intTransportista", Value = intTransportista }
            };

            DataTable p;

            p = lista.Get_Datos("SP_Get_Chasis_Transportista", parameters);

            o.CargarComboDataTable(this.cboChasis, p, "id", "Patente", false, false);

        }

        private void Carga_Combo_Choferes(int intTransportista)
        {

            funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = datos.g_idEmpresa },
                new MySqlParameter(){ ParameterName="intTransportista", Value = intTransportista }
            };

            DataTable p;

            p = lista.Get_Datos("SP_Get_Chofer_Transportista", parameters);

            o.CargarComboDataTable(this.cboChoferes, p, "IdChofer", "Apellido", false, false,true,false);

        }






        private void CboTransportista_SelectedValueChanged(object sender, EventArgs e)
        {
            int intTransportista = 0;

            if (this.cboTransportista.SelectedIndex != -1)
            {

                intTransportista = (int)this.cboTransportista.SelectedValue;
                this.cboTractores.SelectedValueChanged -= new System.EventHandler(this.CboTractores_SelectedValueChanged);
                this.cboChasis.SelectedValueChanged -= new System.EventHandler(this.cboChasis_SelectedValueChanged);
                this.cboChoferes.SelectedValueChanged -= new System.EventHandler(this.cboChoferes_SelectedValueChanged);

                Carga_Combo_Tractores(_Empresa, intTransportista);

                Carga_Combo_Chasis(_Empresa, intTransportista);

                Carga_Combo_Choferes(intTransportista);

                this.cboTractores.SelectedValueChanged += new System.EventHandler(this.CboTractores_SelectedValueChanged);
                this.cboChasis.SelectedValueChanged += new System.EventHandler(this.cboChasis_SelectedValueChanged);
                this.cboChoferes.SelectedValueChanged += new System.EventHandler(this.cboChoferes_SelectedValueChanged);

                DataTable dt;
                dt = (DataTable)this.cboTransportista.DataSource;
                DataRow[] Busco_Dato;
                Busco_Dato = dt.Select("id=" + (Int32)this.cboTransportista.SelectedValue);
                if (Busco_Dato.Count() > 0)
                {
                    this.lblCostoProveedor.Text = Busco_Dato[0][2].ToString();
                    decimal cTransportista;
                    decimal cEmpresa;
                    decimal cDiferencia;
                    cTransportista = Convert.ToDecimal(this.lblCostoProveedor.Text);
                    cEmpresa = Convert.ToDecimal(this.lblCostoEmpresa.Text);
                    cDiferencia = cEmpresa - cTransportista;
                    if (cDiferencia < 0)
                    {
                        this.lbl_Aviso_Costo.Visible = true;
                        this.Tag = "REQ";
                    }
                    else
                    {
                        this.lbl_Aviso_Costo.Visible = false;
                        this.Tag = "OK";
                    }
                    return;
                }
                else
                {
                    this.lblC.Text = "0.00";
                    return;
                }

            }


        }



        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Grabar()
        {

            int intTransportista = 0;
            int intTractor = 0;
            int intChasis = 0;
            int intChofer = 0;
            int intGrabaCambioNominacion = 0;
    

            if (this.cboTransportista.SelectedIndex != -1)
            {
                intTransportista = int.Parse(this.cboTransportista.SelectedValue.ToString());
            }

            if (this.cboTractores.SelectedIndex != -1)
            {
                intTractor = int.Parse(this.cboTractores.SelectedValue.ToString());
            }
            else
            {
                intTractor = int.Parse(this.lbl_Codigo_Tractor.Text);
            }

            if (this.cboChasis.SelectedIndex != -1)
            {
                intChasis = int.Parse(this.cboChasis.SelectedValue.ToString());
            }
            else
            {
                intChasis = int.Parse(this.lbl_Codigo_Chasis.Text);
            }

            if (this.cboChoferes.SelectedIndex != -1)
            {
                intChofer = int.Parse(this.cboChoferes.SelectedValue.ToString());
            }
            else
            {
                intChofer = int.Parse(this.lbl_Codigo_Chofer.Text);
            }

            if (intTransportista == 0 || intTractor == 0 || intChasis == 0 || intChofer == 0)
            {
                MessageBox.Show("Verifique la seleción de las opciones de nominacion");
                return;
            }

            if (intTransportista== Convert.ToInt32(this.lbl_Codigo_Transportista.Text))
            {
                intGrabaCambioNominacion = 0;//No Graba cambio de Nominación.
            }
            else
            {
                intGrabaCambioNominacion = 1;//Graba cambio de Nominación.
            }



            clsConn cnMarco = new clsConn();

            String strConnection_String = "";

            strConnection_String = cnMarco.Cadena_Conexion();

            MySqlConnection cnnConnection = new MySqlConnection(strConnection_String);
            cnnConnection.Open();

            MySqlCommand cmdCommand = cnnConnection.CreateCommand();
            MySqlTransaction trsTransaccion;



            trsTransaccion = cnnConnection.BeginTransaction();

            cmdCommand.Connection = cnnConnection;
            cmdCommand.Transaction = trsTransaccion;
            cmdCommand.CommandType = CommandType.StoredProcedure;
            //int intNroOrden;
            try
            {

                if (intGrabaCambioNominacion != 0)
                {
                    //0 Primera Pasada
                    cmdCommand.Parameters.Clear();
                    cmdCommand.CommandText = "SP_Cambio_Nominacion_Insert";

                    cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                    cmdCommand.Parameters.Add("intOT", MySqlDbType.Int32);
                    cmdCommand.Parameters.Add("intItem", MySqlDbType.Int32);
                    cmdCommand.Parameters.Add("intTransportista", MySqlDbType.Int32);
                    cmdCommand.Parameters.Add("intTractor", MySqlDbType.Int32);
                    cmdCommand.Parameters.Add("intChasis", MySqlDbType.Int32);
                    cmdCommand.Parameters.Add("intChofer", MySqlDbType.Int32);
                    cmdCommand.Parameters.Add("decCosto", MySqlDbType.Decimal);
                    cmdCommand.Parameters.Add("intUsuario", MySqlDbType.Int32);
                    cmdCommand.Parameters.Add("intOrden", MySqlDbType.Int32);
                    cmdCommand.Parameters.Add("intGrabaCambioNominacion", MySqlDbType.Int32);


                    cmdCommand.Parameters["intEmpresa"].Value = _Empresa;
                    cmdCommand.Parameters["intOT"].Value = _OT;
                    cmdCommand.Parameters["intItem"].Value = _Item;
                    cmdCommand.Parameters["intTransportista"].Value = Convert.ToInt32(this.lbl_Codigo_Transportista.Text);
                    cmdCommand.Parameters["intTractor"].Value = Convert.ToInt32(this.lbl_Codigo_Tractor.Text);
                    cmdCommand.Parameters["intChasis"].Value = Convert.ToInt32(this.lbl_Codigo_Chasis.Text);
                    cmdCommand.Parameters["intChofer"].Value = Convert.ToInt32(this.lbl_Codigo_Chofer.Text);
                    cmdCommand.Parameters["decCosto"].Value = 0;
                    cmdCommand.Parameters["intUsuario"].Value = datos.g_idUser;
                    cmdCommand.Parameters["intOrden"].Value = 0;
                    cmdCommand.Parameters["intGrabaCambioNominacion"].Value = intGrabaCambioNominacion;//0 OR 1

                    cmdCommand.ExecuteNonQuery();
                }

                DN_Operaciones ope = new DN_Operaciones();
                ope.liberarCamiones(_Empresa, Convert.ToInt32(this.lbl_Codigo_Transportista.Text), Convert.ToInt32(this.lbl_Codigo_Tractor.Text), Convert.ToInt32(this.lbl_Codigo_Chasis.Text), Convert.ToInt32(this.lbl_Codigo_Chofer.Text), 0, 0);
                //1 Segunda Pasada
                cmdCommand.Parameters.Clear();
                cmdCommand.CommandText = "SP_Cambio_Nominacion_Insert";

                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intOT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intItem", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intTransportista", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intTractor", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intChasis", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intChofer", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("decCosto", MySqlDbType.Decimal);
                cmdCommand.Parameters.Add("intUsuario", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intOrden", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intGrabaCambioNominacion", MySqlDbType.Int32);

                cmdCommand.Parameters["intEmpresa"].Value = _Empresa;
                cmdCommand.Parameters["intOT"].Value = _OT;
                cmdCommand.Parameters["intItem"].Value = _Item;
                cmdCommand.Parameters["intTransportista"].Value = intTransportista;
                cmdCommand.Parameters["intTractor"].Value = intTractor;
                cmdCommand.Parameters["intChasis"].Value = intChasis;
                cmdCommand.Parameters["intChofer"].Value = intChofer;
                cmdCommand.Parameters["decCosto"].Value = _Costo;
                cmdCommand.Parameters["intUsuario"].Value = datos.g_idUser;
                cmdCommand.Parameters["intOrden"].Value = 1;
                cmdCommand.Parameters["intGrabaCambioNominacion"].Value = intGrabaCambioNominacion;//0 OR 1

                cmdCommand.ExecuteNonQuery();
                trsTransaccion.Commit();

                //tabla rq autorización.
                //quien autoriza? 
                //quien ve avisos.


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

        private void BtnAsignar_Click(object sender, EventArgs e)
        {

            //this.btnAsignar.Enabled = false;

            if (!Valida()) { return; }

            Cursor.Current = Cursors.WaitCursor;

            Grabar();

            if (this.ckAvisaCliente.Checked == true)
            {
                MandarEmail();
            }


            Cursor.Current = Cursors.Default;

            this.Close();
        }
        private void MandarEmail()
        {
            funciones_envio_emails fee = new funciones_envio_emails();
            //DNTablas_Gral lista = new DNTablas_Gral();
            //DataTable asunto_cuerpo;
            //string direcciones;
            //int intEvento;
            //string strAsunto;
            //string strCuerpo;
            //DataRow dr;
            //intEvento = (Int32)funciones_envio_emails.TipoArchivos.E_CAMBIO_NOMINACION  ;

            ////Con el Ultimo ingresado vamos a invocar el email para que lo envie por email.
            //var parameters = new[]
            //{
            //        new MySqlParameter(){ ParameterName="intEmpresa", Value = _Empresa },
            //        new MySqlParameter(){ ParameterName="intOT", Value = _OT },
            //        new MySqlParameter(){ ParameterName="intItemOT", Value = _Item },
            //        new MySqlParameter(){ ParameterName="intDestino", Value = 0 },
            //        new MySqlParameter(){ ParameterName="intEvento", Value = intEvento }
            //    };



            //asunto_cuerpo = lista.Get_Datos("SP_Emails_Sin_Conceptos", parameters);
            //if (asunto_cuerpo.Rows.Count > 0)
            //{
            //    dr = asunto_cuerpo.Rows[0];
            //    strAsunto = dr[0].ToString();
            //    strCuerpo = dr[1].ToString();
            //    //Armo las direcciones de email
            //    funciones_envio_emails e = new funciones_envio_emails();

            //    direcciones = e.armar_Cadena_Emails(_Empresa, intEvento, _IdCliente);

            //    e.SendEmailWithOutlook(direcciones, strAsunto, strCuerpo, string.Empty);
            //}
            
            fee.Envio_Email_Cuadro_Control(_Empresa, _OT, _BLBooking, _IdCliente, _Item, 1, 1 , (Int32)funciones_envio_emails.TipoArchivos.E_NOMINACION, "lightblue");
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean Valida()
        {

            Boolean blnSenial = true;

            MessageBoxButtons button = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Error;

            if (this.cboTransportista.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Transportista válido ", "Error", button, icon);
                blnSenial = false;
            }
            else
            {
                if (Convert.ToInt32(this.lbl_Codigo_Transportista.Text) != Convert.ToInt32(this.cboTransportista.SelectedValue))
                {
                    if (this.cboTractores.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar un Tractor válido ", "Error", button, icon);
                        blnSenial = false;
                    }
                    else
                    {

                        if (this.cboChasis.SelectedIndex == -1)
                        {
                            MessageBox.Show("Debe seleccionar un Chasis válido ", "Error", button, icon);
                            blnSenial = false;
                        }
                        else
                        {

                            if (this.cboChoferes.SelectedIndex == -1)
                            {
                                MessageBox.Show("Debe seleccionar un Chofer válido ", "Error", button, icon);
                                blnSenial = false;
                            }
                            else
                            {
                                blnSenial = true;
                            }

                        }

                    }
                }

            }

            return blnSenial;

        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Estás por eliminar una Designación.¿Estas segura?", "Antención " + datos.g_lastName, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
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
            //int intNroOrden;
            try
            {



                cmdCommand.Parameters.Clear();
                cmdCommand.CommandText = "SP_Elimina_Nominacion";

                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intOT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intItem", MySqlDbType.Int32);


                cmdCommand.Parameters["intEmpresa"].Value = _Empresa;
                cmdCommand.Parameters["intOT"].Value = _OT;
                cmdCommand.Parameters["intItem"].Value = _Item;


                cmdCommand.ExecuteNonQuery();

                trsTransaccion.Commit();

                //tabla rq autorización.
                //quien autoriza? 
                //quien ve avisos.
                this.Close();

            }
            catch (Exception)
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

        private void Actualizar_Volver_a_Designados(object sender, EventArgs e)
        {
            string strMensaje = "¿Desea confirmar nuevas Fechas?";
            if (MessageBox.Show(strMensaje, "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
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
                cmdCommand.Parameters.Clear();
                cmdCommand.CommandText = "SP_Cambio_Fecha_Nominacion";

                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intNumero_OT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intItem", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("datFecha_Retiro", MySqlDbType.DateTime);
                cmdCommand.Parameters.Add("datFecha_Posicion", MySqlDbType.DateTime);
                cmdCommand.Parameters.Add("datHora_Posicion", MySqlDbType.String);

                cmdCommand.Parameters["intEmpresa"].Value = _Empresa;
                cmdCommand.Parameters["intNumero_OT"].Value = _OT;
                cmdCommand.Parameters["intItem"].Value = _Item;
                cmdCommand.Parameters["datFecha_Retiro"].Value = Convert.ToDateTime(this.datFechaRetiro.Text).ToString("yyyy-MM-dd");
                cmdCommand.Parameters["datFecha_Posicion"].Value = Convert.ToDateTime(this.datFechaPosic.Text).ToString("yyyy-MM-dd");
                cmdCommand.Parameters["datHora_Posicion"].Value = this.cboHoraPosicion.Text; 

                cmdCommand.ExecuteNonQuery();

                trsTransaccion.Commit();

                this.Close();
            }
            catch (Exception)
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
        private void Bloquea_Asignar(string Leyenda)
        {
            this.lblBlackList.Text = lblLeyenda;
            this.lblBlackList.Text = this.lblBlackList.Text.Replace("XXX", Leyenda);

            if (IsBlackList)
            {
                this.btnAsignar.Enabled = false;
                Timer_Parpadeo.Interval = 1000;
                Timer_Parpadeo.Start();
            }
            else
            {
                this.btnAsignar.Enabled = true;
            }
        }
        private void CboTractores_SelectedValueChanged(object sender, EventArgs e)
        {

            funciones_Varias fv = new funciones_Varias();

            if (this.cboTransportista.SelectedIndex != -1)
            {
                IsBlackList = fv.Valido_Black_List(this.cboTractores.Text,0);

                Bloquea_Asignar("LA PATENTE/DNI/CUIT  " + this.cboTractores.Text);

            }


        }
        private void cboChasis_SelectedValueChanged(object sender, EventArgs e)
        {

            funciones_Varias fv = new funciones_Varias();

            if (this.cboTransportista.SelectedIndex != -1)
            {
                IsBlackList = fv.Valido_Black_List(this.cboChasis.Text,0);

                Bloquea_Asignar("LA PATENTE/DNI/CUIT  " + this.cboChasis.Text);

            }
        }

        private void cboChoferes_SelectedValueChanged(object sender, EventArgs e)
        {
            funciones_Varias fv = new funciones_Varias();
            DataTable dt;
            string strParam;
            if (this.cboTransportista.SelectedIndex != -1)
            {

                dt = (DataTable)this.cboChoferes.DataSource;
                strParam = dt.Rows[0][2].ToString();

                IsBlackList = fv.Valido_Black_List(strParam,0);

                Bloquea_Asignar("LA PATENTE/DNI/CUIT  " + strParam);


            }
        }

        private void Timer_Parpadeo_Tick(object sender, EventArgs e)
        {
            this.lblBlackList.Visible = true;
            intRepeticiones += 1;
            if (intFlag == 0)
            {
                lblBlackList.BackColor = Color.Red;
                intFlag = 1;
            }
            else
            {
                intFlag = 0;
                lblBlackList.BackColor = Color.Blue;
            }
            if (intRepeticiones == 10)
            {
                Timer_Parpadeo.Stop();
                intRepeticiones = 0;
                this.lblBlackList.Visible = false;
                this.Close();
            }
        }

        private void datFechaRetiro_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cboTransportista_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.groupBox1.Enabled = false;
        }

        private void lbl_Nombre_Chasis_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblRazonSocial_Click(object sender, EventArgs e)
        {

        }

        private void lblFechaRet_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void datFechaPosic_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void lbl_Nombre_Transportista_Click(object sender, EventArgs e)
        {

        }
    }

}
