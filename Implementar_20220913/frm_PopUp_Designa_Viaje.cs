using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using k_negocio_00;
using MySql.Data.MySqlClient;
using k_mysql;

namespace k_presentacion_00
{
    public partial class frm_PopUp_Designa_Viaje : Form
    {
        bool IsBlackList = false;
        int intFlag = 0;
        int intRepeticiones=0;
        string lblLeyenda = "XXX SE ENCUENTRA BLOQUEADO PARA REALIZAR VIAJES. COMUNICARSE CON MAXIMILIANO RUATA.";
        public int _Empresa { get; set; }
        public int _OT { get; set; }
        public int _Item { get; set; }
        public int _Corredor { get; set; }
        public Decimal _Costo { get; set; }
        public string _Descripcion_Item { get; set; }
        public int _IdCliente { get; set; }

        public int _IndTipo { get; set; }
        public string _strBooking { get; set; }

        guardar_datos_login datos = guardar_datos_login.Instance();

        public frm_PopUp_Designa_Viaje()
        {
            InitializeComponent();
            funciones_Varias fv = new funciones_Varias();
            fv.ColorearGradientPanel(this, this.Panel);
        }

        private void Frm_PopUp_Designa_Viaje_Load(object sender, EventArgs e)
        {

            Inicia();

        }

        private void Inicia()
        {

            this.lblOT.Text = string.Empty;
            this.lblDescripcion_Item.Text = string.Empty;
            this.lblCostoEmpresa.Text = string.Empty;
            this.lblCostoProveedor.Text = string.Empty;
            this.lblBooking.Text = string.Empty;

            this.lblOT.Text =  _OT.ToString().PadLeft(4, '0');
            this.lblItem.Text = _Item.ToString().PadLeft(4, '0');

            this.lblDescripcion_Item.Text = _Descripcion_Item.ToString();
            this.lblCostoEmpresa.Text =  _Costo.ToString();
            this.lblCostoProveedor.Text = "0,00";

            this.lblBooking.Text = _strBooking;

            Cursor.Current = Cursors.WaitCursor;

            Carga_Combo_Transportistas();

            Carga_Si_Requiere_Moro();

            Cursor.Current = Cursors.Default;
            IsBlackList = false;
        }
        private void Carga_Si_Requiere_Moro()
        {
            funciones_Varias o = new funciones_Varias();

            int intEsMoro;
            intEsMoro = o.Carga_Si_Requiere_Moro(datos.g_idEmpresa, _OT, _Item);
            this.lblEsMoro.Text = intEsMoro.ToString();

            //DNTablas_Gral lista = new DNTablas_Gral();

            //var parameters = new[]
            //{
            //    new MySqlParameter(){ ParameterName="intEmpresa", Value = datos.g_idEmpresa },
            //    new MySqlParameter(){ ParameterName="intOT", Value = _OT },
            //    new MySqlParameter(){ ParameterName="intItem", Value = _Item },
            //};

            //DataTable p;
            //DataRow row;

            //Application.DoEvents();
            //Cursor.Current = Cursors.WaitCursor;

            //p = lista.Get_Datos("SP_OT_Item_Es_Moro", parameters);
            //this.lblEsMoro.Text = "0";
            //if (p.Rows.Count>0)
            //{
            //    row = p.Rows[0];
            //    if (row["EsMoro"].ToString()=="1")
            //    {
            //        this.lblEsMoro.Text = "1";
            //    }
            //    else
            //    {
            //        this.lblEsMoro.Text = "0";
            //    }
            //}


            Cursor.Current = Cursors.Default;
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

            p = lista.Get_Transportistas("sp_Proveedores_A_Designar", parameters);

            this.cboTransportista.SelectedValueChanged -= new EventHandler(this.CboTransportista_SelectedValueChanged);

            o.CargarComboDataTable(this.cboTransportista, p, "id", "Descripcion", false,true,true, false);

            this.cboTransportista.SelectedValueChanged += new EventHandler(this.CboTransportista_SelectedValueChanged);

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

            o.CargarComboDataTable(this.cboTractores, p, "id", "Patente", false, false,true,false);

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

            o.CargarComboDataTable(this.cboChasis, p, "id", "Patente", false, false,true, false);

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

            o.CargarComboDataTable(this.cboChoferes, p, "IdChofer", "Apellido", false, false, true, false);

        }

