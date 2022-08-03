using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using k_negocio_00;
using MySql.Data.MySqlClient;

namespace k_presentacion_00
{
    public partial class frm_Trafico_En_Transito : Form
    {
        bool PrimeraVez = true;
        //int sleep_Viajes;
        //Thread t_A_Nominar;

        guardar_datos_login datos = guardar_datos_login.Instance();
        public int _Empresa { get; set; }
        public int _Nominados { get; set; } 
        public string _Titulo { get; set; }
        public int _Concepto { get; set; }
        public frm_Trafico_En_Transito()
        {
            InitializeComponent();
            //this.Text = _Titulo;
            this.Text = _Titulo;
        }
        //comenzamos proceso de actualizacion.
        private void inicia()
        {
            Configura_Grilla();

            Proceso_General();

            //System.Threading.Thread.Sleep(30000);
            this.Tiempo.Enabled = true;
            this.Tiempo.Interval = 1000 * 30;//15 segundos

        }


        private void Tiempo_Tick(object sender, EventArgs e)
        {
            DNTablas_Gral fv = new DNTablas_Gral();
            if (fv.ServerEncendido() == false)
            {
                Cartel("Probando Conexión...");
                //MessageBox.Show("Server No Encontrado", "Atención");
                MessageBoxTemporal.Show("Servidor no encotrado", "Atención", 10, true);
                PrimeraVez = false;
            }
            else
            {
                PrimeraVez = true;
            }
            if (PrimeraVez == true)
            {
                Cartel("Leyendo...");
                //IniciarProcesoDeActualizacion();
                //Tiempo.Enabled = false;
                //PrimeraVez = false;
                Proceso_General();
                Cartel("Esperando...");
            }
        }
        //private void IniciarProcesoDeActualizacion()
        //{
        //    DNTablas_Gral fv = new DNTablas_Gral();
        //    if (PrimeraVez == true)
        //    {
        //        sleep_Viajes = Convert.ToInt32(fv.DN_Datos_Parametros(datos.g_idEmpresa, "Tiempo_a_Designar"));
        //        t_A_Nominar = new Thread(Leer_Informacion_y_Actualizar);


        //        Control.CheckForIllegalCrossThreadCalls = false;

        //        if (t_A_Nominar.ThreadState != System.Threading.ThreadState.Running)
        //            t_A_Nominar.Start();

        //        PrimeraVez = false;
        //    }
        //}
        //private void Leer_Informacion_y_Actualizar()
        //{
        //    while (true)
        //    {
        //        Proceso_General();
        //        Thread.Sleep(sleep_Viajes);
        //       //Application.DoEvents();
        //    }

        //}
        private void Proceso_General()
        {
            //DN_Trafico c = new DN_Trafico();
            DataTable dt;

            //dt = c.DN_Trafico_Grillas(datos.g_idEmpresa, "SP_Viajes_A_Nominar");

            //funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            //BindingSource bindingSource = new BindingSource();

            //System.Data.DataSet dsOTs = new System.Data.DataSet("OTs");

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="pIdEmpresa", Value = _Empresa },
                new MySqlParameter(){ ParameterName="intNominados", Value = _Nominados },
                new MySqlParameter(){ ParameterName="intConcepto", Value = _Concepto }
            };

            dt = lista.Get_Datos("SP_Viajes_En_Transito", parameters);

            this.dg.DataSource = null;
            this.dg.Rows.Clear();

            this.dg.DataSource = dt;

            this.dg.Refresh();



