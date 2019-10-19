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
    public partial class Login : Form
    {
        private String username;
        private String password;
        private String usuarioBloqueado;
        private short intentos = 0;

        public Login()
        {
            InitializeComponent();
            Decoracion.Reorganizar(this);
            Session.setSession(null,null);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //Boton de logueo
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.username) || String.IsNullOrEmpty(this.password)){
                MessageBox.Show("El Usuario o la Contrasena no pueden estar vacios", "Error");
                return;
            }

            if(this.usuarioBloqueado == this.username){
                MessageBox.Show("Usuario: "+ this.username +" inhabilitado por multiples intentos fallidos", "Error");
                return;
            }

            //consulta  a la DB
            Modelos.Usuario usuario = DB_Ofertas.login(this.username, this.password);

            if (usuario != null){
                //pantalla de seleccion de rol
                 Rol r = new Rol(usuario);
                 r.Show();
                this.Hide();
            }
            else{
                if (this.intentos <= 3) { this.intentos++; }
              
                if (this.intentos > 3)
                {
                    this.usuarioBloqueado = this.username;
                    MessageBox.Show("Se ha inhabilitado el usuario: " + this.username + " por superar la cantidad de intentos", "Error");
                    return;
                }
                else
                {
                    MessageBox.Show("Usuario o contrasena invalida, intentos restantes: "+(3 - this.intentos)+"","Error");
                    return;
                }
            }
        }

        //input de password
        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            this.password = txtPass.Text;
        }

        //input de nombre de usuario
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            this.username = txtUsername.Text;
        }

        //boton cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //ir a registro
        private void LbelChofer_Click(object sender, EventArgs e)
        {
            (new Registro.Registro()).Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
