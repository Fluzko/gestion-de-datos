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
    public partial class Rol : Form
    {
        Modelos.Usuario usuario;
        List<Modelos.Rol> roles;

        public Rol(Modelos.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            Titulo.Text = "Usuario: " + this.usuario.getUsername();
            this.loadRoles();
        }

        private void loadRoles()
        {
            this.roles = this.usuario.getRoles();
            
            if (roles.Count == 0)
            {
                MessageBox.Show("El usuario no tiene roles asignados", "Aviso");
            }
            else
            {
                rolescbx.DataSource = roles;
                rolescbx.DisplayMember = "nombre";
                rolescbx.ValueMember = "id_rol";

                rolescbx.SelectedItem = roles.First();   
            }
        }



        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(rolescbx.Text)){
            //pasa a pantalla de funcionalidad
            Modelos.Rol r = roles.Where(rol => rol.nombre == rolescbx.Text).ToList().First();
            Funcionalidad f = new Funcionalidad(r);

            Session.setSession(usuario,r);
            f.Show();
            this.Hide();
            
            }else{
                MessageBox.Show("No se puede ingresar sin seleccionar un rol, intente con otro usuario","Error");
            }
        }


        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Rol_Load(object sender, EventArgs e)
        {

        }

        private void rolescbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
