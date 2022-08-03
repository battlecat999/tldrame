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
    public partial class frm_abm_eventos : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wpara, int lparam);

        private bool IsNew;


        guardar_datos_login datos = guardar_datos_login.Instance();

        public frm_abm_eventos()
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
            this.txtEventos.Visible = x;
            this.cboEventos.Visible = !x;
        }
        private void inicio()
        {
           
            this.cboEventos.SelectedIndexChanged -= new System.EventHandler(cboEventos_SelectedIndexChanged);

            ocultar_new_cmd(IsNew);
            //this.txtDetalle.Text = string.Empty;
            //this.txtDescripcion.Text = string.Empty;

            this.Controls.OfType<TextBox>().ToList().ForEach(o => o.Text = string.Empty);


            cargarcombos();
            this.cboEstado.SelectedValue = 1;

            this.cboEventos.SelectedIndexChanged += new System.EventHandler(cboEventos_SelectedIndexChanged);

        }

        private void cboEventos_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DN_Eventos  d = new DN_Eventos();

            d.PId  = (Int32)this.cboEventos.SelectedValue; 
            d.Traer_Evento_Por_ID();
            //
            this.txtDescripcion.Text = d.PDescripcion;
            this.txtDetalle.Text = d.PDetalle;
            this.cboEstado.SelectedValue = d.PActivo;
            this.cboConcepto.SelectedValue = d.PConcepto;

            IsNew = false;
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
        }
        private void cargarcombos()
        {

            DNTablas_Gral lista = new DNTablas_Gral();

            DataTable p;
            funciones_Varias o = new funciones_Varias();
            
            p = lista.DN_CargarDataTableGral("SP_Eventos_all");
            o.CargarComboDataTable(cboEventos , p, "id", "descripcion", false, true);

            p = lista.DN_CargarDataTableGral("SP_Get_Estados");
            o.CargarComboDataTable(cboEstado, p, "id", "descripcion", false, true);

            p = lista.Carga_Conceptos_Nominar(datos.g_idEmpresa);
            o.CargarComboDataTable(cboConcepto , p, "Codigo_Concepto", "Descripcion", false,false,false, true);
        }
        private bool validar_controles()
        {
            //bool ok = true;
            //TextBox razon Social
            if (IsNew == true)
            {
                if (this.txtEventos.Text == string.Empty || this.txtEventos.Text == "No Puede estar Vacío")
                {
                    this.txtEventos.Text = "No Puede estar Vacío";
                    this.txtEventos.BackColor = Color.Red;
                    return false;
                }
            }
            else//No es vacio valido el combo
            {
                //MessageBox.Show(this.cboRazonSocial.SelectedValue.ToString());

                if (this.cboEventos.SelectedIndex == -1)
                {
                    MessageBox.Show("El combo no puede estar vacío", "Atención");
                    this.cboEstado.Focus();
                    return false;
                }
            }

            //foreach (Control c in this.Controls)
            //{
            //    if (c.GetType().Name.ToString() == "TextBox" || c.GetType().Name.ToString() == "ComboBox")
            //    {
            //        if ((c.Text == string.Empty || c.Text == "No Puede estar Vacío") && c.Name != "cboEventos")
            //        {

            //            c.Text = "No Puede estar Vacío";
            //            c.BackColor = Color.Red;
            //            return false;
            //        }
            //    }
            //}
            //Valido Combos
            if (this.cboEstado.SelectedIndex == -1)
            {
                MessageBox.Show("El combo no puede estar vacío", "Atención");
                this.cboEstado.Focus();
                return false;
            }

            return true;
        }
        private void cmdGuadar_Click(object sender, EventArgs e)
        {
            string strStoredProcedures;
            if (validar_controles() == false)
            {
                return;
            }
            DN_Eventos o = new DN_Eventos();
            if (this.cboConcepto.SelectedIndex == -1)
            {
                o.PConcepto = 0;
            }
            else

            {
                o.PConcepto = Convert.ToInt32(this.cboConcepto.SelectedValue);
            }

            if (IsNew == true)
            {
                o.PId = 0;
                o.PDescripcion= this.txtEventos.Text.ToUpper();
 
                
                strStoredProcedures = "SP_Eventos_Insert";
            } else
            {
                o.PId = (Int32)this.cboEventos.SelectedValue;
                o.PDescripcion = this.cboEventos.Text.ToUpper();
                strStoredProcedures = "SP_Eventos_update";
            }

            o.PDetalle = this.txtDetalle.Text.ToUpper();
            o.PActivo = (Int32)this.cboEstado.SelectedValue;

            int ok_trans;
            ok_trans = o.Eventos_Insert_Update (strStoredProcedures);
            //this.Close();
            IsNew = false;
            inicio();
        }

        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtEventos_Leave(object sender, EventArgs e)
        {
            this.txtDescripcion.Text = this.txtEventos.Text;
        }
    }
}

