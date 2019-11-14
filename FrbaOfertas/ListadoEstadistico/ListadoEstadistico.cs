using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.ListadoEstadistico
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cargarEstadistica1(String anio, int semestre) {
            List<Modelos.ProveedorEstadistica1> proveedores = DB_Ofertas.getProveedoresFacturacion(anio, semestre);
            gridEstadisticas.DataSource = proveedores;
            
        }

        private void cargarEstadistica2(String anio, int semestre)
        {
            List<Modelos.ProveedorEstadistica2> proveedores = DB_Ofertas.getProveedoresPorcentajeOferta(anio, semestre);
            gridEstadisticas.DataSource = proveedores;

        }        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String anio = txtAnio.Text;

            if (anio == "") {
                MessageBox.Show("Debe ingresar un año a buscar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            int semestre;
            if(sem1.Checked){
                semestre = 1;
            }else{
                semestre = 2;
            }
            if(rbEstadistica1.Checked)
                cargarEstadistica1(anio, semestre);
            else
                cargarEstadistica2(anio, semestre);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new Login.Funcionalidad(Session.getRol())).Show();
            this.Hide();
        }

        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.numerico(e);
        }
    }
}
