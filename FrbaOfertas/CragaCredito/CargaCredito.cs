using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CragaCredito
{
    public partial class CargaCredito : Form
    {
        List<Modelos.TipoPago> tiposPago;

        public CargaCredito()
        {
            InitializeComponent();
            this.loadTiposDePago();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            (new Login.Funcionalidad(Session.getRol())).Show();
            this.Hide();
        }

        private void CargaCredito_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarTarjeta at = new AgregarTarjeta();
            at.Show();
        }

        private void loadTiposDePago()
        {
            this.tiposPago = DB_Ofertas.getTiposDePago();

            if (tiposPago.Count == 0)
            {
                MessageBox.Show("No existen medios de pago disponible", "Aviso");
            }
            else
            {
                cbxTipoPago.DataSource = tiposPago;
                cbxTipoPago.DisplayMember = "nombre";
                cbxTipoPago.ValueMember = "id_tipo";

                cbxTipoPago.SelectedItem = tiposPago.First();
            }
        }
    }
}
