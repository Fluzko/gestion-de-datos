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
        public Rol(Modelos.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            Titulo.Text = "Usuario: " + this.usuario.getUsername();
            loadRoles();
        }

        private void loadRoles()
        {
            List<Modelos.Rol> roles = this.usuario.getRoles();

            if (roles.Count == 0)
            {
                MessageBox.Show("El usuario no tiene roles asignados", "Aviso");
            }
            else
            {
                roles.ForEach(delegate(Modelos.Rol rol){ //cargo el combobox
                    rolescbx.Items.Add(rol);
                });
                rolescbx.SelectedItem = roles.First();
            }
        }



        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(rolescbx.Text)){
            //pasa a pantalla de funcionalidad
            Funcionalidad f = new Funcionalidad((Modelos.Rol) this.rolescbx.SelectedItem);
            f.Show();
            this.Hide();
            }else{
                MessageBox.Show("No se puede ingresar sin seleccionar un rol, intente con otro usuario","Error");
            }
        }

        private void Roles_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}
