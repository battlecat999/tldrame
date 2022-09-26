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
using MySql.Data;
using MySql.Data.Types;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using VB = Microsoft.VisualBasic;
using System.Drawing.Text;
using k_mysql;

namespace k_presentacion_00
{
    public partial class frm_Comerciales_Alta_Presupuestos : Form

    {

        bool esNuevo = true;


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wpara, int lparam);

       
        guardar_datos_login datos = guardar_datos_login.Instance();
        

        System.Data.DataSet _dsOTs = new System.Data.DataSet("OTs");
        BindingSource _bindingSource = new BindingSource();

        DataSet _dtItems = new DataSet();

        public frm_Comerciales_Alta_Presupuestos()
        {
            InitializeComponent();

            funciones_Varias fv = new funciones_Varias();

            //fv.formatColorForm(this);
            
            this.cboRazonSocial.SelectedIndexChanged-=new System.EventHandler(cboRazonSocial_SelectedIndexChanged);
            this.lblUsuario.Text = datos.g_idUser + " " + datos.g_lastName;
            this.cboPresupuesto.SelectedIndexChanged -= new System.EventHandler(cboPresupuesto_SelectedIndexChanged);
            this.cboTipoServicio.SelectedIndexChanged -= new System.EventHandler(cboTipoServicio_SelectedIndexChanged);
            this.cboModalidad.SelectedIndexChanged -= new System.EventHandler(cboModalidad_SelectedIndexChanged);
            this.cboRutas.SelectedIndexChanged -= new System.EventHandler(cboRutas_SelectedIndexChanged);
            this.cboCondicionPago.SelectedIndexChanged -= new System.EventHandler(cboCondicionPago_SelectedIndexChanged);
            this.cboVendedores.SelectedIndexChanged -= new System.EventHandler(cboVendedores_SelectedIndexChanged);
            this.cboMercaderias.SelectedIndexChanged -= new System.EventHandler(cboMercaderia_SelectedIndexChanged);
            this.cboDuracion.SelectedIndexChanged -= new System.EventHandler(cboDuracion_SelectedIndexChanged);


            //Cargamos los combos
            inicio();


            cargarcombos();

            //iniciarGrilla();

            this.cboPresupuesto.SelectedIndexChanged += new System.EventHandler(cboPresupuesto_SelectedIndexChanged);
            this.cboTipoServicio.SelectedIndexChanged += new System.EventHandler(cboTipoServicio_SelectedIndexChanged);
            this.cboRutas.SelectedIndexChanged += new System.EventHandler(cboRutas_SelectedIndexChanged);
            this.cboCondicionPago.SelectedIndexChanged += new System.EventHandler(cboCondicionPago_SelectedIndexChanged);
            this.cboVendedores.SelectedIndexChanged += new System.EventHandler(cboVendedores_SelectedIndexChanged);
            this.cboMercaderias.SelectedIndexChanged += new System.EventHandler(cboMercaderia_SelectedIndexChanged);
            this.cboDuracion.SelectedIndexChanged += new System.EventHandler(cboDuracion_SelectedIndexChanged);
            this.cboModalidad.SelectedIndexChanged += new System.EventHandler(cboModalidad_SelectedIndexChanged);
            this.cboRazonSocial.SelectedIndexChanged +=  new System.EventHandler(cboRazonSocial_SelectedIndexChanged);
        }
        //private void iniciarGrilla()
        //{

        //    funciones_Varias fv = new funciones_Varias();
        //    //fv.PrepararDG(this.dgw, 590, 105, 50, 575);
        //    DN_ABM o = new DN_ABM();
        //    DN_Cotizaciones c = new DN_Cotizaciones();
        //    DataTable d = new DataTable();
        //    DataTable dtC = new DataTable();
        //    DataTable dtG = new DataTable();
        //    string codPresu;
        //    if (this.cboPresupuesto.Text.ToString()==string.Empty)
        //    {
        //        codPresu = "0";
        //    }
        //    else
        //    {
        //        codPresu = this.cboPresupuesto.Text;
        //    }

        //    d = c.DN_Traer_Cotizaciones ("SP_Cotizaciones_Items_ID",codPresu , datos.g_idEmpresa);
        //    dtC = o.DN_Traer_DataTable("SP_GET_Contenedores_ALL", 0 , datos.g_idEmpresa);
        //    dtG = o.DN_Traer_DataTable("SP_GET_Generadores_ALL", 0, datos.g_idEmpresa);
        //    this.dgw.Columns.Clear();

        //    this.dgw.AutoGenerateColumns = false;

