using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using k_negocio_00;
using k_mysql;
using System.Windows.Forms;
using System.Data;

namespace k_presentacion_00
{
    public class clsAlta_Anticipos
    {
        public Boolean Grabar_Anticipos(Boolean boolGrabaCheque,DataGridView grdAnticipos)
        {
            int intForma_Pago = 0;
            Decimal decImporte = 0;
            DateTime datFecha_Cheque;
            String strNro_Cheque = string.Empty;
            String strObservaciones = string.Empty;
            Decimal decLitros;
            Decimal decPrecio_Litro;

            int intItem = 0;
            int intContador = 0;

            DateTime datFecha;

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

                cmdCommand.CommandText = "SP_Anticipos_Insert";

                cmdCommand.Parameters.Add("intEmpresa", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intOT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intItem_OT", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intItem_Anticipo", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intForma_Pago", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("datFecha", MySqlDbType.DateTime);
                cmdCommand.Parameters.Add("decImporte", MySqlDbType.Decimal);
                cmdCommand.Parameters.Add("decLitros", MySqlDbType.Decimal);
                cmdCommand.Parameters.Add("decPrecio_Litro", MySqlDbType.Decimal);
                cmdCommand.Parameters.Add("strObservaciones", MySqlDbType.String);
                cmdCommand.Parameters.Add("strContenedor", MySqlDbType.String);
                cmdCommand.Parameters.Add("intProveedor", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("intMoro", MySqlDbType.Int32);
                cmdCommand.Parameters.Add("datFecha_Cheque", MySqlDbType.DateTime);
                cmdCommand.Parameters.Add("strNro_Cheque", MySqlDbType.String);

                //cmdCommand.Parameters["intEmpresa"].Value = _Empresa;
                //cmdCommand.Parameters["intOT"].Value = _OT;
                //cmdCommand.Parameters["intItem_OT"].Value = _Item;

                //cmdCommand.Parameters["strContenedor"].Value = _Contenedor;
                //cmdCommand.Parameters["intProveedor"].Value = _intTransportista;
                //cmdCommand.Parameters["intMoro"].Value = Convert.ToInt32(this.lblEsMoro.Text);

                intContador = 0;

                foreach (DataGridViewRow dgvRenglon in grdAnticipos.Rows)
                {

                    DataGridViewTextBoxCell Estado;

                    intContador++;

                    intItem++;

                    if (intContador < grdAnticipos.Rows.Count)
                    {

                        Estado = dgvRenglon.Cells["Estado"] as DataGridViewTextBoxCell;

                        if (Estado.Value == null)
                        {
                            //grdAnticipos.CellValueChanged -= new DataGridViewCellEventHandler(GrdAnticipos_CellValueChanged);

                            Estado.Value = "";

                            //grdAnticipos.CellValueChanged += new DataGridViewCellEventHandler(GrdAnticipos_CellValueChanged);
                        }

                        if (Estado.Value.ToString() != string.Empty && Estado.Value.ToString() == "1")
                        {

                            //intItem++;

                            intForma_Pago = Int32.Parse(dgvRenglon.Cells["Condicion_Pago"].Value.ToString());
                            datFecha = DateTime.Parse(dgvRenglon.Cells["Fecha"].Value.ToString());
                            decImporte = Decimal.Parse(dgvRenglon.Cells["Importe"].Value.ToString());

                            decLitros = Decimal.Parse(dgvRenglon.Cells["Litros"].Value.ToString());
                            decPrecio_Litro = Decimal.Parse(dgvRenglon.Cells["Precio_Por_Litro"].Value.ToString());
                            datFecha_Cheque = DateTime.Parse(dgvRenglon.Cells["Fecha_Cheque"].Value.ToString());
                            strNro_Cheque = dgvRenglon.Cells["Nro_Cheque"].Value.ToString();


                            strObservaciones = dgvRenglon.Cells["Observaciones"].Value.ToString();


                            cmdCommand.Parameters["intItem_Anticipo"].Value = intItem;
                            cmdCommand.Parameters["intForma_Pago"].Value = intForma_Pago;
                            cmdCommand.Parameters["datFecha"].Value = datFecha;
                            cmdCommand.Parameters["decImporte"].Value = decImporte;
                            cmdCommand.Parameters["decLitros"].Value = 0;
                            cmdCommand.Parameters["decPrecio_Litro"].Value = 0;
                            cmdCommand.Parameters["datFecha"].Value = datFecha;
                            cmdCommand.Parameters["strObservaciones"].Value = strObservaciones;


                            //AGREGAR MARCA MORO ==>> VIAJE DIFERENCIADO
                            //SI LA OT ESTA MARCADA COMO DIFERENCIADA, NO SE PUEDE USAR UNA EMPRESA QUE NO HAGA VIAJES EN NEGRO.

                            //TENGO QUE PERMITIR ABM DE PROVEEDORES Y MARCARLOS COMO **VIAJES DIFERENCIADOS**

                            //if (Convert.ToInt32(this.lblEsMoro.Text)==1 && intForma_Pago!=1)
                            //{
                            //    MessageBox.Show("La forma de pago es incorrecta!. Consultar con Maxi");
                            //}

                            cmdCommand.ExecuteNonQuery();

                        }

                    }

                }

                trsTransaccion.Commit();

                //MessageBoxButtons button = MessageBoxButtons.OK;
                //MessageBoxIcon icon = MessageBoxIcon.Information;

                //MessageBox.Show("Proceso finalizado ", "Aviso", button, icon);
                return true;

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
                        return false;
                    }
                }

                Console.WriteLine("Error" + e.GetType());
                return false;
            }
            finally
            {
                cnnConnection.Close();

            }
        }
    }
}
