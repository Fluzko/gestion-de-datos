namespace FrbaOfertas.AbmCliente
{
    partial class AbmCliente
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
            this.btnListaClientes = new System.Windows.Forms.Button();
            this.btnAltaCliente = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnListaClientes);
            this.groupBox1.Controls.Add(this.btnAltaCliente);
            this.groupBox1.Location = new System.Drawing.Point(22, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 110);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones:";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnListaClientes
            // 
            this.btnListaClientes.Location = new System.Drawing.Point(11, 71);
            this.btnListaClientes.Name = "btnListaClientes";
            this.btnListaClientes.Size = new System.Drawing.Size(151, 23);
            this.btnListaClientes.TabIndex = 1;
            this.btnListaClientes.Text = "Modificar Cliente";
            this.btnListaClientes.UseVisualStyleBackColor = true;
            this.btnListaClientes.Click += new System.EventHandler(this.btnListaClientes_Click);
            // 
            // btnAltaCliente
            // 
            this.btnAltaCliente.Location = new System.Drawing.Point(11, 29);
            this.btnAltaCliente.Name = "btnAltaCliente";
            this.btnAltaCliente.Size = new System.Drawing.Size(151, 23);
            this.btnAltaCliente.TabIndex = 0;
            this.btnAltaCliente.Text = "Alta de un nuevo Cliente";
            this.btnAltaCliente.UseVisualStyleBackColor = true;
            this.btnAltaCliente.Click += new System.EventHandler(this.btnAltaCliente_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AbmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 202);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "AbmCliente";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnListaClientes;
        private System.Windows.Forms.Button btnAltaCliente;
        private System.Windows.Forms.Button button1;

    }
}