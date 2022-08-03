namespace k_presentacion_00
{
    partial class frm_abm_elementos
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.cboPais = new System.Windows.Forms.ComboBox();
            this.txtElementos = new System.Windows.Forms.TextBox();
            this.cboElementos = new System.Windows.Forms.ComboBox();
            this.gb = new System.Windows.Forms.GroupBox();
            this.opRetorno = new System.Windows.Forms.RadioButton();
            this.opDestino = new System.Windows.Forms.RadioButton();
            this.opOrigen = new System.Windows.Forms.RadioButton();
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdGuadar = new System.Windows.Forms.Button();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdCerrar = new System.Windows.Forms.Button();
            this.pClose = new System.Windows.Forms.PictureBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pClose)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(27, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "Localidad";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(27, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 23);
            this.label3.TabIndex = 17;
            this.label3.Text = "Provincia";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "Pais";
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(152, 250);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(285, 25);
            this.cboLocalidad.TabIndex = 4;
            // 
            // cboProvincia
            // 
            this.cboProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(152, 207);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(285, 25);
            this.cboProvincia.TabIndex = 3;
            // 
            // cboPais
            // 
            this.cboPais.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(152, 164);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(286, 25);
            this.cboPais.TabIndex = 2;
            // 
            // txtElementos
            // 
            this.txtElementos.Location = new System.Drawing.Point(150, 115);
            this.txtElementos.Name = "txtElementos";
            this.txtElementos.Size = new System.Drawing.Size(288, 24);
            this.txtElementos.TabIndex = 19;
            // 
            // cboElementos
            // 
            this.cboElementos.FormattingEnabled = true;
            this.cboElementos.Location = new System.Drawing.Point(150, 114);
            this.cboElementos.Name = "cboElementos";
            this.cboElementos.Size = new System.Drawing.Size(288, 25);
            this.cboElementos.TabIndex = 1;
            // 
            // gb
            // 
            this.gb.Controls.Add(this.opRetorno);
            this.gb.Controls.Add(this.opDestino);
            this.gb.Controls.Add(this.opOrigen);
            this.gb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gb.ForeColor = System.Drawing.Color.White;
            this.gb.Location = new System.Drawing.Point(30, 37);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(449, 60);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            this.gb.Text = "Opción de Filtros";
            // 
            // opRetorno
            // 
            this.opRetorno.AutoSize = true;
            this.opRetorno.ForeColor = System.Drawing.Color.White;
            this.opRetorno.Location = new System.Drawing.Point(326, 23);
            this.opRetorno.Name = "opRetorno";
            this.opRetorno.Size = new System.Drawing.Size(81, 23);
            this.opRetorno.TabIndex = 2;
            this.opRetorno.Text = "Retorno";
            this.opRetorno.UseVisualStyleBackColor = true;
            this.opRetorno.CheckedChanged += new System.EventHandler(this.opicion_CheckedChanged);
            // 
            // opDestino
            // 
            this.opDestino.AutoSize = true;
            this.opDestino.ForeColor = System.Drawing.Color.White;
            this.opDestino.Location = new System.Drawing.Point(181, 23);
            this.opDestino.Name = "opDestino";
            this.opDestino.Size = new System.Drawing.Size(77, 23);
            this.opDestino.TabIndex = 1;
            this.opDestino.Text = "Destino";
            this.opDestino.UseVisualStyleBackColor = true;
            this.opDestino.CheckedChanged += new System.EventHandler(this.opicion_CheckedChanged);
            // 
            // opOrigen
            // 
            this.opOrigen.AutoSize = true;
            this.opOrigen.Checked = true;
            this.opOrigen.ForeColor = System.Drawing.Color.White;
            this.opOrigen.Location = new System.Drawing.Point(31, 23);
            this.opOrigen.Name = "opOrigen";
            this.opOrigen.Size = new System.Drawing.Size(73, 23);
            this.opOrigen.TabIndex = 0;
            this.opOrigen.TabStop = true;
            this.opOrigen.Text = "Origen";
            this.opOrigen.UseVisualStyleBackColor = true;
            this.opOrigen.CheckedChanged += new System.EventHandler(this.opicion_CheckedChanged);
            // 
            // cmdNew
            // 
            this.cmdNew.Location = new System.Drawing.Point(30, 411);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(126, 40);
            this.cmdNew.TabIndex = 7;
            this.cmdNew.Text = "Nuevo";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdGuadar
            // 
            this.cmdGuadar.Location = new System.Drawing.Point(180, 411);
            this.cmdGuadar.Name = "cmdGuadar";
            this.cmdGuadar.Size = new System.Drawing.Size(108, 40);
            this.cmdGuadar.TabIndex = 6;
            this.cmdGuadar.Text = "Guardar";
            this.cmdGuadar.UseVisualStyleBackColor = true;
            this.cmdGuadar.Click += new System.EventHandler(this.cmdGuadar_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(150, 294);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(286, 72);
            this.txtDireccion.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(27, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 35);
            this.label2.TabIndex = 25;
            this.label2.Text = "Dirección u Observaciones";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(27, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 23);
            this.label5.TabIndex = 26;
            this.label5.Text = "Nombre";
            // 
            // cmdCerrar
            // 
            this.cmdCerrar.Location = new System.Drawing.Point(330, 411);
            this.cmdCerrar.Name = "cmdCerrar";
            this.cmdCerrar.Size = new System.Drawing.Size(108, 40);
            this.cmdCerrar.TabIndex = 8;
            this.cmdCerrar.Text = "Cerrar";
            this.cmdCerrar.UseVisualStyleBackColor = true;
            this.cmdCerrar.Click += new System.EventHandler(this.cmdCerrar_Click);
            // 
            // pClose
            // 
            this.pClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pClose.Image = global::k_presentacion_00.Properties.Resources.cerrar;
            this.pClose.Location = new System.Drawing.Point(491, 1);
            this.pClose.Name = "pClose";
            this.pClose.Size = new System.Drawing.Size(24, 18);
            this.pClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pClose.TabIndex = 28;
            this.pClose.TabStop = false;
            this.pClose.Click += new System.EventHandler(this.pClose_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.White;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblUsuario.Location = new System.Drawing.Point(5, 1);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(283, 18);
            this.lblUsuario.TabIndex = 29;
            this.lblUsuario.Text = "label1";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_abm_elementos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(517, 463);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pClose);
            this.Controls.Add(this.cmdCerrar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.cmdGuadar);
            this.Controls.Add(this.cmdNew);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.cboElementos);
            this.Controls.Add(this.txtElementos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboLocalidad);
            this.Controls.Add(this.cboProvincia);
            this.Controls.Add(this.cboPais);
            this.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.SteelBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_abm_elementos";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_ABM_Elementos";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_ABM_Elementos_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_ABM_Elementos_MouseDown);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.ComboBox cboPais;
        private System.Windows.Forms.TextBox txtElementos;
        private System.Windows.Forms.ComboBox cboElementos;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.RadioButton opRetorno;
        private System.Windows.Forms.RadioButton opDestino;
        private System.Windows.Forms.RadioButton opOrigen;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.Button cmdGuadar;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdCerrar;
        private System.Windows.Forms.PictureBox pClose;
        private System.Windows.Forms.Label lblUsuario;
    }
}