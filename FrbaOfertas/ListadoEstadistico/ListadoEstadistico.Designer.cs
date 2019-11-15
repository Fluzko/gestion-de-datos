namespace FrbaOfertas.ListadoEstadistico
{
    partial class ListadoEstadistico
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
            this.label1 = new System.Windows.Forms.Label();
            this.rbEstadistica2 = new System.Windows.Forms.RadioButton();
            this.rbEstadistica1 = new System.Windows.Forms.RadioButton();
            this.gridEstadisticas = new System.Windows.Forms.DataGridView();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.sem2 = new System.Windows.Forms.RadioButton();
            this.sem1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridEstadisticas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mostrar proveedores con:";
            // 
            // rbEstadistica2
            // 
            this.rbEstadistica2.AutoSize = true;
            this.rbEstadistica2.Checked = true;
            this.rbEstadistica2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEstadistica2.Location = new System.Drawing.Point(43, 50);
            this.rbEstadistica2.Name = "rbEstadistica2";
            this.rbEstadistica2.Size = new System.Drawing.Size(311, 24);
            this.rbEstadistica2.TabIndex = 1;
            this.rbEstadistica2.TabStop = true;
            this.rbEstadistica2.Text = "mayor porcentaje de descuento ofrecido";
            this.rbEstadistica2.UseVisualStyleBackColor = true;
            // 
            // rbEstadistica1
            // 
            this.rbEstadistica1.AutoSize = true;
            this.rbEstadistica1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEstadistica1.Location = new System.Drawing.Point(43, 80);
            this.rbEstadistica1.Name = "rbEstadistica1";
            this.rbEstadistica1.Size = new System.Drawing.Size(153, 24);
            this.rbEstadistica1.TabIndex = 2;
            this.rbEstadistica1.Text = "mayor facturación";
            this.rbEstadistica1.UseVisualStyleBackColor = true;
            this.rbEstadistica1.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // gridEstadisticas
            // 
            this.gridEstadisticas.AllowUserToResizeRows = false;
            this.gridEstadisticas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridEstadisticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEstadisticas.Location = new System.Drawing.Point(16, 183);
            this.gridEstadisticas.MultiSelect = false;
            this.gridEstadisticas.Name = "gridEstadisticas";
            this.gridEstadisticas.ReadOnly = true;
            this.gridEstadisticas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEstadisticas.Size = new System.Drawing.Size(590, 263);
            this.gridEstadisticas.TabIndex = 3;
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(70, 134);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(80, 20);
            this.txtAnio.TabIndex = 4;
            this.txtAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnio_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Año";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(274, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Semestre:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(16, 473);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 32);
            this.button1.TabIndex = 9;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(498, 473);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(83, 32);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // sem2
            // 
            this.sem2.AutoSize = true;
            this.sem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sem2.Location = new System.Drawing.Point(77, 13);
            this.sem2.Name = "sem2";
            this.sem2.Size = new System.Drawing.Size(36, 24);
            this.sem2.TabIndex = 11;
            this.sem2.TabStop = true;
            this.sem2.Text = "2";
            this.sem2.UseVisualStyleBackColor = true;
            // 
            // sem1
            // 
            this.sem1.AutoSize = true;
            this.sem1.Checked = true;
            this.sem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sem1.Location = new System.Drawing.Point(13, 13);
            this.sem1.Name = "sem1";
            this.sem1.Size = new System.Drawing.Size(36, 24);
            this.sem1.TabIndex = 10;
            this.sem1.TabStop = true;
            this.sem1.Text = "1";
            this.sem1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sem1);
            this.groupBox1.Controls.Add(this.sem2);
            this.groupBox1.Location = new System.Drawing.Point(371, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 46);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 534);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.gridEstadisticas);
            this.Controls.Add(this.rbEstadistica1);
            this.Controls.Add(this.rbEstadistica2);
            this.Controls.Add(this.label1);
            this.Name = "ListadoEstadistico";
            this.Text = "Estadisticas";
            ((System.ComponentModel.ISupportInitialize)(this.gridEstadisticas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbEstadistica2;
        private System.Windows.Forms.RadioButton rbEstadistica1;
        private System.Windows.Forms.DataGridView gridEstadisticas;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.RadioButton sem2;
        private System.Windows.Forms.RadioButton sem1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}