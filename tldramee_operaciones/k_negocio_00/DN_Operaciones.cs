using k_mysql;

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_negocio_00
{
    public class DN_Operaciones
    {
        int intEmpresa;
        int intOT;
        int intItemOT;
        int intUsuario;
        string strMotivo;
        private decimal decCostoFF;
        private decimal decVentaFF;
        public int IntEmpresa { get => intEmpresa; set => intEmpresa = value; }
        public int IntOT { get => intOT; set => intOT = value; }
        public int IntItemOT { get => intItemOT; set => intItemOT = value; }
        public int IntUsuario { get => intUsuario; set => intUsuario = value; }
        public string StrMotivo { get => strMotivo; set => strMotivo = value; }
        public decimal DecCostoFF { get => decCostoFF; set => decCostoFF = value; }
        public decimal DecVentaFF { get => decVentaFF; set => decVentaFF = value; }


        public void Alta_Falso_Flete()
        {
            clsConn cnMarco = new clsConn();

            string strConnection_String;

            strConnection_String = cnMarco.Cadena_Conexion();

            MySqlConnection cnnConnection = new MySqlConnection(strConnection_String);
            cnnConnection.Open();

            MySqlCommand cmdCommand = cnnConnection.CreateCommand();
            MySqlTransaction trsTransaccion;

            trsTransaccion = cnnConnection.BeginTransaction();

            cmdCommand.Connection = cnnConnection;
            cmdCommand.Transaction = trsTransaccion;
            cmdCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                cmdCommand.CommandText = "SP_OT_Item_Falso_Flete";

                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intNumero_OT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intNumero_Item", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intUsuario", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("strMotivo", MySqlDbType.String);
                cmdCommand.Parameters.Add("decCostoFF", MySqlDbType.Decimal);
                cmdCommand.Parameters.Add("decVentaFF", MySqlDbType.Decimal);

                cmdCommand.Parameters["intEmpresa"].Value = IntEmpresa;
                cmdCommand.Parameters["intNumero_OT"].Value = IntOT;
                cmdCommand.Parameters["intNumero_Item"].Value = IntItemOT;
                cmdCommand.Parameters["intUsuario"].Value = IntUsuario;
                cmdCommand.Parameters["strMotivo"].Value = StrMotivo;
                cmdCommand.Parameters["decCostoFF"].Value = DecCostoFF;
                cmdCommand.Parameters["decVentaFF"].Value = DecVentaFF;

                cmdCommand.ExecuteNonQuery();
                trsTransaccion.Commit();

            }
            catch (Exception e)
            {
                try
                {
                    Console.WriteLine("Error" + e.GetType());
                    trsTransaccion.Rollback();
                }
                catch (MySqlException ex)
                {
                    if (trsTransaccion.Connection != null)
                    {
                        Console.WriteLine("Error" + ex.GetType());
                    }
                }

                //Console.WriteLine("Error" + ex.GetType());
            }
            finally
            {
                cnnConnection.Close();
            }


        }
        public void Baja_OT()
        {
            clsConn cnMarco = new clsConn();

            string strConnection_String;

            strConnection_String = cnMarco.Cadena_Conexion();

            MySqlConnection cnnConnection = new MySqlConnection(strConnection_String);
            cnnConnection.Open();

            MySqlCommand cmdCommand = cnnConnection.CreateCommand();
            MySqlTransaction trsTransaccion;

            trsTransaccion = cnnConnection.BeginTransaction();

            cmdCommand.Connection = cnnConnection;
            cmdCommand.Transaction = trsTransaccion;
            cmdCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                cmdCommand.CommandText = "SP_OT_Baja";

                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intOT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intUsuario", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("strMotivo", MySqlDbType.String);

                cmdCommand.Parameters["intEmpresa"].Value = IntEmpresa;
                cmdCommand.Parameters["intOT"].Value = IntOT;
                cmdCommand.Parameters["intUsuario"].Value = IntUsuario;
                cmdCommand.Parameters["strMotivo"].Value = StrMotivo;

                cmdCommand.ExecuteNonQuery();
                trsTransaccion.Commit();

            }
            catch (Exception e)
            {
                try
                {
                    Console.WriteLine("Error" + e.GetType());
                    trsTransaccion.Rollback();
                }
                catch (MySqlException ex)
                {
                    if (trsTransaccion.Connection != null)
                    {
                        Console.WriteLine("Error" + ex.GetType());
                    }
                }

                //Console.WriteLine("Error" + ex.GetType());
            }
            finally
            {
                cnnConnection.Close();
            }
        }

        public  void Baja_OT_Item()
        {
            clsConn cnMarco = new clsConn();

            string strConnection_String;

            strConnection_String = cnMarco.Cadena_Conexion();

            MySqlConnection cnnConnection = new MySqlConnection(strConnection_String);
            cnnConnection.Open();

            MySqlCommand cmdCommand = cnnConnection.CreateCommand();
            MySqlTransaction trsTransaccion;

            trsTransaccion = cnnConnection.BeginTransaction();

            cmdCommand.Connection = cnnConnection;
            cmdCommand.Transaction = trsTransaccion;
            cmdCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                cmdCommand.CommandText = "SP_OT_Item_Baja";

                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intNumero_OT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intNumero_Item", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intUsuario", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("strMotivo", MySqlDbType.String);

                cmdCommand.Parameters["intEmpresa"].Value = IntEmpresa;
                cmdCommand.Parameters["intNumero_OT"].Value = IntOT ;
                cmdCommand.Parameters["intNumero_Item"].Value = IntItemOT ;
                cmdCommand.Parameters["intUsuario"].Value = IntUsuario;
                cmdCommand.Parameters["strMotivo"].Value = StrMotivo;

                cmdCommand.ExecuteNonQuery();
                trsTransaccion.Commit();

            }
            catch (Exception e)
            {
                try
                {
                    Console.WriteLine("Error" + e.GetType());
                    trsTransaccion.Rollback();
                }
                catch (MySqlException ex)
                {
                    if (trsTransaccion.Connection != null)
                    {
                        Console.WriteLine("Error" + ex.GetType());
                    }
                }

                //Console.WriteLine("Error" + ex.GetType());
            }
            finally
            {
                cnnConnection.Close();
            }


        }
        public void liberarCamiones(int intEmpresa, int intTransportista, int intTractor, int intChasis, int intChofer, int intEsOW, int intConcepto)
        {
            clsConn cnMarco = new clsConn();
            String strConnection_String = "";

            strConnection_String = cnMarco.Cadena_Conexion();
            MySqlConnection cnnConnection = new MySqlConnection(strConnection_String);
            cnnConnection.Open();

            MySqlCommand cmdCommand = cnnConnection.CreateCommand();
            MySqlTransaction trsTransaccion;
            trsTransaccion = cnnConnection.BeginTransaction();

            cmdCommand.Connection = cnnConnection;
            cmdCommand.Transaction = trsTransaccion;
            cmdCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                cmdCommand.CommandText = "SP_OT_Item_Libera_Nominacion";
                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intTransportista", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intTractor", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intChasis", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intChofer", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intEsOW", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intConcepto", MySqlDbType.Int32);

                cmdCommand.Parameters["intEmpresa"].Value = intEmpresa;
                cmdCommand.Parameters["intTransportista"].Value = intTransportista;
                cmdCommand.Parameters["intTractor"].Value = intTractor;
                cmdCommand.Parameters["intChasis"].Value = intChasis;
                cmdCommand.Parameters["intChofer"].Value = intChofer;
                cmdCommand.Parameters["intEsOW"].Value = intEsOW;
                cmdCommand.Parameters["intConcepto"].Value = intConcepto;

                cmdCommand.ExecuteNonQuery();
                trsTransaccion.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    trsTransaccion.Rollback();
                }
                catch (MySqlException ex)
                {
                    if (trsTransaccion.Connection != null)
                    {
                        Console.WriteLine("Error" + ex.GetType());
                    }
                }

                Console.WriteLine("Error" + e.GetType());
            }
            finally
            {
                cnnConnection.Close();
            }
        }

      

    }
}
