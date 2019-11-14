using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CrearOferta
{
    public partial class PublicarOferta : Form
    {
        public PublicarOferta()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonPublicar_Click(object sender, EventArgs e)
        {
            //valida vacios
            String[] inputs = loadInputs();
            if (inputs.Any(input => String.IsNullOrEmpty(input)))
            {
                MessageBox.Show("Faltan llenar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //valida proveedor

            bool alta = DB_Ofertas.crearOferta(this.textDescripcion.Text,
                                               Convert.ToDecimal(this.textPrecioOferta.Text),
                                               Convert.ToDecimal(this.textPrecioLista.Text),
                                               Convert.ToInt32(this.textStockDisp.Text),
                                               Convert.ToInt32(this.textCantMax.Text),
                                               this.calendarFechaPublicacion.SelectionStart,
                                               this.calendarFechaVencimiento.SelectionStart,
                                               this.textProveedor.Text);
                                       
            if (alta)
            {
                MessageBox.Show("Oferta creada correctamente", "Publicar Oferta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleanInputs();
            }

        }

        private String[] loadInputs()
        {
            String[] i ={
            this.textDescripcion.Text,
            this.textPrecioOferta.Text,
            this.textPrecioLista.Text,
            this.textProveedor.Text,
            this.textStockDisp.Text,       
            this.textCantMax.Text,
            this.textFechaPublicacion.Text,
            this.textFechaPublicacion.Text
           };
            return i;
        }
        private void cleanInputs()
        {
            //limpio todos los campos
            this.textDescripcion.Clear();
            this.textPrecioOferta.Clear();
            this.textPrecioLista.Clear();
            this.textProveedor.Clear();
            this.textStockDisp.Clear();       
            this.textCantMax.Clear();
            this.textFechaPublicacion.Clear();
            this.textFechaPublicacion.Clear();
        }

        private void calendarFechaPublicacion_DateSelected(object sender, DateRangeEventArgs e)
        {
            textFechaPublicacion.Text = calendarFechaPublicacion.SelectionRange.Start.ToShortDateString();
            calendarFechaPublicacion.Hide();
           //esto no funciona, restriccion de fecha vencimiento posterior a publicacion
            if (DateTime.Compare(calendarFechaVencimiento.SelectionStart, calendarFechaPublicacion.SelectionStart)<0)
            { 
                calendarFechaVencimiento.SelectionStart = calendarFechaPublicacion.SelectionStart;
                textFechaVencimiento.Text = calendarFechaVencimiento.SelectionStart.ToShortDateString();
            };
        }
        private void calendarFechaVencimiento_DateSelected(object sender, DateRangeEventArgs e)
        {
            textFechaVencimiento.Text = calendarFechaVencimiento.SelectionRange.Start.ToShortDateString();
            calendarFechaVencimiento.Hide();
        }

      ///VALIDACIONES///
     
        private void textPrecioOferta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }

        private void textPrecioLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }

        private void textStockDisp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }

        private void textCantMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }

        private void textDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.letras(e);
        }

        private void buttonSelecFechaPub_Click(object sender, EventArgs e)
        {
            this.calendarFechaPublicacion.Show();
            this.calendarFechaPublicacion.BringToFront();
            this.calendarFechaPublicacion.Select(); 
        }

        private void buttonSelecFechaVen_Click(object sender, EventArgs e)
        {
            this.calendarFechaVencimiento.Show();
            this.calendarFechaVencimiento.BringToFront();
            this.calendarFechaVencimiento.Select(); 

        }

        private void calendarFechaPublicacion_Leave(object sender, EventArgs e)
        {
            this.calendarFechaPublicacion.Hide();
        }

        private void calendarFechaVencimiento_Leave(object sender, EventArgs e)
        {
            this.calendarFechaVencimiento.Hide();
        }

        private void PublicarOferta_Load(object sender, EventArgs e)
        {
            calendarFechaPublicacion.MinDate = DateTime.Now;
            bool admin = DB_Ofertas.esAdmin(Session.getUser().getUsername());
            if (admin)
            {
                this.textProveedor.Enabled = true;
            }
            else {
                this.textProveedor.Text = Session.getUser().getUsername();
            }
            
        }

        private void calendarFechaPublicacion_DateChanged(object sender, DateRangeEventArgs e)
        {
            calendarFechaVencimiento.MinDate = calendarFechaPublicacion.SelectionStart;
        }

        private void textStockDisp_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {

        }

    
    }
}
