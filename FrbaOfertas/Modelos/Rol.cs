using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelos
{
    class Rol
    {
        int id_rol;
        String nombre;

        public Rol(int id, String nombre)
        {
            this.id_rol = id;
            this.nombre = nombre;
        }

        public String getNombre() { return nombre; }
        public List<Modelos.Funcionalidad> getFuncionalidades(){
            return DB_Ofertas.getFuncionalidades(this.nombre);
        }
    }
}
