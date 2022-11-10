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
using System.Text.RegularExpressions;
using k_mysql;
using System.Data.SqlClient;

namespace k_presentacion_00
{


    public partial class frm_Comerciales_OT : Form
    {
        guardar_datos_login datos = guardar_datos_login.Instance();

        System.Data.DataSet _dsOTs = new System.Data.DataSet("OTs");
        BindingSource _bindingSource = new BindingSource();

        DataSet _dtItems = new DataSet();

        public Boolean _blnAlta { get; set; }
        public Boolean _blnVerTodo {get; set; }
        public frm_Comerciales_OT()
        {
            InitializeComponent();
        }
        private void cargarclientes()
            {
                funciones_Varias o = new funciones_Varias();
                DataTable r;
                DNTablas_Gral lista = new DNTablas_Gral();

            this.cboRazonSocial.SelectedIndexChanged -= new System.EventHandler(cboRazonSocial_SelectedIndexChanged);


            r = lista.DN_CargarDataTableGral("SP_Clientes_Get_All", 0, datos.g_idEmpresa);
                o.CargarComboDataTable(this.cboRazonSocial, r, "id", "descripcion", false, true,false,false);

            this.cboRazonSocial.SelectedIndexChanged += new System.EventHandler(cboRazonSocial_SelectedIndexChanged);

        }
        private void Iniciar()
        {
            Limpiar_Controles();
            cargarclientes();

            cargarCombos();

            cargarComboHoras(this.cboHoraCutOffDoc);
            cargarComboHoras(this.cboHoraCutOffDocExt);
            cargarComboHoras(this.cboHoraCutOffFis);
            cargarComboHoras(this.cboHoraCutOffFisExt);

            Carga_Combo_Terminales_Entrega();
            Carga_Combo_Terminales_Retiro();

            Carga_Combo_Modalidades();

            Configura_Grilla();

            //_dsOTs.Tables.Add(Carga_Ots());

            _blnAlta = true;
            _blnVerTodo = true;

        }

