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
    public partial class Modificar : Form
    {
        public Modificar()
        {
            InitializeComponent();
            Decoracion.Reorganizar(this);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {

            int idRol = DB_Ofertas.getIdRol(textNombreRol.Text);
            if (idRol == 0)
            {
                MessageBox.Show("El rol ingresado no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
              
            List<Modelos.Funcionalidad> funcionalidades = DB_Ofertas.getFuncionalidades();
            showFuncionalidades(funcionalidades,idRol);
            textNombreNuevo.Text = textNombreRol.Text;
            return;
        }
        private void showFuncionalidades(List<Modelos.Funcionalidad> funcionalidades,int idRol)
        {
            tablaFuncionalidades.DataSource = funcionalidades;
            tablaFuncionalidades.AutoResizeColumns();
            tablaFuncionalidades.Rows[0].Selected = true;
            foreach (DataGridViewRow row in tablaFuncionalidades.Rows)
            {
                if (DB_Ofertas.tieneFuncionalidad(row.Cells[1].Value.ToString(), idRol))
                    row.Cells[0].Value = true;
                else
                    row.Cells[0].Value = false;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            String nombreNuevoRol, nombreViejoRol;
            List<int> funcionalidades = new List<int>();
            
           
            foreach (DataGridViewRow row in tablaFuncionalidades.Rows)
            {            
               if (row.Cells[0].Value.Equals("True"))
                {

                    funcionalidades.Add(int.Parse(row.Cells[1].Value.ToString()));
                }
            }
            nombreViejoRol = textNombreRol.Text;
            nombreNuevoRol = textNombreNuevo.Text;
            bool update = DB_Ofertas.updateRol(nombreNuevoRol, nombreViejoRol, funcionalidades);

            if (update) 
                MessageBox.Show("Rol modificado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            DialogResult boton = MessageBox.Show("Si vuelve se borraran todos los datos ingresados", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (boton == DialogResult.OK)
            {
                if (Session.isNull())
                {
                    Registro.Registro a = new Registro.Registro();
                    a.Show();
                    this.textNombreRol.Clear();
                    this.textNombreNuevo.Clear();
                    this.Hide();
                }
                else
                {
                    AbmRol a = new AbmRol();
                    a.Show();
                    this.textNombreRol.Clear();
                    this.textNombreNuevo.Clear();
                    this.Hide();
                }
            }
            else
            {
                //se deberia quedar en esta pantalla
            }
        }

        private void buttonLimpiar_Click_1(object sender, EventArgs e)
        {
            this.textNombreRol.Clear();
            this.textNombreNuevo.Clear();
        }

    }
}
