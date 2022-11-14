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
using System.IO;
using static k_presentacion_00.funciones_envio_emails;

namespace k_presentacion_00
{
    public partial class frm_PopUp_Designa_Viaje_Conceptos : Form
    {
        public int _Empresa { get; set; }
        public int _OT { get; set; }
        public int _Item { get; set; }
        public int _Corredor { get; set; }
        public Decimal _Costo { get; set; }
        public string _Descripcion_Item { get; set; }

        private int _Trasportista { get; set; }
        private int _Chasis { get; set; }
        private int _Tractor { get; set; }
        private int _Chofer { get; set; }
        public int _IdCliente { get; set; }

        public int _IndTipo { get; set; }


        BindingSource _bindingSource = new BindingSource();

        guardar_datos_login datos = guardar_datos_login.Instance();

        public bool Nro_Conedor_Guardado;

        public string _strBooking { get; set; }

        //DataTable _dtConceptos = new DataTable();

        //DataGridViewComboBoxColumn _colDescripcion_Concepto = new DataGridViewComboBoxColumn();
        public frm_PopUp_Designa_Viaje_Conceptos()
        {
            InitializeComponent();
            Nro_Conedor_Guardado = true;
        }

        private void Configura_Grilla()
        {
            //https://stackoverflow.com/questions/45498268/dataset-and-combobox-of-datagridview

            DataGridViewComboBoxColumn colDescripcion_Concepto = new DataGridViewComboBoxColumn();
            DataGridViewColumn colFecha_Concepto = new clsCalendar_Column();
            DataGridViewColumn colHora_Concepto = new clsTime_Column();
            DataGridViewColumn colCodigo_Concepto = new DataGridViewTextBoxColumn();
            DataGridViewColumn colEstado = new DataGridViewTextBoxColumn();
            DataGridViewCheckBoxColumn colCheck = new DataGridViewCheckBoxColumn();

            //DataGridViewColumn colItem = new DataGridViewTextBoxColumn();
            //DataGridViewColumn colCantidad = new DataGridViewTextBoxColumn();
            //DataGridViewColumn colNumero_Contenedor = new DataGridViewTextBoxColumn();
            //DataGridViewComboBoxColumn colGenerador = new DataGridViewComboBoxColumn();
            //DataGridViewColumn colNumero_Generador = new DataGridViewTextBoxColumn();
            //DataGridViewColumn colPeso_Generador = new DataGridViewTextBoxColumn();
            //DataGridViewColumn colNumero_Precinto = new DataGridViewTextBoxColumn();
            //DataGridViewColumn colPeso_Toneladas = new DataGridViewTextBoxColumn();
            //DataGridViewColumn colFecha_Retiro = new clsCalendar_Column();
            //DataGridViewColumn colHora_Retiro = new clsTime_Column();
            //DataGridViewColumn colCodigo_Contenedor = new DataGridViewTextBoxColumn();
            //DataGridViewColumn colCodigo_Generador = new DataGridViewTextBoxColumn();


            //DataGridViewColumn colEstado = new DataGridViewTextBoxColumn();

            dgw.AutoGenerateColumns = false;
            //grdConceptos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            dgw.Columns.Add(colDescripcion_Concepto);
            dgw.Columns.Add(colCheck);
            dgw.Columns.Add(colFecha_Concepto);
            dgw.Columns.Add(colHora_Concepto);
            dgw.Columns.Add(colCodigo_Concepto);
            dgw.Columns.Add(colEstado);

            //grdConceptos.ColumnCount = 5;
            dgw.Columns[0].Name = "Descripcion_Concepto";
            dgw.Columns[1].Name = "Check";
            dgw.Columns[2].Name = "Fecha_Concepto";
            dgw.Columns[3].Name = "Hora_Concepto";
            dgw.Columns[4].Name = "Codigo_Concepto";
            dgw.Columns[5].Name = "Estado";

            //grdConceptos.Columns[6].DefaultCellStyle.Format = "N2";
            //grdConceptos.Columns[8].DefaultCellStyle.Format = "N2";

            //grdConceptos.Columns[10].DefaultCellStyle.Format = "HH:mm";
            //grdConceptos.Columns[12].DefaultCellStyle.Format = "HH:mm";

            dgw.Columns[0].HeaderText = "Detalle";
            dgw.Columns[1].HeaderText = "Check";
            dgw.Columns[2].HeaderText = "Fecha";
            dgw.Columns[3].HeaderText = "Hora";
            dgw.Columns[4].HeaderText = "Código Concepto";
            dgw.Columns[5].HeaderText = "Estado";


            //grdConceptos.Columns[6].HeaderText = "Estado";

            dgw.Columns["Descripcion_Concepto"].DataPropertyName = "Codigo_Concepto";
            dgw.Columns["Check"].DataPropertyName = "Realizado";
            dgw.Columns["Fecha_Concepto"].DataPropertyName = "Fecha_Concepto";
            dgw.Columns["Hora_Concepto"].DataPropertyName = "Hora_Concepto";
            dgw.Columns["Codigo_Concepto"].DataPropertyName = "Codigo_Concepto";
            dgw.Columns["Estado"].DataPropertyName = "Estado";

            //grdConceptos.Columns["Estado"].DataPropertyName = "Estado";

            //OCULTA COLUMNAS
            dgw.Columns["Descripcion_Concepto"].ReadOnly = true;
            dgw.Columns["Codigo_Concepto"].ReadOnly = true;
            dgw.Columns["Estado"].ReadOnly = true;

            dgw.Columns["Codigo_Concepto"].Visible = false;
            dgw.Columns["Estado"].Visible = false;

            //grdConceptos.Columns["Item"].Visible = false;
            //grdConceptos.Columns["Item"].ReadOnly = true;
            //grdConceptos.Columns["Cantidad"].ReadOnly = true;
            //grdConceptos.Columns["Codigo_Contenedor"].ReadOnly = true;
            //grdConceptos.Columns["Codigo_Generador"].ReadOnly = true;
            //grdConceptos.Columns["Estado"].ReadOnly = true;

            //grdConceptos.Columns["Item"].Width = 10;
            //grdConceptos.Columns["Cantidad"].Width = 10;

            //this.grdConceptos.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.grdConceptos.Columns["Peso_Generador"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.grdConceptos.Columns["Peso_Toneladas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgw.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //SELECTION MODE
            //grdParametros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgw.MultiSelect = false;

            colDescripcion_Concepto.ValueMember = "Codigo_Concepto";
            colDescripcion_Concepto.DisplayMember = "Descripcion";
            colDescripcion_Concepto.DataSource = Carga_Conceptos_Nominar(_Empresa);
            colDescripcion_Concepto.Width = 250;

            //colItem.Width = 5;

            dgw.CellValueChanged += new DataGridViewCellEventHandler(GrdConceptos_CellValueChanged);
            dgw.CurrentCellDirtyStateChanged += new EventHandler(GrdConceptos_CurrentCellDirtyStateChanged);

        }

