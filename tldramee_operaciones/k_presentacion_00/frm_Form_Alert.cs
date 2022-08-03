using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k_presentacion_00
{
    public partial class frm_Form_Alert : Form
    {
        public frm_Form_Alert()
        {
            InitializeComponent();
        }

        private void frm_Form_Alert_Load(object sender, EventArgs e)
        {

        }
        private int x, y;
        public void showAlert(string msg)
        {
            this.Opacity = 90.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;
            for (int i = 0; i < 10; i++)
            {
                fname = "Alert" + i.ToString();
                frm_Form_Alert frm = (frm_Form_Alert)Application.OpenForms[fname];
                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
            this.lblMsg.Text = msg;
            this.Show();

        }
    }
}
