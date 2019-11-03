namespace FrbaOfertas.ConsumirOferta
{
    partial class ConsumirOferta
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
            System.Windows.Forms.Label lblCliente;
            System.Windows.Forms.Label lblDescripcion;
            this.gridCupones = new System.Windows.Forms.DataGridView();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.txtIdOferta = new System.Windows.Forms.TextBox();
            this.lblIdOferta = new System.Windows.Forms.Label();
            this.txtIdCupon = new System.Windows.Forms.TextBox();
            this.lblIdCupon = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            lblCliente = new System.Windows.Forms.Label();
            lblDescripcion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridCupones)).BeginInit();
            this.grpFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new System.Drawing.Point(6, 34);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new System.Drawing.Size(51, 17);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente";
            // 
            // gridCupones
            // 
            this.gridCupones.AllowUserToResizeRows = false;
            this.gridCupones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCupones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCupones.Location = new System.Drawing.Point(12, 171);
            this.gridCupones.MultiSelect = false;
            this.gridCupones.Name = "gridCupones";
            this.gridCupones.ReadOnly = true;
            this.gridCupones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCupones.Size = new System.Drawing.Size(807, 361);
            this.gridCupones.TabIndex = 0;
            this.gridCupones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCupones_CellClick);
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.txtDescripcion);
            this.grpFiltros.Controls.Add(lblDescripcion);
            this.grpFiltros.Controls.Add(this.txtIdOferta);
            this.grpFiltros.Controls.Add(this.lblIdOferta);
            this.grpFiltros.Controls.Add(this.txtIdCupon);
            this.grpFiltros.Controls.Add(this.lblIdCupon);
            this.grpFiltros.Controls.Add(this.txtCliente);
            this.grpFiltros.Controls.Add(lblCliente);
            this.grpFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpFiltros.Location = new System.Drawing.Point(12, 12);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(807, 117);
            this.grpFiltros.TabIndex = 3;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // txtIdOferta
            // 
            this.txtIdOferta.Location = new System.Drawing.Point(506, 60);
            this.txtIdOferta.Name = "txtIdOferta";
            this.txtIdOferta.Size = new System.Drawing.Size(295, 23);
            this.txtIdOferta.TabIndex = 7;
            this.txtIdOferta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdOferta_KeyPress);
            // 
            // lblIdOferta
            // 
            this.lblIdOferta.AutoSize = true;
            this.lblIdOferta.Location = new System.Drawing.Point(405, 63);
            this.lblIdOferta.Name = "lblIdOferta";
            this.lblIdOferta.Size = new System.Drawing.Size(60, 17);
            this.lblIdOferta.TabIndex = 6;
            this.lblIdOferta.Text = "Id oferta";
            // 
            // txtIdCupon
            // 
            this.txtIdCupon.Location = new System.Drawing.Point(506, 31);
            this.txtIdCupon.Name = "txtIdCupon";
            this.txtIdCupon.Size = new System.Drawing.Size(295, 23);
            this.txtIdCupon.TabIndex = 3;
            this.txtIdCupon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdCupon_KeyPress);
            // 
            // lblIdCupon
            // 
            this.lblIdCupon.AutoSize = true;
            this.lblIdCupon.Location = new System.Drawing.Point(405, 34);
            this.lblIdCupon.Name = "lblIdCupon";
            this.lblIdCupon.Size = new System.Drawing.Size(62, 17);
            this.lblIdCupon.TabIndex = 2;
            this.lblIdCupon.Text = "Id cupón";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(91, 31);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(295, 23);
            this.txtCliente.TabIndex = 1;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnFiltrar.Location = new System.Drawing.Point(21, 135);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(79, 30);
            this.btnFiltrar.TabIndex = 4;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnBaja.Location = new System.Drawing.Point(708, 135);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(97, 30);
            this.btnBaja.TabIndex = 5;
            this.btnBaja.Text = "Dar de baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnVolver.Location = new System.Drawing.Point(12, 538);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(79, 30);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new System.Drawing.Point(6, 63);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new System.Drawing.Size(82, 17);
            lblDescripcion.TabIndex = 12;
            lblDescripcion.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(91, 63);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(295, 23);
            this.txtDescripcion.TabIndex = 13;
            // 
            // ConsumirOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 576);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.gridCupones);
            this.Name = "ConsumirOferta";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.ConsumirOferta_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridCupones)).EndInit();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridCupones;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.TextBox txtIdOferta;
        private System.Windows.Forms.Label lblIdOferta;
        private System.Windows.Forms.TextBox txtIdCupon;
        private System.Windows.Forms.Label lblIdCupon;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox txtDescripcion;
    }
}