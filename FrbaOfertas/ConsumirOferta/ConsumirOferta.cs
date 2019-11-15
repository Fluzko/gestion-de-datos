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
        private Boolean exit = false;

        public ConsumirOferta()
        {
            InitializeComponent();
            Decoracion.Reorganizar(this);
            List<Modelos.Cupon> cupones = DB_Ofertas.getCupones(Session.getUser().getUsername());
            if (cupones == null)
            {
                exit = true;
                return;
            }
            showCupones(cupones);
        }

        private void showCupones(List<Modelos.Cupon> cupones)
        {
            if (cupones != null)
            {
                gridCupones.DataSource = cupones;
                gridCupones.Rows[0].Selected = true;
                current = getRow(0);
            }
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
            DialogResult res = MessageBox.Show("¿Desea canjear el cupon n°" + current.Id + "?", "Consumir Ofertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (res == DialogResult.OK)
            {
                DB_Ofertas.consumirOferta(current, Properties.Settings.Default.Fecha);
            }

            List<Modelos.Cupon> cupones = DB_Ofertas.getCupones(Session.getUser().getUsername());
            showCupones(cupones);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<Modelos.Cupon> cupones;
            String[] searchables = loadSearchInputs();

            if (searchables.All(searchable => string.IsNullOrEmpty(searchable) || string.IsNullOrWhiteSpace(searchable)))
            {
                cupones = DB_Ofertas.getCupones(Session.getUser().getUsername());
                showCupones(cupones);
                return;
            }

            cupones = DB_Ofertas.getCuponesWithCondition(Session.getUser().getUsername(), txtCliente.Text, txtDescripcion.Text, txtIdCupon.Text, txtIdOferta.Text);
            if (cupones == null)
            {
                MessageBox.Show("No hay cupones que coincidan con su busqueda", "Consumir Oferta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            showCupones(cupones);
            return;
        }

        private String[] loadSearchInputs()
        {
            String[] i = {
                            this.txtCliente.Text,
                            this.txtDescripcion.Text,
                            this.txtIdCupon.Text,
                            this.txtIdOferta.Text
                         };
            return i;
        }

        private void txtIdOferta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }

        private void txtIdCupon_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Volver();
        }

        private void Volver()
        {
            (new Login.Funcionalidad(Session.getRol())).Show();
            this.Hide();
            this.Close();
        }

        private void ConsumirOferta_Shown(object sender, EventArgs e)
        {
            if (exit)
            {
                MessageBox.Show("Usted no tiene cupones pendientes para dar de baja.", "Consumir Oferta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Volver();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtCliente.Clear();
            this.txtDescripcion.Clear();
            this.txtIdCupon.Clear();
            this.txtIdOferta.Clear();
            List<Modelos.Cupon> cupones = DB_Ofertas.getCupones(Session.getUser().getUsername());
            if (cupones != null ) 
                showCupones(cupones);
        }
    }
}
