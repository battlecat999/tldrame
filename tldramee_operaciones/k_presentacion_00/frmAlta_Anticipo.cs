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
using k_presentacion_00;
using System.Windows;

namespace k_presentacion_00
{

    public partial class frmAlta_Anticipo : Form
    {
        guardar_datos_login datos = guardar_datos_login.Instance();

        //DataGridViewComboBoxEditingControl dgvCombo;
        public int _Empresa { get; set; }
        public int _OT { get; set; }
        public int _Item { get; set; }
        public string _Descripcion_Item { get; set; }
        public int _Corredor { get; set; }
        public int _intTransportista { get; set; }
        public string _Contenedor { get; set; }
        public int _int_Activo_Anticipo { get; set; }

        public frmAlta_Anticipo()
        {
            InitializeComponent();
        }

        private void FrmAlta_Anticipo_Load(object sender, EventArgs e)
        {

            Inicia();

        }

        private void Inicia()
        {
            bool boolCheque;
            this.lblOT.Text = string.Empty;
            this.lblDescripcion_Item.Text = string.Empty;

            this.lblOT.Text = "OT: " + _OT.ToString().PadLeft(4, '0');
            this.lblDescripcion_Item.Text = _Descripcion_Item.ToString();
            this.lblContenedor.Text = _Contenedor;
            this.lblTransportista.Text = _intTransportista.ToString();
            this.lblTipoViajeEspecial.Visible = false;

            boolCheque = false;
            if (_int_Activo_Anticipo == 3 || _int_Activo_Anticipo == 4)
            {
                boolCheque = true;
            }
            Configura_Grilla(boolCheque);

            Carga_Datos_Anticipo();

            funciones_Varias f = new funciones_Varias();
            int intEsMoro;
            intEsMoro = f.Carga_Si_Requiere_Moro(_Empresa, _OT, _Item);
            if (intEsMoro == 1)
            {
                this.lblEsMoro.Text = intEsMoro.ToString();
                this.lblTipoViajeEspecial.Visible = true;
            }

        }

        private void Carga_Datos_Anticipo()
        {

            funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            BindingSource bindingSource = new BindingSource();

            System.Data.DataSet dsAnticipos = new System.Data.DataSet("Anticipos");

            DataTable p;

            var parameters = new[]
            {
                    new MySqlParameter(){ ParameterName="intEmpresa", Value = _Empresa },
                    new MySqlParameter(){ ParameterName="intOT", Value = _OT },
                    new MySqlParameter(){ ParameterName="intItem_OT", Value = _Item  },
                    new MySqlParameter(){ ParameterName="intActualizacion_Web", Value = 0  }
                    //new MySqlParameter(){ ParameterName="intNumero_OT", Value = _Corredor}
                };

            p = lista.Get_Datos("SP_Get_Anticipos_OT", parameters);

            dsAnticipos.Tables.Add(p);

            bindingSource.DataSource = dsAnticipos.Tables["rel_OT_Item_Anticipos"];

            //this.lblOT.Text = "OT: " + _OT.ToString().PadLeft(11, '0');
            //this.lblDescripcion_Item.Text = _Descripcion_Item.ToString();
            //this.lblCosto.Text = "COSTO = " + _Costo.ToString();

            this.lblOT.DataBindings.Clear();
            this.lblDescripcion_Item.DataBindings.Clear();

            this.lblTransportista.DataBindings.Clear();

            this.lblOT.DataBindings.Add(new Binding("Text", bindingSource, ((DataTable)bindingSource.DataSource).Columns["OT_Con_Mascara"].ColumnName));

            this.Text = "Orden de Transporte: " + this.lblOT.Text;

            this.grdAnticipos.DataSource = dsAnticipos.Tables["rel_OT_Item_Anticipos"];

            int intTieneAnticipoConfirmado;
            if (p.Rows.Count > 0)
            {
                intTieneAnticipoConfirmado = Convert.ToInt32(p.Rows[0]["opAutoriza"].ToString());
            }
            else
            {
                intTieneAnticipoConfirmado = 0;
            }
            //Control de Moros
            int intEsMoro;
            this.lblEsMoro.Text = "0";
            this.lblTipoViajeEspecial.Visible = false;
            if (p.Rows.Count > 0)
            {
                intEsMoro = Convert.ToInt32(p.Rows[0]["opMoro"].ToString());
            }
            else
            {
                intEsMoro = 0;
            }

            if (intEsMoro == 1)
            {
                this.lblEsMoro.Text = intEsMoro.ToString();
                this.lblTipoViajeEspecial.Visible = true;
            }



            //intTieneAnticipoConfirmado = Convert.ToInt32(p.Rows[0]["opAutoriza"].ToString());
            if (intTieneAnticipoConfirmado == 1)
            {
                this.btnGrabar.Enabled = false;
                this.btnEliminar.Enabled = false;
            }
            else
            {
                this.btnGrabar.Enabled = true;
                this.btnEliminar.Enabled = true;
            }

        }

