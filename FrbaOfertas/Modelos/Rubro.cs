using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelos
{
    class Rubro
    {
        public int id_rubro { get; set; }
        public string nombre { get; set; }
        public bool habilitado { get; set; }

        public Rubro() { }
    }
}
