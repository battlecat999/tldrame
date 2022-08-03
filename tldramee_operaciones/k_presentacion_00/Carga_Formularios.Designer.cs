namespace k_presentacion_00
{
    partial class Carga_Formularios
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
            this.button1 = new System.Windows.Forms.Button();
            this.lstForms = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(221, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(242, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstForms
            // 
            this.lstForms.FormattingEnabled = true;
            this.lstForms.Location = new System.Drawing.Point(86, 125);
            this.lstForms.Name = "lstForms";
            this.lstForms.Size = new System.Drawing.Size(477, 329);
            this.lstForms.TabIndex = 2;
            // 
            // Carga_Formularios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 542);
            this.Controls.Add(this.lstForms);
            this.Controls.Add(this.button1);
            this.Name = "Carga_Formularios";
            this.Text = "Carga_Formularios";
            this.Load += new System.EventHandler(this.Carga_Formularios_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstForms;
    }
}