using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelos
{
    public class Rol
    {
        public int id_rol  { get; set; }
        public String nombre { get; set; }

        public Rol(int id, String nombre)
        {
            this.id_rol = id;
            this.nombre = nombre;
        }


        public List<Modelos.Funcionalidad> getFuncionalidades(){
            return DB_Ofertas.getFuncionalidades(this.id_rol);
        }
    }
}
