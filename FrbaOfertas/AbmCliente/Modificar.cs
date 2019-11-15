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
        private String dniCliActual, mailCliActual;

        public Modificar()
        {
            InitializeComponent();
            Decoracion.Reorganizar(this);
            comboHabilitado.Items.Add("Habilitado");
            comboHabilitado.Items.Add("Deshabilitado");
            textApellidoB.CharacterCasing = CharacterCasing.Upper;
            textNombreB.CharacterCasing = CharacterCasing.Upper;
            textNombre.CharacterCasing = CharacterCasing.Upper;
            textApellido.CharacterCasing = CharacterCasing.Upper;
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
                    Console.WriteLine(textNombreB.Text);
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
            if (string.IsNullOrWhiteSpace(textDNIB.Text) || string.IsNullOrEmpty(textDNIB.Text))
            {
                List<Modelos.Cliente> clientes = DB_Ofertas.getClientes(textNombreB.Text, textApellidoB.Text, textEmailB.Text);

                if (clientes == null)
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
                showClients(clientes);
                return;
            }
            else
            {
                List<Modelos.Cliente> clientes = DB_Ofertas.getClientes(textNombreB.Text, textApellidoB.Text, textEmailB.Text, textDNIB.Text);

                if (clientes == null)
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
            dniCliActual = cliente.Dni.ToString();
            textNombre.Text = cliente.Nombre;
            textApellido.Text = cliente.Apellido;
            textMail.Text = cliente.Mail;
            mailCliActual = cliente.Mail;
            textTel.Text = cliente.Telefono.ToString();
            textPiso.Text = cliente.Piso.ToString();
            textCalle.Text = cliente.Direccion;
            textCP.Text = cliente.Cp.ToString();
            textDpto.Text = cliente.Dpto;
            textLoc.Text = cliente.Localidad;
            textFN.Text = cliente.FechaNac.ToShortDateString();
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
            TextBox[] i = { textDNI, textNombre, textApellido, textMail, textTel, textPiso, textCalle, textCP, textDpto, textLoc, textFN };
            return i;
        }

        private TextBox[] requiredInputs()
        {
            TextBox[] i = { textDNI, textNombre, textApellido, textMail, textTel, textCalle, textLoc, textFN };
            return i;
        }


        private void dissableButtons()
        {
            Button[] buttons = { btnModificar, buttonFecha };

            foreach (Button button in buttons)
            {
                button.Enabled = false;
            }
            comboHabilitado.Enabled = false;
        }


        private void enableButtons()
        {
            Button[] buttons = { btnModificar, buttonFecha };


            foreach (Button button in buttons)
            {
                button.Enabled = true;
            }
            comboHabilitado.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (requiredInputs().Any(input => string.IsNullOrEmpty(input.Text) || string.IsNullOrWhiteSpace(input.Text)))
            {
                MessageBox.Show("Faltan llenar campos obligatorios", "Modificar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validar.validateEmail(textMail.Text))
            {
                MessageBox.Show("Formato de email invalido", "Modificar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textMail.Text != this.mailCliActual)
            {
                if (DB_Ofertas.mailExists(textMail.Text))
                {
                    MessageBox.Show("El email que intenta modificar ya esta asociado a un cliente", "Modificar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textDNI.Text != this.dniCliActual)
            {
                if (DB_Ofertas.dniExists(textDNI.Text))
                {
                    MessageBox.Show("El dni que intenta modificar ya esta asociado a un cliente", "Modificar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Modelos.Cliente clienteUpdate = new Modelos.Cliente();
            clienteUpdate.Username = username;
            clienteUpdate.Nombre = textNombre.Text;
            clienteUpdate.Apellido = textApellido.Text;
            clienteUpdate.Dni = int.Parse(textDNI.Text);
            clienteUpdate.Mail = textMail.Text;
            clienteUpdate.FechaNac = Convert.ToDateTime(this.textFN.Text);
            clienteUpdate.Telefono = int.Parse(textTel.Text);
            clienteUpdate.Direccion = textCalle.Text;
            if (string.IsNullOrEmpty(textPiso.Text) || string.IsNullOrWhiteSpace(textPiso.Text))
                clienteUpdate.Cp = "-";
            else
                clienteUpdate.Cp = textCP.Text;
            if (string.IsNullOrEmpty(textDpto.Text) || string.IsNullOrWhiteSpace(textDpto.Text)) 
                clienteUpdate.Dpto = "-";
            else
                clienteUpdate.Dpto = textDpto.Text;
            if (string.IsNullOrEmpty(textPiso.Text) || string.IsNullOrWhiteSpace(textPiso.Text))
                clienteUpdate.Piso = "-";
            else
                clienteUpdate.Piso = textPiso.Text;
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

        private void buttonFecha_Click(object sender, EventArgs e)
        {
            this.calendario.Show();
            this.calendario.BringToFront();
            this.calendario.Select();
        }

        private void calendario_Leave(object sender, EventArgs e)
        {
            this.calendario.Hide();
        }

        private void calendario_DateSelected(object sender, DateRangeEventArgs e)
        {
            textFN.Text = calendario.SelectionRange.Start.ToShortDateString();
            calendario.Hide();
        }

        private void Modificar_Load(object sender, EventArgs e)
        {

        }

        private void clientesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
