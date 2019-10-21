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
            cmd = new SqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
        }

        public static void newsetCmd(String query)
        {
            cmd = new SqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
        }


        public static Modelos.Usuario login(String username, String password) {
            
            setCmd("SELECT username, password from Usuarios WHERE username = @username AND password = @password AND habilitado = 1");
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            
            
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
            
            setCmd("SELECT r.id_rol, r.nombre from Roles r JOIN Rol_Usuario ru ON ru.id_rol = r.id_rol WHERE ru.username = @usuario and r.habilitado = 1");

            cmd.Parameters.AddWithValue("@usuario", usuario);

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
            
            setCmd("SELECT f.id_func,f.nombre, f.descripcion FROM Funcionalidades f JOIN Rol_Funcionalidad rf ON rf.id_func = f.id_func WHERE rf.id_rol = @rol AND habilitado = 1 ");

            cmd.Parameters.AddWithValue("@rol", id_rol);

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

        public static bool altaCliente(String username, String contra, String nombre, String apellido, String mail, String telefono, DateTime fechaNac,
                                        String calle, String piso, String dpto, String localidad, String cp, String dni)
        {

            setCmd("select count(username) from Usuarios where username = @username");

            cmd.Parameters.AddWithValue("@username", username);

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
            setCmd("select count(mail) from Clientes where mail = @mail");

            cmd.Parameters.AddWithValue("@mail", mail);

            reader = cmd.ExecuteReader();
            reader.Read();
            int cantidadMailCliente = reader.GetInt32(0);
            reader.Close();

            setCmd("select count(mail) from Proveedores where mail= '" + mail + "'");

            cmd.Parameters.AddWithValue("@mail", mail);


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
            setCmd("select count(dni) from Clientes where dni = @dni");

            cmd.Parameters.AddWithValue("@dni", dni);

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
                   "values (@username, @password, 1)");

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", contra);

            cmd.ExecuteNonQuery();

            setCmd("select id_ciudad from Ciudades where nombre = @localidad");

            cmd.Parameters.AddWithValue("@localidad", localidad);
            reader = cmd.ExecuteReader();
            reader.Read();
            int idLocalidad = reader.GetInt32(0);
            reader.Close();

            setCmd("insert into Direcciones (direccion, cp, piso, dpto, ciudad)" +
                    "values (@calle, @cp, @piso, @dpto, @idLocalidad)");

            cmd.Parameters.AddWithValue("@calle", calle);
            cmd.Parameters.AddWithValue("@cp", cp);
            cmd.Parameters.AddWithValue("@piso", piso);
            cmd.Parameters.AddWithValue("@dpto", dpto);
            cmd.Parameters.AddWithValue("@idLocalidad", idLocalidad);
            cmd.ExecuteNonQuery();

            setCmd("select id_direccion from Direcciones where direccion = @calle and cp = @cp and piso = @piso and dpto = @dpto and ciudad = @idLocalidad");

            cmd.Parameters.AddWithValue("@calle", calle);
            cmd.Parameters.AddWithValue("@cp", cp);
            cmd.Parameters.AddWithValue("@piso", piso);
            cmd.Parameters.AddWithValue("@dpto", dpto);
            cmd.Parameters.AddWithValue("@idLocalidad", idLocalidad);

            reader = cmd.ExecuteReader();
            reader.Read();
            int idDireccion = reader.GetInt32(0);
            reader.Close();

            setCmd("insert into Clientes (username,nombre,apellido,dni,mail,telefono,id_direccion,fecha_nac,credito,habilitado)" +
                "values (@username, @nombre, @apellido, @dni, @mail, @telefono, @idDireccion, @fechaNac,200.00,1)");

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.Parameters.AddWithValue("@mail", mail);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@idDireccion", idDireccion);
            cmd.Parameters.AddWithValue("@fechaNac", fechaNac);

            cmd.ExecuteNonQuery();

            return true;
        }

        public static List<Modelos.Cliente> getClientes()
        {
            List<Modelos.Cliente> clientes = null;

            setCmd("SELECT c.username, c.nombre, c.apellido, c.dni, c.mail, c.telefono, d.direccion, d.cp, d.piso, d.dpto, ci.nombre, c.fecha_nac, c.credito, c.habilitado " +
                   "FROM Clientes c " +
                   "JOIN Direcciones d ON c.id_direccion = d.id_direccion "+
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
                    cliente.Cp = reader.GetString(7);
                    cliente.Piso = reader.GetString(8);
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
                    "c.nombre LIKE '%@nombre%' AND "+
                    "c.apellido LIKE '%@apellido%' AND "+
                    "c.mail LIKE '%@mail%'");

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@mail", mail);
            
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
                cliente.Cp = reader.GetString(7);
                cliente.Piso = reader.GetString(8);
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
                    "c.nombre LIKE '%@nombre%' AND " +
                    "c.apellido LIKE '%@apellido%' AND " +
                    "c.mail LIKE '%@mail%' AND "+
                    "c.dni = @dni");

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@mail", mail);
            cmd.Parameters.AddWithValue("@dni", dni);

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
                cliente.Cp = reader.GetString(7);
                cliente.Piso = reader.GetString(8);
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

                setCmd("UPDATE Clientes SET "+
                                     "nombre = @nombre, "+
                                     "apellido = @apellido, "+
                                     "dni = @dni, "+
                                     "mail = @mail, "+
                                     "telefono = @telefono, "+
                                     "fecha_nac = @fechanac, "+
                                     "credito = @credito, "+
                                     "habilitado = @habilitado "+
                                     "WHERE username = @username");

                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@apellido",cliente.Apellido);
                cmd.Parameters.AddWithValue("@dni",cliente.Dni);
                cmd.Parameters.AddWithValue("@mail",cliente.Mail);
                cmd.Parameters.AddWithValue("@telefono",cliente.Telefono);
                cmd.Parameters.AddWithValue("@fechanac",cliente.FechaNac);
                cmd.Parameters.AddWithValue("@credito",cliente.Credito);
                cmd.Parameters.AddWithValue("@habilitado",cliente.habilitado);
                cmd.Parameters.AddWithValue("@username",cliente.Username);

                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
   
                if (cmd.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("Ocurrio un error al actualizar los datos", "Actualizar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Cliente actualizado con exito", "Actualizar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }          
        
        public static List<Modelos.Proveedor> getProveedoresFacturacion()
        {
            setCmd("SELECT username, razon_social FROM Proveedores WHERE habilitado = 1 ORDER BY 2");

            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                MessageBox.Show("No hay ningun proveedor habilitado en el sistema", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                reader.Close();
                return null;
            }

            List<Modelos.Proveedor> proveedores = new List<Modelos.Proveedor>();
            
            while(reader.Read()){
                Modelos.Proveedor proveedor = new Modelos.Proveedor();
                
                proveedor.username = reader.GetString(0);
                proveedor.razonSocial = reader.GetString(1);

                proveedores.Add(proveedor);
            }

            reader.Close();
            return proveedores;
        }


        public static List<Modelos.Cupon> getCupones(String proveedor, DateTime desde, DateTime hasta)
        {
            setCmd("SELECT c.id_cupon, c.username, o.descripcion, c.fecha_compra "+
                    "FROM Cupones c "+
                    "JOIN Ofertas o ON o.id_oferta = c.id_oferta "+
                    "WHERE c.facturado = 0 "+ 
                    "AND o.username = @proveedor "+
                    "AND c.fecha_compra >= @desde "+
                    "AND c.fecha_compra <= @hasta "+
                    "ORDER BY c.fecha_compra ASC");

            cmd.Parameters.AddWithValue("@proveedor", proveedor);
            cmd.Parameters.AddWithValue("@desde", desde);
            cmd.Parameters.AddWithValue("@hasta", hasta);

            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }


            List<Modelos.Cupon> cupones = new List<Modelos.Cupon>();

            while (reader.Read())
            {
                Modelos.Cupon cupon = new Modelos.Cupon();
                
                cupon.NumeroCupon = reader.GetInt32(0);
                cupon.cliente = reader.GetString(1);
                cupon.oferta = reader.GetString(2);
                cupon.fechaCompra = reader.GetDateTime(3);

                cupones.Add(cupon);
            }

            reader.Close();
            return cupones;
        }

        public static Modelos.Factura facturarCupones(Modelos.Proveedor proveedor, DateTime desde, DateTime hasta)
        {
            setCmd("INSERT INTO Facturas (username, fecha) " +
                        "VALUES (@idProveedor, @fechaActual)");

            cmd.Parameters.AddWithValue("@idProveedor", proveedor.username);
            cmd.Parameters.AddWithValue("@fechaActual", DateTime.Today);

            cmd.ExecuteNonQuery();


            setCmd("SELECT TOP 1 id_factura FROM Facturas ORDER BY 1 DESC");
            reader = cmd.ExecuteReader();
            reader.Read();
            int idFactura = reader.GetInt32(0);
            reader.Close();


            setCmd( "INSERT INTO Renglones (id_factura, id_oferta, cant) "+
                        "SELECT	@idFactura,o.id_oferta,count(cu.id_cupon) "+
                        "FROM Ofertas o "+
                        "JOIN Cupones cu ON cu.id_oferta = o.id_oferta "+
                        "WHERE o.username = @proveedor "+
                        "AND o.fecha_pub >= @desde "+
                        "AND o.fecha_pub <= @hasta "+
                        "GROUP BY o.id_oferta, o.username "+
                        "ORDER BY 1");

            cmd.Parameters.AddWithValue("@idFactura", idFactura);
            cmd.Parameters.AddWithValue("@proveedor", proveedor.username);
            cmd.Parameters.AddWithValue("@desde", desde);
            cmd.Parameters.AddWithValue("@hasta", hasta);

            cmd.ExecuteNonQuery();

            setCmd("UPDATE Cupones SET facturado = 1 "+
                    "FROM ( SELECT c.id_cupon as id "+
                            "FROM Cupones c "+
                            "JOIN Ofertas o ON o.id_oferta = c.id_oferta "+
                            "WHERE c.facturado = 0 "+ 
                            "AND o.username = @proveedor "+
                            "AND c.fecha_compra >= @desde "+
                            "AND c.fecha_compra <= @hasta ) as facturados "+
                            "WHERE facturados.id = Cupones.id_cupon ");
            cmd.Parameters.AddWithValue("@proveedor", proveedor.username);
            cmd.Parameters.AddWithValue("@desde", desde);
            cmd.Parameters.AddWithValue("@hasta", hasta);

            cmd.ExecuteNonQuery();


            setCmd("SELECT SUM((r.cant * o.precio_rebajado)*0.1) FROM Renglones r "+
                    "JOIN Ofertas o ON r.id_oferta = o.id_oferta "+
                    "WHERE r.id_factura = @idFactura");
            cmd.Parameters.AddWithValue("@idFactura", idFactura);

            reader = cmd.ExecuteReader();
            
            Decimal monto = 0; 
            if (reader.HasRows)
            {
                reader.Read();
                monto = reader.GetDecimal(0);
            }
            reader.Close();

            
            setCmd("UPDATE Facturas SET monto = @monto WHERE id_factura = @idFactura");
            cmd.Parameters.AddWithValue("@idFactura", idFactura);
            cmd.Parameters.AddWithValue("@monto", monto);

            cmd.ExecuteNonQuery();


            Modelos.Factura factura = new Modelos.Factura();
            factura.numero = idFactura;
            factura.monto = monto;

            return factura;
        }

    }
}
