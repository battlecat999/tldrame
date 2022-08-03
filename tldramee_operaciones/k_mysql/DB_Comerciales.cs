using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using k_loger;
using System.Data;


namespace k_mysql
{
    public class DB_Comerciales
    {
        private int idEmpresa;
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


        private clsConn Conexion = new clsConn();

        private MySqlCommand cmmd = new MySqlCommand();
        private MySqlDataReader leer;

        public bool DB_Grabar_Movimiento_Comercial_IN_OUT()
        {
            string SP;
            SP = "SP_Movimiento_Comercial_IN_OUT";


            MySqlCommand cmmd = new MySqlCommand(SP, Conexion.AbrirConexion());

            cmmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmmd.Parameters.AddWithValue("@pIdEmpresa", IdEmpresa);
            cmmd.Parameters.AddWithValue("@pIdCliente", IdCliente);
            cmmd.Parameters.AddWithValue("@pIdContacto", IdContacto);
            cmmd.Parameters.AddWithValue("@pTel_01", Tel_01);
            cmmd.Parameters.AddWithValue("@pTel_02", Tel_02);
            cmmd.Parameters.AddWithValue("@pFax", Fax);
            cmmd.Parameters.AddWithValue("@pEmail", Email);
            cmmd.Parameters.AddWithValue("@pIN_OUT", IN_OUT1);
            cmmd.Parameters.AddWithValue("@pDetalle", Detalle);
            cmmd.Parameters.AddWithValue("@pEnvio_email", Envio_email);
            cmmd.Parameters.AddWithValue("@pTipoLlamado", C_opcion);
            
            cmmd.Parameters.AddWithValue("@pIdUsuario", IdUsuario);
            cmmd.Parameters.AddWithValue("@pNomUsuario", NomUsuario);

            cmmd.ExecuteNonQuery();

            return true;

        }
        public  DataTable DB_Buscar_Historial_Por_Cliente()
        {
            DataTable dt = new DataTable();
            string SP;
            SP = "SP_Movimiento_Comercial_Traer_Historial";

            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = SP;
            cmmd.CommandType = CommandType.StoredProcedure;
            cmmd.Parameters.AddWithValue("@pIdCliente", IdCliente);
            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();

            return dt;
        }

    }
}
