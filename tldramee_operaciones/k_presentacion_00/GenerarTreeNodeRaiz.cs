using PermisoUsuarioForm.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PermisoUsuarioForm.Helpers
{
    public static class GenerarTreeNodeRaiz
    {
        internal static TreeNode GetGenerarTreeNodeRaiz(List<MenuTree> result, List<PermisosUsuario> permisosUsuario)
        {
            List<TreeNode> treeMenu = new List<TreeNode>();

            foreach (var menu in result)
            {
                List<TreeNode> treeFrom = new List<TreeNode>();

                foreach (var form in menu.Forms)
                {
                    List<TreeNode> treeBoton = new List<TreeNode>();

                    foreach (var boton in form.Botons)
                    {
                        var existePermisoBoton = permisosUsuario.Where(
                            w => w.idMenu == menu.codigo
                            && w.idFormulario == form.codigo
                            && w.idBoton == boton.codigo).Count();

                        var botontree = new TreeNode(boton.nombre);
                        botontree.Checked = existePermisoBoton == 0 ? false : true;
                        botontree.Tag = boton.codigo;
                        treeBoton.Add(botontree);

                    }
                    var existePermisoForm = permisosUsuario.Where(
                         w => w.idMenu == menu.codigo
                         && w.idFormulario == form.codigo
                        
                         ).Count();

                    var formtree = new TreeNode(form.nombre, treeBoton.ToArray());
                    formtree.Checked = existePermisoForm == 0 ? false : true;
                    formtree.Tag = form.codigo;
                    treeFrom.Add(formtree);
                }
                var existePermisoMenu = permisosUsuario.Where(
                     w => w.idMenu == menu.codigo
                    //  && w.idBoton == 0
                     ).Count();

                var menutree = new TreeNode(menu.nombre, treeFrom.ToArray());
                menutree.Checked = existePermisoMenu == 0 ? false : true;
                menutree.Tag = menu.codigo;
                treeMenu.Add(menutree);

            }

            return new TreeNode("Principal", treeMenu.ToArray());
        }
    }
}
