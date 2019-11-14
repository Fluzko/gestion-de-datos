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
    public partial class AgregarTarjeta : Form
    {
        public AgregarTarjeta()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Validaciones:
            //valida vacios
            String[] inputs = loadInputs();
            if (inputs.Any(input => String.IsNullOrEmpty(input)))
            {
                MessageBox.Show("Faltan llenar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtCodigo.TextLength != 3)
            {
                MessageBox.Show("El codigo de seguridad no es correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int intMes = int.Parse(txtMes.Text);
            if (intMes > 12 || intMes < 0)
            {
                MessageBox.Show("Error en el campo mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            int intAnio = int.Parse(txtAnio.Text);
            if (intAnio < 0 || intAnio/100 >= 1) //Negativo o mas de 2 digitos
            {
                MessageBox.Show("Error en el campo anio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            DB_Ofertas.agregarTarjetasParaCliente(Session.getUser().getUsername(), txtNumero.Text, txtTitular.Text, intMes, int.Parse(txtAnio.Text), txtCodigo.Text);
            CargaCredito cc = new CargaCredito();
            cc.Show();
            this.Hide();
        }       

        private void btnVolver_Click(object sender, EventArgs e)
        {
            CargaCredito cc = new CargaCredito();
            cc.Show();
            this.Hide();
        }

        private String[] loadInputs()
        {
            String[] i ={
            this.txtNumero.Text,
            this.txtTitular.Text,
            this.txtMes.Text,
            this.txtAnio.Text,
            this.txtCodigo.Text,
            };
            
            return i;
        }
        //campos tipo numerico      

        private void txtMes_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }

        private void txtAnio_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }

        private void txtNumero_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }
        

       
    }
}
