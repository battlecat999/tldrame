using MetroFramework.Forms;
using PermisoUsuarioForm.Domain.Models;
using PermisoUsuarioForm.Domain.Repositories;
using PermisoUsuarioForm.Helpers;
using PermisoUsuarioForm.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace k_presentacion_00
{
    public partial class frmPermisos : MetroForm
    {

        guardar_datos_login datos = guardar_datos_login.Instance();

        private int idEmpresa;
        private int idUsuario = 0;

       

        delegate void SetUsersCallback(List<User> users);
        delegate void SetTreeCallback(List<MenuTree> nodeRaiz,List<PermisosUsuario> permisosUsuarios);

        IPermisoUsuarioRepository _permisoUsuarioRepository = new PermisoUsuarioRepository();
        
        
        
        public frmPermisos()
        {
            InitializeComponent();
            idEmpresa = datos.g_idEmpresa;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
                cmbUsers.PromptText = "Cargando usuarios...";
                lblEventos.ForeColor = Color.Blue;
                lblEventos.Text = "Cargando la lista usuarios...";
                Thread hilo = new Thread(new ThreadStart(()=>this.usersHilo(idEmpresa)));
                hilo.Start();
        }

        private async void usersHilo(int idEmpresa)
        {
            // En lugar de asignar directamente el texto
            // llamamos al método SetText
            try
            {
                var result = await _permisoUsuarioRepository.TraerUsuarios(idEmpresa);
                loadCmbusers(result);
            }
            catch (Exception)
            {
                List<User> users = new List<User>();
                loadCmbusers(users);

            }

        }


        private void loadCmbusers(List<User> users)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (cmbUsers.InvokeRequired)
            {
                SetUsersCallback d = new SetUsersCallback(loadCmbusers);
                this.Invoke(d, users );
            }
            else
            {
                if (users==null)
                {
                    lblEventos.ForeColor = Color.Red;
                    lblEventos.Text = "Error al cargar la lista usuarios.";
                }
                else
                {
                
                    this.cmbUsers.PromptText = "Seleccione un usuario";
                    this.cmbUsers.DataSource = users;
                    this.cmbUsers.DisplayMember = "nombre";
                    this.cmbUsers.ValueMember = "codigo";
                    this.cmbUsers.SelectedIndex = -1;

                    lblEventos.ForeColor = Color.Lime;
                    lblEventos.Text = "La lista de usuario sea completado.";
                }
             
               
            }
        }

        // List the checked TreeNodes.
        private async void btnShowChecked_Click(object sender, EventArgs e)
        {

            //Registrando los permisos
            lblEventos.ForeColor = Color.Blue;
            lblEventos.Text = "Registrando los permisos al usuario...";
            // Get the checked nodes.
            List<TreeNode> checked_nodes = CheckedNodes(trvMeals).Where(w=>w.Level>1).ToList();
            try
            {
                //Borrar permisos del usuario
                await _permisoUsuarioRepository.BorrarPermisosUsuario(idEmpresa, idUsuario);

                // Display the checked nodes.
                //string results = "";
                foreach (TreeNode node in checked_nodes)
                {

                    var idMenu = 0;
                    var idFormulario = 0;
                    var idBoton = 0;

                    switch (node.Level)
                    {
                        case 2:
                            idMenu = Convert.ToInt32(node.Parent.Tag.ToString());
                            idFormulario = Convert.ToInt32(node.Tag.ToString());
                            idBoton = 0;
                            await _permisoUsuarioRepository.GrabarPermisosUsuario(idEmpresa, idUsuario, idMenu, idFormulario, idBoton, 0);
                            break;
                        case 3:
                            idMenu = Convert.ToInt32(node.Parent.Parent.Tag.ToString());
                            idFormulario = Convert.ToInt32(node.Parent.Tag.ToString());
                            idBoton = Convert.ToInt32(node.Tag.ToString());
                            await _permisoUsuarioRepository.GrabarPermisosUsuario(idEmpresa, idUsuario, idMenu, idFormulario, idBoton, 0);
                            break;

                        default:
                            break;
                    }
                }

                lblEventos.ForeColor = Color.Blue;
                lblEventos.Text = "Permisos al usuario registrados.";
            }
            catch (Exception)
            {

                lblEventos.ForeColor = Color.Red;
                lblEventos.Text = "Error en registrar los permisos al usuario...";
            }
      
        }

        // Return a list of the checked TreeView nodes.
        private List<TreeNode> CheckedNodes(TreeView trv)
        {
            List<TreeNode> checked_nodes = new List<TreeNode>();
            FindCheckedNodes(checked_nodes, trvMeals.Nodes);
            return checked_nodes;
        }

        // Return a list of the TreeNodes that are checked.
        private void FindCheckedNodes(List<TreeNode> checked_nodes, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                // Add this node.
                if (node.Checked) checked_nodes.Add(node);
                
                // Check the node's descendants.
                FindCheckedNodes(checked_nodes, node.Nodes);
            }
        }


        private async void btnActualizarUsers_Click(object sender, EventArgs e)
        {
            cmbUsers.PromptText = "Cargando usuarios...";
            lblEventos.ForeColor = Color.Blue;
            lblEventos.Text = "Cargando la lista usuario...";
            this.trvMeals.Nodes.Clear();

            Thread hilo = new Thread(new ThreadStart(()=>this.usersHilo(idEmpresa)));
            hilo.Start();

        }


        private async void cmbUsers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.trvMeals.Nodes.Clear();
            lblEventos.ForeColor = Color.Blue;
            lblEventos.Text = "Cargando el arbol de permisos...";
            ComboBox comboBoxUsers = (ComboBox)sender;
            if (comboBoxUsers.SelectedIndex >= 0)
            {
                this.trvMeals.Nodes.AddRange(new TreeNode[] { new TreeNode("Cargando el arbol de permisos...") });
                 idUsuario = Convert.ToInt32(comboBoxUsers.SelectedValue.ToString());
                Thread hilo = new Thread(new ThreadStart(() => this.treeHilo(idEmpresa, idUsuario)));
                hilo.Start();

            }
        }


        private async void treeHilo(int idEmpresa, int idUsuario)
        {
            
            // En lugar de asignar directamente el texto
            // llamamos al método SetText
            try
            {
               var result = await _permisoUsuarioRepository.TraerMenuTree(idEmpresa);
                var permisosUsuario = await _permisoUsuarioRepository.TraerPermisosUsuario(idEmpresa, idUsuario);
                loadTreeView(result, permisosUsuario);
            }
            catch (Exception)
            {
                List<MenuTree> result = new List<MenuTree>();
                List<PermisosUsuario> permisosUsuario = new List<PermisosUsuario>();

                loadTreeView(result, permisosUsuario);

            }

        }


        private void loadTreeView(List<MenuTree> treeRaiz, List<PermisosUsuario> permisosUsuarios)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (cmbUsers.InvokeRequired)
            {
                SetTreeCallback d = new SetTreeCallback(loadTreeView);
                this.Invoke(d, treeRaiz, permisosUsuarios);
            }
            else
            {
                this.trvMeals.Nodes.Clear();
                TreeNode treeNodeRaiz = GenerarTreeNodeRaiz.GetGenerarTreeNodeRaiz(treeRaiz, permisosUsuarios);
                this.trvMeals.Nodes.AddRange(new TreeNode[] { treeNodeRaiz });
                this.trvMeals.ExpandAll();
                lblEventos.ForeColor = Color.Lime;
                lblEventos.Text = "Cargar del arbol de permisos completado.";

            }
        }

        private void trvMeals_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckedNodes(e.Node.Nodes, e.Node.Checked);
        }
                // Return a list of the TreeNodes that are checked.
        private void CheckedNodes(TreeNodeCollection nodes,bool checkedNode)
        {
            foreach (TreeNode node in nodes)
            {
                // Add this node.
                node.Checked = checkedNode;

                // Check the node's descendants.
                CheckedNodes(node.Nodes, checkedNode);
            }
        }

    }
}
