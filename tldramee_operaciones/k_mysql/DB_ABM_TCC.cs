using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.Types;
using MySql.Data.MySqlClient;
using k_loger;
using System.Data;

/*ABM de Tractores, Chasis, Choferes*/
namespace k_mysql
{
    public class DB_ABM_TCC
    {
        private clsConn Conexion = new clsConn();

        private MySqlCommand cmmd = new MySqlCommand();
        private MySqlDataReader leer;

        public bool ABM_Tractor(int _pA,int _Id,string _Patente, int _Marca,
            int _Modelo,int _Anio, string _NroMotor,string _NroChasis,int _Tara,
            string _NroPoliza, int  _Seguro, string _FecVenSeguro, string _FecVenVTV, int _CantEjes,
            string _GPS_Clientes, string _GPS_Link, string _GPS_Us, string _GPS_Ps, 
            string _Observaciones, int _Activo, int _IdEmpresa, int _IdTransportista, int _IdUsuario, int _Colores)
        {


            DateTime _datFecVenSeguro;
            DateTime _datFecVenVTV;

            _datFecVenSeguro = Convert.ToDateTime(_FecVenSeguro);
            _datFecVenVTV = Convert.ToDateTime(_FecVenVTV);


            string SP;
            SP = "SP_Tractores_ABM";
            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = SP;
            cmmd.CommandType = CommandType.StoredProcedure;
            cmmd.Parameters.AddWithValue("@_pA", _pA);
            cmmd.Parameters.AddWithValue("@_Id", _Id);
            cmmd.Parameters.AddWithValue("@_Patente", _Patente);
            cmmd.Parameters.AddWithValue("@_Marca", _Marca);
            cmmd.Parameters.AddWithValue("@_Modelo", _Modelo);
            cmmd.Parameters.AddWithValue("@_Anio", _Anio);
            cmmd.Parameters.AddWithValue("@_NroMotor", _NroMotor);
            cmmd.Parameters.AddWithValue("@_NroChasis", _NroChasis);
            cmmd.Parameters.AddWithValue("@_Tara", _Tara);
            cmmd.Parameters.AddWithValue("@_NroPoliza", _NroPoliza);
            cmmd.Parameters.AddWithValue("@_Seguro", _Seguro);
            cmmd.Parameters.AddWithValue("@_FecVenSeguro", _datFecVenSeguro);
            cmmd.Parameters.AddWithValue("@_FecVenVTV", _datFecVenVTV);
            cmmd.Parameters.AddWithValue("@_CantEjes", _CantEjes);
            cmmd.Parameters.AddWithValue("@_GPS_Clientes", _GPS_Clientes);
            cmmd.Parameters.AddWithValue("@_GPS_Link", _GPS_Link);
            cmmd.Parameters.AddWithValue("@_GPS_Us", _GPS_Us);
            cmmd.Parameters.AddWithValue("@_GPS_PS", _GPS_Ps);
            cmmd.Parameters.AddWithValue("@_Observaciones", _Observaciones);
            cmmd.Parameters.AddWithValue("@_Activo", _Activo);
            cmmd.Parameters.AddWithValue("@pIdEmpresa", _IdEmpresa);
            cmmd.Parameters.AddWithValue("@pIdTransportista", _IdTransportista);
            cmmd.Parameters.AddWithValue("@pIdUsuario", _IdUsuario);
            cmmd.Parameters.AddWithValue("@_codigo_color", _Colores);

            cmmd.ExecuteNonQuery();
            

            return true;
        }

        public DataTable Traer_Tractor(int _pAll,int _pId)
        {
            DataTable dt = new DataTable();
            string SP;
            SP = "SP_Tractores_All";

            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = SP;
            cmmd.CommandType = CommandType.StoredProcedure;
            cmmd.Parameters.AddWithValue("@pAll", _pAll);
            cmmd.Parameters.AddWithValue("@pId", _pId);
            leer= cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();

            return dt;
        }
        
