using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelos
{
    public class Funcionalidad
    {
        int id_funcionalidad;
        String funcionalidad;
        String pantalla;

        public Funcionalidad(int id, String funcionalidad){
            id_funcionalidad = id;
            this.funcionalidad = funcionalidad;
        }

        public String getFuncionalidad() { return this.funcionalidad; }

        public void changeView() {
           
        }
    }
}
