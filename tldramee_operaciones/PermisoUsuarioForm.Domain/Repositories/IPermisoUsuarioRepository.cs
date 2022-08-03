using PermisoUsuarioForm.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermisoUsuarioForm.Domain.Repositories
{
    public interface IPermisoUsuarioRepository
    {
        Task<List<User>> TraerUsuarios(int idEmpresa);
   
       Task<List<MenuTree>> TraerMenuTree(int idEmpresa);
       Task<List<PermisosUsuario>> TraerPermisosUsuario(int idEmpresa, int idUsuario);
        Task BorrarPermisosUsuario(int idEmpresa, int idUsuario);

        Task GrabarPermisosUsuario(int idEmpresa, int idUsuario, int idMenu, int idFormulario, int idBoton, int idEstado);



    }
}
