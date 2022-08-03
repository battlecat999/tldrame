using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using k_mysql;
using System.Data;
using MySql.Data.MySqlClient;

namespace k_negocio_00
{
    public class DN_Eventos
    {
        private int pId;
        private string pDescripcion;
        private string pDetalle;
        private int pActivo;
        //
        private int pConcepto;
        
        public int PId { get => pId; set => pId = value; }
        public string PDescripcion { get => pDescripcion; set => pDescripcion = value; }
        public string PDetalle { get => pDetalle; set => pDetalle = value; }
        public int PActivo { get => pActivo; set => pActivo = value; }
        public int PConcepto { get => pConcepto; set => pConcepto = value; }

        public void Traer_Evento_Por_ID()
        {
            DB_Ejecutar_SP lista = new DB_Ejecutar_SP();
            DataTable dt = new DataTable();
            MySqlParameter[] Parametros = new MySqlParameter[1];
            Parametros[0] = new MySqlParameter("pId", PId);

            dt = lista.DB_Listar_Todo("SP_Eventos_id", Parametros);

            DataRow row = dt.Rows[0];
            PDescripcion = row["descripcion"].ToString();
            PDetalle = row["detalle"].ToString();
            PActivo= Convert.ToInt32(row["activo"]);
            PConcepto = Convert.ToInt32(row["idConcepto"]);
        }
        public int Eventos_Insert_Update(string strStoredProcedures)
        {
            int ok_Transaccion;

            DB_Ejecutar_SP objDato = new DB_Ejecutar_SP();
            MySqlParameter[] Parametros = new MySqlParameter[5];
            Parametros[0] = new MySqlParameter("@pId", PId);
            Parametros[1] = new MySqlParameter("@pDescripcion", PDescripcion);
            Parametros[2] = new MySqlParameter("@pDetalle", pDetalle);
            Parametros[3] = new MySqlParameter("@pActivo", PActivo);
            Parametros[4] = new MySqlParameter("@pConcepto", PConcepto );


            ok_Transaccion = objDato.DB_SP_NonQuery(strStoredProcedures, Parametros);
            return ok_Transaccion;
        }
        //////////////////////////////////////////////////////////////////////////////////
        public DataTable Evento_Cargar_Grilla(string strStoredProcedure)
        {
            DB_Ejecutar_SP lista = new DB_Ejecutar_SP();
            DataTable dt = new DataTable();
            MySqlParameter[] Parametros = new MySqlParameter[2];

            //

            Parametros[0] = new MySqlParameter("pId", PId);

            dt = lista.DB_Listar_Todo(strStoredProcedure, Parametros);


            return dt;
        }
        public int SegurosAlta()
        {
            int ok_Transaccion;

            DB_Ejecutar_SP objDato = new DB_Ejecutar_SP();
            MySqlParameter[] Parametros = new MySqlParameter[2];
            Parametros[0] = new MySqlParameter("@intID", PId);
            Parametros[1] = new MySqlParameter("@strNombre", PDescripcion);
            
            ok_Transaccion = objDato.DB_SP_NonQuery("SP_Seguros_Alta", Parametros);
            return ok_Transaccion;

            
        }
    }
}
