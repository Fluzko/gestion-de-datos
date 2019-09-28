using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelos
{
    class Usuario
    {
        private String username;
        private String password;

        public List<Rol> getRoles()
        {
            return DB_Ofertas.getRoles(this.username);
        }

        public String getUsername() { return this.username; }
    }
}
