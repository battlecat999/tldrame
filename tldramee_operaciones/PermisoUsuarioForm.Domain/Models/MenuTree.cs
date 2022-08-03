using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermisoUsuarioForm.Domain.Models
{
    public class MenuTree
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public List<MenuForm> Forms { get; set; }
    }

    public class MenuForm
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public List<FormBoton> Botons { get; set; }

    }

    public class FormBoton
    {
        public int codigo { get; set; }
        public string nombre { get; set; }

    }
}