        private void CboTransportista_SelectedValueChanged(object sender, EventArgs e)
        {
            int intTransportista = 0;
            
            //this.cboChoferes.SelectedValueChanged -= new System.EventHandler(this.cboChoferes_SelectedValueChanged);

            if (this.cboTransportista.SelectedIndex != -1)
            {
                DataTable dt;
                //string strParam;
                //funciones_Varias fv = new funciones_Varias();

                this.cboTractores.SelectedValueChanged -= new System.EventHandler(this.CboTractores_SelectedValueChanged);
                this.cboChasis.SelectedValueChanged -= new System.EventHandler(this.cboChasis_SelectedValueChanged);
                this.cboChoferes.SelectedValueChanged -= new System.EventHandler(this.cboChoferes_SelectedValueChanged);

                intTransportista = (int)this.cboTransportista.SelectedValue;


                //dt = (DataTable)this.cboTransportista.DataSource;
                //DataRow[] rows = dt.Select("id = " + this.cboTransportista.SelectedValue);
                //DataRow row = rows[2];

                //IsBlackList = fv.Valido_Black_List(row.ToString());

                //Bloquea_Asignar("LA PATENTE/DNI/CUIT  " + row.ToString());

                Carga_Combo_Tractores(_Empresa, intTransportista);

                Carga_Combo_Chasis(_Empresa, intTransportista);

                Carga_Combo_Choferes(intTransportista);

                this.cboTractores.SelectedValueChanged += new System.EventHandler(this.CboTractores_SelectedValueChanged);
                this.cboChasis.SelectedValueChanged += new System.EventHandler(this.cboChasis_SelectedValueChanged);
                this.cboChoferes.SelectedValueChanged += new System.EventHandler(this.cboChoferes_SelectedValueChanged);

                
                dt = (DataTable)this.cboTransportista.DataSource;
                DataRow[] Busco_Dato;
                Busco_Dato = dt.Select("id=" + (Int32)this.cboTransportista.SelectedValue);
                if (Busco_Dato.Count() > 0)
                {
                    this.lblCostoProveedor.Text = Busco_Dato[0][2].ToString();
                    decimal cTransportista;
                    decimal cEmpresa;
                    decimal cDiferencia;
                    //
                    
                    this.lblRealizaMoro.Text= Busco_Dato[0][3].ToString();
                    //
                    cTransportista = Convert.ToDecimal(this.lblCostoProveedor.Text);
                    cEmpresa = Convert.ToDecimal(this.lblCostoEmpresa.Text);
                    cDiferencia = cEmpresa - cTransportista;
                    if (cDiferencia <= 0)
                    {
                        this.lbl_Aviso_Autorizacion.Visible = true;
                        this.Tag = "REQ";
                    }
                    else
                    {
                        this.lbl_Aviso_Autorizacion.Visible = false;
                        this.Tag = "OK";
                    }
                    
                    return;
                }
                else
                {
                    this.lbl_Titulo_Costo_Transportista.Text = "0.00";
                    
                    return;
                }

            }


        }

