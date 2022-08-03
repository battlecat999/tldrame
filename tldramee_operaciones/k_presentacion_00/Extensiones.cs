using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_presentacion_00
{
    public static class Extensiones
    {

            public static bool IsNumeric(this string s)
            {
                float output;
                return float.TryParse(s, out output);
            }
        
    }
}
