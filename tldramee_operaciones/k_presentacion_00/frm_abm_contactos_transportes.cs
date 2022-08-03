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
    public partial class frm_abm_contactos_transportes : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wpara, int lparam);
        private bool IsNew;
   
        guardar_datos_login datos = guardar_datos_login.Instance();

        public frm_abm_contactos_transportes()
        {
            InitializeComponent();
            
            this.lblUsuario.Text = datos.g_idUser + " " + datos.g_lastName;

            IsNew = false;


                this.Height = 585;
                this.cmdNew.Location = new Point(27, 527);
                this.cmdSave.Location = new Point(190, 527);
                this.cmdCancelar.Location = new Point(345,527);

            inicio();
           
        }

        private void inicio()
        {
            this.cboPais.SelectedIndexChanged -= new System.EventHandler(cboPais_SelectedIndexChanged);
            this.cboContactos.SelectedIndexChanged -= new System.EventHandler(cboContacto_SelectedIndexChanged);
           
            ocultar_new_cmd(IsNew);
            cargarcombos();
            limpiarcontroles();
            cargarContactos();
            cargartransportista();

            this.cboContactos.SelectedIndexChanged += new System.EventHandler(cboContacto_SelectedIndexChanged);
            this.cboPais.SelectedIndexChanged += new System.EventHandler(cboPais_SelectedIndexChanged);
            
            
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

        private void cargarContactos()
        {
            funciones_Varias o = new funciones_Varias();
            DataTable r;
            DN_ABM u = new DN_ABM();
            r = u.DN_Traer_DataTable("SP_Contactos_Get_All",2, datos.g_idEmpresa );
            o.CargarComboDataTable(this.cboContactos, r, "id", "descripcion", false, true);

        }
        private void cargartransportista()
        {
            string SP=string.Empty;
            funciones_Varias o = new funciones_Varias();
            DataTable r;
            DN_ABM u = new DN_ABM();


            SP = "SP_Transportistas_Get_All"; 

            r = u.DN_Traer_DataTable ( SP,0,datos.g_idEmpresa );
            o.CargarComboDataTable(this.cboCT , r, "id", "descripcion", false, true);

        }
        private void cargarcombos()
        {

            DNTablas_Gral lista = new DNTablas_Gral();

            DataTable p;
            funciones_Varias o= new funciones_Varias();

            //p = lista.Get_Condicion_Pago();
            //o.CargarComboDataTable(cboCondicionPago, p, "id", "descripcion", false);

            p = lista.DN_CargarDataTableGral ("SP_Get_Paises",0,0);
            o.CargarComboDataTable(cboPais, p, "id", "descripcion", false, true);

            //p = lista.Get_Tipo_De_IVA();
            //o.CargarComboDataTable(cboCondicionIVA, p, "id", "Descripcion", false);

            p = lista.DN_CargarDataTableGral("SP_Get_Estados",0,0);
            o.CargarComboDataTable(cboEstado, p, "id", "descripcion", false, true);

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
            try
            {
                bool ok = Int32.TryParse(cboProvincia.SelectedValue.ToString(), out p_idProv);

                DNTablas_Gral lista = new DNTablas_Gral();
                cboLocalidad.DataSource = lista.Get_Localidades(p_idProv);
                cboLocalidad.DisplayMember = "descripcion";
                cboLocalidad.ValueMember = "id";
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }

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
            this.txtNewContacto.Visible = x;
            this.cboContactos.Visible= !x;
        }
        private void cboContacto_SelectedIndexChanged(object sender,System.EventArgs e)
        {
            DN_ABM d = new DN_ABM();
            int ID;
            ID = Convert.ToInt32(cboContactos.SelectedValue);
            d.DN_Contactos_Get_Id(ID,datos.g_idEmpresa );
            this.cboCT.SelectedItem = Convert.ToInt32(d.IdOrigen);
            this.cboPais.SelectedValue = d.Pais;
            this.cboProvincia.SelectedValue = d.Prov;
            this.cboLocalidad.SelectedValue = d.Loc; 
            this.txtDireccion.Text = d.Direccion;
            this.txtPostal.Text = d.Cp;
            this.txtTel1 .Text = d.Tel1;
            this.txtTel2.Text = d.Tel2;
            this.txtFax.Text  = d.Fax ;
            this.txtEmail .Text = d.Email;
            this.cboEstado.SelectedValue  = d.Estado ;

            this.cboCT.SelectedValue = d.IdOrigen;

            IsNew = false;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            IsNew = false;
            inicio();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            string strStoredProcedures;

            if (validar_controles() == false)
            {
                return;
            }
            DN_ABM objClientes = new DN_ABM();
            //objeto para hacer algo con la DB supongo
            //*******//
            //ID

            guardar_datos_login datos = guardar_datos_login.Instance();
            if (IsNew == true)
            {
                objClientes.Id = 0;
                objClientes.Nombre = this.txtNewContacto.Text;
                strStoredProcedures = "SP_Contactos_Insert";

            }
            else
            {
                objClientes.Id = Convert.ToInt32(this.cboContactos.SelectedValue);
                objClientes.Nombre = this.cboContactos.Text.ToString();
                strStoredProcedures = "SP_Contactos_Update";
            }
            objClientes.Empresa = datos.g_idEmpresa;
            objClientes.Pais= Convert.ToInt32(this.cboPais.SelectedValue);
            objClientes.Prov = Convert.ToInt32(this.cboProvincia.SelectedValue);
            objClientes.Loc = this.cboLocalidad.SelectedValue.ToString();
            objClientes.Empresa = datos.g_idEmpresa;
            objClientes.Direccion = this.txtDireccion.Text;
            objClientes.Cp = this.txtPostal.Text;
            objClientes.Tel1 = this.txtTel1.Text;
            objClientes.Tel2 = this.txtTel2.Text;
            objClientes.Fax = this.txtFax.Text;
            objClientes.Email = this.txtEmail.Text;
            objClientes.Estado = Convert.ToInt32(this.cboEstado.SelectedValue);
            objClientes.EsDe =2;
            objClientes.IdOrigen  = Convert.ToInt32(this.cboCT.SelectedValue);

            int ok_Transaccion;
            ok_Transaccion = objClientes.DN_Contactos_Insert_Update(strStoredProcedures);

            if (ok_Transaccion != 0)
            {
                IsNew = false;
                inicio();
            }



        }
        private bool validar_controles()
        {
            //bool ok=true;
            //TextBox razon Social
            if (IsNew == true)
            {
                if (this.txtNewContacto.Text == string.Empty || this.txtNewContacto.Text == "No Puede estar Vacío")
                {
                    this.txtNewContacto.Text = "No Puede estar Vacío";
                    this.txtNewContacto.BackColor = Color.Red;
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
                    if ((c.Text == string.Empty || c.Text == "No Puede estar Vacío") && c.Name != "cboContactos")
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
            if (IsNew == false)
            {
                if (this.cboContactos.SelectedIndex == -1)
                {
                    MessageBox.Show("El combo no puede estar vacío", "Atención");
                    this.cboContactos.Focus();
                    return false;
                }
            }

            


            return true;

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

        private void frm_abm_contactos_transportes_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
   
}
