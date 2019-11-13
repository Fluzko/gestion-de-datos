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
    }
}
