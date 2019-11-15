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
            ddEstado.Items.Add("Habilitado");
            ddEstado.Items.Add("Deshabilitado");

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            
        }
        private String habilitadoToString(int id_rol)
        {
            if (DB_Ofertas.habilitado(id_rol)) return "Habilitado";
            else return "Deshabilitado";
        }

        private bool habilitadoToBool(String habilitado)
        {
            if (habilitado == "Habilitado") return true;
            else return false;
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
            ddEstado.SelectedIndex = ddEstado.FindString(habilitadoToString(idRol));
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
                    row.Cells[0].Value = "True";
                else
                    row.Cells[0].Value = "False";
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
            bool habilitado = habilitadoToBool(ddEstado.Text);
            bool update = DB_Ofertas.updateRol(nombreNuevoRol, nombreViejoRol, funcionalidades,habilitado);

            if (update) 
                MessageBox.Show("Rol modificado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textNombreNuevo.Clear();
            textNombreRol.Clear();
            ddEstado.Items.Clear();
            tablaFuncionalidades.DataSource = null;

        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
               AbmRol a = new AbmRol();
               a.Show();
               this.textNombreRol.Clear();
               this.textNombreNuevo.Clear();
               this.Hide();
    
        }

        private void buttonLimpiar_Click_1(object sender, EventArgs e)
        {
            this.textNombreRol.Clear();
            this.textNombreNuevo.Clear();
        }

        private void Modificar_Load(object sender, EventArgs e)
        {

        }

        private void ddEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
