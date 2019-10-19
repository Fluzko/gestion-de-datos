using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelos
{
    class Cliente
    {
        public String Username { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int Dni { get; set; }
        public String Mail { get; set; }
        public int Telefono { get; set; }
        public String Direccion { get; set; }
        public int Cp { get; set; }
        public int Piso { get; set; }
        public String Dpto { get; set; }
        public String Localidad { get; set; }
        public DateTime FechaNac { get; set; }
        public Decimal Credito { get; set; }
        public bool habilitado { get; set; } 
        
        
        public Cliente(){}

    }
}
