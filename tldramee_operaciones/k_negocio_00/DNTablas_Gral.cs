using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using k_mysql;
using System.Data;
using k_loger;
using System.IO;
using MySql.Data.MySqlClient;

namespace k_negocio_00
{
    public class DNTablas_Gral
    {
        string _descripcion;
        string _tabla;

        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Tabla { get => _tabla; set => _tabla = value; }
        public int Permiso_Access(int intEmpresa, string strFormulario, int intUsuario)
        {
            DNTablas_Gral lista = new DNTablas_Gral();
            DataTable dt = new DataTable();
            int intReturn;


            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = intEmpresa },
                new MySqlParameter(){ ParameterName="strFormulario", Value = strFormulario },
                new MySqlParameter(){ ParameterName="intUsuario", Value = intUsuario }
            };

            dt = lista.Get_Datos("SP_Permiso_Acceso", parameters);
            intReturn = 0;
            foreach (DataRow dr in dt.Rows)
            {
                intReturn=Convert.ToInt32(dr[0].ToString());
            }

            return intReturn;
        }
        public DataTable Carga_Conceptos_Nominar(int intEmpresa)
        {
            DNTablas_Gral lista = new DNTablas_Gral();

            DataTable dtConceptos = new DataTable();



            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intEmpresa", Value = intEmpresa },
                new MySqlParameter(){ ParameterName="intActivos", Value = 1 },
                new MySqlParameter(){ ParameterName="intConcepto", Value = DBNull.Value }
                //new MySqlParameter(){ ParameterName="intOT", Value = intOT },
                //new MySqlParameter(){ ParameterName="intItem", Value = intItem },
                //new MySqlParameter(){ ParameterName="intTransportista", Value = intTransportista },
                //new MySqlParameter(){ ParameterName="intTractor", Value = intTractor },
                //new MySqlParameter(){ ParameterName="intChasis", Value = intChasis },
                //new MySqlParameter(){ ParameterName="intChofer", Value = intChofer }
            };

            dtConceptos = lista.Get_Datos("SP_Get_Conceptos_a_Nominar", parameters);


            return dtConceptos;
        }
        public DataTable DN_CargarDataTableGral(string strStoredProcedure,int ID,int IdEmpresa)
        {
            DB_Ejecutar_SP lista = new DB_Ejecutar_SP();
            DataTable dt = new DataTable();
            MySqlParameter[] Parametros = new MySqlParameter[2];

            //
            Parametros[0] = new MySqlParameter("pIdEmpresa", IdEmpresa);
            Parametros[1] = new MySqlParameter("ID", ID);

            dt = lista.DB_Listar_Todo(strStoredProcedure, Parametros);
            return dt;
        }

        public DataTable DN_CargarDataTableGral(string strStoredProcedure)
        {
            DB_Ejecutar_SP lista = new DB_Ejecutar_SP();
            DataTable dt = new DataTable();
            //
            dt = lista.DB_Listar_Todo(strStoredProcedure);
            return dt;
        }

        public DataTable Get_Provincias(int p_idPais)
        {
            DBTablas_Gral lista = new DBTablas_Gral();
            DataTable dt = new DataTable();
            dt = lista.ListarProvincias(p_idPais);
            return dt;
        }
        public DataTable Get_Localidades(int p_idProv)
        {
            DBTablas_Gral lista = new DBTablas_Gral();
            DataTable dt = new DataTable();
            dt = lista.ListarLocalidades(p_idProv);
            return dt;
        }
        
        public DataTable Get_Tipo_Chasis()
        {
            DBTablas_Gral lista = new DBTablas_Gral();
            DataTable dt = new DataTable();
            dt = lista.Listar_TipoChasis();
            return dt;
        }
        public DataTable Get_Tipo_Carga()
        {
            DBTablas_Gral lista = new DBTablas_Gral();
            DataTable dt = new DataTable();
            dt = lista.Listar_TipoCarga();
            return dt;
        }
        public DataTable Get_Tipo_Trafico()
        {
            DBTablas_Gral lista = new DBTablas_Gral();
            DataTable dt = new DataTable();
            dt = lista.Listar_TipoTrafico();
            return dt;
        }

        public DataTable Get_Transportistas(string strStored_Procedure, MySqlParameter[] Parametros   )
        {
            DBTablas_Gral lista = new DBTablas_Gral();
            DataTable dt = new DataTable();
            dt = lista.Get_Transportistas(Parametros);
            return dt;
        }

        public DataTable Get_Datos(string strStored_Procedure, MySqlParameter[] Parametros)
        {
            DBTablas_Gral lista = new DBTablas_Gral();
            DataTable dt = new DataTable();
            dt = lista.Get_Datos(strStored_Procedure, Parametros);
            return dt;
        }
        //public MySqlDataReader Get_Datos_dr(string strStored_Procedure, MySqlParameter[] Parametros)
        //{
        //    DBTablas_Gral lista = new DBTablas_Gral();
        //    MySqlDataReader dr;
        //    dr = lista.Get_Datos_dr(strStored_Procedure, Parametros);
        //    return dr;
        //}
        public DataTable Get_Datos(string strStored_Procedure)
        {
            DBTablas_Gral lista = new DBTablas_Gral();
            DataTable dt = new DataTable();
            dt = lista.Get_Datos(strStored_Procedure);
            return dt;
        }


        public DataTable Get_EmpresasSeguros()
        {
            DBTablas_Gral lista = new DBTablas_Gral();
            DataTable dt = new DataTable();
            dt = lista.Listar_EmpresasSeguros();
            return dt;
        }
        public DataTable Get_Estados()
        {
            DBTablas_Gral lista = new DBTablas_Gral();
            DataTable dt = new DataTable();
            dt = lista.Listar_Estados();
            return dt;
        }
        public bool DN_Grabar_Cab_Detalle(string strCabecera, string strDetalle)
        {
            int ID = 0;
            DB_Ejecutar_SP con = new DB_Ejecutar_SP();
            MySqlTransaction trans;
            con.cmmd.Connection=con.Conexion.AbrirConexion();
            trans = con.Conexion.Begin_Trans();
            try
            {

                ID = con.DB_SP_NonQuery_Transaction_TEXT(strCabecera, con.cmmd);
                if (ID==-1)
                {
                    trans.Rollback();
                    con.Conexion.CerrarConexion();
                    return false;
                }

                trans.Commit();
                con.Conexion.CerrarConexion();
                return true;
                //if (ID != 0) {
                //    //paso el Datatable
                //    strDetalle = strDetalle.Replace("reemplazar", ID.ToString());
                //    con.DB_SP_NonQuery_Transaction_TEXT(strDetalle, con.cmmd);


                //    trans.Commit();
                //    con.Conexion.CerrarConexion();
                //    return true;
                //}
                //else
                //{
                //    trans.Rollback();
                //    con.Conexion.CerrarConexion();
                //    return false;
                //}


            }
            catch (Exception ex)
            {

                trans.Rollback();
                con.Conexion.CerrarConexion();

                CreateLogFiles Err = new CreateLogFiles();
                Err.ErrorLog(string.Concat(Directory.GetCurrentDirectory(), "\\Logs\\ErrorLog.txt"), ex.Message);

                return false;
            }
            finally
            {

            }
        }
            //INSERT TAblas Generales (Id y una descripcion)
            public bool DN_Grabar_Tabla_Gral()
            {
                bool ok_Trans;

                DBTablas_Gral objDatos = new DBTablas_Gral();
                objDatos.Tabla = Tabla;
                objDatos.Descripcion = Descripcion;
                ok_Trans = objDatos.DB_Grabar_Tabla_Gral();
                return ok_Trans;
            }
        public bool ServerEncendido()
        {
            clsConn cn = new clsConn();
            if (cn.AbrirConexion().State != ConnectionState.Closed)
                return true;
            else
                return false;
        }
        public int DN_Datos_Parametros(int IntEmpresa,string strCampo)
        {
            DBTablas_Gral lista = new DBTablas_Gral();
            DataTable dt = new DataTable();

            int Tiempo_Espera;
            dt = lista.DB_Datos_Parametros(IntEmpresa, strCampo);

            DataRow row = dt.Rows[0];

            Tiempo_Espera = Convert.ToInt32(row["nombre"]);
            Tiempo_Espera = Tiempo_Espera*1000;
            return Tiempo_Espera;
        }

    }
}
