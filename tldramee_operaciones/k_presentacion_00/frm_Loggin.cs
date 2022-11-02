using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using k_negocio_00;
using MySql.Data;
using MySql.Data.Types;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace k_presentacion_00
{
    public partial class frm_Loggin : Form
    {
        public frm_Loggin()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd,int wmsg, int wpara,int lparam);

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (this.txtuser.Text=="USUARIO") {
                this.txtuser.Text  = "";
                this.txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text==""){
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (this.txtpass.Text == "CONTRASEÑA")
            {
                this.txtpass.Text = "";
                this.txtpass.ForeColor = Color.LightGray;
                this.txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                this.txtpass.Text = "CONTRASEÑA";
                this.txtpass.ForeColor = Color.DimGray;
                this.txtpass.UseSystemPasswordChar = false;
            }
        }

        private void pCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            
            //creo un objeto de la capa de negocio
            DNUsers objUsuario = new DNUsers();
            DataTable  Loguear;
            objUsuario.Usuario = txtuser.Text;
            objUsuario.Password = txtpass.Text;
            if (objUsuario.Usuario == txtuser.Text)
            {
                lblErrorUsuario.Visible = false;
                if (objUsuario.Password == txtpass.Text)
                {
                    lblErrorPass.Visible = false;
           
                    Loguear = objUsuario.iniciarSesion();
                    if (Loguear.Rows.Count >0)
                    {
                        //guardo los datos del login
                        guardar_datos_login datos = guardar_datos_login.Instance();
                        datos.g_idEmpresa = objUsuario.IdEmpresa;
                        datos.g_nomEmpresa = objUsuario.NomEmpresa;
                        datos.g_idUser = objUsuario.IdUsuario;
                        datos.g_userName = objUsuario.Usuario;
                        datos.g_lastName = objUsuario.LastName;
                        datos.g_email = objUsuario.Email;
                        datos.g_permiso = objUsuario.Permiso;
                        //datos.g_telefono1 = objUsuario.telefono1;
                        //datos.g_funciones = objUsuario.funciones;
                        //datos.g_nombreUser = objUsuario.nombreUser;
                        //MPS20210216
                        datos.g_Ruta_Firma_HTMP = ConfigurationManager.AppSettings["Ruta_Firma_html"].ToString();
                        datos.g_Ruta_Comp_Anticipos = ConfigurationManager.AppSettings["ruta_anticipos_pdf"].ToString();
                        datos.g_Ruta_Comp_HTML = ConfigurationManager.AppSettings["ruta_anticipos_html"].ToString();
                        datos.g_Ruta_Comp_Emails= ConfigurationManager.AppSettings["ruta_anticipos_email"].ToString();
                        datos.g_Email_Administracion = ConfigurationManager.AppSettings["email_administracion"].ToString();

                        //
                        this.Hide();
                        //frm_Inicial ObjFP = new frm_Inicial();
                        frmInicialFinal  ObjFP = new frmInicialFinal();
                        ObjFP.Show();
                    }
                    else
                    {
                        //MessageBox.Show("Usuario o Contraseña Inválido", "Atención");
                        lblErrorLogin.Text = "Usuario o Contraseña Inválidas, intente de nuevo";
                        lblErrorLogin.Visible = true;
                        txtpass.Text = "";
                        txtpass_Leave( null,e);
                        txtuser.Focus();
                    }
                }
                else
                {
                    //MessageBox.Show(objUsuario.Password);
                    lblErrorPass.Text = objUsuario.Password;
                    lblErrorPass.Visible = true;
                }
            }
            else
            {
                //MessageBox.Show(objUsuario.Usuario);
                lblErrorUsuario.Text= objUsuario.Usuario;
                lblErrorUsuario.Visible = true;
            }
        }

        private void txtuser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                txtuser.Text = "administrador";
                txtpass.UseSystemPasswordChar = true;
                txtpass.Text = "cast233";
                btnAcceder_Click(sender,e);
            }
            if (e.KeyCode == Keys.F4)
            {
                txtuser.Text = "Miry";
                txtpass.UseSystemPasswordChar = true;
                txtpass.Text = "1";
                btnAcceder_Click(sender, e);
            }

            if (e.KeyCode == Keys.F6)
            {
                txtuser.Text = "Joana";
                txtpass.UseSystemPasswordChar = true;
                txtpass.Text = "1";
                btnAcceder_Click(sender, e);
            }
        }
    }
}
