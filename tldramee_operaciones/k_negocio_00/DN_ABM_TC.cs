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
    public class DN_ABM_TC
    {
        private int _pAll;
        //Asociacion Transportes_XXXXX
        private int _Tabla;
        private int _Id;
        private string _Patente;
        private int _Marca;
        private int _Modelo;
        private int _Anio;
        private string _NroMotor;
        private string _NroChasis;
        private int _Tara;
        private string _NroPoliza;
        private int  _Seguro;
        private string _FecVenSeguro;
        private string _FecVecVTV;
        private int _CantEjes;
        private string _GPS_Clientes;
        private string _GPS_Link;
        private string _GPS_Us;
        private string _GPS_PS;
        private string _Observaciones;
        //
        private int _TipoChasis;
        private int _TipoCarga;
        private int _TipoTrafico;
        private int _Generador;
        //
        private int _Activo;
        private int _Colores;

        private bool _va;
        private string _nameAux;
        private int IdEmpresa;
        private int IdTransportista;
        private int IdUsuario;

        /// <summary>
        /// Tractores
        /// </summary>
        /// <returns></returns>

        //Funciones Traer Todo o Uno
        public DataTable Tractor_GET()
        {

            DB_ABM_TCC lista = new DB_ABM_TCC();
            DataTable dt = new DataTable();
            dt = lista.Traer_Tractor(pAll,Id);
            return dt;
        }
        public void Tractor_GET_id()
        {
            DB_ABM_TCC lista = new DB_ABM_TCC();
            DataTable dt = new DataTable();
            dt = lista.Traer_Tractor(pAll, Id);

            DataRow row = dt.Rows[0];
            Marca = Convert.ToInt32(row["Marca"]);
            Modelo = Convert.ToInt32(row["Modelo"]);
            Anio = Convert.ToInt32(row["Anio"]);
            NroMotor  = row["NroMotor"].ToString();
            NroChasis = row["NroChasis"].ToString();
            Tara = Convert.ToInt32(row["Tara"]);
            Seguro = Convert.ToInt32(row["Seguro"]);
            NroPoliza = row["NroPoliza"].ToString();
            Va = false;
            FecVenSeguro = Convert.ToDateTime(row["FecVenSeguro"]).ToString("dd/MM/yyyy");
            FecVecVTV = Convert.ToDateTime(row["FecVenVTV"]).ToString("dd/MM/yyyy");
            CantEjes = Convert.ToInt32(row["CantEjes"]);

            GPS_Clientes  = row["GPS_Clientes"].ToString();

            GPS_Link  = row["GPS_Link"].ToString();
            GPS_Us  = row["GPS_Us"].ToString();
            GPS_PS  = row["GPS_PS"].ToString();

            Observaciones = row["Observaciones"].ToString();
            Activo = Convert.ToInt32(row["Activo"]);
            Colores = Convert.ToInt32(row["codigo_color"]);
            idTransportista = Convert.ToInt32(row["Transportista"]);

        }

        //Funciones para Insertar o Actualizar
        public bool Tractor_ACTUALIZAR()
        {
            bool ok_Tra;
            DB_ABM_TCC objDato = new DB_ABM_TCC();
            ok_Tra = objDato.ABM_Tractor(pAll, Id, Patente, Marca, Modelo, Anio, NroMotor,
                NroChasis, Tara, NroPoliza, Seguro, FecVenSeguro, FecVecVTV, CantEjes,  GPS_Clientes,
                GPS_Link, GPS_Us, GPS_PS, Observaciones, Activo,IdEmpresa ,idTransportista,idUsuario,Colores );
            return ok_Tra;
        }
        public int DN_insertar_Marca(string strStoredProcedures)
        {
            int ok_Transaccion;

            DB_Ejecutar_SP objDato = new DB_Ejecutar_SP();


            MySqlParameter[] Parametros = new MySqlParameter[1];

            Parametros[0] = new MySqlParameter("@pNombre", NameAux);


            ok_Transaccion = objDato.DB_SP_NonQuery(strStoredProcedures, Parametros);
            return ok_Transaccion;
        }
        public int DN_insertar_Marca_Modelo(string strStoredProcedures)
        {
            int ok_Transaccion;

            DB_Ejecutar_SP objDato = new DB_Ejecutar_SP();

            MySqlParameter[] Parametros = new MySqlParameter[2];

            Parametros[0] = new MySqlParameter("@pIdMarca", Id );
            Parametros[1] = new MySqlParameter("@pNombre", NameAux);


            ok_Transaccion = objDato.DB_SP_NonQuery(strStoredProcedures, Parametros);
            return ok_Transaccion;
        }
        /// <summary>
        /// Chasis
        /// </summary>
        //Funciones Traer Todo o Uno
        public DataTable Chasis_GET()
        {

            DB_ABM_TCC lista = new DB_ABM_TCC();
            DataTable dt = new DataTable();
            dt = lista.Traer_Chasis (pAll, Id);
            return dt;
        }
        public void Chasis_GET_id()
        {
            DB_ABM_TCC lista = new DB_ABM_TCC();
            DataTable dt = new DataTable();
            dt = lista.Traer_Chasis(pAll, Id);

            DataRow row = dt.Rows[0];
            Marca = Convert.ToInt32(row["Marca"]);
            Modelo = Convert.ToInt32(row["Modelo"]);
            Anio = Convert.ToInt32(row["Anio"]);
            TipoChasis = Convert.ToInt32(row["TipoChasis"]);
            NroChasis = row["NroChasis"].ToString();
            Tara = Convert.ToInt32(row["Tara"]);
            Seguro = Convert.ToInt32(row["Seguro"]);
            NroPoliza = row["NroPoliza"].ToString();
            Va = false;
            FecVenSeguro = Convert.ToDateTime(row["FecVenSeguro"]).ToString("dd/MM/yyyy");
            FecVecVTV = Convert.ToDateTime(row["FecVenVTV"]).ToString("dd/MM/yyyy");
            CantEjes = Convert.ToInt32 (row["CantEjes"]);
            Generador = Convert.ToInt32(row["Generador"]);

            TipoTrafico = Convert.ToInt32(row["TipoTrafico"]);
            TipoCarga = Convert.ToInt32(row["TipoCarga"]);
            Observaciones = row["Observaciones"].ToString();
            Activo = Convert.ToInt32(row["Activo"]);
            Colores = Convert.ToInt32(row["codigo_color"]);
            idTransportista = Convert.ToInt32(row["Transportista"]);
        }

        //Funciones para Insertar o Actualizar
        public bool Chasis_ACTUALIZAR()
        {
            bool ok_Tra;
            DB_ABM_TCC objDato = new DB_ABM_TCC();
            ok_Tra = objDato.ABM_Chasis(pAll, Id, Patente, Marca, Modelo, Anio, TipoChasis,
                NroChasis, Tara, NroPoliza , Seguro, FecVenSeguro, FecVecVTV,CantEjes,TipoCarga,TipoTrafico,Generador,Observaciones  
                , Activo, IdEmpresa, idTransportista, idUsuario,Colores);
            return ok_Tra;
        }
        public DataTable Listar_Marcas()
        {
            DB_ABM_TCC lista = new DB_ABM_TCC();
            DataTable dt = new DataTable();
            dt = lista.Listar_Tipo_Marcas();
            return dt;
        }
        public DataTable Listar_Colores()
        {
            DB_ABM_TCC lista = new DB_ABM_TCC();
            DataTable dt = new DataTable();
            dt = lista.Listar_Tipo_Colores();
            return dt;
        }
        public DataTable Listar_Modelos()
        {
            DB_ABM_TCC lista = new DB_ABM_TCC();
            DataTable dt = new DataTable();
            
            dt = lista.Listar_Tipo_Modelos (Id);
            return dt;
        }
        public int Tabla
        {
            get
            {
                return _Tabla;
            }

            set
            {
                _Tabla = value;
            }
        }

        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }

        public string Patente
        {
            get
            {
                return _Patente;
            }

            set
            {
                _Patente = value;
            }
        }

        public int Marca
        {
            get
            {
                return _Marca;
            }

            set
            {
                _Marca = value;
            }
        }

        public int Modelo
        {
            get
            {
                return _Modelo;
            }

            set
            {
                _Modelo = value;
            }
        }

        public int Anio
        {
            get
            {
                return _Anio;
            }

            set
            {
                _Anio = value;
            }
        }

        public string NroMotor
        {
            get
            {
                return _NroMotor;
            }

            set
            {
                _NroMotor = value;
            }
        }

        public string NroChasis
        {
            get
            {
                return _NroChasis;
            }

            set
            {
                _NroChasis = value;
            }
        }

        public int Tara
        {
            get
            {
                return _Tara;
            }

            set
            {
                _Tara = value;
            }
        }

        public string NroPoliza
        {
            get
            {
                return _NroPoliza;
            }

            set
            {
                _NroPoliza = value;
            }
        }

        public int Seguro
        {
            get
            {
                return _Seguro;
            }

            set
            {
                _Seguro = value;
            }
        }

        public string FecVenSeguro
        {
            get
            {
                return _FecVenSeguro;
            }

            set
            {
                if (Va == true)
                {
                    DateTime mifecha;
                    
                    mifecha = Convert.ToDateTime(value);
                    _FecVenSeguro = mifecha.ToString("yyyy-MM-dd");
                }
                else
                {
                    _FecVenSeguro = value;
                }
            }
        }

        public string FecVecVTV
        {
            get
            {
                return _FecVecVTV;
            }

            set
            {
                if (Va == true)
                {
                    DateTime mifecha;
                    mifecha = Convert.ToDateTime(value);
                    _FecVecVTV = mifecha.ToString("yyyy-MM-dd");
                }
                else
                {
                    _FecVecVTV = value;
                }
            }
        }

        public string GPS_Clientes
        {
            get
            {
                return _GPS_Clientes;
            }

            set
            {
                _GPS_Clientes = value;
            }
        }

        public string GPS_Link
        {
            get
            {
                return _GPS_Link;
            }

            set
            {
                _GPS_Link = value;
            }
        }

        public string GPS_Us
        {
            get
            {
                return _GPS_Us;
            }

            set
            {
                _GPS_Us = value;
            }
        }

        public string GPS_PS
        {
            get
            {
                return _GPS_PS;
            }

            set
            {
                _GPS_PS = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return _Observaciones;
            }

            set
            {
                _Observaciones = value;
            }
        }

        public int TipoChasis
        {
            get
            {
                return _TipoChasis;
            }

            set
            {
                _TipoChasis = value;
            }
        }

        public int TipoCarga
        {
            get
            {
                return _TipoCarga;
            }

            set
            {
                _TipoCarga = value;
            }
        }

        public int TipoTrafico
        {
            get
            {
                return _TipoTrafico;
            }

            set
            {
                _TipoTrafico = value;
            }
        }

        public int Generador
        {
            get
            {
                return _Generador;
            }

            set
            {
                _Generador = value;
            }
        }
        public int CantEjes
        {
            get
            {
                return _CantEjes;
            }

            set
            {
                _CantEjes = value;
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
        public int Colores
        {
            get
            {
                return _Colores;
            }

            set
            {
                _Colores = value;
            }
        }

        public int pAll
        {
            get
            {
                return _pAll;
            }

            set
            {
                _pAll = value;
            }
        }

        public bool Va
        {
            get
            {
                return _va;
            }

            set
            {
                _va = value;
            }
        }

        public string NameAux { get => _nameAux; set => _nameAux = value; }
        public int idEmpresa { get => IdEmpresa; set => IdEmpresa = value; }
        public int idTransportista { get => IdTransportista; set => IdTransportista = value; }
        public int idUsuario { get => IdUsuario; set => IdUsuario = value; }
    }
}
