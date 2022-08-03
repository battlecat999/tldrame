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
using System.IO;

namespace k_mysql
{
   public class DB_Ejecutar_SP
    {
        public clsConn Conexion = new clsConn();
     
        public  MySqlCommand cmmd = new MySqlCommand();
        public MySqlDataReader leer;
        //private MySqlDataReader leer;
        public DataTable DB_Listar_Transaction(string strStoredProcedure, MySqlParameter[] Parametros, MySqlCommand cmmd)
        { 

            DataTable dt = new DataTable();
            cmmd.CommandText = strStoredProcedure;

            foreach (MySqlParameter Param in Parametros)
            {
                cmmd.Parameters.Add(Param);
            }

            cmmd.CommandType = CommandType.StoredProcedure;
            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();

            return dt;
        }

        public int DB_SP_Escalar_Transaction_TEXT(string strStoredProcedure, MySqlCommand cmmd)
        {
            Int32  ID = 0;
            try
            {
                cmmd.CommandText = strStoredProcedure;
                cmmd.CommandType = System.Data.CommandType.Text ;
                //foreach (MySqlParameter Param in Parametros)
                //{
                //    if (Param != null)
                //    {
                //        cmmd.Parameters.Add(Param);
                //    }
                //}
                ID = Convert.ToInt32(cmmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                CreateLogFiles Err = new CreateLogFiles();
                Err.ErrorLog(string.Concat(Directory.GetCurrentDirectory(), "\\Logs\\ErrorLog.txt"), ex.Message);
                return 0;
            }
            finally
            {

            }
            return ID;
        }
        public int DB_SP_NonQuery_Transaction_TEXT(string strStoredProcedure,MySqlCommand cmmd)
        {
            Int32 ID = 0;
            try
            {
                cmmd.CommandText = strStoredProcedure;
                cmmd.CommandType = System.Data.CommandType.Text ;

                ID = cmmd.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                CreateLogFiles Err = new CreateLogFiles();
                Err.ErrorLog(string.Concat(Directory.GetCurrentDirectory(), "\\Logs\\ErrorLog.txt"), ex.Message);
                return -1;
            }
            finally
            {
                
            }
            return ID;
        }


        public int DB_SP_NonQuery(string strStoredProcedure, MySqlParameter[] Parametros)
        {
            int ID = 0;
            MySqlCommand cmmd = new MySqlCommand();

            try
            {
                
                
                
                cmmd.Connection = Conexion.AbrirConexion();
                cmmd.CommandText = strStoredProcedure;
                cmmd.CommandType = System.Data.CommandType.StoredProcedure;
                foreach(MySqlParameter Param in Parametros)
                {
                    if (Param != null)
                    {
                        cmmd.Parameters.Add(Param);
                    }
                }
                ID = cmmd.ExecuteNonQuery();

            } 
            catch (Exception ex)
            {
                CreateLogFiles Err = new CreateLogFiles();
                Err.ErrorLog(string.Concat(Directory.GetCurrentDirectory(), "\\Logs\\ErrorLog.txt"), ex.Message);
                return 0;

            }
            finally
            {
                
            }
                return ID;
        }

        #region Listar_Todo_Con_Argumentos

        public DataTable DB_Listar_Todo(string strStoredProcedure, MySqlParameter[] Parametros)
        {
            DataTable dt = new DataTable();
            try
            {

           
            
            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = strStoredProcedure;

            foreach (MySqlParameter Param in Parametros)
            {
                if (Param != null)
                {
                    cmmd.Parameters.Add(Param);
                }
            }

            cmmd.CommandType = CommandType.StoredProcedure;
            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            }

            catch (Exception ex)
            {
                CreateLogFiles Err = new CreateLogFiles();
                Err.ErrorLog(string.Concat(Directory.GetCurrentDirectory(), "\\Logs\\ErrorLog.txt"), ex.Message);
                return dt ;

            }
            return dt;
        }

        public DataTable DB_Listar_Todo(string strStoredProcedure)
        {
            DataTable dt = new DataTable();
            cmmd.Connection = Conexion.AbrirConexion();
            cmmd.CommandText = strStoredProcedure;
            cmmd.CommandType = CommandType.StoredProcedure;
            leer = cmmd.ExecuteReader();
            dt.Load(leer);
            leer.Close();
            Conexion.CerrarConexion();
            return dt;
        }
        #endregion
        #region Recuperar_Datos

        #endregion

    }
}
