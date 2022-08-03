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
    public partial class frm_abm_elementos : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wpara, int lparam);

        private bool IsNew;

        private int opcion_seleccion;
        guardar_datos_login datos = guardar_datos_login.Instance();

        public frm_abm_elementos()
        {
            InitializeComponent();
            
            this.lblUsuario.Text = datos.g_idUser + " " + datos.g_lastName;

        }

        private void frm_ABM_Elementos_Load(object sender, EventArgs e)
        {
            inicio();
            
        }
        private void ocultar_new_cmd(bool x)
        {
            this.txtElementos.Visible = x;
            this.cboElementos.Visible = !x;
        }
        private void inicio()
        {
            this.cboPais.SelectedIndexChanged -= new System.EventHandler(cboPais_SelectedIndexChanged);

            ocultar_new_cmd(IsNew);

            //cargo_Valor_radio_Button();

            this.txtDireccion.Text = string.Empty;
            cargarcombos();
            this.cboPais.SelectedIndexChanged += new System.EventHandler(cboPais_SelectedIndexChanged);
            

        }
        private void cargo_Valor_radio_Button()
        {
            foreach (Control ctrl in this.gb.Controls)
            {
                if (ctrl is RadioButton)
                {
                    if (((RadioButton)ctrl).Checked == true)
                    {
                        switch (((RadioButton)ctrl).Name)
                        {
                            case "opOrigen":
                                opcion_seleccion = 1;
                                break;
                            case "opDestino":
                                opcion_seleccion = 2;
                                break;
                            case "opRetorno":
                                opcion_seleccion = 3;
                                break;
                        }
                        //this.cboElementos.SelectedIndexChanged -= new System.EventHandler(cboElemento_SelectedIndexChanged);
                        //cargarElementos(0, opcion_seleccion, string.Empty, datos.g_idEmpresa);
                        //this.cboElementos.SelectedIndexChanged += new System.EventHandler(cboElemento_SelectedIndexChanged);
                    }
                }
            }
        }
        private void cboElemento_Selecciono(object sender, System.EventArgs e)
        {
            DN_Corredores  d = new DN_Corredores ();
            try
            {
                d.pAll = 1;
                d.Id = opcion_seleccion;
                d.pNombre = this.cboElementos.Text.ToString();
                d.IdEmpresa = datos.g_idEmpresa;

                d.Elementos_GET();
                //

                this.cboProvincia.SelectedIndexChanged -= new System.EventHandler(cboProvincia_SelectedIndexChanged);
                //this.cboLocalidad.SelectedIndexChanged -= new System.EventHandler(cboLocalidad_SelectedIndexChanged);

                this.cboPais.SelectedValue = d.Pais;

                this.cboProvincia.SelectedIndexChanged += new System.EventHandler(cboProvincia_SelectedIndexChanged);

                this.cboProvincia.SelectedValue = d.Provincia;

                this.cboLocalidad.SelectedIndexChanged += new System.EventHandler(cboLocalidad_SelectedIndexChanged);

                d.Localidad = this.cboLocalidad.SelectedValue.ToString();
                this.txtDireccion.Text = d.Direccion;

                IsNew = false;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
           
        }

        private void opicion_CheckedChanged(object sender, EventArgs e)
        {
            DN_Corredores o = new DN_Corredores();
            
            switch (((RadioButton)sender).Name)
            {
                case "opOrigen":
                    if (((RadioButton)sender).Checked==true)
                    {
                        opcion_seleccion = 1;
                        cargarElementos(0, opcion_seleccion, string.Empty, datos.g_idEmpresa);
                    }
                        
                    break;
                case "opDestino":
                    if (((RadioButton)sender).Checked == true)
                    {
                        opcion_seleccion = 2;
                        cargarElementos(0, opcion_seleccion, string.Empty, datos.g_idEmpresa);
                    }
                    break;
                case "opRetorno":
                    if (((RadioButton)sender).Checked == true)
                    {
                        opcion_seleccion = 3;
                        cargarElementos(0, opcion_seleccion, string.Empty, datos.g_idEmpresa);
                    }
                    break;
            }
        



        }
        private void  cargarElementos(int _pAll,int _id, string _pNombre,int IdEmpresa)
        {
            funciones_Varias o = new funciones_Varias();
            DataTable r;

            DN_Corredores u = new DN_Corredores();
            

            u.pAll = _pAll ;
            u.Id = _id;
            u.pNombre = _pNombre;
            u.IdEmpresa = IdEmpresa;

            r = u.Elementos_GET();

            this.cboElementos.SelectedIndexChanged -= new System.EventHandler(cboElemento_Selecciono);

            o.CargarComboDataTable(this.cboElementos, r, "id", "descripcion", true, true);

            this.cboElementos.SelectedIndexChanged += new System.EventHandler(cboElemento_Selecciono);
        }
        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            int p_idPais;
            bool ok = Int32.TryParse(cboPais.SelectedValue.ToString(), out p_idPais);

            DNTablas_Gral lista = new DNTablas_Gral();

            this.cboProvincia.SelectedIndexChanged -= new System.EventHandler(cboProvincia_SelectedIndexChanged);

            cboProvincia.DataSource = lista.Get_Provincias(p_idPais);
            cboProvincia.DisplayMember = "provincia";
            cboProvincia.ValueMember = "id";
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(cboProvincia_SelectedIndexChanged);
            //cboProvincia_SelectedIndexChanged(sender, e);


        }
        private void cboProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int p_idProv;
            bool ok = Int32.TryParse(cboProvincia.SelectedValue.ToString(), out p_idProv);

            DNTablas_Gral lista = new DNTablas_Gral();
            cboLocalidad.DataSource = lista.Get_Localidades(p_idProv);
            cboLocalidad.DisplayMember = "descripcion";
            cboLocalidad.ValueMember = "id";
        }
        private void cboLocalidad_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void frm_ABM_Elementos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            IsNew = true;
            inicio();
            cargo_Valor_radio_Button();
        }
        private void cargarcombos()
        {

            DNTablas_Gral lista = new DNTablas_Gral();

            DataTable p;
            funciones_Varias o = new funciones_Varias();
            
            p = lista.DN_CargarDataTableGral("SP_Get_Paises", 0, 0);
            o.CargarComboDataTable(cboPais, p, "id", "descripcion", false, true);
        }
        private bool validar_controles()
        {
            //bool ok = true;
            //TextBox razon Social
            if (IsNew == true)
            {
                if (this.txtElementos.Text == string.Empty || this.txtElementos.Text == "No Puede estar Vacío")
                {
                    this.txtElementos.Text = "No Puede estar Vacío";
                    this.txtElementos.BackColor = Color.Red;
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
                    if ((c.Text == string.Empty || c.Text == "No Puede estar Vacío") && c.Name != "cboElementos")
                    {

                        c.Text = "No Puede estar Vacío";
                        c.BackColor = Color.Red;
                        return false;
                    }
                }
            }
            //Valido Combos


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

            return true;
        }
        private void cmdGuadar_Click(object sender, EventArgs e)
        {
            if (validar_controles() == false)
            {
                return;
            }
            DN_Corredores o = new DN_Corredores();
            if (IsNew == true)
            {
                o.pAll = 0;

                o.pNombre = this.txtElementos.Text;
            } else
            {
                o.pAll = 1;
                o.pNombre = this.cboElementos.Text;
            }
            o.Id = opcion_seleccion;
            o.Pais = Convert.ToInt32(this.cboPais.SelectedValue);
            o.Provincia  = Convert.ToInt32(this.cboProvincia.SelectedValue);
            o.Localidad = this.cboLocalidad.SelectedValue.ToString();
            o.Direccion  =this.txtDireccion.Text ;
            o.IdEmpresa = datos.g_idEmpresa;
            o.IdUsuario = datos.g_idUser;

            bool ok_trans;
            ok_trans = o.grabar_Elementos(IsNew);
            this.Close();
        }

        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
