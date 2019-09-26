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
        String username;
        public Rol(String username)
        {
            InitializeComponent();
            this.username = username;
            Titulo.Text = "Usuario: "+username;
            loadRoles();
        }

        private void loadRoles()
        {
            List<String> roles = DB_Ofertas.getRoles(this.username);

            if (roles.Count == 0)
            {
                MessageBox.Show("El usuario no tiene roles asignados", "Aviso");
            }
            else
            {
                for(int i = 0; i < roles.Count(); i++){ //cargo el combobox
                    rolescbx.Items.Add(roles.ElementAt(i)); 
                }
            }
        }


        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(rolescbx.Text)){
            //pasa a pantalla de funcionalidad
            Funcionalidad f = new Funcionalidad(this.rolescbx.Text);
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
    }
}
