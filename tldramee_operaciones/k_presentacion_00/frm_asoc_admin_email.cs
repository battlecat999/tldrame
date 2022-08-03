using k_negocio_00;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k_presentacion_00
{

    public partial class frm_asoc_admin_email : Form
    {
        int intEmpresa;
        funciones_Varias fv = new funciones_Varias();
        DNTablas_Gral dNTablas = new DNTablas_Gral();
        DataTable dt = new DataTable();

        public frm_asoc_admin_email()
        {
            InitializeComponent();

            fv.ColorearGradientPanel(this, this.Panel);
            Inicia();
        }

        private void frm_asoc_admin_email_Load(object sender, EventArgs e)
        {

        }
        private void Inicia()
        {

            this.cboEmpresa.SelectedIndexChanged -= new System.EventHandler (cboEmpresa_SelectedIndexChanged); 
            this.cboEventos.SelectedIndexChanged -= new System.EventHandler(cboEventos_SelectedIndexChanged);

            Cursor.Current = Cursors.WaitCursor;

            dt = dNTablas.DN_CargarDataTableGral("SP_Cargar_Datos_Empresa");
            fv.CargarComboDataTable(this.cboEmpresa, dt, "empresa_ID", "empresa_nombre", false, true);


            dt = dNTablas.DN_CargarDataTableGral("SP_Eventos_all");
            fv.CargarComboDataTable(cboEventos, dt, "id", "descripcion", false, true);

            this.cboEventos.SelectedIndexChanged += new System.EventHandler(cboEventos_SelectedIndexChanged);
            this.cboEmpresa.SelectedIndexChanged += new System.EventHandler(cboEmpresa_SelectedIndexChanged);
            

            Cursor.Current = Cursors.Default;

        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            intEmpresa = Convert.ToInt32(this.cboEmpresa.SelectedValue);
            var parameters = new[]
           {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = intEmpresa }
            };

            this.cboUsuarios.SelectedIndexChanged -= new System.EventHandler(cboUsuarios_SelectedIndexChanged);

            dt = dNTablas.Get_Datos("SP_Cargar_Usuarios", parameters);
            fv.CargarComboDataTable(cboUsuarios, dt, "idUser", "userName", false, true);

            this.cboUsuarios.SelectedIndexChanged += new System.EventHandler(cboUsuarios_SelectedIndexChanged);
        }

        private void cboEventos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int intEvento;
            int intUsuario;
            intEvento = Convert.ToInt32(this.cboEventos.SelectedValue);
            intUsuario = Convert.ToInt32(this.cboUsuarios.SelectedValue);


            var parameters = new[]
          {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = intEmpresa },
                new MySqlParameter(){ ParameterName="intEvento", Value = intEvento },
                new MySqlParameter(){ ParameterName="intUsuario", Value = intUsuario }
            };
            dt = dNTablas.Get_Datos("SP_Email_Admin_Evento", parameters);
            if (dt.Rows.Count > 0)
            {
                this.txtEmails.Text = dt.Rows[0][0].ToString();
            }
        }

        private void cmdGrabar_Click(object sender, EventArgs e)
        {

        }
    }
}
