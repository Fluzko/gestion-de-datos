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
        List<Modelos.Funcionalidad> funcionalidades;

        public Funcionalidad(Modelos.Rol rol)
        {
            InitializeComponent();
            this.rol = rol;
            Titulo.Text = "Rol: " + rol.nombre;
            loadFuncionalidades();
        }

        private void loadFuncionalidades()
        {
            funcionalidades = this.rol.getFuncionalidades();

            if (funcionalidades.Count == 0)
            {
                MessageBox.Show("El usuario no tiene roles asignados", "Aviso");
            }
            else
            {
                funcionalidadescbx.DataSource = funcionalidades;
                funcionalidadescbx.DisplayMember = "funcionalidad";
                funcionalidadescbx.ValueMember = "id_funcionalidad";

                funcionalidadescbx.SelectedItem = funcionalidades.First();
            }
        }


        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (!((Modelos.Funcionalidad)funcionalidadescbx.SelectedItem).Equals(null))
            {
                //pasar al menu adecuado
                Modelos.Funcionalidad funcionalidad = funcionalidades.Where(func => func.funcionalidad == funcionalidadescbx.Text).ToList().First();
                funcionalidad.changeView();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Elija una funcionalidad valida", "Error");
            }
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
