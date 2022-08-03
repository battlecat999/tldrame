namespace k_presentacion_00
{
    partial class frmPermisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermisos));
            this.trvMeals = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.btnActualizarUsers = new MetroFramework.Controls.MetroButton();
            this.cmbUsers = new MetroFramework.Controls.MetroComboBox();
            this.lblEventos = new MetroFramework.Controls.MetroLabel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvMeals
            // 
            this.trvMeals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvMeals.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trvMeals.CheckBoxes = true;
            this.trvMeals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvMeals.FullRowSelect = true;
            this.trvMeals.Location = new System.Drawing.Point(45, 0);
            this.trvMeals.Name = "trvMeals";
            this.trvMeals.Size = new System.Drawing.Size(409, 576);
            this.trvMeals.TabIndex = 7;
            this.trvMeals.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvMeals_AfterCheck);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(902, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(8, 576);
            this.panel1.TabIndex = 67;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.trvMeals);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(8, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(894, 576);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.metroButton1);
            this.panel3.Controls.Add(this.btnActualizarUsers);
            this.panel3.Controls.Add(this.cmbUsers);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(467, 73);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 70, 10, 0);
            this.panel3.Size = new System.Drawing.Size(435, 576);
            this.panel3.TabIndex = 68;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(167, 273);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(112, 28);
            this.metroButton1.TabIndex = 9;
            this.metroButton1.Text = "Grabar";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.btnShowChecked_Click);
            // 
            // btnActualizarUsers
            // 
            this.btnActualizarUsers.Location = new System.Drawing.Point(302, 72);
            this.btnActualizarUsers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnActualizarUsers.Name = "btnActualizarUsers";
            this.btnActualizarUsers.Size = new System.Drawing.Size(66, 28);
            this.btnActualizarUsers.TabIndex = 2;
            this.btnActualizarUsers.Text = "Actualizar";
            this.btnActualizarUsers.UseSelectable = true;
            this.btnActualizarUsers.Click += new System.EventHandler(this.btnActualizarUsers_Click);
            // 
            // cmbUsers
            // 
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.ItemHeight = 23;
            this.cmbUsers.Location = new System.Drawing.Point(96, 72);
            this.cmbUsers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(194, 29);
            this.cmbUsers.TabIndex = 1;
            this.cmbUsers.Tag = "";
            this.cmbUsers.UseSelectable = true;
            this.cmbUsers.SelectionChangeCommitted += new System.EventHandler(this.cmbUsers_SelectionChangeCommitted);
            // 
            // lblEventos
            // 
            this.lblEventos.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblEventos.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblEventos.ForeColor = System.Drawing.Color.Lime;
            this.lblEventos.Location = new System.Drawing.Point(468, 24);
            this.lblEventos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEventos.Name = "lblEventos";
            this.lblEventos.Size = new System.Drawing.Size(434, 33);
            this.lblEventos.TabIndex = 69;
            this.lblEventos.UseCustomBackColor = true;
            this.lblEventos.UseCustomForeColor = true;
            this.lblEventos.UseStyleColors = true;
            // 
            // frmPermisos
            // 
            this.ApplyImageInvert = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = global::k_presentacion_00.Properties.Resources.Usuario_permisos_mybusinesspos_300x200;
            this.BackImagePadding = new System.Windows.Forms.Padding(210, 10, 0, 0);
            this.BackMaxSize = 80;
            this.ClientSize = new System.Drawing.Size(918, 657);
            this.Controls.Add(this.lblEventos);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPermisos";
            this.Padding = new System.Windows.Forms.Padding(8, 73, 8, 8);
            this.Text = "Permisos Usuarios";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.TreeView trvMeals;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private MetroFramework.Controls.MetroComboBox cmbUsers;
        private MetroFramework.Controls.MetroButton btnActualizarUsers;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel lblEventos;
    }
}

