using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmCliente
{
    public partial class Alta : Form
    {

        public Alta()
        {
            InitializeComponent();
            Decoracion.Reorganizar(this);
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            DialogResult boton = MessageBox.Show("Si vuelve se borraran todos los datos ingresados", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (boton == DialogResult.OK){
                if (Session.isNull())
                {
                    Registro.Registro a = new Registro.Registro();
                    a.Show();
                    this.cleanInputs();
                    this.Hide();
                }
                else
                {
                    AbmCliente a = new AbmCliente();
                    a.Show();
                    this.cleanInputs();
                    this.Hide();
                }
            }
            else{
                //se deberia quedar en esta pantalla
            }
        }


        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.cleanInputs();
        }

        private void buttonFecha_Click(object sender, EventArgs e)
        {
            this.calendario.Show();
            this.calendario.BringToFront();
            this.calendario.Select();  
        }


        private void calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            textFN.Text = calendario.SelectionRange.Start.ToShortDateString();
            calendario.Hide();
        }

        private void cleanInputs()
        {
            //limpio todos los campos
            this.textNombre.Clear();
            this.textApellido.Clear();
            this.textMail.Clear();
            this.textTelefono.Clear();
            this.textFN.Clear();
            this.textCalle.Clear();
            this.textPiso.Clear();
            this.textDpto.Clear();
            this.textLocalidad.Clear();
            this.textCP.Clear();
            this.textDNI.Clear();
            this.textUsuario.Clear();
            this.textContra.Clear();
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            //valida vacios
            String[] inputs = loadInputs();
            if (inputs.Any(input => String.IsNullOrEmpty(input))){
                MessageBox.Show("Faltan llenar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //valido formato de mails
            if (!Validar.validateEmail(this.textMail.Text)){
                MessageBox.Show("Formato invalido de Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool alta = DB_Ofertas.altaCliente( this.textUsuario.Text,
                                                this.textContra.Text,
                                                this.textNombre.Text,
                                                this.textApellido.Text,
                                                this.textMail.Text,
                                                this.textTelefono.Text,
                                                Convert.ToDateTime(this.textFN.Text),
                                                this.textCalle.Text,
                                                this.textPiso.Text,
                                                this.textDpto.Text,
                                                this.textLocalidad.Text,
                                                this.textCP.Text,
                                                this.textDNI.Text);

            if (alta)
            {
                MessageBox.Show("Usuario dado de alta correctamente", "Alta cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleanInputs();
            }
 
        }


        private String[] loadInputs()
        {
            String[] i ={
            this.textNombre.Text,
            this.textApellido.Text,
            this.textMail.Text,
            this.textTelefono.Text,
            this.textFN.Text,
            this.textCalle.Text,
            this.textPiso.Text,
            this.textDpto.Text,
            this.textLocalidad.Text,
            this.textCP.Text,
            this.textDNI.Text,
            this.textUsuario.Text,
            this.textContra.Text};
            return i;
        }

        //campos tipo numerico
        private void textDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
            
        }

        //campos string
        private void textNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.letras(e);
        }


    }
}
