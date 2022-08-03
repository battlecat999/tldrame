using k_mysql;
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
    public partial class frm_Cargar_Estadias : Form
    {
        public int _Empresa { get; set; }
        public int _OT { get; set; }
        public int _Item { get; set; }

        public string _Contenedor{ get; set; }

        public frm_Cargar_Estadias()
        {
            InitializeComponent();
            
        }
        private void Iniciar()
        {
            this.datFechaDesde.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.cboCantidad.SelectedIndex = 0;
            this.lblEmpresa.Text = _Empresa.ToString();
            this.lblOT.Text = _OT.ToString();
            this.lblItem.Text = _Item.ToString();
            this.txtNroContenedor.Text = _Contenedor.ToString();
        } 

        private void cboCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            double dblDias;
            DateTime datInicio;
            datInicio= Convert.ToDateTime(this.datFechaDesde.Text);
            dblDias = Convert.ToInt32(this.cboCantidad.Text);

            if (dblDias != 0)
            {
                dblDias -= 1;
                this.datFechaFin.Text = datInicio.AddDays(dblDias).ToString("dd/MM/yyyy"); ;
            }

        }

        private void cmdGrabar_Click(object sender, EventArgs e)
        {
            if (Grabar() == true)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private bool Grabar()
        {
            int intEstadia;
            int intOT;
            int intItem; 
            DateTime datFechaInicio; 
            int intCantDias; 
            DateTime datFechaFin; 
            decimal decPrecioDiario; 
            string strContenedor; 
            string strObservaciones;
            int intEstado;
            string strConnection_String;


            //Declaro variables de conexion
            //Declaro la conexión
            clsConn cnMarco = new clsConn();
            //Busco la cadena de conexión
            strConnection_String = cnMarco.Cadena_Conexion();
            //Establezco la conexión con el Servidor
            MySqlConnection cnnConnection = new MySqlConnection(strConnection_String);
            //Abro la conexión
            cnnConnection.Open();
            //Creo un comando
            MySqlCommand cmdCommand = cnnConnection.CreateCommand();
            //Establezco una transaccion
            MySqlTransaction trsTransaccion;
            //Begin trans
            trsTransaccion = cnnConnection.BeginTransaction();
            cmdCommand.Connection = cnnConnection;
            cmdCommand.Transaction = trsTransaccion;
            cmdCommand.CommandType = CommandType.StoredProcedure;
            try
            {

                intEstadia = 0;//que le paso?
                intOT = Convert.ToInt32(this.lblOT.Text);
                intItem = Convert.ToInt32(this.lblItem.Text);
                datFechaInicio = DateTime.Parse(this.datFechaDesde.Text);
                intCantDias = Convert.ToInt32(this.cboCantidad.Text);
                datFechaFin = DateTime.Parse(this.datFechaFin.Text);
                decPrecioDiario = Convert.ToDecimal(this.txtPrecio.Text.Replace("$", ""));
                strContenedor = this.txtNroContenedor.Text.ToUpper();
                strObservaciones = this.txtObservaciones.Text.ToUpper();
                intEstado = 1;//1=ALta, 2=baja

                cmdCommand.CommandText = "SP_Estadia_Alta";

                cmdCommand.Parameters.Add("intEstadia", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intOT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intItem", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("datFechaInicio", MySqlDbType.DateTime);
                cmdCommand.Parameters.Add("intCantDias", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("datFechaFin", MySqlDbType.DateTime);
                cmdCommand.Parameters.Add("decPrecioDiario", MySqlDbType.Decimal);
                cmdCommand.Parameters.Add("strContenedor", MySqlDbType.VarChar);
                cmdCommand.Parameters.Add("strObservaciones", MySqlDbType.VarChar);
                cmdCommand.Parameters.Add("intEstado", MySqlDbType.Int32);

                //paso los valores
                cmdCommand.Parameters["intEstadia"].Value = intEstadia;
                cmdCommand.Parameters["intOT"].Value = intOT;
                cmdCommand.Parameters["intItem"].Value = intItem;
                cmdCommand.Parameters["datFechaInicio"].Value = datFechaInicio;
                cmdCommand.Parameters["intCantDias"].Value = intCantDias;
                cmdCommand.Parameters["datFechaFin"].Value = datFechaFin;
                cmdCommand.Parameters["decPrecioDiario"].Value = decPrecioDiario;
                cmdCommand.Parameters["strContenedor"].Value = strContenedor;
                cmdCommand.Parameters["strObservaciones"].Value = strObservaciones;
                cmdCommand.Parameters["intEstado"].Value = intEstado;

                cmdCommand.ExecuteNonQuery();//Ejecuta la consulta

                trsTransaccion.Commit();

                //Con el Ultimo ingresado vamos a invocar el email para que lo envie por email.

                DNTablas_Gral lista = new DNTablas_Gral();
                DataTable asunto_cuerpo;
                string direcciones;
                //int intEvento;
                string strAsunto;
                string strCuerpo;

                
                var parameters = new[]
                {
                    new MySqlParameter(){ ParameterName="intEmpresa", Value = _Empresa },
                    new MySqlParameter(){ ParameterName="intOT", Value = _OT },
                    new MySqlParameter(){ ParameterName="intItemOT", Value = _Item }
                };
                asunto_cuerpo = lista.Get_Datos("SP_Emails_Estadias", parameters);
                DataRow dr;
                if (asunto_cuerpo.Rows.Count > 0)
                {
                    funciones_envio_emails fee = new funciones_envio_emails();
                    dr = asunto_cuerpo.Rows[0];
                    //intEvento = Convert.ToInt32(dr[0]);
                    strAsunto = dr[0].ToString();
                    strCuerpo = dr[1].ToString();
                    //Armo las direcciones de email
                    direcciones= fee.armar_Cadena_Emails("SP_Email_Admin_Evento", _Empresa, 11, 0, "intUsuario");
                    fee.SendEmailWithOutlook(direcciones, strAsunto, strCuerpo, string.Empty, false);
                }

                cnnConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                trsTransaccion.Rollback();
                MessageBox.Show("Error Crítico " + ex.Message.ToString(),"Atención");
                cnnConnection.Close();
                return false;
            }
            
        }
        private void TextBoxFormattedOnEnter(object sender, EventArgs e)
        {
            // El control TextBox ha tomado el foco.
            //
            // Referenciamos el control TextBox que ha
            // desencadenado el evento.
            //
            TextBox tb = (TextBox)sender;

            // Mostramos en el control TextBox el valor
            // de la propiedad Tag sin formatear.
            //
            tb.Text = Convert.ToString(tb.Tag);

        }

        private void TextBoxFormattedOnLeave(object sender, EventArgs e)
        {
            // El control TextBox ha perdido el foco.
            //
            // Referenciamos el control TextBox que ha
            // desencadenado el evento.
            //
            TextBox tb = (TextBox)sender;

            // Primero verificamos si el valor se puede convertir a Decimal.
            //
            tb.Text = tb.Text.Replace(".",",");
            decimal numero = default(decimal);
            bool bln = decimal.TryParse(tb.Text, out numero);

            if ((!(bln)))
            {
                // No es un valor decimal válido; limpiamos el control.
                tb.Clear();
                return;
            }

            // En la propiedad Tag guardamos el valor con todos los decimales.
            //
            tb.Tag = numero;

            // Y acto seguido formateamos el valor
            // a monetario con dos decimales.
            //
            tb.Text = string.Format("{0:C2}", numero);

        }

        private void frm_Cargar_Estadias_Load(object sender, EventArgs e)
        {
            Iniciar();
        }
    }
}
