using System;
using System.Data;
using System.Windows.Forms;
using k_negocio_00;
using MySql.Data.MySqlClient;
using System.Globalization;


namespace k_presentacion_00
{
    public partial class frmBuscador_OT : Form
    {
        public int _OT { get; set; }
        public int _Item { get; set; }
        public int _Corredor { get; set; }
        public Decimal _Costo { get; set; }
        public int _IdCliente { get; set; }

        BindingSource _bindingSource = new BindingSource();

        int idEmpresa;
        guardar_datos_login datos = guardar_datos_login.Instance();

        public int IdEmpresa { get => idEmpresa; set => idEmpresa = value; }

        public frmBuscador_OT()
        {
            InitializeComponent();
            iniciar();
        }
        private void iniciar()
        {
            //cargo fechas en combo
            DateTime fDesde = new DateTime(2000, 1, 1);
            DateTime fHasta = new DateTime(2050, 12, 31);
            this.mFechaDesde.Text = fDesde.ToString();
            this.mFechaHasta.Text = fHasta.ToString();
            cargar_clientes_transportistas();

        }
        private void cargar_clientes_transportistas()
        {
            funciones_Varias o = new funciones_Varias();
            DataTable r;
            DN_ABM u = new DN_ABM();

            r = u.DN_Traer_DataTable("SP_Clientes_Get_All", 0, datos.g_idEmpresa);

            o.CargarComboDataTable(this.cboClientes, r, "id", "descripcion", false, false, false, true);

            r = u.DN_Traer_DataTable("SP_Transportistas_Get_All", 0, datos.g_idEmpresa);

            o.CargarComboDataTable(this.cboTransportista, r, "id", "descripcion", false, false, false, true);

        }
        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            DataTable dtOT;
            DNTablas_Gral lista = new DNTablas_Gral();
            MySqlParameter[] Parametros = new MySqlParameter[9];
            DataGridViewButtonColumn colBtnNominacion = new DataGridViewButtonColumn();

            dgv.Columns.Clear();
            //Empresa
            Parametros[0] = new MySqlParameter("intEmpresa", datos.g_idEmpresa);
            //OT
            if (this.txtNroOT.Text != string.Empty)
            {
                Parametros[1] = new MySqlParameter("intOT", int.Parse(this.txtNroOT.Text));
            }
            else
            {
                Parametros[1] = new MySqlParameter("intOT", DBNull.Value);
            }
            //Clientes
            if (this.cboClientes.SelectedIndex != -1)
            {
                Parametros[2] = new MySqlParameter("intCliente", Convert.ToInt32(this.cboClientes.SelectedValue));
            }
            else
            {
                Parametros[2] = new MySqlParameter("intCliente", DBNull.Value);
            }
            //Transporte
            if (this.cboTransportista.SelectedIndex != -1)
            {
                Parametros[3] = new MySqlParameter("intTransportista", Convert.ToInt32(this.cboTransportista.SelectedValue));
            }
            else
            {
                Parametros[3] = new MySqlParameter("intTransportista", DBNull.Value);
            }
            //Fechas
            DateTime fDesde;
            DateTime fHasta;
            fDesde = DateTime.Parse(this.mFechaDesde.Text);
            fHasta = DateTime.Parse(this.mFechaHasta.Text);

            Parametros[4] = new MySqlParameter("datFechaDesde", MySqlDbType.DateTime);
            Parametros[5] = new MySqlParameter("datFechaHasta", MySqlDbType.DateTime);
            Parametros[4].Value = fDesde.ToString("yyyy-MM-dd");
            Parametros[5].Value = fHasta.ToString("yyyy-MM-dd");



            //Nro de contenedor
            if (this.txtContenedor.Text != string.Empty)
            {
                Parametros[6] = new MySqlParameter("strNroCont", this.txtContenedor.Text);
            }
            else
            {
                Parametros[6] = new MySqlParameter("strNroCont", DBNull.Value);
            }
            //Nro Booking
            if (this.txtBL.Text != string.Empty)
            {
                Parametros[7] = new MySqlParameter("strBooking", (this.txtBL.Text));
            }
            else
            {
                Parametros[7] = new MySqlParameter("strBooking", DBNull.Value);
            }


            if (this.txtPatente.Text != string.Empty)
            {
                Parametros[8] = new MySqlParameter("strPatente", this.txtPatente.Text);
            }
            else
            {
                Parametros[8] = new MySqlParameter("strPatente", DBNull.Value);
            }

            dtOT = lista.Get_Datos("SP_Buscador_OT", Parametros); //, parameters);

