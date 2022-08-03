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
    public partial class frm_abm_contactos : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wpara, int lparam);
        private bool IsNew;

        guardar_datos_login datos = guardar_datos_login.Instance();

        public frm_abm_contactos()
        {
            InitializeComponent();

            this.lblUsuario.Text = datos.g_idUser + " " + datos.g_lastName;

            IsNew = false;
            //funciones_Varias fv = new funciones_Varias();
            //fv.PrepararDG (DG, 200, 45, 88, 480);
            Conf_Grid();
            inicio();
            

        }
        private void Conf_Grid()
        {
            this.DG.AutoGenerateColumns = false;



            DataGridViewTextBoxColumn colIDC = new DataGridViewTextBoxColumn();
            colIDC.Visible = false;
            colIDC.HeaderText = "C";
            colIDC.Name = "idCliente";
            colIDC.DataPropertyName = "idCliente";
            this.DG.Columns.Add(colIDC);

            DataGridViewTextBoxColumn colIDE = new DataGridViewTextBoxColumn();
            colIDE.Visible = false;
            colIDE.HeaderText = "E";
            colIDE.Name = "idEvento";
            colIDE.DataPropertyName = "idEvento";
            this.DG.Columns.Add(colIDE);

            DataGridViewTextBoxColumn colEvento = new DataGridViewTextBoxColumn();
            colEvento.Visible = true;
            colEvento.HeaderText = "Evento";
            colEvento.Name = "Evento";
            colEvento.DataPropertyName = "evento";
            colEvento.Width = 300;
            this.DG.Columns.Add(colEvento);

            DataGridViewCheckBoxColumn colEliminar = new DataGridViewCheckBoxColumn();
            colEliminar.Visible = true;
            colEliminar.HeaderText = "¿Eliminar?";
            colEliminar.Name = "Eliminar";
            colEliminar.DataPropertyName = "Eliminar";
            this.DG.Columns.Add(colEliminar);

        }
        private void inicio()
        {
            this.cboPais.SelectedIndexChanged -= new System.EventHandler(cboPais_SelectedIndexChanged);
            this.cboContactos.SelectedIndexChanged -= new System.EventHandler(cboContacto_SelectedIndexChanged);

            ocultar_new_cmd(IsNew);
            cargarcombos();
            limpiarcontroles();
            if (IsNew == false)
            {
                cargarContactos();
            }
            cargardataGrid();
            cargarclientes();

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
                    }
                    else
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
            r = u.DN_Traer_DataTable("SP_Contactos_Get_All", 1, datos.g_idEmpresa);
            o.CargarComboDataTable(this.cboContactos, r, "id", "descripcion", false, true);

        }
        private void cargarclientes()
        {
            string SP = string.Empty;
            funciones_Varias o = new funciones_Varias();
            DataTable r;
            DN_ABM u = new DN_ABM();


            SP = "SP_Clientes_Get_All";

            r = u.DN_Traer_DataTable(SP, 0, datos.g_idEmpresa);
            o.CargarComboDataTable(this.cboCT, r, "id", "descripcion", false, true);

        }
        private void cargarcombos()
        {

            DNTablas_Gral lista = new DNTablas_Gral();

            DataTable p;
            funciones_Varias o = new funciones_Varias();

            //p = lista.Get_Condicion_Pago();
            //o.CargarComboDataTable(cboCondicionPago, p, "id", "descripcion", false);

            p = lista.DN_CargarDataTableGral("SP_Get_Paises", 0, 0);
            o.CargarComboDataTable(cboPais, p, "id", "descripcion", false, true);

            //p = lista.Get_Tipo_De_IVA();
            //o.CargarComboDataTable(cboCondicionIVA, p, "id", "Descripcion", false);

            p = lista.DN_CargarDataTableGral("SP_Get_Estados", 0, 0);
            o.CargarComboDataTable(cboEstado, p, "id", "descripcion", false, true);

            p = lista.DN_CargarDataTableGral("SP_Eventos_all", 0, 0);
            o.CargarComboDataTable(cboEventos, p, "id", "descripcion", false, true);

        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            int p_idPais;
            bool ok = Int32.TryParse(cboPais.SelectedValue.ToString(), out p_idPais);
            this.cboProvincia.SelectedIndexChanged -= new System.EventHandler(cboProvincia_SelectedIndexChanged);
            DNTablas_Gral lista = new DNTablas_Gral();

            cboProvincia.DataSource = lista.Get_Provincias(p_idPais);
            cboProvincia.DisplayMember = "provincia";
            cboProvincia.ValueMember = "id";
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(cboProvincia_SelectedIndexChanged);
            cboProvincia_SelectedIndexChanged(sender, e);
        }
        private void cboProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
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
            catch(Exception ex)
            {
                Console.WriteLine("Error" + ex.GetType());
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
            this.cboContactos.Visible = !x;
            if (x == true)
            {
                this.cboEventos.Enabled = false;
                this.DG.Enabled = false;
            }
            else
            {
                this.cboEventos.Enabled = true;
                this.DG.Enabled = true;
            }
        }
        private void cboContacto_SelectedIndexChanged(object sender, System.EventArgs e)
        {


            DN_ABM d = new DN_ABM();
            int ID;
            ID = Convert.ToInt32(cboContactos.SelectedValue);
            d.DN_Contactos_Get_Id(ID, datos.g_idEmpresa);
            this.cboCT.SelectedItem = Convert.ToInt32(d.IdOrigen);
            this.cboPais.SelectedValue = d.Pais;
            this.cboProvincia.SelectedValue = d.Prov;
            this.cboLocalidad.SelectedValue = d.Loc;
            this.txtDireccion.Text = d.Direccion;
            this.txtPostal.Text = d.Cp;
            this.txtTel1.Text = d.Tel1;
            this.txtTel2.Text = d.Tel2;
            this.txtFax.Text = d.Fax;
            this.txtEmail.Text = d.Email;
            this.cboEstado.SelectedValue = d.Estado;
            //if (d.EsDe == 1) { rClientes.Checked = true; }else { rTransportistas.Checked = true; }

            this.cboCT.SelectedValue = d.IdOrigen;
            cargardataGrid();

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
            //
            
            int intCliente = Convert.ToInt32(this.cboCT.SelectedValue);
            int intContacto;

            guardar_datos_login datos = guardar_datos_login.Instance();
            if (IsNew == true)
            {
                objClientes.Id = 0;
                objClientes.Nombre = this.txtNewContacto.Text;
                strStoredProcedures = "SP_Contactos_Insert";

            }
            else
            {
                intContacto = Convert.ToInt32(this.cboContactos.SelectedValue);
                objClientes.Id = intContacto;
                objClientes.Nombre = this.cboContactos.Text.ToString();
                strStoredProcedures = "SP_Contactos_Update";

                //inserto dataGrid
                DataTable dt = new DataTable();
                dt = (DataTable)this.DG.DataSource;
                


                objClientes.DN_Grabar_Asoc_Eventos_Clientes(datos.g_idEmpresa,intCliente,intContacto,dt);
            }
            objClientes.Empresa = datos.g_idEmpresa;
            objClientes.Pais = Convert.ToInt32(this.cboPais.SelectedValue);
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

            objClientes.EsDe = 1;
            objClientes.IdOrigen = intCliente;//numero de cliente

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
           // bool ok = true;
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
            //else//No es vacio valido el combo
            //{
            //    //MessageBox.Show(this.cboRazonSocial.SelectedValue.ToString());

            //    return true;
            //}

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
            funciones_Varias vc = new funciones_Varias();
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
                if (((TextBox)sender).Text == "No Puede estar Vacío") { ((TextBox)sender).Text = ""; }
               ((TextBox)sender).BackColor = Color.White;
            }
            else if (sender.GetType().Name == "ComboBox")
            {
                if (((ComboBox)sender).Text == "No Puede estar Vacío") { ((ComboBox)sender).Text = ""; }
                ((ComboBox)sender).BackColor = Color.White;
            }
        }

        private void frm_abm_contactos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void cargardataGrid()
        {
            DN_ABM o = new DN_ABM();
            DataTable d = new DataTable();


            int intContacto;
            if (this.cboContactos.SelectedIndex == -1)
            {
                intContacto = 0;
            }
            else
            {
                intContacto = (Int32)this.cboContactos.SelectedValue;
            }
            d = o.DN_Traer_DataTable("SP_Cliente_Evento_Traer", "intEmpresa","intContacto",datos.g_idEmpresa, intContacto);
            //this.DG.Columns.Clear();



            this.DG.DataSource = d;
           

        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)this.DG.DataSource;
            DataRow[] Busco_Dato;
            Busco_Dato = dt.Select("idEvento=" + (Int32)this.cboEventos.SelectedValue);
            if (Busco_Dato.Count() > 0)
            {
                MessageBox.Show("No se puede agregar, existe el evento en la Grilla", "Aviso", MessageBoxButtons.OK);
                return;
            }

            DataRow dr = dt.NewRow();

            dr["idCliente"] = (Int32)this.cboContactos.SelectedValue;
            dr["idEvento"] = (Int32)this.cboEventos.SelectedValue;
            dr["evento"] = this.cboEventos.Text.ToString();
            dr["Eliminar"] = 0;
            dt.Rows.Add(dr);
            //this.DG.Rows.Clear();
            this.DG.DataSource = dt;

        
        }

        private void cboContactos_Leave(object sender, EventArgs e)
        {
            string nombreNuevo;
            if (this.cboContactos.SelectedIndex == -1)
            {
                if(MessageBox.Show("No existe el nombre del contacto.¿Desea darlo de Alta?", "Atención", MessageBoxButtons.YesNo )==DialogResult.Yes)
                {
                    nombreNuevo = this.cboContactos.Text;
                    IsNew = true;
                    inicio();
                    this.txtNewContacto.Text = nombreNuevo;
                }
                
            }
        }
    }
}
