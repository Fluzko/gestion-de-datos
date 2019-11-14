using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Registro
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
            Decoracion.Reorganizar(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login.Login l = new Login.Login();
            l.Show();
            this.Hide();
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            (new AbmCliente.Alta()).Show();
            this.Hide();
        }

        private void buttonRegistroProveedor_Click(object sender, EventArgs e)
        {
            (new AbmProveedor.AltaProveedor()).Show();
            this.Hide();
        }

    }
}
