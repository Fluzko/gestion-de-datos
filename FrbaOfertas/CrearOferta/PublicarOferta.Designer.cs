namespace FrbaOfertas.CrearOferta
{
    partial class PublicarOferta
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
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.textStockDisp = new System.Windows.Forms.TextBox();
            this.textPrecioLista = new System.Windows.Forms.TextBox();
            this.textPrecioOferta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.calendarFechaPublicacion = new System.Windows.Forms.MonthCalendar();
            this.calendarFechaVencimiento = new System.Windows.Forms.MonthCalendar();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textCantMax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textProveedor = new System.Windows.Forms.TextBox();
            this.buttonPublicar = new System.Windows.Forms.Button();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.textFechaPublicacion = new System.Windows.Forms.TextBox();
            this.textFechaVencimiento = new System.Windows.Forms.TextBox();
            this.buttonSelecFechaPub = new System.Windows.Forms.Button();
            this.buttonSelecFechaVen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(129, 23);
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(263, 22);
            this.textDescripcion.TabIndex = 23;
            this.textDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDescripcion_KeyPress);
            // 
            // textStockDisp
            // 
            this.textStockDisp.Location = new System.Drawing.Point(130, 129);
            this.textStockDisp.Name = "textStockDisp";
            this.textStockDisp.Size = new System.Drawing.Size(262, 22);
            this.textStockDisp.TabIndex = 22;
            this.textStockDisp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textStockDisp_KeyPress);
            // 
            // textPrecioLista
            // 
            this.textPrecioLista.Location = new System.Drawing.Point(130, 94);
            this.textPrecioLista.Name = "textPrecioLista";
            this.textPrecioLista.Size = new System.Drawing.Size(262, 22);
            this.textPrecioLista.TabIndex = 21;
            this.textPrecioLista.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPrecioLista_KeyPress);
            // 
            // textPrecioOferta
            // 
            this.textPrecioOferta.Location = new System.Drawing.Point(130, 57);
            this.textPrecioOferta.Name = "textPrecioOferta";
            this.textPrecioOferta.Size = new System.Drawing.Size(262, 22);
            this.textPrecioOferta.TabIndex = 20;
            this.textPrecioOferta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPrecioOferta_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Descripcion:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Precio de Oferta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Precio de Lista:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Stock Disponible:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Fecha Publicacion:";
            // 
            // calendarFechaPublicacion
            // 
            this.calendarFechaPublicacion.Location = new System.Drawing.Point(16, 237);
            this.calendarFechaPublicacion.Name = "calendarFechaPublicacion";
            this.calendarFechaPublicacion.TabIndex = 29;
            this.calendarFechaPublicacion.Visible = false;
            this.calendarFechaPublicacion.Leave += new System.EventHandler(this.calendarFechaPublicacion_Leave);
            // 
            // calendarFechaVencimiento
            // 
            this.calendarFechaVencimiento.Location = new System.Drawing.Point(337, 235);
            this.calendarFechaVencimiento.Name = "calendarFechaVencimiento";
            this.calendarFechaVencimiento.TabIndex = 31;
            this.calendarFechaVencimiento.Visible = false;
            this.calendarFechaVencimiento.Leave += new System.EventHandler(this.calendarFechaVencimiento_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(334, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 17);
            this.label6.TabIndex = 30;
            this.label6.Text = "Fecha Vencimiento:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 17);
            this.label7.TabIndex = 32;
            this.label7.Text = "Cantidad Max por Cliente:";
            // 
            // textCantMax
            // 
            this.textCantMax.Location = new System.Drawing.Point(189, 161);
            this.textCantMax.Name = "textCantMax";
            this.textCantMax.Size = new System.Drawing.Size(203, 22);
            this.textCantMax.TabIndex = 33;
            this.textCantMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCantMax_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 462);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 17);
            this.label8.TabIndex = 34;
            this.label8.Text = "Proveedor (Razon Social):";
            // 
            // textProveedor
            // 
            this.textProveedor.Location = new System.Drawing.Point(189, 462);
            this.textProveedor.Name = "textProveedor";
            this.textProveedor.Size = new System.Drawing.Size(224, 22);
            this.textProveedor.TabIndex = 35;
            // 
            // buttonPublicar
            // 
            this.buttonPublicar.Location = new System.Drawing.Point(486, 517);
            this.buttonPublicar.Name = "buttonPublicar";
            this.buttonPublicar.Size = new System.Drawing.Size(119, 30);
            this.buttonPublicar.TabIndex = 36;
            this.buttonPublicar.Text = "Publicar";
            this.buttonPublicar.UseVisualStyleBackColor = true;
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Location = new System.Drawing.Point(19, 517);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(121, 30);
            this.buttonCerrar.TabIndex = 37;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            // 
            // textFechaPublicacion
            // 
            this.textFechaPublicacion.Location = new System.Drawing.Point(146, 209);
            this.textFechaPublicacion.Name = "textFechaPublicacion";
            this.textFechaPublicacion.ReadOnly = true;
            this.textFechaPublicacion.Size = new System.Drawing.Size(100, 22);
            this.textFechaPublicacion.TabIndex = 38;
            // 
            // textFechaVencimiento
            // 
            this.textFechaVencimiento.Location = new System.Drawing.Point(473, 209);
            this.textFechaVencimiento.Name = "textFechaVencimiento";
            this.textFechaVencimiento.ReadOnly = true;
            this.textFechaVencimiento.Size = new System.Drawing.Size(95, 22);
            this.textFechaVencimiento.TabIndex = 39;
            // 
            // buttonSelecFechaPub
            // 
            this.buttonSelecFechaPub.Location = new System.Drawing.Point(59, 250);
            this.buttonSelecFechaPub.Name = "buttonSelecFechaPub";
            this.buttonSelecFechaPub.Size = new System.Drawing.Size(159, 35);
            this.buttonSelecFechaPub.TabIndex = 40;
            this.buttonSelecFechaPub.Text = "Seleccionar fecha";
            this.buttonSelecFechaPub.UseVisualStyleBackColor = true;
            this.buttonSelecFechaPub.Click += new System.EventHandler(this.buttonSelecFechaPub_Click);
            // 
            // buttonSelecFechaVen
            // 
            this.buttonSelecFechaVen.Location = new System.Drawing.Point(401, 250);
            this.buttonSelecFechaVen.Name = "buttonSelecFechaVen";
            this.buttonSelecFechaVen.Size = new System.Drawing.Size(150, 34);
            this.buttonSelecFechaVen.TabIndex = 41;
            this.buttonSelecFechaVen.Text = "Seleccionar fecha";
            this.buttonSelecFechaVen.UseVisualStyleBackColor = true;
            this.buttonSelecFechaVen.Click += new System.EventHandler(this.buttonSelecFechaVen_Click);
            // 
            // PublicarOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 554);
            this.Controls.Add(this.buttonSelecFechaVen);
            this.Controls.Add(this.buttonSelecFechaPub);
            this.Controls.Add(this.textFechaVencimiento);
            this.Controls.Add(this.textFechaPublicacion);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.buttonPublicar);
            this.Controls.Add(this.textProveedor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textCantMax);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textDescripcion);
            this.Controls.Add(this.textStockDisp);
            this.Controls.Add(this.textPrecioLista);
            this.Controls.Add(this.textPrecioOferta);
            this.Controls.Add(this.calendarFechaPublicacion);
            this.Controls.Add(this.calendarFechaVencimiento);
            this.Name = "PublicarOferta";
            this.Text = "Publicar Ofertas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox textDescripcion;
        internal System.Windows.Forms.TextBox textStockDisp;
        internal System.Windows.Forms.TextBox textPrecioLista;
        internal System.Windows.Forms.TextBox textPrecioOferta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MonthCalendar calendarFechaPublicacion;
        private System.Windows.Forms.MonthCalendar calendarFechaVencimiento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textCantMax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textProveedor;
        private System.Windows.Forms.Button buttonPublicar;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.TextBox textFechaPublicacion;
        private System.Windows.Forms.TextBox textFechaVencimiento;
        private System.Windows.Forms.Button buttonSelecFechaPub;
        private System.Windows.Forms.Button buttonSelecFechaVen;
    }
}