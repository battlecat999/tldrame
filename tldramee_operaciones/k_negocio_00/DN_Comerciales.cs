using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using k_mysql;
using MySql.Data;
using MySql.Data.Types;
using MySql.Data.MySqlClient;
using System.Data;

namespace k_negocio_00
{
    public class DN_Comerciales
    {
        private int idCliente;
        private int idContacto;
        private string tel_01;
        private string tel_02;
        private string fax;
        private string email;
        private int IN_OUT;
        private string detalle;
        private bool envio_email;
        private string c_opcion;
        private int idEmpresa;
        private int idUsuario;
        private string nomUsuario;

        public int IdEmpresa { get => idEmpresa; set => idEmpresa = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdContacto { get => idContacto; set => idContacto = value; }
        public string Tel_01 { get => tel_01; set => tel_01 = value; }
        public string Tel_02 { get => tel_02; set => tel_02 = value; }
        public string Fax { get => fax; set => fax = value; }
        public string Email { get => email; set => email = value; }
        public int IN_OUT1 { get => IN_OUT; set => IN_OUT = value; }
        public string Detalle { get => detalle; set => detalle = value; }
        public bool Envio_email { get => envio_email; set => envio_email = value; }
        public string C_opcion { get => c_opcion; set => c_opcion = value; }
        
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string NomUsuario { get => nomUsuario; set => nomUsuario = value; }


        public bool DN_Grabar_Movimiento_Comercial_IN_OUT()
        {
            bool ok;
            ok = true;

            DB_Comerciales db_c = new DB_Comerciales();
            db_c.IdEmpresa = idEmpresa;
            db_c.IdCliente = IdCliente;
            db_c.IdContacto = IdContacto;
            db_c.Tel_01 = Tel_01;
            db_c.Tel_02 = Tel_02;
            db_c.Fax = Fax;
            db_c.Email = Email;
            db_c.IN_OUT1 = IN_OUT1;
            db_c.Detalle = Detalle.Replace("'", "´").ToUpper() ;
            db_c.Envio_email = Envio_email;
            db_c.C_opcion = C_opcion;
            db_c.IdUsuario = IdUsuario;
            db_c.NomUsuario = NomUsuario;

            db_c.DB_Grabar_Movimiento_Comercial_IN_OUT();

            return ok;
        }

        public string Buscar_Historial_Por_Cliente()
        {
            DataTable dt = new DataTable();
            DB_Comerciales lista = new DB_Comerciales();
            lista.IdCliente = IdCliente;
            dt = lista.DB_Buscar_Historial_Por_Cliente();

            string c_Informe;
            c_Informe = string.Empty;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows) 
                {
                    c_Informe = String.Concat(c_Informe, "Fecha y Hora: ", dr["FechaHora"], "Acción: ", dr["TipoLlamada"], dr["TipoLlamada"].ToString() == "Reunión" ? "--> Estado de la Reunión: " : "--> Tipo de Llamado: ", dr["TipoLlamado"], " Hecho Por: ", dr["nombreUsuario"]);
                    c_Informe = String.Concat(c_Informe, "\r\n");
                    c_Informe = String.Concat(c_Informe, dr["Detalle"]);
                    c_Informe = String.Concat(c_Informe, "\r\n");
                    c_Informe = String.Concat(c_Informe, "\r\n");
                }
                return  c_Informe;
            }else
            {
                return "sin Novedades...";
            }
        }
    }
}
