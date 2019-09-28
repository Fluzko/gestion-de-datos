namespace FrbaOfertas.Login
{
    partial class Funcionalidad
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
            this.cerrarSesion = new System.Windows.Forms.Button();
            this.btnAcceder = new System.Windows.Forms.Button();
            this.funcionalidadescbx = new System.Windows.Forms.ComboBox();
            this.Titulo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cerrarSesion);
            this.groupBox1.Controls.Add(this.btnAcceder);
            this.groupBox1.Controls.Add(this.funcionalidadescbx);
            this.groupBox1.Location = new System.Drawing.Point(16, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 111);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funcionalidades disponibles:";
            // 
            // cerrarSesion
            // 
            this.cerrarSesion.Location = new System.Drawing.Point(0, 88);
            this.cerrarSesion.Name = "cerrarSesion";
            this.cerrarSesion.Size = new System.Drawing.Size(80, 23);
            this.cerrarSesion.TabIndex = 9;
            this.cerrarSesion.Text = "Cerrar Sesion";
            this.cerrarSesion.UseVisualStyleBackColor = true;
            this.cerrarSesion.Click += new System.EventHandler(this.cerrarSesion_Click);
            // 
            // btnAcceder
            // 
            this.btnAcceder.Location = new System.Drawing.Point(158, 88);
            this.btnAcceder.Name = "btnAcceder";
            this.btnAcceder.Size = new System.Drawing.Size(75, 23);
            this.btnAcceder.TabIndex = 8;
            this.btnAcceder.Text = "Entrar";
            this.btnAcceder.UseVisualStyleBackColor = true;
            this.btnAcceder.Click += new System.EventHandler(this.btnAcceder_Click);
            // 
            // funcionalidadescbx
            // 
            this.funcionalidadescbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.funcionalidadescbx.FormattingEnabled = true;
            this.funcionalidadescbx.Location = new System.Drawing.Point(0, 37);
            this.funcionalidadescbx.Name = "funcionalidadescbx";
            this.funcionalidadescbx.Size = new System.Drawing.Size(233, 21);
            this.funcionalidadescbx.TabIndex = 0;
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.Location = new System.Drawing.Point(12, 9);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(58, 23);
            this.Titulo.TabIndex = 7;
            this.Titulo.Text = "Un rol";
            this.Titulo.Click += new System.EventHandler(this.titulo_Click);
            // 
            // Funcionalidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 174);
            this.Controls.Add(this.Titulo);
            this.Controls.Add(this.groupBox1);
            this.Name = "Funcionalidad";
            this.Text = "Seleccion funcionalidad";
            this.Load += new System.EventHandler(this.Funcionalidad_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cerrarSesion;
        private System.Windows.Forms.Button btnAcceder;
        private System.Windows.Forms.ComboBox funcionalidadescbx;
        private System.Windows.Forms.Label Titulo;
    }
}