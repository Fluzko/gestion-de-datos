using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    class DB_Ofertas
    {
        public static Modelos.Usuario login(String username, String password) {  }
        public static List<Modelos.Rol> getRoles(String usuario) { }
        public static List<Modelos.Funcionalidad> getFuncionalidades(String rol) { }
        public static bool altaCliente( String nombre, String apellido, String mail, int telefono, DateTime fechaNac,
                                    String calle, int piso, String dpto, String localidad, int cp, int dni){}
                                                
                                              
    }
}
