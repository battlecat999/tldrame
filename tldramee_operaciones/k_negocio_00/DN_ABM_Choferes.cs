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
using System.Globalization;

namespace k_negocio_00
{
    public class DN_ABM_Choferes
    {
        private int pAll;
        private int Id;
        private string Apellido;
        private int Pais;
        private int Provincia;
        private string Localidad;
        private string Direccion;
        private string CodPost;
        private int TipoDoc;
        private string NroDoc;
        private string NroLicencia;
        private string FecVenLic;
        private string Municipio;
        private string NroPoliza;
        private string Seguro;
        private string FecVenSeguro;
        private string LibretaSanitaria;
        private string Email;
        private string Radio;
        //
        private string Telefono;
        private string Celular;
//
        private int Activo;

        private int IdEmpresa;
        private int IdTransportista;
        private int IdUsuario;

        //
        private bool _va;

        public DataTable Chofer_GET()
        {
            DB_ABM_TCC lista = new DB_ABM_TCC();
            DataTable dt = new DataTable();
            dt = lista.Traer_Chofer (PAll, Id1);
            return dt;
        }
        private string formatear_Numero(string var)
        {
            string strNuevo=String.Empty;
            int intLen = var.Length;
            if (intLen>=7 && intLen<=8)
            {
                double numero = Convert.ToDouble(var);
                NumberFormatInfo formato = new CultureInfo("es-AR").NumberFormat;
                formato.CurrencyGroupSeparator = ".";
                //formato.NumberDecimalSeparator = "";
                formato.NumberDecimalDigits = 0;
                strNuevo = numero.ToString("N", formato).ToString();
            }
            if (intLen>8)
            {
                string preFijo = var.Substring(0, 2);
                string subFijo = var.Substring(var.Length - 1, 1);
                string numFijo = var.Substring(2, var.Length - 3);

               // double numero = Convert.ToDouble(numFijo);
                //NumberFormatInfo formato = new CultureInfo("es-AR").NumberFormat;
                //formato.CurrencyGroupSeparator = "";
                //formato.NumberDecimalSeparator = "";
                //formato.NumberDecimalDigits = 0;
                //strNuevo = numero.ToString("N", formato).ToString();

                strNuevo = string.Concat(preFijo, "-", numFijo, "-", subFijo);


                //strNuevo = String.Format("00-00.000.000-0", var);
            }
            return strNuevo;
        }
        public void Chofer_GET_id()
        {

            try
            {
                DB_ABM_TCC lista = new DB_ABM_TCC();
                DataTable dt = new DataTable();
                dt = lista.Traer_Chofer(PAll, Id1);
                //
                DataRow row = dt.Rows[0];
                Pais1=Convert.ToInt32(row["Pais"]);
                Provincia1 = Convert.ToInt32(row["Provincia"]);
                Localidad1=row["Localidad"].ToString();
                Direccion1=row["Direccion"].ToString();
                CodPost1= row["CodPost"].ToString();
                TipoDoc1 = Convert.ToInt32(row["TipoDoc"]);

                NroDoc1 = formatear_Numero(row["NroDoc"].ToString());
                NroLicencia1 = formatear_Numero(row["NroLicencia"].ToString());

                Va = false;

                FecVenLic1 = Convert.ToDateTime(row["FecVenLic"]).ToString("dd/MM/yyyy");

                Municipio1 = row["Municipio"].ToString();
                NroPoliza1 = row["NroPoliza"].ToString();
                Seguro1 = row["Seguro"].ToString();
                FecVenSeguro1 = Convert.ToDateTime(row["FecVenSeguro"]).ToString("dd/MM/yyyy");
                LibretaSanitaria1 = row["LibretaSanitaria"].ToString();
                Email1 = row["Email"].ToString();
                Radio1 = row["Radio"].ToString();
                Telefono1 = row["Telefono"].ToString();
                Celular1 = row["Celular"].ToString();
                Activo1 = Convert.ToInt32(row["Activo"]);
                idTransportista = Convert.ToInt32(row["Transportista"]);
            }
            catch (Exception)
            {

                //throw;
            }
        }
        public bool  Chofer_ACTUALIZAR()
        {
            bool ok_Tra;
            DB_ABM_TCC objDato = new DB_ABM_TCC();
            ok_Tra = objDato.ABM_Chofer(PAll,Id1,Apellido1,Pais1,Provincia1,Localidad1,
                Direccion1,CodPost1,TipoDoc1,NroDoc1,NroLicencia1,FecVenLic1,Municipio1,
                NroPoliza1,Seguro1,FecVenSeguro1,LibretaSanitaria1,Email1,Radio1,Telefono1,Celular1,Activo1,IdEmpresa,idTransportista ,idUsuario );

            return ok_Tra;
        }

