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
    public partial class frm_abm_tractores : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wpara, int lparam);
        private bool IsNew;
        guardar_datos_login datos = guardar_datos_login.Instance();
        bool IsBlackList;
        public frm_abm_tractores()
        {
            InitializeComponent();
            
            this.lblUsuario.Text = datos.g_idUser + " " + datos.g_lastName;
            IsNew = false;
      
            inicio();
        }

        private void frm_abm_tractores_Load(object sender, EventArgs e)
        {
              
            
           
        }
        private void inicio()
        {
            this.cboMarca.SelectedIndexChanged -= new System.EventHandler(cboMarca_SelectedIndexChanged);
            //this.cboProvincia.SelectedIndexChanged -= new System.EventHandler(cboProvincia_SelectedIndexChanged);
            this.cboRazonSocial.SelectedIndexChanged -= new System.EventHandler(cboRazonSocial_SelectedIndexChanged);
            this.cboPatente.SelectedIndexChanged -= new System.EventHandler(cboPatente_SelectedIndexChanged);
           
            ocultar_new_cmd(IsNew);
            cargarcombos();
            limpiarcontroles();
            cargarPatentes();
            cargar_clientes_transportistas();

            this.cboPatente.SelectedIndexChanged += new System.EventHandler(cboPatente_SelectedIndexChanged);
           
            this.cboRazonSocial.SelectedIndexChanged += new System.EventHandler(cboRazonSocial_SelectedIndexChanged);
            this.txtNewPatente.Focus();
            
        }
        private void cargar_clientes_transportistas()
        {
            funciones_Varias o = new funciones_Varias();
            DataTable r;
            DN_ABM u = new DN_ABM();

            r = u.DN_Traer_DataTable("SP_Transportistas_Get_All", 0, datos.g_idEmpresa);

            o.CargarComboDataTable(this.cboRazonSocial, r, "id", "descripcion", false, true);

        }
        private void limpiarcontroles()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType().Name.ToString() != "Button" && 
                    c.GetType().Name.ToString() != "Label" && 
                    c.GetType().Name.ToString() != "CheckBox" &&
                    c.GetType().Name.ToString() != "ComboBox")
                {

                    switch (c.Name)
                    {
                        case "txtNewPatente":
                            c.Text = string.Empty;
                            break;
                        case "txtTara":
                        case "txtAnio":
                        case "txtCantEjes":
                            c.Text = "0";
                            break;
                        case "cboEmpresaSeguros":
                            
                            break;

                        default:
                            c.Text = "S/N";
                            break;

                    }

                }
                else if(c.GetType().Name.ToString() == "ComboBox")
                {
                    c.Text = string.Empty;
                    
                }

            }
            this.cboMarca.SelectedIndexChanged += new System.EventHandler(cboMarca_SelectedIndexChanged);
            this.cboEmpresaSeguros.SelectedIndex = 0;
            this.cboMarca.SelectedIndex = 0;
            this.cboModelo.SelectedIndex = 0;
            this.cboColor.SelectedValue = 1;
            this.mskFecVenSeg.Text = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy");
            this.mskFecVenVTV.Text= DateTime.Now.AddDays(30).ToString("dd/MM/yyyy");
            this.cboEstado.SelectedValue = 1;
            this.cboRazonSocial.SelectedIndex = -1;
            this.opBlackList.Checked = false;
            this.opBlackList.Enabled = true;
        }

        private void cargarPatentes()
        {
            funciones_Varias o = new funciones_Varias();
            DataTable r;
            DN_ABM_TC u = new DN_ABM_TC();

            u.pAll = 0;
            u.Id = 0;
            r = u.Tractor_GET();
            o.CargarComboDataTable(this.cboPatente, r, "id", "descripcion", false, true);

        }
        private void cargarcombos()
        {

            DNTablas_Gral  lista = new DNTablas_Gral();

            DataTable p;
            funciones_Varias o= new funciones_Varias();

            p = lista.Get_Estados();
            o.CargarComboDataTable(cboEstado, p, "id", "descripcion", false, true);

            p = lista.Get_EmpresasSeguros();
            o.CargarComboDataTable(cboEmpresaSeguros , p, "id", "descripcion", false, true);

            DN_ABM_TC l = new DN_ABM_TC();

           p = l.Listar_Marcas ();
           o.CargarComboDataTable(cboMarca, p, "id", "descripcion", false, true);

            p = l.Listar_Colores();
            o.CargarComboDataTable(cboColor, p, "id", "descripcion", false, true);

        }

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable p;
                funciones_Varias o = new funciones_Varias();
                int p_idMarca;
                bool ok = Int32.TryParse(cboMarca.SelectedValue.ToString(), out p_idMarca);

                DN_ABM_TC lista = new DN_ABM_TC();

                lista.Id = p_idMarca;
                p = lista.Listar_Modelos();
                o.CargarComboDataTable(cboModelo, p, "id", "descripcion", false, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

           
        private void cmbNew_Click(object sender, EventArgs e)
        {
            IsNew = true;
            inicio();

        }
        private void ocultar_new_cmd(bool x)
        {
            this.txtNewPatente.Visible = x;
            this.cboPatente.Visible= !x;
        }
        private void cboPatente_SelectedIndexChanged(object sender,System.EventArgs e)
        {
            DN_ABM_TC d = new DN_ABM_TC();

            d.Id = Convert.ToInt32(cboPatente.SelectedValue);

            funciones_Varias fv = new funciones_Varias();
            IsBlackList = fv.Valido_Black_List(this.cboPatente.Text, 0);

            if (d.Id != 0)
            {
                d.pAll = 1;

                d.Tractor_GET_id ();

                this.cboMarca.SelectedValue = d.Marca;
                this.cboModelo.SelectedValue = d.Modelo;

       

                this.txtAnio.Text = Convert.ToString(d.Anio);
                this.txtNroMotor.Text = d.NroMotor;
                this.txtNroChasis.Text = d.NroChasis;
                this.txtTara.Text = Convert.ToString(d.Tara);
                this.cboEmpresaSeguros.SelectedValue = d.Seguro;
                this.txtNroPoliza.Text = d.NroPoliza;
                this.mskFecVenSeg.Text = d.FecVenSeguro;
                this.mskFecVenVTV.Text = d.FecVecVTV;
                this.txtCantEjes.Text = Convert.ToString(d.CantEjes);

                this.txtGPS_Cliente.Text = d.GPS_Clientes;
                this.txtGPS_Link.Text = d.GPS_Link;
                this.txtGPS_Us.Text = d.GPS_Us;
                this.txtGPS_Ps.Text = d.GPS_PS;

                this.txtObservaciones.Text = d.Observaciones;

                this.cboEstado.SelectedValue = d.Activo;
                this.cboColor.SelectedValue = d.Colores;
                this.cboRazonSocial.SelectedValue = Convert.ToInt32(d.idTransportista);

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

                IsNew = false;
            }else
            {
                MessageBox.Show("Debe Seleccionar un Dato válido");
            }
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
            DN_ABM_TC objCamiones = new DN_ABM_TC();
            //objeto para hacer algo con la DB supongo
            //*******//
            //ID
            if (IsNew == true)
            {
                objCamiones.pAll = 0;
                objCamiones.Id = 0;
                objCamiones.Patente = this.txtNewPatente.Text;
            }
            else
            {
                objCamiones.pAll = 1;
                objCamiones.Id = Convert.ToInt32(this.cboPatente.SelectedValue);
                objCamiones.Patente = this.cboPatente.Text.ToString();
            }

            objCamiones.Marca = Convert.ToInt32(this.cboMarca.SelectedValue);
            objCamiones.Modelo = Convert.ToInt32(this.cboModelo.SelectedValue);
            objCamiones.Anio = Convert.ToInt32(this.txtAnio.Text);
            objCamiones.NroMotor = this.txtNroMotor.Text;
            objCamiones.NroChasis = this.txtNroChasis.Text;
            objCamiones.Tara = Convert.ToInt32(this.txtTara.Text);
            objCamiones.Seguro = Convert.ToInt32(this.cboEmpresaSeguros.SelectedValue);
            objCamiones.NroPoliza = this.txtNroPoliza.Text;
            objCamiones.Va = true;
            objCamiones.FecVenSeguro = this.mskFecVenSeg.Text;
            objCamiones.FecVecVTV = this.mskFecVenVTV.Text;
            objCamiones.CantEjes = Convert.ToInt32(this.txtCantEjes.Text);

            objCamiones.GPS_Clientes = this.txtGPS_Cliente.Text;
            objCamiones.GPS_Link = this.txtGPS_Link.Text;
            objCamiones.GPS_Us = this.txtGPS_Us.Text;
            objCamiones.GPS_PS = this.txtGPS_Ps.Text;

            objCamiones.Observaciones = this.txtObservaciones.Text;
            objCamiones.Activo = Convert.ToInt32(this.cboEstado.SelectedValue);
            objCamiones.idEmpresa = datos.g_idEmpresa;
            objCamiones.idTransportista = Convert.ToInt32(this.cboRazonSocial.SelectedValue);
            objCamiones.idUsuario = datos.g_idUser;
            objCamiones.Colores = Convert.ToInt32(this.cboColor.SelectedValue);

            bool ok_Transaccion;
            ok_Transaccion = objCamiones.Tractor_ACTUALIZAR ();
            

            if (ok_Transaccion == true)
            {
                if (this.opBlackList.Checked == true)
                {
                    funciones_Varias fv = new funciones_Varias();
                    IsBlackList = fv.Valido_Black_List(objCamiones.Patente, 1);

                    //Bloquea_Asignar("LA PATENTE/DNI/CUIT  " + objCamiones.Patente);
                }

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
                if (this.txtNewPatente.Text == string.Empty || this.txtNewPatente.Text == "No Puede estar Vacío")
                {
                    this.txtNewPatente.Text = "No Puede estar Vacío";
                    this.txtNewPatente.BackColor = Color.Red;
                    return false;
                }
            }
            else//No es vacio valido el combo
            {
                return true;
            }

            foreach (Control c in this.Controls)
            {
                if (c.GetType().Name.ToString() == "TextBox" || c.GetType().Name.ToString() == "ComboBox")
                {
                    if((c.Text == string.Empty || c.Text == "No Puede estar Vacío") && c.Name !="cboPatente")
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
            if (this.cboMarca.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboMarca.Focus();
                return false;
            }
            if (this.cboModelo.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboModelo.Focus();
                return false;
            }
            if (this.cboEmpresaSeguros.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboEmpresaSeguros.Focus();
                return false;
            }
            if (IsNew == false)
            {
                if (this.cboPatente.SelectedIndex == -1)
                {
                    MessageBox.Show("El combo no puede estar vacío", "Atención");
                    this.cboPatente.Focus();
                    return false;
                }
            }
            if (this.cboRazonSocial.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboRazonSocial.Focus();
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

        private void frm_abm_tractores_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtNroChasis_Leave(object sender, EventArgs e)
        {
            txtNroChasis.Text = txtNroChasis.Text.ToUpper();
        }

        private void e_Cambiar_mayus_S_Espacios(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Text = ((TextBox)sender).Text.Replace(" ", "");

            string strName = ((TextBox)sender).Name;
            if (strName=="txtNewPatente")
            {
                funciones_Varias fv = new funciones_Varias();
                IsBlackList = fv.Valido_Black_List(this.txtNewPatente.Text, 0);

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
        }

        private void cboMarca_Leave(object sender, EventArgs e)
        {
            if (this.cboMarca.SelectedIndex == -1)
            {
                if (MessageBox.Show("Elemento Inexistente. ¿Desea Agregarlo?","Atención",MessageBoxButtons.YesNo )==DialogResult.Yes)
                {
                    DataTable p;
                    funciones_Varias o = new funciones_Varias();
                    DN_ABM_TC objCamiones = new DN_ABM_TC();

                    this.cboMarca.SelectedIndexChanged -= new System.EventHandler(cboMarca_SelectedIndexChanged);
                    objCamiones.NameAux = this.cboMarca.Text.ToUpper();
                    objCamiones.DN_insertar_Marca("SP_Insert_marcas");
                    p = objCamiones.Listar_Marcas();
                    o.CargarComboDataTable(cboMarca, p, "id", "descripcion", false, true);
                    this.cboMarca.SelectedIndexChanged += new System.EventHandler(cboMarca_SelectedIndexChanged);

                }
            }

        }

        private void cboModelo_Leave(object sender, EventArgs e)
        {
            if (this.cboModelo.SelectedIndex == -1)
            {
                if (MessageBox.Show("Elemento Inexistente. ¿Desea Agregarlo?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataTable p;
                    funciones_Varias o = new funciones_Varias();
                    DN_ABM_TC objCamiones = new DN_ABM_TC();

                    objCamiones.Id = Convert.ToInt32(this.cboMarca.SelectedValue);
                    objCamiones.NameAux = this.cboModelo.Text.ToUpper();
                    objCamiones.DN_insertar_Marca_Modelo("SP_Insert_Marca_Modelo");
  
                    p = objCamiones.Listar_Modelos();
                    o.CargarComboDataTable(cboModelo, p, "id", "descripcion", false, true);


                }
            }
        }

        //private void cboPatente_Leave(object sender, EventArgs e)
        //{
        //    if (this.cboPatente.SelectedIndex == -1)
        //    {
        //        MessageBox.Show("Elemento Inexistente. Debe hacer clic en el Botón Nuevo", "Atención");
        //        this.cmdSave.Focus();
        //    }
        //}

        private void cboRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Bloquear_Black_List()
        {
            funciones_Varias fv = new funciones_Varias();
            IsBlackList = fv.Valido_Black_List(this.txtNewPatente.Text, 0);

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
    }
   
}
