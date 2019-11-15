using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelos
{
    class ProveedorEstadistica2
    {

        public String Username { get; set; }
        public String RazonSocial { get; set; }
        public Double PorcentajeDescuento { get; set; }

        
        public ProveedorEstadistica2(String user, String rs, Double pd)
        {
            this.Username = user;
            this.RazonSocial = rs;
            this.PorcentajeDescuento = pd;
         }
    }
}
