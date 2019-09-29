namespace FrbaOfertas.Facturar
{
    partial class Facturar
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnListaClientes = new System.Windows.Forms.Button();
            this.btnAltaCliente = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clientesGrid = new System.Windows.Forms.DataGridView();
            this.buttonFecha = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textFN = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.buttonFecha);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textFN);
            this.groupBox2.Controls.Add(this.btnListaClientes);
            this.groupBox2.Controls.Add(this.txtUsername);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 154);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nuevo usuario:";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnListaClientes
            // 
            this.btnListaClientes.Location = new System.Drawing.Point(86, 125);
            this.btnListaClientes.Name = "btnListaClientes";
            this.btnListaClientes.Size = new System.Drawing.Size(151, 23);
            this.btnListaClientes.TabIndex = 1;
            this.btnListaClientes.Text = "Buscar ventas";
            this.btnListaClientes.UseVisualStyleBackColor = true;
            // 
            // btnAltaCliente
            // 
            this.btnAltaCliente.Location = new System.Drawing.Point(123, 339);
            this.btnAltaCliente.Name = "btnAltaCliente";
            this.btnAltaCliente.Size = new System.Drawing.Size(167, 23);
            this.btnAltaCliente.TabIndex = 0;
            this.btnAltaCliente.Text = "Facturar";
            this.btnAltaCliente.UseVisualStyleBackColor = true;
            this.btnAltaCliente.Click += new System.EventHandler(this.btnAltaCliente_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(86, 26);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(192, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor:";
            // 
            // clientesGrid
            // 
            this.clientesGrid.AllowUserToAddRows = false;
            this.clientesGrid.AllowUserToDeleteRows = false;
            this.clientesGrid.AllowUserToOrderColumns = true;
            this.clientesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientesGrid.Location = new System.Drawing.Point(12, 172);
            this.clientesGrid.Name = "clientesGrid";
            this.clientesGrid.ReadOnly = true;
            this.clientesGrid.Size = new System.Drawing.Size(418, 161);
            this.clientesGrid.TabIndex = 58;
            // 
            // buttonFecha
            // 
            this.buttonFecha.Location = new System.Drawing.Point(207, 56);
            this.buttonFecha.Name = "buttonFecha";
            this.buttonFecha.Size = new System.Drawing.Size(71, 23);
            this.buttonFecha.TabIndex = 33;
            this.buttonFecha.Text = "Seleccionar";
            this.buttonFecha.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Desde:";
            // 
            // textFN
            // 
            this.textFN.Location = new System.Drawing.Point(86, 56);
            this.textFN.Name = "textFN";
            this.textFN.ReadOnly = true;
            this.textFN.Size = new System.Drawing.Size(111, 20);
            this.textFN.TabIndex = 31;
            this.textFN.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Hasta:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(111, 20);
            this.textBox1.TabIndex = 34;
            this.textBox1.TabStop = false;
            // 
            // Facturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 369);
            this.Controls.Add(this.clientesGrid);
            this.Controls.Add(this.btnAltaCliente);
            this.Controls.Add(this.groupBox2);
            this.Name = "Facturar";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientesGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnListaClientes;
        private System.Windows.Forms.Button btnAltaCliente;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView clientesGrid;
        private System.Windows.Forms.Button buttonFecha;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textFN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}