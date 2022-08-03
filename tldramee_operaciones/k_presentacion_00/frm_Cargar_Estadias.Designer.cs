namespace k_presentacion_00
{
    partial class frm_Cargar_Estadias
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
            this.datFechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.cboCantidad = new System.Windows.Forms.ComboBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.cmdGrabar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblOT = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.datFechaFin = new System.Windows.Forms.MaskedTextBox();
            this.txtNroContenedor = new System.Windows.Forms.MaskedTextBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // datFechaDesde
            // 
            this.datFechaDesde.Location = new System.Drawing.Point(61, 51);
            this.datFechaDesde.Mask = "00/00/0000";
            this.datFechaDesde.Name = "datFechaDesde";
            this.datFechaDesde.Size = new System.Drawing.Size(101, 21);
            this.datFechaDesde.TabIndex = 0;
            this.datFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.datFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(423, 51);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(132, 21);
            this.txtPrecio.TabIndex = 2;
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecio.Enter += new System.EventHandler(this.TextBoxFormattedOnEnter);
            this.txtPrecio.Leave += new System.EventHandler(this.TextBoxFormattedOnLeave);
            // 
            // cboCantidad
            // 
            this.cboCantidad.FormattingEnabled = true;
            this.cboCantidad.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cboCantidad.Location = new System.Drawing.Point(192, 49);
            this.cboCantidad.Name = "cboCantidad";
            this.cboCantidad.Size = new System.Drawing.Size(98, 23);
            this.cboCantidad.TabIndex = 4;
            this.cboCantidad.SelectedIndexChanged += new System.EventHandler(this.cboCantidad_SelectedIndexChanged);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(61, 78);
            this.txtObservaciones.MaxLength = 100;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(628, 179);
            this.txtObservaciones.TabIndex = 5;
            // 
            // cmdGrabar
            // 
            this.cmdGrabar.Location = new System.Drawing.Point(256, 276);
            this.cmdGrabar.Name = "cmdGrabar";
            this.cmdGrabar.Size = new System.Drawing.Size(180, 30);
            this.cmdGrabar.TabIndex = 6;
            this.cmdGrabar.Text = "Grabar y Cerrar";
            this.cmdGrabar.UseVisualStyleBackColor = true;
            this.cmdGrabar.Click += new System.EventHandler(this.cmdGrabar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Fecha de Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Cantidad de días";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Precio por Día";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(561, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Contenedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(379, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nº de Viaje (Ítem)";
            // 
            // lblOT
            // 
            this.lblOT.AutoSize = true;
            this.lblOT.Location = new System.Drawing.Point(164, 9);
            this.lblOT.Name = "lblOT";
            this.lblOT.Size = new System.Drawing.Size(23, 15);
            this.lblOT.TabIndex = 12;
            this.lblOT.Text = "OT";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(58, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Nº de OT";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(501, 9);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(32, 15);
            this.lblItem.TabIndex = 14;
            this.lblItem.Text = "Item";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(305, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Fecha Fin";
            // 
            // datFechaFin
            // 
            this.datFechaFin.Location = new System.Drawing.Point(308, 51);
            this.datFechaFin.Mask = "00/00/0000";
            this.datFechaFin.Name = "datFechaFin";
            this.datFechaFin.Size = new System.Drawing.Size(101, 21);
            this.datFechaFin.TabIndex = 15;
            this.datFechaFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.datFechaFin.ValidatingType = typeof(System.DateTime);
            // 
            // txtNroContenedor
            // 
            this.txtNroContenedor.Location = new System.Drawing.Point(561, 51);
            this.txtNroContenedor.Mask = ">LLLL0000000";
            this.txtNroContenedor.Name = "txtNroContenedor";
            this.txtNroContenedor.Size = new System.Drawing.Size(129, 21);
            this.txtNroContenedor.TabIndex = 71;
            this.txtNroContenedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.ForeColor = System.Drawing.SystemColors.Control;
            this.lblEmpresa.Location = new System.Drawing.Point(107, 291);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(58, 15);
            this.lblEmpresa.TabIndex = 72;
            this.lblEmpresa.Text = "Empresa";
            // 
            // frm_Cargar_Estadias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 318);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.txtNroContenedor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.datFechaFin);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblOT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdGrabar);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.cboCantidad);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.datFechaDesde);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frm_Cargar_Estadias";
            this.Text = "Carga de Estadías";
            this.Load += new System.EventHandler(this.frm_Cargar_Estadias_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox datFechaDesde;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.ComboBox cboCantidad;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button cmdGrabar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblOT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox datFechaFin;
        private System.Windows.Forms.MaskedTextBox txtNroContenedor;
        private System.Windows.Forms.Label lblEmpresa;
    }
}