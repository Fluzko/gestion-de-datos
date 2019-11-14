using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelos
{
    class ProveedorEstadistica1
    {
        public String Username { get; set; }
        public String RazonSocial { get; set; }
        public Double Facturacion { get; set; }

        public ProveedorEstadistica1(String user, String rs, Double fact)
        {
            this.Username = user;
            this.RazonSocial = rs;
            this.Facturacion = fact;
         }
    }
}
