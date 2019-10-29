using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelos
{
    class Cupon
    {
        public DateTime fechaCompra { get; set; }
        public int NumeroCupon { get; set; }
        public String cliente { get; set; }
        public String oferta { get; set; }
        //public DateTime fechaEntrega { get; set; }

        public Cupon() { }

    }
}
