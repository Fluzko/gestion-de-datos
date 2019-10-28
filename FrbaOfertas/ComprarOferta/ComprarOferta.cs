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
        private Modelos.Oferta current;

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
            //gridOfertas.AutoResizeColumns();
            gridOfertas.Rows[0].Selected = true;
            current = getRow(0);
            numCantidad.Maximum = ((Modelos.Oferta)gridOfertas.Rows[0].DataBoundItem).MaxPorCliente;
        }

        private void gridOfertas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                current = getRow(i);
                numCantidad.Maximum = current.MaxPorCliente;
            }
        }

        private Modelos.Oferta getRow(int i)
        {
            DataGridViewRow selectedRow = gridOfertas.Rows[i];
            return (Modelos.Oferta)selectedRow.DataBoundItem;
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (numCantidad.Value == 0)
            {
                MessageBox.Show("Seleccione una cantidad mayor a 0", "Compra Ofertas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult res = MessageBox.Show("¿Desea comprar " + numCantidad.Value + " de estas ofertas?", "Compra Ofertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            
            if (res == DialogResult.OK)
            {
                DB_Ofertas.comprarOferta(Session.getUser(), current, (int)numCantidad.Value);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<Modelos.Oferta> ofertas;
            String[] searchables = loadSearchInputs();

            if (searchables.All(searchable => string.IsNullOrEmpty(searchable) || string.IsNullOrWhiteSpace(searchable)))
            {
                ofertas = DB_Ofertas.getOfertas();
                showOfertas(ofertas);
                return;
            }

            ofertas = DB_Ofertas.getOfertasWithCondition(txtProveedor.Text, txtDescripcion.Text, txtPrecioMin.Text, txtPrecioMax.Text);
            if (ofertas == null)
            {
                MessageBox.Show("No hay ofertas que coincidan con su busqueda", "Compra Ofertas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            showOfertas(ofertas);
            return;
        }

        private String[] loadSearchInputs()
        {
            String[] i = {
                            this.txtProveedor.Text,
                            this.txtDescripcion.Text,
                            this.txtPrecioMin.Text,
                            this.txtPrecioMax.Text
                         };
            return i;
        }

        private void txtPrecioMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }

        private void txtPrecioMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }
    }
}