        public bool ABM_Chasis(int _pA,int _Id,string _Patente, int _Marca,
            int _Modelo,int _Anio, int _TipoChasis, string _NroChasis,int _Tara,
            string _NroPoliza, int  _Seguro, string _FecVenSeguro, string _FecVenVTV,
            int _CantEjes, int _TipoCarga, int _TipoTrafico, int _Generador,
            string _Observaciones, int _Activo,int _IdEmpresa, int _IdTransportista, int _IdUsuario,int _colores)
        {
            string SP;

            DateTime _datFecVenSeguro;
            DateTime _datFecVenVTV;

            _datFecVenSeguro = Convert.ToDateTime(_FecVenSeguro);
            _datFecVenVTV = Convert.ToDateTime(_FecVenVTV);

            SP = "SP_Chasis_ABM";
            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = SP;
            cmmd.CommandType = CommandType.StoredProcedure;
            cmmd.Parameters.AddWithValue("@_pA", _pA);//1=insert
            cmmd.Parameters.AddWithValue("@_Id", _Id);//0 si es nuevo
            cmmd.Parameters.AddWithValue("@_Patente", _Patente);
            cmmd.Parameters.AddWithValue("@_Marca", _Marca);
            cmmd.Parameters.AddWithValue("@_Modelo", _Modelo);
            cmmd.Parameters.AddWithValue("@_Anio", _Anio);
            cmmd.Parameters.AddWithValue("@_TipoChasis", _TipoChasis);
            cmmd.Parameters.AddWithValue("@_NroChasis", _NroChasis);
            cmmd.Parameters.AddWithValue("@_Tara", _Tara);
            cmmd.Parameters.AddWithValue("@_NroPoliza", _NroPoliza);
            cmmd.Parameters.AddWithValue("@_Seguro", _Seguro);
            cmmd.Parameters.AddWithValue("@_FecVenSeguro", _datFecVenSeguro);
            cmmd.Parameters.AddWithValue("@_FecVenVTV", _datFecVenVTV);
            cmmd.Parameters.AddWithValue("@_CantEjes", _CantEjes);
            cmmd.Parameters.AddWithValue("@_TipoCarga", _TipoCarga);
            cmmd.Parameters.AddWithValue("@_TipoTrafico", _TipoTrafico);
            cmmd.Parameters.AddWithValue("@_Generador", _Generador);
            cmmd.Parameters.AddWithValue("@_Observaciones", _Observaciones);
            cmmd.Parameters.AddWithValue("@_Activo", _Activo);
            cmmd.Parameters.AddWithValue("@pIdEmpresa", _IdEmpresa);
            cmmd.Parameters.AddWithValue("@pIdTransportista", _IdTransportista);
            cmmd.Parameters.AddWithValue("@pIdUsuario", _IdUsuario);
            cmmd.Parameters.AddWithValue("@_codigo_color", _colores );

            cmmd.ExecuteNonQuery();
            

            return true;
        }

        public DataTable Traer_Chasis(int _pAll, int _pId)
        {
            DataTable dt = new DataTable();
            string SP;
            SP = "SP_Chasis_All";

            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = SP;
            cmmd.CommandType = CommandType.StoredProcedure;
            cmmd.Parameters.AddWithValue("@pAll", _pAll);
            cmmd.Parameters.AddWithValue("@pId", _pId);
            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();

            return dt;
        }

