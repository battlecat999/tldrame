using System;
using System.IO;
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
    
    public class clsConn
    {
        private  MySqlConnection cnn = new MySqlConnection();

        public String Cadena_Conexion()
        {

            String strCadena = "";

            IniFile Lee = new k_mysql.IniFile();

            strCadena = Lee.LeeSetting();

            return strCadena; 

        }

        public MySqlConnection  AbrirConexion()
        {
            IniFile Lee = new k_mysql.IniFile();

            try
            {
                string Conexion_INI = Lee.LeeSetting();
                if (Conexion_INI != string.Empty)
                {
                    if(cnn.State==System.Data.ConnectionState.Closed)
                    {
                        cnn.ConnectionString = Conexion_INI;
                        cnn.Open();
                    }else
                    {
                        cnn.Close();
                        cnn.ConnectionString = Conexion_INI;
                        cnn.Open();
                    }
                    return cnn;
                }else
                {
                    return cnn;
                }
            }
            catch (Exception ex)
            {
                CreateLogFiles Err = new CreateLogFiles ();
                Err.ErrorLog(string.Concat(Directory.GetCurrentDirectory(), "\\Logs\\ErrorLog.txt"), ex.Message);
                return cnn;
            }
        }
        public MySqlTransaction Begin_Trans()
        {
            MySqlTransaction myTrans;
            myTrans=cnn.BeginTransaction();
            return myTrans  ;
        }


        public MySqlConnection CerrarConexion()
        {
            if(cnn.State==System.Data.ConnectionState.Open)
            {
                cnn.Close();
            }
            return cnn;
        }
    }
}
