namespace FrbaOfertas.ComprarOferta
{
    partial class ComprarOferta
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
            System.Windows.Forms.Label lblProveedor;
            this.gridOfertas = new System.Windows.Forms.DataGridView();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtPrecioMax = new System.Windows.Forms.TextBox();
            this.lblPrecioMax = new System.Windows.Forms.Label();
            this.txtPrecioMin = new System.Windows.Forms.TextBox();
            this.lblPrecioMin = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnComprar = new System.Windows.Forms.Button();
            lblProveedor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridOfertas)).BeginInit();
            this.grpFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new System.Drawing.Point(6, 34);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new System.Drawing.Size(74, 17);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor";
            // 
            // gridOfertas
            // 
            this.gridOfertas.AllowUserToResizeRows = false;
            this.gridOfertas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridOfertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOfertas.Location = new System.Drawing.Point(12, 171);
            this.gridOfertas.MultiSelect = false;
            this.gridOfertas.Name = "gridOfertas";
            this.gridOfertas.ReadOnly = true;
            this.gridOfertas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridOfertas.Size = new System.Drawing.Size(807, 393);
            this.gridOfertas.TabIndex = 0;
            this.gridOfertas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOfertas_CellClick);
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.txtDescripcion);
            this.grpFiltros.Controls.Add(this.lblDescripcion);
            this.grpFiltros.Controls.Add(this.txtPrecioMax);
            this.grpFiltros.Controls.Add(this.lblPrecioMax);
            this.grpFiltros.Controls.Add(this.txtPrecioMin);
            this.grpFiltros.Controls.Add(this.lblPrecioMin);
            this.grpFiltros.Controls.Add(this.txtProveedor);
            this.grpFiltros.Controls.Add(lblProveedor);
            this.grpFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpFiltros.Location = new System.Drawing.Point(12, 12);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(807, 117);
            this.grpFiltros.TabIndex = 2;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(91, 60);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(295, 23);
            this.txtDescripcion.TabIndex = 7;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(6, 63);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(82, 17);
            this.lblDescripcion.TabIndex = 6;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // txtPrecioMax
            // 
            this.txtPrecioMax.Location = new System.Drawing.Point(506, 60);
            this.txtPrecioMax.Name = "txtPrecioMax";
            this.txtPrecioMax.Size = new System.Drawing.Size(295, 23);
            this.txtPrecioMax.TabIndex = 5;
            this.txtPrecioMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioMax_KeyPress);
            // 
            // lblPrecioMax
            // 
            this.lblPrecioMax.AutoSize = true;
            this.lblPrecioMax.Location = new System.Drawing.Point(405, 63);
            this.lblPrecioMax.Name = "lblPrecioMax";
            this.lblPrecioMax.Size = new System.Drawing.Size(99, 17);
            this.lblPrecioMax.TabIndex = 4;
            this.lblPrecioMax.Text = "Precio Máximo";
            // 
            // txtPrecioMin
            // 
            this.txtPrecioMin.Location = new System.Drawing.Point(506, 31);
            this.txtPrecioMin.Name = "txtPrecioMin";
            this.txtPrecioMin.Size = new System.Drawing.Size(295, 23);
            this.txtPrecioMin.TabIndex = 3;
            this.txtPrecioMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioMin_KeyPress);
            // 
            // lblPrecioMin
            // 
            this.lblPrecioMin.AutoSize = true;
            this.lblPrecioMin.Location = new System.Drawing.Point(405, 34);
            this.lblPrecioMin.Name = "lblPrecioMin";
            this.lblPrecioMin.Size = new System.Drawing.Size(96, 17);
            this.lblPrecioMin.TabIndex = 2;
            this.lblPrecioMin.Text = "Precio Minimo";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new System.Drawing.Point(91, 31);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(295, 23);
            this.txtProveedor.TabIndex = 1;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnFiltrar.Location = new System.Drawing.Point(21, 135);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(79, 30);
            this.btnFiltrar.TabIndex = 3;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnComprar
            // 
            this.btnComprar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnComprar.Location = new System.Drawing.Point(726, 135);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(79, 30);
            this.btnComprar.TabIndex = 4;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // ComprarOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 576);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.gridOfertas);
            this.Name = "ComprarOferta";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridOfertas)).EndInit();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridOfertas;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.TextBox txtPrecioMin;
        private System.Windows.Forms.Label lblPrecioMin;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.TextBox txtPrecioMax;
        private System.Windows.Forms.Label lblPrecioMax;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnComprar;
    }
}