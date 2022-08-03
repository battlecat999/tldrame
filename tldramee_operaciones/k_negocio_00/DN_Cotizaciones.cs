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
   public class DN_Cotizaciones
    {
        string nueva_cotizacion;

        public string Nueva_cotizacion { get => nueva_cotizacion; set => nueva_cotizacion = value; }

        public DataTable DN_Traer_Cotizaciones(string SP, string  pCotizacion, int IdEmpresa)
        {
            DB_Ejecutar_SP lista = new DB_Ejecutar_SP();
            DataTable dt = new DataTable();
            MySqlParameter[] Parametros = new MySqlParameter[2];

            //
            Parametros[0] = new MySqlParameter("pCotizacion", pCotizacion);
            Parametros[1] = new MySqlParameter("pIdEmpresa", IdEmpresa);
           

            dt = lista.DB_Listar_Todo(SP, Parametros);

            return dt;
            //dt = lista.DB_Listar_Todo(strStoredProcedures, Parametros);
        }
        public string DN_Traer_Nueva_Cotizacion(string SP, int IdEmpresa)
        {
            MySqlParameter[] Parametros = new MySqlParameter[1];
            DB_Ejecutar_SP lista = new DB_Ejecutar_SP();
            DataTable dt = new DataTable();
            Parametros[0] = new MySqlParameter("pEmpresa",IdEmpresa );
            dt = lista.DB_Listar_Todo(SP, Parametros);
            nueva_cotizacion = dt.Rows[0][0].ToString();
            return nueva_cotizacion;

        }
        //INSERT TAblas Generales (Id y una descripcion)
        //public bool DN_Grabar_Tabla_Gral()
        //{
        //    bool ok_Trans;

        //    DBTablas_Gral objDatos = new DBTablas_Gral();
        //    objDatos.Tabla = Tabla;
        //    objDatos.Descripcion = Descripcion;
        //    ok_Trans = objDatos.DB_Grabar_Tabla_Gral();
        //    return ok_Trans;
        //}



    }
}
