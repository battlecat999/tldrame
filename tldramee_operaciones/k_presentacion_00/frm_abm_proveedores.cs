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
    public partial class frm_abm_proveedores : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wpara, int lparam);
        private bool IsNew;
        string strStoredProcedure = string.Empty;
        string strStored_Carga_CboRazon_Social = string.Empty;//SP_Clientes_Get_All
        string strStored_Carga_Datos = string.Empty;//SP_Clientes_Get_Id


        guardar_datos_login datos = guardar_datos_login.Instance();
        public frm_abm_proveedores()
        {
            InitializeComponent();

            
            this.lblUsuario.Text = datos.g_idUser + " " + datos.g_lastName;

            IsNew = false;

            inicio();

                this.BackColor = Color.FromArgb(227,98,0);
                this.lblTitulo.Text = "Matenimiento de Proveedores";
            
        }

        private void inicio()
        {
            this.cboPais.SelectedIndexChanged -= new System.EventHandler(cboPais_SelectedIndexChanged);
            this.cboRazonSocial.SelectedIndexChanged -= new System.EventHandler(cboRazonSocial_SelectedIndexChanged);
            this.cboProvincia.SelectedIndexChanged -= new System.EventHandler(cboProvincia_SelectedIndexChanged);

            cargarNombreSP();

            ocultar_new_cmd(IsNew);

            cargarcombos();
            limpiarcontroles();
            cargar_clientes_transportistas ();

            this.cboRazonSocial.SelectedIndexChanged += new System.EventHandler(cboRazonSocial_SelectedIndexChanged);
            this.cboPais.SelectedIndexChanged += new System.EventHandler(cboPais_SelectedIndexChanged);
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(cboProvincia_SelectedIndexChanged);


            //if (IsNew == true)
            //{
            //    this.cmdSave.Enabled = false;
            //}
            //else this.cmdSave.Enabled = true;

        }
        private void limpiarcontroles()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType().Name.ToString() != "Button" && c.GetType().Name.ToString() != "Label" && c.GetType().Name.ToString()!="CheckBox")
                {
                    if (c.Name == "txtNewRazonSocial")
                    {
                        c.Text = string.Empty;
                    }else
                    {
                        c.Text = string.Empty;
                    }
                    
                }
            }
            this.opMoro.Checked = false;
        }

        private void cargar_clientes_transportistas()
        {
            funciones_Varias o = new funciones_Varias();
            DataTable r;
            DN_ABM u = new DN_ABM();
           
            r = u.DN_Traer_DataTable(strStored_Carga_CboRazon_Social, 0,datos.g_idEmpresa );
            
            o.CargarComboDataTable(this.cboRazonSocial, r, "id", "descripcion", false, true);

        }
        private void cargarcombos()
        {

            DNTablas_Gral lista = new DNTablas_Gral();

            DataTable p;
            funciones_Varias o= new funciones_Varias();

            //p = lista.DN_CargarDataTableGral ("SP_Condicion_de_Pago", 0, 0);
            //o.CargarComboDataTable(cboCondicionIVA, p, "id", "descripcion", false);

            p = lista.DN_CargarDataTableGral("SP_Get_tipoCondIVA", 0, 0);
            o.CargarComboDataTable(cboCondicionIVA, p, "id", "descripcion", false, true, false, true);

            p = lista.DN_CargarDataTableGral("SP_Get_Estados", 0, 0);
            o.CargarComboDataTable(cboEstado, p, "id", "descripcion", false, true, false, true);

            p = lista.DN_CargarDataTableGral("SP_Get_Paises", 0, 0);
            o.CargarComboDataTable(cboPais, p, "id", "descripcion", false, true, false, true);


        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            int p_idPais;
            DataTable p;
            funciones_Varias o = new funciones_Varias();
            bool ok= Int32.TryParse(cboPais.SelectedValue.ToString(), out p_idPais);

            this.cboProvincia.SelectedIndexChanged -= new System.EventHandler(cboProvincia_SelectedIndexChanged);

            DNTablas_Gral lista = new DNTablas_Gral();
            
            p = lista.Get_Provincias(p_idPais);
            o.CargarComboDataTable(cboProvincia, p, "id", "provincia",  false,false ,false, true);

            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(cboProvincia_SelectedIndexChanged);
            cboProvincia_SelectedIndexChanged(sender,e);
        }
         private void cboProvincia_SelectedIndexChanged(object sender,System.EventArgs e)
         {
            int p_idProv;
            string p_cbo;
            DataTable p;
            funciones_Varias o = new funciones_Varias();
            if (cboProvincia.Text == string.Empty)
            {
                p_cbo = "0";
            }else
            {
                p_cbo = cboProvincia.SelectedValue.ToString();
            }

            bool ok = Int32.TryParse(p_cbo , out p_idProv);

            DNTablas_Gral lista = new DNTablas_Gral();
            p = lista.Get_Localidades(p_idProv);
            o.CargarComboDataTable(cboLocalidad , p, "id", "descripcion", false, false, false, true);
        }
        private void cboLocalidad_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
        }
        private void cmbNew_Click(object sender, EventArgs e)
        {
            IsNew = true;
            inicio();

        }
        private void ocultar_new_cmd(bool x)
        {
            this.txtNewRazon.Visible = x;
            this.cboRazonSocial.Visible= !x;
        }
        private void cboRazonSocial_SelectedIndexChanged(object sender,System.EventArgs e)
        {
            DN_ABM d = new DN_ABM();

            d.Id = Convert.ToInt32(cboRazonSocial.SelectedValue);
            guardar_datos_login datos = guardar_datos_login.Instance();

            if (d.Id == 0)
            {
                return ;
            }
            d.DN_Proveedores_Get_Id(strStored_Carga_Datos, datos.g_idEmpresa,d.Id);



            this.cboPais.SelectedValue = d.Pais;
            this.cboProvincia.SelectedValue = d.Prov;
            this.cboLocalidad.SelectedValue = d.Loc; 
            this.txtDireccion.Text = d.Direccion;
            this.txtPostal.Text = d.Cp;
            this.txtTel1 .Text = d.Tel1;
            this.txtEmail .Text = d.Email;
            this.txtSite .Text = d.Site;
            this.txtCUIT .Text = d.Cuit;
            this.cboEstado.SelectedValue  = d.Estado ;
            //this.cboCondicionIVA.SelectedValue = d.Codiva ;
            this.cboCondicionIVA.SelectedValue = d.Codpago ;
            this.opMoro.Checked = Convert.ToBoolean(d.OpMoro);

            IsNew = false;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            IsNew = false;
            inicio();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {


            if (validar_controles() == false)
            {
                return;
            }
            DN_ABM objProveedor = new DN_ABM();
            //objeto para hacer algo con la DB supongo
            //*******//
            //ID
            if (IsNew == true)
            {
                objProveedor.Id = 0;
                objProveedor.Nombre = this.txtNewRazon.Text;
            }
            else
            {
                objProveedor.Id = Convert.ToInt32(this.cboRazonSocial.SelectedValue);
                objProveedor.Nombre = this.cboRazonSocial.Text.ToString();
            }
            objProveedor.Va = true;
            objProveedor.Pais= Convert.ToInt32(this.cboPais.SelectedValue);
            objProveedor.Prov = Convert.ToInt32(this.cboProvincia.SelectedValue);
            objProveedor.Loc = this.cboLocalidad.SelectedValue.ToString();
            objProveedor.Direccion = this.txtDireccion.Text;
            objProveedor.Cp = this.txtPostal.Text;
            objProveedor.Tel1 = this.txtTel1.Text;
            objProveedor.Email = this.txtEmail.Text;
            objProveedor.Site = this.txtSite.Text;
            objProveedor.Cuit = this.txtCUIT.Text;
            objProveedor.Estado = Convert.ToInt32(this.cboEstado.SelectedValue);
            objProveedor.Codpago = Convert.ToInt32(this.cboCondicionIVA.SelectedValue);
            objProveedor.OpMoro = Convert.ToInt32(this.opMoro.Checked);

            cargarNombreSP();

            int ok_Transaccion;
            ok_Transaccion = objProveedor.ABM_Proveedores_De_Form_a_DN(strStoredProcedure,datos.g_idEmpresa,datos.g_idUser );

            if (ok_Transaccion == 1)
            {
                IsNew = false;
                inicio();
            }
            
        }
        private void cargarNombreSP()
        {

            
                if (IsNew == true)
                {
                    strStoredProcedure = "SP_Transportistas_Insert";
                }
                else
                {
                    strStoredProcedure = "SP_Transportistas_Update";
                }
                strStored_Carga_CboRazon_Social = "SP_Transportistas_Get_All";
                strStored_Carga_Datos = "SP_Transportistas_Get_Id";
            
        }
        private bool validar_controles()
        {
            bool ok=true;
            //TextBox razon Social
            if (IsNew == true)
            {
                if (this.txtNewRazon.Text == string.Empty || this.txtNewRazon.Text == "No Puede estar Vacío")
                {
                    this.txtNewRazon.Text = "No Puede estar Vacío";
                    this.txtNewRazon.BackColor = Color.Red;
                    return false;
                }
            }
            else//No es vacio valido el combo
            {
                //MessageBox.Show(this.cboRazonSocial.SelectedValue.ToString());

                return true;
            }

            foreach (Control c in this.Controls)
            {
                if (c.GetType().Name.ToString() == "TextBox" || c.GetType().Name.ToString() == "ComboBox")
                {
                    if((c.Text == string.Empty || c.Text == "No Puede estar Vacío") && c.Name !="cboRazonSocial")
                    {
                        c.Text = "No Puede estar Vacío";
                        c.BackColor = Color.Red;
                        return false;
                    }
                }
            }

            //Valido Combos

            if (this.cboCondicionIVA.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboCondicionIVA.Focus();
                return false;
            }
            if (this.cboEstado.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboEstado.Focus();
                return false;
            }
            if (this.cboPais.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboPais.Focus();
                return false;
            }
            if (this.cboProvincia.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboProvincia.Focus();
                return false;
            }
            if (this.cboLocalidad.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboLocalidad.Focus();
                return false;
            }


            if (IsNew == false)
            {
                if (this.cboRazonSocial.SelectedIndex == -1)
                {
                    MessageBox.Show("El combo no puede estar vacío", "Atención");
                    this.cboRazonSocial.Focus();
                    return false;
                }
            }




            return ok;

        }
        
        
        private void pClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            prestaurar.Visible = true;
            pmaximizar.Visible = false;
        }

        private void prestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            prestaurar.Visible = false;
            pmaximizar.Visible = true;
        }

        private void pminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Color_Blanco_Enter(object sender, EventArgs e)
        {

            //MessageBox.Show(sender.GetType().Name);
             if (sender.GetType().Name == "TextBox")
            {
                if(((TextBox)sender).Text=="No Puede estar Vacío") { ((TextBox)sender).Text = ""; }
                ((TextBox)sender).BackColor = Color.White;
            }
            else if(sender.GetType().Name == "ComboBox")
            {
                if (((ComboBox)sender).Text == "No Puede estar Vacío") { ((ComboBox)sender).Text = ""; }
                ((ComboBox)sender).BackColor = Color.White;
            }
            
        }

        private void frm_abm_proveedores_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void cboRazonSocial_Leave(object sender, EventArgs e)
        {
            string nombreNuevo;
            //this.cboRazonSocial.SelectedIndexChanged -= new System.EventHandler(cboRazonSocial_SelectedIndexChanged);
            if (this.cboRazonSocial.SelectedIndex == -1 && this.cboRazonSocial.Text !=string.Empty )
            {
                if (MessageBox.Show("No existe el nombre del contacto.¿Desea darlo de Alta?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    nombreNuevo = this.cboRazonSocial.Text;
                    IsNew = true;
                    inicio();
                    this.txtNewRazon.Text = nombreNuevo;
                }

            }
           // this.cboRazonSocial.SelectedIndexChanged += new System.EventHandler(cboRazonSocial_SelectedIndexChanged);
        }

        private void text_Mayuscula(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (Char.IsLower(e.KeyChar))
            {
                tb.SelectedText = Char.ToUpper(e.KeyChar).ToString();

                e.Handled = true;
            }
        }
        private void combo_Mayuscula(object sender, KeyPressEventArgs e)
        {
            ComboBox tb = (ComboBox)sender;
            if (Char.IsLower(e.KeyChar))
            {
                tb.SelectedText = Char.ToUpper(e.KeyChar).ToString();

                e.Handled = true;
            }
        }
    }
   
}
