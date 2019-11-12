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
    public partial class ModificarProveedores : Form
    {
        public ModificarProveedores()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void ModificarProveedores_Load(object sender, EventArgs e)
        {

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
             String[] searchables = loadSearchInputs();

            //todos los campos de busqueda vacios
            if (searchables.All(searchable => string.IsNullOrEmpty(searchable) || string.IsNullOrWhiteSpace(searchable)))
            {

                List<Modelos.Cliente> clientes = DB_Ofertas.getClientes();

                if (clientes == null)
                {
                    Console.WriteLine(textCUITB.Text);
                    MessageBox.Show("No hay clientes", "Modificar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (TextBox input in modificableInputs())
                {
                    input.Enabled = false;
                    input.Clear();
                }
                dissableButtons();
                showClients(clientes);
                return;
            }

            //si no ingresa dni
            if (string.IsNullOrWhiteSpace(textRazonSocialB.Text) || string.IsNullOrEmpty(textRazonSocialB.Text))
            {
                List<Modelos.Proveedor> clientes = DB_Ofertas.getProveedores(textCUITB.Text, textApellidoB.Text, textEmailB.Text);

                if (proveedores == null)
                {
                    MessageBox.Show("No hay proveedores que coincidan con su busqueda", "Modificar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (TextBox input in modificableInputs())
                {
                    input.Enabled = false;
                    input.Clear();
                }
                dissableButtons();
                showProveedores(proveedores);
                return;
            }
            else
            {
                List<Modelos.Proveedor> proveedores = DB_Ofertas.getProveedores(textCUITB.Text, textEmailB.Text, textRazonSocialB.Text);

                if (proveedores == null)
                {
                    MessageBox.Show("No hay clientes que coincidan con su busqueda", "Modificar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (TextBox input in modificableInputs())
                {
                    input.Enabled = false;
                    input.Clear();
                }
                dissableButtons();
                showProveedores(proveedores);
                return;
            }
        }

          private String[] loadSearchInputs()
        {
            String[] i = {
                            this.textRazonSocialB.Text,
                            this.textCUITB.Text,
                            this.textEmailB.Text
                         };
            return i;
        }
        private void showProveedores(List<Modelos.Proveedor> proveedores)
        {
            proveedoresGrid.DataSource = proveedores;
            proveedoresGrid.AutoResizeColumns();
            proveedoresGrid.Rows[0].Selected = true;
        }

         private TextBox[] modificableInputs()
        {
            TextBox[] i = { textRazonSocial, textNombreContacto, textRubro, textMail, textTel, textPiso, textCalle, textCP, textDpto, textLoc, textCUIT };
            return i;
        }

             private void dissableButtons()
        {
            Button[] buttons = { btnModificar};

            foreach (Button button in buttons)
            {
                button.Enabled = false;
            }
         
        }
      
    }


    }
}