        private void CboTractores_SelectedValueChanged(object sender, EventArgs e)
        {
            
            int intTransportista = 0;

            if (this.cboTransportista.SelectedIndex != -1)
            {

                intTransportista = (int)this.cboTransportista.SelectedValue;
                funciones_Varias fv = new funciones_Varias();
                IsBlackList= fv.Valido_Black_List(this.cboTractores.Text,0);

                Bloquea_Asignar("LA PATENTE/DNI/CUIT  " + this.cboTractores.Text);

               
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
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Grabar()
        {

            clsConn cnMarco = new clsConn();

            String strConnection_String = "";

            strConnection_String = cnMarco.Cadena_Conexion();

            MySqlConnection cnnConnection = new MySqlConnection(strConnection_String);
            cnnConnection.Open();

            MySqlCommand cmdCommand = cnnConnection.CreateCommand();
            MySqlTransaction trsTransaccion;

            int intTransportista = 0;
            int intTractor = 0;
            int intChasis = 0;
            int intChofer = 0;

            if (this.cboTransportista.SelectedIndex != -1)
            {
                intTransportista = int.Parse(this.cboTransportista.SelectedValue.ToString());
            }

            if (this.cboTractores.SelectedIndex != -1)
            {
                intTractor = int.Parse(this.cboTractores.SelectedValue.ToString());
            }

            if (this.cboChasis.SelectedIndex != -1)
            {
                intChasis = int.Parse(this.cboChasis.SelectedValue.ToString());
            }

            if (this.cboChoferes.SelectedIndex != -1)
            {
                intChofer = int.Parse(this.cboChoferes.SelectedValue.ToString());
            }

            trsTransaccion = cnnConnection.BeginTransaction();

            cmdCommand.Connection = cnnConnection;
            cmdCommand.Transaction = trsTransaccion;
            cmdCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                cmdCommand.CommandText = "SP_OT_Item_Nomina";

                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intOT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intItem", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intTransportista", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intTractor", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intChasis", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intChofer", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("decCosto", MySqlDbType.Decimal);
                cmdCommand.Parameters.Add("intAutoriza", MySqlDbType.Int32 );

                cmdCommand.Parameters["intEmpresa"].Value = _Empresa;
                cmdCommand.Parameters["intOT"].Value = _OT;
                cmdCommand.Parameters["intItem"].Value = _Item;
                cmdCommand.Parameters["intTransportista"].Value = intTransportista;
                cmdCommand.Parameters["intTractor"].Value = intTractor;
                cmdCommand.Parameters["intChasis"].Value = intChasis;
                cmdCommand.Parameters["intChofer"].Value = intChofer;
                cmdCommand.Parameters["decCosto"].Value = this.lblCostoProveedor.Text;// _Costo;
                if (this.Tag.ToString() == "OK")
                {
                    cmdCommand.Parameters["intAutoriza"].Value = 0;
                }
                else
                {
                    cmdCommand.Parameters["intAutoriza"].Value = 1;
                }
                

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

            if ( !Valida() ) { return; }

            Cursor.Current = Cursors.WaitCursor;

            Grabar();
            //MandarEmail();
            //MandarCuadro_Control();
            Cursor.Current = Cursors.Default;

            this.Close();
        }
        private void MandarCuadro_Control()
        {
            funciones_envio_emails fee = new funciones_envio_emails();
            fee.Envio_Email_Cuadro_Control(_Empresa, _OT, _strBooking, _IdCliente, 0,0,0, (Int32)funciones_envio_emails.TipoArchivos.E_NOMINACION,"lightblue");//paso 0 en itemot para que el SP no tome un item especifico
        }
        private void MandarEmail()
        {
            funciones_envio_emails fee = new funciones_envio_emails();
            DNTablas_Gral lista = new DNTablas_Gral();
            DataTable asunto_cuerpo;
            string direcciones;
            int intEvento;
            string strAsunto;
            string strCuerpo;
            DataRow dr;
            intEvento = (Int32)funciones_envio_emails.TipoArchivos.E_NOMINACION ;

            //Con el Ultimo ingresado vamos a invocar el email para que lo envie por email.
            var parameters = new[]
            {
                    new MySqlParameter(){ ParameterName="intEmpresa", Value = _Empresa },
                    new MySqlParameter(){ ParameterName="intOT", Value = _OT },
                    new MySqlParameter(){ ParameterName="intItemOT", Value = _Item },
                    new MySqlParameter(){ ParameterName="intDestino", Value = 0 },
                    new MySqlParameter(){ ParameterName="intEvento", Value = intEvento }
                };



            asunto_cuerpo = lista.Get_Datos("SP_Emails_Sin_Conceptos", parameters);
            if (asunto_cuerpo.Rows.Count > 0)
            {
                dr = asunto_cuerpo.Rows[0];
                strAsunto = dr[0].ToString();
                strCuerpo = dr[1].ToString();
                //Armo las direcciones de email
                funciones_envio_emails e = new funciones_envio_emails();

                direcciones = e.armar_Cadena_Emails("SP_Emails_Direcciones",_Empresa, intEvento, _IdCliente, "intCliente");

                e.SendEmailWithOutlook(direcciones, strAsunto, strCuerpo, string.Empty,false);
            }
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean Valida()
        {

            Boolean blnSenial = false;

            MessageBoxButtons button = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Error;

            if (this.cboTransportista.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Transportista válido ", "Error", button, icon);
            }
            else
                {

                if (this.cboTractores.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un Tractor válido ", "Error", button, icon);
                }
                else
                {

                    if (this.cboChasis.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar un Chasis válido ", "Error", button, icon);
                    }
                    else
                    {

                        if (this.cboChoferes.SelectedIndex == -1)
                        {
                            MessageBox.Show("Debe seleccionar un Chofer válido ", "Error", button, icon);
                        }
                        else
                        {
                            if ((this.lblEsMoro.Text == "1") && (this.lblRealizaMoro.Text == "0"))
                            {
                                MessageBox.Show("El viajes esta Marcado como ESPECIAL. Solo puede viajar un TRANSPORTISTA que realice viajes ESPECIALES");
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

        private void Timer_Parpadeo_Tick(object sender, EventArgs e)
        {
            this.lblBlackList.Visible = true;
            intRepeticiones += 1;
            if (intFlag==0)
            {
                lblBlackList.BackColor = Color.Red;
                intFlag = 1;
            }
            else
            {
                intFlag = 0;
                lblBlackList.BackColor = Color.Blue;
            }
            if (intRepeticiones==10)
            {
                Timer_Parpadeo.Stop();
                intRepeticiones = 0;
                this.lblBlackList.Visible = false;
                this.Close();
            }

        }

        private void cboChasis_SelectedValueChanged(object sender, EventArgs e)
        {

            funciones_Varias fv = new funciones_Varias();
            IsBlackList = fv.Valido_Black_List(this.cboChasis.Text,0);

            Bloquea_Asignar("LA PATENTE/DNI/CUIT  " + this.cboTractores.Text);
        }

        private void cboChoferes_SelectedValueChanged(object sender, EventArgs e)
        {
            funciones_Varias fv = new funciones_Varias();
            DataTable dt;

            if (this.cboTransportista.SelectedIndex != -1)
            {

                dt = (DataTable)this.cboChoferes.DataSource;
                DataRow[] rows = dt.Select("idChofer = " + this.cboChoferes.SelectedValue);
                DataRow row = rows[0];

                IsBlackList = fv.Valido_Black_List(row.ToString(),0);

                Bloquea_Asignar("LA PATENTE/DNI/CUIT  " + row.ToString());
                

            }
        }
    }

}