        private void Configura_Grilla(bool boolCheque)
        {
            //https://stackoverflow.com/questions/45498268/dataset-and-combobox-of-datagridview

            DataGridViewColumn colFecha = new clsCalendar_Column();
            DataGridViewComboBoxColumn colCondicion_Pago = new DataGridViewComboBoxColumn();
            DataGridViewColumn colImporte = new DataGridViewTextBoxColumn();

            DataGridViewColumn colLitros = new DataGridViewTextBoxColumn();
            DataGridViewColumn colPrecio_Litro = new DataGridViewTextBoxColumn();

            DataGridViewColumn colFecha_Cheque = new clsCalendar_Column();
            DataGridViewColumn colNro_Cheque = new DataGridViewTextBoxColumn();


            DataGridViewColumn colObservaciones = new DataGridViewTextBoxColumn();
            DataGridViewColumn colEstado = new DataGridViewTextBoxColumn();

            DataGridViewColumn colEmpresa = new DataGridViewTextBoxColumn();
            DataGridViewColumn colOT = new DataGridViewTextBoxColumn();
            DataGridViewColumn colItem_OT = new DataGridViewTextBoxColumn();
            DataGridViewColumn colItem_Anticipo = new DataGridViewTextBoxColumn();
            DataGridViewColumn colOT_Con_Mascara = new DataGridViewTextBoxColumn();

            grdAnticipos.AutoGenerateColumns = false;

            grdAnticipos.Columns.Add(colFecha);
            grdAnticipos.Columns.Add(colCondicion_Pago);

            //grdAnticipos.Columns.Add(colImporte);

            grdAnticipos.Columns.Add(colPrecio_Litro);
            grdAnticipos.Columns.Add(colLitros);
            //MPS-2021-08-06
            grdAnticipos.Columns.Add(colFecha_Cheque);
            grdAnticipos.Columns.Add(colNro_Cheque);
            //
            grdAnticipos.Columns.Add(colImporte);

            grdAnticipos.Columns.Add(colObservaciones);
            grdAnticipos.Columns.Add(colEstado);

            grdAnticipos.Columns.Add(colEmpresa);
            grdAnticipos.Columns.Add(colOT);
            grdAnticipos.Columns.Add(colItem_OT);
            grdAnticipos.Columns.Add(colItem_Anticipo);
            grdAnticipos.Columns.Add(colOT_Con_Mascara);



            //grdConceptos.ColumnCount = 5;
            grdAnticipos.Columns[0].Name = "Fecha";
            grdAnticipos.Columns[1].Name = "Condicion_Pago";

            //grdAnticipos.Columns[2].Name = "Importe";
            grdAnticipos.Columns[2].Name = "Precio_Por_Litro";
            grdAnticipos.Columns[3].Name = "Litros";

            grdAnticipos.Columns[4].Name = "Fecha_Cheque";
            grdAnticipos.Columns[5].Name = "NroCheque";


            grdAnticipos.Columns[6].Name = "Importe";

            grdAnticipos.Columns[7].Name = "Observaciones";
            grdAnticipos.Columns[8].Name = "Estado";

            grdAnticipos.Columns[9].Name = "Empresa";
            grdAnticipos.Columns[10].Name = "OT";
            grdAnticipos.Columns[11].Name = "Item_OT";
            grdAnticipos.Columns[12].Name = "Item_Anticipo";
            grdAnticipos.Columns[13].Name = "OT_Con_Mascara";



            grdAnticipos.Columns[2].DefaultCellStyle.Format = "N2";
            grdAnticipos.Columns[3].DefaultCellStyle.Format = "N2";
            grdAnticipos.Columns[6].DefaultCellStyle.Format = "N2";//Importe

            //grdConceptos.Columns[10].DefaultCellStyle.Format = "HH:mm";
            //grdConceptos.Columns[12].DefaultCellStyle.Format = "HH:mm";

            grdAnticipos.Columns[0].HeaderText = "Fecha";
            grdAnticipos.Columns[1].HeaderText = "Forma Pago";
            //grdAnticipos.Columns[2].HeaderText = "Importe";
            //grdAnticipos.Columns[3].HeaderText = "Precio por Litro";
            //grdAnticipos.Columns[4].HeaderText = "Litros";

            grdAnticipos.Columns[2].HeaderText = "Precio por Litro";
            grdAnticipos.Columns[3].HeaderText = "Litros";

            grdAnticipos.Columns[4].HeaderText = "Fecha Cheque";
            grdAnticipos.Columns[5].HeaderText = "Nº Cheque";

            grdAnticipos.Columns[6].HeaderText = "Importe";

            grdAnticipos.Columns[7].HeaderText = "Observaciones";
            grdAnticipos.Columns[8].HeaderText = "Estado";

            grdAnticipos.Columns[9].HeaderText = "Empresa";
            grdAnticipos.Columns[10].HeaderText = "OT";
            grdAnticipos.Columns[11].HeaderText = "Item_OT";
            grdAnticipos.Columns[12].HeaderText = "Item_Anticipo";
            grdAnticipos.Columns[13].HeaderText = "OT_Con_Mascara";


            //grdConceptos.Columns[6].HeaderText = "Estado";

            grdAnticipos.Columns["Fecha"].DataPropertyName = "Fecha";
            grdAnticipos.Columns["Condicion_Pago"].DataPropertyName = "Codigo_Forma_Pago";

            //grdAnticipos.Columns["Importe"].DataPropertyName = "Importe";
            //grdAnticipos.Columns["Litros"].DataPropertyName = "Litros";
            //grdAnticipos.Columns["Precio_Por_Litro"].DataPropertyName = "Precio_Litro";



            grdAnticipos.Columns["Litros"].DataPropertyName = "Litros";
            grdAnticipos.Columns["Precio_Por_Litro"].DataPropertyName = "Precio_Litro";

            grdAnticipos.Columns["Fecha_Cheque"].DataPropertyName = "Fecha_Cheque";
            grdAnticipos.Columns["NroCheque"].DataPropertyName = "Nro_Cheque";

            grdAnticipos.Columns["Importe"].DataPropertyName = "Importe";

            grdAnticipos.Columns["Observaciones"].DataPropertyName = "Observaciones";

            grdAnticipos.Columns["Empresa"].DataPropertyName = "Empresa";
            grdAnticipos.Columns["OT"].DataPropertyName = "OT";
            grdAnticipos.Columns["Item_OT"].DataPropertyName = "Item_OT";
            grdAnticipos.Columns["Item_Anticipo"].DataPropertyName = "Item_Anticipo";
            grdAnticipos.Columns["OT_Con_Mascara"].DataPropertyName = "OT_Con_Mascara";

            //grdConceptos.Columns["Estado"].DataPropertyName = "Estado";

            //OCULTA COLUMNAS
            //grdConceptos.Columns["Descripcion_Concepto"].ReadOnly = true;
            //grdConceptos.Columns["Codigo_Concepto"].ReadOnly = true;
            //grdConceptos.Columns["Estado"].ReadOnly = true;
            //grdConceptos.Columns["Codigo_Concepto"].Visible = false;
            //grdConceptos.Columns["Estado"].Visible = false;

            //grdConceptos.Columns["Item"].Visible = false;
            //grdConceptos.Columns["Item"].ReadOnly = true;
            //grdConceptos.Columns["Cantidad"].ReadOnly = true;
            //grdConceptos.Columns["Codigo_Contenedor"].ReadOnly = true;
            //grdConceptos.Columns["Codigo_Generador"].ReadOnly = true;
            this.grdAnticipos.Columns["Estado"].ReadOnly = true;

            this.grdAnticipos.Columns["Empresa"].ReadOnly = true;
            this.grdAnticipos.Columns["OT"].ReadOnly = true;
            this.grdAnticipos.Columns["Item_OT"].ReadOnly = true;
            this.grdAnticipos.Columns["Item_Anticipo"].ReadOnly = true;

            //this.grdAnticipos.Columns["Litros"].ReadOnly = true;

            this.grdAnticipos.Columns["OT_Con_Mascara"].ReadOnly = true;

            this.grdAnticipos.Columns["Empresa"].Visible = false;
            this.grdAnticipos.Columns["OT"].Visible = false;
            this.grdAnticipos.Columns["Item_OT"].Visible = false;
            this.grdAnticipos.Columns["Item_Anticipo"].Visible = false;
            this.grdAnticipos.Columns["OT_Con_Mascara"].Visible = false;
            this.grdAnticipos.Columns["Estado"].Visible = false;

            if (boolCheque == false)
            {
                this.grdAnticipos.Columns["Fecha_Cheque"].Visible = false;
                this.grdAnticipos.Columns["NroCheque"].Visible = false;
                this.grdAnticipos.Columns["Litros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.grdAnticipos.Columns["Precio_Por_Litro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else
            {
                this.grdAnticipos.Columns["Precio_Por_Litro"].Visible = false;
                this.grdAnticipos.Columns["Litros"].Visible = false;
                this.grdAnticipos.Columns["Fecha_Cheque"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.grdAnticipos.Columns["NroCheque"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            //this.grdAnticipos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GrdAnticipos_CellFormatting);


            //grdConceptos.Columns["Item"].Width = 10;
            //grdConceptos.Columns["Cantidad"].Width = 10;

            this.grdAnticipos.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //this.grdConceptos.Columns["Peso_Generador"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.grdConceptos.Columns["Peso_Toneladas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdAnticipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //SELECTION MODE
            //grdParametros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdAnticipos.MultiSelect = false;

            colCondicion_Pago.ValueMember = "id";
            colCondicion_Pago.DisplayMember = "descripcion";
            colCondicion_Pago.DataSource = Carga_Condiciones_Pagos();
            colCondicion_Pago.Width = 250;

            //colItem.Width = 5;

            //grdConceptos.CellValueChanged += new DataGridViewCellEventHandler(GrdConceptos_CellValueChanged);
            //grdConceptos.CurrentCellDirtyStateChanged += new EventHandler(GrdConceptos_CurrentCellDirtyStateChanged);

        }

        private DataTable Carga_Condiciones_Pagos()
        {

            funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            DataTable dtCondiciones_Pagos = new DataTable();

            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="int_Activo_Anticipo", Value = _int_Activo_Anticipo }
            //    new MySqlParameter(){ ParameterName="intActivos", Value = 1 },
            //    new MySqlParameter(){ ParameterName="intConcepto", Value = DBNull.Value }
            };

            dtCondiciones_Pagos = lista.Get_Datos("SP_Condicion_de_Pago_Anticipos", parameters);

            Cursor.Current = Cursors.Default;

            return dtCondiciones_Pagos;

        }

        private void GrdAnticipos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            grdAnticipos.CellValueChanged -= new DataGridViewCellEventHandler(GrdAnticipos_CellValueChanged);

            grdAnticipos.Rows[e.RowIndex].Cells["Estado"].Value = "1";


            grdAnticipos.CellValueChanged += new DataGridViewCellEventHandler(GrdAnticipos_CellValueChanged);

        }

        private void GrdAnticipos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //e.Handled = true;
                //SendKeys.Send("{TAB}");


                if (e.KeyData == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    SendKeys.Send("{TAB}");
                    //    int col = grdAnticipos.CurrentCell.ColumnIndex;
                    //    int row = grdAnticipos.CurrentCell.RowIndex;

                    //    if (col < grdAnticipos.ColumnCount - 1)
                    //    {
                    //        col++;
                    //    }
                    //    else
                    //    {
                    //        col = 0;
                    //        row++;
                    //    }

                    //    if (row == grdAnticipos.RowCount)
                    //        grdAnticipos.Rows.Add();

                    //    grdAnticipos.CurrentCell = grdAnticipos[col, row];
                    //    e.Handled = true;

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error" + ex.GetType());
            }

        }
        private void BtnGrabar_Click(object sender, EventArgs e)
        {

            if (Grabar() == true)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool Grabar()
        {

            int intForma_Pago = 0;
            Decimal decImporte = 0;
            Decimal decLitros = 0;
            Decimal decPrecio_Litro = 0;
            String strObservaciones = string.Empty;

            int intItem = 0;
            int intContador = 0;

            DateTime datFecha;

            DateTime datFecha_Cheque;
            String strNro_Cheque;

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

                cmdCommand.CommandText = "SP_Anticipos_Insert";

                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intOT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intItem_OT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intItem_Anticipo", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intForma_Pago", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("datFecha", MySqlDbType.DateTime);
                cmdCommand.Parameters.Add("decImporte", MySqlDbType.Decimal);
                cmdCommand.Parameters.Add("decLitros", MySqlDbType.Decimal);
                cmdCommand.Parameters.Add("decPrecio_Litro", MySqlDbType.Decimal);
                cmdCommand.Parameters.Add("strObservaciones", MySqlDbType.String);
                cmdCommand.Parameters.Add("strContenedor", MySqlDbType.String);
                cmdCommand.Parameters.Add("intProveedor", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intMoro", MySqlDbType.Int32);

                cmdCommand.Parameters.Add("datFecha_Cheque", MySqlDbType.DateTime);
                cmdCommand.Parameters.Add("strNro_Cheque", MySqlDbType.String);

                cmdCommand.Parameters["intEmpresa"].Value = _Empresa;
                cmdCommand.Parameters["intOT"].Value = _OT;
                cmdCommand.Parameters["intItem_OT"].Value = _Item;

                cmdCommand.Parameters["strContenedor"].Value = _Contenedor;
                cmdCommand.Parameters["intProveedor"].Value = _intTransportista;
                cmdCommand.Parameters["intMoro"].Value = Convert.ToInt32(this.lblEsMoro.Text);

                intContador = 0;

                foreach (DataGridViewRow dgvRenglon in grdAnticipos.Rows)
                {

                    DataGridViewTextBoxCell Estado;

                    intContador++;

                    intItem++;

                    if (intContador < grdAnticipos.Rows.Count)
                    {

                        Estado = dgvRenglon.Cells["Estado"] as DataGridViewTextBoxCell;

                        if (Estado.Value == null)
                        {
                            grdAnticipos.CellValueChanged -= new DataGridViewCellEventHandler(GrdAnticipos_CellValueChanged);

                            Estado.Value = "";

                            grdAnticipos.CellValueChanged += new DataGridViewCellEventHandler(GrdAnticipos_CellValueChanged);
                        }

                        if (Estado.Value.ToString() != string.Empty && Estado.Value.ToString() == "1")
                        {

                            //intItem++;

                            intForma_Pago = Int32.Parse(dgvRenglon.Cells["Condicion_Pago"].Value.ToString());
                            datFecha = DateTime.Parse(dgvRenglon.Cells["Fecha"].Value.ToString());
                            decImporte = Decimal.Parse(dgvRenglon.Cells["Importe"].Value.ToString());
                            decLitros = Decimal.Parse(dgvRenglon.Cells["Litros"].Value.ToString());
                            decPrecio_Litro = Decimal.Parse(dgvRenglon.Cells["Precio_Por_Litro"].Value.ToString());
                            strObservaciones = dgvRenglon.Cells["Observaciones"].Value.ToString();

                            if (intForma_Pago==2 || intForma_Pago == 4)
                            {
                                datFecha_Cheque = DateTime.Parse(dgvRenglon.Cells["Fecha_Cheque"].Value.ToString());
                                strNro_Cheque = dgvRenglon.Cells["NroCheque"].Value.ToString();
                            }
                            else
                            {
                                datFecha_Cheque = Convert.ToDateTime("01/01/1900");
                                strNro_Cheque = string.Empty;
                            }

                            cmdCommand.Parameters["intItem_Anticipo"].Value = intItem;
                            cmdCommand.Parameters["intForma_Pago"].Value = intForma_Pago;
                            cmdCommand.Parameters["datFecha"].Value = datFecha;
                            cmdCommand.Parameters["decImporte"].Value = decImporte;
                            cmdCommand.Parameters["decLitros"].Value = decLitros;
                            cmdCommand.Parameters["decPrecio_Litro"].Value = decPrecio_Litro;
                            cmdCommand.Parameters["strObservaciones"].Value = strObservaciones;

                            cmdCommand.Parameters["datFecha_Cheque"].Value = datFecha_Cheque;
                            cmdCommand.Parameters["strNro_Cheque"].Value = strNro_Cheque;

                            //AGREGAR MARCA MORO ==>> VIAJE DIFERENCIADO
                            //SI LA OT ESTA MARCADA COMO DIFERENCIADA, NO SE PUEDE USAR UNA EMPRESA QUE NO HAGA VIAJES EN NEGRO.

                            //TENGO QUE PERMITIR ABM DE PROVEEDORES Y MARCARLOS COMO **VIAJES DIFERENCIADOS**

                            //if (Convert.ToInt32(this.lblEsMoro.Text)==1 && intForma_Pago!=1)
                            //{
                            //    MessageBox.Show("La forma de pago es incorrecta!. Consultar con Maxi");
                            //}

                            cmdCommand.ExecuteNonQuery();


                        }

                    }

                }

                trsTransaccion.Commit();
                //genero el PDF para adjuntar por email
                if (intForma_Pago == 1 || intForma_Pago == 2 || intForma_Pago == 4)
                {
                    string ruta_Attachement;
                    string strAsunto;
                    string strCuerpo;
                    DataTable dt_Anticipos;
                    DataRow dr;
                    funciones_Varias fv = new funciones_Varias();
                    funciones_envio_emails e = new funciones_envio_emails();



                    //cargar SP HTML
                    DNTablas_Gral lista = new DNTablas_Gral();

                    var parameters = new[]
                    {
                        new MySqlParameter(){ ParameterName="intEmpresa", Value = datos.g_idEmpresa },
                        new MySqlParameter(){ ParameterName="intOT", Value = _OT },
                        new MySqlParameter(){ ParameterName="intItemOT", Value = _Item }
                       };

                    dt_Anticipos = lista.Get_Datos("SP_Genera_Recibo_Emails", parameters);
                    dr = dt_Anticipos.Rows[0];

                    ruta_Attachement=fv.Genera_PDF_desde_HTML(dr["v_numero_anticipo"].ToString(), dr["strCuerpo"].ToString());
                    strAsunto = dr["strAsunto"].ToString();
                    strCuerpo=dr["strCuerpo"].ToString();

                    e.SendEmailWithOutlook(datos.g_Ruta_Comp_Emails, strAsunto, strCuerpo, ruta_Attachement,false);
                }

                //MessageBoxButtons button = MessageBoxButtons.OK;
                //MessageBoxIcon icon = MessageBoxIcon.Information;

                //MessageBox.Show("Proceso finalizado ", "Aviso", button, icon);
                return true;

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
                        return false;
                    }
                }

                Console.WriteLine("Error" + e.GetType());
                return false;
            }
            finally
            {
                cnnConnection.Close();

            }

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GrdAnticipos_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {

            DateTime datFecha_Hoy = DateTime.Now;

            e.Row.Cells["Empresa"].Value = _Empresa;
            e.Row.Cells["OT"].Value = _OT;
            e.Row.Cells["Item_OT"].Value = _Item;
            e.Row.Cells["Item_Anticipo"].Value = 1;
            e.Row.Cells["Fecha"].Value = datFecha_Hoy.ToString("dd/MM/yyyy");
            e.Row.Cells["Importe"].Value = 0;
            e.Row.Cells["Litros"].Value = 0;
            e.Row.Cells["Precio_Por_Litro"].Value = 0;
            e.Row.Cells["Observaciones"].Value = "";
            e.Row.Cells["OT_Con_Mascara"].Value = _OT.ToString().PadLeft((11 - _OT.ToString().Length), '0');

        }

        private void GrdAnticipos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            //if (this.grdAnticipos.Columns[e.ColumnIndex].Name.Equals("Litros"))
            //{
            //    try
            //    {
            //        this.grdAnticipos.Rows[e.RowIndex].Cells["Litros"].Value = Convert.ToDecimal(this.grdAnticipos.Rows[e.RowIndex].Cells["Importe"].Value) * Convert.ToDecimal(this.grdAnticipos.Rows[e.RowIndex].Cells["Precio_Por_Litro"].Value);
            //    }
            //    catch (Exception ex) { }
            //}

        }

