﻿namespace k_presentacion_00
{
    partial class frm_abm_proveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_abm_proveedores));
            this.cboRazonSocial = new System.Windows.Forms.ComboBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.cboPais = new System.Windows.Forms.ComboBox();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.txtPostal = new System.Windows.Forms.TextBox();
            this.txtTel1 = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.cboCondicionIVA = new System.Windows.Forms.ComboBox();
            this.txtNewRazon = new System.Windows.Forms.TextBox();
            this.txtSite = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtCUIT = new System.Windows.Forms.MaskedTextBox();
            this.pmaximizar = new System.Windows.Forms.PictureBox();
            this.pminimizar = new System.Windows.Forms.PictureBox();
            this.prestaurar = new System.Windows.Forms.PictureBox();
            this.pClose = new System.Windows.Forms.PictureBox();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmbNew = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.opMoro = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pmaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pminimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pClose)).BeginInit();
            this.SuspendLayout();
            // 
            // cboRazonSocial
            // 
            this.cboRazonSocial.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRazonSocial.FormattingEnabled = true;
            this.cboRazonSocial.Location = new System.Drawing.Point(120, 52);
            this.cboRazonSocial.Name = "cboRazonSocial";
            this.cboRazonSocial.Size = new System.Drawing.Size(369, 25);
            this.cboRazonSocial.TabIndex = 0;
            this.cboRazonSocial.Text = "cboRazonSocial";
            this.cboRazonSocial.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            this.cboRazonSocial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_Mayuscula);
            this.cboRazonSocial.Leave += new System.EventHandler(this.cboRazonSocial_Leave);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(120, 192);
            this.txtDireccion.MaxLength = 200;
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(176, 62);
            this.txtDireccion.TabIndex = 5;
            this.txtDireccion.Text = "txtDireccion";
            this.txtDireccion.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            // 
            // cboPais
            // 
            this.cboPais.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPais.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(120, 87);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(369, 25);
            this.cboPais.TabIndex = 2;
            this.cboPais.Text = "cboPais";
            this.cboPais.SelectedIndexChanged += new System.EventHandler(this.cboPais_SelectedIndexChanged);
            this.cboPais.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            // 
            // cboProvincia
            // 
            this.cboProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboProvincia.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(120, 122);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(369, 25);
            this.cboProvincia.TabIndex = 3;
            this.cboProvincia.Text = "cboProvincia";
            this.cboProvincia.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboLocalidad.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(120, 157);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(369, 25);
            this.cboLocalidad.TabIndex = 4;
            this.cboLocalidad.Text = "cboLocalidad";
            this.cboLocalidad.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            // 
            // txtPostal
            // 
            this.txtPostal.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPostal.Location = new System.Drawing.Point(408, 194);
            this.txtPostal.MaxLength = 10;
            this.txtPostal.Name = "txtPostal";
            this.txtPostal.Size = new System.Drawing.Size(81, 24);
            this.txtPostal.TabIndex = 6;
            this.txtPostal.Text = "txtPostal";
            this.txtPostal.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            // 
            // txtTel1
            // 
            this.txtTel1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTel1.Location = new System.Drawing.Point(120, 260);
            this.txtTel1.MaxLength = 25;
            this.txtTel1.Multiline = true;
            this.txtTel1.Name = "txtTel1";
            this.txtTel1.Size = new System.Drawing.Size(369, 61);
            this.txtTel1.TabIndex = 7;
            this.txtTel1.Text = "Telefono1";
            this.txtTel1.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(120, 327);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(369, 24);
            this.txtEmail.TabIndex = 10;
            this.txtEmail.Text = "Email";
            this.txtEmail.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            // 
            // cboEstado
            // 
            this.cboEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboEstado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(370, 393);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(115, 25);
            this.cboEstado.TabIndex = 13;
            this.cboEstado.Text = "cboEstado";
            this.cboEstado.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            // 
            // cboCondicionIVA
            // 
            this.cboCondicionIVA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCondicionIVA.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCondicionIVA.FormattingEnabled = true;
            this.cboCondicionIVA.Location = new System.Drawing.Point(118, 428);
            this.cboCondicionIVA.Name = "cboCondicionIVA";
            this.cboCondicionIVA.Size = new System.Drawing.Size(367, 25);
            this.cboCondicionIVA.TabIndex = 14;
            this.cboCondicionIVA.Text = "CondicionIVA";
            this.cboCondicionIVA.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            // 
            // txtNewRazon
            // 
            this.txtNewRazon.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewRazon.Location = new System.Drawing.Point(120, 53);
            this.txtNewRazon.MaxLength = 200;
            this.txtNewRazon.Name = "txtNewRazon";
            this.txtNewRazon.Size = new System.Drawing.Size(369, 24);
            this.txtNewRazon.TabIndex = 1;
            this.txtNewRazon.Text = "textBox1";
            this.txtNewRazon.Enter += new System.EventHandler(this.Color_Blanco_Enter);
            this.txtNewRazon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_Mayuscula);
            // 
            // txtSite
            // 
            this.txtSite.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSite.Location = new System.Drawing.Point(118, 359);
            this.txtSite.MaxLength = 50;
            this.txtSite.Name = "txtSite";
            this.txtSite.Size = new System.Drawing.Size(369, 24);
            this.txtSite.TabIndex = 11;
            this.txtSite.Text = "Site";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "Razon Social";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "País";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "Provincia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "Localidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 18);
            this.label5.TabIndex = 27;
            this.label5.Text = "Dirección";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(302, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 18);
            this.label6.TabIndex = 28;
            this.label6.Text = "Cód Postal";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 18);
            this.label7.TabIndex = 29;
            this.label7.Text = "Telefonos";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 331);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 18);
            this.label10.TabIndex = 32;
            this.label10.Text = "Em@il";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 363);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 18);
            this.label11.TabIndex = 33;
            this.label11.Text = "web Site";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 389);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 18);
            this.label12.TabIndex = 34;
            this.label12.Text = "CUIT";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(308, 393);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 18);
            this.label13.TabIndex = 35;
            this.label13.Text = "Estado";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 428);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 18);
            this.label14.TabIndex = 36;
            this.label14.Text = "Cond IVA";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 24);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(499, 18);
            this.lblTitulo.TabIndex = 38;
            this.lblTitulo.Text = "Mantenimiento de Proveedores";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCUIT
            // 
            this.txtCUIT.Location = new System.Drawing.Point(118, 389);
            this.txtCUIT.Mask = "##-########-#";
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Size = new System.Drawing.Size(111, 26);
            this.txtCUIT.TabIndex = 12;
            // 
            // pmaximizar
            // 
            this.pmaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pmaximizar.Image = ((System.Drawing.Image)(resources.GetObject("pmaximizar.Image")));
            this.pmaximizar.Location = new System.Drawing.Point(460, 3);
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
            this.pminimizar.Location = new System.Drawing.Point(437, 3);
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
            this.prestaurar.Location = new System.Drawing.Point(460, 3);
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
            this.pClose.Location = new System.Drawing.Point(482, 3);
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
            this.cmdCancelar.Location = new System.Drawing.Point(335, 538);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(150, 43);
            this.cmdCancelar.TabIndex = 18;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = global::k_presentacion_00.Properties.Resources.spell_check;
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(180, 538);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(140, 43);
            this.cmdSave.TabIndex = 16;
            this.cmdSave.Text = "Guardar";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmbNew
            // 
            this.cmbNew.Image = global::k_presentacion_00.Properties.Resources.file_empty;
            this.cmbNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbNew.Location = new System.Drawing.Point(17, 538);
            this.cmbNew.Name = "cmbNew";
            this.cmbNew.Size = new System.Drawing.Size(142, 43);
            this.cmbNew.TabIndex = 17;
            this.cmbNew.Text = "Nuevo";
            this.cmbNew.UseVisualStyleBackColor = true;
            this.cmbNew.Click += new System.EventHandler(this.cmbNew_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.White;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblUsuario.Location = new System.Drawing.Point(-1, 3);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(283, 18);
            this.lblUsuario.TabIndex = 39;
            this.lblUsuario.Text = "label1";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUsuario.Visible = false;
            // 
            // opMoro
            // 
            this.opMoro.AutoSize = true;
            this.opMoro.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.opMoro.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opMoro.Location = new System.Drawing.Point(12, 468);
            this.opMoro.Name = "opMoro";
            this.opMoro.Size = new System.Drawing.Size(237, 22);
            this.opMoro.TabIndex = 40;
            this.opMoro.Text = "Realiza Viajes Diferenciados";
            this.opMoro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.opMoro.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.opMoro.UseVisualStyleBackColor = true;
            // 
            // frm_abm_proveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(196)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(508, 593);
            this.Controls.Add(this.opMoro);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtCUIT);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSite);
            this.Controls.Add(this.pmaximizar);
            this.Controls.Add(this.pminimizar);
            this.Controls.Add(this.prestaurar);
            this.Controls.Add(this.txtNewRazon);
            this.Controls.Add(this.pClose);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmbNew);
            this.Controls.Add(this.cboCondicionIVA);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTel1);
            this.Controls.Add(this.txtPostal);
            this.Controls.Add(this.cboLocalidad);
            this.Controls.Add(this.cboProvincia);
            this.Controls.Add(this.cboPais);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.cboRazonSocial);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frm_abm_proveedores";
            this.Text = "ABM_Cli_Trans";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_abm_proveedores_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pmaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pminimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboRazonSocial;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.ComboBox cboPais;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.TextBox txtPostal;
        private System.Windows.Forms.TextBox txtTel1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.ComboBox cboCondicionIVA;
        private System.Windows.Forms.Button cmbNew;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.PictureBox pClose;
        private System.Windows.Forms.TextBox txtNewRazon;
        private System.Windows.Forms.PictureBox pminimizar;
        private System.Windows.Forms.PictureBox prestaurar;
        private System.Windows.Forms.PictureBox pmaximizar;
        private System.Windows.Forms.TextBox txtSite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.MaskedTextBox txtCUIT;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.CheckBox opMoro;
    }
}