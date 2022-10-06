using System;

namespace k_presentacion_00
{
    partial class frm_PopUp_Designa_Viaje_Conceptos
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
            this.lblDescripcion_Item = new System.Windows.Forms.Label();
            this.lblCosto = new System.Windows.Forms.Label();
            this.lblOT = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.btnInsertar_Linea = new System.Windows.Forms.Button();
            this.btnCargar_Conceptos = new System.Windows.Forms.Button();
            this.btnEliminar_Linea = new System.Windows.Forms.Button();
            this.lblTransportista = new System.Windows.Forms.Label();
            this.lblTractor = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblChofer = new System.Windows.Forms.Label();
            this.lblChasis = new System.Windows.Forms.Label();
            this.lbl_ID_Transportista = new System.Windows.Forms.Label();
            this.lbl_ID_Chasis = new System.Windows.Forms.Label();
            this.lbl_ID_Tractor = new System.Windows.Forms.Label();
            this.lbl_ID_Chofer = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEstados_OTs = new System.Windows.Forms.ComboBox();
            this.btnGenera_Anticipo_Transf = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNroPrecinto = new System.Windows.Forms.TextBox();
            this.txtNroContenedor = new System.Windows.Forms.MaskedTextBox();
            this.cmdGuardar_Contenedor = new System.Windows.Forms.Button();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblBL_Booking = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCambioNominacion = new System.Windows.Forms.Button();
            this.cboTransportista = new System.Windows.Forms.ComboBox();
            this.cboTractores = new System.Windows.Forms.ComboBox();
            this.cboChasis = new System.Windows.Forms.ComboBox();
            this.cboChoferes = new System.Windows.Forms.ComboBox();
            this.txtCostoFF = new System.Windows.Forms.TextBox();
            this.lblCostoFF = new System.Windows.Forms.Label();
            this.txtVentaFF = new System.Windows.Forms.TextBox();
            this.lblVentaFF = new System.Windows.Forms.Label();
            this.opReqAnticipo = new System.Windows.Forms.CheckBox();
            this.lblTipo_Modalidad = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblNominacion = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnGenera_Anticipo_Comb = new System.Windows.Forms.Button();
            this.btnGenera_Anticipo_Extra = new System.Windows.Forms.Button();
            this.opDual = new System.Windows.Forms.CheckBox();
            this.btnGenera_Anticipo_Cheques = new System.Windows.Forms.Button();
            this.lblTieneFactura = new System.Windows.Forms.Label();
            this.lblTieneAnticipo = new System.Windows.Forms.Label();
            this.cmdLimpiar = new System.Windows.Forms.Button();
            this.txtNroPrecintoVacio = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTipoServicio = new System.Windows.Forms.Label();
            this.lblFechaRetiro = new System.Windows.Forms.Label();
            this.lblFechaPosicion = new System.Windows.Forms.Label();
            this.lblHoraPosicion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescripcion_Item
            // 
            this.lblDescripcion_Item.AutoSize = true;
            this.lblDescripcion_Item.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion_Item.Location = new System.Drawing.Point(109, 36);
            this.lblDescripcion_Item.Name = "lblDescripcion_Item";
            this.lblDescripcion_Item.Size = new System.Drawing.Size(145, 18);
            this.lblDescripcion_Item.TabIndex = 43;
            this.lblDescripcion_Item.Text = "lblDescripcion_Item";
            this.lblDescripcion_Item.Click += new System.EventHandler(this.lblDescripcion_Item_Click);
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosto.Location = new System.Drawing.Point(109, 62);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(65, 18);
            this.lblCosto.TabIndex = 42;
            this.lblCosto.Text = "lblCosto";
            this.lblCosto.Visible = false;
            // 
            // lblOT
            // 
            this.lblOT.AutoSize = true;
            this.lblOT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOT.Location = new System.Drawing.Point(176, 12);
            this.lblOT.Name = "lblOT";
            this.lblOT.Size = new System.Drawing.Size(49, 19);
            this.lblOT.TabIndex = 41;
            this.lblOT.Text = "lblOT";
            this.lblOT.Click += new System.EventHandler(this.lblOT_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(149, 561);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(128, 35);
            this.btnSalir.TabIndex = 40;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(13, 561);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(128, 35);
            this.btnGrabar.TabIndex = 39;
            this.btnGrabar.Text = "GRABAR";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgw.ColumnHeadersHeight = 40;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgw.EnableHeadersVisualStyles = false;
            this.dgw.GridColor = System.Drawing.Color.SteelBlue;
            this.dgw.Location = new System.Drawing.Point(13, 308);
            this.dgw.Name = "dgw";
            this.dgw.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgw.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgw.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(830, 247);
            this.dgw.TabIndex = 44;
            this.dgw.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdConceptos_CellContentClick);
            this.dgw.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdConceptos_CellEndEdit);
            this.dgw.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GrdConceptos_CellMouseUp);
            this.dgw.CurrentCellDirtyStateChanged += new System.EventHandler(this.GrdConceptos_CurrentCellDirtyStateChanged);
            this.dgw.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgw_DataError);
            this.dgw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GrdConceptos_KeyPress);
            // 
            // btnInsertar_Linea
            // 
            this.btnInsertar_Linea.Location = new System.Drawing.Point(170, 267);
            this.btnInsertar_Linea.Name = "btnInsertar_Linea";
            this.btnInsertar_Linea.Size = new System.Drawing.Size(128, 35);
            this.btnInsertar_Linea.TabIndex = 45;
            this.btnInsertar_Linea.Text = "INSERTAR LINEA";
            this.btnInsertar_Linea.UseVisualStyleBackColor = true;
            this.btnInsertar_Linea.Visible = false;
            this.btnInsertar_Linea.Click += new System.EventHandler(this.BtnInsertar_Linea_Click);
            // 
            // btnCargar_Conceptos
            // 
            this.btnCargar_Conceptos.Location = new System.Drawing.Point(12, 267);
            this.btnCargar_Conceptos.Name = "btnCargar_Conceptos";
            this.btnCargar_Conceptos.Size = new System.Drawing.Size(152, 35);
            this.btnCargar_Conceptos.TabIndex = 46;
            this.btnCargar_Conceptos.Text = "CARGAR CONCEPTOS";
            this.btnCargar_Conceptos.UseVisualStyleBackColor = true;
            this.btnCargar_Conceptos.Visible = false;
            this.btnCargar_Conceptos.Click += new System.EventHandler(this.BtnCargar_Conceptos_Click);
            // 
            // btnEliminar_Linea
            // 
            this.btnEliminar_Linea.Location = new System.Drawing.Point(306, 267);
            this.btnEliminar_Linea.Name = "btnEliminar_Linea";
            this.btnEliminar_Linea.Size = new System.Drawing.Size(128, 35);
            this.btnEliminar_Linea.TabIndex = 47;
            this.btnEliminar_Linea.Text = "ELIMINAR LINEA";
            this.btnEliminar_Linea.UseVisualStyleBackColor = true;
            this.btnEliminar_Linea.Visible = false;
            this.btnEliminar_Linea.Click += new System.EventHandler(this.BtnEliminar_Linea_Click);
            // 
            // lblTransportista
            // 
            this.lblTransportista.AutoSize = true;
            this.lblTransportista.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransportista.Location = new System.Drawing.Point(109, 84);
            this.lblTransportista.Name = "lblTransportista";
            this.lblTransportista.Size = new System.Drawing.Size(113, 18);
            this.lblTransportista.TabIndex = 48;
            this.lblTransportista.Text = "lblTransportista";
            // 
            // lblTractor
            // 
            this.lblTractor.AutoSize = true;
            this.lblTractor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTractor.Location = new System.Drawing.Point(109, 109);
            this.lblTractor.Name = "lblTractor";
            this.lblTractor.Size = new System.Drawing.Size(71, 18);
            this.lblTractor.TabIndex = 49;
            this.lblTractor.Text = "lblTractor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 19);
            this.label4.TabIndex = 50;
            this.label4.Text = "Trans.:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 19);
            this.label5.TabIndex = 51;
            this.label5.Text = "Tractor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 19);
            this.label6.TabIndex = 53;
            this.label6.Text = "Chofer:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 19);
            this.label7.TabIndex = 52;
            this.label7.Text = "Chasis:";
            // 
            // lblChofer
            // 
            this.lblChofer.AutoSize = true;
            this.lblChofer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChofer.Location = new System.Drawing.Point(109, 157);
            this.lblChofer.Name = "lblChofer";
            this.lblChofer.Size = new System.Drawing.Size(70, 18);
            this.lblChofer.TabIndex = 55;
            this.lblChofer.Text = "lblChofer";
            // 
            // lblChasis
            // 
            this.lblChasis.AutoSize = true;
            this.lblChasis.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChasis.Location = new System.Drawing.Point(109, 135);
            this.lblChasis.Name = "lblChasis";
            this.lblChasis.Size = new System.Drawing.Size(72, 18);
            this.lblChasis.TabIndex = 54;
            this.lblChasis.Text = "lblChasis";
            // 
            // lbl_ID_Transportista
            // 
            this.lbl_ID_Transportista.AutoSize = true;
            this.lbl_ID_Transportista.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ID_Transportista.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_ID_Transportista.Location = new System.Drawing.Point(288, 561);
            this.lbl_ID_Transportista.Name = "lbl_ID_Transportista";
            this.lbl_ID_Transportista.Size = new System.Drawing.Size(146, 18);
            this.lbl_ID_Transportista.TabIndex = 56;
            this.lbl_ID_Transportista.Text = "lbl_ID_Transportista";
            // 
            // lbl_ID_Chasis
            // 
            this.lbl_ID_Chasis.AutoSize = true;
            this.lbl_ID_Chasis.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ID_Chasis.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_ID_Chasis.Location = new System.Drawing.Point(465, 561);
            this.lbl_ID_Chasis.Name = "lbl_ID_Chasis";
            this.lbl_ID_Chasis.Size = new System.Drawing.Size(105, 18);
            this.lbl_ID_Chasis.TabIndex = 57;
            this.lbl_ID_Chasis.Text = "lbl_ID_Chasis";
            // 
            // lbl_ID_Tractor
            // 
            this.lbl_ID_Tractor.AutoSize = true;
            this.lbl_ID_Tractor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ID_Tractor.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_ID_Tractor.Location = new System.Drawing.Point(24, 630);
            this.lbl_ID_Tractor.Name = "lbl_ID_Tractor";
            this.lbl_ID_Tractor.Size = new System.Drawing.Size(104, 18);
            this.lbl_ID_Tractor.TabIndex = 58;
            this.lbl_ID_Tractor.Text = "lbl_ID_Tractor";
            // 
            // lbl_ID_Chofer
            // 
            this.lbl_ID_Chofer.AutoSize = true;
            this.lbl_ID_Chofer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ID_Chofer.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_ID_Chofer.Location = new System.Drawing.Point(152, 630);
            this.lbl_ID_Chofer.Name = "lbl_ID_Chofer";
            this.lbl_ID_Chofer.Size = new System.Drawing.Size(103, 18);
            this.lbl_ID_Chofer.TabIndex = 59;
            this.lbl_ID_Chofer.Text = "lbl_ID_Chofer";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 19);
            this.label8.TabIndex = 60;
            this.label8.Text = "Orden Transporte:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 19);
            this.label9.TabIndex = 61;
            this.label9.Text = "Cliente:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(23, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 19);
            this.label10.TabIndex = 62;
            this.label10.Text = "Costo:";
            this.label10.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(626, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 63;
            this.label1.Text = "Estado:";
            // 
            // cboEstados_OTs
            // 
            this.cboEstados_OTs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstados_OTs.FormattingEnabled = true;
            this.cboEstados_OTs.Location = new System.Drawing.Point(702, 250);
            this.cboEstados_OTs.Name = "cboEstados_OTs";
            this.cboEstados_OTs.Size = new System.Drawing.Size(141, 23);
            this.cboEstados_OTs.TabIndex = 64;
            this.cboEstados_OTs.SelectedValueChanged += new System.EventHandler(this.cboEstados_OTs_SelectedValueChanged);
            // 
            // btnGenera_Anticipo_Transf
            // 
            this.btnGenera_Anticipo_Transf.BackColor = System.Drawing.Color.Black;
            this.btnGenera_Anticipo_Transf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenera_Anticipo_Transf.ForeColor = System.Drawing.Color.White;
            this.btnGenera_Anticipo_Transf.Location = new System.Drawing.Point(13, 630);
            this.btnGenera_Anticipo_Transf.Name = "btnGenera_Anticipo_Transf";
            this.btnGenera_Anticipo_Transf.Size = new System.Drawing.Size(376, 35);
            this.btnGenera_Anticipo_Transf.TabIndex = 65;
            this.btnGenera_Anticipo_Transf.Tag = "1";
            this.btnGenera_Anticipo_Transf.Text = "EFECTIVO || TRANS || COMBUSTIBLE || EXTRACOSTOS";
            this.btnGenera_Anticipo_Transf.UseVisualStyleBackColor = false;
            this.btnGenera_Anticipo_Transf.Click += new System.EventHandler(this.Abre_Genera_Anticipo);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(525, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 18);
            this.label2.TabIndex = 67;
            this.label2.Text = "Nº Precinto Full:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(525, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 18);
            this.label3.TabIndex = 66;
            this.label3.Text = "Nº de Contenedor";
            // 
            // txtNroPrecinto
            // 
            this.txtNroPrecinto.Location = new System.Drawing.Point(672, 116);
            this.txtNroPrecinto.Name = "txtNroPrecinto";
            this.txtNroPrecinto.Size = new System.Drawing.Size(168, 21);
            this.txtNroPrecinto.TabIndex = 69;
            this.txtNroPrecinto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNroContenedor
            // 
            this.txtNroContenedor.Location = new System.Drawing.Point(672, 78);
            this.txtNroContenedor.Mask = ">LLLL0000000";
            this.txtNroContenedor.Name = "txtNroContenedor";
            this.txtNroContenedor.Size = new System.Drawing.Size(168, 21);
            this.txtNroContenedor.TabIndex = 70;
            this.txtNroContenedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdGuardar_Contenedor
            // 
            this.cmdGuardar_Contenedor.Location = new System.Drawing.Point(766, 204);
            this.cmdGuardar_Contenedor.Name = "cmdGuardar_Contenedor";
            this.cmdGuardar_Contenedor.Size = new System.Drawing.Size(77, 28);
            this.cmdGuardar_Contenedor.TabIndex = 71;
            this.cmdGuardar_Contenedor.Text = "Guardar";
            this.cmdGuardar_Contenedor.UseVisualStyleBackColor = true;
            this.cmdGuardar_Contenedor.Click += new System.EventHandler(this.cmdGuardar_Contenedor_Click);
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(307, 13);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(59, 19);
            this.lblItem.TabIndex = 72;
            this.lblItem.Text = "lblItem";
            // 
            // lblBL_Booking
            // 
            this.lblBL_Booking.AutoSize = true;
            this.lblBL_Booking.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBL_Booking.Location = new System.Drawing.Point(355, 119);
            this.lblBL_Booking.Name = "lblBL_Booking";
            this.lblBL_Booking.Size = new System.Drawing.Size(90, 18);
            this.lblBL_Booking.TabIndex = 74;
            this.lblBL_Booking.Text = "BL/Booking";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(249, 118);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 19);
            this.label12.TabIndex = 73;
            this.label12.Text = "BL/Booking";
            // 
            // btnCambioNominacion
            // 
            this.btnCambioNominacion.Location = new System.Drawing.Point(320, 561);
            this.btnCambioNominacion.Name = "btnCambioNominacion";
            this.btnCambioNominacion.Size = new System.Drawing.Size(237, 35);
            this.btnCambioNominacion.TabIndex = 75;
            this.btnCambioNominacion.Text = "CAMBIO DE NOMINACIÓN";
            this.btnCambioNominacion.UseVisualStyleBackColor = true;
            this.btnCambioNominacion.Click += new System.EventHandler(this.btnCambioNominacion_Click);
            // 
            // cboTransportista
            // 
            this.cboTransportista.FormattingEnabled = true;
            this.cboTransportista.Location = new System.Drawing.Point(380, 6);
            this.cboTransportista.Name = "cboTransportista";
            this.cboTransportista.Size = new System.Drawing.Size(214, 23);
            this.cboTransportista.TabIndex = 31;
            this.cboTransportista.Visible = false;
            this.cboTransportista.SelectedValueChanged += new System.EventHandler(this.CboTransportista_SelectedValueChanged);
            // 
            // cboTractores
            // 
            this.cboTractores.FormattingEnabled = true;
            this.cboTractores.Location = new System.Drawing.Point(629, 9);
            this.cboTractores.Name = "cboTractores";
            this.cboTractores.Size = new System.Drawing.Size(214, 23);
            this.cboTractores.TabIndex = 33;
            this.cboTractores.Visible = false;
            this.cboTractores.SelectedValueChanged += new System.EventHandler(this.CboTractores_SelectedValueChanged);
            // 
            // cboChasis
            // 
            this.cboChasis.FormattingEnabled = true;
            this.cboChasis.Location = new System.Drawing.Point(380, 40);
            this.cboChasis.Name = "cboChasis";
            this.cboChasis.Size = new System.Drawing.Size(214, 23);
            this.cboChasis.TabIndex = 35;
            this.cboChasis.Visible = false;
            // 
            // cboChoferes
            // 
            this.cboChoferes.FormattingEnabled = true;
            this.cboChoferes.Location = new System.Drawing.Point(629, 40);
            this.cboChoferes.Name = "cboChoferes";
            this.cboChoferes.Size = new System.Drawing.Size(214, 23);
            this.cboChoferes.TabIndex = 37;
            this.cboChoferes.Visible = false;
            this.cboChoferes.SelectedValueChanged += new System.EventHandler(this.CboChoferes_SelectedValueChanged);
            // 
            // txtCostoFF
            // 
            this.txtCostoFF.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoFF.ForeColor = System.Drawing.Color.Red;
            this.txtCostoFF.Location = new System.Drawing.Point(539, 281);
            this.txtCostoFF.Name = "txtCostoFF";
            this.txtCostoFF.Size = new System.Drawing.Size(97, 21);
            this.txtCostoFF.TabIndex = 77;
            this.txtCostoFF.Text = "0";
            this.txtCostoFF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCostoFF.Visible = false;
            // 
            // lblCostoFF
            // 
            this.lblCostoFF.AutoSize = true;
            this.lblCostoFF.BackColor = System.Drawing.Color.White;
            this.lblCostoFF.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoFF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCostoFF.Location = new System.Drawing.Point(457, 281);
            this.lblCostoFF.Name = "lblCostoFF";
            this.lblCostoFF.Size = new System.Drawing.Size(81, 19);
            this.lblCostoFF.TabIndex = 76;
            this.lblCostoFF.Text = "Costo F.F";
            this.lblCostoFF.Visible = false;
            // 
            // txtVentaFF
            // 
            this.txtVentaFF.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVentaFF.ForeColor = System.Drawing.Color.Red;
            this.txtVentaFF.Location = new System.Drawing.Point(738, 281);
            this.txtVentaFF.Name = "txtVentaFF";
            this.txtVentaFF.Size = new System.Drawing.Size(97, 21);
            this.txtVentaFF.TabIndex = 79;
            this.txtVentaFF.Text = "0";
            this.txtVentaFF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVentaFF.Visible = false;
            // 
            // lblVentaFF
            // 
            this.lblVentaFF.AutoSize = true;
            this.lblVentaFF.BackColor = System.Drawing.Color.White;
            this.lblVentaFF.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentaFF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVentaFF.Location = new System.Drawing.Point(651, 281);
            this.lblVentaFF.Name = "lblVentaFF";
            this.lblVentaFF.Size = new System.Drawing.Size(78, 19);
            this.lblVentaFF.TabIndex = 78;
            this.lblVentaFF.Text = "Venta F.F";
            this.lblVentaFF.Visible = false;
            // 
            // opReqAnticipo
            // 
            this.opReqAnticipo.AutoSize = true;
            this.opReqAnticipo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.opReqAnticipo.Location = new System.Drawing.Point(13, 602);
            this.opReqAnticipo.Name = "opReqAnticipo";
            this.opReqAnticipo.Size = new System.Drawing.Size(94, 19);
            this.opReqAnticipo.TabIndex = 80;
            this.opReqAnticipo.Text = "Req Anticipo";
            this.opReqAnticipo.UseVisualStyleBackColor = true;
            // 
            // lblTipo_Modalidad
            // 
            this.lblTipo_Modalidad.AutoSize = true;
            this.lblTipo_Modalidad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo_Modalidad.Location = new System.Drawing.Point(111, 180);
            this.lblTipo_Modalidad.Name = "lblTipo_Modalidad";
            this.lblTipo_Modalidad.Size = new System.Drawing.Size(136, 18);
            this.lblTipo_Modalidad.TabIndex = 82;
            this.lblTipo_Modalidad.Text = "lblTipo_Modalidad";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(23, 179);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 19);
            this.label13.TabIndex = 81;
            this.label13.Text = "Modalidad:";
            // 
            // lblNominacion
            // 
            this.lblNominacion.AutoSize = true;
            this.lblNominacion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNominacion.Location = new System.Drawing.Point(145, 220);
            this.lblNominacion.Name = "lblNominacion";
            this.lblNominacion.Size = new System.Drawing.Size(106, 18);
            this.lblNominacion.TabIndex = 84;
            this.lblNominacion.Text = "lblNominacion";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(23, 208);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 40);
            this.label14.TabIndex = 83;
            this.label14.Text = "Email de Nominación";
            // 
            // btnGenera_Anticipo_Comb
            // 
            this.btnGenera_Anticipo_Comb.BackColor = System.Drawing.Color.Black;
            this.btnGenera_Anticipo_Comb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenera_Anticipo_Comb.ForeColor = System.Drawing.Color.White;
            this.btnGenera_Anticipo_Comb.Location = new System.Drawing.Point(425, 640);
            this.btnGenera_Anticipo_Comb.Name = "btnGenera_Anticipo_Comb";
            this.btnGenera_Anticipo_Comb.Size = new System.Drawing.Size(179, 35);
            this.btnGenera_Anticipo_Comb.TabIndex = 85;
            this.btnGenera_Anticipo_Comb.Tag = "2";
            this.btnGenera_Anticipo_Comb.Text = "COMBUSTIBLE";
            this.btnGenera_Anticipo_Comb.UseVisualStyleBackColor = false;
            this.btnGenera_Anticipo_Comb.Visible = false;
            this.btnGenera_Anticipo_Comb.Click += new System.EventHandler(this.Abre_Genera_Anticipo);
            // 
            // btnGenera_Anticipo_Extra
            // 
            this.btnGenera_Anticipo_Extra.BackColor = System.Drawing.Color.Black;
            this.btnGenera_Anticipo_Extra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenera_Anticipo_Extra.ForeColor = System.Drawing.Color.White;
            this.btnGenera_Anticipo_Extra.Location = new System.Drawing.Point(425, 630);
            this.btnGenera_Anticipo_Extra.Name = "btnGenera_Anticipo_Extra";
            this.btnGenera_Anticipo_Extra.Size = new System.Drawing.Size(180, 35);
            this.btnGenera_Anticipo_Extra.TabIndex = 86;
            this.btnGenera_Anticipo_Extra.Tag = "3";
            this.btnGenera_Anticipo_Extra.Text = "EXTRACOSTOS";
            this.btnGenera_Anticipo_Extra.UseVisualStyleBackColor = false;
            this.btnGenera_Anticipo_Extra.Visible = false;
            this.btnGenera_Anticipo_Extra.Click += new System.EventHandler(this.Abre_Genera_Anticipo);
            // 
            // opDual
            // 
            this.opDual.AutoSize = true;
            this.opDual.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.opDual.Location = new System.Drawing.Point(380, 77);
            this.opDual.Name = "opDual";
            this.opDual.Size = new System.Drawing.Size(82, 19);
            this.opDual.TabIndex = 87;
            this.opDual.Text = "Viaje Dual";
            this.opDual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.opDual.UseVisualStyleBackColor = true;
            this.opDual.CheckedChanged += new System.EventHandler(this.opDual_CheckedChanged);
            // 
            // btnGenera_Anticipo_Cheques
            // 
            this.btnGenera_Anticipo_Cheques.BackColor = System.Drawing.Color.Black;
            this.btnGenera_Anticipo_Cheques.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenera_Anticipo_Cheques.ForeColor = System.Drawing.Color.White;
            this.btnGenera_Anticipo_Cheques.Location = new System.Drawing.Point(655, 630);
            this.btnGenera_Anticipo_Cheques.Name = "btnGenera_Anticipo_Cheques";
            this.btnGenera_Anticipo_Cheques.Size = new System.Drawing.Size(188, 35);
            this.btnGenera_Anticipo_Cheques.TabIndex = 88;
            this.btnGenera_Anticipo_Cheques.Tag = "4";
            this.btnGenera_Anticipo_Cheques.Text = "CHEQUES";
            this.btnGenera_Anticipo_Cheques.UseVisualStyleBackColor = false;
            this.btnGenera_Anticipo_Cheques.Click += new System.EventHandler(this.Abre_Genera_Anticipo);
            // 
            // lblTieneFactura
            // 
            this.lblTieneFactura.AutoSize = true;
            this.lblTieneFactura.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieneFactura.Location = new System.Drawing.Point(528, 230);
            this.lblTieneFactura.Name = "lblTieneFactura";
            this.lblTieneFactura.Size = new System.Drawing.Size(114, 18);
            this.lblTieneFactura.TabIndex = 89;
            this.lblTieneFactura.Text = "lblTieneFactura";
            // 
            // lblTieneAnticipo
            // 
            this.lblTieneAnticipo.AutoSize = true;
            this.lblTieneAnticipo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieneAnticipo.Location = new System.Drawing.Point(528, 208);
            this.lblTieneAnticipo.Name = "lblTieneAnticipo";
            this.lblTieneAnticipo.Size = new System.Drawing.Size(118, 18);
            this.lblTieneAnticipo.TabIndex = 90;
            this.lblTieneAnticipo.Text = "lblTieneAnticipo";
            this.lblTieneAnticipo.Click += new System.EventHandler(this.lblTieneAnticipo_Click);
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.Location = new System.Drawing.Point(675, 204);
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Size = new System.Drawing.Size(77, 28);
            this.cmdLimpiar.TabIndex = 91;
            this.cmdLimpiar.Text = "Limpiar";
            this.cmdLimpiar.UseVisualStyleBackColor = true;
            this.cmdLimpiar.Click += new System.EventHandler(this.cmdLimpiar_Click);
            // 
            // txtNroPrecintoVacio
            // 
            this.txtNroPrecintoVacio.Location = new System.Drawing.Point(672, 143);
            this.txtNroPrecintoVacio.Name = "txtNroPrecintoVacio";
            this.txtNroPrecintoVacio.Size = new System.Drawing.Size(168, 21);
            this.txtNroPrecintoVacio.TabIndex = 93;
            this.txtNroPrecintoVacio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(525, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 18);
            this.label11.TabIndex = 92;
            this.label11.Text = "Nº Precinto Empty:";
            // 
            // lblTipoServicio
            // 
            this.lblTipoServicio.AutoSize = true;
            this.lblTipoServicio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoServicio.Location = new System.Drawing.Point(527, 179);
            this.lblTipoServicio.Name = "lblTipoServicio";
            this.lblTipoServicio.Size = new System.Drawing.Size(110, 18);
            this.lblTipoServicio.TabIndex = 94;
            this.lblTipoServicio.Text = "lblTipoServicio";
            this.lblTipoServicio.Click += new System.EventHandler(this.lblTipoServicio_Click);
            // 
            // lblFechaRetiro
            // 
            this.lblFechaRetiro.AutoSize = true;
            this.lblFechaRetiro.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaRetiro.Location = new System.Drawing.Point(303, 208);
            this.lblFechaRetiro.Name = "lblFechaRetiro";
            this.lblFechaRetiro.Size = new System.Drawing.Size(59, 18);
            this.lblFechaRetiro.TabIndex = 95;
            this.lblFechaRetiro.Text = "label15";
            this.lblFechaRetiro.Visible = false;
            this.lblFechaRetiro.Click += new System.EventHandler(this.label15_Click);
            // 
            // lblFechaPosicion
            // 
            this.lblFechaPosicion.AutoSize = true;
            this.lblFechaPosicion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaPosicion.Location = new System.Drawing.Point(303, 179);
            this.lblFechaPosicion.Name = "lblFechaPosicion";
            this.lblFechaPosicion.Size = new System.Drawing.Size(59, 18);
            this.lblFechaPosicion.TabIndex = 97;
            this.lblFechaPosicion.Text = "label15";
            this.lblFechaPosicion.Visible = false;
            // 
            // lblHoraPosicion
            // 
            this.lblHoraPosicion.AutoSize = true;
            this.lblHoraPosicion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraPosicion.Location = new System.Drawing.Point(303, 230);
            this.lblHoraPosicion.Name = "lblHoraPosicion";
            this.lblHoraPosicion.Size = new System.Drawing.Size(59, 18);
            this.lblHoraPosicion.TabIndex = 98;
            this.lblHoraPosicion.Text = "label15";
            this.lblHoraPosicion.Visible = false;
            // 
            // frm_PopUp_Designa_Viaje_Conceptos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(855, 677);
            this.Controls.Add(this.lblHoraPosicion);
            this.Controls.Add(this.lblFechaPosicion);
            this.Controls.Add(this.lblFechaRetiro);
            this.Controls.Add(this.lblTipoServicio);
            this.Controls.Add(this.txtNroPrecintoVacio);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmdLimpiar);
            this.Controls.Add(this.lblTieneAnticipo);
            this.Controls.Add(this.lblTieneFactura);
            this.Controls.Add(this.btnGenera_Anticipo_Cheques);
            this.Controls.Add(this.opDual);
            this.Controls.Add(this.btnGenera_Anticipo_Extra);
            this.Controls.Add(this.btnGenera_Anticipo_Comb);
            this.Controls.Add(this.lblNominacion);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblTipo_Modalidad);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.opReqAnticipo);
            this.Controls.Add(this.txtVentaFF);
            this.Controls.Add(this.lblVentaFF);
            this.Controls.Add(this.txtCostoFF);
            this.Controls.Add(this.lblCostoFF);
            this.Controls.Add(this.btnCambioNominacion);
            this.Controls.Add(this.lblBL_Booking);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.cmdGuardar_Contenedor);
            this.Controls.Add(this.txtNroContenedor);
            this.Controls.Add(this.txtNroPrecinto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGenera_Anticipo_Transf);
            this.Controls.Add(this.cboEstados_OTs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_ID_Chofer);
            this.Controls.Add(this.lbl_ID_Tractor);
            this.Controls.Add(this.lbl_ID_Chasis);
            this.Controls.Add(this.lbl_ID_Transportista);
            this.Controls.Add(this.lblChofer);
            this.Controls.Add(this.lblChasis);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTractor);
            this.Controls.Add(this.lblTransportista);
            this.Controls.Add(this.btnEliminar_Linea);
            this.Controls.Add(this.btnCargar_Conceptos);
            this.Controls.Add(this.btnInsertar_Linea);
            this.Controls.Add(this.dgw);
            this.Controls.Add(this.lblDescripcion_Item);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.lblOT);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.cboChoferes);
            this.Controls.Add(this.cboChasis);
            this.Controls.Add(this.cboTractores);
            this.Controls.Add(this.cboTransportista);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_PopUp_Designa_Viaje_Conceptos";
            this.Load += new System.EventHandler(this.Frm_Designa_Viaje_Conceptos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescripcion_Item;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Label lblOT;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.Button btnInsertar_Linea;
        private System.Windows.Forms.Button btnCargar_Conceptos;
        private System.Windows.Forms.Button btnEliminar_Linea;
        private System.Windows.Forms.Label lblTransportista;
        private System.Windows.Forms.Label lblTractor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblChofer;
        private System.Windows.Forms.Label lblChasis;
        private System.Windows.Forms.Label lbl_ID_Transportista;
        private System.Windows.Forms.Label lbl_ID_Chasis;
        private System.Windows.Forms.Label lbl_ID_Tractor;
        private System.Windows.Forms.Label lbl_ID_Chofer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEstados_OTs;
        private System.Windows.Forms.Button btnGenera_Anticipo_Transf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNroPrecinto;
        private System.Windows.Forms.MaskedTextBox txtNroContenedor;
        private System.Windows.Forms.Button cmdGuardar_Contenedor;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblBL_Booking;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCambioNominacion;
        private System.Windows.Forms.ComboBox cboTransportista;
        private System.Windows.Forms.ComboBox cboTractores;
        private System.Windows.Forms.ComboBox cboChasis;
        private System.Windows.Forms.ComboBox cboChoferes;
        private System.Windows.Forms.TextBox txtCostoFF;
        private System.Windows.Forms.Label lblCostoFF;
        private System.Windows.Forms.TextBox txtVentaFF;
        private System.Windows.Forms.Label lblVentaFF;
        private System.Windows.Forms.CheckBox opReqAnticipo;
        private System.Windows.Forms.Label lblTipo_Modalidad;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblNominacion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnGenera_Anticipo_Comb;
        private System.Windows.Forms.Button btnGenera_Anticipo_Extra;
        private System.Windows.Forms.CheckBox opDual;
        private System.Windows.Forms.Button btnGenera_Anticipo_Cheques;
        private System.Windows.Forms.Label lblTieneFactura;
        private System.Windows.Forms.Label lblTieneAnticipo;
        private System.Windows.Forms.Button cmdLimpiar;
        private System.Windows.Forms.TextBox txtNroPrecintoVacio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTipoServicio;
        private System.Windows.Forms.Label lblFechaRetiro;
        private System.Windows.Forms.Label lblFechaPosicion;
        private System.Windows.Forms.Label lblHoraPosicion;
    }
}