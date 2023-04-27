using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net.Mail;
using Outlook=Microsoft.Office.Interop.Outlook;

using System.Text.RegularExpressions;
using k_negocio_00;
using MySql.Data.MySqlClient;
using k_mysql;
using System.IO;
using System.Web.UI;
using System.Windows.Forms;
using k_presentacion_00;
using iTextSharp.tool.xml.html;


namespace k_presentacion_00
{
    public class funciones_envio_emails
    {

        public  bool email_bien_escrito(string email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Agregar_Evento_Calendario(string nombreCliente, string nombreContacto, DateTime Fecha_Reunion, string direccionReunion, string Tel_Cont, int tiempo = 1)
        {
           // try
            //{
            //* Inicializamos nuestra apliación OutLook
                Outlook.Application outlookApp =(Outlook.Application) new Outlook.Application();
            //Crea un objeto de OutLook 
                Outlook.AppointmentItem Cita;

            //Creamos una instancia de un objeto tipo AppointmentItem

            Cita = (Outlook.AppointmentItem)outlookApp.CreateItem(Outlook.OlItemType.olAppointmentItem);

            //AppointmentItem
            Cita.Subject = String.Concat("Recordatorio Llamado: ", nombreCliente, "");
            Cita.Body = String.Concat("Cliente ", nombreCliente, "-->Hablar con: ", nombreContacto, " Hora: ", Fecha_Reunion, " Tel: ", Tel_Cont);
            Cita.Start = Fecha_Reunion;
            Cita.End = Fecha_Reunion.AddHours(tiempo);
            Cita.Location = direccionReunion;
            Cita.ReminderSet = true;
            Cita.ReminderMinutesBeforeStart = 3600; // 6 hs antes
            Cita.Save();

           // }
          //  catch (System.Exception)
          //  {
                
           //     return false;
          //  }
            return true;
        }
        public bool SendEmailWithOutlook(string mailDirection, string mailSubject, string mailContent, string pathAttachment, Boolean boolAutomatico)
        {
            try
            {
                //Microsoft.Office.Interop.Outlook My_OutLook = new Microsoft.Office.Interop.Outlook(); 
                var oApp = new Microsoft.Office.Interop.Outlook.Application();

                Microsoft.Office.Interop.Outlook.NameSpace ns = oApp.GetNamespace("MAPI");

                object f = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);

                System.Threading.Thread.Sleep(1000);

                Outlook.MailItem mailItem = oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                mailItem.Subject = mailSubject;

                mailItem.HTMLBody = mailContent;
                mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
                mailItem.To = mailDirection;
                //Adjunto
                if (pathAttachment!=string.Empty)
                {
                    int iPosition = (int)mailItem.Body.Length + 1;
                    int iAttachType = (int)Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue;
                    Microsoft.Office.Interop.Outlook.Attachment oAttach = mailItem.Attachments.Add(pathAttachment, iAttachType, iPosition, "Adjunto");
                }

                mailItem.Save();
                if (boolAutomatico == true)
                {
                    mailItem.Send();
                }
                else
                {
                    mailItem.Display();
                }



                oApp = null;
                f = null;
                mailItem = null;
                //oAttach = null;

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error envío: " + ex.Message.ToString());
                return false;
            }
            finally
            {
            }
            return true;

        }

        public string armar_Cadena_Emails(string SP,int intEmpresa, int intEvento, int intCliente,string param_name)
        {
            funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = intEmpresa },
                new MySqlParameter(){ ParameterName="intEvento", Value = intEvento },
                new MySqlParameter(){ ParameterName=param_name, Value = intCliente }
            };

