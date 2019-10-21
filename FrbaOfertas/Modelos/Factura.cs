using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelos
{
    class Factura
    {
        public Decimal monto{ get; set; }
        public String proveedor { get; set; }
        public DateTime fecha { get; set; }
        public List<Renglon> renglones { get; set; }

        public Factura() { }
    }
}
