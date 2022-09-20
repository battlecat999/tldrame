using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_mysql
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
            public string g_Item { get; set; }  
            public string g_IdEstado { get; set; }
        }
}
