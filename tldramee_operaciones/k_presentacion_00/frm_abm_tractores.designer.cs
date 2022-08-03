namespace k_presentacion_00
{
    partial class frm_abm_tractores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_abm_tractores));
            this.cboPatente = new System.Windows.Forms.ComboBox();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.cboModelo = new System.Windows.Forms.ComboBox();
            this.txtNroChasis = new System.Windows.Forms.TextBox();
            this.txtNewPatente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pmaximizar = new System.Windows.Forms.PictureBox();
            this.pminimizar = new System.Windows.Forms.PictureBox();
            this.prestaurar = new System.Windows.Forms.PictureBox();
            this.pClose = new System.Windows.Forms.PictureBox();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmbNew = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNroPoliza = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.mskFecVenSeg = new System.Windows.Forms.MaskedTextBox();
            this.mskFecVenVTV = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.txtCantEjes = new k_TextBox_Num.k_textbox_n();
            this.txtAnio = new k_TextBox_Num.k_textbox_n();
            this.txtTara = new k_TextBox_Num.k_textbox_n();
            this.cboEmpresaSeguros = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNroMotor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGPS_Cliente = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtGPS_Link = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtGPS_Us = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGPS_Ps = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cboRazonSocial = new System.Windows.Forms.ComboBox();
            this.lblColor = new System.Windows.Forms.Label();
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
            this.cboPatente.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPatente.FormattingEnabled = true;
            this.cboPatente.Location = new System.Drawing.Point(120, 57);
            this.cboPatente.Name = "cboPatente";
            this.cboPatente.Size = new System.Drawing.Size(390, 22);
            this.cboPatente.TabIndex = 0;
            this.cboPatente.Text = "cboPatente";
            this.cboPatente.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            // 
            // cboMarca
            // 
            this.cboMarca.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(120, 87);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(388, 22);
            this.cboMarca.TabIndex = 2;
            this.cboMarca.Text = "cboMarca";
            this.cboMarca.SelectedIndexChanged += new System.EventHandler(this.cboMarca_SelectedIndexChanged);
            this.cboMarca.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            this.cboMarca.Leave += new System.EventHandler(this.cboMarca_Leave);
            // 
            // cboModelo
            // 
            this.cboModelo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModelo.FormattingEnabled = true;
            this.cboModelo.Location = new System.Drawing.Point(120, 121);
            this.cboModelo.Name = "cboModelo";
            this.cboModelo.Size = new System.Drawing.Size(388, 22);
            this.cboModelo.TabIndex = 3;
            this.cboModelo.Text = "cboModelo";
            this.cboModelo.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            this.cboModelo.Leave += new System.EventHandler(this.cboModelo_Leave);
            // 
            // txtNroChasis
            // 
            this.txtNroChasis.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroChasis.Location = new System.Drawing.Point(376, 231);
            this.txtNroChasis.MaxLength = 50;
            this.txtNroChasis.Name = "txtNroChasis";
            this.txtNroChasis.Size = new System.Drawing.Size(129, 22);
            this.txtNroChasis.TabIndex = 7;
            this.txtNroChasis.Text = "txtNroChasis";
            this.txtNroChasis.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            this.txtNroChasis.Leave += new System.EventHandler(this.e_Cambiar_mayus_S_Espacios);
            // 
            // txtNewPatente
            // 
            this.txtNewPatente.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPatente.Location = new System.Drawing.Point(120, 57);
            this.txtNewPatente.MaxLength = 200;
            this.txtNewPatente.Name = "txtNewPatente";
            this.txtNewPatente.Size = new System.Drawing.Size(388, 22);
            this.txtNewPatente.TabIndex = 1;
            this.txtNewPatente.Text = "txtPatente";
            this.txtNewPatente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNewPatente.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            this.txtNewPatente.Leave += new System.EventHandler(this.e_Cambiar_mayus_S_Espacios);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 23;
            this.label1.Text = "Patente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 24;
            this.label2.Text = "Marca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 14);
            this.label3.TabIndex = 25;
            this.label3.Text = "Modelo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 14);
            this.label4.TabIndex = 26;
            this.label4.Text = "Año";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(283, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 14);
            this.label6.TabIndex = 28;
            this.label6.Text = "Nº de Chasis";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 331);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 39);
            this.label9.TabIndex = 31;
            this.label9.Text = "Cantidad de Ejes";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(3, 24);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(499, 29);
            this.lblTitulo.TabIndex = 38;
            this.lblTitulo.Text = "Mantenimiento de Tractores";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pmaximizar
            // 
            this.pmaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pmaximizar.Image = ((System.Drawing.Image)(resources.GetObject("pmaximizar.Image")));
            this.pmaximizar.Location = new System.Drawing.Point(474, 3);
            this.pmaximizar.Name = "pmaximizar";
            this.pmaximizar.Size = new System.Drawing.Size(15, 19);
            this.pmaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pmaximizar.TabIndex = 20;
            this.pmaximizar.TabStop = false;
            // 
            // pminimizar
            // 
            this.pminimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pminimizar.Image = ((System.Drawing.Image)(resources.GetObject("pminimizar.Image")));
            this.pminimizar.Location = new System.Drawing.Point(451, 3);
            this.pminimizar.Name = "pminimizar";
            this.pminimizar.Size = new System.Drawing.Size(15, 19);
            this.pminimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pminimizar.TabIndex = 19;
            this.pminimizar.TabStop = false;
            // 
            // prestaurar
            // 
            this.prestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prestaurar.Image = ((System.Drawing.Image)(resources.GetObject("prestaurar.Image")));
            this.prestaurar.Location = new System.Drawing.Point(474, 3);
            this.prestaurar.Name = "prestaurar";
            this.prestaurar.Size = new System.Drawing.Size(15, 19);
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
            this.pClose.Location = new System.Drawing.Point(496, 3);
            this.pClose.Name = "pClose";
            this.pClose.Size = new System.Drawing.Size(24, 19);
            this.pClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pClose.TabIndex = 16;
            this.pClose.TabStop = false;
            this.pClose.Click += new System.EventHandler(this.pClose_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Image = global::k_presentacion_00.Properties.Resources.cross;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(354, 597);
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
            this.cmdSave.Location = new System.Drawing.Point(192, 597);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(140, 43);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.Text = "Guardar";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmbNew
            // 
            this.cmbNew.Image = global::k_presentacion_00.Properties.Resources.file_empty;
            this.cmbNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbNew.Location = new System.Drawing.Point(15, 597);
            this.cmbNew.Name = "cmbNew";
            this.cmbNew.Size = new System.Drawing.Size(141, 43);
            this.cmbNew.TabIndex = 18;
            this.cmbNew.Text = "Nuevo";
            this.cmbNew.UseVisualStyleBackColor = true;
            this.cmbNew.Click += new System.EventHandler(this.cmbNew_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(283, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 14);
            this.label8.TabIndex = 41;
            this.label8.Text = "Tara";
            // 
            // txtNroPoliza
            // 
            this.txtNroPoliza.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroPoliza.Location = new System.Drawing.Point(376, 261);
            this.txtNroPoliza.MaxLength = 10;
            this.txtNroPoliza.Name = "txtNroPoliza";
            this.txtNroPoliza.Size = new System.Drawing.Size(129, 22);
            this.txtNroPoliza.TabIndex = 9;
            this.txtNroPoliza.Text = "txtNroPoliza";
            this.txtNroPoliza.Leave += new System.EventHandler(this.e_Cambiar_mayus_S_Espacios);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(14, 263);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 14);
            this.label16.TabIndex = 44;
            this.label16.Text = "Seguro";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(283, 264);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 14);
            this.label17.TabIndex = 43;
            this.label17.Text = "Nº de Poliza";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(283, 301);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 14);
            this.label18.TabIndex = 57;
            this.label18.Text = "Fec Vec. Seg.";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(14, 300);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(79, 14);
            this.label19.TabIndex = 56;
            this.label19.Text = "Fec Vec. Lic.";
            // 
            // mskFecVenSeg
            // 
            this.mskFecVenSeg.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskFecVenSeg.Location = new System.Drawing.Point(415, 297);
            this.mskFecVenSeg.Mask = "00/00/0000";
            this.mskFecVenSeg.Name = "mskFecVenSeg";
            this.mskFecVenSeg.Size = new System.Drawing.Size(90, 22);
            this.mskFecVenSeg.TabIndex = 11;
            this.mskFecVenSeg.ValidatingType = typeof(System.DateTime);
            // 
            // mskFecVenVTV
            // 
            this.mskFecVenVTV.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskFecVenVTV.Location = new System.Drawing.Point(120, 296);
            this.mskFecVenVTV.Mask = "00/00/0000";
            this.mskFecVenVTV.Name = "mskFecVenVTV";
            this.mskFecVenVTV.Size = new System.Drawing.Size(90, 22);
            this.mskFecVenVTV.TabIndex = 10;
            this.mskFecVenVTV.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 464);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 24);
            this.label7.TabIndex = 60;
            this.label7.Text = "Observ.";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(120, 469);
            this.txtObservaciones.MaxLength = 25;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(385, 70);
            this.txtObservaciones.TabIndex = 16;
            this.txtObservaciones.Text = "Obs";
            // 
            // txtCantEjes
            // 
            this.txtCantEjes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantEjes.Location = new System.Drawing.Point(120, 331);
            this.txtCantEjes.Name = "txtCantEjes";
            this.txtCantEjes.Size = new System.Drawing.Size(100, 22);
            this.txtCantEjes.TabIndex = 12;
            this.txtCantEjes.Text = "txtCantEjes";
            // 
            // txtAnio
            // 
            this.txtAnio.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnio.Location = new System.Drawing.Point(120, 197);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(100, 22);
            this.txtAnio.TabIndex = 5;
            this.txtAnio.Text = "txtAnio";
            this.txtAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTara
            // 
            this.txtTara.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTara.Location = new System.Drawing.Point(405, 197);
            this.txtTara.Name = "txtTara";
            this.txtTara.Size = new System.Drawing.Size(100, 22);
            this.txtTara.TabIndex = 5;
            this.txtTara.Text = "Tara";
            this.txtTara.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboEmpresaSeguros
            // 
            this.cboEmpresaSeguros.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmpresaSeguros.FormattingEnabled = true;
            this.cboEmpresaSeguros.Location = new System.Drawing.Point(120, 264);
            this.cboEmpresaSeguros.Name = "cboEmpresaSeguros";
            this.cboEmpresaSeguros.Size = new System.Drawing.Size(145, 22);
            this.cboEmpresaSeguros.TabIndex = 7;
            this.cboEmpresaSeguros.Text = "cboEmpresaSeguros";
            this.cboEmpresaSeguros.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 14);
            this.label5.TabIndex = 62;
            this.label5.Text = "Nº de Motor";
            // 
            // txtNroMotor
            // 
            this.txtNroMotor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroMotor.Location = new System.Drawing.Point(120, 233);
            this.txtNroMotor.MaxLength = 50;
            this.txtNroMotor.Name = "txtNroMotor";
            this.txtNroMotor.Size = new System.Drawing.Size(129, 22);
            this.txtNroMotor.TabIndex = 61;
            this.txtNroMotor.Text = "NroMotor";
            this.txtNroMotor.Leave += new System.EventHandler(this.e_Cambiar_mayus_S_Espacios);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 379);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 14);
            this.label10.TabIndex = 64;
            this.label10.Text = "GPS del Cliente";
            // 
            // txtGPS_Cliente
            // 
            this.txtGPS_Cliente.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGPS_Cliente.Location = new System.Drawing.Point(118, 376);
            this.txtGPS_Cliente.MaxLength = 100;
            this.txtGPS_Cliente.Name = "txtGPS_Cliente";
            this.txtGPS_Cliente.Size = new System.Drawing.Size(387, 22);
            this.txtGPS_Cliente.TabIndex = 63;
            this.txtGPS_Cliente.Text = "txtGPS_Cliente";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(14, 409);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 14);
            this.label11.TabIndex = 66;
            this.label11.Text = "GPS Link";
            // 
            // txtGPS_Link
            // 
            this.txtGPS_Link.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGPS_Link.Location = new System.Drawing.Point(119, 406);
            this.txtGPS_Link.MaxLength = 100;
            this.txtGPS_Link.Name = "txtGPS_Link";
            this.txtGPS_Link.Size = new System.Drawing.Size(386, 22);
            this.txtGPS_Link.TabIndex = 65;
            this.txtGPS_Link.Text = "txtGPS_Link";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(14, 439);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 14);
            this.label12.TabIndex = 68;
            this.label12.Text = "Usuario GPS";
            // 
            // txtGPS_Us
            // 
            this.txtGPS_Us.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGPS_Us.Location = new System.Drawing.Point(120, 436);
            this.txtGPS_Us.MaxLength = 100;
            this.txtGPS_Us.Name = "txtGPS_Us";
            this.txtGPS_Us.Size = new System.Drawing.Size(129, 22);
            this.txtGPS_Us.TabIndex = 67;
            this.txtGPS_Us.Text = "txtGPS_Us";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(283, 440);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 14);
            this.label13.TabIndex = 70;
            this.label13.Text = "Clave GPS";
            // 
            // txtGPS_Ps
            // 
            this.txtGPS_Ps.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGPS_Ps.Location = new System.Drawing.Point(376, 439);
            this.txtGPS_Ps.MaxLength = 100;
            this.txtGPS_Ps.Name = "txtGPS_Ps";
            this.txtGPS_Ps.Size = new System.Drawing.Size(129, 22);
            this.txtGPS_Ps.TabIndex = 69;
            this.txtGPS_Ps.Text = "txtGPS_Ps";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(14, 549);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 14);
            this.label14.TabIndex = 72;
            this.label14.Text = "Estado";
            // 
            // cboEstado
            // 
            this.cboEstado.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(120, 544);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(115, 22);
            this.cboEstado.TabIndex = 71;
            this.cboEstado.Text = "cboEstado";
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.White;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblUsuario.Location = new System.Drawing.Point(3, 3);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(283, 19);
            this.lblUsuario.TabIndex = 73;
            this.lblUsuario.Text = "label1";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(14, 159);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 14);
            this.label15.TabIndex = 75;
            this.label15.Text = "Transportista";
            // 
            // cboRazonSocial
            // 
            this.cboRazonSocial.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRazonSocial.FormattingEnabled = true;
            this.cboRazonSocial.Location = new System.Drawing.Point(120, 153);
            this.cboRazonSocial.Name = "cboRazonSocial";
            this.cboRazonSocial.Size = new System.Drawing.Size(388, 22);
            this.cboRazonSocial.TabIndex = 4;
            this.cboRazonSocial.Text = "comboBox1";
            this.cboRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cboRazonSocial_SelectedIndexChanged);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(283, 336);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(39, 14);
            this.lblColor.TabIndex = 77;
            this.lblColor.Text = "Color";
            // 
            // cboColor
            // 
            this.cboColor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(390, 331);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(115, 22);
            this.cboColor.TabIndex = 76;
            this.cboColor.Text = "Color";
            // 
            // opBlackList
            // 
            this.opBlackList.AutoSize = true;
            this.opBlackList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.opBlackList.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opBlackList.Location = new System.Drawing.Point(379, 549);
            this.opBlackList.Name = "opBlackList";
            this.opBlackList.Size = new System.Drawing.Size(123, 22);
            this.opBlackList.TabIndex = 81;
            this.opBlackList.Text = "The Black List";
            this.opBlackList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.opBlackList.UseVisualStyleBackColor = true;
            // 
            // frm_abm_tractores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(522, 656);
            this.Controls.Add(this.opBlackList);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.cboColor);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cboRazonSocial);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtGPS_Ps);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtGPS_Us);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtGPS_Link);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtGPS_Cliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNroMotor);
            this.Controls.Add(this.cboEmpresaSeguros);
            this.Controls.Add(this.txtTara);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.txtCantEjes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.mskFecVenSeg);
            this.Controls.Add(this.mskFecVenVTV);
            this.Controls.Add(this.txtNroPoliza);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pmaximizar);
            this.Controls.Add(this.pminimizar);
            this.Controls.Add(this.prestaurar);
            this.Controls.Add(this.txtNewPatente);
            this.Controls.Add(this.pClose);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmbNew);
            this.Controls.Add(this.txtNroChasis);
            this.Controls.Add(this.cboModelo);
            this.Controls.Add(this.cboMarca);
            this.Controls.Add(this.cboPatente);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_abm_tractores";
            this.Text = "frm_abm_tractores";
            this.Load += new System.EventHandler(this.frm_abm_tractores_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_abm_tractores_MouseDown);
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
        private System.Windows.Forms.Button cmbNew;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.PictureBox pClose;
        private System.Windows.Forms.TextBox txtNewPatente;
        private System.Windows.Forms.PictureBox pminimizar;
        private System.Windows.Forms.PictureBox prestaurar;
        private System.Windows.Forms.PictureBox pmaximizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNroPoliza;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.MaskedTextBox mskFecVenSeg;
        private System.Windows.Forms.MaskedTextBox mskFecVenVTV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtObservaciones;
        private k_TextBox_Num.k_textbox_n txtCantEjes;
        private k_TextBox_Num.k_textbox_n txtAnio;
        private k_TextBox_Num.k_textbox_n txtTara;
        private System.Windows.Forms.ComboBox cboEmpresaSeguros;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNroMotor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtGPS_Cliente;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtGPS_Link;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtGPS_Us;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtGPS_Ps;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboRazonSocial;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.CheckBox opBlackList;
    }
}