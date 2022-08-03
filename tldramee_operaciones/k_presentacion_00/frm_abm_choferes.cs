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
using System.Text.RegularExpressions;

namespace k_presentacion_00
{
    public partial class frm_abm_choferes : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wpara, int lparam);

        private bool IsNew;
   
        guardar_datos_login datos = guardar_datos_login.Instance();

        bool IsBlackList;
        public frm_abm_choferes()
        {
            InitializeComponent();
           
            this.lblUsuario.Text = datos.g_idUser + " " + datos.g_lastName;

            IsNew = false;
            
            
           
        }

        private void frm_abm_choferes_Load(object sender, EventArgs e)
        {
              
            inicio();
           
        }
        private void inicio()
        {
            this.cboPais.SelectedIndexChanged -= new System.EventHandler(cboPais_SelectedIndexChanged);
            //this.cboProvincia.SelectedIndexChanged -= new System.EventHandler(cboProvincia_SelectedIndexChanged);
            //this.cboLocalidad.SelectedIndexChanged -= new System.EventHandler(cboLocalidad_SelectedIndexChanged);
            this.cboChoferes.SelectedIndexChanged -= new System.EventHandler(cboChoferes_SelectedIndexChanged);
           
            ocultar_new_cmd(IsNew);
            cargarcombos();
            limpiarcontroles();
            cargarContactos();
            cargar_clientes_transportistas();

            this.cboChoferes.SelectedIndexChanged += new System.EventHandler(cboChoferes_SelectedIndexChanged);
            this.cboPais.SelectedIndexChanged += new System.EventHandler(cboPais_SelectedIndexChanged);
            //this.cboProvincia.SelectedIndexChanged += new System.EventHandler(cboProvincia_SelectedIndexChanged);
            
            
        }
        private void cargar_clientes_transportistas()
        {
            funciones_Varias o = new funciones_Varias();
            DataTable r;
            DN_ABM u = new DN_ABM();

            r = u.DN_Traer_DataTable("SP_Transportistas_Get_All", 0, datos.g_idEmpresa);


            o.CargarComboDataTable(this.cboRazonSocial, r, "id", "descripcion", false,false);

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
                    }else if(c.GetType().Name.ToString()=="MaskedTextBox")
                    {
                        c.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    }else 
                    {
                        c.Text = "S/N";//String.Empty;
                    }
                    
                }
            }
            this.opBlackList.Text = "Black List";
            this.opBlackList.Checked = false;
            this.opBlackList.Enabled = true;
        }

        private void cargarContactos()
        {
            funciones_Varias o = new funciones_Varias();
            DataTable r;

            DN_ABM_Choferes u = new DN_ABM_Choferes();

            u.PAll = 0;
            u.Id1 = 0;

            r = u.Chofer_GET();
            o.CargarComboDataTable(this.cboChoferes, r, "idChofer", "Apellido", false, true);

        }
        private void cargarcombos()
        {

            DNTablas_Gral lista = new DNTablas_Gral();

            DataTable p;
            funciones_Varias o= new funciones_Varias();

            //p = lista.Get_Condicion_Pago();
            //o.CargarComboDataTable(cboCondicionPago, p, "id", "descripcion", false);

            p = lista.DN_CargarDataTableGral("SP_Get_Paises", 0, 0);
            o.CargarComboDataTable(cboPais, p, "id", "descripcion", false, true);

            p = lista.DN_CargarDataTableGral("SP_Get_Estados",0,0);
            o.CargarComboDataTable(cboEstado, p, "id", "descripcion", false, true);

            p = lista.DN_CargarDataTableGral("SP_GET_Tipo_de_Doc",0,0);
            o.CargarComboDataTable(cboTipoDoc, p, "id", "descripcion", false, true);
        
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
            try
            {


            int p_idProv;
            bool ok = Int32.TryParse(cboProvincia.SelectedValue.ToString(), out p_idProv);

            DNTablas_Gral lista = new DNTablas_Gral();
            cboLocalidad.DataSource = lista.Get_Localidades(p_idProv);
            cboLocalidad.DisplayMember = "descripcion";
            cboLocalidad.ValueMember = "id";
            }
            catch (Exception)
            {

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
            this.cboChoferes.Visible= !x;
        }
        private void cboChoferes_SelectedIndexChanged(object sender,System.EventArgs e)
        {
            DN_ABM_Choferes  d = new DN_ABM_Choferes();
            d.PAll = 1;
            d.Id1 = Convert.ToInt32(cboChoferes.SelectedValue);
            d.Chofer_GET_id();

            funciones_Varias fv = new funciones_Varias();
            

            //
            this.cboPais.SelectedValue = d.Pais1;
            this.cboProvincia.SelectedValue = d.Provincia1 ;
            this.cboLocalidad.SelectedValue = d.Localidad1 ; 
            this.txtDireccion.Text = d.Direccion1;
            this.txtPostal.Text = d.CodPost1 ;

            this.cboTipoDoc.SelectedValue=d.TipoDoc1;
            this.txtNroDoc.Text  = d.NroDoc1;
            Bloqueo_Black_List(this.txtNroDoc.Text);
            

            this.txtNroLicencia.Text=d.NroLicencia1;
            this.txtMunicipio.Text = d.Municipio1;

            this.mskFecVenLic.Text=d.FecVenLic1;
            this.txtSeguro.Text=d.Seguro1;
            this.txtNroPoliza.Text=d.NroPoliza1;
            this.txtLibrSanitaria.Text=d.LibretaSanitaria1 ;
            this.mskFecVenSeg.Text = d.FecVenSeguro1;

            this.txtTel1 .Text = d.Telefono1 ;
            this.txtRadio.Text = d.Radio1 ;
            this.txtCelular.Text  = d.Celular1  ;
            this.txtEmail .Text = d.Email1;
            this.cboEstado.SelectedValue  = d.Activo1  ;
            this.cboRazonSocial.SelectedValue = d.idTransportista;
           

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

            //validar existe DNI
            if (validar_DNI(this.txtNroDoc.Text ,IsNew) == false)
            {
                return;
            }


            DN_ABM_Choferes  objClientes = new DN_ABM_Choferes ();
            //objeto para hacer algo con la DB supongo
            //*******//
            //ID
           

            if (IsNew == true)
            {
                objClientes.PAll = 0;
                objClientes.Id1 = 0;
                objClientes.Apellido1  = this.txtNewContacto.Text;
            }
            else
            {
                objClientes.PAll = 1;
                objClientes.Id1 = Convert.ToInt32(this.cboChoferes.SelectedValue);
                objClientes.Apellido1  = this.cboChoferes.Text.ToString();
            }
            objClientes.Pais1= Convert.ToInt32(this.cboPais.SelectedValue);
            objClientes.Provincia1  = Convert.ToInt32(this.cboProvincia.SelectedValue);
            objClientes.Localidad1  = this.cboLocalidad.SelectedValue.ToString();
            objClientes.Direccion1 = this.txtDireccion.Text;
            objClientes.CodPost1  = this.txtPostal.Text;
            objClientes.TipoDoc1 = Convert.ToInt32(this.cboTipoDoc.SelectedValue);
            objClientes.NroDoc1 = formatear_Solo_Numero(this.txtNroDoc.Text);
            objClientes.NroLicencia1 = formatear_Solo_Numero(this.txtNroLicencia.Text);
            objClientes.Va = true;//mascara de las fechas
            objClientes.FecVenLic1 = this.mskFecVenLic.Text;
            objClientes.Seguro1 = this.txtSeguro.Text;
            objClientes.NroPoliza1 = this.txtNroPoliza.Text;
            objClientes.LibretaSanitaria1 = this.txtLibrSanitaria.Text;
            objClientes.FecVenSeguro1 = this.mskFecVenSeg.Text;
            objClientes.Telefono1  = this.txtTel1.Text;
            objClientes.Radio1  = this.txtRadio.Text;
            objClientes.Celular1  = this.txtCelular.Text;
            objClientes.Email1  = this.txtEmail.Text;
            objClientes.Activo1  = Convert.ToInt32(this.cboEstado.SelectedValue);
            objClientes.idEmpresa = datos.g_idEmpresa;
            objClientes.idTransportista = Convert.ToInt32(this.cboRazonSocial.SelectedValue);
            objClientes.idUsuario = datos.g_idUser;


            bool ok_Transaccion;
            ok_Transaccion = objClientes.Chofer_ACTUALIZAR();

            if (ok_Transaccion == true)
            {
                if (this.opBlackList.Checked == true)
                {
                    funciones_Varias fv = new funciones_Varias();
                    IsBlackList = fv.Valido_Black_List(objClientes.NroDoc1, 1);

                    //Bloquea_Asignar("LA PATENTE/DNI/CUIT  " + objCamiones.Patente);
                }
                IsNew = false;
                inicio();
            }



        }
        private string formatear_Solo_Numero(string strVar)
        {
            string strNewCadena = string.Empty;

            char[] chrDNI = (from t in strVar where char.IsDigit(t) select t).ToArray();
            foreach (char c in chrDNI)
            {
                strNewCadena = string.Concat(strNewCadena, c.ToString());
                //Console.WriteLine(c);
            }
            return strNewCadena;
        }
        private bool validar_DNI(string strDNI, bool bEsNuevo)
        {
            DataTable dtOT;
            DNTablas_Gral lista = new DNTablas_Gral();
            MySqlParameter[] Parametros = new MySqlParameter[1];

            
            

            //MessageBox.Show(strNewDNI);
            this.txtNroDoc.Text = formatear_Solo_Numero(strDNI);
            //Empresa
            Parametros[0] = new MySqlParameter("strDNI", strDNI);
            
            dtOT = lista.Get_Datos("SP_ValidarDNI", Parametros);
            if (dtOT.Rows.Count==0)
            {
                return true;
            }
            else
            {
                if (bEsNuevo==true)
                {
                    MessageBox.Show("DNI Existente");
                    return false;
                }
                
            }
            return true;
            
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
                    if ((c.Text == string.Empty || c.Text == "No Puede estar Vacío") && c.Name != "cboChoferes")
                    {

                        c.Text = "No Puede estar Vacío";
                        c.BackColor = Color.Red;
                        return false;
                    }
                }
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
                if (this.cboChoferes.SelectedIndex == -1)
                {
                    MessageBox.Show("El combo no puede estar vacío", "Atención");
                    this.cboChoferes.Focus();
                    return false;
                }
            }
            if (this.txtNroDoc.Text=="S/N")
            {
                MessageBox.Show("El Número de DNI debe ser Válido", "Atención");
                this.txtNroDoc.Focus();
                return false;
            }
            if (this.txtNroLicencia.Text == "S/N")
            {
                MessageBox.Show("El Número de Licencia debe ser Válido", "Atención");
                this.txtNroLicencia.Focus();
                return false;
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

        private void frm_abm_choferes_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Bloqueo_Black_List(string strParam)
        {
            funciones_Varias fv = new funciones_Varias();
            strParam = formatear_Solo_Numero(strParam);
            IsBlackList = fv.Valido_Black_List(strParam, 0);
            if (IsBlackList)
            {
                this.opBlackList.Checked = true;
                this.opBlackList.Enabled = false;
                this.cmdSave.Enabled = false;
            }
            else
            {
                this.opBlackList.Checked = false;
                this.opBlackList.Enabled = true;
                this.cmdSave.Enabled = true;
            }
        }

        private void txtNroDoc_Leave(object sender, EventArgs e)
        {
            Bloqueo_Black_List(this.txtNroDoc.Text);
        }
    }
   
}
