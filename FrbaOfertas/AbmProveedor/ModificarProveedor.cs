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
    public partial class ModificarProveedor : Form
    {
        List<Modelos.Rubro> rubros;
        private String username { get; set; }
        private String razonProvActual, mailProvActual;

        public ModificarProveedor()
        {
            InitializeComponent();
            Decoracion.Reorganizar(this);
            listRubros();
            comboHabilitado.Items.Add("Habilitado");
            comboHabilitado.Items.Add("Deshabilitado");
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textRazonSocialB.Clear();
            textCUITB.Clear();         
            textMail.Clear();
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

                List<Modelos.Proveedor> proveedores = DB_Ofertas.getProveedores();

                if (proveedores == null)
                {
                    Console.WriteLine(textCUITB.Text);
                    MessageBox.Show("No hay proveedores", "Modificar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            //si no ingresa razon social
            if (string.IsNullOrWhiteSpace(textRazonSocialB.Text) || string.IsNullOrEmpty(textRazonSocialB.Text))
            {
                List<Modelos.Proveedor> proveedores = DB_Ofertas.getProveedores(textCUITB.Text, textEmailB.Text);

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
            //si no ingresa cuit
            if (string.IsNullOrWhiteSpace(textCUITB.Text) || string.IsNullOrEmpty(textCUITB.Text))
            {
                List<Modelos.Proveedor> proveedores = DB_Ofertas.getProveedoresRSyE(textRazonSocialB.Text, textEmailB.Text);

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

            //si no ingresa mail
            if (string.IsNullOrWhiteSpace(textEmailB.Text) || string.IsNullOrEmpty(textEmailB.Text))
            {
                List<Modelos.Proveedor> proveedores = DB_Ofertas.getProveedoresRSyC(textRazonSocialB.Text, textCUITB.Text);

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

            //ingresa solo razon social
            if (string.IsNullOrWhiteSpace(textEmailB.Text) || string.IsNullOrEmpty(textEmailB.Text) && (string.IsNullOrWhiteSpace(textCUITB.Text)||string.IsNullOrEmpty(textCUITB.Text)))
            {
                List<Modelos.Proveedor> proveedores = DB_Ofertas.getProveedoresRS(textRazonSocialB.Text);

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
            //ingresa solo mail
            if (string.IsNullOrWhiteSpace(textRazonSocialB.Text) || string.IsNullOrEmpty(textRazonSocialB.Text) && (string.IsNullOrWhiteSpace(textCUITB.Text) || string.IsNullOrEmpty(textCUITB.Text)))
            {
                List<Modelos.Proveedor> proveedores = DB_Ofertas.getProveedoresE(textEmailB.Text);

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
            //ingresa solo cuit
            if (string.IsNullOrWhiteSpace(textEmailB.Text) || string.IsNullOrEmpty(textEmailB.Text) && (string.IsNullOrWhiteSpace(textRazonSocialB.Text) || string.IsNullOrEmpty(textRazonSocialB.Text)))
            {
                List<Modelos.Proveedor> proveedores = DB_Ofertas.getProveedoresC(textCUITB.Text);

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
            TextBox[] i = { textRazonSocial, textNombreContacto, textMail, textTel, textPiso, textCalle, textCP, textDpto, textLoc, textCUIT };
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
        if (requiredInputs().Any(input => string.IsNullOrEmpty(input.Text) || string.IsNullOrWhiteSpace(input.Text)))
            {
                MessageBox.Show("Faltan llenar campos obligatorios", "Modificar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validar.validateEmail(textMail.Text))
            {
                MessageBox.Show("Formato de email invalido", "Modificar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textMail.Text != this.mailProvActual)
            {
                if (DB_Ofertas.mailExistsProv(textMail.Text))
                {
                    MessageBox.Show("El email que intenta modificar ya esta asociado a un proveedor", "Modificar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (textRazonSocial.Text != this.razonProvActual)
            {
                if (DB_Ofertas.razonExists(textRazonSocial.Text))
                {
                    MessageBox.Show("La razon que intenta modificar ya esta asociada a un proveedor", "Modificar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Modelos.Proveedor proveedorUpdate = new Modelos.Proveedor();
            proveedorUpdate.Username = username;
            proveedorUpdate.RazonSocial = textRazonSocial.Text;
            proveedorUpdate.Cuit = textCUIT.Text;
            proveedorUpdate.Rubro_Id = DB_Ofertas.idRubro(ddRubros.Text);
            proveedorUpdate.NombreContacto = textNombreContacto.Text;
            if (string.IsNullOrEmpty(textMail.Text) || string.IsNullOrWhiteSpace(textMail.Text))
                proveedorUpdate.Mail = "-";
            else
                proveedorUpdate.Mail = textMail.Text;
            proveedorUpdate.Telefono = int.Parse(textTel.Text);
            if (string.IsNullOrEmpty(textCalle.Text) || string.IsNullOrWhiteSpace(textCalle.Text))
                proveedorUpdate.Direccion = "-";
            else
                proveedorUpdate.Direccion = textCalle.Text;
            if (string.IsNullOrEmpty(textCP.Text) || string.IsNullOrWhiteSpace(textCP.Text))
                proveedorUpdate.Cp = "-";
            else
                proveedorUpdate.Cp = textCP.Text;
            if (string.IsNullOrEmpty(textDpto.Text) || string.IsNullOrWhiteSpace(textDpto.Text))
                proveedorUpdate.Dpto = "-";
            else
                proveedorUpdate.Dpto = textDpto.Text;
            if (string.IsNullOrEmpty(textPiso.Text) || string.IsNullOrWhiteSpace(textPiso.Text))
                proveedorUpdate.Piso = "-";
            else
                proveedorUpdate.Piso = textPiso.Text;
            if (string.IsNullOrEmpty(textLoc.Text) || string.IsNullOrWhiteSpace(textLoc.Text))
                proveedorUpdate.Localidad = "-";
            else
                proveedorUpdate.Localidad = textLoc.Text;
            proveedorUpdate.habilitado = habilitadoToBool(comboHabilitado.SelectedItem.ToString());

            DB_Ofertas.updateProveedor(proveedorUpdate);
            buttonBuscar_Click(sender, e);
        }

        private TextBox[] requiredInputs()
        {
            TextBox[] i = { textRazonSocial, textCUIT, textNombreContacto, textMail, textTel, textCalle, textLoc};
            return i;
        }

        private void proveedoresGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;

            DataGridViewRow selectedRow = proveedoresGrid.Rows[i];
            Modelos.Proveedor proveedor = ((Modelos.Proveedor)selectedRow.DataBoundItem);
            username = proveedor.Username;
            textRazonSocial.Text = proveedor.RazonSocial.ToString();
            razonProvActual = proveedor.RazonSocial.ToString();
            textCUIT.Text = proveedor.Cuit;
            textMail.Text = proveedor.Mail;
            mailProvActual = proveedor.Mail;
            textNombreContacto.Text = proveedor.NombreContacto;
            ddRubros.Text = DB_Ofertas.nombreRubro(proveedor.Rubro_Id);
            textTel.Text = proveedor.Telefono.ToString();
            textPiso.Text = proveedor.Piso.ToString();
            textCalle.Text = proveedor.Direccion;
            textCP.Text = proveedor.Cp.ToString();
            textDpto.Text = proveedor.Dpto;
            textLoc.Text = proveedor.Localidad;
            comboHabilitado.SelectedIndex = comboHabilitado.FindString(habilitadoToString(proveedor));

            foreach (TextBox input in modificableInputs())
            {
                input.Enabled = true;
            }
            enableButtons();
        }

        private String habilitadoToString(Modelos.Proveedor proveedor)
        {
            if (proveedor.habilitado) return "Habilitado";
            else return "Deshabilitado";
        }

        private bool habilitadoToBool(String habilitado)
        {
            if (habilitado == "Habilitado") return true;
            else return false;
        }

        private void enableButtons()
        {
            Button[] buttons = { btnModificar };

            foreach (Button button in buttons)
            {
                button.Enabled = true;
            }
            comboHabilitado.Enabled = true;
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            (new AbmProveedores()).Show();
            this.Hide();
        }

        private void textCUITB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }

        private void proveedoresGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
