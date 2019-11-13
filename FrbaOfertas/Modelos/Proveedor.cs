using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelos
{
    class Proveedor
    {
        public String Username { get; set; }
        public String RazonSocial { get; set; }
        public int Telefono { get; set; }
        public String Mail { get; set; }
        public String Cuit { get; set; }
        public String Rubro { get; set; }
        public String NombreContacto { get; set; }
        public String Direccion { get; set; }
        public String Cp { get; set; }
        public String Piso { get; set; }
        public String Dpto { get; set; }
        public String Localidad { get; set; }
        public bool habilitado { get; set; } 

        public Proveedor() { }


    }
}
