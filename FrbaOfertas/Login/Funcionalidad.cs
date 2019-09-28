using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Login
{
    public partial class Funcionalidad : Form
    {
        Modelos.Rol rol;
     
        public Funcionalidad(Modelos.Rol rol)
        {
            InitializeComponent();
            this.rol = rol;
            Titulo.Text = "Rol: " + rol.getNombre();
            loadFuncionalidades();
        }

        private void loadFuncionalidades()
        {
            List<Modelos.Funcionalidad> funcionalidades = this.rol.getFuncionalidades();

            if (funcionalidades.Count == 0)
            {
                MessageBox.Show("El usuario no tiene roles asignados", "Aviso");
            }
            else
            {
                funcionalidades.ForEach(delegate(Modelos.Funcionalidad funcionalidad)
                { //cargo el combobox
                    funcionalidadescbx.Items.Add(rol);
                });
                funcionalidadescbx.SelectedItem = funcionalidades.First();
            }
        }

        private void titulo_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(funcionalidadescbx.Text))
            {
                //pasar al menu adecuado
                
                //f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No se puede ingresar sin seleccionar un rol, intente con otro usuario", "Error");
            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {

        }

        private void cerrarSesion_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void Funcionalidad_Load(object sender, EventArgs e)
        {

        }
    }
}
