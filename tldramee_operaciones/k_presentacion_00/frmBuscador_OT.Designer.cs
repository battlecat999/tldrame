namespace k_presentacion_00
{
    partial class frmBuscador_OT
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
            this.mFechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.mFechaHasta = new System.Windows.Forms.MaskedTextBox();
            this.txtNroOT = new System.Windows.Forms.TextBox();
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.cboTransportista = new System.Windows.Forms.ComboBox();
            this.txtContenedor = new System.Windows.Forms.TextBox();
            this.txtBL = new System.Windows.Forms.TextBox();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.lblOT = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPatente = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // mFechaDesde
            // 
            this.mFechaDesde.Location = new System.Drawing.Point(659, 82);
            this.mFechaDesde.Mask = "00/00/0000";
            this.mFechaDesde.Name = "mFechaDesde";
            this.mFechaDesde.Size = new System.Drawing.Size(97, 23);
            this.mFechaDesde.TabIndex = 0;
            this.mFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // mFechaHasta
            // 
            this.mFechaHasta.Location = new System.Drawing.Point(782, 81);
            this.mFechaHasta.Mask = "00/00/0000";
            this.mFechaHasta.Name = "mFechaHasta";
            this.mFechaHasta.Size = new System.Drawing.Size(97, 23);
            this.mFechaHasta.TabIndex = 1;
            this.mFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // txtNroOT
            // 
            this.txtNroOT.Location = new System.Drawing.Point(14, 82);
            this.txtNroOT.Name = "txtNroOT";
            this.txtNroOT.Size = new System.Drawing.Size(121, 23);
            this.txtNroOT.TabIndex = 2;
            // 
            // cboClientes
            // 
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(174, 82);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(218, 24);
            this.cboClientes.TabIndex = 3;
            this.cboClientes.SelectedIndexChanged += new System.EventHandler(this.cboClientes_SelectedIndexChanged);
            // 
            // cboTransportista
            // 
            this.cboTransportista.FormattingEnabled = true;
            this.cboTransportista.Location = new System.Drawing.Point(424, 82);
            this.cboTransportista.Name = "cboTransportista";
            this.cboTransportista.Size = new System.Drawing.Size(196, 24);
            this.cboTransportista.TabIndex = 5;
            // 
            // txtContenedor
            // 
            this.txtContenedor.Location = new System.Drawing.Point(894, 81);
            this.txtContenedor.Name = "txtContenedor";
            this.txtContenedor.Size = new System.Drawing.Size(121, 23);
            this.txtContenedor.TabIndex = 6;
            // 
            // txtBL
            // 
            this.txtBL.Location = new System.Drawing.Point(1034, 81);
            this.txtBL.Name = "txtBL";
            this.txtBL.Size = new System.Drawing.Size(121, 23);
            this.txtBL.TabIndex = 7;
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBuscar.Location = new System.Drawing.Point(13, 110);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(1550, 43);
            this.cmdBuscar.TabIndex = 8;
            this.cmdBuscar.Text = "Buscar y Exportar a Excel";
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // lblOT
            // 
            this.lblOT.AutoSize = true;
            this.lblOT.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOT.Location = new System.Drawing.Point(11, 63);
            this.lblOT.Name = "lblOT";
            this.lblOT.Size = new System.Drawing.Size(95, 16);
            this.lblOT.TabIndex = 9;
            this.lblOT.Text = "por Nº de OT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(171, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "por Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(421, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "por Transportista";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(669, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "por Fecha de Finalización ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(891, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "por Nro de Cont.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1021, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "por Nro de Booking";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1577, 32);
            this.label1.TabIndex = 17;
            this.label1.Text = "Buscador de Cargas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(13, 172);
            this.dgv.Name = "dgv";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.ShowCellErrors = false;
            this.dgv.Size = new System.Drawing.Size(1550, 526);
            this.dgv.TabIndex = 18;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1172, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "por Patente del Tractor";
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(1185, 82);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(121, 23);
            this.txtPatente.TabIndex = 19;
            // 
            // frmBuscador_OT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1579, 707);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPatente);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblOT);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.txtBL);
            this.Controls.Add(this.txtContenedor);
            this.Controls.Add(this.cboTransportista);
            this.Controls.Add(this.cboClientes);
            this.Controls.Add(this.txtNroOT);
            this.Controls.Add(this.mFechaHasta);
            this.Controls.Add(this.mFechaDesde);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBuscador_OT";
            this.Text = "Buscador de Cargas";
            this.Load += new System.EventHandler(this.frmBuscador_OT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mFechaDesde;
        private System.Windows.Forms.MaskedTextBox mFechaHasta;
        private System.Windows.Forms.TextBox txtNroOT;
        private System.Windows.Forms.ComboBox cboClientes;
        private System.Windows.Forms.ComboBox cboTransportista;
        private System.Windows.Forms.TextBox txtContenedor;
        private System.Windows.Forms.TextBox txtBL;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.Label lblOT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPatente;
    }
}