        //private void Carga_Combo_Conceptos_En_Grilla()
        //{

        //    //PARA CARGAR EL COMBO CON DISTINTOS VALORES POR LÍNEA
        //    //https://stackoverflow.com/questions/43932832/c-sharp-datagridview-combobox-with-different-values-per-row

        //    int intTransportista = 0;
        //    int intTractor = 0;
        //    int intChasis = 0;
        //    int intChofer = 0;

        //    if (this.cboTransportista.SelectedIndex != -1)
        //    {
        //        intTransportista = int.Parse(this.cboTransportista.SelectedValue.ToString());
        //    }

        //    if (this.cboTractores.SelectedIndex != -1)
        //    {
        //        intTractor = int.Parse(this.cboTractores.SelectedValue.ToString());
        //    }

        //    if (this.cboChasis.SelectedIndex != -1)
        //    {
        //        intChasis = int.Parse(this.cboChasis.SelectedValue.ToString());
        //    }

        //    if (this.cboChoferes.SelectedIndex != -1)
        //    {
        //        intChofer = int.Parse(this.cboChoferes.SelectedValue.ToString());
        //    }

        //    _colDescripcion_Concepto.ValueMember = "Codigo_Concepto";
        //    _colDescripcion_Concepto.DisplayMember = "Descripcion";
        //    _colDescripcion_Concepto.DataSource = Carga_Conceptos_Nominar(_Empresa, _OT, _Item, intTransportista, intTractor, intChasis, intChofer );
        //    _colDescripcion_Concepto.Width = 250;

        //}

        private DataTable Carga_Conceptos_Nominar(int intEmpresa)
        {

            funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            DataTable dtConceptos = new DataTable();

            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = intEmpresa },
                new MySqlParameter(){ ParameterName="intActivos", Value = 1 },
                new MySqlParameter(){ ParameterName="intConcepto", Value = DBNull.Value }
                //new MySqlParameter(){ ParameterName="intOT", Value = intOT },
                //new MySqlParameter(){ ParameterName="intItem", Value = intItem },
                //new MySqlParameter(){ ParameterName="intTransportista", Value = intTransportista },
                //new MySqlParameter(){ ParameterName="intTractor", Value = intTractor },
                //new MySqlParameter(){ ParameterName="intChasis", Value = intChasis },
                //new MySqlParameter(){ ParameterName="intChofer", Value = intChofer }
            };

            dtConceptos = lista.Get_Datos("SP_Get_Conceptos_a_Nominar", parameters);
            
            Cursor.Current = Cursors.Default;
            
