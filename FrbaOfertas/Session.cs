using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    class Session
    {
        private static Modelos.Usuario user = null;
        private static Modelos.Rol rol = null;


        public static void setSession(Modelos.Usuario u, Modelos.Rol r)
        {
            user = u;
            rol = r;
        }

        public static Modelos.Usuario getUser() { return user; }
        public static Modelos.Rol getRol() { return rol; }

        public static bool isNull()
        {
            if(user == null && rol == null)
                return true;
            else 
                return false;
        
        }
    }
}
