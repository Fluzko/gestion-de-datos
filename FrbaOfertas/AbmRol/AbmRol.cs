using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmRol
{
    public partial class AbmRol : Form
    {
        public AbmRol()
        {
            InitializeComponent();
        }

        private void AbmRol_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            (new Alta()).Show();
            this.Hide();

        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            (new Listar()).Show();
            this.Hide();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            (new Login.Funcionalidad(Session.getRol())).Show();
            this.Hide();
        }
    }
}
