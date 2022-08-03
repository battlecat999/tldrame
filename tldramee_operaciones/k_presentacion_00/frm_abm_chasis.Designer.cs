namespace k_presentacion_00
{
    partial class frm_abm_chasis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_abm_chasis));
            this.cboPatente = new System.Windows.Forms.ComboBox();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.cboModelo = new System.Windows.Forms.ComboBox();
            this.txtNroChasis = new System.Windows.Forms.TextBox();
            this.cboTipoCarga = new System.Windows.Forms.ComboBox();
            this.txtNewPatente = new System.Windows.Forms.TextBox();
            this.cboTipoTrafico = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNroPoliza = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.mskFecVenSeg = new System.Windows.Forms.MaskedTextBox();
            this.mskFecVenVTV = new System.Windows.Forms.MaskedTextBox();
            this.cGenerador = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.txtCantEjes = new k_TextBox_Num.k_textbox_n();
            this.cboTipoChasis = new System.Windows.Forms.ComboBox();
            this.txtAnio = new k_TextBox_Num.k_textbox_n();
            this.txtTara = new k_TextBox_Num.k_textbox_n();
            this.cboEmpresaSeguros = new System.Windows.Forms.ComboBox();
            this.pmaximizar = new System.Windows.Forms.PictureBox();
            this.pminimizar = new System.Windows.Forms.PictureBox();
            this.prestaurar = new System.Windows.Forms.PictureBox();
            this.pClose = new System.Windows.Forms.PictureBox();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmbNew = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboRazonSocial = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.opBlackList = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pmaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pminimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pClose)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPatente
            // 
            this.cboPatente.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPatente.FormattingEnabled = true;
            this.cboPatente.Location = new System.Drawing.Point(119, 57);
            this.cboPatente.Name = "cboPatente";
            this.cboPatente.Size = new System.Drawing.Size(387, 24);
            this.cboPatente.TabIndex = 0;
            this.cboPatente.Text = "cboPatente";
            this.cboPatente.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            // 
            // cboMarca
            // 
            this.cboMarca.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(119, 87);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(387, 24);
            this.cboMarca.TabIndex = 2;
            this.cboMarca.Text = "cboMarca";
            this.cboMarca.SelectedIndexChanged += new System.EventHandler(this.cboMarca_SelectedIndexChanged);
            this.cboMarca.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            this.cboMarca.Leave += new System.EventHandler(this.cboMarca_Leave);
            // 
            // cboModelo
            // 
            this.cboModelo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModelo.FormattingEnabled = true;
            this.cboModelo.Location = new System.Drawing.Point(119, 122);
            this.cboModelo.Name = "cboModelo";
            this.cboModelo.Size = new System.Drawing.Size(387, 24);
            this.cboModelo.TabIndex = 3;
            this.cboModelo.Text = "cboModelo";
            this.cboModelo.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            this.cboModelo.Leave += new System.EventHandler(this.cboModelo_Leave);
            // 
            // txtNroChasis
            // 
            this.txtNroChasis.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroChasis.Location = new System.Drawing.Point(372, 229);
            this.txtNroChasis.MaxLength = 50;
            this.txtNroChasis.Name = "txtNroChasis";
            this.txtNroChasis.Size = new System.Drawing.Size(129, 24);
            this.txtNroChasis.TabIndex = 7;
            this.txtNroChasis.Text = "txtNroChasis";
            this.txtNroChasis.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            this.txtNroChasis.Leave += new System.EventHandler(this.e_Cambiar_mayus_S_Espacios);
            // 
            // cboTipoCarga
            // 
            this.cboTipoCarga.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoCarga.FormattingEnabled = true;
            this.cboTipoCarga.Location = new System.Drawing.Point(118, 373);
            this.cboTipoCarga.Name = "cboTipoCarga";
            this.cboTipoCarga.Size = new System.Drawing.Size(146, 24);
            this.cboTipoCarga.TabIndex = 14;
            this.cboTipoCarga.Text = "cboTipoCarga";
            this.cboTipoCarga.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            // 
            // txtNewPatente
            // 
            this.txtNewPatente.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPatente.Location = new System.Drawing.Point(119, 57);
            this.txtNewPatente.MaxLength = 200;
            this.txtNewPatente.Name = "txtNewPatente";
            this.txtNewPatente.Size = new System.Drawing.Size(387, 24);
            this.txtNewPatente.TabIndex = 1;
            this.txtNewPatente.Text = "txtPatente";
            this.txtNewPatente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNewPatente.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            this.txtNewPatente.Leave += new System.EventHandler(this.e_Cambiar_mayus_S_Espacios);
            // 
            // cboTipoTrafico
            // 
            this.cboTipoTrafico.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoTrafico.FormattingEnabled = true;
            this.cboTipoTrafico.Location = new System.Drawing.Point(358, 375);
            this.cboTipoTrafico.Name = "cboTipoTrafico";
            this.cboTipoTrafico.Size = new System.Drawing.Size(146, 24);
            this.cboTipoTrafico.TabIndex = 15;
            this.cboTipoTrafico.Text = "cboTipoTrafico";
            this.cboTipoTrafico.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Patente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Marca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Modelo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Año";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Tipo Chasis";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(268, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 17);
            this.label6.TabIndex = 28;
            this.label6.Text = "Nº de Chasis";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 330);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 38);
            this.label9.TabIndex = 31;
            this.label9.Text = "Cantidad de Ejes";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 380);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 17);
            this.label14.TabIndex = 36;
            this.label14.Text = "Carga";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(295, 376);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 17);
            this.label15.TabIndex = 37;
            this.label15.Text = "Tráfico";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(2, 24);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(499, 29);
            this.lblTitulo.TabIndex = 38;
            this.lblTitulo.Text = "Mantenimiento de Chasis";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(198, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 17);
            this.label8.TabIndex = 41;
            this.label8.Text = "Tara";
            // 
            // txtNroPoliza
            // 
            this.txtNroPoliza.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroPoliza.Location = new System.Drawing.Point(372, 259);
            this.txtNroPoliza.MaxLength = 50;
            this.txtNroPoliza.Name = "txtNroPoliza";
            this.txtNroPoliza.Size = new System.Drawing.Size(129, 24);
            this.txtNroPoliza.TabIndex = 9;
            this.txtNroPoliza.Text = "txtNroPoliza";
            this.txtNroPoliza.Leave += new System.EventHandler(this.e_Cambiar_mayus_S_Espacios);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(10, 261);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 17);
            this.label16.TabIndex = 44;
            this.label16.Text = "Seguro";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(268, 263);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 17);
            this.label17.TabIndex = 43;
            this.label17.Text = "Nº de Poliza";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(268, 300);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(98, 17);
            this.label18.TabIndex = 57;
            this.label18.Text = "Fec Vec. Seg.";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(10, 298);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(90, 17);
            this.label19.TabIndex = 56;
            this.label19.Text = "Fec Vec. Lic.";
            // 
            // mskFecVenSeg
            // 
            this.mskFecVenSeg.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskFecVenSeg.Location = new System.Drawing.Point(411, 295);
            this.mskFecVenSeg.Mask = "00/00/0000";
            this.mskFecVenSeg.Name = "mskFecVenSeg";
            this.mskFecVenSeg.Size = new System.Drawing.Size(90, 24);
            this.mskFecVenSeg.TabIndex = 11;
            this.mskFecVenSeg.ValidatingType = typeof(System.DateTime);
            // 
            // mskFecVenVTV
            // 
            this.mskFecVenVTV.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskFecVenVTV.Location = new System.Drawing.Point(116, 294);
            this.mskFecVenVTV.Mask = "00/00/0000";
            this.mskFecVenVTV.Name = "mskFecVenVTV";
            this.mskFecVenVTV.Size = new System.Drawing.Size(90, 24);
            this.mskFecVenVTV.TabIndex = 10;
            this.mskFecVenVTV.ValidatingType = typeof(System.DateTime);
            // 
            // cGenerador
            // 
            this.cGenerador.AutoSize = true;
            this.cGenerador.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cGenerador.Location = new System.Drawing.Point(270, 333);
            this.cGenerador.Name = "cGenerador";
            this.cGenerador.Size = new System.Drawing.Size(157, 21);
            this.cGenerador.TabIndex = 13;
            this.cGenerador.Text = "¿Tiene Generador?";
            this.cGenerador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cGenerador.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 406);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 24);
            this.label7.TabIndex = 60;
            this.label7.Text = "Observ.";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(118, 406);
            this.txtObservaciones.MaxLength = 25;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(386, 108);
            this.txtObservaciones.TabIndex = 16;
            this.txtObservaciones.Text = "Obs";
            // 
            // txtCantEjes
            // 
            this.txtCantEjes.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantEjes.Location = new System.Drawing.Point(116, 330);
            this.txtCantEjes.Name = "txtCantEjes";
            this.txtCantEjes.Size = new System.Drawing.Size(100, 24);
            this.txtCantEjes.TabIndex = 12;
            this.txtCantEjes.Text = "txtCantEjes";
            // 
            // cboTipoChasis
            // 
            this.cboTipoChasis.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoChasis.FormattingEnabled = true;
            this.cboTipoChasis.Location = new System.Drawing.Point(116, 227);
            this.cboTipoChasis.Name = "cboTipoChasis";
            this.cboTipoChasis.Size = new System.Drawing.Size(146, 24);
            this.cboTipoChasis.TabIndex = 6;
            this.cboTipoChasis.Text = "cboTipoChasis";
            // 
            // txtAnio
            // 
            this.txtAnio.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnio.Location = new System.Drawing.Point(116, 196);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(68, 24);
            this.txtAnio.TabIndex = 4;
            this.txtAnio.Text = "txtAnio";
            this.txtAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTara
            // 
            this.txtTara.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTara.Location = new System.Drawing.Point(242, 195);
            this.txtTara.Name = "txtTara";
            this.txtTara.Size = new System.Drawing.Size(100, 24);
            this.txtTara.TabIndex = 5;
            this.txtTara.Text = "Tara";
            this.txtTara.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboEmpresaSeguros
            // 
            this.cboEmpresaSeguros.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmpresaSeguros.FormattingEnabled = true;
            this.cboEmpresaSeguros.Location = new System.Drawing.Point(116, 263);
            this.cboEmpresaSeguros.Name = "cboEmpresaSeguros";
            this.cboEmpresaSeguros.Size = new System.Drawing.Size(146, 24);
            this.cboEmpresaSeguros.TabIndex = 7;
            this.cboEmpresaSeguros.Text = "cboEmpresaSeguros";
            // 
            // pmaximizar
            // 
            this.pmaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pmaximizar.Image = ((System.Drawing.Image)(resources.GetObject("pmaximizar.Image")));
            this.pmaximizar.Location = new System.Drawing.Point(490, 3);
            this.pmaximizar.Name = "pmaximizar";
            this.pmaximizar.Size = new System.Drawing.Size(16, 18);
            this.pmaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pmaximizar.TabIndex = 20;
            this.pmaximizar.TabStop = false;
            // 
            // pminimizar
            // 
            this.pminimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pminimizar.Image = ((System.Drawing.Image)(resources.GetObject("pminimizar.Image")));
            this.pminimizar.Location = new System.Drawing.Point(467, 3);
            this.pminimizar.Name = "pminimizar";
            this.pminimizar.Size = new System.Drawing.Size(16, 18);
            this.pminimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pminimizar.TabIndex = 19;
            this.pminimizar.TabStop = false;
            // 
            // prestaurar
            // 
            this.prestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prestaurar.Image = ((System.Drawing.Image)(resources.GetObject("prestaurar.Image")));
            this.prestaurar.Location = new System.Drawing.Point(490, 3);
            this.prestaurar.Name = "prestaurar";
            this.prestaurar.Size = new System.Drawing.Size(16, 18);
            this.prestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.prestaurar.TabIndex = 18;
            this.prestaurar.TabStop = false;
            this.prestaurar.Visible = false;
            this.prestaurar.Click += new System.EventHandler(this.prestaurar_Click);
            // 
            // pClose
            // 
            this.pClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pClose.Image = global::k_presentacion_00.Properties.Resources.cerrar;
            this.pClose.Location = new System.Drawing.Point(512, 3);
            this.pClose.Name = "pClose";
            this.pClose.Size = new System.Drawing.Size(24, 18);
            this.pClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pClose.TabIndex = 16;
            this.pClose.TabStop = false;
            this.pClose.Click += new System.EventHandler(this.pClose_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Image = global::k_presentacion_00.Properties.Resources.cross;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(355, 563);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(150, 43);
            this.cmdCancelar.TabIndex = 19;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = global::k_presentacion_00.Properties.Resources.spell_check;
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(193, 563);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(140, 43);
            this.cmdSave.TabIndex = 17;
            this.cmdSave.Text = "Guardar";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmbNew
            // 
            this.cmbNew.Image = global::k_presentacion_00.Properties.Resources.file_empty;
            this.cmbNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbNew.Location = new System.Drawing.Point(16, 563);
            this.cmbNew.Name = "cmbNew";
            this.cmbNew.Size = new System.Drawing.Size(142, 43);
            this.cmbNew.TabIndex = 18;
            this.cmbNew.Text = "Nuevo";
            this.cmbNew.UseVisualStyleBackColor = true;
            this.cmbNew.Click += new System.EventHandler(this.cmbNew_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 524);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 17);
            this.label13.TabIndex = 62;
            this.label13.Text = "Estado";
            // 
            // cboEstado
            // 
            this.cboEstado.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(118, 520);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(115, 24);
            this.cboEstado.TabIndex = 61;
            this.cboEstado.Text = "cboEstado";
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.White;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblUsuario.Location = new System.Drawing.Point(3, 3);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(283, 18);
            this.lblUsuario.TabIndex = 63;
            this.lblUsuario.Text = "label1";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUsuario.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 17);
            this.label10.TabIndex = 77;
            this.label10.Text = "Transportista";
            // 
            // cboRazonSocial
            // 
            this.cboRazonSocial.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRazonSocial.FormattingEnabled = true;
            this.cboRazonSocial.Location = new System.Drawing.Point(119, 153);
            this.cboRazonSocial.Name = "cboRazonSocial";
            this.cboRazonSocial.Size = new System.Drawing.Size(387, 24);
            this.cboRazonSocial.TabIndex = 76;
            this.cboRazonSocial.Text = "comboBox1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(350, 196);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 17);
            this.label11.TabIndex = 79;
            this.label11.Text = "Estado";
            // 
            // cboColor
            // 
            this.cboColor.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(412, 195);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(89, 24);
            this.cboColor.TabIndex = 78;
            this.cboColor.Text = "cboColor";
            // 
            // opBlackList
            // 
            this.opBlackList.AutoSize = true;
            this.opBlackList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.opBlackList.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opBlackList.Location = new System.Drawing.Point(378, 524);
            this.opBlackList.Name = "opBlackList";
            this.opBlackList.Size = new System.Drawing.Size(123, 22);
            this.opBlackList.TabIndex = 80;
            this.opBlackList.Text = "The Black List";
            this.opBlackList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.opBlackList.UseVisualStyleBackColor = true;
            // 
            // frm_abm_chasis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(538, 622);
            this.Controls.Add(this.opBlackList);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboColor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboRazonSocial);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.cboEmpresaSeguros);
            this.Controls.Add(this.txtTara);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.cboTipoChasis);
            this.Controls.Add(this.txtCantEjes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.cGenerador);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.mskFecVenSeg);
            this.Controls.Add(this.mskFecVenVTV);
            this.Controls.Add(this.txtNroPoliza);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTipoTrafico);
            this.Controls.Add(this.pmaximizar);
            this.Controls.Add(this.pminimizar);
            this.Controls.Add(this.prestaurar);
            this.Controls.Add(this.txtNewPatente);
            this.Controls.Add(this.pClose);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmbNew);
            this.Controls.Add(this.cboTipoCarga);
            this.Controls.Add(this.txtNroChasis);
            this.Controls.Add(this.cboModelo);
            this.Controls.Add(this.cboMarca);
            this.Controls.Add(this.cboPatente);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frm_abm_chasis";
            this.Text = "frm_abm_chasis";
            this.Load += new System.EventHandler(this.frm_abm_chasis_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_abm_chasis_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pmaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pminimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPatente;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.ComboBox cboModelo;
        private System.Windows.Forms.TextBox txtNroChasis;
        private System.Windows.Forms.ComboBox cboTipoCarga;
        private System.Windows.Forms.Button cmbNew;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.PictureBox pClose;
        private System.Windows.Forms.TextBox txtNewPatente;
        private System.Windows.Forms.PictureBox pminimizar;
        private System.Windows.Forms.PictureBox prestaurar;
        private System.Windows.Forms.PictureBox pmaximizar;
        private System.Windows.Forms.ComboBox cboTipoTrafico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNroPoliza;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.MaskedTextBox mskFecVenSeg;
        private System.Windows.Forms.MaskedTextBox mskFecVenVTV;
        private System.Windows.Forms.CheckBox cGenerador;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtObservaciones;
        private k_TextBox_Num.k_textbox_n txtCantEjes;
        private System.Windows.Forms.ComboBox cboTipoChasis;
        private k_TextBox_Num.k_textbox_n txtAnio;
        private k_TextBox_Num.k_textbox_n txtTara;
        private System.Windows.Forms.ComboBox cboEmpresaSeguros;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboRazonSocial;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.CheckBox opBlackList;
    }
}