            //Se recorren las filas del DataGridView
            foreach (DataGridViewRow row in dg.Rows)
            {
                // Se Evalua que el valor Activo este Falso, en caso correcto se pinta de Rojo
                //string srtColor;
                //if ()
                string EsImpo;
                bool ok;



                if (row.Cells[13].Value != null)
                {
                    EsImpo = row.Cells[5].Value.ToString();
                    ok = EsImpo.Contains("IM -");

                    if (ok == false)
                    {
                        dg.Rows[row.Index].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(row.Cells[13].Value.ToString());
                    }
                    else
                    {
                        dg.Rows[row.Index].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFE300");
                    }

                }
            }




        }
        private void Cartel(string leyenda)
        {
            //this.lblTitulo.Text = leyenda;

        }

        private void frm_Trafico_a_Designar_Load(object sender, EventArgs e)
        {
            inicia();
        }
        private void abrir_Popup(int menosLinea)
        {
            this.Tiempo.Enabled = false;//cuando se da enter y abre el pop se detene el reloj

            frm_PopUp_Designa_Viaje frm_PopUp_Designa_Viaje = new frm_PopUp_Designa_Viaje();
            frm_PopUp_Designa_Viaje_Conceptos frm_PopUp_Designa_Viaje_Conceptos = new frm_PopUp_Designa_Viaje_Conceptos();

            int intEmpresa = 0;
            int intOT = 0;
            int intItem = 0;
            int intId_Corredor = 0;
            int intId_Cliente = 0;
            Decimal decCosto = 0;
            string strDescripcion_Item = string.Empty;

            int intIndTipo = 0;
            string strBooking;

            int intLinea = dg.CurrentRow.Index-menosLinea  ;

            intEmpresa = (int)dg.Rows[intLinea].Cells["Empresa"].Value;
            intOT = (int)dg.Rows[intLinea].Cells["OT"].Value;
            intItem = (int)dg.Rows[intLinea].Cells["Item"].Value;
            intId_Cliente = (int)dg.Rows[intLinea].Cells["idCliente"].Value;
            intIndTipo =Convert.ToInt32(dg.Rows[intLinea].Cells["IndTipo"].Value);
            strBooking = dg.Rows[intLinea].Cells["BL_Booking"].Value.ToString();

            if (!int.TryParse(dg.Rows[intLinea].Cells["Corredor"].Value.ToString(), out intId_Corredor))
            {
                intId_Corredor = 0;
            }

            decCosto = Convert.ToDecimal(dg.Rows[intLinea].Cells["Costo"].Value);

            strDescripcion_Item = dg.Rows[intLinea].Cells["Cliente"].Value.ToString();

            if (_Nominados == 0)
            {
                frm_PopUp_Designa_Viaje._Empresa = intEmpresa;
                frm_PopUp_Designa_Viaje._OT = intOT;
                frm_PopUp_Designa_Viaje._Item = intItem;
                frm_PopUp_Designa_Viaje._Corredor = intId_Corredor;
                frm_PopUp_Designa_Viaje._Costo = decCosto;
                frm_PopUp_Designa_Viaje._Descripcion_Item = strDescripcion_Item;
                frm_PopUp_Designa_Viaje._IdCliente = intId_Cliente;
                frm_PopUp_Designa_Viaje._IndTipo = intIndTipo;
                frm_PopUp_Designa_Viaje._strBooking  = strBooking;

                frm_PopUp_Designa_Viaje.ShowDialog(this);
            }
            else
            {
                frm_PopUp_Designa_Viaje_Conceptos._Empresa = intEmpresa;
                frm_PopUp_Designa_Viaje_Conceptos._OT = intOT;
                frm_PopUp_Designa_Viaje_Conceptos._Item = intItem;
                frm_PopUp_Designa_Viaje_Conceptos._Corredor = intId_Corredor;
                frm_PopUp_Designa_Viaje_Conceptos._Costo = decCosto;
                frm_PopUp_Designa_Viaje_Conceptos._Descripcion_Item = strDescripcion_Item;
                frm_PopUp_Designa_Viaje_Conceptos._IdCliente = intId_Cliente;
                frm_PopUp_Designa_Viaje_Conceptos._IndTipo = intIndTipo;
                frm_PopUp_Designa_Viaje_Conceptos._strBooking = strBooking;

                frm_PopUp_Designa_Viaje_Conceptos.ShowDialog(this);

            }

            Proceso_General();//se recarga la grilla
            this.Tiempo.Enabled = true;//se inicia nuevamente el reloj

        }
        private void dg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                abrir_Popup(1);
            }
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

            DataGridViewColumn colNro_OT_Con_Mascara = new DataGridViewTextBoxColumn();
            DataGridViewColumn colItem = new DataGridViewTextBoxColumn();
            DataGridViewColumn colFecha_Retiro = new DataGridViewTextBoxColumn();
            DataGridViewColumn colCliente = new DataGridViewTextBoxColumn();
            DataGridViewColumn colTipo_Servicio = new DataGridViewTextBoxColumn();
            DataGridViewColumn colTipo_Contenedor = new DataGridViewTextBoxColumn();
            DataGridViewColumn colRuta = new DataGridViewTextBoxColumn();
            DataGridViewColumn colUltima_Situacion = new DataGridViewTextBoxColumn();
            DataGridViewColumn colOT = new DataGridViewTextBoxColumn();
            DataGridViewColumn colEmpresa = new DataGridViewTextBoxColumn();
            DataGridViewColumn colCorredor = new DataGridViewTextBoxColumn();
            DataGridViewColumn colCosto = new DataGridViewTextBoxColumn();
            DataGridViewColumn colColor = new DataGridViewTextBoxColumn();
            DataGridViewColumn colIdCliente = new DataGridViewTextBoxColumn();
            DataGridViewColumn colIndTipo = new DataGridViewTextBoxColumn();
            DataGridViewColumn colBooking = new DataGridViewTextBoxColumn();

            dg.AutoGenerateColumns = false;

            dg.Columns.Add(colNro_OT_Con_Mascara);
            dg.Columns.Add(colItem);
            dg.Columns.Add(colFecha_Retiro);
            dg.Columns.Add(colCliente);
            dg.Columns.Add(colBooking);//MPS-->2020-03-14
            dg.Columns.Add(colTipo_Servicio);
            dg.Columns.Add(colTipo_Contenedor);
            dg.Columns.Add(colRuta);
            dg.Columns.Add(colUltima_Situacion);
            dg.Columns.Add(colOT);
            dg.Columns.Add(colEmpresa);
            dg.Columns.Add(colCorredor);
            dg.Columns.Add(colCosto);
            dg.Columns.Add(colColor);
            dg.Columns.Add(colIdCliente);
            dg.Columns.Add(colIndTipo);

            //grdViajes.ColumnCount = 5;
            dg.Columns[0].Name = "Nro_OT_Con_Mascara";
            dg.Columns[1].Name = "Item";
            dg.Columns[2].Name = "Fecha_Retiro";
            dg.Columns[3].Name = "Cliente";
            dg.Columns[4].Name = "BL_Booking";
            dg.Columns[5].Name = "Tipo_Servicio";
            dg.Columns[6].Name = "Tipo_Contenedor";
            dg.Columns[7].Name = "Ruta";
            dg.Columns[8].Name = "Ultima_Situación";
            dg.Columns[9].Name = "OT";
            dg.Columns[10].Name = "Empresa";
            dg.Columns[11].Name = "Corredor";
            dg.Columns[12].Name = "Costo";
            dg.Columns[13].Name = "Color";
            dg.Columns[14].Name = "idCliente";
            dg.Columns[15].Name = "IndTipo";

            //dg.Columns[6].DefaultCellStyle.Format = "N2";
            //dg.Columns[8].DefaultCellStyle.Format = "N2";

            //dg.Columns[10].DefaultCellStyle.Format = "HH:mm:ss";
            //dg.Columns[12].DefaultCellStyle.Format = "HH:mm:ss";

            dg.Columns[0].HeaderText = "OT";
            dg.Columns[1].HeaderText = "Ítem";
            dg.Columns[2].HeaderText = "Fecha Retiro";
            dg.Columns[3].HeaderText = "Cliente";
            dg.Columns[4].HeaderText = "BL_Booking";
            dg.Columns[5].HeaderText = "Servicio || Realizado por...";
            dg.Columns[6].HeaderText = "Tipo Contenedor";
            dg.Columns[7].HeaderText = "Ruta";
            dg.Columns[8].HeaderText = "Última Situación";
            dg.Columns[9].HeaderText = "OT";
            dg.Columns[10].HeaderText = "Empresa";
            dg.Columns[11].HeaderText = "Corredor";
            dg.Columns[12].HeaderText = "Costo";
            dg.Columns[13].HeaderText = "Color";
            dg.Columns[14].HeaderText = "idCliente";
            dg.Columns[15].HeaderText = "IndTipo";

            dg.Columns["Nro_OT_Con_Mascara"].DataPropertyName = "Nro_OT_Con_Mascara";
            dg.Columns["Item"].DataPropertyName = "item";
            dg.Columns["Fecha_Retiro"].DataPropertyName = "RetiroFecha";
            dg.Columns["Cliente"].DataPropertyName = "Razon_Social";

            dg.Columns["BL_Booking"].DataPropertyName = "BL_Booking";

            dg.Columns["Tipo_Servicio"].DataPropertyName = "Tipo_Servicio";
            dg.Columns["Tipo_Contenedor"].DataPropertyName = "Contenedor";
            dg.Columns["Ruta"].DataPropertyName = "Ruta";
            dg.Columns["Ultima_Situación"].DataPropertyName = "Ultima_Situacion";
            dg.Columns["OT"].DataPropertyName = "IdOT";
            dg.Columns["Empresa"].DataPropertyName = "IdEmpresa";
            dg.Columns["Corredor"].DataPropertyName = "IdCorredor";
            dg.Columns["Costo"].DataPropertyName = "Costo";
            dg.Columns["Color"].DataPropertyName = "Color";
            dg.Columns["idCliente"].DataPropertyName = "Id";
            dg.Columns["IndTipo"].DataPropertyName = "IndTipo";

            dg.Columns["Nro_OT_Con_Mascara"].ReadOnly = true;
            dg.Columns["Item"].ReadOnly = true;
            dg.Columns["Fecha_Retiro"].ReadOnly = true;
            dg.Columns["Cliente"].ReadOnly = true;

            dg.Columns["BL_Booking"].ReadOnly = true;

            dg.Columns["Tipo_Servicio"].ReadOnly = true;
            dg.Columns["Tipo_Contenedor"].ReadOnly = true;
            dg.Columns["Ruta"].ReadOnly = true;
            dg.Columns["Ultima_Situación"].ReadOnly = true;
            dg.Columns["OT"].ReadOnly = true;
            dg.Columns["Empresa"].ReadOnly = true;
            dg.Columns["Corredor"].ReadOnly = true;
            dg.Columns["Costo"].ReadOnly = true;
            dg.Columns["Color"].ReadOnly = true;
            dg.Columns["idCliente"].ReadOnly = true;
            dg.Columns["IndTipo"].ReadOnly = true;

            //OCULTA COLUMNAS
            dg.Columns["Item"].Visible = true;
            dg.Columns["OT"].Visible = false;
            dg.Columns["Empresa"].Visible = false;
            dg.Columns["Corredor"].Visible = false;
            dg.Columns["Color"].Visible = false;
            dg.Columns["idCliente"].Visible = false;
            dg.Columns["IndTipo"].Visible = false;
            dg.Columns["BL_Booking"].Visible = true;
            //dg.Columns["Item"].Width = 15;
            dg.Columns["Costo"].Visible = false;

            //dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //SELECTION MODE
            //grdParametros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg.MultiSelect = false;

            colNro_OT_Con_Mascara.Width=40;
            colItem.Width = 40;
            colFecha_Retiro.Width = 40*4;
            colCliente.Width = 40*3;
            colBooking.Width = 40*3;
            colTipo_Servicio.Width = 40*9;
            colTipo_Contenedor.Width = 40*2;
            colRuta.Width = 40*7;
            colUltima_Situacion.Width = 40*6;
            //colOT.Width = 15;
            //colEmpresa.Width = 15;
            //colCorredor.Width = 15;
            //colCosto.Width = 15;
            //colColor.Width = 15;
            //colIdCliente.Width = 15;
            //colIndTipo.Width = 15;

        }



        private void dg_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            abrir_Popup(0);
        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
