namespace k_presentacion_00
{
    partial class frmCM2
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
            this.mFechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.mFechaHasta = new System.Windows.Forms.MaskedTextBox();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mFechaDesde
            // 
            this.mFechaDesde.Location = new System.Drawing.Point(13, 68);
            this.mFechaDesde.Mask = "00/00/0000";
            this.mFechaDesde.Name = "mFechaDesde";
            this.mFechaDesde.Size = new System.Drawing.Size(97, 23);
            this.mFechaDesde.TabIndex = 0;
            this.mFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // mFechaHasta
            // 
            this.mFechaHasta.Location = new System.Drawing.Point(136, 67);
            this.mFechaHasta.Mask = "00/00/0000";
            this.mFechaHasta.Name = "mFechaHasta";
            this.mFechaHasta.Size = new System.Drawing.Size(97, 23);
            this.mFechaHasta.TabIndex = 1;
            this.mFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Location = new System.Drawing.Point(267, 57);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(213, 43);
            this.cmdBuscar.TabIndex = 8;
            this.cmdBuscar.Text = "Buscar y Exportar a Excel";
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(243, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Fecha Desde - Fecha Hasta (Pos.)";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(477, 32);
            this.label1.TabIndex = 17;
            this.label1.Text = "Buscador de Ordenes de Transportes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCM2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(490, 116);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.mFechaHasta);
            this.Controls.Add(this.mFechaDesde);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCM2";
            this.Text = "Emite CM2";
            this.Load += new System.EventHandler(this.frmCM2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mFechaDesde;
        private System.Windows.Forms.MaskedTextBox mFechaHasta;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}