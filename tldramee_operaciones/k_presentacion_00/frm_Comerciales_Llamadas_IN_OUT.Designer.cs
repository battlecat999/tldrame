namespace k_presentacion_00
{
    partial class frm_Comerciales_Llamadas_IN_OUT
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
            this.txtFechaHora = new System.Windows.Forms.TextBox();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rPC = new System.Windows.Forms.RadioButton();
            this.rOperaciones = new System.Windows.Forms.RadioButton();
            this.rVentas = new System.Windows.Forms.RadioButton();
            this.cEnviaPorEmail = new System.Windows.Forms.CheckBox();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.lblFechaHora = new System.Windows.Forms.Label();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.pClose = new System.Windows.Forms.PictureBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtTipoLlamado = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pClose)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFechaHora
            // 
            this.txtFechaHora.Location = new System.Drawing.Point(119, 38);
            this.txtFechaHora.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFechaHora.Name = "txtFechaHora";
            this.txtFechaHora.Size = new System.Drawing.Size(322, 22);
            this.txtFechaHora.TabIndex = 0;
            // 
            // txtDetalle
            // 
            this.txtDetalle.Location = new System.Drawing.Point(14, 123);
            this.txtDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(427, 182);
            this.txtDetalle.TabIndex = 1;
            this.txtDetalle.Text = "Escriba Aquí....";
            this.txtDetalle.Enter += new System.EventHandler(this.txtDetalle_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rPC);
            this.groupBox1.Controls.Add(this.rOperaciones);
            this.groupBox1.Controls.Add(this.rVentas);
            this.groupBox1.Location = new System.Drawing.Point(12, 313);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(428, 66);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grupo de Opciones";
            // 
            // rPC
            // 
            this.rPC.AutoSize = true;
            this.rPC.Enabled = false;
            this.rPC.Location = new System.Drawing.Point(310, 23);
            this.rPC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rPC.Name = "rPC";
            this.rPC.Size = new System.Drawing.Size(67, 21);
            this.rPC.TabIndex = 2;
            this.rPC.Text = "Sin Uso";
            this.rPC.UseVisualStyleBackColor = true;
            this.rPC.CheckedChanged += new System.EventHandler(this.Selec_op_CheckedChanged);
            // 
            // rOperaciones
            // 
            this.rOperaciones.AutoSize = true;
            this.rOperaciones.Location = new System.Drawing.Point(163, 24);
            this.rOperaciones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rOperaciones.Name = "rOperaciones";
            this.rOperaciones.Size = new System.Drawing.Size(103, 21);
            this.rOperaciones.TabIndex = 1;
            this.rOperaciones.Text = "Operaciones";
            this.rOperaciones.UseVisualStyleBackColor = true;
            this.rOperaciones.CheckedChanged += new System.EventHandler(this.Selec_op_CheckedChanged);
            // 
            // rVentas
            // 
            this.rVentas.AutoSize = true;
            this.rVentas.Location = new System.Drawing.Point(18, 24);
            this.rVentas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rVentas.Name = "rVentas";
            this.rVentas.Size = new System.Drawing.Size(68, 21);
            this.rVentas.TabIndex = 0;
            this.rVentas.Text = "Ventas";
            this.rVentas.UseVisualStyleBackColor = true;
            this.rVentas.CheckedChanged += new System.EventHandler(this.Selec_op_CheckedChanged);
            // 
            // cEnviaPorEmail
            // 
            this.cEnviaPorEmail.AutoSize = true;
            this.cEnviaPorEmail.Location = new System.Drawing.Point(14, 392);
            this.cEnviaPorEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cEnviaPorEmail.Name = "cEnviaPorEmail";
            this.cEnviaPorEmail.Size = new System.Drawing.Size(116, 21);
            this.cEnviaPorEmail.TabIndex = 3;
            this.cEnviaPorEmail.Text = "Envia por Email";
            this.cEnviaPorEmail.UseVisualStyleBackColor = true;
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Location = new System.Drawing.Point(175, 387);
            this.cmdGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(112, 34);
            this.cmdGuardar.TabIndex = 4;
            this.cmdGuardar.Text = "Grabar y Cerrar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.AutoSize = true;
            this.lblFechaHora.Location = new System.Drawing.Point(18, 38);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(45, 17);
            this.lblFechaHora.TabIndex = 5;
            this.lblFechaHora.Text = "label1";
            // 
            // lblFormulario
            // 
            this.lblFormulario.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormulario.ForeColor = System.Drawing.Color.Red;
            this.lblFormulario.Location = new System.Drawing.Point(-1, -1);
            this.lblFormulario.Name = "lblFormulario";
            this.lblFormulario.Size = new System.Drawing.Size(426, 25);
            this.lblFormulario.TabIndex = 7;
            this.lblFormulario.Text = "label1";
            this.lblFormulario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pClose
            // 
            this.pClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pClose.Image = global::k_presentacion_00.Properties.Resources.cross1;
            this.pClose.Location = new System.Drawing.Point(431, 0);
            this.pClose.Name = "pClose";
            this.pClose.Size = new System.Drawing.Size(27, 19);
            this.pClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pClose.TabIndex = 31;
            this.pClose.TabStop = false;
            this.pClose.Click += new System.EventHandler(this.pClose_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.White;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblUsuario.Location = new System.Drawing.Point(11, 101);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(283, 18);
            this.lblUsuario.TabIndex = 36;
            this.lblUsuario.Text = "label1";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUsuario.Visible = false;
            // 
            // txtTipoLlamado
            // 
            this.txtTipoLlamado.Location = new System.Drawing.Point(364, 390);
            this.txtTipoLlamado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTipoLlamado.Name = "txtTipoLlamado";
            this.txtTipoLlamado.Size = new System.Drawing.Size(77, 22);
            this.txtTipoLlamado.TabIndex = 37;
            // 
            // frm_Comerciales_Llamadas_IN_OUT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 426);
            this.Controls.Add(this.txtTipoLlamado);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pClose);
            this.Controls.Add(this.lblFormulario);
            this.Controls.Add(this.lblFechaHora);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.cEnviaPorEmail);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDetalle);
            this.Controls.Add(this.txtFechaHora);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_Comerciales_Llamadas_IN_OUT";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo de Llamada";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rPC;
        private System.Windows.Forms.RadioButton rOperaciones;
        private System.Windows.Forms.RadioButton rVentas;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.PictureBox pClose;
        public System.Windows.Forms.TextBox txtFechaHora;
        public System.Windows.Forms.TextBox txtDetalle;
        public System.Windows.Forms.Label lblFormulario;
        private System.Windows.Forms.Label lblUsuario;
        public System.Windows.Forms.TextBox txtTipoLlamado;
        public System.Windows.Forms.CheckBox cEnviaPorEmail;
    }
}