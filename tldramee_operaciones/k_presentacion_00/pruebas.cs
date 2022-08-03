using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using k_negocio_00;
using MySql.Data.MySqlClient;
using System.Diagnostics;



namespace k_presentacion_00
{
    public partial class pruebas : Form
    {
        guardar_datos_login datos = guardar_datos_login.Instance();
        public pruebas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

            
            DataTable dt_Anticipos;
                string HTML_Datos;
            
            

            //cargar SP HTML
            DNTablas_Gral lista = new DNTablas_Gral();

            var parameters = new[]
                {
                    new MySqlParameter(){ ParameterName="intEmpresa", Value = datos.g_idEmpresa },
                    new MySqlParameter(){ ParameterName="intOT", Value = 1865 },
                    new MySqlParameter(){ ParameterName="intItemOT", Value = 1 }
                };

            dt_Anticipos = lista.Get_Datos("SP_Genera_Recibo_Emails", parameters);

            DataRow dr;
            dr = dt_Anticipos.Rows[0];

            string path = AppDomain.CurrentDomain.BaseDirectory + "wkhtmltopdf\\wkhtmltopdf.exe";


            ProcessStartInfo oProcessStarInfo = new ProcessStartInfo();
            oProcessStarInfo.UseShellExecute = false;
            oProcessStarInfo.FileName = path;

                //Eliminar Archivo 
                //
                string ruta_archivo_html = @datos.g_Ruta_Comp_HTML + "Genera_Recibo.html ";
                if (File.Exists(ruta_archivo_html))
                {
                    File.Delete(ruta_archivo_html);
                }
                HTML_Datos = dr["strCuerpo"].ToString();
                File.WriteAllText(ruta_archivo_html, HTML_Datos);



            oProcessStarInfo.Arguments= ruta_archivo_html + " " + datos.g_Ruta_Comp_Anticipos + "\\" + dr["v_numero_anticipo"].ToString() + ".pdf";


            using(Process oProcess = Process.Start(oProcessStarInfo))
            {
                oProcess.WaitForExit();
            }
            MessageBox.Show("PDF Creado");
                //if (dt_Anticipos.Rows.Count > 0)
                //{
                //    DataRow dr;
                //    dr = dt_Anticipos.Rows[0];
                //    guardar.FileName = dr["v_numero_anticipo"].ToString()+ ".pdf";
                //    //guardar.ShowDialog();

                //    string paginahtml_texto = dr["strCuerpo"].ToString();
                //    if (guardar.ShowDialog() == DialogResult.OK)
                //    {
                //        using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                //        {
                //            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                //            PdfWriter write = PdfWriter.GetInstance(pdfDoc, stream);

                //            pdfDoc.Open();

                //            pdfDoc.Add(new Phrase(""));
                //            using (StringReader sr = new StringReader(paginahtml_texto))
                //            {
                //                XMLWorkerHelper.GetInstance().ParseXHtml(write, pdfDoc, sr);
                //            }

                //            pdfDoc.Close();
                //            stream.Close();
                //        }
                //    }
                //}
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //frm_Cargar_Estadias frm = new frm_Cargar_Estadias();
            //    frm._OT = 1840;
            //    frm._Item = 1;

            //frm.ShowDialog(this);
            //if (frm.DialogResult== DialogResult.OK)
            //{

            string path = AppDomain.CurrentDomain.BaseDirectory + "wkhtmltopdf\\wkhtmltopdf.exe";
            MessageBox.Show(path);

            //}
            //else
            //{


            //}
        }
    }
}
