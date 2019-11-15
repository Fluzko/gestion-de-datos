using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmProveedor
{
    public partial class AltaProveedor : Form
    {
        List<Modelos.Rubro> rubros;

        public AltaProveedor()
        {
            InitializeComponent();
            Decoracion.Reorganizar(this);
            listRubros();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.cleanInputs();
        }

        private void listRubros()
        {
            rubros = DB_Ofertas.getRubros();

            if (rubros.Count != 0)
            {
                ddRubros.Enabled = true;
                ddRubros.DataSource = rubros;
                ddRubros.DisplayMember = "nombre";
                ddRubros.ValueMember = "id_rubro";
                ddRubros.SelectedItem = rubros.First();
            }
        }

        private void cleanInputs()
        {
            //limpio todos los campos
            this.textRazonSocial.Clear();
            this.textCUIT.Clear();
            this.textMail.Clear();
            this.textTelefono.Clear();
            this.textCalle.Clear();
            this.textPiso.Clear();
            this.textDpto.Clear();
            this.textLocalidad.Clear();
            this.textCP.Clear();
            this.textUsuario.Clear();
            this.textContra.Clear();
            
            this.textNombreContacto.Clear();
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

            if (string.IsNullOrEmpty(textCP.Text))
                textCP.Text = "-";
            if (string.IsNullOrEmpty(textPiso.Text))
                textPiso.Text = "-";
            if (string.IsNullOrEmpty(textDpto.Text))
                textDpto.Text = "-";

            bool alta = DB_Ofertas.altaProveedor( this.textUsuario.Text,
                                                this.textContra.Text,
                                                this.textRazonSocial.Text,
                                                this.textCUIT.Text,
                                                this.textMail.Text,
                                                this.textTelefono.Text,
                                                this.textNombreContacto.Text,
                                                this.ddRubros.Text,
                                                this.textCalle.Text,
                                                this.textPiso.Text,
                                                this.textDpto.Text,
                                                this.textLocalidad.Text,
                                                this.textCP.Text);

            if (alta)
            {
                MessageBox.Show("Proveedor dado de alta correctamente", "Alta proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleanInputs();
            }
        }

        private String[] loadInputs()
        {
            String[] i ={
            this.textRazonSocial.Text,
            this.textCUIT.Text,
            this.textMail.Text,
            this.textTelefono.Text,
            this.textNombreContacto.Text,
           // this.ddRubros.SelectedText,
            this.textCalle.Text,
            //this.textPiso.Text,
            //this.textDpto.Text,
            this.textLocalidad.Text,
            //this.textCP.Text,
           };
            return i;
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
                    AbmProveedores a = new AbmProveedores();
                    a.Show();
                    this.cleanInputs();
                    this.Hide();
                }
            }
            else{
                //se deberia quedar en esta pantalla
            }
        }

        private void textTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }

        private void textNombreContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.letras(e);
        }

        private void textCUIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }

        private void AltaProveedor_Load(object sender, EventArgs e)
        {

        }

    }
}
