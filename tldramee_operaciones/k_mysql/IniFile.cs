using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using encrypasocv;


namespace k_mysql
{
   public class IniFile
    {

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, string lpReturnedString, int nSize, string lpFileName);
        private void GrabarINI(string Archivo, string Seccion, string Clave,string Text)
        {
            WritePrivateProfileString(Seccion, Clave, Text, Archivo);
        }
        private  string LeerINI(string Archivo, string Seccion, string Clave)
        {
            string result=string.Empty;
            int iRetLen;
            string sRet;
            string lpDefault;
            lpDefault = "Unknown";
            sRet = new string(' ', 255);
            iRetLen = GetPrivateProfileString(Seccion, Clave, lpDefault, sRet, sRet.Length , Archivo);
            sRet = sRet.Substring(0, iRetLen); //Left(sRet, iRetLen);
            result = sRet;
            return result;
        }
        //Leer La configuracion del archivo
        public string LeeSetting()
        {
            string result=string.Empty;
            string rutaini = string.Empty;
            encrypasocv.Encryption en = new encrypasocv.Encryption();

            try
            {
                if (System.IO.File.Exists(string.Concat(Directory.GetCurrentDirectory(), "\\Cnn.ini")))
                {
                    rutaini = string.Concat(Directory.GetCurrentDirectory(), "\\Cnn.ini");
                   
                    result = en.Decrypt( LeerINI(rutaini, "Settings", "CadenaCon"));
                }
                else
                {
                    result = string.Empty;
                }

            }
            finally
            {

            }
         
            return result;
            
        }
    }
}