            return dtConceptos;
        }

        private void Frm_Designa_Viaje_Conceptos_Load(object sender, EventArgs e)
        {
            Inicia();
        }

        private void Inicia()
        {

            BindingSource bindingSource = new BindingSource();

            //this.lblOT.Text = string.Empty;
            //this.lblDescripcion_Item.Text = string.Empty;
            //this.lblCosto.Text = string.Empty;

            //this.lblOT.Text = "OT: " + _OT.ToString().PadLeft(11, '0');
            //this.lblDescripcion_Item.Text = _Descripcion_Item.ToString();
            //this.lblCosto.Text = "COSTO = " + _Costo.ToString();

            Cursor.Current = Cursors.WaitCursor;

            Carga_Combo_Estados_OTs();

            Carga_Datos_OT();

            ocultar_y_bloquear(false);
            //Carga_Combo_Transportistas();
            //Carga_Combo_Choferes();

            Configura_Grilla();

            Carga_Grilla_Conceptos();

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

            o.CargarComboDataTable(this.cboTransportista, p, "id", "Descripcion", false, true);

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

            o.CargarComboDataTable(this.cboTractores, p, "id", "Patente", false, true);

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

            o.CargarComboDataTable(this.cboChasis, p, "id", "Patente", false, true);

        }

        //private void Carga_Combo_Choferes()
        //{

        //    funciones_Varias o = new funciones_Varias();
        //    DNTablas_Gral lista = new DNTablas_Gral();

        //    var parameters = new[]
        //    {
        //        new MySqlParameter(){ ParameterName="pId", Value = DBNull.Value }
        //        //new MySqlParameter(){ ParameterName="intTransportista", Value = intTransportista }
        //    };

        //    DataTable p;

        //    p = lista.Get_Datos("SP_Choferes_All", parameters);

        //    o.CargarComboDataTable(this.cboChoferes, p, "IdChofer", "Apellido", false, true);

        //}

        private void CboTransportista_SelectedValueChanged(object sender, EventArgs e)
        {
            int intTransportista = 0;

            if (this.cboTransportista.SelectedIndex != -1)
            {

                intTransportista = (int)this.cboTransportista.SelectedValue;

                Carga_Combo_Tractores(_Empresa, intTransportista);

            }

        }

        private void CboTractores_SelectedValueChanged(object sender, EventArgs e)
        {

            int intTransportista = 0;

            if (this.cboTransportista.SelectedIndex != -1)
            {

                intTransportista = (int)this.cboTransportista.SelectedValue;

                Carga_Combo_Chasis(_Empresa, intTransportista);
            }

        }

        private void GrdConceptos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex != 0)
                return;

            dgw.CellValueChanged -= new DataGridViewCellEventHandler(GrdConceptos_CellValueChanged);

            DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgw.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (e.ColumnIndex == 0)
            {
                dgw[3, e.RowIndex].Value = cb.Value;
            }

            dgw.CellValueChanged += new DataGridViewCellEventHandler(GrdConceptos_CellValueChanged);

        }

        private void GrdConceptos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

            //if (this.grdConceptos.IsCurrentCellDirty)
            //{
            //    grdConceptos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //}

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void  Grabar()
        {
            //https://www.youtube.com/watch?v=fne9TMDlLN4&feature=push-sd&attr_tag=nMx1KFpTImtfvSZb%3A6

            clsConn cnMarco = new clsConn();

            string strConnection_String;

            strConnection_String = cnMarco.Cadena_Conexion();

            MySqlConnection cnnConnection = new MySqlConnection(strConnection_String);
            cnnConnection.Open();

            MySqlCommand cmdCommand = cnnConnection.CreateCommand();
            MySqlTransaction trsTransaccion;

            //CABECERA
            //int intNumero_OT = 0;
            int intTransportista ;
            int intTractor ;
            int intChasis ;
            int intChofer ;
            int intEstado = 0;
            int intEsOW;
            string strMotivoBaja;

            //DETALLE
            int intItem = 0;
            int intCodigo_Concepto = 0;
            DateTime datFecha;
            string datHora;

            intEsOW = 0;//por default para RT
            
            if (_IndTipo == 1)//OW
            {
                intEsOW = 1;
            }

            intTransportista = int.Parse(this.lbl_ID_Transportista.Text.ToString());
            intTractor = int.Parse(this.lbl_ID_Tractor.Text.ToString());
            intChasis = int.Parse(this.lbl_ID_Chasis.Text.ToString());
            intChofer = int.Parse(this.lbl_ID_Chofer.Text.ToString());



            if (this.cboEstados_OTs.SelectedIndex != -1)
            {
                intEstado = int.Parse(this.cboEstados_OTs.SelectedValue.ToString());
                if (intEstado==4)
                {           
                    strMotivoBaja = Microsoft.VisualBasic.Interaction.InputBox("Informe Motivo de Cancelación del Viaje", "Motivo de Baja", "Autorizado por " + datos.g_lastName.ToString());
                    DN_Operaciones ope = new DN_Operaciones();

                    ope.IntEmpresa = datos.g_idEmpresa;
                    ope.IntOT = _OT;
                    ope.IntItemOT = _Item;
                    ope.IntUsuario = datos.g_idUser;
                    ope.StrMotivo = strMotivoBaja;
                    ope.Baja_OT_Item();

                    ope.liberarCamiones(datos.g_idEmpresa, intTransportista, intTractor, intChasis, intChofer, intEsOW,0);

                    funciones_envio_emails fee = new funciones_envio_emails();
                    int intEventoAdmin = (Int32)funciones_envio_emails.TipoArchivos.E_CANCELACION;

                    fee.Envio_Email_Cuadro_Administracion("SP_Emails_Cancelacion",_Empresa, _OT, _Item, intEventoAdmin, this.lblBL_Booking.Text,"lightorange"); //paso 0 en itemot para que el SP no tome un item especifico

                    return;
                }
                intEstado = int.Parse(this.cboEstados_OTs.SelectedValue.ToString());
                if (intEstado == 2)
                {
                    strMotivoBaja = Microsoft.VisualBasic.Interaction.InputBox("Informe Motivo de Falso Flete", "Motivo del Falso Flete", "Autorizado por " + datos.g_lastName.ToString());
                    DN_Operaciones ope = new DN_Operaciones();

                    ope.IntEmpresa = datos.g_idEmpresa;
                    ope.IntOT = _OT;
                    ope.IntItemOT = _Item;
                    ope.IntUsuario = datos.g_idUser;
                    ope.StrMotivo = strMotivoBaja;
                    ope.DecCostoFF = Convert.ToDecimal(this.txtCostoFF.Text);
                    ope.DecVentaFF = Convert.ToDecimal(this.txtVentaFF.Text);
                    ope.Alta_Falso_Flete();
                    ope.liberarCamiones(datos.g_idEmpresa, intTransportista, intTractor, intChasis, intChofer, intEsOW, 0);

                    funciones_envio_emails fee = new funciones_envio_emails();
                    int intEventoAdmin = (Int32)funciones_envio_emails.TipoArchivos.E_FALSO_FLETE ;

                    fee.Envio_Email_Cuadro_Administracion("SP_Emails_FF", _Empresa, _OT, _Item, intEventoAdmin,this.lblBL_Booking.Text,"lightorange"); //paso 0 en itemot para que el SP no tome un item especifico
                    return;
                }
            }

            intTransportista = int.Parse(this.lbl_ID_Transportista.Text.ToString());
            intTractor = int.Parse(this.lbl_ID_Tractor.Text.ToString());
            intChasis = int.Parse(this.lbl_ID_Chasis.Text.ToString());
            intChofer = int.Parse(this.lbl_ID_Chofer.Text.ToString());

            trsTransaccion = cnnConnection.BeginTransaction();

            cmdCommand.Connection = cnnConnection;
            cmdCommand.Transaction = trsTransaccion;
            cmdCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                cmdCommand.CommandText = "SP_Alta_ItemOT_Conceptos";

                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intOT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intItem", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intTransportista", MySqlDbType.String);
                cmdCommand.Parameters.Add("intTractor", MySqlDbType.String);
                cmdCommand.Parameters.Add("intChasis", MySqlDbType.String);
                cmdCommand.Parameters.Add("intChofer", MySqlDbType.String);
                cmdCommand.Parameters.Add("intCodigo_Concepto", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("datFecha", MySqlDbType.DateTime);
                cmdCommand.Parameters.Add("datHora", MySqlDbType.String);
                cmdCommand.Parameters.Add("intEstado_OT", MySqlDbType.Int16);
                cmdCommand.Parameters.Add("intReqAnticipo", MySqlDbType.Int16);

                cmdCommand.Parameters["intEmpresa"].Value = _Empresa;

                if (_OT != 0)
                {
                    cmdCommand.Parameters["intOT"].Value = _OT;
                }
                else
                {
                    cmdCommand.Parameters["intOT"].Value = DBNull.Value;
                }

                cmdCommand.Parameters["intEstado_OT"].Value = intEstado;

                cmdCommand.Parameters["intItem"].Value = _Item;
                cmdCommand.Parameters["intTransportista"].Value = intTransportista;
                cmdCommand.Parameters["intTractor"].Value = intTractor;
                cmdCommand.Parameters["intChasis"].Value = intChasis;
                cmdCommand.Parameters["intChofer"].Value = intChofer;
                cmdCommand.Parameters["intCodigo_Concepto"].Value = DBNull.Value;
                if (this.opReqAnticipo.Checked==true)
                {
                    cmdCommand.Parameters["intReqAnticipo"].Value = 1;
                }
                else
                {
                    cmdCommand.Parameters["intReqAnticipo"].Value = 0;
                }

                //cmdCommand.ExecuteNonQuery();




                DataGridViewCheckBoxCell checkbox; //= (DataGridViewCheckBoxCell)grdConceptos.CurrentCell;

                bool isChecked = false;

                foreach (DataGridViewRow dgvRenglon in dgw.Rows)
                {

                    checkbox = dgvRenglon.Cells[1] as DataGridViewCheckBoxCell;
                    isChecked = (bool)checkbox.EditedFormattedValue;

                    if (isChecked)
                    { 

                        intItem++;

                        intCodigo_Concepto = int.Parse(dgvRenglon.Cells["Codigo_Concepto"].Value.ToString());
                        datFecha = DateTime.Parse(dgvRenglon.Cells["Fecha_Concepto"].Value.ToString());
                        datHora = dgvRenglon.Cells["Hora_Concepto"].Value.ToString();

                        //cmdCommand.Parameters["intItem"].Value = intItem;
                        cmdCommand.Parameters["intCodigo_Concepto"].Value = intCodigo_Concepto;
                        cmdCommand.Parameters["datFecha"].Value = datFecha;
                        cmdCommand.Parameters["datHora"].Value = datHora;

                        cmdCommand.ExecuteNonQuery();

                    }

                }

                

                trsTransaccion.Commit();

                //Graba el Ultimo
                cmdCommand.CommandText = "SP_Update_Itemot_Conceptos";
                MySqlDataReader leer;

                DataTable p = new DataTable(); 

                leer= cmdCommand.ExecuteReader();
                p.Load(leer);

                leer.Close();
                int intConcepto;
                DataRow dr;

                if (p.Rows.Count > 0)
                {
                    dr = p.Rows[0];
                    intConcepto = Convert.ToInt32(dr[0]);
                }
                else
                {
                    intConcepto = 0;
                }
                //intConcepto =0;



                if ((intConcepto==3 && intEsOW==1) || (intConcepto==6 && intEsOW == 0))
                {
                    finalizaOT(datos.g_idEmpresa, _OT, _Item, intEsOW, intConcepto);


                    frm_Cargar_Estadias frm = new frm_Cargar_Estadias();
                    frm._Empresa = datos.g_idEmpresa;
                    frm._OT = _OT;
                    frm._Item = _Item;
                    frm._Contenedor = this.txtNroContenedor.Text;

                    frm.ShowDialog(this);
                    if (frm.DialogResult != DialogResult.OK)
                    {
                        MessageBox.Show("No se pudo generar el email con los datos de la estadía", "Atención " + datos.g_lastName.ToUpper());
                    }

                }

                

                DNTablas_Gral lista = new DNTablas_Gral();
                DataTable asunto_cuerpo;
                string  direcciones;
                int intEvento;
                string strAsunto;
                string strCuerpo;

                //Con el Ultimo ingresado vamos a invocar el email para que lo envie por email.
                var parameters = new[]
                {
                    new MySqlParameter(){ ParameterName="intEmpresa", Value = _Empresa },
                    new MySqlParameter(){ ParameterName="intOT", Value = _OT },
                    new MySqlParameter(){ ParameterName="intItemOT", Value = _Item },
                    new MySqlParameter(){ ParameterName="intDestino", Value = 0 },
                    new MySqlParameter(){ ParameterName="intConcepto", Value = intConcepto }
                };

                asunto_cuerpo = lista.Get_Datos("SP_Emails_Con_Conceptos", parameters);
                if (asunto_cuerpo.Rows.Count > 0)
                {
                    dr = asunto_cuerpo.Rows[0];
                    intEvento = Convert.ToInt32(dr[0]);
                    strAsunto = dr[1].ToString();
                    strCuerpo = dr[2].ToString();
                    //Armo las direcciones de email
                    funciones_envio_emails e = new funciones_envio_emails();
                    direcciones = e.armar_Cadena_Emails("SP_Emails_Direcciones", _Empresa, intEvento, _IdCliente, "intCliente");
                                       

                    if (intEvento==(Int32)funciones_envio_emails.TipoArchivos.E_FIN_VIAJE_OW && this.lblTipo_Modalidad.Text=="OW")
                    {
                        e.Envio_Email_Cuadro_Control(_Empresa, _OT, _strBooking, _IdCliente, -2,2,0, (Int32)funciones_envio_emails.TipoArchivos.E_FIN_VIAJE_OW,"lightgreen");//paso 0 en itemot para que el SP no tome un item especifico
                    }
                    else if (intEvento == (Int32)funciones_envio_emails.TipoArchivos.E_FIN_VIAJE_RT && this.lblTipo_Modalidad.Text == "RT")
                    {
                        e.Envio_Email_Cuadro_Control(_Empresa, _OT, _strBooking, _IdCliente, -2, 2,0, (Int32)funciones_envio_emails.TipoArchivos.E_FIN_VIAJE_RT,"lightgreen");//paso 0 en itemot para que el SP no tome un item especifico
                    }
                    else
                    {
                        e.SendEmailWithOutlook(direcciones, strAsunto, strCuerpo, string.Empty, false);
                    }
                    

                    //funciones_envio_emails fee = new funciones_envio_emails();
                    

                }
                // 
                //fee.Envio_Email_Cuadro_Control(_Empresa, _OT, _strBooking, _IdCliente, 0, 0, (Int32)funciones_envio_emails.TipoArchivos.E_NOMINACION);//paso 0 en itemot para que el SP no tome un item especifico
                //libero el camión.
                DN_Operaciones ope = new DN_Operaciones();
                ope.liberarCamiones(datos.g_idEmpresa, intTransportista, intTractor, intChasis, intChofer, intEsOW, intConcepto);
                //
                //finalizaOT(datos.g_idEmpresa, _OT, _Item, intEsOW, intConcepto);

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
        private void finalizaOT(int intEmpresa,int intOT,int intItem,int intEsOW,int intConcepto)
        {
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
            try
            {
                cmdCommand.CommandText = "SP_OT_Item_Finaliza";

                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intOT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intItem_OT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intEsOW", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intConcepto", MySqlDbType.Int32);

                cmdCommand.Parameters["intEmpresa"].Value = intEmpresa;
                cmdCommand.Parameters["intOT"].Value = intOT;
                cmdCommand.Parameters["intItem_OT"].Value = intItem;
                cmdCommand.Parameters["intEsOW"].Value = intEsOW;
                cmdCommand.Parameters["intConcepto"].Value = intConcepto;

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

        private void BtnGrabar_Click(object sender, EventArgs e)
        {

            if ( !Valida() ) { return; };

            Grabar();
            ocultar_y_bloquear(false);
        }

        //private void Agrega_Linea_En_Grilla()
        //{

        //    //https://es.stackoverflow.com/questions/159484/no-puedo-agregar-filas-a-un-datagridview

        //    DataTable dt = _bindingSource.DataSource as DataTable;

        //    DataRow row = dt.NewRow();

        //    row["Codigo_Concepto"] = 2;
        //    row["Fecha_Concepto"] = DateTime.Now;
        //    row["Hora_Concepto"] = DateTime.Now.ToString("hh:mm");
        //    row["Desc_Concepto"] = 2;

        //    dt.Rows.Add(row);

        //    _bindingSource.DataSource = dt;

        //    grdConceptos.DataSource = null;  
        //    grdConceptos.DataSource = _dtConceptos;

        //}

        private void GrdConceptos_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }

        private void BtnInsertar_Linea_Click(object sender, EventArgs e)
        {
            //Carga_Combo_Conceptos_En_Grilla();
            //Agrega_Linea_En_Grilla();
        }

        private void CboChoferes_SelectedValueChanged(object sender, EventArgs e)
        {

            //Carga_Grilla_Conceptos();

        }

        //private void Carga_Grilla_Conceptos()
        //{
        //    //COMO CARGAR LA GRILLA
        //    //https://stackoverflow.com/questions/19941569/populate-datagridview-combobox

        //    //combo
        //    //https://www.akadia.com/services/dotnet_combobox_in_datagrid.html

        //    int intTransportista = 0;
        //    int intTractor = 0;
        //    int intChasis = 0;
        //    int intChofer = 0;
        //    int intItem = 1;

        //    funciones_Varias o = new funciones_Varias();
        //    DNTablas_Gral lista = new DNTablas_Gral();

        //    if (this.cboTransportista.SelectedIndex != -1)
        //    {
        //        intTransportista = int.Parse(this.cboTransportista.SelectedValue.ToString());
        //    }

        //    if (this.cboTractores.SelectedIndex != -1)
        //    {
        //        intTractor = int.Parse(this.cboTractores.SelectedValue.ToString());
        //    }

        //    if (this.cboChasis.SelectedIndex != -1)
        //    {
        //        intChasis = int.Parse(this.cboChasis.SelectedValue.ToString());
        //    }

        //    if (this.cboChoferes.SelectedIndex != -1)
        //    {
        //        intChofer = int.Parse(this.cboChoferes.SelectedValue.ToString());
        //    }

        //    var parameters = new[]
        //    {
        //        new MySqlParameter(){ ParameterName="intEmpresa", Value = _Empresa },
        //        new MySqlParameter(){ ParameterName="intOT", Value = _OT },
        //        new MySqlParameter(){ ParameterName="intTransportista", Value = intTransportista },
        //        new MySqlParameter(){ ParameterName="intTractor", Value = intTractor },
        //        new MySqlParameter(){ ParameterName="intChasis", Value = intChasis },
        //        new MySqlParameter(){ ParameterName="intChofer", Value = intChofer },
        //        new MySqlParameter(){ ParameterName="intItem", Value = _Item }
        //    };

        //    DataTable dtConceptos;

        //    dtConceptos = lista.Get_Datos("SP_Carga_ItemOT_Conceptos", parameters);

        //    //_bindingSource.DataSource = null;
        //    //_bindingSource.DataSource = dtConceptos;

        //    grdConceptos.DataSource = dtConceptos;

        //    //_dtConceptos = grdConceptos.DataSource as DataTable;

        //}

        private void BtnCargar_Conceptos_Click(object sender, EventArgs e)
        {
            //Carga_Combo_Conceptos_En_Grilla();
            Carga_Grilla_Conceptos();
        }

        private void Elimina_Lineas_En_Grilla()
        {
            dgw.Rows.RemoveAt(dgw.CurrentRow.Index);
        }

        private void BtnEliminar_Linea_Click(object sender, EventArgs e)
        {
            Elimina_Lineas_En_Grilla();
        }

        private void GrdConceptos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            dgw.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (e.ColumnIndex == 1)
            {

                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dgw.CurrentCell;

                bool isChecked = (bool)checkbox.EditedFormattedValue;
                int intConcepto=0;
                if (isChecked)
                {
                    //verificar el concepto.
                    intConcepto = (Int32)dgw[0, e.RowIndex].Value;

                    if (intConcepto==1 && lblNominacion.Text == "NO")
                    {
                        MessageBox.Show("No se puede iniciar el viaje si no envia el email al cliente con los datos de Nominación", "Atención");
                        dgw[1, e.RowIndex].Value = 0;
                        SendKeys.Send("{ESC}");
                        return;
                    }
  
                    if (intConcepto>1 && this.txtNroContenedor.Text== "")
                    {
                        MessageBox.Show("No puede continuar si no informa el contenedor","Atención",MessageBoxButtons.OK );
                        this.txtNroContenedor.Focus();
                        dgw[1, e.RowIndex].Value = 0;
                        Nro_Conedor_Guardado = false;
                        SendKeys.Send("{ESC}");
                        return;
                    }
                    if (Nro_Conedor_Guardado == false)
                    {
                        MessageBox.Show("No guardo el Nro de Contenedor", "Atención", MessageBoxButtons.OK);
                        this.txtNroContenedor.Focus();
                        return;
                    }
                    if ((this.lblTipo_Modalidad.Text=="OW" && intConcepto==3 && this.opReqAnticipo.Checked==true)||(this.lblTipo_Modalidad.Text == "RT" && intConcepto == 6 && this.opReqAnticipo.Checked == true))
                    {
                        MessageBox.Show("No se puede finalizar el viaje porque requiere cargar Anticipo", "Atención", MessageBoxButtons.OK);
                        dgw[1, e.RowIndex].Value = 0;
                        return;
                    }

                                                   

                    dgw[2, e.RowIndex].Value = DateTime.Now.ToString("dd/MM/yyyy");
                    dgw[3, e.RowIndex].Value = DateTime.Now.ToString("HH:mm");
                    Grabar();


                }
                else
                {
                    dgw[1, e.RowIndex].Value = 0;
                    dgw[2, e.RowIndex].Value = DBNull.Value;
                    dgw[3, e.RowIndex].Value = DBNull.Value;
                }

            }

        }

        private void GrdConceptos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GrdConceptos_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void Carga_Datos_OT()
        {

            funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            BindingSource bindingSource = new BindingSource();

            System.Data.DataSet dsOTs = new System.Data.DataSet("OTs");

            DataTable p;

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = _Empresa },
                new MySqlParameter(){ ParameterName="intNumero_OT", Value = _OT },
                new MySqlParameter(){ ParameterName="intItem_OT", Value = _Item  }
            };

            p = lista.Get_Datos("SP_GET_OT_POR_ITEM", parameters);

            dsOTs.Tables.Add(p);

            bindingSource.DataSource = dsOTs.Tables["Table1"];

            //this.lblOT.Text = "OT: " + _OT.ToString().PadLeft(11, '0');
            //this.lblDescripcion_Item.Text = _Descripcion_Item.ToString();
            //this.lblCosto.Text = "COSTO = " + _Costo.ToString();

            this.lblOT.DataBindings.Clear();
            this.lblDescripcion_Item.DataBindings.Clear();
            this.lblCosto.DataBindings.Clear();
            this.lblTransportista.DataBindings.Clear();
            this.lblTractor.DataBindings.Clear();

            this.lbl_ID_Transportista.DataBindings.Clear();
            this.lbl_ID_Chasis.DataBindings.Clear();
            this.lbl_ID_Tractor.DataBindings.Clear();
            this.lbl_ID_Chofer.DataBindings.Clear();

            this.lblOT.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["OT_Con_Mascara"].ColumnName));
            this.lblDescripcion_Item.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Desc_Cliente"].ColumnName));
            this.lblCosto.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Costo"].ColumnName));
            this.lblTransportista.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Desc_Transportista"].ColumnName));
            this.lblTractor.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Desc_Tractor"].ColumnName));
            this.lblChasis.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Desc_Chasis"].ColumnName));
            this.lblChofer.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Desc_Chofer"].ColumnName));

            this.lbl_ID_Transportista.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Transportista"].ColumnName));
            this.lbl_ID_Chasis.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Chasis"].ColumnName));
            this.lbl_ID_Tractor.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Tractor"].ColumnName));
            this.lbl_ID_Chofer.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Chofer"].ColumnName));

            this.txtNroContenedor.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["NroContenedor"].ColumnName));

            this.txtNroPrecinto.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["NroPrecinto"].ColumnName));
            this.txtNroPrecintoVacio.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["NroPrecintoEmpty"].ColumnName));

            this.lblBL_Booking.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["BL_Booking"].ColumnName));

            this.opReqAnticipo.DataBindings.Add(new Binding("Checked", bindingSource, ((DataTable)bindingSource.DataSource).Columns["reqAnticipo"].ColumnName));

            this.lblTipo_Modalidad.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["dTipo_Modalidad"].ColumnName));

            this.lblNominacion.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Fecha_Email_Nominacion"].ColumnName));

            //MPS 2021-12-16
            this.lblTieneAnticipo.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Tiene_Anticipo"].ColumnName));
            this.lblTieneFactura.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Tiene_Factura"].ColumnName));

      
            this.cboEstados_OTs.DataBindings.Clear();
            //ED 2022-08-29
            this.lblTipoServicio.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["TipoServicio"].ColumnName));
            //ED 2022-09-08 cargamos datos a los labels;
            this.lblFechaPosicion.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["PosFecha"].ColumnName));
            this.lblFechaRetiro.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["RetiroFecha"].ColumnName));
            this.lblHoraPosicion.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["PosHora"].ColumnName));
            //this.cboRazonSocial.DataBindings.Clear();
            //this.cboContactos.DataBindings.Clear();
            //this.cboPresupuesto.DataBindings.Clear();
            //this.cboRutas.DataBindings.Clear();
            //this.cboTipoServicio.DataBindings.Clear();
            //this.cboMercaderias.DataBindings.Clear();

            //this.datFecha.DataBindings.Clear();
            //this.datFecha_Vencimiento.DataBindings.Clear();

            //this.txtCosto.DataBindings.Clear();
            //this.txtImporte.DataBindings.Clear();
            //this.txtObservacion.DataBindings.Clear();

            //TEXTBOX
            //this.txtObservacion.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Observacion"].ColumnName));

            //COMBOS
            this.cboEstados_OTs.DataBindings.Add(new Binding("SelectedValue", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Estado_OT"].ColumnName));
            //this.cboRazonSocial.DataBindings.Add(new Binding("SelectedValue", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Cod_Cliente"].ColumnName));
            //this.cboPresupuesto.DataBindings.Add(new Binding("SelectedValue", bindingSource, ((DataTable)bindingSource.DataSource).Columns["IdCotizacion"].ColumnName));
            //this.cboTipoServicio.DataBindings.Add(new Binding("SelectedValue", bindingSource, ((DataTable)bindingSource.DataSource).Columns["TipoServicio"].ColumnName));

            //CAMPOS NUMÉRICOS
            //this.txtCosto.DataBindings.Add(new Binding("Value", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Costo"].ColumnName));
            //this.txtImporte.DataBindings.Add(new Binding("Value", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Venta"].ColumnName));

            //Fechas
            //this.datFecha.DataBindings.Add(new Binding("Value", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Fecha"].ColumnName));
            //this.datFecha_Vencimiento.DataBindings.Add(new Binding("Value", bindingSource, ((DataTable)bindingSource.DataSource).Columns["Fecha"].ColumnName));

            this.Text = "Orden de Transporte: " + this.lblOT.Text;

            this.lblItem.Text = _Item.ToString();
        }

        private void Carga_Grilla_Conceptos()
        {
            //COMO CARGAR LA GRILLA
            //https://stackoverflow.com/questions/19941569/populate-datagridview-combobox

            //combo
            //https://www.akadia.com/services/dotnet_combobox_in_datagrid.html

            int intTransportista = 0;
            int intTractor = 0;
            int intChasis = 0;
            int intChofer = 0;
            //int intVarTipo = 0;
            //int intItem = 1;

            funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            intTransportista = int.Parse(this.lbl_ID_Transportista.Text.ToString());
            intTractor = int.Parse(this.lbl_ID_Tractor.Text.ToString());
            intChasis = int.Parse(this.lbl_ID_Chasis.Text.ToString());
            intChofer = int.Parse(this.lbl_ID_Chofer.Text.ToString());
            MySqlParameter[] Parametros = new MySqlParameter[8];


            Parametros[0] = new MySqlParameter("intEmpresa", _Empresa);
            Parametros[1] = new MySqlParameter("intOT",  _OT);
            Parametros[2] = new MySqlParameter("intTransportista", intTransportista);
            Parametros[3] = new MySqlParameter("intTractor", intTractor);
            Parametros[4] = new MySqlParameter("intChasis",  intChasis);
            Parametros[5] = new MySqlParameter("intChofer",  intChofer);
            Parametros[6] = new MySqlParameter("intItem",  _Item);
            if (_IndTipo == 2)//RW
            {
                Parametros[7] = new MySqlParameter("intEsOW", DBNull.Value);
            }
            else
            {
                Parametros[7] = new MySqlParameter("intEsOW",1);
            }
            
           

            DataTable dtConceptos;

            dtConceptos = lista.Get_Datos("SP_Carga_ItemOT_Conceptos", Parametros);

            dgw.DataSource = dtConceptos;

        }

        private void Carga_Combo_Estados_OTs()
        {
            cboEstados_OTs.SelectedValueChanged -= cboEstados_OTs_SelectedValueChanged;
        
        funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intEstado", Value = DBNull.Value },
                new MySqlParameter(){ ParameterName="intActivos", Value = 1 }
            };

            DataTable p;

            p = lista.Get_Datos("SP_GET_ESTADOS_OTS_ALL", parameters);

            o.CargarComboDataTable(this.cboEstados_OTs, p, "id", "Descripcion", false,false);
            cboEstados_OTs.SelectedValueChanged += cboEstados_OTs_SelectedValueChanged;
        }

        private Boolean Valida()
        {

            Boolean blnSenial = false;

            MessageBoxButtons button = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Error;

            if (this.cboEstados_OTs.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Estado válido para la Orden de Transporte ", "Error", button, icon);
            }
            else
            {
                blnSenial = true; 
            }

            if (Convert.ToInt32(this.cboEstados_OTs.SelectedValue)==4)
            {
                if (datos.g_permiso > 2) 
                {
                    MessageBox.Show("No tiene permiso para realizar la anulación. Debe ser un Administrador o alguien de Gerencia", "Atención", MessageBoxButtons.OK);
                    blnSenial = false;
                }
            }
            if (Convert.ToInt32(this.cboEstados_OTs.SelectedValue) == 2)
            {
                if (datos.g_permiso > 2)
                {
                    MessageBox.Show("No tiene permiso para informar un falso flete. Debe ser un Administrador o alguien de Gerencia", "Atención", MessageBoxButtons.OK);
                    blnSenial = false;
                }
                else
                {
                    decimal decCostoFF;
                    decimal.TryParse(this.txtCostoFF.Text,out decCostoFF);

                    decimal decVentaFF;
                    decimal.TryParse(this.txtVentaFF.Text, out decVentaFF);

                    if (decCostoFF>decVentaFF || decCostoFF==0 || decVentaFF==0 || decCostoFF<0 || decVentaFF <0)
                    {
                        MessageBox.Show("Revise los valores de referencia. ", "Atención", MessageBoxButtons.OK);
                        blnSenial = false;
                    }
                }
            }



            return blnSenial;
        }

        private void Abre_Genera_Anticipo(object sender, EventArgs e)
        {
            if (this.txtNroContenedor.Text == "")
            {
                MessageBox.Show("NO puede generar un anticipo si no esta el número de CONTENEDOR informado","Atención",MessageBoxButtons.OK);
                return;
            }
            var btn = (Button)sender;
            int int_Tag = Convert.ToInt32(btn.Tag);




            frmAlta_Anticipo fAnticipos = new frmAlta_Anticipo();

            fAnticipos._Empresa = _Empresa;
            fAnticipos._OT = _OT;
            fAnticipos._Item = _Item;
            fAnticipos._Descripcion_Item = _Descripcion_Item;
            fAnticipos._Contenedor = this.txtNroContenedor.Text;
            fAnticipos._intTransportista = Convert.ToInt32(this.lbl_ID_Transportista.Text);
            fAnticipos._int_Activo_Anticipo = int_Tag;

            fAnticipos.ShowDialog(this);
            if (fAnticipos.DialogResult==DialogResult.OK)
            {
                this.opReqAnticipo.Checked = false;
            }
            

        }

        private void cmdGuardar_Contenedor_Click(object sender, EventArgs e)
        {
            string msg;
            string strContenedor;
            string strPrecinto;
            string strPrecintoEmpty;
     


            if (this.opDual.CheckState != CheckState.Checked)
            {
                if (this.txtNroContenedor.Text == string.Empty)
                {
                    MessageBox.Show("No se puede guardar el contenedor, el valor no puede estar vacío", "Atención", MessageBoxButtons.OK);
                    return;
                }
                if (this.txtNroContenedor.Text.Length != 11)
                {
                    MessageBox.Show("No se puede guardar el contenedor, el valor código debe ser de 4 Letras (AAAA) y 7 Números (1234567)", "Atención", MessageBoxButtons.OK);
                    return;
                }
            }

            string buscar = "-";
            int exist;
            if (this.opDual.CheckState == CheckState.Checked)
            {
                exist = this.txtNroPrecinto.ToString().IndexOf(buscar);
                if (exist == -1)
                {
                    MessageBox.Show("El precinto debe estar informado con un guión divisor ####### - ###### ", "Atención", MessageBoxButtons.OK);
                    return;
                }
            }


            msg = "¿Desea grabar el Nº de Contenedor y Precinto?";
            if (MessageBox.Show(msg, "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            //valido existe contenedor en curso
            DataTable p;
            DNTablas_Gral lista = new DNTablas_Gral();
            var parameters = new[]
{
                new MySqlParameter(){ ParameterName="intEmpresa", Value = datos.g_idEmpresa},
                new MySqlParameter(){ ParameterName="strNroContenedor", Value = this.txtNroContenedor.Text},
                new MySqlParameter(){ ParameterName="intOT", Value = this.lblOT.Text},
                new MySqlParameter(){ ParameterName="intItem", Value = this.lblItem.Text}
            };

            p = lista.Get_Datos("SP_Valida_Existe_Contenedor", parameters);
            if (p.Rows.Count>0)
            {
                MessageBox.Show("No se puede guardar el contenedor " + this.txtNroContenedor.Text + " por que esta en otra OT en curso", "Atención", MessageBoxButtons.OK);
                return;
            }
            ///////////////////////////

            clsConn cnMarco = new clsConn();

            String strConnection_String;

            strConnection_String = cnMarco.Cadena_Conexion();

            MySqlConnection cnnConnection = new MySqlConnection(strConnection_String);
            cnnConnection.Open();

            MySqlCommand cmdCommand = cnnConnection.CreateCommand();
            MySqlTransaction trsTransaccion;

            trsTransaccion = cnnConnection.BeginTransaction();
            strContenedor = this.txtNroContenedor.Text.ToString();
            strPrecinto = this.txtNroPrecinto.Text.ToString();
            strPrecintoEmpty = this.txtNroPrecintoVacio.Text.ToString();
            cmdCommand.Connection = cnnConnection;
            cmdCommand.Transaction = trsTransaccion;
            cmdCommand.CommandType = CommandType.StoredProcedure;
            
            try
            {
                cmdCommand.CommandText = "SP_UPDATE_Contenedor_Precinto";

                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intOT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intItem", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("strContenedor", MySqlDbType.String);
                cmdCommand.Parameters.Add("strPrecinto", MySqlDbType.String);
                cmdCommand.Parameters.Add("strPrecintoEmpty", MySqlDbType.String);

                cmdCommand.Parameters["intEmpresa"].Value = _Empresa;
                cmdCommand.Parameters["intOT"].Value = _OT;
                cmdCommand.Parameters["intItem"].Value = _Item;
                cmdCommand.Parameters["strContenedor"].Value = strContenedor;
                cmdCommand.Parameters["strPrecinto"].Value = strPrecinto;
                cmdCommand.Parameters["strPrecintoEmpty"].Value = strPrecintoEmpty;


                cmdCommand.ExecuteNonQuery();
                trsTransaccion.Commit();
                Nro_Conedor_Guardado = true;
             
                funciones_envio_emails fee = new funciones_envio_emails();
                //DDE 2022/09/13 
                fee.Envio_Email_Cuadro_Control(_Empresa, _OT, _strBooking,_IdCliente,0,0,Convert.ToInt32(this.lblTipoServicio.Text), (Int32)funciones_envio_emails.TipoArchivos.E_NOMINACION,"lightblue");//paso 0 en itemot para que el SP no tome un item especifico
           
            }
            catch (Exception ex)
            {
                try
                {
                    trsTransaccion.Rollback();
                }
                catch (MySqlException ex_mysql)
                {
                    if (trsTransaccion.Connection != null)
                    {
                        Console.WriteLine("Error" + ex_mysql.GetType());
                    }
                }

                Console.WriteLine("Error" + ex.GetType());
            }
            finally
            {
                cnnConnection.Close();
            }

           

        }

        private void btnCambioNominacion_Click(object sender, EventArgs e)
        {
            frmCambioNominacion f = new frmCambioNominacion();
            f._Empresa = datos.g_idEmpresa; 
            f._OT = _OT ;
            f._Item = _Item ;
            f._Corredor = _Corredor;
            f._Costo = _Costo;
            f._codigo_Transportista = Convert.ToInt32(this.lbl_ID_Transportista.Text) ;
            f._nombre_Transportista = this.lblTransportista.Text ;
            f._codigo_Tractor = Convert.ToInt32(this.lbl_ID_Tractor.Text);
            f._nombre_Tractor = this.lblTractor.Text; 
            f._codigo_Chasis = Convert.ToInt32(this.lbl_ID_Chasis.Text);
            f._nombre_Chasis = this.lblChasis.Text;
            f._codigo_Chofer = Convert.ToInt32(this.lbl_ID_Chofer.Text);
            f._nombre_Chofer = this.lblChofer.Text;
            f._BLBooking = this.lblBL_Booking.Text;
            f._IdCliente = _IdCliente;
            //dde 08/09/22
            f._FechaPosicion = this.lblFechaPosicion.Text;
            f._FechaRetiro = this.lblFechaRetiro.Text;
            f._HoraPosicion = this.lblHoraPosicion.Text;
            //

            f.ShowDialog(this);

            this.Close();
        }

        private void dgw_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            //MessageBox.Show("Error happened " + anError.Context.ToString());

            //if (anError.Context == DataGridViewDataErrorContexts.Commit)
            //{
            //    MessageBox.Show("Commit error");
            //}
            //if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            //{
            //    MessageBox.Show("Cell change");
            //}
            //if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            //{
            //    MessageBox.Show("parsing error");
            //}
            //if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            //{
            //    MessageBox.Show("leave control error");
            //}

            //if ((anError.Exception) is ConstraintException)
            //{
            //    DataGridView view = (DataGridView)sender;
            //    view.Rows[anError.RowIndex].ErrorText = "an error";
            //    view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

            //    anError.ThrowException = false;
            //}
            if (anError.Exception != null &&
                            anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                anError.Cancel = true;
            }
                
        }

        private void cboEstados_OTs_SelectedValueChanged(object sender, EventArgs e)
        {
            int new_estado;
            new_estado = Convert.ToInt32(this.cboEstados_OTs.SelectedValue);
            if (new_estado==2)
            {
                ocultar_y_bloquear(true);
            }
            else
            {
                ocultar_y_bloquear(false);
            }
        }
        private void ocultar_y_bloquear(bool a)
        {
            //true
            this.txtCostoFF.Visible = a;
            this.txtVentaFF.Visible = a;
            this.lblCostoFF.Visible = a;
            this.lblVentaFF.Visible = a;

            this.dgw.Enabled = !a;
            this.cmdGuardar_Contenedor.Enabled = !a;
            this.btnCambioNominacion.Enabled = !a;
            this.btnGenera_Anticipo_Transf.Enabled = !a;

            if (datos.g_permiso <= 3)
            {
                this.opReqAnticipo.Enabled = true;
            }
            else
            {
                this.opReqAnticipo.Enabled = false;
            }
        }

        private void opDual_CheckedChanged(object sender, EventArgs e)
        {
            if (this.opDual.CheckState == CheckState.Checked)
            {
                this.txtNroContenedor.Mask = ">LLLL000000 - >LLLL000000";
            }
            else
            {
                this.txtNroContenedor.Mask = ">LLLL000000";
            }

        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {


            
                string strContenedor;
                string strPrecinto;
                string strPrecintoEmpty;

               
                ///////////////////////////

                clsConn cnMarco = new clsConn();

                String strConnection_String;

                strConnection_String = cnMarco.Cadena_Conexion();

                MySqlConnection cnnConnection = new MySqlConnection(strConnection_String);
                cnnConnection.Open();

                MySqlCommand cmdCommand = cnnConnection.CreateCommand();
                MySqlTransaction trsTransaccion;

                trsTransaccion = cnnConnection.BeginTransaction();
                strContenedor = this.txtNroContenedor.Text.ToString();
                strPrecinto = this.txtNroPrecinto.Text.ToString();
                strPrecintoEmpty = this.txtNroPrecintoVacio.Text.ToString();
                cmdCommand.Connection = cnnConnection;
                cmdCommand.Transaction = trsTransaccion;
                cmdCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    if (this.lblTieneFactura.Text == "1" || this.lblTieneAnticipo.Text == "1")
                    {
                        MessageBox.Show("Este viaje ya fue descargado para Administración. De aviso del cambio.");
                        cmdCommand.CommandText = "SP_cambio_contenedores_precintos_add";

                        cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                        cmdCommand.Parameters.Add("intOT", MySqlDbType.Int32);
                        cmdCommand.Parameters.Add("intItem", MySqlDbType.Int32);
                        cmdCommand.Parameters.Add("intUsuario", MySqlDbType.Int32);
                        cmdCommand.Parameters.Add("strContenedor_Nuevo", MySqlDbType.String);
                        
                                           
                        cmdCommand.Parameters.Add("strPrecintoEmpty_Nuevo", MySqlDbType.String);

                        cmdCommand.Parameters.Add("strPrecinto_Nuevo", MySqlDbType.String);

                        cmdCommand.Parameters.Add("strBooking", MySqlDbType.String);
                        cmdCommand.Parameters.Add("strObservacion", MySqlDbType.String);


                        cmdCommand.Parameters["intEmpresa"].Value = _Empresa;
                        cmdCommand.Parameters["intOT"].Value = _OT;
                        cmdCommand.Parameters["intItem"].Value = _Item;
                        cmdCommand.Parameters["intUsuario"].Value = datos.g_idUser;
                        cmdCommand.Parameters["strContenedor_Nuevo"].Value = strContenedor;
                        cmdCommand.Parameters["strPrecinto_Nuevo"].Value = strPrecinto;
                        cmdCommand.Parameters["strPrecintoEmpty_Nuevo"].Value = strPrecintoEmpty;
                        cmdCommand.Parameters["strBooking"].Value = _strBooking;
                        cmdCommand.Parameters["strObservacion"].Value = "Cambio de Contenedor y/o Precinto " + datos.g_lastName.ToString();



                        cmdCommand.ExecuteNonQuery();

                    string strCuerpo;
                    strCuerpo = string.Concat("OT: ", _OT, Environment.NewLine, "Item: ", _Item, Environment.NewLine, "Contenedor Nuevo: ", strContenedor, " Precinto Nuevo:", strPrecinto);

                    funciones_envio_emails fee = new funciones_envio_emails();
                    fee.SendEmailWithOutlook(datos.g_Email_Administracion, "Cambio de Contenedores " + _strBooking, strCuerpo, string.Empty, true);

                }

                    cmdCommand.Parameters.Clear();
                          

                    cmdCommand.CommandText = "SP_Limpiar_Contenedor_Precinto";
                    cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                    cmdCommand.Parameters.Add("intOT", MySqlDbType.Int32);
                    cmdCommand.Parameters.Add("intItem", MySqlDbType.Int32);

                    cmdCommand.Parameters["intEmpresa"].Value = _Empresa;
                    cmdCommand.Parameters["intOT"].Value = _OT;
                    cmdCommand.Parameters["intItem"].Value = _Item;

                    cmdCommand.ExecuteNonQuery();

                    trsTransaccion.Commit();
                    cnnConnection.Close();

                   

                    this.txtNroContenedor.Text = string.Empty;
                    this.txtNroPrecinto.Text = string.Empty;

                }
                catch (Exception ex)
                {
                    trsTransaccion.Rollback();
                    MessageBox.Show("Error Crítico " + ex.Message.ToString(), "Atención");
                    cnnConnection.Close();
                    
                }


            
        }

        private void lblTipoServicio_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblDescripcion_Item_Click(object sender, EventArgs e)
        {

        }

        private void lblTieneAnticipo_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void lblOT_Click(object sender, EventArgs e)
        {

        }

        private void lblFechaPosicion_Click(object sender, EventArgs e)
        {

        }

        private void lblHoraPosicion_Click(object sender, EventArgs e)
        {

        }
    }
}