            dgv.DataSource = dtOT;
            dgv.Columns[0].Width = 45;
            dgv.Columns[1].Width = 45;
            dgv.Columns[2].Width = 150;//clientes
            dgv.Columns[3].Width = 120;
            dgv.Columns[4].Width = 45;
            dgv.Columns[5].Width = 45;
            dgv.Columns[6].Width = 55;
            dgv.Columns[7].Width = 200;//ruta
            dgv.Columns[8].Width = 55;
            dgv.Columns[9].Width = 100;//posic
            dgv.Columns[10].Width = 100;
            dgv.Columns[11].Width = 140;//transportista
            dgv.Columns[12].Width = 55;
            dgv.Columns[13].Width = 55;
            dgv.Columns[14].Width = 55;
            dgv.Columns[15].Width = 55;
            dgv.Columns[16].Width = 55;
            dgv.Columns[17].Width = 55;
            dgv.Columns[18].Width = 55;//Ultima Posicion
            dgv.Columns[19].Visible = false;//Compra
            dgv.Columns[20].Visible = false;//codTractor
            dgv.Columns[21].Visible = false;//codChasis
            dgv.Columns[22].Visible = false;//codChofer
            dgv.Columns[23].Visible = false;//HoraPosic
            dgv.Columns[24].Visible = false;//idCorredor
            dgv.Columns[25].Visible = false;//idProveedor
            dgv.Columns[26].Visible = false;//idCliente

            dgv.Columns.Add(colBtnNominacion);
            colBtnNominacion.Name = "Cambio Nominacion";
            //dgv.Columns[20].Name = "Cambio Nominacion";
            //dgv.Columns[20].HeaderText = "Cambio Nominacion";


            if (MessageBox.Show("¿Desea Exportar a Excel?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataTable dt = (DataTable)this.dgv.DataSource;
                funciones_Varias.ExportToExcel(dt, "ExportacionOT");
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int intOt;
            int intItem;
            int intCorredor;
            int intCliente;
            decimal decCompra;
            int intCodTractor;
            int intCodChasis;
            string strNombreTractor;
            string strNombreChasis;
            string strNombreChofer;
            int intChofer;
            string strBooking;
            string strfechaPos;
            string strfechaRet;
            string strHoraPosic;
            string strTransportista;
            string strDesc;
            int intTransportista;
            try
            {
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);

                if (e.ColumnIndex == 27)
                {
                    if (dgv[15, e.RowIndex].Value.ToString() == "FINALIZADA")
                    {


                        frmCambioNominacion f = new frmCambioNominacion();

                        intOt = int.Parse(dgv[0, e.RowIndex].Value.ToString());
                        intItem = int.Parse(dgv[1, e.RowIndex].Value.ToString());
                        intCorredor = int.Parse(dgv[24, e.RowIndex].Value.ToString());
                        intCliente = int.Parse(dgv[26, e.RowIndex].Value.ToString());
                        decCompra = decimal.Parse(dgv[19, e.RowIndex].Value.ToString());

                        intTransportista = int.Parse(dgv[25, e.RowIndex].Value.ToString()); ;
                        strTransportista = dgv[11, e.RowIndex].Value.ToString();

                        intCodTractor = int.Parse(dgv[20, e.RowIndex].Value.ToString());
                        strNombreTractor = dgv[12, e.RowIndex].Value.ToString();

                        intCodChasis = int.Parse(dgv[21, e.RowIndex].Value.ToString());
                        strNombreChasis = dgv[13, e.RowIndex].Value.ToString();

                        intChofer = int.Parse(dgv[22, e.RowIndex].Value.ToString());
                        strNombreChofer = dgv[14, e.RowIndex].Value.ToString();

                        strBooking = dgv[4, e.RowIndex].Value.ToString();
                        strfechaPos = dgv[9, e.RowIndex].Value.ToString();
                        strfechaRet = dgv[8, e.RowIndex].Value.ToString();
                        strHoraPosic = dgv[23, e.RowIndex].Value.ToString();
                        strDesc = dgv[15, e.RowIndex].Value.ToString();

                        //EDD 2022-11-15
                        f._Empresa = datos.g_idEmpresa;
                        f._OT = intOt;
                        f._Item = intItem;
                        f._Corredor = intCorredor;
                        f._Costo = decCompra;
                        f._codigo_Transportista = intTransportista;
                        f._nombre_Transportista = strTransportista;
                        f._codigo_Tractor = Convert.ToInt32(intCodTractor);
                        f._nombre_Tractor = strNombreTractor;
                        f._codigo_Chasis = Convert.ToInt32(intCodChasis);
                        f._nombre_Chasis = strNombreChasis;
                        f._codigo_Chofer = Convert.ToInt32(intChofer);
                        f._nombre_Chofer = strNombreChofer;
                        f._BLBooking = strBooking;
                        f._IdCliente = intCliente;
                        f._FechaPosicion = Convert.ToDateTime(strfechaPos).ToString("dd-MM-yyyy");
                        f._FechaRetiro = Convert.ToDateTime(strfechaRet).ToString("dd-MM-yyyy");
                        f._HoraPosicion = strHoraPosic;
                        f._viene_De = 1;//viene desde el buscador de OT


                        f.ShowDialog(this);
                        this.Close();
                    }
                    else
                    {
                        return;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        private void frmBuscador_OT_Load(object sender, EventArgs e)
        {

        }

        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
