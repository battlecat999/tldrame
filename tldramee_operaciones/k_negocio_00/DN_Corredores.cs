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
    public class DN_Corredores
    {
        private int _IdEmpresa;
        private int _IdUsuario;

        private int _pAll;
        private int  _Id;
        private string _pNombre;
        private int pais;
        private int provincia;
        private string localidad;
        private string direccion;
        //
        private string _Origen;
        private string _Destino;
        private string _Retorno;
        private double _oneWay;
        private double _roundTrip;
        private double _TTAT;
        private double _TTAC;
        
        private int _Tipo;
        private double _Costo;
        private string _Fecha;
        private int _Activo;

        private bool _va;
        //
        private int _IdCorredor;
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

        public int Pais
        {
            get
            {
                return pais;
            }

            set
            {
                pais = value;
            }
        }

        public int Provincia
        {
            get
            {
                return provincia;
            }

            set
            {
                provincia = value;
            }
        }

        public string Localidad
        {
            get
            {
                return localidad;
            }

            set
            {
                localidad = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public string pNombre
        {
            get
            {
                return _pNombre;
            }

            set
            {
                _pNombre = value;
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

        public double OneWay
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
                if (va == true)
                {
                    DateTime mifecha;

                    mifecha = Convert.ToDateTime(value);
                    _Fecha = mifecha.ToString("yyyy-MM-dd");
                }
                else
                {
                    _Fecha = value;
                }
            }
        }

        public bool va
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

        public int IdCorredor { get => _IdCorredor; set => _IdCorredor = value; }
        public int IdEmpresa { get => _IdEmpresa; set => _IdEmpresa = value; }
        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }

        public DataTable Elementos_GET()
        {
            DB_Corredores lista = new DB_Corredores();
            DataTable dt = new DataTable();

                dt = lista.Traer_Elementos(pAll, Id, pNombre, IdEmpresa);

                if (dt.Rows.Count != 0)
                {
                    if (pAll != 0)
                    {
                        DataRow row = dt.Rows[0];
                        Pais = Convert.ToInt32(row["idPais"]);
                        Provincia = Convert.ToInt32(row["idProvincia"]);
                        Localidad = row["idLocalidad"].ToString();
                        Direccion = row["direccion"].ToString();
                    }
                }

            return dt;

            
        }

        public bool grabar_Elementos(bool IsNew)
        {
            bool ok_Transaccion;

            DB_Corredores objDato = new DB_Corredores ();

            ok_Transaccion = objDato.DB_grabar_Elementos(IdEmpresa, pAll,Id,pNombre ,Pais,Provincia,Localidad,Direccion  );
            
            return ok_Transaccion;
        }
        ///////////
        public DataTable Corredores_GET(string strStoredProcedure, int ID, int IdEmpresa)
        {
            DB_Ejecutar_SP lista = new DB_Ejecutar_SP();
            DataTable dt = new DataTable();
            MySqlParameter[] Parametros = new MySqlParameter[2];

            //

            Parametros[0] = new MySqlParameter("pIdEmpresa", IdEmpresa);
            //if (ID != 0)
            //{
                Parametros[1] = new MySqlParameter("ID", ID);
            //}
            

            dt = lista.DB_Listar_Todo(strStoredProcedure,Parametros);


        return dt;
    }
    public bool Corredores_Grabar()
        {
            bool ok_Trans;

            DB_Corredores objDatos = new DB_Corredores();

            objDatos.pALL = pAll;
            objDatos.pId = Id;
            objDatos.Origen = Origen;
            objDatos.Destino = Destino;
            objDatos.Retorno = Retorno;
            objDatos.OneWay = OneWay;
            objDatos.RoundTrip = RoundTrip;
            objDatos.TTAT = TTAT;
            objDatos.TTAC = TTAC;
            objDatos.Tipo = Tipo;
            objDatos.Costo = Costo;

            objDatos.Fecha = Fecha;
            objDatos.Activo = Activo;
            objDatos.IdEmpresa = IdEmpresa;
            objDatos.IdUsuario = IdUsuario;


            ok_Trans = objDatos.DB_Corredores_Grabar();
            return ok_Trans;
        }
        public int DN_asoc_Cliente_Transporte_Corredor(string strStoredProcedures)
        {

      
           int ok_Transaccion;

            DB_Ejecutar_SP objDato = new DB_Ejecutar_SP();


            MySqlParameter[] Parametros = new MySqlParameter[7];

            Parametros[0] = new MySqlParameter("@pBaja", pAll);
            Parametros[1] = new MySqlParameter("@pIdEmpresa", IdEmpresa);
            Parametros[2] = new MySqlParameter("@pId", Id);//Paso el Cliente/Transportista
            Parametros[3] = new MySqlParameter("@pIdCorredor", IdCorredor);
            Parametros[4] = new MySqlParameter("@pCosto", Costo);
            Parametros[5] = new MySqlParameter("@pIdUsuario", IdUsuario);//
            Parametros[6] = new MySqlParameter("@datFechaAlta", MySqlDbType.DateTime);
            Parametros[6].Value = Fecha;

            ok_Transaccion = objDato.DB_SP_NonQuery(strStoredProcedures, Parametros);
            return ok_Transaccion;

        }


    }
}