        private void Configura_Grilla()
        {


            //https://stackoverflow.com/questions/45498268/dataset-and-combobox-of-datagridview
            //var colCuenta = new DataGridViewComboBoxColumn();

            //colCuenta.DataSource = _dsCuentas.Tables["Table"];
            //colCuenta.ValueMember = "IdCuenta";
            //colCuenta.DisplayMember = "IdCuenta";

            //colCuenta.DefaultCellStyle.BackColor = Color.White;
            //colCuenta.DefaultCellStyle.SelectionBackColor = Color.Blue;
            //colCuenta.FlatStyle = FlatStyle.Flat;

            DataGridViewColumn colItem = new DataGridViewTextBoxColumn();
            DataGridViewColumn colCantidad = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn colContenedor = new DataGridViewComboBoxColumn();
            DataGridViewColumn colNumero_Contenedor = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn colGenerador = new DataGridViewComboBoxColumn();
            DataGridViewColumn colNumero_Generador = new DataGridViewTextBoxColumn();
            DataGridViewColumn colPeso_Generador = new DataGridViewTextBoxColumn();
            DataGridViewColumn colNumero_Precinto = new DataGridViewTextBoxColumn();
            DataGridViewColumn colPeso_Toneladas = new DataGridViewTextBoxColumn();
            

            //https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-host-controls-in-windows-forms-datagridview-cells?redirectedfrom=MSDN
            DataGridViewColumn colFecha_Posicion = new clsCalendar_Column();

            //https://stackoverflow.com/questions/1807621/c-sharp-winforms-datagridview-time-column
            DataGridViewComboBoxColumn colHora_Posicion = new DataGridViewComboBoxColumn();

            DataGridViewColumn colFecha_Retiro = new clsCalendar_Column();
            //DataGridViewColumn colHora_Retiro = new clsTime_Column();

            DataGridViewColumn colCodigo_Contenedor = new DataGridViewTextBoxColumn();
            DataGridViewColumn colCodigo_Generador = new DataGridViewTextBoxColumn();
            DataGridViewColumn colEstado = new DataGridViewTextBoxColumn();
            DataGridViewColumn colMoro = new DataGridViewCheckBoxColumn();//2021-03-30

            //DataGridViewColumn colEstado = new DataGridViewTextBoxColumn();

            dg.AutoGenerateColumns = false;
            //grdViajes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            dg.Columns.Add(colItem);
            dg.Columns.Add(colCantidad);
            dg.Columns.Add(colContenedor);
            dg.Columns.Add(colNumero_Contenedor);
            dg.Columns.Add(colGenerador);
            dg.Columns.Add(colNumero_Generador);
            dg.Columns.Add(colPeso_Generador);
            dg.Columns.Add(colNumero_Precinto);
            dg.Columns.Add(colPeso_Toneladas);
            dg.Columns.Add(colFecha_Posicion);
            dg.Columns.Add(colHora_Posicion);
            dg.Columns.Add(colFecha_Retiro);
            //grdViajes.Columns.Add(colHora_Retiro);
            dg.Columns.Add(colCodigo_Contenedor);
            dg.Columns.Add(colCodigo_Generador);
            dg.Columns.Add(colEstado);
            //
            dg.Columns.Add(colMoro);

            //grdViajes.ColumnCount = 5;
            dg.Columns[0].Name = "Item";
            dg.Columns[1].Name = "Cantidad";
            dg.Columns[2].Name = "Contenedor";
            dg.Columns[3].Name = "Numero_Contenedor";
            dg.Columns[4].Name = "Generador";
            dg.Columns[5].Name = "Numero_Generador";
            dg.Columns[6].Name = "Peso_Generador";
            dg.Columns[7].Name = "Numero_Precinto";
            dg.Columns[8].Name = "Peso_Toneladas";

            dg.Columns[9].Name = "Fecha_Posicion";
            dg.Columns[10].Name = "Hora_Posicion";
            dg.Columns[11].Name = "Fecha_Retiro";
            //grdViajes.Columns[12].Name = "Hora_Retiro";

            dg.Columns[12].Name = "Codigo_Contenedor";
            dg.Columns[13].Name = "Codigo_Generador";
            dg.Columns[14].Name = "Estado";
            dg.Columns[15].Name = "Especial";


            //grdViajes.Columns[6].Name = "Estado";

            dg.Columns[6].DefaultCellStyle.Format = "N2";
            dg.Columns[8].DefaultCellStyle.Format = "N2";

            dg.Columns[10].DefaultCellStyle.Format = "HH:mm:ss";
            //grdViajes.Columns[12].DefaultCellStyle.Format = "HH:mm:ss";

            dg.Columns[0].HeaderText = "Ítem";
            dg.Columns[1].HeaderText = "Cantidad";
            dg.Columns[2].HeaderText = "Contenedor";
            dg.Columns[3].HeaderText = "Nro. Contenedor";
            dg.Columns[4].HeaderText = "Generador";
            dg.Columns[5].HeaderText = "Nro. Generador";
            dg.Columns[6].HeaderText = "Peso Generador";
            dg.Columns[7].HeaderText = "Precinto";
            dg.Columns[8].HeaderText = "Peso en Toneladas";
            dg.Columns[9].HeaderText = "Fecha Posición";
            dg.Columns[10].HeaderText = "Hora Posición";
            dg.Columns[11].HeaderText = "Fecha Retiro";
            //grdViajes.Columns[12].HeaderText = "Hora Retiro";
            dg.Columns[12].HeaderText = "Codigo Contenedor";
            dg.Columns[13].HeaderText = "Codigo Generador";
            dg.Columns[14].HeaderText = "Estado";
            //
            dg.Columns[15].HeaderText = "Especial";




            //grdViajes.Columns[6].HeaderText = "Estado";

            dg.Columns["Item"].DataPropertyName = "Item";
            dg.Columns["Cantidad"].DataPropertyName = "Cantidad";
            dg.Columns["Contenedor"].DataPropertyName = "Codigo_Contenedor";
            dg.Columns["Numero_Contenedor"].DataPropertyName = "Numero_Contenedor";
            dg.Columns["Generador"].DataPropertyName = "Codigo_Generador";
            dg.Columns["Numero_Generador"].DataPropertyName = "Numero_Generador";
            dg.Columns["Peso_Generador"].DataPropertyName = "Peso_Generador";
            dg.Columns["Numero_Precinto"].DataPropertyName = "Numero_Precinto";
            dg.Columns["Peso_Toneladas"].DataPropertyName = "Peso_Toneladas";
            dg.Columns["Fecha_Posicion"].DataPropertyName = "Fecha_Posicion";
            dg.Columns["Hora_Posicion"].DataPropertyName = "Hora_Posicion";
            dg.Columns["Fecha_Retiro"].DataPropertyName = "Fecha_Retiro";
            //grdViajes.Columns["Hora_Retiro"].DataPropertyName = "Hora_Retiro";
            dg.Columns["Codigo_Contenedor"].DataPropertyName = "Codigo_Contenedor";
            dg.Columns["Codigo_Generador"].DataPropertyName = "Codigo_Generador";
            dg.Columns["Estado"].DataPropertyName = "Estado";

            dg.Columns["Especial"].DataPropertyName = "opMoro";


            //grdViajes.Columns["Estado"].DataPropertyName = "Estado";

            //OCULTA COLUMNAS
            dg.Columns["Item"].Visible = true;
            dg.Columns["Cantidad"].Visible = false;
            dg.Columns["Item"].ReadOnly = true;
            dg.Columns["Cantidad"].ReadOnly = true;
            dg.Columns["Codigo_Contenedor"].ReadOnly = true;
            dg.Columns["Codigo_Generador"].ReadOnly = true;
            
            dg.Columns["Estado"].ReadOnly = true;
            dg.Columns["Estado"].Visible = false;

            dg.Columns["Codigo_Contenedor"].Visible = false;
            dg.Columns["Codigo_Generador"].Visible = false;

            dg.Columns["Item"].Width = 50;
            dg.Columns["Cantidad"].Width = 10;
            dg.Columns["Especial"].Width = 50;

            /*
            DataGridViewCheckBoxColumn chkAgrupa_Tarjeta = new DataGridViewCheckBoxColumn();
            chkAgrupa_Tarjeta.Name = "Agrupa_Tarjeta";
            chkAgrupa_Tarjeta.HeaderText = "Agrupa Tarjeta";
            grdParametros.Columns.Add(chkAgrupa_Tarjeta);
            */

            this.dg.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dg.Columns["Numero_Contenedor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dg.Columns["Numero_Generador"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dg.Columns["Peso_Generador"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dg.Columns["Peso_Toneladas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            

            this.dg.Columns["Especial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //SELECTION MODE
            //grdParametros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg.MultiSelect = false;
            funciones_Varias f = new funciones_Varias();

            colContenedor.ValueMember = "Codigo_Contenedor";
            colContenedor.DisplayMember = "descripcion";
            colContenedor.DataSource = f.Carga_Contenedores(datos.g_idEmpresa);

            colGenerador.ValueMember = "Codigo_Generador";
            colGenerador.DisplayMember = "descripcion";
            colGenerador.DataSource = Carga_Generadores();

            colHora_Posicion.ValueMember = "Codigo_Hora";
            colHora_Posicion.DisplayMember = "descripcion";
            colHora_Posicion.DataSource = carga_horarios();
          

            //colItem.Width = 5;

            dg.CellValueChanged += new DataGridViewCellEventHandler(grdViajes_CellValueChanged);
            dg.CurrentCellDirtyStateChanged += new EventHandler(GrdViajes_CurrentCellDirtyStateChanged);

            //grdViajes.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(GrdViajes_EditingControlShowing);
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private Boolean Validar_Controles()
        {
            Boolean blnTodo_OK;

            MessageBoxButtons button = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Error;

            blnTodo_OK = true;

            if (this.txtBooking.Text==string.Empty)
            {
                MessageBox.Show("Debe indicar el Booking/BL válido ", "Error", button, icon);
                this.txtBooking.Focus();
                blnTodo_OK = false;
              
            }
            if (this.txtBuque.Text==string.Empty )
            {
                MessageBox.Show("Debe indicar un número de buque válido ", "Error", button, icon);
                this.txtBuque.Focus();
                blnTodo_OK = false;
                
            }
            return blnTodo_OK;
        }
        private Boolean Valida_Grilla()
        {

            Boolean blnTodo_OK;

            MessageBoxButtons button = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Error;

            blnTodo_OK = true;

            Int32 intCantidad_Lineas = this.dg.Rows.Count-1;
            //Int32 intContador = 0;

            foreach (DataGridViewRow rw in this.dg.Rows)
            {

                //for (int i = 0; i < rw.Cells.Count; i++)
                //{
                //    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                //    {

                //        if (rw.Cells[i].Visible && !rw.Cells[i].ReadOnly )
                //        { 
                //            MessageBox.Show("Debe ingresar un dato ", "Error", button, icon);
                //            blnTodo_OK = false;

                //            this.grdViajes.CurrentCell = rw.Cells[i];

                //            //i = rw.Cells.Count;
                //            break;
                //        }

                //    }

                //    if (!blnTodo_OK)
                //    {
                //        break;
                //    }

                //}

                //intContador++;

                //if (intContador <= intCantidad_Lineas)
                //{ 

                    if (rw.Cells["Codigo_Contenedor"].Value == null || rw.Cells["Codigo_Contenedor"].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells["Codigo_Contenedor"].Value.ToString()))
                    {
                        MessageBox.Show("Debe seleccionar un Contenedor válido ", "Error", button, icon);
                        blnTodo_OK = false;
                        break;
                    }
                    else
                    {

                        //if (rw.Cells["Numero_Contenedor"].Value == null || rw.Cells["Numero_Contenedor"].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells["Numero_Contenedor"].Value.ToString()))
                        //{
                        //    MessageBox.Show("Debe ingresar un Número de Contenedor válido ", "Error", button, icon);
                        //    blnTodo_OK = false;
                        //    break;
                        //}
                        //else
                       // {

                            if (rw.Cells["Peso_Toneladas"].Value == null || rw.Cells["Peso_Toneladas"].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells["Peso_Toneladas"].Value.ToString()) || (Decimal)rw.Cells["Peso_Toneladas"].Value == 0)
                            {
                                MessageBox.Show("Debe ingresar un Peso en Toneladas distinto de 0(Cero) ", "Error", button, icon);
                                blnTodo_OK = false;
                                break;
                            }

                        //}

                    }

                //}
                //return blnTodo_OK;

            }

            return blnTodo_OK; 

        }



        private DataTable Carga_Ots()
        {
            DN_ABM o = new DN_ABM();

            DataTable dtOTs = new DataTable();

            dtOTs = o.DN_Traer_DataTable("SP_Get_OT_All", "intEmpresa", "intNumero_OT", datos.g_idEmpresa, 0);

            return dtOTs;
        }

        private DataTable Carga_Ots(string strNumero_OT)
        {
            DN_ABM o = new DN_ABM();

            DataTable dtOTs = new DataTable();

            dtOTs = o.DN_Traer_DataTable("SP_Get_OT_All", "intEmpresa", "intNumero_OT", datos.g_idEmpresa, strNumero_OT);

            return dtOTs;
        }

        private DataTable carga_horarios()
        {
            DN_ABM o = new DN_ABM();

            DataTable horarios = new DataTable();

            horarios = o.DN_Traer_DataTable("SP_CargaHorarios", 0, datos.g_idEmpresa);

            return horarios;
        }

        private DataTable Carga_Generadores()
        {
            DN_ABM o = new DN_ABM();

            DataTable dtGeneradores = new DataTable();
            dtGeneradores = o.DN_Traer_DataTable("SP_GET_Generadores_ALL", 0, datos.g_idEmpresa);

            return dtGeneradores;
        }


        private void cargarCombos()
        {

            this.lblUsuario.Text = datos.g_idUser + " " + datos.g_lastName;

            this.cboTipoServicio.SelectedIndexChanged -= new System.EventHandler(cboTipoServicio_SelectedIndexChanged);
            this.cboMercaderias.SelectedIndexChanged -= new System.EventHandler(cboMercaderia_SelectedIndexChanged);
            this.cboNroOT.SelectedIndexChanged -= new System.EventHandler(cboNroOT_SelectedIndexChanged);



            //Cargamos los combos
            DNTablas_Gral lista = new DNTablas_Gral();

            DataTable p;
            funciones_Varias o = new funciones_Varias();

            p = lista.DN_CargarDataTableGral("SP_GET_Tipo_Servicios_ALL", 0, 0);
            o.CargarComboDataTable(cboTipoServicio, p, "id", "descripcion", false, true, false, false);

            cargarcombo_Mercaderia();

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = datos.g_idEmpresa}
            };

