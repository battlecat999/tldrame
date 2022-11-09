using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_presentacion_00
{
    public class guardar_datos_login//la clase se hace public
    {
        private static guardar_datos_login datos;
        private guardar_datos_login() { }
        public static guardar_datos_login Instance()
        {
            if (datos == null)
            {
                datos = new guardar_datos_login();
            }
            return datos;
        }
        public int g_idEmpresa { get; set; }
        public string g_nomEmpresa { get; set; }
        public string g_empresaDireccion { get; set; }
        public int g_idUser { get; set; }
        public string g_userName { get; set; }
        public string g_lastName { get; set; }
        public string g_email { get; set; }
        public int g_permiso { get; set; }
        public string g_Ruta_Firma_HTMP { get; set; }
        public string g_Ruta_Firma_Logo { get; set; }
        public string g_Ruta_Comp_Anticipos { get; set; }
        public string g_Ruta_Comp_HTML { get; set; }
        public string g_Ruta_Comp_Emails { get; set; }

        public string g_Email_Administracion { get; set; }
        public string g_telefono1 { get; set; }
        public string g_funciones { get; set; }
        public string g_nombreUser { get; set; }

    }
}
