using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    class Session
    {
        private static Modelos.Usuario user;
        private static Modelos.Rol rol;


        public static void setSession(Modelos.Usuario u, Modelos.Rol r)
        {
            user = u;
            rol = r;
        }

        public static Modelos.Usuario getUser() { return user; }
        public static Modelos.Rol getRol() { return rol; }
    }
}
