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


namespace k_presentacion_00
{
    public partial class frm_CorredorClientes : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wpara, int lparam);

        //private bool opEditar=true;

        guardar_datos_login datos = guardar_datos_login.Instance();
        public frm_CorredorClientes()
        {

            InitializeComponent();

            
            this.lblUsuario.Text = datos.g_idUser + " " + datos.g_lastName;

        }

        private void frm_CorredorClientes_Load(object sender, EventArgs e)
        {
            //cargarcombos_rutas();
            //cargardataGrid();
            limpiarForm();
        }
        private void limpiarForm()
        {
            this.txtCosto.Text = "0,00";
            this.c_Activo.Checked = true;
            this.txtIdCorredor.Text = "0";
            cargarcombos_rutas();
            cargardataGrid();
            //opEditar = false;
        }
        private void cargardataGrid()
        {
            DN_ABM o = new DN_ABM();
            DataTable d = new DataTable();

            
    
            d = o.DN_Traer_DataTable("SP_ACC_Select", 0,datos.g_idEmpresa );

            this.dgw.Columns.Clear();

            this.dgw.AutoGenerateColumns = true;

            this.dgw.DataSource = d;

            this.dgw.Columns[0].Visible = false;
            this.dgw.Columns[2].Visible = false;
            this.dgw.Columns[3].HeaderText = "Origen";
            this.dgw.Columns[4].HeaderText = "Destino";
            this.dgw.Columns[5].HeaderText = "Retorno";

            this.dgw.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

        }
        private void pminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void cargarcombos_rutas()
        {
            funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();
            DataTable r;
            DataTable dt;
            DN_Corredores u = new DN_Corredores();


            u.pAll = 0;
            u.pNombre = "";
            u.Id = 1;
            u.IdEmpresa=datos.g_idEmpresa;

            
            dt = lista.DN_CargarDataTableGral("SP_Clientes_Get_All", 0, datos.g_idEmpresa);
            o.CargarComboDataTable(this.cboClientes, dt, "id", "descripcion", false, true);

            r = lista.DN_CargarDataTableGral("SP_Corredores_Combo", 0, datos.g_idEmpresa);
            o.CargarComboDataTable(this.cboRutas , r, "id", "descripcion", false, true);

          


        }
        private void frm_CorredorClientes_MouseDown(object sender, MouseEventArgs e)
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

                if ( c_Activo.Checked   == true)//Nuevo
                {
                    dn.pAll = 1;
                }
                else
                {
                    dn.pAll = 2;//Da de Baja
                }

                dn.Id = Convert.ToInt32(this.cboClientes.SelectedValue);
                dn.IdCorredor = Convert.ToInt32(this.cboRutas.SelectedValue);
                dn.Costo = Double.Parse(this.txtCosto.Text);
                dn.va = true;
                dn.Fecha = DateTime.Today.ToString("dd/MM/yyyy");
                dn.IdUsuario=datos.g_idUser;
                dn.IdEmpresa=datos.g_idEmpresa;
               //dn.Activo = Convert.ToInt32(this.c_Activo.Checked);

                dn.DN_asoc_Cliente_Transporte_Corredor("SP_ACC_Insert");
                
                limpiarForm();
                cargardataGrid();
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
            try
            {


                if (dgw.SelectedRows.Count > 0)
                {
                    //opEditar = true;
                    this.txtIdCorredor.Text = this.dgw.CurrentRow.Cells[0].Value.ToString();
                    this.cboClientes.Text = this.dgw.CurrentRow.Cells[1].Value.ToString();
                    this.cboRutas.SelectedValue  = this.dgw.CurrentRow.Cells[2].Value;
                    this.txtCosto.Text = this.dgw.CurrentRow.Cells[6].Value.ToString();
                    this.c_Activo.Checked = this.dgw.CurrentRow.Cells[8].Value.ToString() == "SI" ? true : false;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Debe seleccionar una fila para editar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool validoForm()
        {
          
            //Valido Combos

            if (this.cboClientes.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboClientes.Focus();
                return false;
            }
            if (this.cboRutas.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboRutas.Focus();
                return false;
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
                        return false;
                    }
                }
            }


            return true;
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

        private void cmdActualizar_Click(object sender, EventArgs e)
        {
            cargardataGrid();
        }

        private void dgw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdEditar_Click(sender, e);
                e.Handled = true;
            }
        }

        private void pminimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
