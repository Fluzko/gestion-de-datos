using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.ComprarOferta
{
    public partial class ConsumirOferta : Form
    {
        public ConsumirOferta()
        {
            InitializeComponent();
            Decoracion.Reorganizar(this);
        }

        private void gridOfertas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
