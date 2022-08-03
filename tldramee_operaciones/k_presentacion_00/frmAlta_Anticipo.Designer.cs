namespace k_presentacion_00
{
    partial class frmAlta_Anticipo
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
            this.lblDescripcion_Item = new System.Windows.Forms.Label();
            this.lblOT = new System.Windows.Forms.Label();
            this.lblTransportista = new System.Windows.Forms.Label();
            this.grdAnticipos = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblContenedor = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblEsMoro = new System.Windows.Forms.Label();
            this.lblTipoViajeEspecial = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnticipos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescripcion_Item
            // 
            this.lblDescripcion_Item.AutoSize = true;
            this.lblDescripcion_Item.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion_Item.Location = new System.Drawing.Point(14, 43);
            this.lblDescripcion_Item.Name = "lblDescripcion_Item";
            this.lblDescripcion_Item.Size = new System.Drawing.Size(160, 19);
            this.lblDescripcion_Item.TabIndex = 32;
            this.lblDescripcion_Item.Text = "lblDescripcion_Item";
            // 
            // lblOT
            // 
            this.lblOT.AutoSize = true;
            this.lblOT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOT.Location = new System.Drawing.Point(14, 11);
            this.lblOT.Name = "lblOT";
            this.lblOT.Size = new System.Drawing.Size(49, 19);
            this.lblOT.TabIndex = 31;
            this.lblOT.Text = "lblOT";
            // 
            // lblTransportista
            // 
            this.lblTransportista.AutoSize = true;
            this.lblTransportista.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransportista.Location = new System.Drawing.Point(14, 75);
            this.lblTransportista.Name = "lblTransportista";
            this.lblTransportista.Size = new System.Drawing.Size(128, 19);
            this.lblTransportista.TabIndex = 33;
            this.lblTransportista.Text = "lblTransportista";
            // 
            // grdAnticipos
            // 
            this.grdAnticipos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.grdAnticipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAnticipos.Location = new System.Drawing.Point(17, 204);
            this.grdAnticipos.Name = "grdAnticipos";
            this.grdAnticipos.Size = new System.Drawing.Size(884, 241);
            this.grdAnticipos.TabIndex = 34;
            this.grdAnticipos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdAnticipos_CellEndEdit);
            this.grdAnticipos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GrdAnticipos_CellFormatting);
            this.grdAnticipos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdAnticipos_CellValueChanged);
            this.grdAnticipos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdAnticipos_DataError);
            this.grdAnticipos.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.GrdAnticipos_DefaultValuesNeeded);
            
            this.grdAnticipos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdAnticipos_KeyDown);
            // 
            // btnNuevo
            // 
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(17, 161);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(128, 35);
            this.btnNuevo.TabIndex = 35;
            this.btnNuevo.Text = "NUEVO ANTICIPO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Location = new System.Drawing.Point(17, 451);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(128, 35);
            this.btnGrabar.TabIndex = 36;
            this.btnGrabar.Text = "GRABAR";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(326, 451);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(128, 35);
            this.btnSalir.TabIndex = 37;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // lblContenedor
            // 
            this.lblContenedor.AutoSize = true;
            this.lblContenedor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContenedor.Location = new System.Drawing.Point(14, 107);
            this.lblContenedor.Name = "lblContenedor";
            this.lblContenedor.Size = new System.Drawing.Size(118, 19);
            this.lblContenedor.TabIndex = 38;
            this.lblContenedor.Text = "lblContenedor";
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(172, 451);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(128, 35);
            this.btnEliminar.TabIndex = 39;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.cmdEliminar_Click);
            // 
            // lblEsMoro
            // 
            this.lblEsMoro.AutoSize = true;
            this.lblEsMoro.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEsMoro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(134)))), ((int)(((byte)(139)))));
            this.lblEsMoro.Location = new System.Drawing.Point(884, 9);
            this.lblEsMoro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEsMoro.Name = "lblEsMoro";
            this.lblEsMoro.Size = new System.Drawing.Size(17, 18);
            this.lblEsMoro.TabIndex = 58;
            this.lblEsMoro.Text = "0";
            // 
            // lblTipoViajeEspecial
            // 
            this.lblTipoViajeEspecial.AutoSize = true;
            this.lblTipoViajeEspecial.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoViajeEspecial.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTipoViajeEspecial.Location = new System.Drawing.Point(673, 9);
            this.lblTipoViajeEspecial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoViajeEspecial.Name = "lblTipoViajeEspecial";
            this.lblTipoViajeEspecial.Size = new System.Drawing.Size(175, 19);
            this.lblTipoViajeEspecial.TabIndex = 59;
            this.lblTipoViajeEspecial.Text = "Realiza Viaje Especial";
            // 
            // frmAlta_Anticipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(933, 500);
            this.Controls.Add(this.lblTipoViajeEspecial);
            this.Controls.Add(this.lblEsMoro);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblContenedor);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grdAnticipos);
            this.Controls.Add(this.lblTransportista);
            this.Controls.Add(this.lblDescripcion_Item);
            this.Controls.Add(this.lblOT);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmAlta_Anticipo";
            this.Text = "Alta de Anticipo";
            this.Load += new System.EventHandler(this.FrmAlta_Anticipo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAnticipos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescripcion_Item;
        private System.Windows.Forms.Label lblOT;
        private System.Windows.Forms.Label lblTransportista;
        private System.Windows.Forms.DataGridView grdAnticipos;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblContenedor;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblEsMoro;
        private System.Windows.Forms.Label lblTipoViajeEspecial;
    }
}