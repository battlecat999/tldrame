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
    public class DNUsers
    {
        //Encapusalmiento variables
        private DBUsers objDato = new DBUsers();//instancia a la capa datos de empleados
                                                //variables
        private string _Usuario;
        private string _Pass;
        private int _idEmpresa;
        private string _nomEmpresa;
        private int _idUsuario;
        private string _lastName;
        private string _email;
        private int _permiso;
        private string _telefono1;
        private string _funciones;
        private string _nombreUser;
        private string _empresaDireccion;


        //todas las demas....
        // METODOS GET Y SET -->para el manejo de variables.
        public string Usuario
        {
            //set { _Usuario = value; }
            //get { return _Usuario; }
            set
            {
                if (value=="USUARIO") { _Usuario = "Ingrese su Usuario."; }
                else { _Usuario = value; }
            }
            get { return _Usuario; }
        }
        public string Password
        {
            set {
                if (value == "CONTRASEÑA") { _Pass = "Ingrese su Contraseña"; }
                else{
                    _Pass = value;
                }
            }
            get { return _Pass; }
        }

        public int IdEmpresa { get => _idEmpresa; set => _idEmpresa = value; }
        public string NomEmpresa { get => _nomEmpresa; set => _nomEmpresa = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Email { get => _email; set => _email = value; }
        public int Permiso { get => _permiso; set => _permiso = value; }
        public string telefono1 { get => _telefono1; set => _telefono1 = value; }
        public string funciones { get => _funciones; set => _funciones = value; }
        public string nombreUser { get => _nombreUser; set => _nombreUser = value; }
        public string direcEmpresa { get => _empresaDireccion; set => _empresaDireccion = value; }


        //CONSTRUCTOR
        //public DNUsers(){ }
        public DataTable iniciarSesion()
        {
            MySqlDataReader Loguear;
            DataTable dt = new DataTable ();
            Loguear = objDato.iniciarSesion(Usuario,Password);//el nombre del get y set
            dt.Load(Loguear);
            if(dt.Rows.Count > 0)
            {
                IdEmpresa = Convert.ToInt32(dt.Rows[0]["empresa_ID"]);
                NomEmpresa = dt.Rows[0]["empresa_nombre"].ToString();
                IdUsuario = Convert.ToInt32(dt.Rows[0]["idUser"]);
                LastName = dt.Rows[0]["lastName"].ToString();
                Email = dt.Rows[0]["userEmail"].ToString();
                Permiso= Convert.ToInt32(dt.Rows[0]["kind"]);
                funciones= dt.Rows[0]["funciones"].ToString();
                telefono1 = dt.Rows[0]["telefono1"].ToString();
                nombreUser = dt.Rows[0]["nombreUser"].ToString();
                direcEmpresa = dt.Rows[0]["direcEmpresa"].ToString();

            }   
            
                
            
            return dt;
            
        }
    }
}