        public bool ABM_Chofer(int _pA, int _IdChofer, string _Apellido, int _Pais, int _Provincia, string _Localidad,
            string _Direccion, string _CodPost, int _TipoDoc, string _NroDoc, string _NroLicencia, string _FecVenLic,
            string _Municipio, string _NroPoliza, string _Seguro, string _FecVenSeguro, string _LibretaSanitaria,
            string _Email, string _Radio, string _Telefono, string _Celular, int _Activo, int _IdEmpresa, int _IdTransportista, int _IdUsuario)
        {
            try
            {

                DateTime _datFecVenSeguro;
                DateTime _datFecVenLic;

                _datFecVenSeguro = Convert.ToDateTime(_FecVenSeguro);
                _datFecVenLic = Convert.ToDateTime(_FecVenLic);

                string SP;
                SP = "SP_Choferes_ABM";
                cmmd.Connection = Conexion.AbrirConexion();
                cmmd.CommandText = SP;
                cmmd.CommandType = CommandType.StoredProcedure;
                cmmd.Parameters.AddWithValue("@_pA", _pA);
                cmmd.Parameters.AddWithValue("@_IdChofer", _IdChofer);
                cmmd.Parameters.AddWithValue("@_Apellido", _Apellido);
                cmmd.Parameters.AddWithValue("@_Pais", _Pais);
                cmmd.Parameters.AddWithValue("@_Provincia", _Provincia);
                cmmd.Parameters.AddWithValue("@_Localidad", _Localidad);
                cmmd.Parameters.AddWithValue("@_Direccion", _Direccion);
                cmmd.Parameters.AddWithValue("@_CodPost", _CodPost);
                cmmd.Parameters.AddWithValue("@_TipoDoc", _TipoDoc);
                cmmd.Parameters.AddWithValue("@_NroDoc", _NroDoc);

                cmmd.Parameters.AddWithValue("@_NroLicencia", _NroLicencia);
                cmmd.Parameters.AddWithValue("@_FecVenLic", _datFecVenLic);
                cmmd.Parameters.AddWithValue("@_Municipio", _Municipio);
                cmmd.Parameters.AddWithValue("@_NroPoliza", _NroPoliza);

                cmmd.Parameters.AddWithValue("@_Seguro", _Seguro);
                cmmd.Parameters.AddWithValue("@_FecVenSeguro", _datFecVenSeguro);
                cmmd.Parameters.AddWithValue("@_LibretaSanitaria", _LibretaSanitaria);
                cmmd.Parameters.AddWithValue("@_Email", _Email);
                cmmd.Parameters.AddWithValue("@_Radio", _Radio);
                cmmd.Parameters.AddWithValue("@_Telefono", _Telefono);
                cmmd.Parameters.AddWithValue("@_Celular", _Celular);
                cmmd.Parameters.AddWithValue("@_Activo", _Activo);

                cmmd.Parameters.AddWithValue("@pIdEmpresa", _IdEmpresa);
                cmmd.Parameters.AddWithValue("@pIdTransportista", _IdTransportista);
                cmmd.Parameters.AddWithValue("@pIdUsuario", _IdUsuario);

                cmmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
                                                                                    {
                Console.WriteLine("Error" + e.GetType());
                return false;
            }
            finally
            {
               
            }
        }

        public DataTable  Traer_Chofer(int _pAll, int _pId)
        {
            DataTable dt = new DataTable();
            string SP;
            SP = "SP_Choferes_All";

            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = SP;
            cmmd.CommandType = CommandType.StoredProcedure;
            cmmd.Parameters.AddWithValue("@pAll", _pAll);
            cmmd.Parameters.AddWithValue("@pId", _pId);
            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();

            return dt;
        }
        
        public bool ABM_Trans_TCC(int _Tabla, int _pA, int _idTrans, int _Id, int _ocupado, int _ot, int _activo)
        {
            string SP;
            SP = "SP_Trans_TCC";
            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = SP;
            cmmd.CommandType = CommandType.StoredProcedure;
            cmmd.Parameters.AddWithValue("@_Tabla", _Tabla);
            cmmd.Parameters.AddWithValue("@_pA", _pA);//1 Alta - 2 UPDATE 
            cmmd.Parameters.AddWithValue("@_idTrans", _idTrans);
            cmmd.Parameters.AddWithValue("@_Id", _Id);
            cmmd.Parameters.AddWithValue("@_ocupado", _ocupado);
            cmmd.Parameters.AddWithValue("@_ot", _ot);
            cmmd.Parameters.AddWithValue("@_activo", _activo);//0 - Activo - 1 - Inactivo
            cmmd.ExecuteNonQuery();

            return true;
        }
        public DataTable Listar_Tipo_Marcas()
        {
            DataTable dt = new DataTable();
            string SP;
            SP = "SP_GET_Tipo_Marcas";

            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = SP;
            cmmd.CommandType = CommandType.StoredProcedure;
            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();

            return dt;
        }
        public DataTable Listar_Tipo_Colores()
        {
            DataTable dt = new DataTable();
            string SP;
            SP = "SP_GET_Tipo_Colores";

            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = SP;
            cmmd.CommandType = CommandType.StoredProcedure;
            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();

            return dt;
        }
        public DataTable Listar_Tipo_Modelos(int id)
        {
            DataTable dt = new DataTable();
            string SP;
            SP = "SP_GET_Marcas_Modelos";

            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = SP;
            cmmd.CommandType = CommandType.StoredProcedure;
            cmmd.Parameters.AddWithValue("@pId", id);
            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();

            return dt;
        }
    }
}
