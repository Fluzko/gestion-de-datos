namespace FrbaOfertas.AbmRol
{
    partial class AbmRol
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
            this.btnLista = new System.Windows.Forms.Button();
            this.btnNuevoRol = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLista);
            this.groupBox1.Controls.Add(this.btnNuevoRol);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(224, 135);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones:";
            // 
            // btnLista
            // 
            this.btnLista.Location = new System.Drawing.Point(15, 87);
            this.btnLista.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLista.Name = "btnLista";
            this.btnLista.Size = new System.Drawing.Size(201, 28);
            this.btnLista.TabIndex = 1;
            this.btnLista.Text = "Listado de roles";
            this.btnLista.UseVisualStyleBackColor = true;
            // 
            // btnNuevoRol
            // 
            this.btnNuevoRol.Location = new System.Drawing.Point(15, 36);
            this.btnNuevoRol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNuevoRol.Name = "btnNuevoRol";
            this.btnNuevoRol.Size = new System.Drawing.Size(201, 28);
            this.btnNuevoRol.TabIndex = 0;
            this.btnNuevoRol.Text = "Alta de un nuevo Rol";
            this.btnNuevoRol.UseVisualStyleBackColor = true;
            this.btnNuevoRol.Click += new System.EventHandler(this.btnNuevoRol_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 170);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AbmRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 213);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AbmRol";
            this.Text = "Accion rol";
            this.Load += new System.EventHandler(this.AbmRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLista;
        private System.Windows.Forms.Button btnNuevoRol;
        private System.Windows.Forms.Button button1;
    }
}