            p = lista.Get_Datos("SP_OT_Combo", parameters);
            o.CargarComboDataTable(cboNroOT, p, "Codigo_OT", "descripcion", false, true, false, false);
            //
            
            p = o.Carga_Contenedores(datos.g_idEmpresa);


            o.CargarComboDataTable(cboContenedores, p, "Codigo_Contenedor", "descripcion", false, true, false, false);

            //
            this.cboTipoServicio.SelectedIndexChanged += new System.EventHandler(cboTipoServicio_SelectedIndexChanged);
            this.cboMercaderias.SelectedIndexChanged += new System.EventHandler(cboMercaderia_SelectedIndexChanged);
            this.cboNroOT.SelectedIndexChanged += new System.EventHandler(cboNroOT_SelectedIndexChanged);
        }
        private void cargarcombo_Mercaderia()
        {
            //DNTablas_Gral lista = new DNTablas_Gral();
            //funciones_Varias o = new funciones_Varias();
            //DataTable p;
            //p = lista.DN_CargarDataTableGral("SP_GET_Mercaderias_ALL", 0, 0);
            //o.CargarComboDataTable(cboMercaderias, p, "id", "descripcion", false);


            funciones_Varias o = new funciones_Varias();
            DataTable p;
            
            DNTablas_Gral lista = new DNTablas_Gral();

            p = lista.DN_CargarDataTableGral("SP_GET_Mercaderias_ALL", 0, 0);
            o.CargarComboDataTable(cboMercaderias, p, "codigo_mercaderia", "descripcion", false, true, false, false);

            //int intEmpresa = 1; //POR AHORA!

            //var parameters = new[]
            //{
            //    new MySqlParameter(){ ParameterName="pIdEmpresa", Value = intEmpresa },
            //    new MySqlParameter(){ ParameterName="ID", Value = 0 } //SE LE PASA 0(CERO) PARA NO CAMBIAR TODOS LOS PRG. DE MARCO.
            //};

            DataTable dtMercaderias;

            dtMercaderias = lista.Get_Datos("SP_GET_Mercaderias_ALL");

            o.CargarComboDataTable(this.cboMercaderias, dtMercaderias, "Codigo_Mercaderia", "descripcion", false, true, false, false);
        }

        private void cargarcombo_Rutas()
        {
            funciones_Varias o = new funciones_Varias();
            DN_ABM dn = new DN_ABM();
            DataTable r;
            DNTablas_Gral u = new DNTablas_Gral();

            r = u.DN_CargarDataTableGral("SP_Corredores_Combo", 0, datos.g_idEmpresa);
            o.CargarComboDataTable(this.cboRutas, r, "id", "descripcion", false, true, false, false);
        }
        private void cargarComboHoras(ComboBox cbo)
        {
            int i = 0;
            string oHora = string.Empty;
            for ( i = 0; i <= 9; i++)
            {
                oHora = string.Concat("0", i.ToString(), ":00");
                cbo.Items.Add(oHora);
            }
            for (i = 10; i < 24; i++)
            {
                oHora = string.Concat(i.ToString(), ":00");
                cbo.Items.Add(oHora);
            }
        }
        private void cboRazonSocial_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            cargarContactos();
            //cargarPresupuestos();
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
            o.CargarComboDataTable(this.cboContactos, r, "id", "descripcion", false, true, false, false);

