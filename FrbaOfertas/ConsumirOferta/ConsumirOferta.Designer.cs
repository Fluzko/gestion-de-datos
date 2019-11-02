namespace FrbaOfertas.ComprarOferta
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
            this.gridOfertas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridOfertas)).BeginInit();
            this.SuspendLayout();
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
            this.gridOfertas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOfertas_CellClick);
            // 
            // ComprarOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 576);
            this.Controls.Add(this.gridOfertas);
            this.Name = "ComprarOferta";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridOfertas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridOfertas;
    }
}