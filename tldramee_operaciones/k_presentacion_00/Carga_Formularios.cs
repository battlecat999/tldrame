using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k_presentacion_00
{
    public partial class Carga_Formularios : Form
    {
        private System.Reflection.Assembly ass;
        public Carga_Formularios()
        {
            InitializeComponent();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Assembly asm = Assembly.GetExecutingAssembly();

            //List<Form> formList = asm.GetTypes()
            //                            .Where(x => x.IsSubclassOf(typeof(Form)))
            //                            .Select(x => (Form)Activator.CreateInstance(x))
            //                            .ToList();

            ////tambien se puede realizar sin usar linq
            ////foreach (Type item in asm.GetTypes())
            ////{
            ////    if (item.IsSubclassOf(typeof(Form)))
            ////    {
            ////        formList.Add((Form)Activator.CreateInstance(item));
            ////    }
            ////}

            //lstForms.DisplayMember = "Text";
            //lstForms.DataSource = formList;
        }
        private void mostrarForms()
        {
            // llena una colección con los formularios de esta aplicación
            // estén o no en memoria.
            // Muestra el resultado en un listbox
            string q;
            q = string.Empty;
            lstForms.Items.Clear();

            foreach (Type t in ass.GetTypes())
            {
                if (t.IsSubclassOf(typeof(Form)))
                {
                    var nombreTipo = t.BaseType.Name;
                    // También tendrá My.Application: (solo en VB)
                    // <espacio de nombres>.My.MyApplication
                    if (nombreTipo.ToLower().Contains("form"))
                        //lstForms.Items.Add(t.Name);
                        q = string.Concat(q, t.Name, Environment.NewLine);
                }
            }
            //q = q;
        }

        private void Carga_Formularios_Load(object sender, EventArgs e)
        {
            ass = System.Reflection.Assembly.GetExecutingAssembly();
            mostrarForms();
        }
    }
}
