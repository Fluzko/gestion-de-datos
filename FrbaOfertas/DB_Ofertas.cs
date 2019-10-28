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

        public static List<Modelos.Cliente> getClientes()
        {
            List<Modelos.Cliente> clientes = null;

            setCmd("SELECT c.username, c.nombre, c.apellido, c.dni, c.mail, c.telefono, d.direccion, d.cp, d.piso, d.dpto, ci.nombre, c.fecha_nac, c.credito, c.habilitado " +
                   "FROM Clientes c " +
                   "JOIN Direcciones d ON c.id_direccion = d.id_direccion " +
                   "JOIN Ciudades ci ON ci.id_ciudad = d.ciudad ");
            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return clientes;
            }

            clientes = new List<Modelos.Cliente>();

            while (reader.Read())
            {
                Modelos.Cliente cliente = new Modelos.Cliente();
                cliente.Username = reader.GetString(0);
                cliente.Nombre = reader.GetString(1);
                cliente.Apellido = reader.GetString(2);
                cliente.Dni = reader.GetInt32(3);
                cliente.Mail = reader.GetString(4);
                cliente.Telefono = reader.GetInt32(5);
                cliente.Direccion = reader.GetString(6);
                cliente.Cp = reader.GetInt32(7);
                cliente.Piso = reader.GetInt32(8);
                cliente.Dpto = reader.GetString(9);
                cliente.Localidad = reader.GetString(10);
                cliente.FechaNac = reader.GetDateTime(11);
                cliente.Credito = reader.GetDecimal(12);
                cliente.habilitado = reader.GetBoolean(13);

                clientes.Add(cliente);
            }

            reader.Close();
            return clientes;
        }

        public static List<Modelos.Cliente> getClientes(String nombre, String apellido, String mail)
        {
            List<Modelos.Cliente> clientes = null;

            setCmd("SELECT c.username, c.nombre, c.apellido, c.dni, c.mail, c.telefono, d.direccion, d.cp, d.piso, d.dpto, ci.nombre, c.fecha_nac, c.credito, c.habilitado " +
                    "FROM Clientes c " +
                    "JOIN Direcciones d ON c.id_direccion = d.id_direccion " +
                    "JOIN Ciudades ci ON ci.id_ciudad = d.ciudad " +
                    "WHERE "+ 
                    "c.nombre LIKE '%"+ nombre +"%' AND "+
                    "c.apellido LIKE '%"+ apellido +"%' AND "+
                    "c.mail LIKE '%"+ mail +"%'");
            
            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return clientes;
            }

            clientes = new List<Modelos.Cliente>();

            while (reader.Read())
            {
                Modelos.Cliente cliente = new Modelos.Cliente();
                cliente.Username = reader.GetString(0);
                cliente.Nombre = reader.GetString(1);
                cliente.Apellido = reader.GetString(2);
                cliente.Dni = reader.GetInt32(3);
                cliente.Mail = reader.GetString(4);
                cliente.Telefono = reader.GetInt32(5);
                cliente.Direccion = reader.GetString(6);
                cliente.Cp = reader.GetInt32(7);
                cliente.Piso = reader.GetInt32(8);
                cliente.Dpto = reader.GetString(9);
                cliente.Localidad = reader.GetString(10);
                cliente.FechaNac = reader.GetDateTime(11);
                cliente.Credito = reader.GetDecimal(12);
                cliente.habilitado = reader.GetBoolean(13);

                clientes.Add(cliente);
            }

            reader.Close();
            return clientes;
        }

        public static List<Modelos.Cliente> getClientes(String nombre, String apellido, String mail, String dni)
        {
            List<Modelos.Cliente> clientes = null;

            setCmd("SELECT c.username, c.nombre, c.apellido, c.dni, c.mail, c.telefono, d.direccion, d.cp, d.piso, d.dpto, ci.nombre, c.fecha_nac, c.credito, c.habilitado " +
                    "FROM Clientes c " +
                    "JOIN Direcciones d ON c.id_direccion = d.id_direccion " +
                    "JOIN Ciudades ci ON ci.id_ciudad = d.ciudad " +
                    "WHERE " +
                    "c.nombre LIKE '%" + nombre + "%' AND " +
                    "c.apellido LIKE '%" + apellido + "%' AND " +
                    "c.mail LIKE '%" + mail + "%' AND "+
                    "c.dni = "+ dni);

            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return clientes;
            }

            clientes = new List<Modelos.Cliente>();

            while (reader.Read())
            {
                Modelos.Cliente cliente = new Modelos.Cliente();
                cliente.Username = reader.GetString(0);
                cliente.Nombre = reader.GetString(1);
                cliente.Apellido = reader.GetString(2);
                cliente.Dni = reader.GetInt32(3);
                cliente.Mail = reader.GetString(4);
                cliente.Telefono = reader.GetInt32(5);
                cliente.Direccion = reader.GetString(6);
                cliente.Cp = reader.GetInt32(7);
                cliente.Piso = reader.GetInt32(8);
                cliente.Dpto = reader.GetString(9);
                cliente.Localidad = reader.GetString(10);
                cliente.FechaNac = reader.GetDateTime(11);
                cliente.Credito = reader.GetDecimal(12);
                cliente.habilitado = reader.GetBoolean(13);

                clientes.Add(cliente);
            }

            reader.Close();
            return clientes;
        }  
     
        public static void updateCliente(Modelos.Cliente cliente){
            setCmd("UPDATE Clientes SET" + 
                    " nombre = '" + cliente.Nombre +"',"+
                    " apellido  = '" + cliente.Apellido +"',"+ 
                    " dni = " + cliente.Dni + ","+
                    " mail  = '" + cliente.Mail +"',"+
                    " telefono = " + cliente.Telefono + ","+
                    " fecha_nac = '" + cliente.FechaNac.ToShortDateString() + "', " +
                    " credito = " + cliente.Credito + ", "+
                    " habilitado  = '" + cliente.habilitado.ToString() + "'" +
                    " WHERE username = '" + cliente.Username +"'");

                
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("Ocurrio un error al actualizar los datos", "Actualizar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Cliente actualizado con exito", "Actualizar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
    

        }

        public static List<Modelos.Oferta> getOfertas()
        {
            List<Modelos.Oferta> ofertas = null;

            setCmd("SELECT o.id_oferta, p.razon_social, o.descripcion, o.fecha_pub, o.fecha_vec, o.precio_rebajado, o.max_cliente " +
                    "FROM Ofertas o " +
                    "JOIN Proveedores p ON p.username = o.username");
            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return ofertas;
            }

            ofertas = new List<Modelos.Oferta>();

            while (reader.Read())
            {
                Modelos.Oferta oferta = new Modelos.Oferta();
                oferta.Id = reader.GetInt32(0);
                oferta.Proveedor = reader.GetString(1);
                oferta.Descripcion = reader.GetString(2);
                oferta.FechaPublicacion = reader.GetDateTime(3).Date;
                oferta.FechaVencimiento = reader.GetDateTime(4).Date;
                oferta.Precio = reader.GetDecimal(5);
                oferta.MaxPorCliente = reader.GetInt32(6);

                ofertas.Add(oferta);
            }

            reader.Close();
            return ofertas;
        }

        public static List<Modelos.Oferta> getOfertasWithCondition(String raz_soc, String desc, String precioMin, String precioMax)
        {
            List<Modelos.Oferta> ofertas = null;

            String conditions = "";

            if (!string.IsNullOrEmpty(raz_soc) && !string.IsNullOrWhiteSpace(raz_soc))
            {
                if (conditions.Length > 0)
                    conditions += " AND ";
                conditions += "p.razon_social LIKE '%" + raz_soc + "%'";
            }

            if (!string.IsNullOrEmpty(desc) && !string.IsNullOrWhiteSpace(desc))
            {
                if (conditions.Length > 0)
                    conditions += " AND ";
                conditions += "o.descripcion LIKE '%" + desc + "%'";
            }

            if (!string.IsNullOrEmpty(precioMin) && !string.IsNullOrWhiteSpace(precioMin))
            {
                if (conditions.Length > 0)
                    conditions += " AND ";
                conditions += "o.precio_rebajado >= " + precioMin;
            }

            if (!string.IsNullOrEmpty(precioMax) && !string.IsNullOrWhiteSpace(precioMax))
            {
                if (conditions.Length > 0)
                    conditions += " AND ";
                conditions += "o.precio_rebajado <= " + precioMax;
            }

            setCmd("SELECT o.id_oferta, p.razon_social, o.descripcion, o.fecha_pub, o.fecha_vec, o.precio_rebajado, o.max_cliente " +
                    "FROM Ofertas o " +
                    "JOIN Proveedores p ON p.username = o.username " +
                    "WHERE " + conditions);
            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return ofertas;
            }

            ofertas = new List<Modelos.Oferta>();

            while (reader.Read())
            {
                Modelos.Oferta oferta = new Modelos.Oferta();
                oferta.Id = reader.GetInt32(0);
                oferta.Proveedor = reader.GetString(1);
                oferta.Descripcion = reader.GetString(2);
                oferta.FechaPublicacion = reader.GetDateTime(3).Date;
                oferta.FechaVencimiento = reader.GetDateTime(4).Date;
                oferta.Precio = reader.GetDecimal(5);
                oferta.MaxPorCliente = reader.GetInt32(6);

                ofertas.Add(oferta);
            }

            reader.Close();
            return ofertas;
        }

        public static void comprarOferta(Modelos.Usuario usuario, Modelos.Oferta oferta, int cant)
        {
            String query = "BEGIN TRANSACTION ";

            for(int i = 0; i < cant; i++)
            {
                query +=    "INSERT INTO Cupones (username, id_oferta, fecha_compra) " +
                            "VALUES(@username, @oferta, CAST(@fecha AS DATETIME)) ";
            }

            query += "COMMIT";

            setCmd(query);
            cmd.Parameters.AddWithValue("@username", usuario.getUsername());
            cmd.Parameters.AddWithValue("@oferta", oferta.Id);
            cmd.Parameters.AddWithValue("@fecha", DateTime.Now);

            try
            {
                reader = cmd.ExecuteReader();
                reader.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Comprar Ofertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return;
        }
    }
}