        //    DataGridViewTextBoxColumn colCotizacion = new DataGridViewTextBoxColumn();
        //    colCotizacion.Visible = false;
        //    colCotizacion.HeaderText = "N";
        //    colCotizacion.Name = "colCotizacion";
        //    colCotizacion.DataPropertyName = "idCotizacion";
        //    this.dgw.Columns.Add(colCotizacion);

        //    DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
        //    colItem.Visible = true;
        //    colItem.Width = 100;
        //    colItem.HeaderText = "Items";
        //    colItem.Name = "colItems";
        //    colItem.DataPropertyName = "Item";
        //    this.dgw.Columns.Add(colItem);

        //    DataGridViewComboBoxColumn colContenedores = new DataGridViewComboBoxColumn();

        //    colContenedores.DataSource = dtC;
        //    colContenedores.DisplayMember = "Descripcion";
        //    colContenedores.ValueMember = "Codigo_Contenedor";
        //    colContenedores.Visible = true;
        //    colContenedores.HeaderText = "Contenedor";
        //    colContenedores.Width = 300;
        //    colContenedores.Name = "colContenedores";
        //    colContenedores.DataPropertyName = "Contenedor";//Campo donde se guarda
        //    this.dgw.Columns.Add(colContenedores);

        //    DataGridViewComboBoxColumn colGeneradores = new DataGridViewComboBoxColumn();

        //    colGeneradores.DataSource = dtG;
        //    colGeneradores.DisplayMember = "descripcion";
        //    colGeneradores.ValueMember = "Codigo_Generador";
        //    colGeneradores.Visible = true;
        //    colGeneradores.HeaderText = "Generador";
        //    colGeneradores.Width = 300;
        //    colGeneradores.Name = "colGeneradores";
        //    colGeneradores.DataPropertyName = "Generadores";//Campo donde se guarda

        //    this.dgw.Columns.Add(colGeneradores);

