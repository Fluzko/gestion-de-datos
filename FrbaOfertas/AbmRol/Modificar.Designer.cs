namespace FrbaOfertas.AbmRol
{
    partial class Modificar
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
            this.tablaFuncionalidades = new System.Windows.Forms.DataGridView();
            this.Elegir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.cbxRolEstadoNuevo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRolEstadoActual = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtRolNombreNuevo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRolNombreActual = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaFuncionalidades)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tablaFuncionalidades);
            this.groupBox1.Controls.Add(this.btnCerrar);
            this.groupBox1.Controls.Add(this.cbxRolEstadoNuevo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtRolEstadoActual);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.txtRolNombreNuevo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtRolNombreActual);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(384, 514);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificar rol actual:";
            // 
            // tablaFuncionalidades
            // 
            this.tablaFuncionalidades.AllowUserToAddRows = false;
            this.tablaFuncionalidades.AllowUserToDeleteRows = false;
            this.tablaFuncionalidades.AllowUserToOrderColumns = true;
            this.tablaFuncionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaFuncionalidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Elegir});
            this.tablaFuncionalidades.Location = new System.Drawing.Point(11, 239);
            this.tablaFuncionalidades.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tablaFuncionalidades.MultiSelect = false;
            this.tablaFuncionalidades.Name = "tablaFuncionalidades";
            this.tablaFuncionalidades.ReadOnly = true;
            this.tablaFuncionalidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaFuncionalidades.Size = new System.Drawing.Size(364, 220);
            this.tablaFuncionalidades.TabIndex = 11;
            this.tablaFuncionalidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaFuncionalidades_CellContentClick);
            // 
            // Elegir
            // 
            this.Elegir.HeaderText = "Elegir";
            this.Elegir.Name = "Elegir";
            this.Elegir.ReadOnly = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(11, 475);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 28);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "Volver";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // cbxRolEstadoNuevo
            // 
            this.cbxRolEstadoNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRolEstadoNuevo.FormattingEnabled = true;
            this.cbxRolEstadoNuevo.Items.AddRange(new object[] {
            "habilitado",
            "deshabilitado"});
            this.cbxRolEstadoNuevo.Location = new System.Drawing.Point(51, 197);
            this.cbxRolEstadoNuevo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxRolEstadoNuevo.Name = "cbxRolEstadoNuevo";
            this.cbxRolEstadoNuevo.Size = new System.Drawing.Size(280, 24);
            this.cbxRolEstadoNuevo.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 177);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Estado nuevo:";
            // 
            // txtRolEstadoActual
            // 
            this.txtRolEstadoActual.Location = new System.Drawing.Point(51, 149);
            this.txtRolEstadoActual.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRolEstadoActual.Name = "txtRolEstadoActual";
            this.txtRolEstadoActual.ReadOnly = true;
            this.txtRolEstadoActual.Size = new System.Drawing.Size(280, 22);
            this.txtRolEstadoActual.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Estado actual:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(167, 475);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(275, 475);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 28);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // txtRolNombreNuevo
            // 
            this.txtRolNombreNuevo.Location = new System.Drawing.Point(51, 101);
            this.txtRolNombreNuevo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRolNombreNuevo.Name = "txtRolNombreNuevo";
            this.txtRolNombreNuevo.Size = new System.Drawing.Size(280, 22);
            this.txtRolNombreNuevo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre nuevo:";
            // 
            // txtRolNombreActual
            // 
            this.txtRolNombreActual.Location = new System.Drawing.Point(51, 53);
            this.txtRolNombreActual.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRolNombreActual.Name = "txtRolNombreActual";
            this.txtRolNombreActual.ReadOnly = true;
            this.txtRolNombreActual.Size = new System.Drawing.Size(280, 22);
            this.txtRolNombreActual.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre actual:";
            // 
            // Modificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 551);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Modificar";
            this.Text = "Modificar rol";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaFuncionalidades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView tablaFuncionalidades;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Elegir;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ComboBox cbxRolEstadoNuevo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRolEstadoActual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtRolNombreNuevo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRolNombreActual;
        private System.Windows.Forms.Label label1;

    }
}