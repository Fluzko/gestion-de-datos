using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.ConsumirOferta
{
    public partial class ConsumirOferta : Form
    {
        private Modelos.Cupon current;

        public ConsumirOferta()
        {
            InitializeComponent();
            Decoracion.Reorganizar(this);
            List<Modelos.Cupon> cupones = DB_Ofertas.getCupones(Session.getUser().getUsername());
            showCupones(cupones);
        }

        private void showCupones(List<Modelos.Cupon> cupones)
        {
            gridCupones.DataSource = cupones;
            //gridOfertas.AutoResizeColumns();
            gridCupones.Rows[0].Selected = true;
            current = getRow(0);
        }

        private Modelos.Cupon getRow(int i)
        {
            DataGridViewRow selectedRow = gridCupones.Rows[i];
            return (Modelos.Cupon)selectedRow.DataBoundItem;
        }

        private void gridCupones_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBaja_Click(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

        }

        private void txtIdOferta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }

        private void txtIdCupon_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }
    }
}
