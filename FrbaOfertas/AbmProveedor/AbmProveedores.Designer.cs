namespace FrbaOfertas.AbmProveedor
{
    partial class AbmProveedores
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonModificarProveedor = new System.Windows.Forms.Button();
            this.buttonAltaProveedor = new System.Windows.Forms.Button();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonModificarProveedor);
            this.groupBox1.Controls.Add(this.buttonAltaProveedor);
            this.groupBox1.Location = new System.Drawing.Point(30, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones";
            // 
            // buttonModificarProveedor
            // 
            this.buttonModificarProveedor.Location = new System.Drawing.Point(20, 78);
            this.buttonModificarProveedor.Name = "buttonModificarProveedor";
            this.buttonModificarProveedor.Size = new System.Drawing.Size(184, 31);
            this.buttonModificarProveedor.TabIndex = 1;
            this.buttonModificarProveedor.Text = "Modificar proveedor";
            this.buttonModificarProveedor.UseVisualStyleBackColor = true;
            this.buttonModificarProveedor.Click += new System.EventHandler(this.buttonModificarProveedor_Click);
            // 
            // buttonAltaProveedor
            // 
            this.buttonAltaProveedor.Location = new System.Drawing.Point(20, 32);
            this.buttonAltaProveedor.Name = "buttonAltaProveedor";
            this.buttonAltaProveedor.Size = new System.Drawing.Size(184, 31);
            this.buttonAltaProveedor.TabIndex = 0;
            this.buttonAltaProveedor.Text = "Alta de nuevo proveedor";
            this.buttonAltaProveedor.UseVisualStyleBackColor = true;
            this.buttonAltaProveedor.Click += new System.EventHandler(this.buttonAltaProveedor_Click);
            // 
            // buttonVolver
            // 
            this.buttonVolver.Location = new System.Drawing.Point(96, 176);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(86, 30);
            this.buttonVolver.TabIndex = 1;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // AbmProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 251);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.groupBox1);
            this.Name = "AbmProveedores";
            this.Text = "Proveedores";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAltaProveedor;
        private System.Windows.Forms.Button buttonModificarProveedor;
        private System.Windows.Forms.Button buttonVolver;
    }
}