using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmRol
{
    public partial class Eliminar : Form
    {

        List<string> roles;

        public Eliminar()
        {
            InitializeComponent();
            Decoracion.Reorganizar(this);
            listRoles();
        }

        private void tablaFuncionalidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Modificar_Load(object sender, EventArgs e)
        {

        }

        private void listRoles()
        {
            roles = DB_Ofertas.getAllRoles();

            if (roles.Count != 0)
            {
                ddRoles.Enabled = true;
                ddRoles.DataSource = roles;
                ddRoles.DisplayMember = "nombre";
                //ddRoles.ValueMember = "nombre";
                ddRoles.SelectedItem = roles.First();
            }
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            if (Session.isNull())
            {
                Registro.Registro a = new Registro.Registro();
                a.Show();
                this.Hide();
            }
            else
            {
                AbmRol a = new AbmRol();
                a.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult boton = MessageBox.Show("Estas seguro que quieres borrar el rol?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (boton == DialogResult.OK)
            {
               bool eliminar = DB_Ofertas.eliminarRol(ddRoles.Text);
                if (eliminar)
                {
                    MessageBox.Show("Se borro el rol seleccionado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                    listRoles();
                    ddRoles.ResetText();
                }
             }           
            else
            {
                //se deberia quedar en esta pantalla
            }
            
        }
    }
}