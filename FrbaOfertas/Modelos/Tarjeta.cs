using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelos
{
    class Tarjeta
    {
        public String Titular { get; set; }
        public String Numero { get; set; }
      
        public Tarjeta(String numero, String tit)
        {
            this.Titular = tit;
            this.Numero = numero;
         }
    }
}
