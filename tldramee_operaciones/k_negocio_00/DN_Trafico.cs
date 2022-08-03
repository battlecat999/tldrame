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
    public class DN_Trafico
    {
        public DataTable DN_Trafico_Grillas(int intEmpresa,string strStoredProcedure)
        {
            DB_Ejecutar_SP lista = new DB_Ejecutar_SP();
            DataTable dt = new DataTable();
            MySqlParameter[] Parametros = new MySqlParameter[1];
            
            Parametros[0] = new MySqlParameter("pIdEmpresa", intEmpresa);
            dt = lista.DB_Listar_Todo(strStoredProcedure, Parametros);


            return dt;
        }
    }
}
