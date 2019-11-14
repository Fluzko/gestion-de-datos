using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmProveedor
{
    public partial class AbmProveedores : Form
    {
        private Button buttonModificarProveedor;
        private GroupBox groupBox1;
        private Button buttonVolver;
        private Button buttonAltaProveedor;
    
        public AbmProveedores()
        {
            InitializeComponent();
            Decoracion.Reorganizar(this);
        }

        private void buttonAltaProveedor_Click(object sender, EventArgs e)
        {
            AltaProveedor a = new AltaProveedor();
            a.Show();
            this.Hide();
        }

        private void buttonModificarProveedor_Click(object sender, EventArgs e)
        {
            ModificarProveedor m = new ModificarProveedor();
            m.Show();
            this.Hide();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            (new Login.Funcionalidad(Session.getRol())).Show();
            this.Hide();
        }

        private void InitializeComponent()
        {
            this.buttonAltaProveedor = new System.Windows.Forms.Button();
            this.buttonModificarProveedor = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAltaProveedor
            // 
            this.buttonAltaProveedor.Location = new System.Drawing.Point(53, 40);
            this.buttonAltaProveedor.Name = "buttonAltaProveedor";
            this.buttonAltaProveedor.Size = new System.Drawing.Size(207, 40);
            this.buttonAltaProveedor.TabIndex = 0;
            this.buttonAltaProveedor.Text = "Dar de alta proveedor";
            this.buttonAltaProveedor.UseVisualStyleBackColor = true;
            // 
            // buttonModificarProveedor
            // 
            this.buttonModificarProveedor.Location = new System.Drawing.Point(53, 109);
            this.buttonModificarProveedor.Name = "buttonModificarProveedor";
            this.buttonModificarProveedor.Size = new System.Drawing.Size(207, 42);
            this.buttonModificarProveedor.TabIndex = 1;
            this.buttonModificarProveedor.Text = "Modificar proveedor";
            this.buttonModificarProveedor.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonModificarProveedor);
            this.groupBox1.Controls.Add(this.buttonAltaProveedor);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 188);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones";
            // 
            // buttonVolver
            // 
            this.buttonVolver.Location = new System.Drawing.Point(129, 219);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(75, 23);
            this.buttonVolver.TabIndex = 3;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            // 
            // AbmProveedores
            // 
            this.ClientSize = new System.Drawing.Size(339, 257);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.groupBox1);
            this.Name = "AbmProveedores";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
