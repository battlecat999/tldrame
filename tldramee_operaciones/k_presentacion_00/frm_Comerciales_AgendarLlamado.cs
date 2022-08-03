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
    public partial class frm_Comerciales_AgendarLlamado : Form
    {
        public frm_Comerciales_AgendarLlamado()
        {
            InitializeComponent();
            cargarComboHorarios();
            ArmarLabel();
        }
        private void cargarComboHorarios()
        {
            this.cboHorarios.Items.Clear();
            for (int minutes = 0; minutes < 1440; minutes += 30)
            {
                string hours = new DateTime().AddMinutes(minutes).ToString("HH:mm");
                cboHorarios.Items.Add(hours);
            }
            cboHorarios.Text = DateTime.Now.ToString("HH:mm");
            this.txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void pClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Hide ();
        }
        private void ArmarLabel()
        {
            this.lblLlamado.Text = "Programar el llamado para " + this.Calendario_Reuniones.SelectionStart.ToLongDateString () + " en el horario de las " + this.cboHorarios.Text;
        }

        private void Calendario_ValueChanged(object sender, EventArgs e)
        {

            if(Convert.ToDateTime(this.Calendario_Reuniones.SelectionStart.ToShortDateString()) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
            {
                MessageBox.Show("La fecha Debe ser Mayor a la del día de HOY");
                return;
            }
            this.txtFecha.Text = this.Calendario_Reuniones.SelectionStart.ToString("dd/MM/yyyy");
            ArmarLabel();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (this.cboHorarios.Text==string.Empty )
            {
                MessageBox.Show("Debe seleccionar un horario o cancelar");
                return;
            }
            if (this.txtFecha.Text ==string.Empty )
            {
                MessageBox.Show("Debe seleccionar una fecha");
                return;
            }
            DialogResult = DialogResult.Yes;
        }

        private void cboHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArmarLabel();
        }

        private void Calendario_Reuniones_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.txtFecha.Text = this.Calendario_Reuniones.SelectionRange.Start.ToShortDateString();
        }
    }
}
