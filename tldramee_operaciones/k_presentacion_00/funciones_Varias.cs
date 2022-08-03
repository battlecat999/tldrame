using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using ClosedXML.Excel;
using System.Diagnostics;
using k_negocio_00;
using MySql.Data.MySqlClient;
using System.IO;

namespace k_presentacion_00
{
    public class funciones_Varias
    {
        guardar_datos_login datos = guardar_datos_login.Instance();
        public string Genera_PDF_desde_HTML(string str_numero_anticipo, string str_nombre_archivo)
        {
            try
            {
                string HTML_Datos;
                string path = AppDomain.CurrentDomain.BaseDirectory + "wkhtmltopdf\\wkhtmltopdf.exe";

                ProcessStartInfo oProcessStarInfo = new ProcessStartInfo();
                oProcessStarInfo.UseShellExecute = false;
                oProcessStarInfo.FileName = path;

                //Eliminar Archivo 
                //
                string ruta_archivo_html = @datos.g_Ruta_Comp_HTML + "Genera_Recibo.html ";
                string ruta_archivo_pdf = @datos.g_Ruta_Comp_Anticipos + "\\" + str_numero_anticipo + ".pdf";
                if (File.Exists(ruta_archivo_html))
                {
                    File.Delete(ruta_archivo_html);
                }
                HTML_Datos = str_nombre_archivo;// dr["strCuerpo"].ToString();
                File.WriteAllText(ruta_archivo_html, HTML_Datos);



                oProcessStarInfo.Arguments = ruta_archivo_html + " " + ruta_archivo_pdf;


                using (Process oProcess = Process.Start(oProcessStarInfo))
                {
                    oProcess.WaitForExit();
                }
                return ruta_archivo_pdf;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static AutoCompleteStringCollection LoadAutoComplete(DataTable dt_param,string campo)
        {
            DataTable dt = dt_param;

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringCol.Add(Convert.ToString(row[campo]));
            }

            return stringCol;
        }
        public void CargarComboDataTable(ComboBox cbo,DataTable dt,String campoValue, String compoDisplay,bool Cadena,bool boolAutoCompletado)
        {
            DataRow row = dt.NewRow();
            if (Cadena == true)
            {
                row[(0)] = String.Empty;
            }else
            {
                row[(0)] = 0;
            }
            row[1] = String.Empty;

            dt.Rows.Add(row);
         
            
            cbo.DisplayMember = compoDisplay;
            cbo.ValueMember = campoValue;
            cbo.DataSource = dt;
            
            cbo.SelectedIndex = -1;

            if (boolAutoCompletado == true)
            {
                cbo.AutoCompleteCustomSource = funciones_Varias.LoadAutoComplete(dt, compoDisplay);
                cbo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cbo.AutoCompleteMode = AutoCompleteMode.Suggest;
                
            }

        }
        public void CargarComboDataTable(ComboBox cbo, DataTable dt, String campoValue, String compoDisplay, bool Cadena, bool agrega_linea_vacia,bool tres_campos, bool boolAutoCompletado)
        {
            DataRow row = dt.NewRow();
            if (Cadena == true)
            {
                row[(0)] = String.Empty;
            }
            else
            {
                row[(0)] = 0;
            }
            row[1] = String.Empty;
            if (tres_campos == true)
            {
                row[2] = 0;
            }

            if (agrega_linea_vacia == true)
            {
                dt.Rows.Add(row);
            }

            cbo.DisplayMember = compoDisplay;
            cbo.ValueMember = campoValue;
            cbo.DataSource = dt;

            cbo.SelectedIndex = -1;
            if (boolAutoCompletado == true)
            {
                cbo.AutoCompleteCustomSource = funciones_Varias.LoadAutoComplete(dt, compoDisplay);
                cbo.AutoCompleteMode = AutoCompleteMode.Suggest;
                cbo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }


       
        public void ColorearGradientPanel(Form F, GradientPanel G)
        {
            G.ColorButtom = ColorTranslator.FromHtml("#8A898F");
            G.ColorTop = ColorTranslator.FromHtml("#81352D");
            foreach(Control lbl in G.Controls)
            {
                if(lbl.GetType().Name.ToString() == "Label")
                {
                    lbl.BackColor = Color.Transparent;
                }
            }
        }

        public static string GetValorCelda(DataGridView dgv, int num)
        {
            string valor = "";

            valor = dgv.Rows[dgv.CurrentRow.Index].Cells[num].Value.ToString();

            return valor;
        }
        public static void ExportToExcel(DataTable dt,string nombreArchivo)
        {
            DataTable dataTable = dt;
            dataTable.TableName = "Exportación";
            string rutaArchivo;
            rutaArchivo = Application.StartupPath.ToString() + "\\"+ nombreArchivo  +".xlsx";
            if (dataTable.Rows.Count > 0)
            {
                using (var wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(dataTable);

                    wb.SaveAs(rutaArchivo);
                    Process.Start(rutaArchivo);
                }
            }
        }
        public enum TipoConcepto
        {
            //C_INICIA_VIAJE = 1,
            C_EN_PUERTO = 1,
            C_EN_TRANSITO = 2,
            C_EN_PLANTA = 3,
            C_RETORNO = 4,
            C_SALE_TERMINAL = 5,
            
        }
        public int ListarProcesoNuevo(int[] Existe01, int[] Existe02)
        {
            int xx = 0;
            int intListarProcesoNuevo;
            intListarProcesoNuevo = 0;
            Array.Sort(Existe01);
            Array.Sort(Existe02);

            for (xx = 0; xx <= Existe02.Length - 1; xx++)
            {
                if (Existe01[xx] != Existe02[xx])
                {
                    intListarProcesoNuevo= Existe02[xx];
                    return intListarProcesoNuevo;
                }
            }
            if (intListarProcesoNuevo==0)
            {
                return 0;
            }
            else
            {
                return intListarProcesoNuevo;
            }
        }
        public int[] ListarProcesosAntes(string strProceso)
        {
            Process[] proceso;
            int[] IdProcesos;
            int i;
            // obtener los procesos segun el parametros
            proceso = Process.GetProcessesByName(strProceso);
            IdProcesos = new int[101];
            for (i = 0; i <= 100; i++)
                IdProcesos[i] = 65000;
            for (i = 0; i <= proceso.Length - 1; i++)
                IdProcesos[i] = proceso[i].Id;

            return IdProcesos;
        }
        public int[] ListarProcesosDespues(string strProceso)
        {
            Process[] proceso;
            int[] IdProcesos;
            int i;
            // obtener los procesos segun el parametros
            proceso = Process.GetProcessesByName(strProceso);
            IdProcesos = new int[101];
            for (i = 0; i <= 100; i++)
                IdProcesos[i] = 65000;

            for (i = 0; i <= proceso.Length - 1; i++)
                IdProcesos[i] = proceso[i].Id;
            return IdProcesos;
        }

        public bool DescargarProceso(int PID)
        {
            if (PID != 0)
                Process.GetProcessById(PID).Kill();
            return true;
        }
        public  DataTable Carga_Contenedores(int intEmpresa)
        {
            DN_ABM o = new DN_ABM();

            DataTable dtContenedores = new DataTable();
            dtContenedores = o.DN_Traer_DataTable("SP_GET_Contenedores_ALL", 0,intEmpresa);

            return dtContenedores;
        }
        public bool IsDate(String date)
        {
            try
            {
                DateTime dt = DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool Valido_Black_List(string strValor,int intGrabar)
        {
            string strLeyenda;
            DNTablas_Gral lista = new DNTablas_Gral();
            DataTable dt;
            var parameters = new[]
           {
                    new MySqlParameter(){ ParameterName="strPatente", Value = strValor },
                    new MySqlParameter(){ ParameterName="intGrabar", Value = intGrabar }
           };
            DataRow dr;


            dt = lista.Get_Datos("SP_Black_List_Valida", parameters);
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
                strLeyenda = dr[0].ToString();
                return true;
            }
            else
            {
                strLeyenda = string.Empty;
                return false;
            }
            

        }
        public int Carga_Si_Requiere_Moro(int intEmpresa,int intOT, int intItem)
        {
            DNTablas_Gral lista = new DNTablas_Gral();

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = intEmpresa },
                new MySqlParameter(){ ParameterName="intOT", Value = intOT },
                new MySqlParameter(){ ParameterName="intItem", Value = intItem },
            };

            DataTable p;
            DataRow row;

            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;

            p = lista.Get_Datos("SP_OT_Item_Es_Moro", parameters);
            //this.lblEsMoro.Text = "0";
            if (p.Rows.Count > 0)
            {
                row = p.Rows[0];
                if (row["EsMoro"].ToString() == "1")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        public bool Abrir_Form_OT(int permisos)
        {
            if (permisos <= 4)
            {
                frm_Comerciales_OT ofrm = new frm_Comerciales_OT();
                ofrm.Location = new Point(10, 10);
                ofrm.Show();
            }
            return true;
        }
    }

}


