using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Facturar
{
    public partial class Facturar : Form
    {
        List<Modelos.Proveedor> proveedores;
        Modelos.Proveedor proveedorSeleccionado;
        List<Modelos.Cupon> cupones;
        DateTime desde; 
        DateTime hasta;

        public Facturar()
        {
            InitializeComponent();
            Decoracion.Reorganizar(this);
            listProveedores();
        }


        private void listProveedores()
        {
            proveedores = DB_Ofertas.getProveedoresFacturacion();

            if (proveedores.Count != 0)
            {
                ddProveedor.Enabled = true;
                ddProveedor.DataSource = proveedores;
                ddProveedor.DisplayMember = "razonSocial";
                ddProveedor.ValueMember = "username";
                ddProveedor.SelectedItem = proveedores.First();
            }
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            (new Login.Funcionalidad(Session.getRol())).Show();
            this.Hide();
        }


        private void Facturar_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            proveedorSeleccionado = proveedores.Where(p => p.razonSocial == ddProveedor.Text).ToList().First();

            cupones = DB_Ofertas.getCupones(proveedorSeleccionado.username, dateTimeDesde.Value, dateTimeHasta.Value);

            dataGridCupones.DataSource = cupones;

            desde = dateTimeDesde.Value;
            hasta = dateTimeHasta.Value;

            dataGridCupones.AutoResizeColumns();

        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            bool rsp = DB_Ofertas.facturarCupones(proveedorSeleccionado, desde, hasta);
                    
        }

    }
}
