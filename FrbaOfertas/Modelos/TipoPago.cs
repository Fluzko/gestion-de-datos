using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelos
{
    class TipoPago
    {
        public int id_tipo { get; set; }
        public String nombre { get; set; }
        
        public TipoPago(int id, String nombre)
        {
            this.id_tipo = id;
            this.nombre = nombre;
        }

    }
}
