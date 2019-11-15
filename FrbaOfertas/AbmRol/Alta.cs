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
    public partial class Alta : Form
    {
        public Alta()
        {
            InitializeComponent();
            Decoracion.Reorganizar(this);
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            String nombreRol;
            List<int> funcionalidades = new List<int>();
            
           
            foreach (DataGridViewRow row in tablaFuncionalidades.Rows)
            {            
               if (row.Cells[0].Value.Equals("True"))
                {

                    funcionalidades.Add(int.Parse(row.Cells[1].Value.ToString()));
                }
            }

            nombreRol = textNombre.Text;

            bool alta = DB_Ofertas.crearRol(nombreRol, funcionalidades);

            if (alta) 
                MessageBox.Show("Rol creado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void Alta_Load(object sender, EventArgs e)
        {
            List<Modelos.Funcionalidad> funcionalidades = DB_Ofertas.getFuncionalidades();
            showFuncionalidades(funcionalidades);
            tablaFuncionalidades.Columns["id_funcionalidad"].ReadOnly = true;
            tablaFuncionalidades.Columns["funcionalidad"].ReadOnly = true;
            tablaFuncionalidades.Columns["descripcion"].ReadOnly = true;
        }

        private void showFuncionalidades(List<Modelos.Funcionalidad> funcionalidades)
        {
            tablaFuncionalidades.DataSource = funcionalidades;
            tablaFuncionalidades.AutoResizeColumns();
            tablaFuncionalidades.Rows[0].Selected = true;
            foreach (DataGridViewRow row in tablaFuncionalidades.Rows)
            {
                row.Cells[0].Value = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tablaFuncionalidades_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult boton = MessageBox.Show("Si vuelve se borraran todos los datos ingresados", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (boton == DialogResult.OK)
            {
                if (Session.isNull())
                {
                    Registro.Registro a = new Registro.Registro();
                    a.Show();
                    this.textNombre.Clear();
                    this.Hide();
                }
                else
                {
                    AbmRol a = new AbmRol();
                    a.Show();
                    this.textNombre.Clear();
                    this.Hide();
                }
            }
            else
            {
                //se deberia quedar en esta pantalla
            }
        }
    }
}
