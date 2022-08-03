using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_presentacion_00
{
    public class rpt_Cotizaciones_Clase
    {
        //Propiedades
        public string Cotizacion { get; set; }
        public string diasValidez { get; set; }
        public string FechaVencimiento { get; set; }
        public string Razon_Social { get; set; }
        public string TipoServicio { get; set; }
        public string TipoModalidad { get; set; }
        public string Vendedor { get; set; }
        public string Ruta { get; set; }
        public string Mercaderia { get; set; }
        public string Contenedor { get; set; }
        public string dias_operacion { get; set; }
        public string Estadia { get; set; }
        public string Tarifa { get; set; }

        //Asignar el constructor por
        //defecto para que no genere error
        //de argumentos
        
        public rpt_Cotizaciones_Clase() { }
        
        //Constructor que recibe parámetro de la misma clase
        public rpt_Cotizaciones_Clase(rpt_Cotizaciones_Clase Add)
        {
            Cotizacion = Add.Cotizacion;
            diasValidez = Add.diasValidez;
            FechaVencimiento = Add.FechaVencimiento;
            Razon_Social = Add.Razon_Social;
            TipoServicio = Add.TipoServicio;
            TipoModalidad = Add.TipoModalidad;
            Vendedor = Add.Vendedor;
            Ruta = Add.Ruta;
            Mercaderia = Add.Mercaderia;
            Contenedor = Add.Contenedor;
            dias_operacion = Add.dias_operacion;
            Estadia = Add.Estadia;
            Tarifa = Add.Tarifa;
        }


    }
}
