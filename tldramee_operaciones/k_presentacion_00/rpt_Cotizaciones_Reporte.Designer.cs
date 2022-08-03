namespace k_presentacion_00
{
    partial class rpt_Cotizaciones_Reporte
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rpt_Cotizaciones_Viewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rpt_Cotizaciones_ClaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpt_Cotizaciones_DataSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rpt_Cotizaciones_ClaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpt_Cotizaciones_DataSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpt_Cotizaciones_Viewer
            // 
            this.rpt_Cotizaciones_Viewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rpt_Cotizaciones_Viewer.DocumentMapWidth = 12;
            reportDataSource1.Name = "DS_Cotizaciones";
            reportDataSource1.Value = this.rpt_Cotizaciones_ClaseBindingSource;
            this.rpt_Cotizaciones_Viewer.LocalReport.DataSources.Add(reportDataSource1);
            this.rpt_Cotizaciones_Viewer.LocalReport.ReportEmbeddedResource = "k_presentacion_00.rpt_Cotizaciones.rdlc";
            this.rpt_Cotizaciones_Viewer.Location = new System.Drawing.Point(1, 0);
            this.rpt_Cotizaciones_Viewer.Name = "rpt_Cotizaciones_Viewer";
            this.rpt_Cotizaciones_Viewer.ServerReport.BearerToken = null;
            this.rpt_Cotizaciones_Viewer.Size = new System.Drawing.Size(600, 526);
            this.rpt_Cotizaciones_Viewer.TabIndex = 1;
            // 
            // rpt_Cotizaciones_ClaseBindingSource
            // 
            this.rpt_Cotizaciones_ClaseBindingSource.DataSource = typeof(k_presentacion_00.rpt_Cotizaciones_Clase);
            // 
            // rpt_Cotizaciones_DataSource
            // 
            this.rpt_Cotizaciones_DataSource.DataSource = typeof(k_presentacion_00.rpt_Cotizaciones_Clase);
            // 
            // rpt_Cotizaciones_Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 525);
            this.Controls.Add(this.rpt_Cotizaciones_Viewer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "rpt_Cotizaciones_Reporte";
            this.Text = "rpt_Cotizaciones_Reporte";
            this.Load += new System.EventHandler(this.rpt_Cotizaciones_Reporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rpt_Cotizaciones_ClaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpt_Cotizaciones_DataSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource rpt_Cotizaciones_DataSource;
        private Microsoft.Reporting.WinForms.ReportViewer rpt_Cotizaciones_Viewer;
        private System.Windows.Forms.BindingSource rpt_Cotizaciones_ClaseBindingSource;
    }
}