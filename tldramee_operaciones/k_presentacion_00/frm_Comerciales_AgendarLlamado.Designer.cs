namespace k_presentacion_00
{
    partial class frm_Comerciales_AgendarLlamado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pClose = new System.Windows.Forms.PictureBox();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.cboHorarios = new System.Windows.Forms.ComboBox();
            this.lblLlamado = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.Calendario_Reuniones = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.pClose)).BeginInit();
            this.SuspendLayout();
            // 
            // pClose
            // 
            this.pClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pClose.Image = global::k_presentacion_00.Properties.Resources.cross;
            this.pClose.Location = new System.Drawing.Point(435, 0);
            this.pClose.Name = "pClose";
            this.pClose.Size = new System.Drawing.Size(36, 25);
            this.pClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pClose.TabIndex = 32;
            this.pClose.TabStop = false;
            this.pClose.Click += new System.EventHandler(this.pClose_Click);
            // 
            // lblFormulario
            // 
            this.lblFormulario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormulario.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormulario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(33)))), ((int)(((byte)(24)))));
            this.lblFormulario.Location = new System.Drawing.Point(-1, 0);
            this.lblFormulario.Name = "lblFormulario";
            this.lblFormulario.Size = new System.Drawing.Size(439, 25);
            this.lblFormulario.TabIndex = 33;
            this.lblFormulario.Text = "Agendar Llamadas";
            this.lblFormulario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboHorarios
            // 
            this.cboHorarios.FormattingEnabled = true;
            this.cboHorarios.Location = new System.Drawing.Point(304, 34);
            this.cboHorarios.Name = "cboHorarios";
            this.cboHorarios.Size = new System.Drawing.Size(107, 21);
            this.cboHorarios.TabIndex = 35;
            this.cboHorarios.SelectedIndexChanged += new System.EventHandler(this.cboHorarios_SelectedIndexChanged);
            // 
            // lblLlamado
            // 
            this.lblLlamado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLlamado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLlamado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(33)))), ((int)(((byte)(24)))));
            this.lblLlamado.Location = new System.Drawing.Point(13, 205);
            this.lblLlamado.Name = "lblLlamado";
            this.lblLlamado.Size = new System.Drawing.Size(439, 77);
            this.lblLlamado.TabIndex = 36;
            this.lblLlamado.Text = "Agendar Llamadas";
            this.lblLlamado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(16, 208);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(116, 20);
            this.txtFecha.TabIndex = 37;
            this.txtFecha.Visible = false;
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Location = new System.Drawing.Point(190, 301);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(97, 40);
            this.cmdGuardar.TabIndex = 38;
            this.cmdGuardar.Text = "Agendar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // Calendario_Reuniones
            // 
            this.Calendario_Reuniones.Location = new System.Drawing.Point(16, 34);
            this.Calendario_Reuniones.Name = "Calendario_Reuniones";
            this.Calendario_Reuniones.TabIndex = 39;
            this.Calendario_Reuniones.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.Calendario_Reuniones_DateSelected);
            // 
            // frm_Comerciales_AgendarLlamado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(216)))), ((int)(((byte)(171)))));
            this.ClientSize = new System.Drawing.Size(471, 353);
            this.Controls.Add(this.Calendario_Reuniones);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.lblLlamado);
            this.Controls.Add(this.cboHorarios);
            this.Controls.Add(this.lblFormulario);
            this.Controls.Add(this.pClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Comerciales_AgendarLlamado";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Comerciales_AgendarLlamado";
            ((System.ComponentModel.ISupportInitialize)(this.pClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pClose;
        public System.Windows.Forms.Label lblFormulario;
        public System.Windows.Forms.Label lblLlamado;
        public System.Windows.Forms.TextBox txtFecha;
        public System.Windows.Forms.ComboBox cboHorarios;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.MonthCalendar Calendario_Reuniones;
    }
}