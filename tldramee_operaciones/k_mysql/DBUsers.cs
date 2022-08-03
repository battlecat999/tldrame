using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.Types;
using MySql.Data.MySqlClient;
using k_loger;



namespace k_mysql
{
    //se cambio a publico
    public class DBUsers
    {
        private clsConn Conexion = new clsConn();
        private MySqlDataReader leer;

        public MySqlDataReader iniciarSesion(string user, string pass)
        {
            try
            {


            MD5 o = new MD5();
            pass = o.GetMd5Hash(pass);
            MySqlCommand cmmd = new MySqlCommand("SP_IniciarSesion", Conexion.AbrirConexion() );
            cmmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmmd.Parameters.AddWithValue("@_userName", user);
            cmmd.Parameters.AddWithValue("@_passName", pass);

            //string sql = "select * from users where userName=?userName AND userPass=?userPass";
            //MySqlCommand cmmd = new MySqlCommand();
            //cmmd.Connection = Conexion.CnnSql();
            //cmmd.CommandText = sql;
            //cmmd.Parameters.AddWithValue("?userName", user);
            //cmmd.Parameters.AddWithValue("?userPass", pass);
            leer = cmmd.ExecuteReader();
            return leer;
            }
            catch (Exception)
            {
               
                return leer;
            }
        }

    }
}
