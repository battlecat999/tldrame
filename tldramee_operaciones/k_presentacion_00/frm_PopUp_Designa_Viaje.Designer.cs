namespace k_presentacion_00
{
    partial class frm_PopUp_Designa_Viaje
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
            this.Timer_Parpadeo = new System.Windows.Forms.Timer(this.components);
            this.Panel = new k_presentacion_00.GradientPanel();
            this.lblBlackList = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBooking = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.lbl_Aviso_Autorizacion = new System.Windows.Forms.Label();
            this.lbl_Titulo_Costo_Transportista = new System.Windows.Forms.Label();
            this.lblCostoProveedor = new System.Windows.Forms.Label();
            this.lbl_Titulo_Costo_Empresa = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDescripcion_Item = new System.Windows.Forms.Label();
            this.lblCostoEmpresa = new System.Windows.Forms.Label();
            this.lblOT = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboChoferes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboChasis = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTractores = new System.Windows.Forms.ComboBox();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.cboTransportista = new System.Windows.Forms.ComboBox();
            this.lblRealizaMoro = new System.Windows.Forms.Label();
            this.lblEsMoro = new System.Windows.Forms.Label();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer_Parpadeo
            // 
            this.Timer_Parpadeo.Tick += new System.EventHandler(this.Timer_Parpadeo_Tick);
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.Panel.ColorButtom = System.Drawing.Color.Empty;
            this.Panel.ColorTop = System.Drawing.Color.Empty;
            this.Panel.Controls.Add(this.lblBlackList);
            this.Panel.Controls.Add(this.label6);
            this.Panel.Controls.Add(this.lblBooking);
            this.Panel.Controls.Add(this.lblItem);
            this.Panel.Controls.Add(this.lbl_Aviso_Autorizacion);
            this.Panel.Controls.Add(this.lbl_Titulo_Costo_Transportista);
            this.Panel.Controls.Add(this.lblCostoProveedor);
            this.Panel.Controls.Add(this.lbl_Titulo_Costo_Empresa);
            this.Panel.Controls.Add(this.label5);
            this.Panel.Controls.Add(this.label4);
            this.Panel.Controls.Add(this.lblDescripcion_Item);
            this.Panel.Controls.Add(this.lblCostoEmpresa);
            this.Panel.Controls.Add(this.lblOT);
            this.Panel.Controls.Add(this.btnSalir);
            this.Panel.Controls.Add(this.btnAsignar);
            this.Panel.Controls.Add(this.label3);
            this.Panel.Controls.Add(this.cboChoferes);
            this.Panel.Controls.Add(this.label2);
            this.Panel.Controls.Add(this.cboChasis);
            this.Panel.Controls.Add(this.label1);
            this.Panel.Controls.Add(this.cboTractores);
            this.Panel.Controls.Add(this.lblRazonSocial);
            this.Panel.Controls.Add(this.cboTransportista);
            this.Panel.Controls.Add(this.lblRealizaMoro);
            this.Panel.Controls.Add(this.lblEsMoro);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(425, 412);
            this.Panel.TabIndex = 34;
            // 
            // lblBlackList
            // 
            this.lblBlackList.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlackList.ForeColor = System.Drawing.Color.White;
            this.lblBlackList.Location = new System.Drawing.Point(-5, 189);
            this.lblBlackList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBlackList.Name = "lblBlackList";
            this.lblBlackList.Size = new System.Drawing.Size(430, 147);
            this.lblBlackList.TabIndex = 56;
            this.lblBlackList.Text = "XXX SE ENCUENTRA BLOQUEADO PARA REALIZAR VIAJES. COMUNICARSE CON MAXIMILIANO RUAT" +
    "A.";
            this.lblBlackList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBlackList.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(19, 71);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 18);
            this.label6.TabIndex = 55;
            this.label6.Text = "BL/Booking";
            // 
            // lblBooking
            // 
            this.lblBooking.AutoSize = true;
            this.lblBooking.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBooking.ForeColor = System.Drawing.Color.White;
            this.lblBooking.Location = new System.Drawing.Point(167, 71);
            this.lblBooking.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBooking.Name = "lblBooking";
            this.lblBooking.Size = new System.Drawing.Size(90, 18);
            this.lblBooking.TabIndex = 54;
            this.lblBooking.Text = "BL/Booking";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.Color.White;
            this.lblItem.Location = new System.Drawing.Point(306, 15);
            this.lblItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(52, 18);
            this.lblItem.TabIndex = 53;
            this.lblItem.Text = "lblItem";
            // 
            // lbl_Aviso_Autorizacion
            // 
            this.lbl_Aviso_Autorizacion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Aviso_Autorizacion.ForeColor = System.Drawing.Color.White;
            this.lbl_Aviso_Autorizacion.Location = new System.Drawing.Point(16, 291);
            this.lbl_Aviso_Autorizacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Aviso_Autorizacion.Name = "lbl_Aviso_Autorizacion";
            this.lbl_Aviso_Autorizacion.Size = new System.Drawing.Size(355, 21);
            this.lbl_Aviso_Autorizacion.TabIndex = 52;
            this.lbl_Aviso_Autorizacion.Text = "Este viaje quedará Pendiente de Autorización";
            this.lbl_Aviso_Autorizacion.Visible = false;
            // 
            // lbl_Titulo_Costo_Transportista
            // 
            this.lbl_Titulo_Costo_Transportista.AutoSize = true;
            this.lbl_Titulo_Costo_Transportista.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titulo_Costo_Transportista.ForeColor = System.Drawing.Color.White;
            this.lbl_Titulo_Costo_Transportista.Location = new System.Drawing.Point(17, 101);
            this.lbl_Titulo_Costo_Transportista.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Titulo_Costo_Transportista.Name = "lbl_Titulo_Costo_Transportista";
            this.lbl_Titulo_Costo_Transportista.Size = new System.Drawing.Size(111, 18);
            this.lbl_Titulo_Costo_Transportista.TabIndex = 51;
            this.lbl_Titulo_Costo_Transportista.Text = "Monto a Pagar";
            this.lbl_Titulo_Costo_Transportista.Visible = false;
            // 
            // lblCostoProveedor
            // 
            this.lblCostoProveedor.AutoSize = true;
            this.lblCostoProveedor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoProveedor.ForeColor = System.Drawing.Color.White;
            this.lblCostoProveedor.Location = new System.Drawing.Point(165, 101);
            this.lblCostoProveedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCostoProveedor.Name = "lblCostoProveedor";
            this.lblCostoProveedor.Size = new System.Drawing.Size(138, 18);
            this.lblCostoProveedor.TabIndex = 50;
            this.lblCostoProveedor.Text = "lblCostoProveedor";
            this.lblCostoProveedor.Visible = false;
            // 
            // lbl_Titulo_Costo_Empresa
            // 
            this.lbl_Titulo_Costo_Empresa.AutoSize = true;
            this.lbl_Titulo_Costo_Empresa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titulo_Costo_Empresa.ForeColor = System.Drawing.Color.White;
            this.lbl_Titulo_Costo_Empresa.Location = new System.Drawing.Point(17, 71);
            this.lbl_Titulo_Costo_Empresa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Titulo_Costo_Empresa.Name = "lbl_Titulo_Costo_Empresa";
            this.lbl_Titulo_Costo_Empresa.Size = new System.Drawing.Size(97, 18);
            this.lbl_Titulo_Costo_Empresa.TabIndex = 49;
            this.lbl_Titulo_Costo_Empresa.Text = "Máx a Pagar";
            this.lbl_Titulo_Costo_Empresa.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(17, 42);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 18);
            this.label5.TabIndex = 48;
            this.label5.Text = "Descripción";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 18);
            this.label4.TabIndex = 47;
            this.label4.Text = "Nº Orden de Transp.";
            // 
            // lblDescripcion_Item
            // 
            this.lblDescripcion_Item.AutoSize = true;
            this.lblDescripcion_Item.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion_Item.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion_Item.Location = new System.Drawing.Point(165, 42);
            this.lblDescripcion_Item.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion_Item.Name = "lblDescripcion_Item";
            this.lblDescripcion_Item.Size = new System.Drawing.Size(145, 18);
            this.lblDescripcion_Item.TabIndex = 46;
            this.lblDescripcion_Item.Text = "lblDescripcion_Item";
            // 
            // lblCostoEmpresa
            // 
            this.lblCostoEmpresa.AutoSize = true;
            this.lblCostoEmpresa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoEmpresa.ForeColor = System.Drawing.Color.White;
            this.lblCostoEmpresa.Location = new System.Drawing.Point(165, 71);
            this.lblCostoEmpresa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCostoEmpresa.Name = "lblCostoEmpresa";
            this.lblCostoEmpresa.Size = new System.Drawing.Size(129, 18);
            this.lblCostoEmpresa.TabIndex = 45;
            this.lblCostoEmpresa.Text = "lblCostoEmpresa";
            this.lblCostoEmpresa.Visible = false;
            // 
            // lblOT
            // 
            this.lblOT.AutoSize = true;
            this.lblOT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOT.ForeColor = System.Drawing.Color.White;
            this.lblOT.Location = new System.Drawing.Point(165, 15);
            this.lblOT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOT.Name = "lblOT";
            this.lblOT.Size = new System.Drawing.Size(44, 18);
            this.lblOT.TabIndex = 44;
            this.lblOT.Text = "lblOT";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(229, 340);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(129, 38);
            this.btnSalir.TabIndex = 43;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(22, 340);
            this.btnAsignar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(129, 38);
            this.btnAsignar.TabIndex = 42;
            this.btnAsignar.Text = "ASIGNAR";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.BtnAsignar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(40, 243);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 41;
            this.label3.Text = "Chofer:";
            // 
            // cboChoferes
            // 
            this.cboChoferes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChoferes.FormattingEnabled = true;
            this.cboChoferes.Location = new System.Drawing.Point(144, 239);
            this.cboChoferes.Margin = new System.Windows.Forms.Padding(4);
            this.cboChoferes.Name = "cboChoferes";
            this.cboChoferes.Size = new System.Drawing.Size(214, 24);
            this.cboChoferes.TabIndex = 40;
            this.cboChoferes.SelectedValueChanged += new System.EventHandler(this.cboChoferes_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(40, 211);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 39;
            this.label2.Text = "Chasis:";
            // 
            // cboChasis
            // 
            this.cboChasis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChasis.FormattingEnabled = true;
            this.cboChasis.Location = new System.Drawing.Point(144, 207);
            this.cboChasis.Margin = new System.Windows.Forms.Padding(4);
            this.cboChasis.Name = "cboChasis";
            this.cboChasis.Size = new System.Drawing.Size(214, 24);
            this.cboChasis.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(40, 179);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "Tractor:";
            // 
            // cboTractores
            // 
            this.cboTractores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTractores.FormattingEnabled = true;
            this.cboTractores.Location = new System.Drawing.Point(144, 175);
            this.cboTractores.Margin = new System.Windows.Forms.Padding(4);
            this.cboTractores.Name = "cboTractores";
            this.cboTractores.Size = new System.Drawing.Size(214, 24);
            this.cboTractores.TabIndex = 36;
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.ForeColor = System.Drawing.Color.White;
            this.lblRazonSocial.Location = new System.Drawing.Point(40, 147);
            this.lblRazonSocial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(95, 16);
            this.lblRazonSocial.TabIndex = 35;
            this.lblRazonSocial.Text = "Transportista:";
            // 
            // cboTransportista
            // 
            this.cboTransportista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransportista.FormattingEnabled = true;
            this.cboTransportista.Location = new System.Drawing.Point(144, 143);
            this.cboTransportista.Margin = new System.Windows.Forms.Padding(4);
            this.cboTransportista.Name = "cboTransportista";
            this.cboTransportista.Size = new System.Drawing.Size(214, 24);
            this.cboTransportista.TabIndex = 34;
            this.cboTransportista.SelectedValueChanged += new System.EventHandler(this.CboTransportista_SelectedValueChanged);
            // 
            // lblRealizaMoro
            // 
            this.lblRealizaMoro.AutoSize = true;
            this.lblRealizaMoro.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRealizaMoro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(134)))), ((int)(((byte)(139)))));
            this.lblRealizaMoro.Location = new System.Drawing.Point(395, 385);
            this.lblRealizaMoro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRealizaMoro.Name = "lblRealizaMoro";
            this.lblRealizaMoro.Size = new System.Drawing.Size(17, 18);
            this.lblRealizaMoro.TabIndex = 58;
            this.lblRealizaMoro.Text = "0";
            // 
            // lblEsMoro
            // 
            this.lblEsMoro.AutoSize = true;
            this.lblEsMoro.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEsMoro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(134)))), ((int)(((byte)(139)))));
            this.lblEsMoro.Location = new System.Drawing.Point(4, 382);
            this.lblEsMoro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEsMoro.Name = "lblEsMoro";
            this.lblEsMoro.Size = new System.Drawing.Size(17, 18);
            this.lblEsMoro.TabIndex = 57;
            this.lblEsMoro.Text = "0";
            // 
            // frm_PopUp_Designa_Viaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(425, 412);
            this.Controls.Add(this.Panel);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_PopUp_Designa_Viaje";
            this.Text = "Asigna Viaje";
            this.Load += new System.EventHandler(this.Frm_PopUp_Designa_Viaje_Load);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPanel Panel;
        private System.Windows.Forms.Label lbl_Titulo_Costo_Empresa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDescripcion_Item;
        private System.Windows.Forms.Label lblCostoEmpresa;
        private System.Windows.Forms.Label lblOT;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboChoferes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboChasis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTractores;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.ComboBox cboTransportista;
        private System.Windows.Forms.Label lbl_Titulo_Costo_Transportista;
        private System.Windows.Forms.Label lblCostoProveedor;
        private System.Windows.Forms.Label lbl_Aviso_Autorizacion;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblBooking;
        private System.Windows.Forms.Label lblBlackList;
        private System.Windows.Forms.Timer Timer_Parpadeo;
        private System.Windows.Forms.Label lblRealizaMoro;
        private System.Windows.Forms.Label lblEsMoro;
    }
}