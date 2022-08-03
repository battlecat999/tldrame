namespace k_presentacion_00
{
    partial class frm_CorredorTransportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CorredorTransportes));
            this.cboTransportistas = new System.Windows.Forms.ComboBox();
            this.cboRutas = new System.Windows.Forms.ComboBox();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.c_Activo = new System.Windows.Forms.CheckBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdGuadar = new System.Windows.Forms.Button();
            this.cmdEditar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.pClose = new System.Windows.Forms.PictureBox();
            this.txtSimboloPeso = new System.Windows.Forms.TextBox();
            this.txtIdCorredor = new k_TextBox_Num.k_textbox_n();
            this.lblmensaje = new System.Windows.Forms.Label();
            this.cmdActualizar = new System.Windows.Forms.Button();
            this.pminimizar = new System.Windows.Forms.PictureBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pminimizar)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTransportistas
            // 
            this.cboTransportistas.FormattingEnabled = true;
            this.cboTransportistas.Location = new System.Drawing.Point(21, 78);
            this.cboTransportistas.Name = "cboTransportistas";
            this.cboTransportistas.Size = new System.Drawing.Size(280, 25);
            this.cboTransportistas.TabIndex = 0;
            // 
            // cboRutas
            // 
            this.cboRutas.FormattingEnabled = true;
            this.cboRutas.Location = new System.Drawing.Point(335, 78);
            this.cboRutas.Name = "cboRutas";
            this.cboRutas.Size = new System.Drawing.Size(268, 25);
            this.cboRutas.TabIndex = 1;
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgw.ColumnHeadersHeight = 40;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgw.EnableHeadersVisualStyles = false;
            this.dgw.GridColor = System.Drawing.Color.SteelBlue;
            this.dgw.Location = new System.Drawing.Point(26, 182);
            this.dgw.Name = "dgw";
            this.dgw.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgw.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgw.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(1042, 335);
            this.dgw.TabIndex = 21;
            this.dgw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgw_KeyDown);
            // 
            // c_Activo
            // 
            this.c_Activo.AutoSize = true;
            this.c_Activo.Checked = true;
            this.c_Activo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c_Activo.ForeColor = System.Drawing.Color.White;
            this.c_Activo.Location = new System.Drawing.Point(826, 80);
            this.c_Activo.Name = "c_Activo";
            this.c_Activo.Size = new System.Drawing.Size(71, 23);
            this.c_Activo.TabIndex = 9;
            this.c_Activo.Text = "Activo";
            this.c_Activo.UseVisualStyleBackColor = true;
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(669, 80);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(120, 24);
            this.txtCosto.TabIndex = 7;
            this.txtCosto.Text = "Costo";
            this.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCosto.Enter += new System.EventHandler(this.TextBoxFormattedOnEnter);
            this.txtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxChangeOnKeyPress);
            this.txtCosto.Leave += new System.EventHandler(this.TextBoxFormattedOnLeave);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Transportista";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(332, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(271, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ruta Seleccionada";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(642, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Costo del Viaje";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(23, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(257, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Detalle de Viajes...";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(23, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "Asociar Rutas a Transportes";
            // 
            // cmdGuadar
            // 
            this.cmdGuadar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.cmdGuadar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGuadar.ForeColor = System.Drawing.Color.White;
            this.cmdGuadar.Location = new System.Drawing.Point(863, 131);
            this.cmdGuadar.Name = "cmdGuadar";
            this.cmdGuadar.Size = new System.Drawing.Size(178, 34);
            this.cmdGuadar.TabIndex = 11;
            this.cmdGuadar.Text = "Guardar";
            this.cmdGuadar.UseVisualStyleBackColor = false;
            this.cmdGuadar.Click += new System.EventHandler(this.cmdGuadar_Click);
            // 
            // cmdEditar
            // 
            this.cmdEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.cmdEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEditar.ForeColor = System.Drawing.Color.White;
            this.cmdEditar.Location = new System.Drawing.Point(26, 535);
            this.cmdEditar.Name = "cmdEditar";
            this.cmdEditar.Size = new System.Drawing.Size(178, 34);
            this.cmdEditar.TabIndex = 19;
            this.cmdEditar.Text = "Editar";
            this.cmdEditar.UseVisualStyleBackColor = false;
            this.cmdEditar.Click += new System.EventHandler(this.cmdEditar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSalir.ForeColor = System.Drawing.Color.White;
            this.cmdSalir.Location = new System.Drawing.Point(890, 535);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(178, 34);
            this.cmdSalir.TabIndex = 20;
            this.cmdSalir.Text = "Cerrar";
            this.cmdSalir.UseVisualStyleBackColor = false;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // pClose
            // 
            this.pClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pClose.Image = global::k_presentacion_00.Properties.Resources.cerrar;
            this.pClose.Location = new System.Drawing.Point(1044, 3);
            this.pClose.Name = "pClose";
            this.pClose.Size = new System.Drawing.Size(24, 18);
            this.pClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pClose.TabIndex = 29;
            this.pClose.TabStop = false;
            this.pClose.Click += new System.EventHandler(this.pClose_Click);
            // 
            // txtSimboloPeso
            // 
            this.txtSimboloPeso.Enabled = false;
            this.txtSimboloPeso.Location = new System.Drawing.Point(628, 80);
            this.txtSimboloPeso.Name = "txtSimboloPeso";
            this.txtSimboloPeso.Size = new System.Drawing.Size(35, 24);
            this.txtSimboloPeso.TabIndex = 30;
            this.txtSimboloPeso.Text = "$";
            this.txtSimboloPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIdCorredor
            // 
            this.txtIdCorredor.Location = new System.Drawing.Point(905, 78);
            this.txtIdCorredor.Name = "txtIdCorredor";
            this.txtIdCorredor.Size = new System.Drawing.Size(107, 24);
            this.txtIdCorredor.TabIndex = 31;
            this.txtIdCorredor.Text = "idCorredor";
            this.txtIdCorredor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdCorredor.Visible = false;
            // 
            // lblmensaje
            // 
            this.lblmensaje.BackColor = System.Drawing.Color.GreenYellow;
            this.lblmensaje.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmensaje.ForeColor = System.Drawing.Color.DarkRed;
            this.lblmensaje.Location = new System.Drawing.Point(114, 138);
            this.lblmensaje.Name = "lblmensaje";
            this.lblmensaje.Size = new System.Drawing.Size(706, 23);
            this.lblmensaje.TabIndex = 32;
            this.lblmensaje.Text = "Destino del Viaje";
            this.lblmensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblmensaje.Visible = false;
            // 
            // cmdActualizar
            // 
            this.cmdActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.cmdActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdActualizar.ForeColor = System.Drawing.Color.White;
            this.cmdActualizar.Location = new System.Drawing.Point(222, 535);
            this.cmdActualizar.Name = "cmdActualizar";
            this.cmdActualizar.Size = new System.Drawing.Size(178, 34);
            this.cmdActualizar.TabIndex = 33;
            this.cmdActualizar.Text = "Actualizar";
            this.cmdActualizar.UseVisualStyleBackColor = false;
            this.cmdActualizar.Click += new System.EventHandler(this.cmdActualizar_Click);
            // 
            // pminimizar
            // 
            this.pminimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pminimizar.Image = ((System.Drawing.Image)(resources.GetObject("pminimizar.Image")));
            this.pminimizar.Location = new System.Drawing.Point(1018, 3);
            this.pminimizar.Name = "pminimizar";
            this.pminimizar.Size = new System.Drawing.Size(20, 18);
            this.pminimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pminimizar.TabIndex = 34;
            this.pminimizar.TabStop = false;
            this.pminimizar.Click += new System.EventHandler(this.pminimizar_Click_1);
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.White;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblUsuario.Location = new System.Drawing.Point(729, 3);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(283, 18);
            this.lblUsuario.TabIndex = 35;
            this.lblUsuario.Text = "label1";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_CorredorTransportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(1076, 586);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pminimizar);
            this.Controls.Add(this.cmdActualizar);
            this.Controls.Add(this.lblmensaje);
            this.Controls.Add(this.txtIdCorredor);
            this.Controls.Add(this.txtSimboloPeso);
            this.Controls.Add(this.pClose);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdEditar);
            this.Controls.Add(this.cmdGuadar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.c_Activo);
            this.Controls.Add(this.dgw);
            this.Controls.Add(this.cboRutas);
            this.Controls.Add(this.cboTransportistas);
            this.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_CorredorTransportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_CorredorTransportes";
            this.Load += new System.EventHandler(this.frm_CorredorTransportes_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_CorredorTransportes_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pminimizar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTransportistas;
        private System.Windows.Forms.ComboBox cboRutas;
        private System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.CheckBox c_Activo;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdGuadar;
        private System.Windows.Forms.Button cmdEditar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.PictureBox pClose;
        private System.Windows.Forms.TextBox txtSimboloPeso;
        private k_TextBox_Num.k_textbox_n txtIdCorredor;
        private System.Windows.Forms.Label lblmensaje;
        private System.Windows.Forms.Button cmdActualizar;
        private System.Windows.Forms.PictureBox pminimizar;
        private System.Windows.Forms.Label lblUsuario;
    }
}