        public int PAll
        {
            get
            {
                return pAll;
            }

            set
            {
                pAll = value;
            }
        }

        public int Id1
        {
            get
            {
                return Id;
            }

            set
            {
                Id = value;
            }
        }

        public string Apellido1
        {
            get
            {
                return Apellido;
            }

            set
            {
                Apellido = value;
            }
        }

        public int Pais1
        {
            get
            {
                return Pais;
            }

            set
            {
                Pais = value;
            }
        }

        public int Provincia1
        {
            get
            {
                return Provincia;
            }

            set
            {
                Provincia = value;
            }
        }

        public string  Localidad1
        {
            get
            {
                return Localidad;
            }

            set
            {
                Localidad = value;
            }
        }

        public string Direccion1
        {
            get
            {
                return Direccion;
            }

            set
            {
                Direccion = value;
            }
        }

        public string CodPost1
        {
            get
            {
                return CodPost;
            }

            set
            {
                CodPost = value;
            }
        }

        public int TipoDoc1
        {
            get
            {
                return TipoDoc;
            }

            set
            {
                TipoDoc = value;
            }
        }

        public string NroDoc1
        {
            get
            {
                return NroDoc;
            }

            set
            {
                NroDoc = value;
            }
        }

        public string NroLicencia1
        {
            get
            {
                return NroLicencia;
            }

            set
            {

                NroLicencia =  value;
            }
        }

        public string FecVenLic1
        {
            get
            {
                return FecVenLic;
            }

            set
            {
                if (_va == true)
                {
                    DateTime mifecha;
                    mifecha = Convert.ToDateTime(value);
                    FecVenLic = mifecha.ToString("yyyy-MM-dd");
                }
                else
                {
                    FecVenLic = value;
                }
            }
        }

        public string Municipio1
        {
            get
            {
                return Municipio;
            }

            set
            {
                Municipio = value;
            }
        }

        public string NroPoliza1
        {
            get
            {
                return NroPoliza;
            }

            set
            {
                NroPoliza = value;
            }
        }

        public string Seguro1
        {
            get
            {
                return Seguro;
            }

            set
            {
                Seguro = value;
            }
        }

        public string FecVenSeguro1
        {
            get
            {
                return FecVenSeguro;
            }

            set
            {
                if (_va == true)
                {
                    DateTime mifecha;
                    mifecha = Convert.ToDateTime(value);
                    FecVenSeguro = mifecha.ToString("yyyy-MM-dd");
                }
                else
                {
                    FecVenSeguro = value;
                }
            }
        }

        public string LibretaSanitaria1
        {
            get
            {
                return LibretaSanitaria;
            }

            set
            {
                LibretaSanitaria = value;
            }
        }

        public string Email1
        {
            get
            {
                return Email;
            }

            set
            {
                Email = value;
            }
        }

        public string Radio1
        {
            get
            {
                return Radio;
            }

            set
            {
                Radio = value;
            }
        }

        public string Telefono1
        {
            get
            {
                return Telefono;
            }

            set
            {
                Telefono = value;
            }
        }

        public string Celular1
        {
            get
            {
                return Celular;
            }

            set
            {
                Celular = value;
            }
        }

        public int Activo1
        {
            get
            {
                return Activo;
            }

            set
            {
                Activo = value;
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
        public int idEmpresa { get => IdEmpresa; set => IdEmpresa = value; }
        public int idTransportista { get => IdTransportista; set => IdTransportista = value; }
        public int idUsuario { get => IdUsuario; set => IdUsuario = value; }
    }
}
