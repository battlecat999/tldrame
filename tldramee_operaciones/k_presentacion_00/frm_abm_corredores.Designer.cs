namespace k_presentacion_00
{
    partial class frm_abm_corredores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_abm_corredores));
            this.cboOrigen = new System.Windows.Forms.ComboBox();
            this.cboDestino = new System.Windows.Forms.ComboBox();
            this.cboRetorno = new System.Windows.Forms.ComboBox();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.TTA_Transporte = new k_TextBox_Num.k_textbox_n();
            this.TTA_Cliente = new k_TextBox_Num.k_textbox_n();
            this.c_Activo = new System.Windows.Forms.CheckBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.c_Tipo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdGuadar = new System.Windows.Forms.Button();
            this.cmdEditar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRoundTrip = new k_TextBox_Num.k_textbox_n();
            this.txtOneWay = new k_TextBox_Num.k_textbox_n();
            this.pClose = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtIdCorredor = new k_TextBox_Num.k_textbox_n();
            this.lblmensaje = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pminimizar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pminimizar)).BeginInit();
            this.SuspendLayout();
            // 
            // cboOrigen
            // 
            this.cboOrigen.FormattingEnabled = true;
            this.cboOrigen.Location = new System.Drawing.Point(21, 78);
            this.cboOrigen.Name = "cboOrigen";
            this.cboOrigen.Size = new System.Drawing.Size(280, 25);
            this.cboOrigen.TabIndex = 0;
            // 
            // cboDestino
            // 
            this.cboDestino.FormattingEnabled = true;
            this.cboDestino.Location = new System.Drawing.Point(335, 78);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Size = new System.Drawing.Size(268, 25);
            this.cboDestino.TabIndex = 1;
            // 
            // cboRetorno
            // 
            this.cboRetorno.FormattingEnabled = true;
            this.cboRetorno.Location = new System.Drawing.Point(650, 78);
            this.cboRetorno.Name = "cboRetorno";
            this.cboRetorno.Size = new System.Drawing.Size(238, 25);
            this.cboRetorno.TabIndex = 2;
            // 
            // dgw
            // 
            this.dgw.AllowUserToOrderColumns = true;
            this.dgw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgw.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgw.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dgw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgw.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgw.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgw.ColumnHeadersHeight = 40;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgw.EnableHeadersVisualStyles = false;
            this.dgw.GridColor = System.Drawing.Color.SteelBlue;
            this.dgw.Location = new System.Drawing.Point(26, 250);
            this.dgw.Name = "dgw";
            this.dgw.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgw.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgw.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(1042, 335);
            this.dgw.TabIndex = 21;
            // 
            // TTA_Transporte
            // 
            this.TTA_Transporte.Location = new System.Drawing.Point(357, 137);
            this.TTA_Transporte.Name = "TTA_Transporte";
            this.TTA_Transporte.Size = new System.Drawing.Size(107, 24);
            this.TTA_Transporte.TabIndex = 5;
            this.TTA_Transporte.Text = "TTA_Transporte";
            this.TTA_Transporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TTA_Cliente
            // 
            this.TTA_Cliente.Location = new System.Drawing.Point(495, 137);
            this.TTA_Cliente.Name = "TTA_Cliente";
            this.TTA_Cliente.Size = new System.Drawing.Size(121, 24);
            this.TTA_Cliente.TabIndex = 6;
            this.TTA_Cliente.Text = "TTA_Cliente";
            this.TTA_Cliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // c_Activo
            // 
            this.c_Activo.AutoSize = true;
            this.c_Activo.ForeColor = System.Drawing.Color.White;
            this.c_Activo.Location = new System.Drawing.Point(305, 176);
            this.c_Activo.Name = "c_Activo";
            this.c_Activo.Size = new System.Drawing.Size(71, 23);
            this.c_Activo.TabIndex = 9;
            this.c_Activo.Text = "Activo";
            this.c_Activo.UseVisualStyleBackColor = true;
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(678, 137);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(120, 24);
            this.txtCosto.TabIndex = 7;
            this.txtCosto.Text = "Costo";
            this.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCosto.Enter += new System.EventHandler(this.TextBoxFormattedOnEnter);
            this.txtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxChangeOnKeyPress);
            this.txtCosto.Leave += new System.EventHandler(this.TextBoxFormattedOnLeave);
            // 
            // c_Tipo
            // 
            this.c_Tipo.AutoSize = true;
            this.c_Tipo.ForeColor = System.Drawing.Color.White;
            this.c_Tipo.Location = new System.Drawing.Point(76, 176);
            this.c_Tipo.Name = "c_Tipo";
            this.c_Tipo.Size = new System.Drawing.Size(163, 23);
            this.c_Tipo.TabIndex = 8;
            this.c_Tipo.Text = "¿Vuelta Completa?";
            this.c_Tipo.UseVisualStyleBackColor = true;
            this.c_Tipo.CheckedChanged += new System.EventHandler(this.c_Tipo_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Origen del Viaje";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(332, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(271, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Destino del Viaje";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(647, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Retorno A...";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(354, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "T.T.A Transporte";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(492, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "T.T.A Cliente";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(642, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Costo del Viaje";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(23, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(257, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Detalle de Viajes...";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(23, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mantenimiento de Rutas";
            // 
            // cmdGuadar
            // 
            this.cmdGuadar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.cmdGuadar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGuadar.ForeColor = System.Drawing.Color.White;
            this.cmdGuadar.Location = new System.Drawing.Point(890, 208);
            this.cmdGuadar.Name = "cmdGuadar";
            this.cmdGuadar.Size = new System.Drawing.Size(178, 34);
            this.cmdGuadar.TabIndex = 11;
            this.cmdGuadar.Text = "Guardar";
            this.cmdGuadar.UseVisualStyleBackColor = false;
            this.cmdGuadar.Click += new System.EventHandler(this.cmdGuadar_Click);
            // 
            // cmdEditar
            // 
            this.cmdEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.cmdEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEditar.ForeColor = System.Drawing.Color.White;
            this.cmdEditar.Location = new System.Drawing.Point(26, 591);
            this.cmdEditar.Name = "cmdEditar";
            this.cmdEditar.Size = new System.Drawing.Size(178, 34);
            this.cmdEditar.TabIndex = 19;
            this.cmdEditar.Text = "Editar";
            this.cmdEditar.UseVisualStyleBackColor = false;
            this.cmdEditar.Click += new System.EventHandler(this.cmdEditar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSalir.ForeColor = System.Drawing.Color.White;
            this.cmdSalir.Location = new System.Drawing.Point(890, 591);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(178, 34);
            this.cmdSalir.TabIndex = 20;
            this.cmdSalir.Text = "Cerrar";
            this.cmdSalir.UseVisualStyleBackColor = false;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.cmdAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAgregar.ForeColor = System.Drawing.Color.White;
            this.cmdAgregar.Location = new System.Drawing.Point(926, 78);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(93, 31);
            this.cmdAgregar.TabIndex = 10;
            this.cmdAgregar.Text = "Agregar...";
            this.cmdAgregar.UseVisualStyleBackColor = false;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(211, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "KM Ida y Vuelta (RT)";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(73, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 20);
            this.label10.TabIndex = 24;
            this.label10.Text = "K.M Ida (OW)";
            // 
            // txtRoundTrip
            // 
            this.txtRoundTrip.Location = new System.Drawing.Point(214, 137);
            this.txtRoundTrip.Name = "txtRoundTrip";
            this.txtRoundTrip.Size = new System.Drawing.Size(121, 24);
            this.txtRoundTrip.TabIndex = 4;
            this.txtRoundTrip.Text = "RoundTrip";
            this.txtRoundTrip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtOneWay
            // 
            this.txtOneWay.Location = new System.Drawing.Point(76, 137);
            this.txtOneWay.Name = "txtOneWay";
            this.txtOneWay.Size = new System.Drawing.Size(107, 24);
            this.txtOneWay.TabIndex = 3;
            this.txtOneWay.Text = "OneWay";
            this.txtOneWay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pClose
            // 
            this.pClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pClose.Image = global::k_presentacion_00.Properties.Resources.cerrar;
            this.pClose.Location = new System.Drawing.Point(1044, 3);
            this.pClose.Name = "pClose";
            this.pClose.Size = new System.Drawing.Size(24, 18);
            this.pClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pClose.TabIndex = 29;
            this.pClose.TabStop = false;
            this.pClose.Click += new System.EventHandler(this.pClose_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(645, 137);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 24);
            this.textBox1.TabIndex = 30;
            this.textBox1.Text = "$";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIdCorredor
            // 
            this.txtIdCorredor.Location = new System.Drawing.Point(826, 137);
            this.txtIdCorredor.Name = "txtIdCorredor";
            this.txtIdCorredor.Size = new System.Drawing.Size(107, 24);
            this.txtIdCorredor.TabIndex = 31;
            this.txtIdCorredor.Text = "idCorredor";
            this.txtIdCorredor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdCorredor.Visible = false;
            // 
            // lblmensaje
            // 
            this.lblmensaje.BackColor = System.Drawing.Color.GreenYellow;
            this.lblmensaje.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmensaje.ForeColor = System.Drawing.Color.DarkRed;
            this.lblmensaje.Location = new System.Drawing.Point(164, 212);
            this.lblmensaje.Name = "lblmensaje";
            this.lblmensaje.Size = new System.Drawing.Size(706, 23);
            this.lblmensaje.TabIndex = 32;
            this.lblmensaje.Text = "Destino del Viaje";
            this.lblmensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblmensaje.Visible = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.White;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblUsuario.Location = new System.Drawing.Point(723, 3);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(283, 18);
            this.lblUsuario.TabIndex = 36;
            this.lblUsuario.Text = "label1";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pminimizar
            // 
            this.pminimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pminimizar.Image = ((System.Drawing.Image)(resources.GetObject("pminimizar.Image")));
            this.pminimizar.Location = new System.Drawing.Point(1018, 3);
            this.pminimizar.Name = "pminimizar";
            this.pminimizar.Size = new System.Drawing.Size(20, 18);
            this.pminimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pminimizar.TabIndex = 37;
            this.pminimizar.TabStop = false;
            // 
            // frm_abm_corredores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(1076, 637);
            this.Controls.Add(this.pminimizar);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblmensaje);
            this.Controls.Add(this.txtIdCorredor);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pClose);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtRoundTrip);
            this.Controls.Add(this.txtOneWay);
            this.Controls.Add(this.cmdAgregar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdEditar);
            this.Controls.Add(this.cmdGuadar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c_Tipo);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.c_Activo);
            this.Controls.Add(this.TTA_Cliente);
            this.Controls.Add(this.TTA_Transporte);
            this.Controls.Add(this.dgw);
            this.Controls.Add(this.cboRetorno);
            this.Controls.Add(this.cboDestino);
            this.Controls.Add(this.cboOrigen);
            this.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_abm_corredores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_abm_corredores";
            this.Load += new System.EventHandler(this.frm_abm_corredores_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_abm_corredores_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pminimizar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboOrigen;
        private System.Windows.Forms.ComboBox cboDestino;
        private System.Windows.Forms.ComboBox cboRetorno;
        private System.Windows.Forms.DataGridView dgw;
        private k_TextBox_Num.k_textbox_n TTA_Transporte;
        private k_TextBox_Num.k_textbox_n TTA_Cliente;
        private System.Windows.Forms.CheckBox c_Activo;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.CheckBox c_Tipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdGuadar;
        private System.Windows.Forms.Button cmdEditar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private k_TextBox_Num.k_textbox_n txtRoundTrip;
        private k_TextBox_Num.k_textbox_n txtOneWay;
        private System.Windows.Forms.PictureBox pClose;
        private System.Windows.Forms.TextBox textBox1;
        private k_TextBox_Num.k_textbox_n txtIdCorredor;
        private System.Windows.Forms.Label lblmensaje;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.PictureBox pminimizar;
    }
}