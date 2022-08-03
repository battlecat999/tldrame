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
    public class DN_ABM
    {
        private string _SP;
        
        private int _id;
        private string _nombre;
        private int _empresa;
        private int _pais;
        private int _prov;
        private string _loc;
        private string _direccion;
        private string _cp;
        private string _tel1;
        private string _tel2;
        private string _fax;
        private string _email;
        private string _cuit;
        private string _site;
        private int _estado;
        private string _fechaInicio;
        private int _codpago;
        private int _EsDe;
        private int _idOrigen;

        private bool _va;

        private int _Evento;
        private int _opMoro;
        

        public void DN_Grabar_Asoc_Eventos_Clientes(int intEmpresa,int intCliente,int intContacto,DataTable dt)
        {
            int ok_Transaccion;
            DB_Ejecutar_SP objDato = new DB_Ejecutar_SP();
            MySqlParameter[] Parametros = new MySqlParameter[5];

            Parametros[0] = new MySqlParameter("intEmpresa", intEmpresa);
            Parametros[1] = new MySqlParameter("intCliente", intCliente);
            Parametros[2] = new MySqlParameter("intContacto", intContacto);
            Parametros[3] = new MySqlParameter("intEvento", 1);
            Parametros[4] = new MySqlParameter("intEstado", 1);
            ok_Transaccion = objDato.DB_SP_NonQuery("SP_Cliente_Evento_Del", Parametros);

           
            

            foreach (DataRow dtRow in dt.Rows)
            {
                if (dtRow[3].ToString()=="0")
                {
                    Parametros[0].Value = intEmpresa; //new MySqlParameter("intEmpresa", intEmpresa);
                    Parametros[1].Value = intCliente;// new MySqlParameter("intCliente", intCliente);
                    Parametros[2].Value = intContacto;// = new MySqlParameter("intContacto", intContacto);
                    Parametros[3].Value = dtRow[1].ToString();// = new MySqlParameter("intEvento", dtRow[1].ToString());
                    Parametros[4].Value = 1;// = new MySqlParameter("intEstado", 1);
                    ok_Transaccion = objDato.DB_SP_NonQuery("SP_Cliente_Evento_Insert", Parametros);
                }

            }
        }

        public DataTable DN_Traer_DataTable(string SP, int ID, int IdEmpresa)
        {
            DB_Ejecutar_SP lista = new DB_Ejecutar_SP();
            DataTable dt = new DataTable();
            MySqlParameter[] Parametros = new MySqlParameter[2];

            //
            Parametros[0] = new MySqlParameter("pIdEmpresa", IdEmpresa);
            Parametros[1] = new MySqlParameter("ID", ID);

            dt = lista.DB_Listar_Todo(SP, Parametros);

            return dt;
            //dt = lista.DB_Listar_Todo(strStoredProcedures, Parametros);
        }

        public DataTable DN_Traer_DataTable(string strNombre_Stored, string strNombre_Campo_Empresa, string strNombre_Campo_Codigo, int intValor_Campo_Empresa, object objValor_Campo_Codigo)
        {
            DB_Ejecutar_SP lista = new DB_Ejecutar_SP();
            DataTable dt = new DataTable();

            MySqlParameter[] Parametros = new MySqlParameter[2];

            //
            Parametros[0] = new MySqlParameter(strNombre_Campo_Empresa, intValor_Campo_Empresa);
            Parametros[1] = new MySqlParameter(strNombre_Campo_Codigo, objValor_Campo_Codigo);

            dt = lista.DB_Listar_Todo(strNombre_Stored, Parametros);

            return dt;
        }


        public void DN_Clientes_Get_Id(string strStoredProcedure,int IdEmpresa,int ID)
        {
            DB_Ejecutar_SP lista = new DB_Ejecutar_SP();
            DataTable dt = new DataTable();
            MySqlParameter[] Parametros = new MySqlParameter[2];

            //
            Parametros[0] = new MySqlParameter("pIdEmpresa", IdEmpresa);
            Parametros[1] = new MySqlParameter("pId", ID);

            dt = lista.DB_Listar_Todo (strStoredProcedure,Parametros );
            if (dt.Rows.Count > 0)
            {
                //return dt;
                Va = false;

                DataRow row = dt.Rows[0];
                Pais = Convert.ToInt32(row["Pais"]);
                Prov = Convert.ToInt32(row["Provincia"]);
                Loc = row["Localidad"].ToString();
                Direccion = row["Direccion"].ToString();
                Cp = row["Codigo_Postal"].ToString();
                Tel1 = row["Telefonos"].ToString();
                Email = row["Email"].ToString();
                Site = row["Site"].ToString();
                Cuit = row["CUIT"].ToString();
                Estado = Convert.ToInt32(row["Estado"]);
                //Codiva = Convert.ToInt32(row["IdCondicionIVA"]);
                Codpago = Convert.ToInt32(String.IsNullOrEmpty(row["Condicion_IVA"].ToString()) ? 0: row["Condicion_IVA"]);
            }


        }
        public void DN_Proveedores_Get_Id(string strStoredProcedure, int IdEmpresa, int ID)
        {
            DB_Ejecutar_SP lista = new DB_Ejecutar_SP();
            DataTable dt = new DataTable();
            MySqlParameter[] Parametros = new MySqlParameter[2];

            //
            Parametros[0] = new MySqlParameter("pIdEmpresa", IdEmpresa);
            Parametros[1] = new MySqlParameter("pId", ID);

            dt = lista.DB_Listar_Todo(strStoredProcedure, Parametros);
            if (dt.Rows.Count > 0)
            {
                //return dt;
                Va = false;

                DataRow row = dt.Rows[0];
                Pais = Convert.ToInt32(row["Pais"]);
                Prov = Convert.ToInt32(row["Provincia"]);
                Loc = row["Localidad"].ToString();
                Direccion = row["Direccion"].ToString();
                Cp = row["Codigo_Postal"].ToString();
                Tel1 = row["Telefonos"].ToString();
                Email = row["Email"].ToString();
                Site = row["Site"].ToString();
                Cuit = row["CUIT"].ToString();
                Estado = Convert.ToInt32(row["Estado"]);
                //Codiva = Convert.ToInt32(row["IdCondicionIVA"]);
                Codpago = Convert.ToInt32(String.IsNullOrEmpty(row["Condicion_IVA"].ToString()) ? 0 : row["Condicion_IVA"]);
                OpMoro= Convert.ToInt32(String.IsNullOrEmpty(row["opMoro"].ToString()) ? 0 : row["opMoro"]);
            }


        }
        //CONSTRUCTOR
        //public DNUsers(){ }
        public int ABM_Clientes_De_Form_a_DN(string strStoredProcedures,int IdEmpresa,int IdUsuario)
        {
            int ok_Transaccion;

            DB_Ejecutar_SP objDato = new DB_Ejecutar_SP();


            MySqlParameter[] Parametros = new MySqlParameter[16];

            Parametros[0] = new MySqlParameter("@pId", Id);
            Parametros[1] = new MySqlParameter("@pRazonSocial", Nombre);
            Parametros[2] = new MySqlParameter("@pPais", Pais);
            Parametros[3] = new MySqlParameter("@pProv", Prov);
            Parametros[4] = new MySqlParameter("@pLoc", Loc);
            Parametros[5] = new MySqlParameter("@pDireccion", Direccion);
            Parametros[6] = new MySqlParameter("@pCP", Cp);
            Parametros[7] = new MySqlParameter("@pTel1", Tel1);
            Parametros[8] = new MySqlParameter("@pEmail", Email);
            Parametros[9] = new MySqlParameter("@pSite", Site);
            Parametros[10] = new MySqlParameter("@pCuit", Cuit);
            Parametros[11] = new MySqlParameter("@pEstado", Estado);
            Parametros[12] = new MySqlParameter("@pCodPago", Codpago);
            Parametros[13] = new MySqlParameter("@pFechaInicioActividad", fechaInicio );
            Parametros[14] = new MySqlParameter("@pIdEmpresa",IdEmpresa  );



            ok_Transaccion = objDato.DB_SP_NonQuery(strStoredProcedures, Parametros);
            return ok_Transaccion;

        }
        public int ABM_Proveedores_De_Form_a_DN(string strStoredProcedures, int IdEmpresa, int IdUsuario)
        {
            int ok_Transaccion;

            DB_Ejecutar_SP objDato = new DB_Ejecutar_SP();


            MySqlParameter[] Parametros = new MySqlParameter[15];

            Parametros[0] = new MySqlParameter("@pId", Id);
            Parametros[1] = new MySqlParameter("@pRazonSocial", Nombre);
            Parametros[2] = new MySqlParameter("@pPais", Pais);
            Parametros[3] = new MySqlParameter("@pProv", Prov);
            Parametros[4] = new MySqlParameter("@pLoc", Loc);
            Parametros[5] = new MySqlParameter("@pDireccion", Direccion);
            Parametros[6] = new MySqlParameter("@pCP", Cp);
            Parametros[7] = new MySqlParameter("@pTel1", Tel1);
            Parametros[8] = new MySqlParameter("@pEmail", Email);
            Parametros[9] = new MySqlParameter("@pSite", Site);
            Parametros[10] = new MySqlParameter("@pCuit", Cuit);
            Parametros[11] = new MySqlParameter("@pEstado", Estado);
            Parametros[12] = new MySqlParameter("@pCodPago", Codpago);
            Parametros[13] = new MySqlParameter("@pIdEmpresa", IdEmpresa);
            Parametros[14] = new MySqlParameter("@intMoro", OpMoro);

            ok_Transaccion = objDato.DB_SP_NonQuery(strStoredProcedures, Parametros);
            return ok_Transaccion;

        }
        public DataTable DN_Contactos_Clientes_Por_Id(string strStoredProcedures,int idEmpresa, int idCliente,int EsDe)
        {
            DB_Ejecutar_SP lista = new DB_Ejecutar_SP();
            DataTable dt = new DataTable();

            MySqlParameter[] Parametros = new MySqlParameter[3];
            Parametros[0] = new MySqlParameter("pIdEmpresa", idEmpresa);
            Parametros[1] = new MySqlParameter("pIdOrigen", idCliente);
            Parametros[2] = new MySqlParameter("pEsDe", EsDe);


            dt = lista.DB_Listar_Todo(strStoredProcedures,Parametros);

            return dt;
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }
        public string Tel2
        {
            get
            {
                return _tel2;
            }

            set
            {
                _tel2 = value;
            }
        }

        public string Fax
        {
            get
            {
                return _fax;
            }

            set
            {
                _fax = value;
            }
        }
        public int Pais
        {
            get
            {
                return _pais;
            }

            set
            {
                _pais = value;
            }
        }

        public int Prov
        {
            get
            {
                return _prov;
            }

            set
            {
                _prov = value;
            }
        }

        public string Loc
        {
            get
            {
                return _loc;
            }

            set
            {
                _loc = value;
                if (_loc==string.Empty )
                {
                    _loc = "0";
                }
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                _direccion = value;
            }
        }

        public string Cp
        {
            get
            {
                return _cp;
            }

            set
            {
                _cp = value;
            }
        }

        public string Tel1
        {
            get
            {
                return _tel1;
            }

            set
            {
                _tel1 = value;
            }
        }




        public string Email
        {
            get            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string Cuit
        {
            get
            {
                return _cuit;
            }

            set
            {
                _cuit = value;
            }
        }

        public int Estado
        {
            get
            {
                return _estado;
            }

            set
            {
                _estado = value;
            }
        }

        //public int Codiva
        //{
        public string fechaInicio
        {
            get
            {
                return _fechaInicio;
            }

            set
            {
                if (_va == true)
                {
                    DateTime mifecha;
                    mifecha = Convert.ToDateTime(value);
                    _fechaInicio = mifecha.ToString("yyyy-MM-dd");
                }
                else
                {
                    _fechaInicio = value;
                }
            }
        }
        //}

        public int Codpago
        {
            get
            {
                return _codpago;
            }

            set
            {
                _codpago = value;
            }
        }
        public bool Va
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

        public string SP
        {
            get
            {
                return _SP;
            }

            set
            {
                _SP = value;
            }
        }

        public string Site
        {
            get
            {
                return _site;
            }

            set
            {
                _site = value;
            }
        }

        public int EsDe
        {
            get
            {
                return _EsDe;
            }

            set
            {
                _EsDe = value;
            }
        }

        public int IdOrigen
        {
            get
            {
                return _idOrigen;
            }

            set
            {
                _idOrigen = value;
            }
        }

        public int Empresa { get => _empresa; set => _empresa = value; }
        public int Evento { get => _Evento; set => _Evento = value; }
        public int OpMoro { get => _opMoro; set => _opMoro = value; }


        ////Metodos de Contactos
        //public DataTable DN_Contactos_Get_All00()
        //{
        //    DB_Ejecutar_SP lista = new DB_Ejecutar_SP();
        //    DataTable dt = new DataTable();
        //    dt = lista.DB_Listar_Todo (strStoredProcedure);
        //    return dt;
        //}


        public void DN_Contactos_Get_Id(int ID, int IdEmpresa)
        {
            DB_Ejecutar_SP lista = new DB_Ejecutar_SP();
            DataTable dt = new DataTable();

            MySqlParameter[] Parametros = new MySqlParameter[2];

            //
            Parametros[0] = new MySqlParameter("pIdEmpresa", IdEmpresa);
            Parametros[1] = new MySqlParameter("ID", ID);

            dt = lista.DB_Listar_Todo("SP_Contactos_Get_Id", Parametros );

            //return dt;
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                IdOrigen = Convert.ToInt32(row["idOrigen"]);
                Pais = Convert.ToInt32(row["Pais"]);
                Prov = Convert.ToInt32(row["Provincia"]);
                Loc = row["Localidad"].ToString();
                Direccion = row["Direccion"].ToString();
                Cp = row["CodPost"].ToString();
                Tel1 = row["Tel1"].ToString();
                Email = row["Email"].ToString();
                Estado = Convert.ToInt32(row["Estado"]);
                EsDe = Convert.ToInt32(row["EsDe"]);
            }
        }

        public int DN_Contactos_Insert_Update(string strStoredProcedures)
        {
            int ok_Transaccion;

            DB_Ejecutar_SP objDato = new DB_Ejecutar_SP();


            MySqlParameter[] Parametros = new MySqlParameter[15];

            Parametros[0]= new MySqlParameter("@pId", Id);
            Parametros[1]= new MySqlParameter("@pIdOrigen", IdOrigen);
            Parametros[2]= new MySqlParameter("@pRazonSocial", Nombre);
            Parametros[3]= new MySqlParameter("@pPais", Pais);
            Parametros[4]= new MySqlParameter("@pProv", Prov);
            Parametros[5]= new MySqlParameter("@pLoc", Loc);
            Parametros[6]= new MySqlParameter("@pDireccion", Direccion);
            Parametros[7]= new MySqlParameter("@pCP", Cp);
            Parametros[8]= new MySqlParameter("@pTel1", Tel1);
            Parametros[9]= new MySqlParameter("@pTel2", Tel2);
            Parametros[10]= new MySqlParameter("@pFax", Fax);
            Parametros[11]= new MySqlParameter("@pEmail", Email);
            Parametros[12]= new MySqlParameter("@pEstado", Estado);
            Parametros[13]= new MySqlParameter("@pEsDe", EsDe);
            Parametros[14] = new MySqlParameter("@pIdEmpresa", Empresa );

            ok_Transaccion = objDato.DB_SP_NonQuery(strStoredProcedures, Parametros);
            return ok_Transaccion;

        }

    }
}
