using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelos
{
    class Tarjeta
    {   
        public String Numero { get; set; }
        public String Vencimiento { get; set; }
        public String Titular { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public String CodigoVerificacion { get; set; }

    }
}
