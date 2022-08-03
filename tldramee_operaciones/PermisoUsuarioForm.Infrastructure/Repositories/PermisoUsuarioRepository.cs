using MySql.Data.MySqlClient;
using PermisoUsuarioForm.Domain.Models;
using PermisoUsuarioForm.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using k_mysql;

namespace PermisoUsuarioForm.Infrastructure.Repositories
{
    public class PermisoUsuarioRepository : IPermisoUsuarioRepository
    {
        public async Task<List<MenuTree>> TraerMenuTree(int idEmpresa)
        {
            IniFile Lee = new k_mysql.IniFile();
            string constr = Lee.LeeSetting();//ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            List<MenuTree> menuTrees = new List<MenuTree>();

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SP_Carga_Treeview", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@intEmpresa", idEmpresa);

                    // cmd.Parameters.Add(new MySqlParameter { MySqlDbType = MySqlDbType.Int32, ParameterName = "@intEmpresa", Value = 1 });

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        menuTrees = CrearMenuTree(dt);



                    }
                }
            }
            return menuTrees;
        }

        private List<MenuTree> CrearMenuTree(DataTable dt)
        {
            List<MenuTree> menuTrees = new List<MenuTree>();

            foreach (DataRow fila in dt.Rows)
            {

              var result =  menuTrees.Where(w => w.nombre == fila[1].ToString()).Count();

                if (result == 0)
                {
                    menuTrees.Add(
                   new MenuTree
                   {
                       codigo = Convert.ToInt32(fila[0].ToString()),
                       nombre = fila[1].ToString(),
                       Forms = new List<MenuForm> { 
                                        new MenuForm { 
                                            codigo = Convert.ToInt32(fila[2].ToString()), 
                                            nombre = fila[3].ToString(),
                                            Botons = new List<FormBoton> { 
                                                new FormBoton { 
                                                    codigo = Convert.ToInt32(fila[4].ToString()),
                                                    nombre =fila[5].ToString()
                                                } 
                                            }
                                        }
                      }
                   }
                     );

                }
                else
                {
                    var result2 =  menuTrees.Where(w => w.nombre == fila[1].ToString()).FirstOrDefault().Forms.Where(w=>w.nombre == fila[3].ToString()).Count();

                    if (result2 == 0)
                    {

                        foreach (var menuTree in menuTrees)
                        {
                            if (menuTree.nombre == fila[1].ToString())
                            {
                                menuTree.Forms.Add(new MenuForm
                                {
                                    codigo = Convert.ToInt32(fila[2].ToString()),
                                    nombre = fila[3].ToString(),
                                    Botons = new List<FormBoton> {
                                                new FormBoton {
                                                    codigo = Convert.ToInt32(fila[4].ToString()),
                                                    nombre =fila[5].ToString()
                                                }
                                            }
                                });
                            }

                        }


                    }
                    else
                    {

                        foreach (var menuTree in menuTrees.SelectMany(s=>s.Forms))
                        {
                            if (menuTree.nombre == fila[3].ToString())
                            {
                                menuTree.Botons.Add(new FormBoton
                                {
                                    codigo = Convert.ToInt32(fila[4].ToString()),
                                    nombre = fila[5].ToString()
                                });
                            }

                        }

                    }

                }


            }

            return menuTrees;

        }

        public async Task<List<User>>  TraerUsuarios(int idEmpresa)
        {

            IniFile Lee = new k_mysql.IniFile();
            string constr = Lee.LeeSetting();//ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            List<User> users = new List<User>(); 

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SP_Trae_Usuarios", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@intEmpresa", idEmpresa);

                   // cmd.Parameters.Add(new MySqlParameter { MySqlDbType = MySqlDbType.Int32, ParameterName = "@intEmpresa", Value = 1 });
                    
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        foreach(DataRow fila in dt.Rows)
 {
                            users.Add(
                                        new User
                                        {
                                            codigo = Convert.ToInt32(fila[0].ToString()),
                                            nombre = fila[1].ToString()
                                        }
                                );

                        }


                    }
                }
            }
            return users;
        }

        public async Task<List<PermisosUsuario>> TraerPermisosUsuario(int idEmpresa, int idUsuario)
        {
            IniFile Lee = new k_mysql.IniFile();
            string constr = Lee.LeeSetting();//ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            List<PermisosUsuario> permisosUsuarios = new List<PermisosUsuario>();

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SP_Carga_Treeview_Permisos", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@intEmpresa", idEmpresa);
                    cmd.Parameters.AddWithValue("@intUsuario", idUsuario);


                    // cmd.Parameters.Add(new MySqlParameter { MySqlDbType = MySqlDbType.Int32, ParameterName = "@intEmpresa", Value = 1 });

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        foreach (DataRow fila in dt.Rows)
                        {
                            permisosUsuarios.Add(
                                       new PermisosUsuario
                                       {
                                           idMenu = Convert.ToInt32(fila[0].ToString()),
                                           idFormulario = Convert.ToInt32(fila[1].ToString()),
                                           idBoton = Convert.ToInt32(fila[2].ToString()),

                                       }
                                     );
                        }

                    }
                }
            }
            return permisosUsuarios;
        }

        public async Task GrabarPermisosUsuario(int idEmpresa, int idUsuario, int idMenu, int idFormulario, int idBoton, int idEstado)
        {
            IniFile Lee = new k_mysql.IniFile();
            string constr = Lee.LeeSetting();//ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            List<MenuTree> menuTrees = new List<MenuTree>();

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SP_Graba_Permisos", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@intEmpresa", idEmpresa);
                    cmd.Parameters.AddWithValue("@intUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@intMenu", idMenu);
                    cmd.Parameters.AddWithValue("@intFormulario", idFormulario);
                    cmd.Parameters.AddWithValue("@intBoton", idBoton);
                    cmd.Parameters.AddWithValue("@intEstado", idEstado);

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                      //  menuTrees = CrearMenuTree(dt);
                    }
                }
            }
            
        }

        public async Task BorrarPermisosUsuario(int idEmpresa, int idUsuario)
        {
            IniFile Lee = new k_mysql.IniFile();
            string constr = Lee.LeeSetting();//ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            List<MenuTree> menuTrees = new List<MenuTree>();

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SP_Borra_Treeview_Permisos", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@intEmpresa", idEmpresa);
                    cmd.Parameters.AddWithValue("@intUsuario", idUsuario);
       
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        //  menuTrees = CrearMenuTree(dt);
                    }
                }
            }
        }
    }


}
