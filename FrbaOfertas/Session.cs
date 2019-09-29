using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    class Session
    {
        Modelos.Usuario user;
        Modelos.Rol rol;

        public Session(Modelos.Usuario user, Modelos.Rol rol) {
            this.user = user;
            this.rol = rol;
        }

        public Modelos.Usuario getUser() { return this.user; }
        public Modelos.Rol getRol() { return this.rol; }
    }
}
