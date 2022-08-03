namespace k_presentacion_00
{
    partial class frmAyuda
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
            this.grdAyuda = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdAyuda)).BeginInit();
            this.SuspendLayout();
            // 
            // grdAyuda
            // 
            this.grdAyuda.AllowUserToAddRows = false;
            this.grdAyuda.AllowUserToDeleteRows = false;
            this.grdAyuda.AllowUserToResizeRows = false;
            this.grdAyuda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdAyuda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAyuda.Location = new System.Drawing.Point(13, 68);
            this.grdAyuda.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdAyuda.Name = "grdAyuda";
            this.grdAyuda.ReadOnly = true;
            this.grdAyuda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAyuda.Size = new System.Drawing.Size(581, 185);
            this.grdAyuda.TabIndex = 0;
            this.grdAyuda.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdAyuda_CellDoubleClick);
            // 
            // frmAyuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 292);
            this.Controls.Add(this.grdAyuda);
            this.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAyuda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmAyuda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAyuda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdAyuda;
    }
}