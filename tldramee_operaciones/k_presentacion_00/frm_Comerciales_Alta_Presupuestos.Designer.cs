namespace k_presentacion_00
{
    partial class frm_Comerciales_Alta_Presupuestos
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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.cboTipoServicio = new System.Windows.Forms.ComboBox();
            this.cboRutas = new System.Windows.Forms.ComboBox();
            this.cboVendedores = new System.Windows.Forms.ComboBox();
            this.cboCondicionPago = new System.Windows.Forms.ComboBox();
            this.cboMercaderias = new System.Windows.Forms.ComboBox();
            this.cboDuracion = new System.Windows.Forms.ComboBox();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.cmdLimpiar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtContedores = new k_TextBox_Num.k_textbox_n();
            this.txtPeso = new k_TextBox_Num.k_textbox_n();
            this.cboPresupuesto = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboContactos = new System.Windows.Forms.ComboBox();
            this.cboRazonSocial = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtVenta = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtMKP = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.mFecha = new System.Windows.Forms.MaskedTextBox();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboModalidad = new System.Windows.Forms.ComboBox();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.cboContenedores = new System.Windows.Forms.ComboBox();
            this.mFechaVencimiento = new System.Windows.Forms.MaskedTextBox();
            this.k_dias_Validez = new k_TextBox_Num.k_textbox_n();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtEstadia = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblDiasValidez = new System.Windows.Forms.Label();
            this.cmdUCt = new System.Windows.Forms.Button();
            this.cmdAC = new System.Windows.Forms.Button();
            this.cmdUC = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.mFechaVigDesde = new System.Windows.Forms.MaskedTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.dg = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
            this.lblUsuario.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblUsuario.Location = new System.Drawing.Point(385, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(283, 18);
            this.lblUsuario.TabIndex = 65;
            this.lblUsuario.Text = "label1";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUsuario.Visible = false;
            // 
            // cboTipoServicio
            // 
            this.cboTipoServicio.FormattingEnabled = true;
            this.cboTipoServicio.Location = new System.Drawing.Point(58, 187);
            this.cboTipoServicio.Name = "cboTipoServicio";
            this.cboTipoServicio.Size = new System.Drawing.Size(161, 23);
            this.cboTipoServicio.TabIndex = 4;
            this.cboTipoServicio.SelectedIndexChanged += new System.EventHandler(this.cboTipoServicio_SelectedIndexChanged);
            // 
            // cboRutas
            // 
            this.cboRutas.DropDownWidth = 500;
            this.cboRutas.FormattingEnabled = true;
            this.cboRutas.Location = new System.Drawing.Point(410, 187);
            this.cboRutas.Name = "cboRutas";
            this.cboRutas.Size = new System.Drawing.Size(230, 23);
            this.cboRutas.TabIndex = 6;
            this.cboRutas.SelectedIndexChanged += new System.EventHandler(this.cboRutas_SelectedIndexChanged);
            // 
            // cboVendedores
            // 
            this.cboVendedores.FormattingEnabled = true;
            this.cboVendedores.Location = new System.Drawing.Point(210, 293);
            this.cboVendedores.Name = "cboVendedores";
            this.cboVendedores.Size = new System.Drawing.Size(194, 23);
            this.cboVendedores.TabIndex = 11;
            this.cboVendedores.SelectedIndexChanged += new System.EventHandler(this.cboVendedores_SelectedIndexChanged);
            // 
            // cboCondicionPago
            // 
            this.cboCondicionPago.FormattingEnabled = true;
            this.cboCondicionPago.Location = new System.Drawing.Point(298, 503);
            this.cboCondicionPago.Name = "cboCondicionPago";
            this.cboCondicionPago.Size = new System.Drawing.Size(243, 23);
            this.cboCondicionPago.TabIndex = 6;
            this.cboCondicionPago.Visible = false;
            this.cboCondicionPago.SelectedIndexChanged += new System.EventHandler(this.cboCondicionPago_SelectedIndexChanged);
            // 
            // cboMercaderias
            // 
            this.cboMercaderias.FormattingEnabled = true;
            this.cboMercaderias.Location = new System.Drawing.Point(433, 293);
            this.cboMercaderias.Name = "cboMercaderias";
            this.cboMercaderias.Size = new System.Drawing.Size(208, 23);
            this.cboMercaderias.TabIndex = 12;
            this.cboMercaderias.SelectedIndexChanged += new System.EventHandler(this.cboMercaderia_SelectedIndexChanged);
            // 
            // cboDuracion
            // 
            this.cboDuracion.FormattingEnabled = true;
            this.cboDuracion.Location = new System.Drawing.Point(58, 293);
            this.cboDuracion.Name = "cboDuracion";
            this.cboDuracion.Size = new System.Drawing.Size(150, 23);
            this.cboDuracion.TabIndex = 10;
            this.cboDuracion.SelectedIndexChanged += new System.EventHandler(this.cboDuracion_SelectedIndexChanged);
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Location = new System.Drawing.Point(20, 751);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(163, 49);
            this.cmdGuardar.TabIndex = 21;
            this.cmdGuardar.Text = "Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.CmdGuardar_Click);
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.Location = new System.Drawing.Point(428, 751);
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Size = new System.Drawing.Size(171, 49);
            this.cmdLimpiar.TabIndex = 23;
            this.cmdLimpiar.Text = "Limpiar";
            this.cmdLimpiar.UseVisualStyleBackColor = true;
            this.cmdLimpiar.Click += new System.EventHandler(this.CmdLimpiar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 83;
            this.label3.Text = "¿Tipo de Servicio?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(407, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 84;
            this.label4.Text = "¿Qué Ruta?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(295, 483);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 17);
            this.label5.TabIndex = 85;
            this.label5.Text = "¿Comó Paga?";
            this.label5.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(429, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 17);
            this.label7.TabIndex = 87;
            this.label7.Text = "¿Qué Mercadería llevamos?";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(58, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 17);
            this.label8.TabIndex = 88;
            this.label8.Text = "¿Cuánto dura el viaje?";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(188, 341);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 17);
            this.label9.TabIndex = 89;
            this.label9.Text = "¿El Peso Apróx? (Tn)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(58, 319);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 40);
            this.label10.TabIndex = 90;
            this.label10.Text = "¿Cuántos Contenedores?";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(221, 273);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 17);
            this.label11.TabIndex = 91;
            this.label11.Text = "¿Quién Vende?";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(19, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(245, 17);
            this.label12.TabIndex = 92;
            this.label12.Text = "Datos Necesarios para iniciar la Solicitud";
            // 
            // txtContedores
            // 
            this.txtContedores.Location = new System.Drawing.Point(58, 362);
            this.txtContedores.Name = "txtContedores";
            this.txtContedores.Size = new System.Drawing.Size(103, 24);
            this.txtContedores.TabIndex = 13;
            this.txtContedores.Text = "1";
            this.txtContedores.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(198, 363);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(103, 24);
            this.txtPeso.TabIndex = 14;
            this.txtPeso.Text = "0";
            this.txtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboPresupuesto
            // 
            this.cboPresupuesto.FormattingEnabled = true;
            this.cboPresupuesto.Location = new System.Drawing.Point(116, 35);
            this.cboPresupuesto.Name = "cboPresupuesto";
            this.cboPresupuesto.Size = new System.Drawing.Size(270, 23);
            this.cboPresupuesto.TabIndex = 1;
            this.cboPresupuesto.SelectedIndexChanged += new System.EventHandler(this.cboPresupuesto_SelectedIndexChanged_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(19, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 17);
            this.label13.TabIndex = 104;
            this.label13.Text = "Contactos";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(19, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 17);
            this.label14.TabIndex = 103;
            this.label14.Text = "Clientes";
            // 
            // cboContactos
            // 
            this.cboContactos.FormattingEnabled = true;
            this.cboContactos.Location = new System.Drawing.Point(116, 93);
            this.cboContactos.Name = "cboContactos";
            this.cboContactos.Size = new System.Drawing.Size(420, 23);
            this.cboContactos.TabIndex = 3;
            this.cboContactos.SelectedIndexChanged += new System.EventHandler(this.cboContactos_SelectedIndexChanged);
            // 
            // cboRazonSocial
            // 
            this.cboRazonSocial.FormattingEnabled = true;
            this.cboRazonSocial.Location = new System.Drawing.Point(116, 64);
            this.cboRazonSocial.Name = "cboRazonSocial";
            this.cboRazonSocial.Size = new System.Drawing.Size(420, 23);
            this.cboRazonSocial.TabIndex = 2;
            this.cboRazonSocial.Leave += new System.EventHandler(this.cboRazonSocial_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 105;
            this.label1.Text = "Presupuesto";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(58, 413);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 24);
            this.textBox1.TabIndex = 108;
            this.textBox1.Text = "$";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(58, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 107;
            this.label2.Text = "Costo del Viaje";
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(58, 413);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(138, 24);
            this.txtCosto.TabIndex = 16;
            this.txtCosto.Text = "0.00";
            this.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ENTER_KeyPress);
            this.txtCosto.Leave += new System.EventHandler(this.TxtCosto_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
            this.label15.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(368, 389);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 17);
            this.label15.TabIndex = 110;
            this.label15.Text = "Venta del Viaje";
            // 
            // txtVenta
            // 
            this.txtVenta.Location = new System.Drawing.Point(393, 413);
            this.txtVenta.Name = "txtVenta";
            this.txtVenta.Size = new System.Drawing.Size(100, 24);
            this.txtVenta.TabIndex = 18;
            this.txtVenta.Text = "0.00";
            this.txtVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ENTER_KeyPress);
            this.txtVenta.Leave += new System.EventHandler(this.txtVenta_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
            this.label16.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(245, 390);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 17);
            this.label16.TabIndex = 112;
            this.label16.Text = "Markup";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMKP
            // 
            this.txtMKP.Location = new System.Drawing.Point(219, 413);
            this.txtMKP.Name = "txtMKP";
            this.txtMKP.Size = new System.Drawing.Size(120, 24);
            this.txtMKP.TabIndex = 17;
            this.txtMKP.Text = "Markup";
            this.txtMKP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMKP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ENTER_KeyPress);
            this.txtMKP.Leave += new System.EventHandler(this.TxtMKP_Leave);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(359, 413);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(35, 24);
            this.textBox2.TabIndex = 113;
            this.textBox2.Text = "$";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mFecha
            // 
            this.mFecha.Location = new System.Drawing.Point(393, 35);
            this.mFecha.Mask = "00/00/0000";
            this.mFecha.Name = "mFecha";
            this.mFecha.Size = new System.Drawing.Size(70, 24);
            this.mFecha.TabIndex = 100;
            this.mFecha.ValidatingType = typeof(System.DateTime);
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(58, 466);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(582, 84);
            this.txtObservacion.TabIndex = 20;
            this.txtObservacion.Text = "Indique alguna observación (si lo desea)...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(228, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 17);
            this.label6.TabIndex = 116;
            this.label6.Text = "¿Modalidad?";
            // 
            // cboModalidad
            // 
            this.cboModalidad.FormattingEnabled = true;
            this.cboModalidad.Location = new System.Drawing.Point(231, 187);
            this.cboModalidad.Name = "cboModalidad";
            this.cboModalidad.Size = new System.Drawing.Size(161, 23);
            this.cboModalidad.TabIndex = 5;
            this.cboModalidad.SelectedIndexChanged += new System.EventHandler(this.cboModalidad_SelectedIndexChanged);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Location = new System.Drawing.Point(222, 751);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(179, 49);
            this.cmdImprimir.TabIndex = 22;
            this.cmdImprimir.Text = "Imprimir";
            this.cmdImprimir.UseVisualStyleBackColor = true;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(358, 342);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 17);
            this.label17.TabIndex = 119;
            this.label17.Text = "Contenedor";
            // 
            // cboContenedores
            // 
            this.cboContenedores.FormattingEnabled = true;
            this.cboContenedores.Location = new System.Drawing.Point(357, 362);
            this.cboContenedores.Name = "cboContenedores";
            this.cboContenedores.Size = new System.Drawing.Size(148, 23);
            this.cboContenedores.TabIndex = 15;
            this.cboContenedores.SelectedIndexChanged += new System.EventHandler(this.cboContenedores_SelectedIndexChanged_1);
            // 
            // mFechaVencimiento
            // 
            this.mFechaVencimiento.Location = new System.Drawing.Point(273, 233);
            this.mFechaVencimiento.Mask = "00/00/0000";
            this.mFechaVencimiento.Name = "mFechaVencimiento";
            this.mFechaVencimiento.Size = new System.Drawing.Size(87, 24);
            this.mFechaVencimiento.TabIndex = 9;
            this.mFechaVencimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mFechaVencimiento.ValidatingType = typeof(System.DateTime);
            this.mFechaVencimiento.Leave += new System.EventHandler(this.mFechaVencimiento_Leave);
            // 
            // k_dias_Validez
            // 
            this.k_dias_Validez.Location = new System.Drawing.Point(172, 233);
            this.k_dias_Validez.Name = "k_dias_Validez";
            this.k_dias_Validez.Size = new System.Drawing.Size(78, 24);
            this.k_dias_Validez.TabIndex = 8;
            this.k_dias_Validez.Text = "30";
            this.k_dias_Validez.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.k_dias_Validez.Leave += new System.EventHandler(this.k_dias_Validez_Leave);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(506, 413);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(35, 24);
            this.textBox3.TabIndex = 124;
            this.textBox3.Text = "$";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
            this.label18.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(515, 389);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(84, 17);
            this.label18.TabIndex = 123;
            this.label18.Text = "Valor Estadía";
            // 
            // txtEstadia
            // 
            this.txtEstadia.Location = new System.Drawing.Point(540, 413);
            this.txtEstadia.Name = "txtEstadia";
            this.txtEstadia.Size = new System.Drawing.Size(100, 24);
            this.txtEstadia.TabIndex = 19;
            this.txtEstadia.Text = "0.00";
            this.txtEstadia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
            this.label19.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(270, 213);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(94, 17);
            this.label19.TabIndex = 125;
            this.label19.Text = "Vigencia Hasta";
            // 
            // lblDiasValidez
            // 
            this.lblDiasValidez.AutoSize = true;
            this.lblDiasValidez.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
            this.lblDiasValidez.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDiasValidez.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiasValidez.ForeColor = System.Drawing.Color.Black;
            this.lblDiasValidez.Location = new System.Drawing.Point(169, 213);
            this.lblDiasValidez.Name = "lblDiasValidez";
            this.lblDiasValidez.Size = new System.Drawing.Size(95, 17);
            this.lblDiasValidez.TabIndex = 126;
            this.lblDiasValidez.Text = "Días de Validez";
            // 
            // cmdUCt
            // 
            this.cmdUCt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
            this.cmdUCt.FlatAppearance.BorderSize = 0;
            this.cmdUCt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdUCt.Image = global::k_presentacion_00.Properties.Resources.pngocean1;
            this.cmdUCt.Location = new System.Drawing.Point(540, 92);
            this.cmdUCt.Name = "cmdUCt";
            this.cmdUCt.Size = new System.Drawing.Size(25, 25);
            this.cmdUCt.TabIndex = 101;
            this.cmdUCt.UseVisualStyleBackColor = false;
            this.cmdUCt.Click += new System.EventHandler(this.cmdUCt_Click);
            // 
            // cmdAC
            // 
            this.cmdAC.AutoSize = true;
            this.cmdAC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
            this.cmdAC.FlatAppearance.BorderSize = 0;
            this.cmdAC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAC.ForeColor = System.Drawing.Color.White;
            this.cmdAC.Image = global::k_presentacion_00.Properties.Resources.pngocean_com16;
            this.cmdAC.Location = new System.Drawing.Point(591, 62);
            this.cmdAC.Name = "cmdAC";
            this.cmdAC.Size = new System.Drawing.Size(25, 25);
            this.cmdAC.TabIndex = 100;
            this.cmdAC.UseVisualStyleBackColor = false;
            this.cmdAC.Click += new System.EventHandler(this.cmdAC_Click);
            // 
            // cmdUC
            // 
            this.cmdUC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
            this.cmdUC.FlatAppearance.BorderSize = 0;
            this.cmdUC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdUC.Image = global::k_presentacion_00.Properties.Resources.pngocean1;
            this.cmdUC.Location = new System.Drawing.Point(540, 62);
            this.cmdUC.Name = "cmdUC";
            this.cmdUC.Size = new System.Drawing.Size(25, 25);
            this.cmdUC.TabIndex = 99;
            this.cmdUC.UseVisualStyleBackColor = false;
            this.cmdUC.Click += new System.EventHandler(this.cmdUC_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.FlatAppearance.BorderSize = 0;
            this.cmdAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAgregar.ForeColor = System.Drawing.Color.White;
            this.cmdAgregar.Image = global::k_presentacion_00.Properties.Resources.pngocean_com16;
            this.cmdAgregar.Location = new System.Drawing.Point(643, 288);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(25, 25);
            this.cmdAgregar.TabIndex = 95;
            this.cmdAgregar.UseVisualStyleBackColor = true;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
            this.label20.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(58, 213);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(97, 17);
            this.label20.TabIndex = 128;
            this.label20.Text = "Vigencia Desde";
            // 
            // mFechaVigDesde
            // 
            this.mFechaVigDesde.Location = new System.Drawing.Point(58, 233);
            this.mFechaVigDesde.Mask = "00/00/0000";
            this.mFechaVigDesde.Name = "mFechaVigDesde";
            this.mFechaVigDesde.Size = new System.Drawing.Size(92, 24);
            this.mFechaVigDesde.TabIndex = 7;
            this.mFechaVigDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mFechaVigDesde.ValidatingType = typeof(System.DateTime);
            this.mFechaVigDesde.Leave += new System.EventHandler(this.mFechaVigDesde_Leave);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(21, 693);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(158, 17);
            this.label21.TabIndex = 130;
            this.label21.Text = "Situación de la Cotización";
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(20, 713);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(148, 23);
            this.cboEstado.TabIndex = 129;
            // 
            // cboItem
            // 
            this.cboItem.FormattingEnabled = true;
            this.cboItem.Location = new System.Drawing.Point(120, 566);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(148, 23);
            this.cboItem.TabIndex = 131;
            this.cboItem.SelectedIndexChanged += new System.EventHandler(this.cboItem_SelectedIndexChanged);
            this.cboItem.SelectedValueChanged += new System.EventHandler(this.cboItem_SelectedValueChanged);
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(19, 572);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(95, 17);
            this.lblItem.TabIndex = 132;
            this.lblItem.Text = "Concepto Item";
            // 
            // dg
            // 
            this.dg.AllowUserToAddRows = false;
            this.dg.BackgroundColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Location = new System.Drawing.Point(22, 595);
            this.dg.Name = "dg";
            this.dg.Size = new System.Drawing.Size(618, 88);
            this.dg.TabIndex = 133;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Black;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ForeColor = System.Drawing.Color.Black;
            this.btnAgregar.Image = global::k_presentacion_00.Properties.Resources.descarga;
            this.btnAgregar.Location = new System.Drawing.Point(293, 564);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(24, 24);
            this.btnAgregar.TabIndex = 134;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // frm_Comerciales_Alta_Presupuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(752, 812);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dg);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.cboItem);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.mFechaVigDesde);
            this.Controls.Add(this.lblDiasValidez);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtEstadia);
            this.Controls.Add(this.k_dias_Validez);
            this.Controls.Add(this.mFechaVencimiento);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cboContenedores);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboModalidad);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.mFecha);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtMKP);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtVenta);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmdUCt);
            this.Controls.Add(this.cmdAC);
            this.Controls.Add(this.cmdUC);
            this.Controls.Add(this.cboContactos);
            this.Controls.Add(this.cboRazonSocial);
            this.Controls.Add(this.cboPresupuesto);
            this.Controls.Add(this.cmdAgregar);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.txtContedores);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdLimpiar);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.cboDuracion);
            this.Controls.Add(this.cboMercaderias);
            this.Controls.Add(this.cboCondicionPago);
            this.Controls.Add(this.cboVendedores);
            this.Controls.Add(this.cboRutas);
            this.Controls.Add(this.cboTipoServicio);
            this.Controls.Add(this.lblUsuario);
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frm_Comerciales_Alta_Presupuestos";
            this.Text = "Solicitud de Transporte";
            this.Load += new System.EventHandler(this.Frm_Comerciales_Alta_Presupuestos_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_Comerciales_Alta_Presupuestos_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ComboBox cboTipoServicio;
        private System.Windows.Forms.ComboBox cboRutas;
        private System.Windows.Forms.ComboBox cboVendedores;
        private System.Windows.Forms.ComboBox cboCondicionPago;
        private System.Windows.Forms.ComboBox cboMercaderias;
        private System.Windows.Forms.ComboBox cboDuracion;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Button cmdLimpiar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private k_TextBox_Num.k_textbox_n txtContedores;
        private k_TextBox_Num.k_textbox_n txtPeso;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.ComboBox cboPresupuesto;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button cmdUCt;
        private System.Windows.Forms.Button cmdAC;
        private System.Windows.Forms.Button cmdUC;
        private System.Windows.Forms.ComboBox cboContactos;
        private System.Windows.Forms.ComboBox cboRazonSocial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtVenta;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtMKP;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.MaskedTextBox mFecha;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboModalidad;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cboContenedores;
        private System.Windows.Forms.MaskedTextBox mFechaVencimiento;
        private k_TextBox_Num.k_textbox_n k_dias_Validez;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtEstadia;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblDiasValidez;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.MaskedTextBox mFechaVigDesde;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.ComboBox cboItem;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.Button btnAgregar;
    }
}