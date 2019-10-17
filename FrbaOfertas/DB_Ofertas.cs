using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;


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

        public static bool altaCliente(String usuario, String contra, String nombre, String apellido, String mail, String telefono, DateTime fechaNac,
                                        String calle, String piso, String dpto, String localidad, String cp, String dni)
        {

            setCmd("select count(username) from Usuarios where username = '" + usuario + "'");
            reader = cmd.ExecuteReader();
            reader.Read();

            //chequeo existencia de nombre de usuario
            if (reader.GetInt32(0) != 0)
            {
                MessageBox.Show("Este usuario ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reader.Close();
                return false;
            }
            reader.Close();



            // chequeo unicidad de mail
            setCmd("select count(mail) from Clientes where mail= '" + mail + "'");
            reader = cmd.ExecuteReader();
            reader.Read();
            int cantidadMailCliente = reader.GetInt32(0);
            reader.Close();

            setCmd("select count(mail) from Proveedores where mail= '" + mail + "'");
            reader = cmd.ExecuteReader();
            reader.Read();
            int cantidadMailProveedor = reader.GetInt32(0);
            reader.Close();

            if (cantidadMailCliente != 0 || cantidadMailProveedor != 0)
            {
                MessageBox.Show("Este email ya se encuentra registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // chequeo unicidad dni
            setCmd("select count(dni) from Clientes where dni = '" + dni + "'");
            reader = cmd.ExecuteReader();
            reader.Read();
            int cantidadDniCliente = reader.GetInt32(0);
            reader.Close();

            if (cantidadDniCliente != 0)
            {
                MessageBox.Show("Ya hay un cliente asociado a este Dni. Contacte con un adminsitrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            setCmd("insert into Usuarios (username,password,habilitado)" +
                   "values ('"+usuario+"','"+contra+"',1)");
            cmd.ExecuteNonQuery();

            setCmd("select id_ciudad from Ciudades where nombre = '"+ localidad +"'");
            reader = cmd.ExecuteReader();
            reader.Read();
            int idLocalidad = reader.GetInt32(0);
            reader.Close();

            setCmd("insert into Direcciones (direccion, cp, piso, dpto, ciudad)" +
                    "values ('" + calle + "','" + cp + "','" + piso + "','" + dpto + "'," + idLocalidad + ")");
            cmd.ExecuteNonQuery();

            setCmd("select id_direccion from Direcciones where direccion = '"+calle+"' and cp = "+cp+" and piso = "+piso+" and dpto = '"+dpto+"' and ciudad = '"+idLocalidad+"'");
            reader = cmd.ExecuteReader();
            reader.Read();
            int idDireccion = reader.GetInt32(0);
            reader.Close();

            setCmd("insert into Clientes (username,nombre,apellido,dni,mail,telefono,id_direccion,fecha_nac,credito,habilitado)" +
                "values ('"+ usuario +"','"+ nombre +"','"+ apellido +"',"+ dni +",'"+ mail +"',"+ telefono +","+ idDireccion +",'"+ fechaNac.ToShortDateString() +
                   "',200.00,1)");
            cmd.ExecuteNonQuery();

            return true;



        }
                                                
                                              
    }
}