        private void GrdAnticipos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                SendKeys.Send("{UP}");
                SendKeys.Send("{TAB}");
                if (Convert.ToDecimal(grdAnticipos.CurrentRow.Cells["Condicion_Pago"].Value) == 10)
                {
                    //grdAnticipos.CurrentRow.Cells["Importe"].Selected = true;
                }

                if (Convert.ToDecimal(grdAnticipos.CurrentRow.Cells["Precio_Por_Litro"].Value) != 0 && Convert.ToDecimal(grdAnticipos.CurrentRow.Cells["Litros"].Value) != 0)
                {
                    //decimal decImporte = Convert.ToDecimal(grdAnticipos.CurrentRow.Cells["Importe"].Value);
                    //decimal decLitros = decImporte / Convert.ToDecimal(grdAnticipos.CurrentRow.Cells["Precio_Por_Litro"].Value);
                    //grdAnticipos.CurrentRow.Cells["Litros"].Value = decLitros;

                    decimal decLitros = Convert.ToDecimal(grdAnticipos.CurrentRow.Cells["Litros"].Value);
                    decimal decPrecioLitros = Convert.ToDecimal(grdAnticipos.CurrentRow.Cells["Precio_Por_Litro"].Value);
                    grdAnticipos.CurrentRow.Cells["Importe"].Value = decLitros * decPrecioLitros;
                    //decimal decImporte = Convert.ToDecimal(grdAnticipos.CurrentRow.Cells["Importe"].Value);

                }
                if (Convert.ToDecimal(grdAnticipos.CurrentRow.Cells["Condicion_Pago"].Value) == 4 && _int_Activo_Anticipo != 4)
                {
                    MessageBox.Show("No puede cargar cheques en esta opción. No puede cargar la FECHA ni el Número");
                    this.Close();
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Error" + e.GetType());
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void grdAnticipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Tiempo_Tick(object sender, EventArgs e)
        {

        }

        private void grdAnticipos_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            if (anError.Exception != null &&
                            anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                anError.Cancel = true;
            }
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Anula el anticipo?", "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
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



                cmdCommand.CommandText = "SP_Anticipos_Delete";

                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intOT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intItem_OT", MySqlDbType.Int32);

                cmdCommand.Parameters["intEmpresa"].Value = _Empresa;
                cmdCommand.Parameters["intOT"].Value = _OT;
                cmdCommand.Parameters["intItem_OT"].Value = _Item;


                cmdCommand.ExecuteNonQuery();


                trsTransaccion.Commit();

                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Information;

                MessageBox.Show("Proceso finalizado ", "Aviso", button, icon);
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //private void grdAnticipos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    DataGridViewComboBoxEditingControl dgvCombo = e.Control as DataGridViewComboBoxEditingControl;

        //    if (dgvCombo != null)
        //    {
        //        //
        //        // se remueve el handler previo que pudiera tener asociado, a causa ediciones previas de la celda
        //        // evitando asi que se ejecuten varias veces el evento
        //        //
        //        dgvCombo.SelectedIndexChanged -= new EventHandler(dvgCombo_SelectedIndexChanged);

        //        dgvCombo.SelectedIndexChanged += new EventHandler(dvgCombo_SelectedIndexChanged);
        //    }

        //}
        //private void dvgCombo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //
        //    // se recupera el valor del combo
        //    // a modo de ejemplo se escribe en consola el valor seleccionado
        //    //
        //    ComboBox combo = sender as ComboBox;

        //    //Console.WriteLine(combo.SelectedValue);

        //    //
        //    // se accede a la fila actual, para trabajr con otor de sus campos
        //    // en este caso se marca el check si se cambia la seleccion
        //    //
        //    DataGridViewRow row = grdAnticipos.CurrentRow;

        //    if (Convert.ToInt32(row.Cells["Condicion_Pago"].Value) != 4)
        //    {

        //    } 

        //}
    }

}
