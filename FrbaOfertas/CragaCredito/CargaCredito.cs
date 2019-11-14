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
        Modelos.Tarjeta actual;

        public CargaCredito()
        {
            InitializeComponent();
            this.loadTiposDePago();
            lblCredito.Text = DB_Ofertas.getCreditoCliente(Session.getUser().getUsername()).ToString();
            
        }

        private void showTarjetas()            
        {
            List<Modelos.Tarjeta> tarjetas = DB_Ofertas.getTarjetasParaCliente(Session.getUser().getUsername());
            gridTarjetas.DataSource = tarjetas;
            if (tarjetas != null)
            {
                gridTarjetas.Rows[0].Selected = true;
                actual = getRow(0);
            }
            else
            {
                actual = null;
            }
        }

        private void hideTarjetas()
        {
            gridTarjetas.DataSource = null;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            (new Login.Funcionalidad(Session.getRol())).Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarTarjeta at = new AgregarTarjeta();
            at.Show();
            this.Hide();
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
        private Modelos.Tarjeta getRow(int i)
        {
            DataGridViewRow selectedRow = gridTarjetas.Rows[i];
            return (Modelos.Tarjeta)selectedRow.DataBoundItem;
        }

        private void cbxTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTipoPago.Text != "Efectivo")
            {
                showTarjetas();
            }
            else
            {
                actual = null;
                hideTarjetas();
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            double monto = double.Parse(txtMonto.Text);
            if (txtMonto.Text == "" || monto < 0) {
                MessageBox.Show("Error en el monto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (actual == null && cbxTipoPago.Text == "Crédito") {
                MessageBox.Show("Seleccione una tarjeta o cambie el tipo de pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime localDate = DateTime.Now; //CAMBIAR

            String tarjetaNum = null;
            if (actual != null)
            {
                tarjetaNum = actual.Numero;
            }     
            
            Modelos.TipoPago tp = tiposPago.Where(p => p.nombre == cbxTipoPago.Text).ToList().First();

            DB_Ofertas.generarCarga(Session.getUser().getUsername(), tp.id_tipo, localDate, monto, tarjetaNum);
            DB_Ofertas.actualizarMontoCliente(Session.getUser().getUsername(), monto);

            MessageBox.Show("Credito actualizado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtMonto.Text = "";
            lblCredito.Text = DB_Ofertas.getCreditoCliente(Session.getUser().getUsername()).ToString();
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }

    }
}
