using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmCliente
{
    public partial class AbmCliente : Form
    {
        public AbmCliente()
        {
            InitializeComponent();
            Decoracion.Reorganizar(this);
        }

        private void clienteVolverbtn_Click(object sender, EventArgs e)
        {
            //volver a la lista de funcionalidades para la sesion actual
            Login.Funcionalidad f = new Login.Funcionalidad(Session.getRol());
            f.Show();
            this.Hide();
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            //pantalla de alta cliente
            Alta a = new Alta();
            a.Show();
            this.Hide();
        }

        private void btnListaClientes_Click(object sender, EventArgs e)
        {
            //pantalla de modificar cliente
            Modificar m = new Modificar();
            m.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new Login.Funcionalidad(Session.getRol())).Show();
            this.Hide();
        }

        private void AbmCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
