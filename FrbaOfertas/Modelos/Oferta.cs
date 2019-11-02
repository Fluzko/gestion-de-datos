using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelos
{
    class Oferta
    {
        public int Id { get; set; }
        public String Proveedor { get; set; }
        public String Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public Decimal Precio { get; set; }
        public int MaxPorCliente { get; set; }
        public int CantDisponible { get; set; }
        
        public Oferta(){}

    }
}
