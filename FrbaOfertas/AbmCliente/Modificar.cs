using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmCliente
{
    public partial class Modificar : Form
    {
        private String username {get; set;}

        public Modificar()
        {
            InitializeComponent();
            Decoracion.Reorganizar(this);
            dateTimePicker1.Enabled = false;
            comboHabilitado.Items.Add("Habilitado");
            comboHabilitado.Items.Add("Deshabilitado");
        }


        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textApellidoB.Clear();
            textNombreB.Clear();
            textEmailB.Clear();
            textDNIB.Clear();
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
                    MessageBox.Show("No hay clientes que coincidan con su busqueda", "Alta cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrWhiteSpace(textDNIB.Text) || string.IsNullOrEmpty(textDNIB.Text))
            {
                List<Modelos.Cliente> clientes = DB_Ofertas.getClientes(textNombreB.Text, textApellidoB.Text, textEmailB.Text);

                if (clientes == null)
                {
                    MessageBox.Show("No hay clientes que coincidan con su busqueda", "Alta cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
            {
                List<Modelos.Cliente> clientes = DB_Ofertas.getClientes(textNombreB.Text, textApellidoB.Text, textEmailB.Text, textDNIB.Text);

                if (clientes == null)
                {
                    MessageBox.Show("No hay clientes que coincidan con su busqueda", "Alta cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }


        private String[] loadSearchInputs()
        {
            String[] i = {
                            this.textApellidoB.Text,
                            this.textNombreB.Text,
                            this.textDNIB.Text,
                            this.textEmailB.Text
                         };
            return i;
        }


        private void showClients(List<Modelos.Cliente> clientes)
        {
            clientesGrid.DataSource = clientes;
            clientesGrid.AutoResizeColumns();
            clientesGrid.Rows[0].Selected = true;
        }

        private void clientesGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            DataGridViewRow selectedRow = clientesGrid.Rows[i];
            Modelos.Cliente cliente = ((Modelos.Cliente)selectedRow.DataBoundItem);
            username = cliente.Username;
            textDNI.Text = cliente.Dni.ToString();
            textNombre.Text = cliente.Nombre;
            textApellido.Text = cliente.Apellido;
            textMail.Text = cliente.Mail;
            textTel.Text = cliente.Telefono.ToString();
            textPiso.Text = cliente.Piso.ToString();
            textCalle.Text = cliente.Direccion;
            textCP.Text = cliente.Cp.ToString();
            textDpto.Text = cliente.Dpto;
            textLoc.Text = cliente.Localidad;
            dateTimePicker1.Value = cliente.FechaNac;
            comboHabilitado.SelectedIndex = comboHabilitado.FindString(habilitadoToString(cliente));

            foreach (TextBox input in modificableInputs())
            {
                input.Enabled = true;
            }
            enableButtons();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            (new AbmCliente()).Show();
            this.Hide();
        }

        
        private TextBox[] modificableInputs()
        {
            TextBox[] i = { textDNI, textNombre, textApellido, textMail, textTel, textPiso, textCalle, textCP, textDpto, textLoc };
            return i;
        }


        private void dissableButtons()
        {
            Button[] buttons = { btnModificar };

            foreach (Button button in buttons)
            {
                button.Enabled = false;
            }
            dateTimePicker1.Enabled = false;
            comboHabilitado.Enabled = false;
        }


        private void enableButtons()
        {
            Button[] buttons = { btnModificar };


            foreach (Button button in buttons)
            {
                button.Enabled = true;
            }
            dateTimePicker1.Enabled = true;
            comboHabilitado.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modelos.Cliente clienteUpdate = new Modelos.Cliente();
            clienteUpdate.Username = username;
            clienteUpdate.Nombre = textNombre.Text;
            clienteUpdate.Apellido = textApellido.Text;
            clienteUpdate.Dni = int.Parse(textDNI.Text);
            clienteUpdate.Mail = textMail.Text;
            clienteUpdate.FechaNac = Convert.ToDateTime(dateTimePicker1.Text);
            clienteUpdate.Telefono = int.Parse(textTel.Text);
            clienteUpdate.Direccion = textCalle.Text;
            clienteUpdate.Cp = int.Parse(textCP.Text);
            clienteUpdate.Dpto = textDpto.Text;
            clienteUpdate.Piso = int.Parse(textPiso.Text);
            clienteUpdate.Localidad = textLoc.Text;
            clienteUpdate.habilitado = habilitadoToBool(comboHabilitado.SelectedItem.ToString());

            DB_Ofertas.updateCliente(clienteUpdate);
        }

        private String habilitadoToString(Modelos.Cliente cliente)
        {
            if (cliente.habilitado) return "Habilitado";
            else return "Deshabilitado";
        }

        private bool habilitadoToBool(String habilitado){
            if (habilitado == "Habilitado") return true;
            else return false;
        }

        private void textDNIB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }

        private void textNombreB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.letras(e);
        }



    }
}