            DataTable p;
            string s=string.Empty ;
            p = lista.Get_Datos (SP, parameters);
            if (p.Rows.Count == 0)
            {
                return string.Empty;

            }
            foreach(DataRow dr in p.Rows)
            {
                s += string.Concat(dr[0].ToString(), ";");
            }
            int value = s.Length - 1;
            s = s.Substring(0, value);
            return s;
        }
        public enum TipoArchivos
        {
            E_COTI = 1,
            E_NOMINACION = 2,
            E_AUTORIZACIÓN = 3,
            E_CAMBIO_NOMINACION=4,
            E_FALSO_FLETE=5,
            E_FIN_VIAJE_OW = 6,
            E_CANCELACION =7,
            E_FIN_VIAJE_RT=9,
            E_GENERA_ANTICIPOS=10

        }


        //DED 31/08/22 //REMPLAZAMOS BODY STR.HTMLBUILDER X CuerpoEmail.html PARA COMBINAR LOS CODIGOS Y DAR FORMATO ADECUADO//
        public string ExportDatatableToHtml(DataTable dt,string color_Fondo_DataTable)
        {

           
            string archivo = Application.StartupPath.ToString() + "\\CuerpoEmail.html";
            StringBuilder strHTMLBuilder = new StringBuilder();
            ////strHTMLBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\" >");
            ////strHTMLBuilder.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\" >");
            //strHTMLBuilder.Append("<html >");

            ////strHTMLBuilder.Append("<head>");
            ////strHTMLBuilder.Append("</head>");
            //strHTMLBuilder.Append("<body><br/><br/>");
            //strHTMLBuilder.Append("<table border=3px bordercolor=#000000 cellpadding='3' cellspacing='10' bgcolor=#FFFFFF style='font-family:Arial; font-size:10pt '>");

            //strHTMLBuilder.Append("<tr font color='white'>");
            foreach (DataColumn myColumn in dt.Columns)
            {
                strHTMLBuilder.Append("<td align='center' style='padding: 10px 0 10px 0;'>");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");

            }
            strHTMLBuilder.Append("</tr>");


            foreach (DataRow myRow in dt.Rows)
            {

                //strHTMLBuilder.Append("<tr  bgcolor=#FFFFFF>");
                foreach (DataColumn myColumn in dt.Columns)
                {
                    strHTMLBuilder.Append("<td style='font-size: 11pt; widht=50px'; bgcolor='#FFFFFF';>&nbsp;");
                    strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");

                }
                strHTMLBuilder.Append("</tr>");
            }

            //Close tags.  
            //strHTMLBuilder.Append("</table>");
            //strHTMLBuilder.Append("</body>");
            //strHTMLBuilder.Append("</html><br/><br/>");

            //LEEMOS ARCHIVO HTML CuerpoEmail.html
            var html = File.ReadAllText(archivo);
            //LO REEMPLAZAMOS
            string Htmltext = strHTMLBuilder.ToString();
            var html1 = html.Replace("<reemplazar>", Htmltext);

            return html1;
            
        }
        private string ReadSignature()
        {
            //    string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Firmas";
            //    string signature = string.Empty;
            //    DirectoryInfo diInfo = new DirectoryInfo(appDataDir);

            //    if (diInfo.Exists)
            //    {
            //        FileInfo[] fiSignature = diInfo.GetFiles("*.htm");

            //        if (fiSignature.Length > 0)
            //        {
            //            StreamReader sr = new StreamReader(fiSignature[0].FullName, Encoding.Default);
            //            signature = sr.ReadToEnd();

            //            if (!string.IsNullOrEmpty(signature))
            //            {
            //                string fileName = fiSignature[0].Name.Replace(fiSignature[0].Extension, string.Empty);
            //                signature = signature.Replace(fileName + "_files/", appDataDir + "/" + fileName + "_files/");
            //            }
            //        }
            //    }
            guardar_datos_login datos = guardar_datos_login.Instance();
            string signature;
            string appDataDir = datos.g_Ruta_Firma_HTMP;
            DirectoryInfo diInfo = new DirectoryInfo(appDataDir);

            if (File.Exists(appDataDir))
            {
                //FileInfo[] fiSignature = appDataDir.ToString() ;
                //if (fiSignature.Length>0)
                //{
                    StreamReader sr = new StreamReader(appDataDir, Encoding.Default);
                    signature = sr.ReadToEnd();

                //}
                
            }
            else
            {
                signature = string.Empty;
            }
            return signature;

        }

        public void Envio_Email_Cuadro_Administracion(string SP,int intEmpresa, int intOT, int intItemOT,int TipoEventoAdmin,string strBlBooking,string color_Fondo_DataTable)
        {
            clsConn cnMarco = new clsConn();
            String strConnection_String;

            strConnection_String = cnMarco.Cadena_Conexion();

            MySqlConnection cnnConnection = new MySqlConnection(strConnection_String);


            MySqlParameter[] Parametros = new MySqlParameter[3];
            Parametros[0] = new MySqlParameter("intEmpresa", intEmpresa);
            Parametros[1] = new MySqlParameter("intOT", intOT);
            Parametros[2] = new MySqlParameter("intItemOT", intItemOT);


            cnnConnection.Open();

            MySqlCommand cmdCommand = cnnConnection.CreateCommand();
            cmdCommand.Connection = cnnConnection;
            cmdCommand.CommandType = CommandType.StoredProcedure;
            //verifico envio de email al final de la carga del ultimo contenedor
            cmdCommand.Parameters.Clear();//limpio los parametros.
            cmdCommand.CommandText = SP;

            foreach (MySqlParameter p in Parametros)
            {
                cmdCommand.Parameters.Add(p);
            }
            //declaro un tatbla
            DataTable dt_Mail = new DataTable();
            MySqlDataReader leer;
            leer = cmdCommand.ExecuteReader();

            dt_Mail.Load(leer);
            leer.Close();

            if (dt_Mail.Rows.Count > 0)
            {

                //Armo las direcciones de email
                funciones_envio_emails fee = new funciones_envio_emails();
                
                string strAsunto;
                string strCuerpo;
                string direcciones;
               
                direcciones = fee.armar_Cadena_Emails("SP_Email_Admin_Evento",intEmpresa, TipoEventoAdmin, 0, "intUsuario");

                strAsunto = string.Empty;
                switch (TipoEventoAdmin)
                {
                    case 5:
                        strAsunto = string.Concat("FALSO FLETE || OT: ", intOT.ToString(), " || Item: ", intItemOT.ToString(), " || BL/Booking: ", strBlBooking);
                        break;
                    case 6:
                        strAsunto = string.Concat("CANCELACIÓN || OT: ", intOT.ToString(), " || Item: ", intItemOT.ToString(), " || BL/Booking: ", strBlBooking);
                        break;
                }

               //strAsunto = string.Concat("Falso Flete=> OT: ", intOT.ToString(), "Item: ", intItemOT.ToString(), "BL/Booking: ", strBlBooking);
                //Cuerpo
                strCuerpo = string.Concat(fee.ExportDatatableToHtml(dt_Mail, color_Fondo_DataTable), Environment.NewLine, Environment.NewLine, fee.ReadSignature());



                fee.SendEmailWithOutlook(direcciones, strAsunto, strCuerpo, string.Empty, false);
            }
        }
        public void Envio_Email_Cotizacion(int intEmpresa, int intCliente, string strCotizacion, int intEvento_Param)
        {

            clsConn cnMarco = new clsConn();
            String strConnection_String;
            string strAsunto;
            string strCuerpo;
            int intDestino;

            intDestino = 0;
            strConnection_String = cnMarco.Cadena_Conexion();

            MySqlConnection cnnConnection = new MySqlConnection(strConnection_String);


            MySqlParameter[] Parametros = new MySqlParameter[4];
            Parametros[0] = new MySqlParameter("intEmpresa", intEmpresa);
            Parametros[1] = new MySqlParameter("strCotizacion", strCotizacion);
            Parametros[2] = new MySqlParameter("intEvento", intEvento_Param);
            Parametros[3] = new MySqlParameter("intDestino", intDestino);


            cnnConnection.Open();

            MySqlCommand cmdCommand = cnnConnection.CreateCommand();
            cmdCommand.Connection = cnnConnection;
            cmdCommand.CommandType = CommandType.StoredProcedure;
            //verifico envio de email al final de la carga del ultimo contenedor
            cmdCommand.Parameters.Clear();//limpio los parametros.
            cmdCommand.CommandText = "SP_Email_Cotizaciones";

            foreach (MySqlParameter p in Parametros)
            {
                cmdCommand.Parameters.Add(p);
            }
            //declaro un tatbla
            DataTable dt_Mail = new DataTable();
            MySqlDataReader leer;
            leer = cmdCommand.ExecuteReader();

            dt_Mail.Load(leer);
            leer.Close();

            //CARGO LAS DIRECCIONES
            if (dt_Mail.Rows.Count > 0)
            {


                string direcciones;
                int intEvento;

                intEvento = intEvento_Param;
                funciones_envio_emails fee = new funciones_envio_emails();
                direcciones = fee.armar_Cadena_Emails("SP_Emails_Direcciones", intEmpresa, intEvento, intCliente, "intCliente");

                //CARGO EL ASUNTO
                //leer = cmdCommand.ExecuteReader();
                //dt_Asunto.Load(leer);
                //leer.Close();

                strAsunto = dt_Mail.Rows[0][0].ToString();
                ////Cuerpo
                strCuerpo = string.Concat(dt_Mail.Rows[0][1].ToString(), Environment.NewLine, Environment.NewLine, fee.ReadSignature());



                fee.SendEmailWithOutlook(direcciones, strAsunto, strCuerpo, string.Empty, false);
            }
        }
        //intTipoServicio entra si es 1=impo si es 2=expo//DDE 2022/09/13//
        public void Envio_Email_Cuadro_Control(int intEmpresa, int intOT, string strBooking,int intCliente, int intItemOT, 
                int intOpcion,int intTipoServicio,int intEvento_Param,string color_Fondo_DataTable)//intOPcion, lista individual=0 o todo el paquete cuando =1
        {

            clsConn cnMarco = new clsConn();
            String strConnection_String;

            strConnection_String = cnMarco.Cadena_Conexion();

            MySqlConnection cnnConnection = new MySqlConnection(strConnection_String);


            MySqlParameter[] Parametros = new MySqlParameter[5];
            Parametros[0] = new MySqlParameter("intEmpresa",intEmpresa);
            Parametros[1] = new MySqlParameter("intOT", intOT);
            Parametros[2] = new MySqlParameter("strBooking", strBooking);
            if (intItemOT == 0 || intItemOT==-1 || intItemOT==-2)
            {
                Parametros[3] = new MySqlParameter("intItemOT", DBNull.Value );
            }
            else
            {
                Parametros[3] = new MySqlParameter("intItemOT", intItemOT);
            }
            Parametros[4] = new MySqlParameter("intOpcion", intOpcion);


            cnnConnection.Open();
           //******************************

            MySqlCommand cmdCommand = cnnConnection.CreateCommand();
            cmdCommand.Connection = cnnConnection;
            cmdCommand.CommandType = CommandType.StoredProcedure;
            //verifico envio de email al final de la carga del ultimo contenedor
            cmdCommand.Parameters.Clear();//limpio los parametros.
            // EDD 30/08/22 // Aca validamos si es 1(impo)o si es 2(expo) generar cuadro con datos para cada uno//

            //EDD 07/12/22 // SP EXCLUSIVOS PARA CLIENTES UNICOS
            cmdCommand.CommandText = "SP_traer_Clientes_Exclusivos";

            cmdCommand.Parameters.Add("intCliente", MySqlDbType.Int32);
            cmdCommand.Parameters["intCliente"].Value = intCliente;
       
            cmdCommand.ExecuteNonQuery();

            //declaro un tatbla
            DataTable SP = new DataTable();

            MySqlDataReader consultaCliente;
            consultaCliente = cmdCommand.ExecuteReader();

            SP.Load(consultaCliente);
            consultaCliente.Close();
       

            if (intTipoServicio==1)
                if (SP == null || SP.Rows.Count==0)
                {
                    cmdCommand.CommandText ="SP_Emails_Fin_Nominacion_impo";

                }
                else 
                {
                    cmdCommand.CommandText = SP.Rows[0]["SP"].ToString(); 
                }
            else
            {
                cmdCommand.CommandText ="SP_Emails_Fin_Nominacion_expo";
            }

            //cmdCommand.CommandText = "SP_Emails_Fin_Nominacion";



            foreach (MySqlParameter p in Parametros)
            {
                cmdCommand.Parameters.Add(p);
            }
            //declaro un tatbla
            DataTable dt_Mail = new DataTable();
            MySqlDataReader leer;
            leer = cmdCommand.ExecuteReader();

            dt_Mail.Load(leer);
            leer.Close();

            if (dt_Mail.Rows.Count > 0)
            {

                //Armo las direcciones de email
                funciones_envio_emails fee = new funciones_envio_emails();
                DataTable dt_Asunto = new DataTable();
                string strAsunto;
                string strCuerpo;
                string direcciones;
                int intEvento;

                intEvento = intEvento_Param;// (Int32)funciones_envio_emails.TipoArchivos.E_NOMINACION;==>>2020-08-31

                direcciones = fee.armar_Cadena_Emails("SP_Emails_Direcciones",intEmpresa, intEvento, intCliente, "intCliente");

                //Asunto
                
                cmdCommand.Parameters.Clear();//limpio los parametros.
                cmdCommand.CommandText = "SP_Emails_Fin_Nominacion_Asunto";
                if (intItemOT == -1)
                {
                    Parametros[3].Value  = 1;
                }
                if (intItemOT == -2)
                {
                    Parametros[3].Value  = 2;
                }
                foreach (MySqlParameter p in Parametros)
                {
                    cmdCommand.Parameters.Add(p);
                }

                // MySqlDataReader leer;
                leer = cmdCommand.ExecuteReader();
                dt_Asunto.Load(leer);
                leer.Close();

                strAsunto = dt_Asunto.Rows[0][0].ToString();
                //Cuerpo
                strCuerpo = string.Concat(fee.ExportDatatableToHtml(dt_Mail, color_Fondo_DataTable), Environment.NewLine, Environment.NewLine, fee.ReadSignature());



                fee.SendEmailWithOutlook(direcciones, strAsunto, strCuerpo, string.Empty, false);
            }
        }
    }

}
