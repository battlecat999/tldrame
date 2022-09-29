using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace k_mysql
{
    public class DBTablas_Gral
    {
        string _descripcion;
        string _tabla;
        private clsConn Conexion = new clsConn();
        private MySqlCommand cmmd = new MySqlCommand();
        private MySqlDataReader leer;

        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Tabla { get => _tabla; set => _tabla = value; }

        //public DataTable LlenaComboGral(string ComboCargar)
        //{

        //    DataTable dt = new DataTable();
        //    string SP;
        //    SP = string.Empty;
        //    switch (ComboCargar)
        //    {
        //        case "cboCondicionPago": SP = "SP_Condicion_de_Pago";
        //            break;
        //        case "cboCondicionIVA": SP = "SP_Get_tipoCondIVA";
        //            break;
        //        case "cboEstado": SP = "SP_Get_Estados";
        //            break;
        //        case "cboTipoDoc": SP = "SP_GET_Tipo_de_Doc";
        //            break;
        //        case "cboTipoServicio": SP = "SP_GET_Tipo_Servicios_ALL";
        //            break;
        //        case "cboVendedores": SP = "SP_GET_Vendedores_ALL";
        //            break;
        //        case "cboMercaderias": SP = "SP_GET_Mercaderias_ALL";
        //            break;
        //        case "cboContenedores": SP = "SP_GET_Contenedores_ALL";
        //            break;
        //        case "cboCorredores":  SP = "SP_Corredores_Combo";
        //            break;
        //        case "cboDuracion": SP = "SP_Duracion_Viajes";
        //            break;
        //    }

        //    cmmd.Connection = Conexion.AbrirConexion();
        //    cmmd.CommandText = SP;//"SP_Condicion_de_Pago";
        //    cmmd.CommandType = CommandType.StoredProcedure;
        //    leer = cmmd.ExecuteReader();
        //    dt.Load(leer);
        //    leer.Close();
        //    Conexion.CerrarConexion();
        //    return dt;
        //}
        //public DataTable ListarPaises()
        //{
        //    DataTable dt = new DataTable();
        //    cmmd.Connection = Conexion.AbrirConexion();
        //    cmmd.CommandText = "SP_Get_Paises";
        //    cmmd.CommandType = CommandType.StoredProcedure;
        //    leer = cmmd.ExecuteReader();
        //    dt.Load(leer);
        //    leer.Close();
        //    Conexion.CerrarConexion();
        //    return dt;
        //}
        public DataTable ListarProvincias(int p_IdPais)
        {
            DataTable dt = new DataTable();
            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = "SP_Get_Provincias";
            cmmd.CommandType = CommandType.StoredProcedure;
            cmmd.Parameters.AddWithValue("@p_idPais", p_IdPais);
            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return dt;
        }
        public DataTable ListarLocalidades(int p_idProvincia)
        {
            DataTable dt = new DataTable();
            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = "SP_Get_Localidades";
            cmmd.CommandType = CommandType.StoredProcedure;
            cmmd.Parameters.AddWithValue("@p_idProvincia", p_idProvincia);
            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return dt;
        }

        public DataTable Listar_TipoChasis()
        {
            DataTable dt = new DataTable();
            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = "SP_GET_Tipo_Chasis";
            cmmd.CommandType = CommandType.StoredProcedure;
            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return dt;
        }
        public DataTable Listar_TipoCarga()
        {
            DataTable dt = new DataTable();
            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = "SP_GET_Tipo_Carga";
            cmmd.CommandType = CommandType.StoredProcedure;
            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return dt;
        }
        public DataTable Listar_TipoTrafico()
        {
            DataTable dt = new DataTable();
            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = "SP_GET_Tipo_Traficos";
            cmmd.CommandType = CommandType.StoredProcedure;
            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return dt;
        }

        public DataTable Get_Transportistas(MySqlParameter[] Parametros)
        {
            DataTable dt = new DataTable();

            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = "SP_Proveedor_A_Designar";
            cmmd.CommandType = CommandType.StoredProcedure;

            if (Parametros != null)
            {
                foreach (MySqlParameter p in Parametros)
                {
                    cmmd.Parameters.Add(p);
                }
            }

            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return dt;
        }

        public DataTable Get_Datos(string strStored_Procedure, MySqlParameter[] Parametros)
        {
            DataTable dt = new DataTable();

            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = strStored_Procedure;
            cmmd.CommandType = CommandType.StoredProcedure;
            cmmd.CommandTimeout = 120;

            if (Parametros != null)
            {
                foreach (MySqlParameter p in Parametros)
                {
                    cmmd.Parameters.Add(p);
                }
            }

            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return dt;
        }
        //public MySqlDataReader Get_Datos_dr(string strStored_Procedure, MySqlParameter[] Parametros)
        //{
        //    DataTable dt = new DataTable();

        //    cmmd.Connection = Conexion.AbrirConexion();
        //    cmmd.CommandText = strStored_Procedure;
        //    cmmd.CommandType = CommandType.StoredProcedure;

        //    if (Parametros != null)
        //    {
        //        foreach (MySqlParameter p in Parametros)
        //        {
        //            cmmd.Parameters.Add(p);
        //        }
        //    }

        //    leer = cmmd.ExecuteReader();
        //    dt.Load(leer);
        //    //leer.Close();
        //    Conexion.CerrarConexion();
        //    return leer;
        //}


        public DataTable Get_Datos(string strStored_Procedure)
        {
            DataTable dt = new DataTable();

            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = strStored_Procedure;
            cmmd.CommandType = CommandType.StoredProcedure;

            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return dt;
        }



        public DataTable Listar_EmpresasSeguros()
        {
            DataTable dt = new DataTable();
            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = "SP_GET_Empresas_Seguros";
            cmmd.CommandType = CommandType.StoredProcedure;
            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return dt;
        }
        public DataTable Listar_Estados()
        {
            DataTable dt = new DataTable();
            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = "SP_Get_Estados";
            cmmd.CommandType = CommandType.StoredProcedure;
            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return dt;
        }
        //Grabar Tablas Generales.
        public bool DB_Grabar_Tabla_Gral()
        {
            string SP;
            SP = "SP_ALTA_TABLAS_GRALES";
            MySqlCommand cmmd = new MySqlCommand(SP, Conexion.AbrirConexion());

            cmmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmmd.Parameters.AddWithValue("@pTabla", Tabla);
            cmmd.Parameters.AddWithValue("@pDetalle", Descripcion);

            cmmd.ExecuteNonQuery();

            return true;

        }
        public DataTable DB_Datos_Parametros(int IdEmpresa, string strCampo)
        {
            DataTable dt = new DataTable();
            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = "SP_Cargar_Parametros_Generales";
            cmmd.CommandType = CommandType.StoredProcedure;
            cmmd.Parameters.AddWithValue("@pIdEmpresa", IdEmpresa);
            cmmd.Parameters.AddWithValue("@pStrCampo", strCampo);
            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return dt;

        }
        
    }
}
