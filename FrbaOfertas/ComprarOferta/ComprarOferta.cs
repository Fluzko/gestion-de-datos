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
    public partial class ComprarOferta : Form
    {
        public ComprarOferta()
        {
            InitializeComponent();
            Decoracion.Reorganizar(this);
            List<Modelos.Oferta> ofertas = DB_Ofertas.getOfertas();
            showOfertas(ofertas);
        }

        private void showOfertas(List<Modelos.Oferta> ofertas)
        {
            gridOfertas.DataSource = ofertas;
            gridOfertas.AutoResizeColumns();
            gridOfertas.Rows[0].Selected = true;
        }

        private void gridOfertas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            DataGridViewRow selectedRow = gridOfertas.Rows[i];
            Modelos.Oferta oferta = ((Modelos.Oferta)selectedRow.DataBoundItem);
        }

        private void grpFiltros_Enter(object sender, EventArgs e)
        {
            btnFiltrar_Click(sender, e);
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
