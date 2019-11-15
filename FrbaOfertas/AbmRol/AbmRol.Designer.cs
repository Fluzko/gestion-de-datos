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
            this.buttonVolver = new System.Windows.Forms.Button();
            this.buttonEliminarRol = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonEliminarRol);
            this.groupBox1.Controls.Add(this.btnLista);
            this.groupBox1.Controls.Add(this.btnNuevoRol);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(224, 187);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones:";
            // 
            // btnLista
            // 
            this.btnLista.Location = new System.Drawing.Point(15, 87);
            this.btnLista.Margin = new System.Windows.Forms.Padding(4);
            this.btnLista.Name = "btnLista";
            this.btnLista.Size = new System.Drawing.Size(201, 28);
            this.btnLista.TabIndex = 1;
            this.btnLista.Text = "Listado de roles";
            this.btnLista.UseVisualStyleBackColor = true;
            this.btnLista.Click += new System.EventHandler(this.btnLista_Click);
            // 
            // btnNuevoRol
            // 
            this.btnNuevoRol.Location = new System.Drawing.Point(15, 36);
            this.btnNuevoRol.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevoRol.Name = "btnNuevoRol";
            this.btnNuevoRol.Size = new System.Drawing.Size(201, 28);
            this.btnNuevoRol.TabIndex = 0;
            this.btnNuevoRol.Text = "Alta de un nuevo Rol";
            this.btnNuevoRol.UseVisualStyleBackColor = true;
            this.btnNuevoRol.Click += new System.EventHandler(this.btnNuevoRol_Click);
            // 
            // buttonVolver
            // 
            this.buttonVolver.Location = new System.Drawing.Point(80, 235);
            this.buttonVolver.Margin = new System.Windows.Forms.Padding(4);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(100, 28);
            this.buttonVolver.TabIndex = 2;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // buttonEliminarRol
            // 
            this.buttonEliminarRol.Location = new System.Drawing.Point(15, 134);
            this.buttonEliminarRol.Name = "buttonEliminarRol";
            this.buttonEliminarRol.Size = new System.Drawing.Size(201, 28);
            this.buttonEliminarRol.TabIndex = 2;
            this.buttonEliminarRol.Text = "Eliminar Rol";
            this.buttonEliminarRol.UseVisualStyleBackColor = true;
            this.buttonEliminarRol.Click += new System.EventHandler(this.buttonEliminarRol_Click);
            // 
            // AbmRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 285);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonVolver);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.Button buttonEliminarRol;
    }
}