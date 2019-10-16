using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    class DB_Ofertas
    {
        private static SqlConnection connection = new ConectorDB().conection;
        private static SqlCommand cmd = new SqlCommand();
        private static SqlDataReader reader;

        public static void setCmd(String query)
        {
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
        }


        public static Modelos.Usuario login(String username, String password) {
            
            setCmd("SELECT username, password from Usuarios WHERE username = '" + username + "' AND password = '" + password + "' AND habilitado = 1");
            //password = hashbytes('SHA2_256', '" + password + "')
            reader = cmd.ExecuteReader();
            
            if (reader.HasRows)
            {
                reader.Read();
                Modelos.Usuario usuario = new Modelos.Usuario(reader.GetString(0));
                reader.Close();
                return usuario;
            }
            else
            {
                reader.Close();
                return null;
            }
        }


        public static List<Modelos.Rol> getRoles(String usuario) {
            
            setCmd("SELECT r.id_rol, r.nombre from Roles r JOIN Rol_Usuario ru ON ru.id_rol = r.id_rol WHERE ru.username = '"+ usuario +"' and r.habilitado = 1");

            reader = cmd.ExecuteReader();

            List<Modelos.Rol> roles = new List<Modelos.Rol>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Modelos.Rol rol = new Modelos.Rol(reader.GetInt32(0), reader.GetString(1));
                    roles.Add(rol);
                }
                reader.Close();
                return roles;   
            }
            else
            {
                reader.Close();
                return null;
            }
        }


        public static List<Modelos.Funcionalidad> getFuncionalidades(int id_rol) {
            
            setCmd("SELECT f.id_func,f.nombre, f.descripcion FROM Funcionalidades f JOIN Rol_Funcionalidad rf ON rf.id_func = f.id_func WHERE rf.id_rol =" + id_rol + " AND habilitado = 1 ");

            reader = cmd.ExecuteReader();

            List<Modelos.Funcionalidad> funcionalidades = new List<Modelos.Funcionalidad>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    funcionalidades.Add(new Modelos.Funcionalidad(reader.GetInt32(0),reader.GetString(1)));
                }
                reader.Close();
                return funcionalidades;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
    //    public static bool altaCliente( String nombre, String apellido, String mail, int telefono, DateTime fechaNac,
      //                              String calle, int piso, String dpto, String localidad, int cp, int dni){
      
        //}
                                                
                                              
    }
}
