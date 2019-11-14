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
        public Boolean habilitado { get; set; }

        public Usuario(String username, Boolean habilitado)
        {
            this.username = username;
            this.habilitado = habilitado;
        }

        public List<Rol> getRoles()
        {
            return DB_Ofertas.getRoles(this.username);
        }

        public String getUsername() { return this.username; }
    }
}
