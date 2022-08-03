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
    public class DB_Corredores
    {

        /// <summary>
        /// 
        private int _IdTransportista;
        private int _IdCliente;
        private int _IdCorredor;
        private int _IdUsuario;
        private int _IdEmpresa;
        /// </summary>
        private int _pALL;
        private int _pId;
        private string _Origen;
        private string _Destino;
        private string _Retorno;
        private double _oneWay;
        private double _roundTrip;
        private double _TTAT;
        private double _TTAC;
        private int _Activo;
        private int _Tipo;
        private double _Costo;
        private string _Fecha;
        private string _Detalle;



        private clsConn Conexion = new clsConn();

        private MySqlCommand cmmd = new MySqlCommand();
        private MySqlDataReader leer;

        public int pALL
        {
            get
            {
                return _pALL;
            }

            set
            {
                _pALL = value;
            }
        }

        public string Origen
        {
            get
            {
                return _Origen;
            }

            set
            {
                _Origen = value;
            }
        }

        public string Destino
        {
            get
            {
                return _Destino;
            }

            set
            {
                _Destino = value;
            }
        }

        public string Retorno
        {
            get
            {
                return _Retorno;
            }

            set
            {
                _Retorno = value;
            }
        }

        public double  OneWay
        {
            get
            {
                return _oneWay;
            }

            set
            {
                _oneWay = value;
            }
        }

        public double RoundTrip
        {
            get
            {
                return _roundTrip;
            }

            set
            {
                _roundTrip = value;
            }
        }

        public double TTAT
        {
            get
            {
                return _TTAT;
            }

            set
            {
                _TTAT = value;
            }
        }

        public double TTAC
        {
            get
            {
                return _TTAC;
            }

            set
            {
                _TTAC = value;
            }
        }

        public int Activo
        {
            get
            {
                return _Activo;
            }

            set
            {
                _Activo = value;
            }
        }

        public int Tipo
        {
            get
            {
                return _Tipo;
            }

            set
            {
                _Tipo = value;
            }
        }

        public double Costo
        {
            get
            {
                return _Costo;
            }

            set
            {
                _Costo = value;
            }
        }

        public string Fecha
        {
            get
            {
                return _Fecha;
            }

            set
            {
                _Fecha = value;
            }
        }

        public int pId
        {
            get
            {
                return _pId;
            }

            set
            {
                _pId = value;
            }
        }

        public int IdTransportista { get => _IdTransportista; set => _IdTransportista = value; }
        public int IdCorredor { get => _IdCorredor; set => _IdCorredor = value; }
        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public int IdEmpresa { get => _IdEmpresa; set => _IdEmpresa = value; }
        public int IdCliente { get => _IdCliente; set => _IdCliente = value; }
        public string Detalle { get => _Detalle; set => _Detalle = value; }

        public DataTable Traer_Elementos(int _pAll, int _pId,string _pNombre, int _IdEmpresa)
        {
            DataTable dt = new DataTable();
            string SP;
            SP = "SP_Elementos_Get_All";

            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = SP;
            cmmd.CommandType = CommandType.StoredProcedure;
            cmmd.Parameters.AddWithValue("@pAll", _pAll);
            cmmd.Parameters.AddWithValue("@pEs", _pId);
            cmmd.Parameters.AddWithValue("@pNombre", _pNombre);
            cmmd.Parameters.AddWithValue("@pIdEmpresa",_IdEmpresa);

            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();

            return dt;
        }
        public bool DB_grabar_Elementos(int IdEmpresa,int pAll, int Es, string Nombre,int Pais, int Prov, 
            string Loc, string Direccion)
        {
            string SP;
            SP = "SP_Elementos_ABM";


            MySqlCommand cmmd = new MySqlCommand(SP, Conexion.AbrirConexion());
            cmmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmmd.Parameters.AddWithValue("@pAll", pAll );
            cmmd.Parameters.AddWithValue("@pEs", Es);
            cmmd.Parameters.AddWithValue("@pNombre", Nombre);
            cmmd.Parameters.AddWithValue("@pPais", Pais);
            cmmd.Parameters.AddWithValue("@pProvincia", Prov);
            cmmd.Parameters.AddWithValue("@pLocalidad", Loc);
            cmmd.Parameters.AddWithValue("@pDireccion", Direccion);
            cmmd.Parameters.AddWithValue("@pIdEmpresa", IdEmpresa);
            cmmd.ExecuteNonQuery();

            return true;
        }
        //Corredores
        //Corredores
        //public DataTable DB_Corredores_Traer(int pALL)
        //{
        //    DataTable dt = new DataTable();
        //    string SP;
        //    SP = "SP_Corredores_Traer";

        //    cmmd.Connection = Conexion.AbrirConexion();
        //    cmmd.CommandText = SP;
        //    cmmd.CommandType = CommandType.StoredProcedure;
        //    cmmd.Parameters.AddWithValue("@pAll", pALL);
        //    cmmd.Parameters.AddWithValue("@pId", pId );
        //    cmmd.Parameters.AddWithValue("@pIdEmpresa", _IdEmpresa);

        //    leer = cmmd.ExecuteReader();

        //    dt.Load(leer);
        //    leer.Close();
        //    Conexion.CerrarConexion();
        //    return dt;
        //}
        //public DataTable DB_Corredores_Combo()
        //{
        //    DataTable dt = new DataTable();
        //    cmmd.Connection = Conexion.AbrirConexion();
        //    cmmd.CommandText = "SP_Corredores_Combo";
        //    cmmd.CommandType = CommandType.StoredProcedure;
        //    cmmd.Parameters.AddWithValue("@pIdEmpresa", IdEmpresa);

        //    leer = cmmd.ExecuteReader();

        //    dt.Load(leer);
        //    leer.Close();
        //    Conexion.CerrarConexion();
        //    return dt;
        //}
        //public DataTable DB_Corredores_Grilla_TC(string strStoredProcedure, int idEmpresa)//Transporte Cliente
        //{
        //    DataTable dt = new DataTable();
        //    cmmd.Connection = Conexion.AbrirConexion();
        //    if (xxx == 0)
        //    {
        //        cmmd.CommandText = "SP_ATC_Select";
        //    }
        //    else
        //    {
        //        cmmd.CommandText = "SP_ACC_Select";
        //    }
            
        //    cmmd.CommandType = CommandType.StoredProcedure;
        //    cmmd.Parameters.AddWithValue("@pIdEmpresa", idEmpresa);

        //    leer = cmmd.ExecuteReader();

        //    dt.Load(leer);
        //    leer.Close();
        //    Conexion.CerrarConexion();
        //    return dt;
        //}

        public bool DB_Corredores_Grabar()
        {
            string SP;
            SP = "SP_Corredores_Grabar";
            MySqlCommand cmmd = new MySqlCommand(SP , Conexion.AbrirConexion());
            cmmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmmd.Parameters.AddWithValue("@pAll", pALL);
            cmmd.Parameters.AddWithValue("@pId", pId );
            cmmd.Parameters.AddWithValue("@pOrigen", Origen);
            cmmd.Parameters.AddWithValue("@pDestino", Destino);
            cmmd.Parameters.AddWithValue("@pRetorno", Retorno);
            cmmd.Parameters.AddWithValue("@pOneWay", OneWay);
            cmmd.Parameters.AddWithValue("@pRoundTrip", RoundTrip);
            cmmd.Parameters.AddWithValue("@pTTAT", TTAT);
            cmmd.Parameters.AddWithValue("@pTTAC", TTAC);
            cmmd.Parameters.AddWithValue("@pIndTipo", Tipo);
            cmmd.Parameters.AddWithValue("@pCosto", Costo);
            
            cmmd.Parameters.AddWithValue("@pFecha", Fecha);

            cmmd.Parameters.AddWithValue("@pActivo", Activo);
            cmmd.Parameters.AddWithValue("@pIdEmpresa", IdEmpresa);
            cmmd.Parameters.AddWithValue("@pIdUsuario", IdUsuario);
            cmmd.ExecuteNonQuery();
            return true;
        }
       
    }
}
