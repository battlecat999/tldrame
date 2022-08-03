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
    public partial class frm_abm_clientes : Form
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
        public frm_abm_clientes()
        {
            

            InitializeComponent();


            funciones_Varias fv = new funciones_Varias();

            fv.ColorearGradientPanel(this, this.PanelPrincipal);



            this.lblUsuario.Text = datos.g_idUser + " " + datos.g_lastName;

            IsNew = false;

            inicio();               

            this.lblTitulo.Text = "Matenimiento de Clientes";


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

            if (IsNew == true)
            {
                this.cmdSave.Enabled = false;
            }else this.cmdSave.Enabled = true;

        }
        private void limpiarcontroles()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType().Name.ToString() != "Button" && c.GetType().Name.ToString() != "Label")
                {
                    if (c.Name == "txtNewRazonSocial")
                    {
                        c.Text = string.Empty;
                    }else
                    {
                        c.Text = "S/N";//String.Empty;
                    }
                    
                }
            }
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
            
            p = lista.DN_CargarDataTableGral ("SP_Condicion_de_Pago", 0, 0);
            o.CargarComboDataTable(cboCondicionPago, p, "id", "descripcion", false, true);


            //p = lista.DN_CargarDataTableGral("SP_Get_tipoCondIVA", 0, 0);
            //o.CargarComboDataTable(cboCondicionIVA, p, "id", "descripcion", false);

            p = lista.DN_CargarDataTableGral("SP_Get_Estados", 0, 0);
            o.CargarComboDataTable(cboEstado, p, "id", "descripcion", false, true);
            p = lista.DN_CargarDataTableGral("SP_Get_Paises", 0, 0);
            o.CargarComboDataTable(cboPais, p, "id", "descripcion", false, true);


        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            int p_idPais;
            bool ok= Int32.TryParse(cboPais.SelectedValue.ToString(), out p_idPais);

            DNTablas_Gral lista = new DNTablas_Gral();
            
            cboProvincia.DataSource = lista.Get_Provincias(p_idPais);
            cboProvincia.DisplayMember = "provincia";
            cboProvincia.ValueMember = "id";
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(cboProvincia_SelectedIndexChanged);
            cboProvincia_SelectedIndexChanged(sender,e);
        }
         private void cboProvincia_SelectedIndexChanged(object sender,System.EventArgs e)
         {
            int p_idProv;
            string p_cbo;
            if (cboProvincia.Text == string.Empty)
            {
                p_cbo = "0";
            }else
            {
                p_cbo = cboProvincia.SelectedValue.ToString();
            }

            bool ok = Int32.TryParse(p_cbo , out p_idProv);

            DNTablas_Gral lista = new DNTablas_Gral();
            cboLocalidad.DataSource = lista.Get_Localidades(p_idProv);
            cboLocalidad.DisplayMember = "descripcion";
            cboLocalidad.ValueMember = "id";
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
                return ;

            d.DN_Clientes_Get_Id(strStored_Carga_Datos, datos.g_idEmpresa,d.Id);



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
            this.cboCondicionPago.SelectedValue = d.Codpago ;
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
            DN_ABM objClientes = new DN_ABM();
            //objeto para hacer algo con la DB supongo
            //*******//
            //ID
            if (IsNew == true)
            {
                objClientes.Id = 0;
                objClientes.Nombre = this.txtNewRazon.Text;
            }
            else
            {
                objClientes.Id = Convert.ToInt32(this.cboRazonSocial.SelectedValue);
                objClientes.Nombre = this.cboRazonSocial.Text.ToString();
            }
            objClientes.Va = true;
            objClientes.Pais= Convert.ToInt32(this.cboPais.SelectedValue);
            objClientes.Prov = Convert.ToInt32(this.cboProvincia.SelectedValue);
            objClientes.Loc = this.cboLocalidad.SelectedValue.ToString();
            objClientes.Direccion = this.txtDireccion.Text;
            objClientes.Cp = this.txtPostal.Text;
            objClientes.Tel1 = this.txtTel1.Text;
            objClientes.Email = this.txtEmail.Text;
            objClientes.Site = this.txtSite.Text;
            objClientes.Cuit = this.txtCUIT.Text;
            objClientes.Estado = Convert.ToInt32(this.cboEstado.SelectedValue);
            objClientes.fechaInicio  = DateTime.Now.ToShortDateString ();
            objClientes.Codpago = Convert.ToInt32(this.cboCondicionPago.SelectedValue);
            cargarNombreSP();
            

            int ok_Transaccion;
            ok_Transaccion = objClientes.ABM_Clientes_De_Form_a_DN(strStoredProcedure,datos.g_idEmpresa,datos.g_idUser );

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
                    strStoredProcedure = "SP_Clientes_Insert";
                }
                else
                {
                    strStoredProcedure = "SP_Clientes_Update";
                }
                strStored_Carga_CboRazon_Social = "SP_Clientes_Get_All";
                strStored_Carga_Datos = "SP_Clientes_Get_Id";


            

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
            if (this.cboCondicionPago.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboCondicionPago.Focus();
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

        private void frm_abm_clientes_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void cboRazonSocial_Leave(object sender, EventArgs e)
        {
            string nombreNuevo;
            if (this.cboRazonSocial.SelectedIndex == -1)
            {
                if (MessageBox.Show("No existe el nombre del contacto.¿Desea darlo de Alta?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    nombreNuevo = this.cboRazonSocial.Text;
                    IsNew = true;
                    inicio();
                    this.txtNewRazon.Text = nombreNuevo;
                }

            }
        }
    }
   
}
