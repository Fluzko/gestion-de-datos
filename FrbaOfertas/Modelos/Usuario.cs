using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelos
{
    public class Usuario
    {
        private String username;

        public Usuario(String username){
            this.username = username;
        }

        public List<Rol> getRoles()
        {
            return DB_Ofertas.getRoles(this.username);
        }

        public String getUsername() { return this.username; }
    }
}
