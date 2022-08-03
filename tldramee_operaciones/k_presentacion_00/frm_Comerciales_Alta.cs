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
    public partial class frm_Comerciales_Alta : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wpara, int lparam);

        
        guardar_datos_login datos = guardar_datos_login.Instance();

        public frm_Comerciales_Alta()
        {
            InitializeComponent();
            
            this.lblUsuario.Text = datos.g_idUser + " " + datos.g_lastName;

        
            inicio();
        }

        private void inicio()
        {
            this.cboRazonSocial.SelectedIndexChanged -= new System.EventHandler(cboRazonSocial_SelectedIndexChanged);
            
            cargarclientes();

            this.cboRazonSocial.SelectedIndexChanged += new System.EventHandler(cboRazonSocial_SelectedIndexChanged);
            
        }

        private void frm_Comerciales_Alta_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
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
        }
        private void cargarContactos() { 
            funciones_Varias o = new funciones_Varias();
            DataTable r;
            DN_ABM u = new DN_ABM();

            this.cboContactos.SelectedIndexChanged -= new System.EventHandler(cboContactos_SelectedIndexChanged);
            int idCliente;
            idCliente = Convert.ToInt32(this.cboRazonSocial.SelectedValue);

            r = u.DN_Contactos_Clientes_Por_Id("SP_Contactos_Clientes_Por_Id",datos.g_idEmpresa, idCliente,1);
            o.CargarComboDataTable(this.cboContactos, r, "id", "descripcion", false, true);

            this.cboContactos.SelectedIndexChanged += new System.EventHandler(cboContactos_SelectedIndexChanged);
            //

            this.txtNovedades.Text = BuscarHistorial(idCliente);

        }
        private string  BuscarHistorial(int idCliente)
        {
            string str_historial;
            DN_Comerciales DN_v = new DN_Comerciales();
            DN_v.IdCliente = idCliente;
            str_historial =  DN_v.Buscar_Historial_Por_Cliente().ToString ();
            return str_historial;
        }

        private void cboContactos_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DN_ABM d = new DN_ABM();
            int ID;
            ID = Convert.ToInt32(cboContactos.SelectedValue);
            d.DN_Contactos_Get_Id(ID,datos.g_idEmpresa );


            this.txtTel1.Text = d.Tel1;
            this.txtTel2.Text = d.Tel2;
            this.txtFax.Text = d.Fax;
            this.txtEmail.Text = d.Email;

        }
        private void pminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void cmd_Guardar_IN_OUT(object sender, EventArgs e)
        {
            int IN_OUT_Val;
            Button button = sender as Button;

            if (validoComerciales(this.cboRazonSocial, this.cboContactos) == false)
            {
                return;
            }

            if (button.Name  == "cmdIN")
            {
                IN_OUT_Val = 0;
            }
            else
            {
                IN_OUT_Val = 1;
            }

            frm_Comerciales_Llamadas_IN_OUT oForm = new frm_Comerciales_Llamadas_IN_OUT(IN_OUT_Val);


            if (oForm.ShowDialog() == DialogResult.Yes)
            {
                //MessageBox.Show(oForm.txtDetalle.Text);
                funciones_envio_emails outlook = new funciones_envio_emails();
                DN_Comerciales dn_c = new DN_Comerciales();

                dn_c.IdEmpresa = datos.g_idEmpresa;
                dn_c.IdCliente = Convert.ToInt32(this.cboRazonSocial.SelectedValue);
                dn_c.IdContacto= Convert.ToInt32(this.cboContactos.SelectedValue);
                dn_c.Tel_01 = this.txtTel1.Text;
                dn_c.Tel_02 = this.txtTel2.Text;
                dn_c.Fax = this.txtFax.Text;
                dn_c.Email = this.txtEmail.Text;
                dn_c.IN_OUT1 = 0;
                dn_c.Detalle = oForm.txtDetalle.Text;
                dn_c.Envio_email = oForm.cEnviaPorEmail.Checked;
                dn_c.C_opcion = oForm.txtTipoLlamado.Text;
                dn_c.IdUsuario = datos.g_idUser;
                dn_c.NomUsuario = datos.g_userName;
                dn_c.DN_Grabar_Movimiento_Comercial_IN_OUT();

                if (oForm.cEnviaPorEmail.Checked == true)
                {
                    bool validoEmail;
                    validoEmail = outlook.email_bien_escrito(this.txtEmail.Text);
                    if (validoEmail == true)
                    {
                        outlook.SendEmailWithOutlook(this.txtEmail.Text, "Aviso de Llamado", oForm.txtDetalle.Text, string.Empty,false);
                    }
                    outlook = null;
                }
           }
            oForm.Dispose();
            oForm = null;
            this.txtNovedades.Text = BuscarHistorial(Convert.ToInt32(this.cboRazonSocial.SelectedValue));



        }
        private bool validoComerciales(ComboBox cbC, ComboBox cbCT)
        {
            bool ok;
            ok = true;
            if (string.IsNullOrEmpty(cbC.Text) || cbC.SelectedIndex==-1)
            {
                MessageBox.Show("Selecciones un Cliente");
                ok = false;
            }
            if (string.IsNullOrEmpty(cbCT.Text) || cbCT.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciones un Contacto");
                ok = false;
            }


            return ok;

        }

        private void pClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdReprogramar_Click(object sender, EventArgs e)
        {
            if (validoComerciales(this.cboRazonSocial, this.cboContactos) == false)
            {
                return;
            }

            frm_Comerciales_AgendarLlamado oForm = new frm_Comerciales_AgendarLlamado();
            if (oForm.ShowDialog() == DialogResult.Yes)
            {
                DateTime  Fecha_Reunion;
                string Horario;
               
                Horario = oForm.txtFecha.Text + " " + oForm.cboHorarios.Text;
                Fecha_Reunion = Convert.ToDateTime(Horario);

                funciones_envio_emails outlook = new funciones_envio_emails();
                if (outlook.Agregar_Evento_Calendario(this.cboRazonSocial.Text, this.cboContactos.Text, Fecha_Reunion, string.Empty,this.txtTel1.Text ,1)== true)
                {
                    MessageBox.Show("Reunión Agendada", "Atención");
                }
            }
        }

        private void cmdRQ_Coti_Click(object sender, EventArgs e)
        {
            if (validoComerciales(this.cboRazonSocial, this.cboContactos) == false)
            {
                return;
            }

            //frm_Comerciales_Alta_Presupuestos oForm = new frm_Comerciales_Alta_Presupuestos();
            //oForm.txtIdCliente.Text = Convert.ToString(this.cboRazonSocial.SelectedValue);
            //oForm.txtCliente.Text = Convert.ToString(this.cboRazonSocial.Text);
            //oForm.txtIdContacto.Text = Convert.ToString(this.cboContactos.SelectedValue);
            //oForm.txtContacto .Text = Convert.ToString(this.cboContactos.Text);
            //if (oForm.ShowDialog() == DialogResult.Yes)
            //{
            //    MessageBox.Show("Presupuesto generado!!!", "Aviso!!!", MessageBoxButtons.OK);
            //}
        }
        private void cmdPlanificarEntrevistas_Click(object sender, EventArgs e)
        {

        }

        private void frm_Comerciales_Alta_Load(object sender, EventArgs e)
        {

        }

        private void CmdNuevaActividad_Click(object sender, EventArgs e)
        {

        }
    }
}
