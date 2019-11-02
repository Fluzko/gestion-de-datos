using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelos
{
    class Cupon
    {
        public int Id { get; set; }
        public String Cliente { get; set; }
        public int IdOferta { get; set; }
        public String DescripcionOferta { get; set; }
        public DateTime FechaCompra { get; set; }

        public Cupon() { }

    }
}
