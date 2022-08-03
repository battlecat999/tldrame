namespace k_presentacion_00
{
    partial class frm_Emision_Reporte_Cotizaciones
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
            this.label14 = new System.Windows.Forms.Label();
            this.cboRazonSocial = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboRutas = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.datFechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.datFechaHasta = new System.Windows.Forms.MaskedTextBox();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(42, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 17);
            this.label14.TabIndex = 105;
            this.label14.Text = "Clientes";
            // 
            // cboRazonSocial
            // 
            this.cboRazonSocial.FormattingEnabled = true;
            this.cboRazonSocial.Location = new System.Drawing.Point(139, 26);
            this.cboRazonSocial.Name = "cboRazonSocial";
            this.cboRazonSocial.Size = new System.Drawing.Size(420, 22);
            this.cboRazonSocial.TabIndex = 104;
            this.cboRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cboRazonSocial_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 107;
            this.label4.Text = "¿Qué Ruta?";
            // 
            // cboRutas
            // 
            this.cboRutas.DropDownWidth = 500;
            this.cboRutas.FormattingEnabled = true;
            this.cboRutas.Location = new System.Drawing.Point(139, 68);
            this.cboRutas.Name = "cboRutas";
            this.cboRutas.Size = new System.Drawing.Size(230, 22);
            this.cboRutas.TabIndex = 106;
            this.cboRutas.SelectedIndexChanged += new System.EventHandler(this.cboRutas_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
            this.label20.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(42, 118);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(97, 17);
            this.label20.TabIndex = 132;
            this.label20.Text = "Vigencia Desde";
            // 
            // datFechaDesde
            // 
            this.datFechaDesde.Location = new System.Drawing.Point(154, 118);
            this.datFechaDesde.Mask = "00/00/0000";
            this.datFechaDesde.Name = "datFechaDesde";
            this.datFechaDesde.Size = new System.Drawing.Size(92, 22);
            this.datFechaDesde.TabIndex = 129;
            this.datFechaDesde.Text = "01032020";
            this.datFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.datFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
            this.label19.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(252, 118);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(94, 17);
            this.label19.TabIndex = 131;
            this.label19.Text = "Vigencia Hasta";
            // 
            // datFechaHasta
            // 
            this.datFechaHasta.Location = new System.Drawing.Point(352, 118);
            this.datFechaHasta.Mask = "00/00/0000";
            this.datFechaHasta.Name = "datFechaHasta";
            this.datFechaHasta.Size = new System.Drawing.Size(87, 22);
            this.datFechaHasta.TabIndex = 130;
            this.datFechaHasta.Text = "31122050";
            this.datFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.datFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Image = global::k_presentacion_00.Properties.Resources.file_empty;
            this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImprimir.Location = new System.Drawing.Point(198, 167);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(163, 51);
            this.cmdImprimir.TabIndex = 133;
            this.cmdImprimir.Text = "Imprimir";
            this.cmdImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdImprimir.UseVisualStyleBackColor = true;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // frm_Emision_Reporte_Cotizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(235)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(589, 235);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.datFechaDesde);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.datFechaHasta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboRutas);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cboRazonSocial);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frm_Emision_Reporte_Cotizaciones";
            this.Text = "Emisión Reporte de Cotizaciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboRazonSocial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboRutas;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.MaskedTextBox datFechaDesde;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.MaskedTextBox datFechaHasta;
        private System.Windows.Forms.Button cmdImprimir;
    }
}