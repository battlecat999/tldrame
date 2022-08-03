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
using k_mysql;

namespace k_presentacion_00
{
    public partial class frm_abm_corredores : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wpara, int lparam);
        
        bool opEditar;
        guardar_datos_login datos = guardar_datos_login.Instance();
        public frm_abm_corredores()
        {
            InitializeComponent();
            
            this.lblUsuario.Text = datos.g_idUser + " " + datos.g_lastName;

        }

        private void frm_abm_corredores_Load(object sender, EventArgs e)
        {
            //cargarcombos_rutas();
            //cargardataGrid();
            limpiarForm();
        }
        private void limpiarForm()
        {
            this.txtOneWay.Text = string.Empty;
            this.txtRoundTrip .Text = string.Empty;
            this.TTA_Transporte .Text = string.Empty;
            this.TTA_Cliente.Text = string.Empty;
            this.txtCosto.Text = "0,00";
            this.c_Activo.Checked = false;
            this.c_Tipo.Checked = false;
            this.txtIdCorredor.Text = "0";
            cargarcombos_rutas();
            cargardataGrid();
            opEditar = false;
        }
        private void cargardataGrid()
        {
            DN_ABM o = new DN_ABM();
            DataTable d = new DataTable();
            //o.pAll = 0;
            //o.IdEmpresa=datos.g_idEmpresa;
            //o.IdUsuario=datos.g_idUser;
            //d = o.Corredores_GET("Corredores");
            d = o.DN_Traer_DataTable("SP_Corredores_Traer", 0, datos.g_idEmpresa);
            this.dgw.Columns.Clear();

            this.dgw.AutoGenerateColumns = false;

            

            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Visible = false;
            colID.HeaderText = "N";
            colID.Name = "idCorredor";
            colID.DataPropertyName = "idCorredor";
            this.dgw.Columns.Add(colID);

            DataGridViewTextBoxColumn colOrigen = new DataGridViewTextBoxColumn();
            colOrigen.Visible = true;
            colOrigen.HeaderText = "Origen";
            colOrigen.Name = "colOrigen";
            colOrigen.DataPropertyName = "idOrigen";
            this.dgw.Columns.Add(colOrigen);

            DataGridViewTextBoxColumn colDestino = new DataGridViewTextBoxColumn();
            colDestino.Visible = true;
            colDestino.HeaderText = "Destino";
            colDestino.Name = "colDestino";
            colDestino.DataPropertyName = "idDestino";
            this.dgw.Columns.Add(colDestino);

            DataGridViewTextBoxColumn colRetorno = new DataGridViewTextBoxColumn();
            colRetorno.Visible = true;
            colRetorno.HeaderText = "Retorno";
            colRetorno.Name = "colRetorno";
            colRetorno.DataPropertyName = "idRetorno";
            this.dgw.Columns.Add(colRetorno);

            DataGridViewTextBoxColumn colOneWay = new DataGridViewTextBoxColumn();
            colOneWay.Visible = true;
            colOneWay.HeaderText = "OW";
            colOneWay.Name = "colOneWay";
            colOneWay.DataPropertyName = "OneWay";
            this.dgw.Columns.Add(colOneWay);

            DataGridViewTextBoxColumn colRound = new DataGridViewTextBoxColumn();
            colRound.Visible = true;
            colRound.HeaderText = "RT";
            colRound.Name = "colRound";
            colRound.DataPropertyName = "RoundTrip";
            this.dgw.Columns.Add(colRound);

            DataGridViewTextBoxColumn colTTAT = new DataGridViewTextBoxColumn();
            colTTAT.Visible = true;
            colTTAT.HeaderText = "T.T.A.C";
            colTTAT.Name = "colTTAT";
            colTTAT.DataPropertyName = "TTA_Transporte";
            this.dgw.Columns.Add(colTTAT);

            DataGridViewTextBoxColumn colTTAC = new DataGridViewTextBoxColumn();
            colTTAC.Visible = true;
            colTTAC.HeaderText = "T.T.A.C";
            colTTAC.Name = "colTTAC";
            colTTAC.DataPropertyName = "TTA_Cliente";
            this.dgw.Columns.Add(colTTAC);



            DataGridViewCheckBoxColumn colInd = new DataGridViewCheckBoxColumn();
            colInd.Visible = true;
            colInd.HeaderText = "OW o RT";
            colInd.Name = "Tipo";
            colInd.DataPropertyName = "IndTipo";
            this.dgw.Columns.Add(colInd);

            DataGridViewTextBoxColumn colCosto = new DataGridViewTextBoxColumn();
            colCosto.Visible = true;
            colCosto.HeaderText = "Costo";
            colCosto.Name = "colCosto";
            colCosto.DataPropertyName = "Costo";
            this.dgw.Columns.Add(colCosto);

            DataGridViewTextBoxColumn  colFecha = new DataGridViewTextBoxColumn();
            colFecha.Visible = true;
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "Fecha";
            colFecha.DataPropertyName = "Fecha";
            this.dgw.Columns.Add(colFecha);

            DataGridViewCheckBoxColumn colActivo = new DataGridViewCheckBoxColumn();
            colActivo.Visible = true;
            colActivo.HeaderText = "Activo";
            colActivo.Name = "Activo";
            colActivo.DataPropertyName = "Activo";
            this.dgw.Columns.Add(colActivo);

            this.dgw.DataSource = d;
            
        }

        private void cargarcombos_rutas()
        {
            funciones_Varias o = new funciones_Varias();
            DataTable r;

            DN_Corredores u = new DN_Corredores();
            u.pAll = 0;
            u.pNombre = "";
            u.Id = 1;
            u.IdEmpresa=datos.g_idEmpresa;
            u.IdUsuario=datos.g_idUser;

            r = u.Elementos_GET();
            o.CargarComboDataTable(this.cboOrigen, r, "id", "descripcion", false, true);

            u.Id = 2;
            r = u.Elementos_GET();
            o.CargarComboDataTable(this.cboDestino , r, "id", "descripcion", false, true);

            u.Id = 3;
            r = u.Elementos_GET();
            o.CargarComboDataTable(this.cboRetorno , r, "id", "descripcion", false, true);


        }
        private void frm_abm_corredores_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            Form p = new frm_abm_elementos();
            p.ShowDialog();
            cargarcombos_rutas();
         
        }

        private void c_Tipo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdGuadar_Click(object sender, EventArgs e)
        {

            //Validaciones
            if (validoForm() == true)
            {




                DN_Corredores dn = new DN_Corredores();
                
                if (opEditar == true)
                {
                    dn.pAll = 1;
                    dn.Id = Convert.ToInt32(this.txtIdCorredor.Text);
                }
                else
                {
                    dn.pAll = 0;
                    dn.Id = 0;
                }
                dn.Origen = this.cboOrigen.Text;
                dn.Destino = this.cboDestino.Text;
                dn.Retorno = this.cboRetorno.Text;
                dn.OneWay = Convert.ToDouble(this.txtOneWay.Text.ToString());
                dn.RoundTrip = Convert.ToDouble(this.txtRoundTrip.Text);
                dn.TTAT = Convert.ToDouble(this.TTA_Transporte.Text);
                dn.TTAC = Convert.ToDouble(this.TTA_Cliente.Text);
                dn.Tipo = Convert.ToInt32(this.c_Tipo.Checked);
                dn.Costo = Double.Parse(this.txtCosto.Text);
                dn.va = true;
                dn.Fecha = DateTime.Today.ToString("dd/MM/yyyy");
                dn.Activo = Convert.ToInt32(this.c_Activo.Checked);
                dn.IdEmpresa=datos.g_idEmpresa;
                dn.IdUsuario=datos.g_idUser;

                dn.Corredores_Grabar();


                //MPS 2022-06-27
                //VARIABLES
                if (opEditar == true)
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

                    cmdCommand.Parameters.Clear();
                    cmdCommand.CommandText = "SP_Tarifas_Actualizacion_Proveedores";
                    cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                    cmdCommand.Parameters.Add("intCorredor", MySqlDbType.Int32);
                    cmdCommand.Parameters.Add("decCosto", MySqlDbType.Decimal);
                    cmdCommand.Parameters.Add("intUsuario", MySqlDbType.Int32);
                    cmdCommand.Parameters.Add("datFechaAlta", MySqlDbType.DateTime);

                    cmdCommand.Parameters["intEmpresa"].Value = datos.g_idEmpresa;
                    cmdCommand.Parameters["intCorredor"].Value = Convert.ToInt32(this.txtIdCorredor.Text);
                    cmdCommand.Parameters["decCosto"].Value = this.txtCosto.Text;
                    cmdCommand.Parameters["intUsuario"].Value = datos.g_idUser;
                    cmdCommand.Parameters["datFechaAlta"].Value = DateTime.Today.ToString("dd/MM/yyyy");

                    cmdCommand.ExecuteNonQuery();
                    trsTransaccion.Commit();

                    cnnConnection.Close();
                }




                cargardataGrid();
                limpiarForm();
                MessageBox.Show ("Terminó");
            }
        }
        private void TextBoxFormattedOnEnter(object sender, EventArgs e)
        {
            // El control TextBox ha tomado el foco.
            //
            // Referenciamos el control TextBox que ha
            // desencadenado el evento.
            //
            TextBox tb = (TextBox)sender;

            // Mostramos en el control TextBox el valor
            // de la propiedad Tag sin formatear.
            //
            tb.Text = Convert.ToString(tb.Tag);

        }
        private void TextBoxChangeOnKeyPress(object sender, KeyPressEventArgs e)
        { 
            if (Convert.ToInt32(e.KeyChar)==46)
            {
                e.KeyChar = (char)44;
            }
        }
        private void TextBoxFormattedOnLeave(object sender, EventArgs e)
        {
            // El control TextBox ha perdido el foco.
            //
            // Referenciamos el control TextBox que ha
            // desencadenado el evento.
            //
            TextBox tb = (TextBox)sender;

            // Primero verificamos si el valor se puede convertir a Decimal.
            //
                decimal numero = default(decimal);
            bool bln = decimal.TryParse(tb.Text, out numero);

            if ((!(bln)))
            {
                // No es un valor decimal válido; limpiamos el control.
                tb.Clear();
                return;
            }

            // En la propiedad Tag guardamos el valor con todos los decimales.
            //
            tb.Tag = numero;

            // Y acto seguido formateamos el valor
            // a monetario con dos decimales.
            //
            tb.Text = string.Format("{0}", numero);

        }

        private void cmdEditar_Click(object sender, EventArgs e)
        {

            if (dgw.SelectedRows.Count > 0)
            {
                opEditar = true;
                this.txtIdCorredor.Text = this.dgw.CurrentRow.Cells[0].Value.ToString();
                this.cboOrigen.Text = this.dgw.CurrentRow.Cells[1].Value.ToString();
                this.cboDestino.Text = this.dgw.CurrentRow.Cells[2].Value.ToString();
                this.cboRetorno.Text = this.dgw.CurrentRow.Cells[3].Value.ToString();
                this.txtOneWay.Text = this.dgw.CurrentRow.Cells[4].Value.ToString();
                this.txtRoundTrip.Text = this.dgw.CurrentRow.Cells[5].Value.ToString();
                this.TTA_Transporte.Text = this.dgw.CurrentRow.Cells[6].Value.ToString();
                this.TTA_Cliente.Text = this.dgw.CurrentRow.Cells[7].Value.ToString();
                this.c_Tipo.Checked = Convert.ToBoolean(this.dgw.CurrentRow.Cells[8].Value);
                this.txtCosto.Text = this.dgw.CurrentRow.Cells[9].Value.ToString();


                this.c_Activo.Checked = Convert.ToBoolean(this.dgw.CurrentRow.Cells[11].Value);
            }
        }

        private bool validoForm()
        {
            bool ok = true;
            //Valido Combos



          
            if (this.cboOrigen.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboOrigen.Focus();
                return false;
            }
           
            if (this.cboDestino.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboDestino.Focus();
                return false;
            }

            if (c_Tipo.Checked == true)
            {
                if (this.cboRetorno.SelectedIndex == -1)
                {
                    MessageBox.Show("El combo no puede estar vacío", "Atención");
                    this.cboRetorno.Focus();
                    return false;
                }
               
            }

            this.lblmensaje.Visible = false;
            foreach (Control c in this.Controls)
            {
                if (c.GetType().Name.ToString() == "TextBox" || c.GetType().Name.ToString() == "k_TextBox_Num")
                {
                    if ((c.Text == string.Empty || c.Text == "No Puede estar Vacío") && c.Name != "cboRazonSocial")
                    {
                        this.lblmensaje.Visible = true;
                        this.lblmensaje.Text = "No Puede estar Vacío";
                        c.BackColor = Color.Red;
                        return  false;
                    }
                }
            }


            return ok;
        }
        private void Color_Blanco_Enter(object sender, EventArgs e)
        {

            switch (sender.GetType().Name)
            {
                case "TextBox": case "ComboBox": case "k_TextBox_Num":
                    ((TextBox)sender).BackColor = Color.White;
                    break;
            }
            //MessageBox.Show(sender.GetType().Name);

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