        //    this.dgw.DataSource = d;
        //}
        private void cargarclientes()
        {
            funciones_Varias o = new funciones_Varias();
            DataTable r;
            DNTablas_Gral lista = new DNTablas_Gral();

            r = lista.DN_CargarDataTableGral("SP_Clientes_Get_All", 0, datos.g_idEmpresa);//u.DN_Clientes_Get(IsThe);
            o.CargarComboDataTable(this.cboRazonSocial, r, "id", "descripcion", false, true);

        }
        private void cboRazonSocial_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            cargarContactos();
            cargarcombos_rutas();
        }
        private void cargarContactos()
        {
            funciones_Varias o = new funciones_Varias();
            DataTable r;
            DN_ABM u = new DN_ABM();

            this.cboContactos.SelectedIndexChanged -= new System.EventHandler(cboContactos_SelectedIndexChanged);
            int idCliente;
            idCliente = Convert.ToInt32(this.cboRazonSocial.SelectedValue);

            r = u.DN_Contactos_Clientes_Por_Id("SP_Contactos_Clientes_Por_Id", datos.g_idEmpresa, idCliente, 1);
            o.CargarComboDataTable(this.cboContactos, r, "id", "descripcion", false, true);

            this.cboContactos.SelectedIndexChanged += new System.EventHandler(cboContactos_SelectedIndexChanged);
            //

        }
        private void inicio()
        {

            this.cboRazonSocial.SelectedIndexChanged -= new System.EventHandler(cboRazonSocial_SelectedIndexChanged);
            
            

            limpiarControles();
            cargarPresupuestos();
            cargarclientes();
            this.cboRazonSocial.SelectedIndexChanged += new System.EventHandler(cboRazonSocial_SelectedIndexChanged);

        }
        private void limpiarControles()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType().Name.ToString() != "Button" && c.GetType().Name.ToString() != "Label")
                {
                    if (c.Name == "txtNewRazonSocial")
                    {
                        c.Text = string.Empty;
                    }
                    else
                    {
                        c.Text = String.Empty;
                    }

                }
            }
            esNuevo = true;
        }
        private void cargarPresupuestos()
        {

            DN_Cotizaciones c = new DN_Cotizaciones();

            //cargo el combo
            DNTablas_Gral lista = new DNTablas_Gral();

            DataTable p;
            funciones_Varias o = new funciones_Varias();

            this.cboPresupuesto.SelectedIndexChanged -= new System.EventHandler(cboPresupuesto_SelectedIndexChanged);


            p = lista.DN_CargarDataTableGral("SP_Cotizaciones_ALL",0,datos.g_idEmpresa);
            cboPresupuesto.DataSource = null;
            o.CargarComboDataTable(cboPresupuesto , p, "id", "descripcion", false, true);

            this.cboPresupuesto.SelectedIndexChanged += new System.EventHandler(cboPresupuesto_SelectedIndexChanged);

            c.DN_Traer_Nueva_Cotizacion("SP_Cotizaciones_Prox", datos.g_idEmpresa);
            this.cboPresupuesto.Text = c.Nueva_cotizacion;

            this.mFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //cargarMKP
            p = lista.DN_CargarDataTableGral("SP_MKP_Coef", 0, datos.g_idEmpresa);
            this.txtMKP.Text = Convert.ToDecimal(0).ToString("0.0000");
            if (p.Rows.Count > 0)
            {
                DataRow row = p.Rows[0];
                this.txtMKP.Text = Convert.ToDecimal (row[0]).ToString ();
             
            }

        }
        private void cargarcombos()
        {

            DNTablas_Gral lista = new DNTablas_Gral();

            DataTable p;
            funciones_Varias o = new funciones_Varias();

            var parameters = new[]
           {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = datos.g_idEmpresa},
                new MySqlParameter(){ ParameterName="intId", Value = 0},
                new MySqlParameter(){ ParameterName="intAccion", Value = 0}
            };


            p = lista.DN_CargarDataTableGral("SP_GET_Tipo_Servicios_ALL", 0, 0);
            o.CargarComboDataTable(cboTipoServicio, p, "id", "descripcion", false, true);

            p = lista.DN_CargarDataTableGral("SP_GET_Tipo_Modalidad_ALL", 0 ,datos.g_idEmpresa);
            o.CargarComboDataTable(cboModalidad , p, "Codigo_Modalidad", "Descripcion", false, true);

            p = lista.DN_CargarDataTableGral  ("SP_Condicion_de_Pago", 0, 0);
            o.CargarComboDataTable(cboCondicionPago , p, "id", "descripcion", false, true);
            this.cboCondicionPago.SelectedValue = 10;//COM+EFEC 

            p = lista.DN_CargarDataTableGral("SP_GET_Vendedores_ALL", 0, 0);
            o.CargarComboDataTable(cboVendedores, p, "id", "descripcion", false, true);

            p = lista.DN_CargarDataTableGral("SP_Duracion_Viajes", 0, 0);
            o.CargarComboDataTable(cboDuracion, p, "id", "descripcion", false, true);

            p = o.Carga_Contenedores(datos.g_idEmpresa);
            o.CargarComboDataTable(cboContenedores, p, "Codigo_Contenedor", "descripcion", false, true, false, false);

            p = lista.DN_CargarDataTableGral("SP_Cotizacion_Estados", 0, datos.g_idEmpresa );
            o.CargarComboDataTable(cboEstado, p, "Codigo_Estado", "Descripcion", false, true);
            this.cboEstado.SelectedValue = 1;//COM+EFEC 

            p = lista.Get_Datos("SP_Conceptos_Cotizaciones", parameters);
            o.CargarComboDataTable(cboItem, p, "Id", "Item", false, true, true, false);

            cargarcombo_Mercaderia();
            DN_ABM_TC l = new DN_ABM_TC();


        }

        //se hizo aparte para poder invocarlo luego de cargar una nueva mercadería.

        private void cargarcombo_Mercaderia()
        {
            DNTablas_Gral lista = new DNTablas_Gral();
            funciones_Varias o = new funciones_Varias();
            DataTable p;
            p = lista.DN_CargarDataTableGral("SP_GET_Mercaderias_ALL", 0,0);
            o.CargarComboDataTable(cboMercaderias, p, "Codigo_Mercaderia", "descripcion", false, true);
        }


        private void cargarcombos_rutas()
        {
            funciones_Varias o = new funciones_Varias();
            DN_ABM dn = new DN_ABM();
            DataTable r;
            DNTablas_Gral  u = new DNTablas_Gral ();
            this.cboRutas.SelectedIndexChanged -= new System.EventHandler(cboRutas_SelectedIndexChanged);

            int idCliente;
            idCliente = Convert.ToInt32(this.cboRazonSocial.SelectedValue);

            r = u.DN_CargarDataTableGral ("SP_ACC_Select", idCliente ,datos.g_idEmpresa );

            if(r.Rows.Count>0)
            {
                o.CargarComboDataTable(this.cboRutas, r, "id", "descripcion", false,false,false, true);
            }
            else
            {
                MessageBox.Show("No hay rutas asociadas a este cliente", "Atención", MessageBoxButtons.OK);
            }
            

            this.cboRutas.SelectedIndexChanged += new System.EventHandler(cboRutas_SelectedIndexChanged);
        }
        private void pClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frm_Comerciales_Alta_Presupuestos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void cboTipoServicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboDuracion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboContenedores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboVendedores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCondicionPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboRutas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DN_Corredores dc = new DN_Corredores();
            DataTable dt;
            dt = dc.Corredores_GET("SP_Corredores_Traer", Convert.ToInt32(this.cboRutas.SelectedValue), datos.g_idEmpresa);
            DataRow dr;
            dr = dt.Rows[0];
            this.txtCosto.Text = dr["Costo"].ToString();


        }

        private void cboMercaderia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cboMercaderias.SelectedValue)==0)
            {
                DNTablas_Gral   DN = new DNTablas_Gral();
                DN.Tabla = "mercaderias";
                DN.Descripcion  = this.cboMercaderias.Text.ToUpper();
                DN.DN_Grabar_Tabla_Gral ();
                cargarcombo_Mercaderia();

            }
        }

        private void cboContactos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmdUC_Click(object sender, EventArgs e)
        {
            cargarclientes();
        }

        private void cmdUCt_Click(object sender, EventArgs e)
        {
            cargarContactos();
        }

        private void cmdAC_Click(object sender, EventArgs e)
        {

            frm_abm_clientes ofrm = new frm_abm_clientes();
            ofrm.ShowDialog();
        }

        private void cmdACt_Click(object sender, EventArgs e)
        {

        }

        private void cboPresupuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codPresu;
            DataTable dt;
            //iniciarGrilla();
            DNTablas_Gral dn = new DNTablas_Gral();
            codPresu = 0;
            try
            {


                Int32.TryParse(this.cboPresupuesto.SelectedValue.ToString(), out codPresu);

                dt=dn.DN_CargarDataTableGral("SP_Cotizacion_Traer", codPresu , datos.g_idEmpresa);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr;
                    dr = dt.Rows[0];
                    this.cboRazonSocial.SelectedValue = dr["IdCliente"];
                    this.cboContactos.SelectedValue= dr["IdContacto"];
                    this.mFecha.Text = dr["Fecha"].ToString();
                    this.cboTipoServicio.SelectedValue = dr["TipoServicio"];
                    this.cboModalidad.SelectedValue = dr["TipoModalidad"];
                    this.cboRutas.SelectedValue = dr["IdCorredor"];
                    this.cboCondicionPago.SelectedValue = 0;// dr["IdCondicionPago"]; //MPS20200110
                    this.cboVendedores.SelectedValue = dr["IdVendedor"];
                    this.cboMercaderias.SelectedValue = dr["idMercaderia"];
                    this.cboDuracion.SelectedValue = dr["idDuracion"];
                    this.txtContedores.Text = dr["CantContenedores"].ToString();
                    this.txtPeso.Text = dr["PesoContenedores"].ToString();
                    this.txtCosto.Text = dr["CostoCorredor"].ToString();
                    this.txtMKP.Text = dr["MKP"].ToString();
                    this.txtVenta.Text = dr["ImporteVenta"].ToString();
                    this.txtObservacion.Text = dr["Observaciones"].ToString();

                    this.cboDuracion.SelectedValue = dr["IdDuracion"].ToString();
                    this.cboContenedores.SelectedValue = dr["IdContenedor"].ToString();
                    this.k_dias_Validez.Text = dr["diasValidez"].ToString();
                    this.txtEstadia.Text = dr["importeEstadia"].ToString();

                    this.mFechaVencimiento.Text= dr["FechaVencimiento"].ToString();
                    this.mFechaVigDesde.Text = dr["FechaVigenciaDesde"].ToString();

                    this.cboEstado.SelectedValue = dr["Estado"];
                    esNuevo = false;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }


        }

        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            //valido datos



            if (ValidoForm() == false)
            {
                MessageBox.Show("Corrija los campos marcados");
                return;
            }

            string qCab = string.Empty;
            string qDet = string.Empty;

            DateTime fecCot;
            DateTime fecVen;
            DateTime fecDes;
            if (!DateTime.TryParse(this.mFecha.Text, out fecCot))
            {
                MessageBox.Show("No se puede convertir a una fecha válida.");
                return;
            }

            if (!DateTime.TryParse(this.mFechaVigDesde.Text, out fecDes))
            {
                MessageBox.Show("No se puede convertir a una fecha válida.");
                return;
            }


            fecVen = fecDes.AddDays(Convert.ToInt32(this.k_dias_Validez.Text));

            string strSP_Cabecera;
            string str_NroCotizacion;

            if (esNuevo == true)
            {
                strSP_Cabecera = "SP_Cotizaciones_Insert";
                //strSP_Items = "SP_Cotizaciones_Items_Insert";
                str_NroCotizacion = "0";
            }
            else
            {
                strSP_Cabecera = "SP_Cotizaciones_update";
                //strSP_Items = "SP_Cotizaciones_Items_Update";
                str_NroCotizacion = this.cboPresupuesto.Text;
            }


            //(pIdEmpresa,pFecha,pFechaVencimiento,pTipoServicio,pIdCliente,pIdContacto,pIdVendedor,pIdMercaderia,pIdCorredor,pCostoCorredor,pImporteVenta,pIdCondicionPago,pMKP,pOneWay,pObservaciones,pEstado
            qCab = string.Empty;
            qCab = string.Concat(qCab, "CALL ", strSP_Cabecera, " (", datos.g_idEmpresa, ",'", str_NroCotizacion, "','", fecCot.ToString("yyyy-MM-dd"), "','", fecDes.ToString("yyyy-MM-dd"), "','", fecVen.ToString("yyyy-MM-dd"), "',", this.cboTipoServicio.SelectedValue, ",", this.cboModalidad.SelectedValue, ",");
            qCab = string.Concat(qCab, this.cboRazonSocial.SelectedValue, ",", this.cboContactos.SelectedValue, ",", this.cboVendedores.SelectedValue, ",", this.cboMercaderias.SelectedValue, ",");
            qCab = string.Concat(qCab, this.cboRutas.SelectedValue, ",", this.txtCosto.Text.Replace(",", "."), ",", this.txtVenta.Text.Replace(",", "."), ",", this.cboCondicionPago.SelectedValue, ",", this.txtMKP.Text.Replace(",", "."), ",0,'");
            qCab = string.Concat(qCab, this.txtObservacion.Text, "',", this.cboEstado.SelectedValue, ",", this.txtContedores.Text, ",", this.txtPeso.Text, ",", this.cboDuracion.SelectedValue, ",", this.cboContenedores.SelectedValue, ",", this.k_dias_Validez.Text, ",", this.txtEstadia.Text.Replace(",", "."), "); ");



            bool termino;
            DNTablas_Gral ej = new DNTablas_Gral();
            termino = ej.DN_Grabar_Cab_Detalle(qCab, qDet);

            //VARIABLES
            if ((Int32)this.cboEstado.SelectedValue == 2)
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

                //ACTUALIZAR LA RUTA
                cmdCommand.Parameters.Clear();
                cmdCommand.CommandText = "SP_Tarifas_Actualiza_Corredor";

                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intCorredor", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intUsuario", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("decCosto", MySqlDbType.Decimal);

                cmdCommand.Parameters["intEmpresa"].Value = datos.g_idEmpresa;
                cmdCommand.Parameters["intCorredor"].Value = this.cboRutas.SelectedValue;
                cmdCommand.Parameters["intUsuario"].Value = datos.g_idUser;
                cmdCommand.Parameters["decCosto"].Value = this.txtCosto.Text.Replace(",", ".");

                cmdCommand.ExecuteNonQuery();

                //ACTUALIZAR EL CLIENTE
                cmdCommand.Parameters.Clear();
                cmdCommand.CommandText = "SP_ACC_Insert";
                cmdCommand.Parameters.Add("pBaja", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("pIdEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("pId", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("pIdCorredor", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("pCosto", MySqlDbType.Decimal);
                cmdCommand.Parameters.Add("pIdUsuario", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("datFechaAlta", MySqlDbType.DateTime);

                cmdCommand.Parameters["pBaja"].Value = 1;
                cmdCommand.Parameters["pIdEmpresa"].Value = datos.g_idEmpresa;
                cmdCommand.Parameters["pId"].Value = this.cboRazonSocial.SelectedValue;
                cmdCommand.Parameters["pIdCorredor"].Value = this.cboRutas.SelectedValue;
                cmdCommand.Parameters["pCosto"].Value = this.txtVenta.Text;
                cmdCommand.Parameters["pIdUsuario"].Value = datos.g_idUser;
                cmdCommand.Parameters["datFechaAlta"].Value = fecCot.ToString("yyyy-MM-dd");

                cmdCommand.ExecuteNonQuery();

                //ACTUALIZAR EL PROVEEDOR

                cmdCommand.Parameters.Clear();
                cmdCommand.CommandText = "SP_Tarifas_Actualizacion_Proveedores";
                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intCorredor", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("decCosto", MySqlDbType.Decimal);
                cmdCommand.Parameters.Add("intUsuario", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("datFechaAlta", MySqlDbType.DateTime);

                cmdCommand.Parameters["intEmpresa"].Value = datos.g_idEmpresa;
                cmdCommand.Parameters["intCorredor"].Value = this.cboRutas.SelectedValue;
                cmdCommand.Parameters["decCosto"].Value = this.txtCosto.Text;
                cmdCommand.Parameters["intUsuario"].Value = datos.g_idUser;
                cmdCommand.Parameters["datFechaAlta"].Value = fecCot.ToString("yyyy-MM-dd");

                cmdCommand.ExecuteNonQuery();
                trsTransaccion.Commit();

                cnnConnection.Close();
            }

            if (termino == true)
            {
                //inicio();
                Limpiar_Completo();
            }
           


        }
        private bool  ValidoForm()
        {

            if (esNuevo == false)
            {
                if (this.cboPresupuesto.SelectedIndex == -1)
                {
                    MessageBox.Show("El combo no puede estar vacío", "Atención");
                    this.cboPresupuesto.Focus();
                    return false;
                }
            }

            if (this.cboRazonSocial.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboRazonSocial.Focus();
                return false;
            }
            if (this.cboContactos.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboContactos.Focus();
                return false;
            }
            if (this.cboTipoServicio.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboTipoServicio.Focus();
                return false;
            }
            if (this.cboModalidad.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboModalidad.Focus();
                return false;
            }
            if (this.cboCondicionPago.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboCondicionPago.Focus();
                return false;
            }
            if (this.cboVendedores.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboVendedores.Focus();
                return false;
            }

            if (this.cboMercaderias.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboVendedores.Focus();
                return false;
            }
            if (this.cboDuracion.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboVendedores.Focus();
                return false;
            }
            if (this.cboContenedores.SelectedIndex == -1)
            {
                MessageBox.Show("El combo CONTENEDORES no puede estar vacío", "Atención");
                this.cboVendedores.Focus();
                return false;
            }




            if (Convert.ToDecimal (this.txtCosto.Text)  == 0 || Convert.ToDecimal(this.txtCosto.Text)<0)
            {
                MessageBox.Show("El importe no puede ser cero ni negativo", "Atención");
                this.txtCosto.Focus();
                return false;
            }
            if (Convert.ToDecimal(this.txtVenta.Text) == 0 || Convert.ToDecimal(this.txtVenta.Text) < 0)
            {
                MessageBox.Show("El importe no puede ser cero ni negativo", "Atención");
                this.txtVenta.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(this.txtEstadia.Text) || Convert.ToDecimal(this.txtEstadia.Text) < 0)
            {
                MessageBox.Show("El importe de Estadia no puede ESTAR vacio ni ser de valor negativo", "Atención");
                this.txtCosto.Focus();
                return false;
            }
            funciones_Varias fv = new funciones_Varias();

            if (!fv.IsDate(this.mFecha.Text) || !fv.IsDate(this.mFechaVigDesde.Text) || !fv.IsDate(this.mFechaVencimiento.Text))
            {
                MessageBox.Show(datos.g_lastName.ToUpper()  +  " Una de las fechas que estas ingresando es INCORRECTA", "Atención");
                
                return false;
            }


            return true;

        }
        private void Dgw_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //e.Control.KeyPress += Validar;
            // Ignoramos otros tipos de controles existentes en las celdas
            // 
            if (e.Control is DataGridViewComboBoxEditingControl)
            {

                // Referenciamos el control TextBox subyacente en la celda actual.
                // 
                DataGridViewComboBoxEditingControl cellComboBox = e.Control as DataGridViewComboBoxEditingControl;

                // Primero eliminamos el controlador para el evento
                // SelectedValueChanged, y despu??s lo volvemos a instalar.
                // 
                cellComboBox.SelectedValueChanged -= SelectedValueChanged;

                cellComboBox.SelectedValueChanged += SelectedValueChanged;
            }
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                DataGridViewTextBoxEditingControl cellTextBox = e.Control as DataGridViewTextBoxEditingControl;

                //cellTextBox.LostFocus -= LostFocusText;

                //cellTextBox.LostFocus += LostFocusText;
            }
        }
        private void SelectedValueChanged(object sender, EventArgs e) 
        {
            // Referenciamos el control ComboBox
            // 
            //ComboBox combo = (ComboBox)sender;
            //try
            //{
            //    if (combo.SelectedIndex != -1)
            //    {
            //        DataTable dt = (DataTable)this.dgw.DataSource;
            //        if (combo.Text != "System.Data.DataRowView")
            //        {
            //            string[] tmp = new string[] { datos.g_idEmpresa.ToString(), this.cboPresupuesto.Text, "1", combo.SelectedValue.ToString(),"0" };

            //            this.dgw[0, this.dgw.CurrentRow.Index].Value = datos.g_idEmpresa;
            //            this.dgw[1, this.dgw.CurrentRow.Index].Value = this.cboPresupuesto.Text.ToString();
            //            this.dgw[2, this.dgw.CurrentRow.Index].Value = 1;
            //            if (combo.Name == "colContenedores")
            //            {
            //                this.dgw[3, this.dgw.CurrentRow.Index].Value = combo.SelectedValue;
            //            }
            //            else
            //            {
            //                this.dgw[4, this.dgw.CurrentRow.Index].Value = combo.SelectedValue;
            //            }
                        
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
        }

        private void Dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Frm_Comerciales_Alta_Presupuestos_Load(object sender, EventArgs e)
        {

        }
    private void ENTER_KeyPress(object sender, KeyPressEventArgs e)
    {
         if (e.KeyChar == (char) (Keys.Enter))
        {
            e.Handled = true;





                SendKeys.Send("{TAB}");
        }
    }

        private void TxtMKP_Leave(object sender, EventArgs e)
        {

            //decimal dCosto = Convert.ToDecimal(this.txtCosto.Text.Replace(".",","));
            //decimal dMKP = Convert.ToDecimal(this.txtMKP.Text.Replace(".", ",")); ;
            //decimal dVenta = 0;

            //dVenta = dCosto * dMKP;

            //this.txtVenta.Text = Math.Round(dVenta, 2).ToString();
        }

        private void TxtCosto_Leave(object sender, EventArgs e)
        {
            this.txtCosto.Text = Convert.ToDecimal(this.txtCosto.Text.Replace(".", ",")).ToString();
        }



        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            //inicio();
            Limpiar_Completo();
        }
        private void Limpiar_Completo()
        {
            frm_Comerciales_Alta_Presupuestos frm = new frm_Comerciales_Alta_Presupuestos();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.Show();
            this.Close();
        }
        private void cboModalidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtVenta_Leave(object sender, EventArgs e)
        {
            decimal dCosto = Convert.ToDecimal(this.txtCosto.Text.Replace(".", ","));
            decimal dMKP;
            decimal dVenta = Convert.ToDecimal(this.txtVenta.Text.Replace(".", ",")); ;

            //MPS 2022-06-27
            //if (dCosto>=dVenta)
            //{
            //    MessageBox.Show("Estas Cargando un valor incorrecto de venta", "Atención",MessageBoxButtons.OK );
            //    this.txtCosto.Focus();
            //    return;
            //}

            dMKP = dVenta / dCosto;

            this.txtMKP.Text = Math.Round(dMKP, 2).ToString();
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            //funciones_Varias f = new funciones_Varias();
            //int[] ProcesosAntes;
            //int[] ProcesosDespues;
            //int PID;

            //ProcesosAntes = f.ListarProcesosAntes("EXCEL");


            //Excel.Application Mi_Excel = new Excel.Application();
            //Excel._Workbook librosTrabajo;
            //Excel._Worksheet hojaTrabajo;
            //string ExcelFile = @"C:\Sistema_Gestion\Transferencia\Prueba.xlsx";

            //librosTrabajo = Mi_Excel.Workbooks.Add(ExcelFile);
            //hojaTrabajo = (Excel._Worksheet)librosTrabajo.ActiveSheet;
            //hojaTrabajo.Range["A1"].Value = "Prueba";
            //Mi_Excel.UserControl = true;
            //librosTrabajo.Save();
            //hojaTrabajo.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, ExcelFile);

            //Mi_Excel.ActiveWorkbook.Close(true, ExcelFile, Type.Missing);

            //Mi_Excel.Quit();
            //Mi_Excel = null;

            //ProcesosDespues = f.ListarProcesosDespues("EXCEL");
            //PID = f.ListarProcesoNuevo(ProcesosAntes, ProcesosDespues);
            //f.DescargarProceso(PID);
            try
            {


            funciones_envio_emails fee = new funciones_envio_emails();
            int intTipoEvento;
            intTipoEvento = (Int32)funciones_envio_emails.TipoArchivos.E_COTI;
            fee.Envio_Email_Cotizacion(datos.g_idEmpresa, (Int32)this.cboRazonSocial.SelectedValue, this.cboPresupuesto.Text, intTipoEvento);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void cboRazonSocial_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.k_dias_Validez.Text )|| this.k_dias_Validez.Text == "")
            {
                this.k_dias_Validez.Text = "30";
            }
            this.mFechaVigDesde.Text = this.mFecha.Text;
            this.mFechaVencimiento.Text = Convert.ToDateTime(this.mFechaVigDesde.Text).AddDays(Convert.ToInt32(this.k_dias_Validez.Text)).ToShortDateString();
        }

        private void k_dias_Validez_Leave(object sender, EventArgs e)
        {
            Calcular_Fecha_Vencimiento();
        }
        private void Calcular_Fecha_Vencimiento()
        {

            int var_Dias;
            var_Dias = Convert.ToInt32(this.k_dias_Validez.Text);
            if (var_Dias==0)
            {
                this.mFechaVencimiento.Focus();
            }
            else
            {
                this.mFechaVencimiento.Text = VB.DateAndTime.DateAdd(VB.DateInterval.Day, var_Dias, Convert.ToDateTime(this.mFechaVigDesde.Text)).ToString();
            }
        }

        private void mFechaVencimiento_Leave(object sender, EventArgs e)
        {
            this.k_dias_Validez.Text = VB.DateAndTime.DateDiff(VB.DateInterval.Day, Convert.ToDateTime(this.mFechaVigDesde.Text), Convert.ToDateTime(this.mFechaVencimiento.Text)).ToString();
            this.cboDuracion.Focus();

        }

        private void mFechaVigDesde_Leave(object sender, EventArgs e)
        {
            Calcular_Fecha_Vencimiento();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboContenedores_SelectedIndexChanged_1(object sender, EventArgs e)
        {
                
        }



        private void Cargamos_Grilla()
        {

            //funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            int intEmpresa = datos.g_idEmpresa;  //POR AHORA!

            //int intNumero_OT = 0;

            //if (!_blnAlta)
            //{
            //    intNumero_OT = Convert.ToInt32(this.txtNumero_OT.Text.ToString());
            //}



            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = datos.g_idEmpresa},
                new MySqlParameter(){ ParameterName="intId", Value = this.cboItem.SelectedValue},
                new MySqlParameter(){ ParameterName="intAccion", Value = 0}

                //new MySqlParameter(){ ParameterName="intTransportista", Value = intTransportista },
                //new MySqlParameter(){ ParameterName="intTractor", Value = intTractor },
                //new MySqlParameter(){ ParameterName="intChasis", Value = intChasis },
                //new MySqlParameter(){ ParameterName="intChofer", Value = intChofer },
                //new MySqlParameter(){ ParameterName="intItem", Value = _Item }
            };


            DataTable dtItems;

            dtItems = lista.Get_Datos("SP_Conceptos_Cotizaciones", parameters);

            if (_dtItems.Tables.Count > 0)
            {
                _dtItems.Tables.RemoveAt(0);
            }

            _dtItems.Tables.Add(dtItems);

            //grdViajes.DataSource = dtItems;
            dg.DataSource = _dtItems.Tables[0];


            //this.btnAgregar.Enabled = true;
            //this.dg.Enabled = true;
            //this.lblAviso.Visible = false;
            //foreach (DataRow dr in dtItems.Rows)
            //{
            //    //if (dr["Numero_Contenedor"].ToString()!=string.Empty)
            //    //{
            //    //    this.btnAgregar.Enabled = false;
            //    //    this.dg.Enabled = false;
            //    //}
            //    if (dr["TieneFactura"].ToString() == "0")
            //    {
            //        this.btnAgregar.Enabled = false;
            //        this.dg.Enabled = false;
            //        this.lblAviso.Visible = true;
            //    }
            //}

        }
        private void configuraGrilla()
        {
            //DataGridViewColumn colIdEmpresa = new DataGridViewTextBoxColumn();
            //DataGridViewColumn colIdCotizacion = new DataGridViewTextBoxColumn();
            //DataGridViewComboBoxColumn colId = new DataGridViewComboBoxColumn();
            //DataGridViewColumn colItem = new DataGridViewTextBoxColumn();
            //DataGridViewColumn colDescripcion = new DataGridViewTextBoxColumn();

            //dg.AutoGenerateColumns = false;






        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Cargamos_Grilla();
            DataRow rd = _dtItems.Tables[0].NewRow();


            rd["Id"] = this.cboItem.SelectedIndex;
            rd["Item"] = this.cboItem.SelectedValue;
           
            _dtItems.Tables[0].Rows.Add(rd);
            //dg.DataSource = _dtItems.Tables[0];

        }






    }
}