            this.cboContactos.SelectedIndexChanged += new System.EventHandler(cboContactos_SelectedIndexChanged);
            //cargarcombos_rutas();
            //cargarPresupuestos();

            }
        private void cargarcombos_rutas()
        {
            funciones_Varias o = new funciones_Varias();
            DN_ABM dn = new DN_ABM();
            DataTable r;
            DNTablas_Gral u = new DNTablas_Gral();

            int idCliente;
            idCliente = Convert.ToInt32(this.cboRazonSocial.SelectedValue);

            this.cboRutas.SelectedIndexChanged -= new System.EventHandler(cboRutas_SelectedIndexChanged);

            r = u.DN_CargarDataTableGral("SP_ACC_Select", idCliente, datos.g_idEmpresa);
            o.CargarComboDataTable(this.cboRutas, r, "id", "descripcion", false, true, false, false);

            this.cboRutas.SelectedIndexChanged += new System.EventHandler(cboRutas_SelectedIndexChanged);
        }
        private void cargarPresupuestos()
        
        {
            DNTablas_Gral lista = new DNTablas_Gral();
            funciones_Varias o = new funciones_Varias();
            DataTable r;

            int intCliente;
            intCliente = Convert.ToInt32(cboRazonSocial.SelectedValue);
            int intCorredor;
            intCorredor = Convert.ToInt32(this.cboRutas.SelectedValue);
          //cargo los presupuestos.

            this.cboPresupuesto.SelectedIndexChanged -= new System.EventHandler(cboPresupuesto_SelectedIndexChanged);

            //r = lista.DN_CargarDataTableGral("SP_PRESUPUESTO_POR_CLIENTE",ID , datos.g_idEmpresa );
            //o.CargarComboDataTable(this.cboPresupuesto, r, "id", "descripcion", false);

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = datos.g_idEmpresa},
                new MySqlParameter(){ ParameterName="intCliente", Value = intCliente },
                new MySqlParameter(){ ParameterName="intCorredor", Value = intCorredor }
                //new MySqlParameter(){ ParameterName="intTransportista", Value = intTransportista },
                //new MySqlParameter(){ ParameterName="intTractor", Value = intTractor },
                //new MySqlParameter(){ ParameterName="intChasis", Value = intChasis },
                //new MySqlParameter(){ ParameterName="intChofer", Value = intChofer },
                //new MySqlParameter(){ ParameterName="intItem", Value = _Item }
            };

         

            r = lista.Get_Datos("SP_PRESUPUESTO_POR_CLIENTE", parameters);
            o.CargarComboDataTable(this.cboPresupuesto, r, "id", "descripcion", false, true, false, false);

            this.cboPresupuesto.SelectedIndexChanged += new System.EventHandler(cboPresupuesto_SelectedIndexChanged);

        }
        private void cargar_datos_Presupuesto(bool bVerTodo)
        {
            DN_ABM d = new DN_ABM();

            //int ID;

            //bVerTodo=True-->es para lo nuevo
            //bVerTodo=False-->Solo consulta


            //ID = Convert.ToInt32(cboContactos.SelectedValue);
            //d.DN_Contactos_Get_Id(ID, datos.g_idEmpresa);

            //Debe llenar los datos como por ejemplo:
            //Fecha, Fecha Vencimiento, COsto de Ruta, Importe Venta, Tipo de Servicio y Mercadería
            int codPresu;
            DataTable dt;

            DNTablas_Gral dn = new DNTablas_Gral();
            codPresu = 0;

            Int32.TryParse(this.cboPresupuesto.SelectedValue.ToString(), out codPresu);

            dt = dn.DN_CargarDataTableGral("SP_Cotizacion_Traer", codPresu, datos.g_idEmpresa);

            if (dt.Rows.Count > 0)
            {
                DataRow dr;
                dr = dt.Rows[0];
                if (bVerTodo == true)
                { 
                    this.cboRazonSocial.SelectedValue = Convert.ToInt32(dr["IdCliente"]);
                    this.cboContactos.SelectedValue = Convert.ToInt32(dr["IdContacto"]);
                    this.cboTipoServicio.SelectedValue = Convert.ToInt32(dr["TipoServicio"]);
                    this.cboRutas.SelectedValue = Convert.ToInt32(dr["IdCorredor"]);
                    //this.cboCondicionPago.SelectedValue = dr["IdCondicionPago"];
                    //this.cboVendedores.SelectedValue = dr["IdVendedor"];
                    this.cboMercaderias.SelectedValue = Convert.ToInt32(dr["idMercaderia"]);
                    //this.cboDuracion.SelectedValue = dr[""];
                    //this.txtContedores.Text = "";
                    //this.txtPeso.Text = "";
                    this.txtCosto.Text = dr["CostoCorredor"].ToString();
                    this.txtCantContenedores.Text = dr["CantCOntenedores"].ToString();
                    this.txtImporte.Text = dr["ImporteVenta"].ToString();
                    this.txtObservacion.Text = dr["Observaciones"].ToString();

                    this.cboModalidades.SelectedValue = Convert.ToInt32(dr["TipoModalidad"]);
                    this.lblCodigo_Contenedor.Text = "";
                    this.lblPeso_Contenedor.Text = "";
                }
                this.lblFechaDesde.Text = dr["FechaVigenciaDesde"].ToString();
                this.lblFechaHasta.Text = dr["FechaVencimiento"].ToString();

            }
        }
        private void cboPresupuesto_SelectedIndexChanged(object sender, System.EventArgs e)
        {


            cargar_datos_Presupuesto(_blnVerTodo);
            //Llenar la Grilla
            //iniciarGrilla();
            Carga_Grilla();
            bloquear_opMoro(false);


        }

        private void cboTipoServicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cboMercaderia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cboContactos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            

            if (this.cboContenedores.SelectedIndex ==-1)
            {
                MessageBox.Show("Debe seleccionar un combo","Atención");
                return;
            }
            if (this.txtPeso.Text==string.Empty || Extensiones.IsNumeric(this.txtPeso.Text)==false)
            {
                MessageBox.Show("Debe informar un peso valido", "Atención");
                return;
            }

            //validar 
            DateTime fDesde = Convert.ToDateTime(this.lblFechaDesde.Text);
            DateTime fHasta = Convert.ToDateTime(this.lblFechaHasta.Text);
            DateTime fPosic = Convert.ToDateTime(this.datFechaPos.Text);

            if (fPosic.ToUniversalTime() >= fDesde.ToUniversalTime() && fPosic.ToUniversalTime() <= fHasta.ToUniversalTime())
            {



                int i;
                int ultimoID;
                int cantContenedores;
                if (_dtItems.Tables[0].Rows.Count == 0)
                {
                    ultimoID = 0;
                    cantContenedores = Int32.Parse(this.txtCantContenedores.Text);
                }
                else
                {
                    ultimoID = _dtItems.Tables[0].Rows.Cast<DataRow>().Select(row => row.Field<int>("Item")).Max();
                    cantContenedores = Int32.Parse(this.txtCantContenedores.Text) + ultimoID;
                }

                for (i = ultimoID; i < cantContenedores; i++)
                {
                    DataRow rd = _dtItems.Tables[0].NewRow();
                    rd["Item"] = i + 1;
                    rd["Codigo_Contenedor"] = Convert.ToInt32(this.cboContenedores.SelectedValue);
                    rd["Peso_Toneladas"] = Convert.ToInt32(this.txtPeso.Text);
                    rd["Fecha_Posicion"] = this.datFechaPos.Text;
                    rd["Hora_Posicion"] = "06:00";
                    rd["Fecha_Retiro"] = this.datFechaRetiro.Text;


                    _dtItems.Tables[0].Rows.Add(rd);
                }

                dg.DataSource = _dtItems.Tables[0];
                bloquear_opMoro(false);

            }else
            { 
                MessageBox.Show(datos.g_lastName.ToUpper() + ", La fecha de vigencia de la cotización NO permite usarla para este posicionamiento ");
            }

    }

        private void Agrega_Linea_En_Grilla()
        {

            if (this.dg.Rows.Count != 0 )
            {
                DataGridViewRow lngLinea = (DataGridViewRow)dg.Rows[0].Clone();

                //Coloca un "1" en la columna "Cantidad"
                lngLinea.Cells[1].Value = 1;
                dg.Rows.Add(lngLinea);

            }
            else
            {
                this.dg.Rows.Add();
                dg.Rows[this.dg.Rows.Count - 1].Cells["Cantidad"].Value = 1;
            }

            //this.grdViajes.Rows.Add(1);

            //DataTable dt2 = new DataTable();
            //dt2 = grdViajes.DataSource as DataTable;

            //DataRow datarow;
            //datarow = dt2.NewRow(); //Con esto le indica que es una nueva fila.

            //datarow["Codigo_Contenedor"] = prodcod.Text;
            //datarow["ARTICULO"] = articulo.Text;
            //datarow["MANGA"] = manga.Text;
            //datarow["TALLA"] = talla.Text;
            //datarow["UNIDAD"] = unidad.Text;
            //datarow["CANTIDAD"] = cantidad.Text;
            //datarow["PRECIOUNIT"] = preciou.Text;
            //datarow["SUBTOTAL"] = subtotal.Text;
            //datarow["PORCEN_DESCUENTO"] = descuento.Text;
            //datarow["TOTAL"] = total.Text;

            ////Esto se encargará de agregar la fila.
            //dt2.Rows.Add(datarow);



        }

        private void GrdViajes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

            //SOLO PERMITE EL INGRESO DE NÚMEROS, INCLUSO NEGATIVOS Y 1(UNO) SOLO PUNTO DECIMAL
            //https://stackoverflow.com/questions/39982127/restrict-dot-in-datagridview-cell-at-start-of-the-cell

            var cell = dg.CurrentCell;

            //SOLO PARA LAS COLUMNAS DE PESO GENERADOR Y PESO EN TONELADAS
            if (cell.ColumnIndex != 6 && cell.ColumnIndex != 8)
            {
            return;
            }

            string value = cell.EditedFormattedValue.ToString();
            string pattern = @"^-$ | ^-?0$ | ^-?0\.\d*$ | ^-?[1-9]\d*\.?\d*$";

            if (Regex.IsMatch(value, pattern, RegexOptions.IgnorePatternWhitespace))
            {
                dg.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            else
            {
                dg.CancelEdit();
            }

        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            if (Validar_Controles())
            {
                if (Valida_Grilla())
                {
                    Grabar();
                    Limpiar_Controles();
                    cargarCombos();
                    _blnAlta = true;
                    funciones_Varias fv = new funciones_Varias();
                    fv.Abrir_Form_OT(datos.g_permiso);
                    this.Close();
                }
            }


        }

        //private void grdViajes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{

        //    ComboBox cboCombo = e.Control as ComboBox;

        //    int colIndex = this.grdViajes.CurrentCell.ColumnIndex;

        //    if (colIndex == 2)
        //    { 

        //        if (cboCombo != null)
        //        {
        //            cboCombo.SelectedIndexChanged -= new EventHandler(cboGeneradores_SelectedIndexChanged);

        //            cboCombo.SelectedIndexChanged -= new EventHandler(cboContenedores_SelectedIndexChanged);
        //            cboCombo.SelectedIndexChanged += new EventHandler(cboContenedores_SelectedIndexChanged);
                    
        //        }

        //    }
        //    else
        //    {

        //        if (colIndex == 4)
        //        {

        //            if (cboCombo != null)
        //            {
        //                cboCombo.SelectedIndexChanged -= new EventHandler(cboContenedores_SelectedIndexChanged);

        //                cboCombo.SelectedIndexChanged -= new EventHandler(cboGeneradores_SelectedIndexChanged);
        //                cboCombo.SelectedIndexChanged += new EventHandler(cboGeneradores_SelectedIndexChanged);
                        
        //            }

        //        }

        //    }


        //}

        //private void cboContenedores_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ComboBox cb = (ComboBox)sender;
        //    string item = cb.Text;
        //    if (item != null)
        //        MessageBox.Show(item);
        //}

        //private void cboGeneradores_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ComboBox cb = (ComboBox)sender;
        //    string item = cb.Text;
        //    if (item != null)
        //        MessageBox.Show(item);
        //}

        //void grdViajes_CurrentCellDirtyStateChanged(object sender,
        //        EventArgs e)
        //{

        //}

        private void grdViajes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex != 2 && e.ColumnIndex != 4)
                return;

            dg.CellValueChanged -= new DataGridViewCellEventHandler(grdViajes_CellValueChanged);

            DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dg.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (e.ColumnIndex == 2)
            {
                dg[13, e.RowIndex].Value = cb.Value;
            }
            else
            { 
                if (e.ColumnIndex == 4)
                {
                    dg[14, e.RowIndex].Value = cb.Value;
                }
            }

            dg.CellValueChanged += new DataGridViewCellEventHandler(grdViajes_CellValueChanged);

        }

        private void Frm_Comerciales_OT_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Grabar()
        {
            //https://www.youtube.com/watch?v=fne9TMDlLN4&feature=push-sd&attr_tag=nMx1KFpTImtfvSZb%3A6

            clsConn cnMarco = new clsConn();

            String strConnection_String = "";

            strConnection_String = cnMarco.Cadena_Conexion();

            MySqlConnection cnnConnection = new MySqlConnection(strConnection_String);
            cnnConnection.Open();

            MySqlCommand cmdCommand = cnnConnection.CreateCommand();
            MySqlTransaction trsTransaccion;

            //Cabecera
            int intNumero_OT = 0;
            int intID_Cotizacion = 0;
            string strFecha;
            string strID_Cliente = string.Empty;
            string strBuque = string.Empty;
            string strBooking = string.Empty;
            int intTipo_Servicio = 0;
            int intViajes = 0;
            int intId_Terminal_Retiro = 0;
            int intId_Terminal_Entrega = 0;
            int intId_Deposito_Retiro = 0;
            int intId_Deposito_Entrega = 0;
            int intId_Data = 0;
            string strObservaciones;
            string strCodRef;
            //int intEstado = 0;
            Decimal decCosto;
            Decimal decImporte;

            int intTipo_Modalidad ;
            int intContacto;
            int intRuta;
            int intMercaderia;



            //Detalle
            int intItem = 0;
            decimal decCantidad = 0;
            int intID_Contenedor = 0;
            String strNumero_Contenedor = string.Empty;
            int intID_Generador = 0;
            String strNumero_Generador = string.Empty;
            Decimal decPeso_Generador = 0;
            String strNumero_Precinto = string.Empty;
            Decimal decPeso;
            int intNoLlevaFact;
            int intMoro;
           //int intUnidad_Medida = 0;


            DateTime datFecha_Posicion;
            string datHora_Posicion;
            DateTime datFecha_Retiro;
            //DateTime datHora_Retiro;
           

            if (this.txtNumero_OT.Text.Trim() != string.Empty)
            {
                intNumero_OT = int.Parse(this.txtNumero_OT.Text);
            }

            if (this.cboPresupuesto.SelectedIndex != -1)
            {
                intID_Cotizacion = int.Parse(this.cboPresupuesto.SelectedValue.ToString());
            }

            strFecha = this.datFecha.Value.ToString("yyyy-MM-dd"); 
            
            if (this.cboRazonSocial.SelectedIndex != -1)
            {
                strID_Cliente = this.cboRazonSocial.SelectedValue.ToString();
            }

            strBuque = this.txtBuque.Text.Trim();

            strBooking = this.txtBooking.Text.Trim();

            if (this.cboTipoServicio.SelectedIndex != -1)
            {
                intTipo_Servicio = int.Parse(this.cboTipoServicio.SelectedValue.ToString());
            }

            intViajes = int.Parse(this.txtViajes.Value.ToString());

            if (this.cboTerminal_Retiro.SelectedIndex != -1)
            {
                intId_Terminal_Retiro = int.Parse(this.cboTerminal_Retiro.SelectedValue.ToString());
            }

            if (this.cboTerminal_Entrega.SelectedIndex != -1)
            {
                intId_Terminal_Entrega = int.Parse(this.cboTerminal_Entrega.SelectedValue.ToString());
            }

            if (this.cboDeposito_Retiro.SelectedIndex != -1)
            {
                intId_Deposito_Retiro = int.Parse(this.cboDeposito_Retiro.SelectedValue.ToString());
            }

            if (this.cboDeposito_Entrega.SelectedIndex != -1)
            {
                intId_Deposito_Entrega = int.Parse(this.cboDeposito_Entrega.SelectedValue.ToString());
            }

            intTipo_Modalidad = int.Parse(this.cboModalidades.SelectedValue.ToString());

            intContacto = int.Parse(this.cboContactos.SelectedValue.ToString());

            intRuta = int.Parse(this.cboRutas.SelectedValue.ToString());

            intMercaderia = int.Parse(this.cboMercaderias.SelectedValue.ToString());

            intId_Data = 0;

            strObservaciones = this.txtObservacion.Text.Trim();

            decCosto = this.txtCosto.Value;

            decImporte = this.txtImporte.Value;

            intNoLlevaFact = Convert.ToInt32(this.opNoLlevaFactura.Checked);

            strCodRef = this.txtNroRef.Text.Trim();

            intMoro = Convert.ToInt32(this.opMoro.Checked);

            trsTransaccion = cnnConnection.BeginTransaction();

            cmdCommand.Connection = cnnConnection;
            cmdCommand.Transaction = trsTransaccion;
            cmdCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                cmdCommand.CommandText = "SP_OT_Alta";

                cmdCommand.Parameters.Add("pIdEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("pNumero_OT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("pIdCotizacion", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("pFecha", MySqlDbType.Date);
                cmdCommand.Parameters.Add("pNroRefCliente", MySqlDbType.String);
                cmdCommand.Parameters.Add("pBuque", MySqlDbType.String);
                cmdCommand.Parameters.Add("pBLBooking", MySqlDbType.String);
                cmdCommand.Parameters.Add("pTipoServicio", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("pViaje", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("pIdTerminalRet", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("pIdTerminalEnt", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("pIdDepositoRet", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("pIdDepositoEnt", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("pIdATA", MySqlDbType.String);
                cmdCommand.Parameters.Add("pObservaciones", MySqlDbType.String);
                cmdCommand.Parameters.Add("pEstado", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("pCosto", MySqlDbType.Decimal);
                cmdCommand.Parameters.Add("pImporte", MySqlDbType.Decimal);
                cmdCommand.Parameters.Add("intTipo_Modalidad", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intRuta", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intContacto", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intMercaderia", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intNoLlevaFact", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("strCodRef", MySqlDbType.String);
                cmdCommand.Parameters.Add("intMoro", MySqlDbType.Int32);

                cmdCommand.Parameters["pIdEmpresa"].Value = datos.g_idEmpresa;

                if (intNumero_OT != 0)
                {
                    cmdCommand.Parameters["pNumero_OT"].Value = intNumero_OT;
                }
                else
                {
                    cmdCommand.Parameters["pNumero_OT"].Value = DBNull.Value;
                }
                
                cmdCommand.Parameters["pIdCotizacion"].Value = intID_Cotizacion;
                cmdCommand.Parameters["pFecha"].Value = strFecha;
                cmdCommand.Parameters["pNroRefCliente"].Value = strID_Cliente;
                cmdCommand.Parameters["pBuque"].Value = strBuque;
                cmdCommand.Parameters["pBLBooking"].Value = strBooking;
                cmdCommand.Parameters["pTipoServicio"].Value = intTipo_Servicio;
                cmdCommand.Parameters["pViaje"].Value = intViajes;
                cmdCommand.Parameters["pIdTerminalRet"].Value = intId_Terminal_Retiro;
                cmdCommand.Parameters["pIdTerminalEnt"].Value = intId_Terminal_Entrega;
                cmdCommand.Parameters["pIdDepositoRet"].Value = intId_Deposito_Retiro;
                cmdCommand.Parameters["pIdDepositoEnt"].Value = intId_Deposito_Entrega;
                cmdCommand.Parameters["pIdATA"].Value = intId_Data;
                cmdCommand.Parameters["pObservaciones"].Value = strObservaciones;
                cmdCommand.Parameters["pEstado"].Value = 1;
                cmdCommand.Parameters["pCosto"].Value = decCosto;
                cmdCommand.Parameters["pImporte"].Value = decImporte;
                cmdCommand.Parameters["intTipo_Modalidad"].Value = intTipo_Modalidad;

                cmdCommand.Parameters["intContacto"].Value = intContacto;
                cmdCommand.Parameters["intMercaderia"].Value = intMercaderia;
                cmdCommand.Parameters["intRuta"].Value = intRuta;
                cmdCommand.Parameters["intNoLlevaFact"].Value = intNoLlevaFact;

                cmdCommand.Parameters["strCodRef"].Value = strCodRef;
                cmdCommand.Parameters["intMoro"].Value = intMoro;

                cmdCommand.ExecuteNonQuery();

               

                intItem = 0;
                decCantidad = 0;
                intID_Contenedor = 0;
                strNumero_Contenedor = string.Empty;
                intID_Generador = 0;
                strNumero_Generador = string.Empty;
                decPeso_Generador = 0;
                strNumero_Precinto = string.Empty;
                decPeso = 0;
               // intUnidad_Medida = 0;

                cmdCommand.Parameters.Clear();

                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intNumero_OT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intItem", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("decCantidad", MySqlDbType.Decimal);         
                cmdCommand.Parameters.Add("intID_Contenedor", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("strNumero_Contenedor", MySqlDbType.String);
                cmdCommand.Parameters.Add("intID_Generador", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("strNumero_Generador", MySqlDbType.String);
                cmdCommand.Parameters.Add("decPeso_Generador", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("strNumero_Precinto", MySqlDbType.String );
                cmdCommand.Parameters.Add("decPeso", MySqlDbType.Decimal);
                cmdCommand.Parameters.Add("intID_Unidad_Medida", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("datFecha_Posicion", MySqlDbType.DateTime);
                cmdCommand.Parameters.Add("datHora_Posicion", MySqlDbType.String);
                cmdCommand.Parameters.Add("datFecha_Retiro", MySqlDbType.DateTime);
                //cmdCommand.Parameters.Add("datHora_Retiro", MySqlDbType.DateTime);
                cmdCommand.Parameters.Add("decVenta", MySqlDbType.Decimal);
                cmdCommand.Parameters.Add("intMoro", MySqlDbType.Int32);
                //Int32 intCantidad_Lineas = this.grdViajes.Rows.Count - 1;
                //Int32 intContador = 0;

                foreach (DataGridViewRow dgvRenglon in dg.Rows)
                {

                    //intContador++;

                    //if (intContador <= intCantidad_Lineas)
                    //{

                        intItem++;
                        decCantidad = 1;
                        intID_Contenedor = int.Parse(dgvRenglon.Cells["Codigo_Contenedor"].Value.ToString());
                        strNumero_Contenedor = dgvRenglon.Cells["Numero_Contenedor"].Value.ToString();

                        intID_Generador = 0;
                        strNumero_Generador = "0";
                        decPeso_Generador = 0;


                        if (dgvRenglon.Cells["Codigo_Generador"].Value != DBNull.Value) //|| String.IsNullOrWhiteSpace(dgvRenglon.Cells["Codigo_Generador"].Value.ToString()) || dgvRenglon.Cells["Codigo_Generador"].Value != null)
                        {
                            intID_Generador = int.Parse(dgvRenglon.Cells["Codigo_Generador"].Value.ToString());
                        }

                        if (dgvRenglon.Cells["Numero_Generador"].Value != DBNull.Value)
                        {
                            strNumero_Generador = dgvRenglon.Cells["Numero_Generador"].Value.ToString();
                        }

                        if (dgvRenglon.Cells["Peso_Generador"].Value != DBNull.Value)
                        {
                            decPeso_Generador = decimal.Parse(dgvRenglon.Cells["Peso_Generador"].Value.ToString());
                        }

                        strNumero_Precinto = dgvRenglon.Cells["Numero_Precinto"].Value.ToString();
                        decPeso = decimal.Parse(dgvRenglon.Cells["Peso_Toneladas"].Value.ToString());
                        datFecha_Posicion = DateTime.Parse(dgvRenglon.Cells["Fecha_Posicion"].Value.ToString());
                        datHora_Posicion = dgvRenglon.Cells["Hora_Posicion"].Value.ToString();
                        datFecha_Retiro = DateTime.Parse(dgvRenglon.Cells["Fecha_Retiro"].Value.ToString());
                        
                        //datHora_Retiro = DateTime.Parse(dgvRenglon.Cells["Hora_Retiro"].Value.ToString());
                        intMoro = Convert.ToInt32(dgvRenglon.Cells["Especial"].Value);

                cmdCommand.CommandText = "SP_OT_Item_Alta";

                cmdCommand.Parameters["intEmpresa"].Value = datos.g_idEmpresa;
                cmdCommand.Parameters["intNumero_OT"].Value = intNumero_OT;
                cmdCommand.Parameters["intItem"].Value = intItem;
                cmdCommand.Parameters["decCantidad"].Value = decCantidad;
                cmdCommand.Parameters["intID_Contenedor"].Value = intID_Contenedor;
                cmdCommand.Parameters["strNumero_Contenedor"].Value = strNumero_Contenedor;
                        

                    if (intID_Generador == 0)
                        {
                            cmdCommand.Parameters["intID_Generador"].Value = DBNull.Value;
                            cmdCommand.Parameters["strNumero_Generador"].Value = DBNull.Value;
                            cmdCommand.Parameters["decPeso_Generador"].Value = DBNull.Value;
                        }
                        else
                        {
                            cmdCommand.Parameters["intID_Generador"].Value = intID_Generador;
                            cmdCommand.Parameters["strNumero_Generador"].Value = strNumero_Generador;
                            cmdCommand.Parameters["decPeso_Generador"].Value = decPeso_Generador;
                        }

                        if (strNumero_Precinto == string.Empty)
                        {
                            cmdCommand.Parameters["strNumero_Precinto"].Value = DBNull.Value;
                        }
                        else
                        {
                            cmdCommand.Parameters["strNumero_Precinto"].Value = strNumero_Precinto;
                        }
                cmdCommand.Parameters["decPeso"].Value = decPeso;
                cmdCommand.Parameters["intID_Unidad_Medida"].Value = DBNull.Value;
                cmdCommand.Parameters["decVenta"].Value = decImporte;
                cmdCommand.Parameters["datFecha_Posicion"].Value = datFecha_Posicion.ToString("yyyy-MM-dd");
                cmdCommand.Parameters["datHora_Posicion"].Value = datHora_Posicion.ToString();
                    //cmdCommand.Parameters["datFecha_Retiro"].Value = datFecha_Retiro.ToString("yyyy-MM-dd");
                    //cmdCommand.Parameters["datHora_Retiro"].Value = datHora_Retiro.ToString("HH:MM");

                    //cmdCommand.Parameters["datFecha_Posicion"].Value = datFecha_Posicion;
                    //cmdCommand.Parameters["datHora_Posicion"].Value = datHora_Posicion;
                cmdCommand.Parameters["datFecha_Retiro"].Value = datFecha_Retiro;
                    //cmdCommand.Parameters["datHora_Retiro"].Value = datHora_Retiro;
                cmdCommand.Parameters["intMoro"].Value = intMoro;

                cmdCommand.ExecuteNonQuery();

                    //}

                }

                trsTransaccion.Commit();

                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Information;

                MessageBox.Show("Proceso finalizado ", "Aviso", button, icon);

            }

            catch (Exception e)
            {
                try
                {
                    trsTransaccion.Rollback();
                }
                catch (MySqlException ex)
                {
                    if (trsTransaccion.Connection != null )
                    {
                        Console.WriteLine("Error" + ex.GetType());
                    }
                }

                Console.WriteLine("Error" + e.GetType() );
            }
            finally
            {
                cnnConnection.Close();
            }

        }

        private void BtnAyuda_OTs_Click(object sender, EventArgs e)
        {

            //https://stackoverflow.com/questions/5233502/how-to-return-a-value-from-a-form-in-c
            using (var form = new frmAyuda())
            {

                form._datDatos_Ayuda = Carga_Ots();

                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form._strCodigo_Retorno;            //values preserved after close

                    this.txtNumero_OT.Text = val;

                    KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                    this.TxtNumero_OT_KeyPress(sender, arg);

                }
            }

        }

        private void TxtNumero_OT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 )
            {
                Limpiar_Controles();

                _blnAlta = Verifica_Tipo_Operacion_Formulario(sender);

                if (!_blnAlta)
                {
                    string strTexto = string.Empty;
                    strTexto = sender.GetType().GetProperty("Text").GetValue(sender).ToString();

                    Carga_Datos_OT(strTexto);
                    //Carga_Grilla();
                }

                Carga_Grilla();
                bloquear_opMoro(true);

            }

        }

        private void TxtNumero_OT_Leave(object sender, EventArgs e)
        {

            Limpiar_Controles();
            _blnVerTodo = false;

            _blnAlta = Verifica_Tipo_Operacion_Formulario(sender);

            if (!_blnAlta)
            {

                string strTexto = string.Empty;
                strTexto = sender.GetType().GetProperty("Text").GetValue(sender).ToString();

                Carga_Datos_OT(strTexto);
                //Carga_Grilla();
            }

            Carga_Grilla();
            bloquear_opMoro(true);

        }

        private static Boolean Verifica_Tipo_Operacion_Formulario(object objControl)
        {

            Boolean blnAlta = false; 

            string strTexto = string.Empty;
            strTexto = objControl.GetType().GetProperty("Text").GetValue(objControl).ToString();

            if (strTexto.Trim() == string.Empty)
                {
                blnAlta = true;
            }
            else
            {
                blnAlta = false;
            }

            return blnAlta;

        }

        private void Carga_Datos_OT(string strNumero_OT)
        {

            BindingSource bindingSource = new BindingSource();

            System.Data.DataSet dsOTs = new System.Data.DataSet("OTs");

            //string strConsulta = "";
            //strConsulta = "Exec Carga_CompraBU @intEmpresa = " + intEmpresa + ", @intIdCompraBU = " + intID_Compra_BU;
            //dsCompraBU = Entidades.GetDataSet(strConsulta);

            dsOTs.Tables.Add(Carga_Ots(strNumero_OT));

            bindingSource.DataSource = dsOTs.Tables["Table1"];

            if (dsOTs.Tables["Table1"].Rows.Count == 0)
            {
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Exclamation;

                MessageBox.Show("No existen datos ", "Aviso", button, icon);
            }

            this.cboRazonSocial.DataBindings.Clear();
            this.cboContactos.DataBindings.Clear();
            this.cboPresupuesto.DataBindings.Clear();
            this.cboRutas.DataBindings.Clear();
            this.cboTipoServicio.DataBindings.Clear();
            this.cboMercaderias.DataBindings.Clear();

            this.cboContactos.DataBindings.Clear();
            this.cboRutas.DataBindings.Clear();
            this.cboMercaderias.DataBindings.Clear();
            this.cboModalidades.DataBindings.Clear();

            this.cboTerminal_Entrega.DataBindings.Clear();
            this.cboTerminal_Retiro.DataBindings.Clear();

            this.cboModalidades.DataBindings.Clear();

            this.datFecha.DataBindings.Clear();
            this.datFecha_Vencimiento.DataBindings.Clear();

            this.txtCosto.DataBindings.Clear();
            this.txtImporte.DataBindings.Clear();
            this.txtObservacion.DataBindings.Clear();

            this.txtBuque.DataBindings.Clear();
            this.txtBooking.DataBindings.Clear();
            this.opNoLlevaFactura.DataBindings.Clear();
            this.opMoro.DataBindings.Clear();

            //TEXTBOX
            this.txtObservacion.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Observacion"].ColumnName));
            this.txtBuque.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Buque"].ColumnName));
            this.txtBooking.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["BLBooking"].ColumnName));

            //COMBOS
            this.cboRazonSocial.DataBindings.Add(new Binding("SelectedValue", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Cod_Cliente"].ColumnName));
            this.cboContactos.DataBindings.Add(new Binding("SelectedValue", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Codigo_Contacto"].ColumnName));
            this.cboRutas.DataBindings.Add(new Binding("SelectedValue", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Codigo_Ruta"].ColumnName));
            this.cboMercaderias.DataBindings.Add(new Binding("SelectedValue", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Codigo_Mercaderia"].ColumnName));
            this.cboModalidades.DataBindings.Add(new Binding("SelectedValue", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Codigo_Tipo_Modalidad"].ColumnName));


            this.cboPresupuesto.SelectedIndexChanged -= new System.EventHandler(cboPresupuesto_SelectedIndexChanged);

            this.cboPresupuesto.DataBindings.Add(new Binding("SelectedValue", bindingSource, ((DataTable)bindingSource.DataSource).Columns["IdCotizacion"].ColumnName));

            this.cboPresupuesto.SelectedIndexChanged += new System.EventHandler(cboPresupuesto_SelectedIndexChanged);

            //this.cboRutas.DataBindings.Add(new Binding("SelectedValue", bindingSource, ((DataTable)bindingSource.DataSource).Columns["TipoComprobante"].ColumnName));
            this.cboTipoServicio.DataBindings.Add(new Binding("SelectedValue", bindingSource, ((DataTable)bindingSource.DataSource).Columns["TipoServicio"].ColumnName));
            //this.cboMercaderias.DataBindings.Add(new Binding("SelectedValue", bindingSource, ((DataTable)bindingSource.DataSource).Columns["CondicionIVA"].ColumnName));

            this.cboTerminal_Entrega.DataBindings.Add(new Binding("SelectedValue", bindingSource, ((DataTable)bindingSource.DataSource).Columns["IdTerminalEnt"].ColumnName));
            this.cboTerminal_Retiro.DataBindings.Add(new Binding("SelectedValue", bindingSource, ((DataTable)bindingSource.DataSource).Columns["IdTerminalRet"].ColumnName));

            //this.cboModalidades.DataBindings.Add(new Binding("SelectedValue", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Codigo_Tipo_Modalidad"].ColumnName));

            //CAMPOS NUMÉRICOS
            this.txtCosto.DataBindings.Add(new Binding("Value", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Costo"].ColumnName));
            this.txtImporte.DataBindings.Add(new Binding("Value", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Venta"].ColumnName));

            //Fechas
            this.datFecha.DataBindings.Add(new Binding("Value", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Fecha"].ColumnName));
            this.datFecha_Vencimiento.DataBindings.Add(new Binding("Value", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Fecha"].ColumnName));

            this.opNoLlevaFactura.DataBindings.Add(new Binding("Checked", bindingSource, ((DataTable)bindingSource.DataSource).Columns["No_Lleva_Fact"].ColumnName));
            this.opMoro.DataBindings.Add(new Binding("Checked", bindingSource, ((DataTable)bindingSource.DataSource).Columns["op_Moro"].ColumnName));

            cargar_datos_Presupuesto(_blnVerTodo);
            
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            //Limpiar_Controles();
            //cargarCombos();
           // _blnAlta = true;
           // _blnVerTodo = true;
            funciones_Varias fv = new funciones_Varias();
            fv.Abrir_Form_OT(datos.g_permiso);
            this.Close();
        }

        void Limpiar_Controles()
        {

            //this.txtNumero_OT.Text = string.Empty;

            this.cboRazonSocial.SelectedIndexChanged -= new System.EventHandler(cboRazonSocial_SelectedIndexChanged);
            this.cboRazonSocial.SelectedIndex = -1;
            this.cboRazonSocial.SelectedIndexChanged += new System.EventHandler(cboRazonSocial_SelectedIndexChanged);

            this.cboContactos.SelectedIndex = -1;

            this.cboPresupuesto.SelectedIndexChanged -= new System.EventHandler(cboPresupuesto_SelectedIndexChanged);
            this.cboPresupuesto.SelectedIndex = -1;
            this.cboPresupuesto.SelectedIndexChanged += new System.EventHandler(cboPresupuesto_SelectedIndexChanged);

            this.cboRutas.SelectedIndex = -1;
            this.txtCosto.Value = 0;
            this.txtImporte.Value = 0;
            this.cboTipoServicio.SelectedIndex = -1;
            this.cboMercaderias.SelectedIndex = -1;
            this.txtObservacion.Text = string.Empty;
            this.txtBuque.Text = string.Empty;
            this.txtBooking.Text = string.Empty;
            this.txtViajes.Value = 0;
            this.cboTerminal_Retiro.SelectedIndex = -1;
            this.cboDeposito_Retiro.SelectedIndex = -1;
            this.cboDeposito_Entrega.SelectedIndex = -1;
            this.cboTerminal_Entrega.SelectedIndex = -1;
            this.txtCantContenedores.Text = "0";

            this.dg.DataSource = null;
            this.opNoLlevaFactura.Checked = false;
            this.btnAgregar.Enabled = true;
            this.dg.Enabled = true;
            this.lblAviso.Visible = false;
            this.opMoro.Checked = false;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Carga_Grilla()
        {

            funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            int intEmpresa = datos.g_idEmpresa;  //POR AHORA!

            int intNumero_OT = 0;

            if (!_blnAlta)
            {
                intNumero_OT = Convert.ToInt32(this.txtNumero_OT.Text.ToString());
            }
                
                

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = intEmpresa },
                new MySqlParameter(){ ParameterName="intOT", Value = intNumero_OT }
                //new MySqlParameter(){ ParameterName="intTransportista", Value = intTransportista },
                //new MySqlParameter(){ ParameterName="intTractor", Value = intTractor },
                //new MySqlParameter(){ ParameterName="intChasis", Value = intChasis },
                //new MySqlParameter(){ ParameterName="intChofer", Value = intChofer },
                //new MySqlParameter(){ ParameterName="intItem", Value = _Item }
            };

            DataTable dtItems;

            dtItems = lista.Get_Datos("SP_Carga_ItemsOT", parameters);

            if ( _dtItems.Tables.Count > 0)
            {
                _dtItems.Tables.RemoveAt(0);
            }

            _dtItems.Tables.Add(dtItems);

            //grdViajes.DataSource = dtItems;
            dg.DataSource = _dtItems.Tables[0];

            this.btnAgregar.Enabled = true;
            this.dg.Enabled = true;
            this.lblAviso.Visible = false;
            foreach (DataRow dr in dtItems.Rows)
            {
                //if (dr["Numero_Contenedor"].ToString()!=string.Empty)
                //{
                //    this.btnAgregar.Enabled = false;
                //    this.dg.Enabled = false;
                //}
                if (dr["TieneFactura"].ToString() == "0")
                {
                    this.btnAgregar.Enabled = false;
                    this.dg.Enabled = false;
                    this.lblAviso.Visible = true;
                }
            }

        }

        private void Carga_Combo_Terminales_Retiro()
        {

            funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            int intEmpresa = 1; //POR AHORA!

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = intEmpresa },
                new MySqlParameter(){ ParameterName="intOT", Value = DBNull.Value }
            };

            DataTable dtTerminales;

            dtTerminales = lista.Get_Datos("SP_Get_Terminales", parameters);

            o.CargarComboDataTable(this.cboTerminal_Retiro, dtTerminales, "Codigo_Terminal", "Descripcion", false, true, false, false);

        }

        private void Carga_Combo_Modalidades()
        {

            funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            int intEmpresa = 1; //POR AHORA!

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="pIdEmpresa", Value = intEmpresa },
                new MySqlParameter(){ ParameterName="ID", Value = 0 } //SE LE PASA 0(CERO) PARA NO CAMBIAR TODOS LOS PRG. DE MARCO.
            };

            DataTable dtModalidades;

            dtModalidades = lista.Get_Datos("SP_GET_Tipo_Modalidad_ALL", parameters);

            o.CargarComboDataTable(this.cboModalidades, dtModalidades, "Codigo_Modalidad", "Descripcion", false, true, false, false);

        }


        private void Carga_Combo_Terminales_Entrega()
        {

            funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            int intEmpresa = 1; //POR AHORA!

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = intEmpresa },
                new MySqlParameter(){ ParameterName="intOT", Value = DBNull.Value }
            };

            DataTable dtTerminales;

            dtTerminales = lista.Get_Datos("SP_Get_Terminales", parameters);

            o.CargarComboDataTable(this.cboTerminal_Entrega, dtTerminales, "Codigo_Terminal", "Descripcion", false, true, false, false);

        }

        private void cboRutas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarPresupuestos();
        }

        private void btn_AnularItem_Click(object sender, EventArgs e)
        {

                int intEmpresa;
                int intOT;
                int intItemOT;
                //string strMensaje;
                intEmpresa = datos.g_idEmpresa;
                intOT= int.Parse(this.txtNumero_OT.Text);
                intItemOT =Convert.ToInt32(funciones_Varias.GetValorCelda(this.dg,0));

                if (MessageBox.Show("¿Confirmas anular","Atención",MessageBoxButtons.OK) ==DialogResult.OK )
                {
                    DN_Operaciones ope = new DN_Operaciones();
                    ope.IntEmpresa = intEmpresa;
                    ope.IntOT = intOT;
                    ope.IntItemOT = intItemOT;
                    ope.IntUsuario = datos.g_idUser;
                    ope.StrMotivo = Microsoft.VisualBasic.Interaction.InputBox("Informe Motivo de Cancelación del Viaje", "Motivo de Baja", "Autorizado por " + datos.g_lastName.ToString());
                    ope.Baja_OT_Item();
                }
            //ope.liberarCamiones(datos.g_idEmpresa, intTransportista, intTractor, intChasis, intChofer, intEsOW, 0);

        }

        private void cboNroOT_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtNumero_OT.Text = this.cboNroOT.SelectedValue.ToString();
            this.txtNumero_OT.Focus();
            this.FechaOT.Focus();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            int intEmpresa;
            int intOT;

            //string strMensaje;
            intEmpresa = datos.g_idEmpresa;
            intOT = int.Parse(this.txtNumero_OT.Text);


            if (MessageBox.Show("¿Confirmas anular OT Completa", "Atención", MessageBoxButtons.OK) == DialogResult.OK)
            {
                DN_Operaciones ope = new DN_Operaciones();
                ope.IntEmpresa = intEmpresa;
                ope.IntOT = intOT;

                ope.IntUsuario = datos.g_idUser;
                ope.StrMotivo = Microsoft.VisualBasic.Interaction.InputBox("Informe Motivo de Cancelación del Viaje", "Motivo de Baja", "Autorizado por " + datos.g_lastName.ToString());
                ope.Baja_OT();

                funciones_Varias fv = new funciones_Varias();
                fv.Abrir_Form_OT(datos.g_permiso);
                this.Close();
            }
        }

        private void opMoro_CheckedChanged(object sender, EventArgs e)
        {
            bloquear_opMoro(false);
        }
        private void bloquear_opMoro(bool VieneDeConsulta)
        {

            if (VieneDeConsulta)
            {
                return;
            }
            bool IsChecked;
            IsChecked = false;
            if (this.opMoro.CheckState == CheckState.Checked) IsChecked = true;

            foreach (DataGridViewRow row in this.dg.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["Especial"];
                chk.Value = IsChecked;
                chk.ReadOnly = IsChecked;
            }
        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void cboContenedores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboContactos_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void txtObservacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboRazonSocial_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
