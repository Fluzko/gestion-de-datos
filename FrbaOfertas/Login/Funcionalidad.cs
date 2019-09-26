using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Login
{
    public partial class Funcionalidad : Form
    {
        String rol;
        public Funcionalidad(String rol)
        {
            InitializeComponent();
            this.rol = rol;
            Titulo.Text = this.rol;
            loadFuncionalidades();
        }

        private void loadFuncionalidades()
        {

        }

        private void titulo_Click(object sender, EventArgs e)
        {

        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {

        }

        private void cerrarSesion_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
    }
}
