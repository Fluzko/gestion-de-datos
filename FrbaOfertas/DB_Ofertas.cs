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
            cmd.CommandText = query;
            //cmd = new SqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
        }


        public static Modelos.Usuario login(String username, String password)
        {

            setCmd("SELECT username, password from LOS_SINEQUI.Usuarios WHERE username = @username AND password = @password AND habilitado = 1");
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", Hash.GetHash(password));


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


        public static List<Modelos.Rol> getRoles(String usuario)
        {

            setCmd("SELECT r.id_rol, r.nombre from LOS_SINEQUI.Roles r JOIN LOS_SINEQUI.Rol_Usuario ru ON ru.id_rol = r.id_rol WHERE ru.username = @usuario and r.habilitado = 1");

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


        public static List<Modelos.Funcionalidad> getFuncionalidades(int id_rol)
        {

            setCmd("SELECT f.id_func,f.nombre, f.descripcion FROM LOS_SINEQUI.Funcionalidades f JOIN LOS_SINEQUI.Rol_Funcionalidad rf ON rf.id_func = f.id_func WHERE rf.id_rol = @rol AND habilitado = 1 ");

            cmd.Parameters.AddWithValue("@rol", id_rol);

            reader = cmd.ExecuteReader();

            List<Modelos.Funcionalidad> funcionalidades = new List<Modelos.Funcionalidad>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    funcionalidades.Add(new Modelos.Funcionalidad(reader.GetInt32(0), reader.GetString(1)));
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

            setCmd("select count(username) from LOS_SINEQUI.Usuarios where username = @username");

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
            setCmd("select count(mail) from LOS_SINEQUI.Clientes where mail = @mail");

            cmd.Parameters.AddWithValue("@mail", mail);

            reader = cmd.ExecuteReader();
            reader.Read();
            int cantidadMailCliente = reader.GetInt32(0);
            reader.Close();

            setCmd("select count(mail) from LOS_SINEQUI.Proveedores where mail= '" + mail + "'");

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
            setCmd("select count(dni) from LOS_SINEQUI.Clientes where dni = @dni");

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


            setCmd("insert into LOS_SINEQUI.Usuarios (username,password,habilitado)" +
                   "values (@username, @password, 1)");

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", Hash.GetHash(contra));

            cmd.ExecuteNonQuery();


            setCmd("insert into LOS_SINEQUI.Direcciones (direccion, cp, piso, dpto, localidad)" +
                    "values (@calle, @cp, @piso, @dpto, @localidad)");

            cmd.Parameters.AddWithValue("@calle", calle);
            cmd.Parameters.AddWithValue("@cp", cp);
            cmd.Parameters.AddWithValue("@piso", piso);
            cmd.Parameters.AddWithValue("@dpto", dpto);
            cmd.Parameters.AddWithValue("@localidad", localidad);
            cmd.ExecuteNonQuery();

            setCmd("select id_direccion from LOS_SINEQUI.Direcciones where direccion = @calle and cp = @cp and piso = @piso and dpto = @dpto and localidad = @localidad");

            cmd.Parameters.AddWithValue("@calle", calle);
            cmd.Parameters.AddWithValue("@cp", cp);
            cmd.Parameters.AddWithValue("@piso", piso);
            cmd.Parameters.AddWithValue("@dpto", dpto);
            cmd.Parameters.AddWithValue("@localidad", localidad);

            reader = cmd.ExecuteReader();
            reader.Read();
            int idDireccion = reader.GetInt32(0);
            reader.Close();

            setCmd("insert into LOS_SINEQUI.Clientes (username,nombre,apellido,dni,mail,telefono,id_direccion,fecha_nac,credito,habilitado)" +
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

        /////////////////////////////////// CLIENTES ///////////////////////////////////

        public static List<Modelos.Cliente> getClientes()
        {
            List<Modelos.Cliente> clientes = null;

            setCmd("SELECT c.username, c.nombre, c.apellido, c.dni, c.mail, c.telefono, d.direccion, d.cp, d.piso, d.dpto, d.localidad, c.fecha_nac, c.credito, c.habilitado " +
                   "FROM LOS_SINEQUI.Clientes c " +
                   "JOIN LOS_SINEQUI.Direcciones d ON c.id_direccion = d.id_direccion ");
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

            setCmd("SELECT c.username, c.nombre, c.apellido, c.dni, c.mail, c.telefono, d.direccion, d.cp, d.piso, d.dpto, d.localidad, c.fecha_nac, c.credito, c.habilitado " +
                    "FROM LOS_SINEQUI..Clientes c " +
                    "JOIN LOS_SINEQUI..Direcciones d ON c.id_direccion = d.id_direccion " +
                    "WHERE " +
                    "c.nombre LIKE @nombre  AND " +
                    "c.apellido LIKE @apellido AND " +
                    "c.mail LIKE @mail");

            cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
            cmd.Parameters.AddWithValue("@apellido", "%" + apellido + "%");
            cmd.Parameters.AddWithValue("@mail", "%" + mail + "%");

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

            setCmd("SELECT c.username, c.nombre, c.apellido, c.dni, c.mail, c.telefono, d.direccion, d.cp, d.piso, d.dpto, d.localidad, c.fecha_nac, c.credito, c.habilitado " +
                    "FROM LOS_SINEQUI.Clientes c " +
                    "JOIN LOS_SINEQUI.Direcciones d ON c.id_direccion = d.id_direccion " +
                    "WHERE " +
                    "c.nombre LIKE @nombre AND " +
                    "c.apellido LIKE  @apellido AND " +
                    "c.mail LIKE @mail AND " +
                    "c.dni = @dni");

            cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
            cmd.Parameters.AddWithValue("@apellido", "%" + apellido + "%");
            cmd.Parameters.AddWithValue("@mail", "%" + mail + "%");
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

        /////////////////////////////////// OFERTAS ///////////////////////////////////

        public static List<Modelos.Oferta> getOfertas()
        {
            List<Modelos.Oferta> ofertas = null;

            setCmd("SELECT o.id_oferta, p.razon_social, o.descripcion, o.fecha_pub, o.fecha_vec, o.precio_rebajado, o.max_cliente, o.stock " +
                    "FROM LOS_SINEQUI.Ofertas o " +
                    "JOIN LOS_SINEQUI.Proveedores p ON p.username = o.username");
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
                oferta.CantDisponible = reader.GetInt32(7);

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
                conditions += "p.razon_social LIKE @raz_soc";
            }

            if (!string.IsNullOrEmpty(desc) && !string.IsNullOrWhiteSpace(desc))
            {
                if (conditions.Length > 0)
                    conditions += " AND ";
                conditions += "o.descripcion LIKE @desc";
            }

            if (!string.IsNullOrEmpty(precioMin) && !string.IsNullOrWhiteSpace(precioMin))
            {
                if (conditions.Length > 0)
                    conditions += " AND ";
                conditions += "o.precio_rebajado >= @precio_min";
            }

            if (!string.IsNullOrEmpty(precioMax) && !string.IsNullOrWhiteSpace(precioMax))
            {
                if (conditions.Length > 0)
                    conditions += " AND ";
                conditions += "o.precio_rebajado <= @precio_max";
            }

            setCmd("SELECT o.id_oferta, p.razon_social, o.descripcion, o.fecha_pub, o.fecha_vec, o.precio_rebajado, o.max_cliente, o.stock " +
                    "FROM LOS_SINEQUI.Ofertas o " +
                    "JOIN LOS_SINEQUI.Proveedores p ON p.username = o.username " +
                    "WHERE " + conditions);

            cmd.Parameters.AddWithValue("@raz_soc", "%" + raz_soc + "%");
            cmd.Parameters.AddWithValue("@desc", "%" + desc + "%");
            cmd.Parameters.AddWithValue("@precio_min", precioMin);
            cmd.Parameters.AddWithValue("@precio_max", precioMax);

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
                oferta.CantDisponible = reader.GetInt32(7);

                ofertas.Add(oferta);
            }

            reader.Close();
            return ofertas;
        }

        public static void comprarOferta(Modelos.Usuario usuario, Modelos.Oferta oferta, int cant, DateTime fecha)
        {
            String query = "BEGIN TRANSACTION ";

            for (int i = 0; i < cant; i++)
            {
                query += "INSERT INTO LOS_SINEQUI.Cupones (username, id_oferta, fecha_compra) " +
                            "VALUES(@username, @oferta, @fecha) ";
            }

            query += "IF @@ERROR = 0 COMMIT ELSE ROLLBACK";

            setCmd(query);

            cmd.Parameters.AddWithValue("@username", usuario.getUsername());
            cmd.Parameters.AddWithValue("@oferta", oferta.Id);
            cmd.Parameters.AddWithValue("@fecha", fecha);

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

        /////////////////////////////////// CUPONES ///////////////////////////////////
        public static List<Modelos.Cupon> getCupones(String proveedor)
        {
            List<Modelos.Cupon> cupones = null;

            setCmd("SELECT c.id_cupon, c.username, c.id_oferta, o.descripcion, c.fecha_compra, cl.nombre, cl.apellido " +
                    "FROM LOS_SINEQUI.Cupones c " +
                    "JOIN LOS_SINEQUI.Ofertas o ON o.id_oferta = c.id_oferta " +
                    "JOIN LOS_SINEQUI.Clientes cl ON cl.username = c.username " +
                    "WHERE o.username = @username AND c.fecha_entrega IS NULL ");
            cmd.Parameters.AddWithValue("username", proveedor);
            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return cupones;
            }

            cupones = new List<Modelos.Cupon>();

            while (reader.Read())
            {
                Modelos.Cupon cupon = new Modelos.Cupon();
                cupon.Id = reader.GetInt32(0);
                cupon.Cliente = reader.GetString(1);
                cupon.IdOferta = reader.GetInt32(2);
                cupon.DescripcionOferta = reader.GetString(3);
                cupon.FechaCompra = reader.GetDateTime(4).Date;
                cupon.ClienteNombre = reader.GetString(5);
                cupon.ClienteApellido = reader.GetString(6);

                cupones.Add(cupon);
            }

            reader.Close();
            return cupones;
        }

        public static List<Modelos.Cupon> getCuponesWithCondition(String proveedor, String cliente, String descripcion, String id_cupon, String id_oferta)
        {
            List<Modelos.Cupon> cupones = null;

            String conditions = "";

            if (!string.IsNullOrEmpty(cliente) && !string.IsNullOrWhiteSpace(cliente))
            {
                if (conditions.Length > 0)
                    conditions += " AND ";
                conditions += "(c.username LIKE @cliente OR cl.nombre LIKE @cliente OR cl.apellido LIKE @cliente)";
            }

            if (!string.IsNullOrEmpty(descripcion) && !string.IsNullOrWhiteSpace(descripcion))
            {
                if (conditions.Length > 0)
                    conditions += " AND ";
                conditions += "o.descripcion LIKE @descripcion";
            }

            if (!string.IsNullOrEmpty(id_cupon) && !string.IsNullOrWhiteSpace(id_cupon))
            {
                if (conditions.Length > 0)
                    conditions += " AND ";
                conditions += "c.id_cupon = @id_cupon";
            }

            if (!string.IsNullOrEmpty(id_oferta) && !string.IsNullOrWhiteSpace(id_oferta))
            {
                if (conditions.Length > 0)
                    conditions += " AND ";
                conditions += "c.id_oferta = @id_oferta";
            }

            setCmd("SELECT c.id_cupon, c.username, c.id_oferta, o.descripcion, c.fecha_compra, cl.nombre, cl.apellido " +
                    "FROM LOS_SINEQUI.Cupones c " +
                    "JOIN LOS_SINEQUI.Ofertas o ON o.id_oferta = c.id_oferta " +
                    "JOIN LOS_SINEQUI.Clientes cl ON cl.username = c.username " +
                    "WHERE o.username = @proveedor AND c.fecha_entrega IS NULL AND " + conditions);
            cmd.Parameters.AddWithValue("@proveedor", proveedor);
            if (!string.IsNullOrEmpty(cliente) && !string.IsNullOrWhiteSpace(cliente)) cmd.Parameters.AddWithValue("@cliente", "%" + cliente + "%");
            if (!string.IsNullOrEmpty(descripcion) && !string.IsNullOrWhiteSpace(descripcion)) cmd.Parameters.AddWithValue("@descripcion", "%" + descripcion + "%");
            if (!string.IsNullOrEmpty(id_cupon) && !string.IsNullOrWhiteSpace(id_cupon)) cmd.Parameters.AddWithValue("@id_cupon", Int32.Parse(id_cupon));
            if (!string.IsNullOrEmpty(id_oferta) && !string.IsNullOrWhiteSpace(id_oferta)) cmd.Parameters.AddWithValue("@id_oferta", Int32.Parse(id_oferta));

            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return cupones;
            }

            cupones = new List<Modelos.Cupon>();

            while (reader.Read())
            {
                Modelos.Cupon cupon = new Modelos.Cupon();
                cupon.Id = reader.GetInt32(0);
                cupon.Cliente = reader.GetString(1);
                cupon.IdOferta = reader.GetInt32(2);
                cupon.DescripcionOferta = reader.GetString(3);
                cupon.FechaCompra = reader.GetDateTime(4).Date;
                cupon.ClienteNombre = reader.GetString(5);
                cupon.ClienteApellido = reader.GetString(6);

                cupones.Add(cupon);
            }

            reader.Close();
            return cupones;
        }

        public static void consumirOferta(Modelos.Cupon cupon, DateTime fecha)
        {
            String query = "BEGIN TRANSACTION ";

            query += "UPDATE LOS_SINEQUI.Cupones SET fecha_entrega = @fecha " +
                        "WHERE id_cupon = @cupon ";

            query += "IF @@ERROR = 0 COMMIT ELSE ROLLBACK";

            setCmd(query);

            cmd.Parameters.AddWithValue("@fecha", fecha);
            cmd.Parameters.AddWithValue("@cupon", cupon.Id);

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

        /////////////////////////////////// CLIENTES ///////////////////////////////////

        public static bool dniExists(String dni)
        {
            setCmd("SELECT 1 FROM LOS_SINEQUI.Clientes c WHERE c.dni = @dni");
            cmd.Parameters.AddWithValue("@dni", dni);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }

        public static bool mailExists(String mail)
        {
            setCmd("SELECT 1 FROM LOS_SINEQUI.Clientes c WHERE c.mail = @mail");
            cmd.Parameters.AddWithValue("@mail", mail);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }

        public static void updateCliente(Modelos.Cliente cliente)
        {

            setCmd("SELECT id_direccion FROM LOS_SINEQUI.Clientes c WHERE  c.username = @username");
            cmd.Parameters.AddWithValue("@username", cliente.Username);

            reader = cmd.ExecuteReader();
            int idDireccion = -1;

            if (reader.HasRows)
            {
                reader.Read();
                idDireccion = reader.GetInt32(0);
                reader.Close();
            }


            setCmd("UPDATE LOS_SINEQUI.Clientes SET " +
                                    "nombre = @nombre, " +
                                    "apellido = @apellido, " +
                                    "dni = @dni, " +
                                    "mail = @mail, " +
                                    "telefono = @telefono, " +
                                    "fecha_nac = @fechanac, " +
                                    "credito = @credito, " +
                                    "habilitado = @habilitado " +
                                    "WHERE username = @username");

            cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
            cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
            cmd.Parameters.AddWithValue("@dni", cliente.Dni);
            cmd.Parameters.AddWithValue("@mail", cliente.Mail);
            cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
            cmd.Parameters.AddWithValue("@fechanac", cliente.FechaNac);
            cmd.Parameters.AddWithValue("@credito", cliente.Credito);
            cmd.Parameters.AddWithValue("@habilitado", cliente.habilitado);
            cmd.Parameters.AddWithValue("@username", cliente.Username);

            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("Ocurrio un error al actualizar los datos", "Actualizar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (idDireccion != -1)
            {
                setCmd("UPDATE LOS_SINEQUI.Direcciones SET " +
                    "direccion = @direccion, " +
                    "cp = @cp, " +
                    "piso = @piso, " +
                    "dpto = @dpto, " +
                    "localidad = @localidad " +
                    "WHERE id_direccion = @idDireccion");

                cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@cp", cliente.Cp);
                cmd.Parameters.AddWithValue("@piso", cliente.Piso);
                cmd.Parameters.AddWithValue("@dpto", cliente.Dpto);
                cmd.Parameters.AddWithValue("@localidad", cliente.Localidad);
                cmd.Parameters.AddWithValue("@idDireccion", idDireccion);

                cmd.ExecuteNonQuery();
            }


            MessageBox.Show("Cliente actualizado con exito", "Actualizar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        public static List<Modelos.Proveedor> getProveedoresFacturacion()
        {
            setCmd("SELECT username, razon_social FROM LOS_SINEQUI.Proveedores WHERE habilitado = 1 ORDER BY 2");

            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                MessageBox.Show("No hay ningun proveedor habilitado en el sistema", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                reader.Close();
                return null;
            }

            List<Modelos.Proveedor> proveedores = new List<Modelos.Proveedor>();

            while (reader.Read())
            {
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
            setCmd("SELECT c.id_cupon, c.username, o.descripcion, c.fecha_compra " +
                    "FROM LOS_SINEQUI.Cupones c " +
                    "JOIN LOS_SINEQUI.Ofertas o ON o.id_oferta = c.id_oferta " +
                    "WHERE c.facturado = 0 " +
                    "AND o.username = @proveedor " +
                    "AND c.fecha_compra >= @desde " +
                    "AND c.fecha_compra <= @hasta " +
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

                cupon.Id = reader.GetInt32(0);
                cupon.Cliente = reader.GetString(1);
                cupon.DescripcionOferta = reader.GetString(2);
                cupon.FechaCompra = reader.GetDateTime(3);

                cupones.Add(cupon);
            }

            reader.Close();
            return cupones;
        }

        public static Modelos.Factura facturarCupones(Modelos.Proveedor proveedor, DateTime desde, DateTime hasta)
        {
            setCmd("INSERT INTO LOS_SINEQUI.Facturas (username, fecha) " +
                        "VALUES (@idProveedor, @fechaActual)");

            cmd.Parameters.AddWithValue("@idProveedor", proveedor.username);
            cmd.Parameters.AddWithValue("@fechaActual", DateTime.Today);

            cmd.ExecuteNonQuery();


            setCmd("SELECT TOP 1 id_factura FROM LOS_SINEQUI.Facturas ORDER BY 1 DESC");
            reader = cmd.ExecuteReader();
            reader.Read();
            int idFactura = reader.GetInt32(0);
            reader.Close();


            setCmd("INSERT INTO LOS_SINEQUI.Renglones (id_factura, id_oferta, cant) " +
                        "SELECT	@idFactura,o.id_oferta,count(cu.id_cupon) " +
                        "FROM LOS_SINEQUI.Ofertas o " +
                        "JOIN LOS_SINEQUI.Cupones cu ON cu.id_oferta = o.id_oferta " +
                        "WHERE o.username = @proveedor " +
                        "AND o.fecha_pub >= @desde " +
                        "AND o.fecha_pub <= @hasta " +
                        "GROUP BY o.id_oferta, o.username " +
                        "ORDER BY 1");

            cmd.Parameters.AddWithValue("@idFactura", idFactura);
            cmd.Parameters.AddWithValue("@proveedor", proveedor.username);
            cmd.Parameters.AddWithValue("@desde", desde);
            cmd.Parameters.AddWithValue("@hasta", hasta);

            cmd.ExecuteNonQuery();

            setCmd("UPDATE LOS_SINEQUI.Cupones SET facturado = 1 " +
                    "FROM ( SELECT c.id_cupon as id " +
                            "FROM LOS_SINEQUI.Cupones c " +
                            "JOIN LOS_SINEQUI.Ofertas o ON o.id_oferta = c.id_oferta " +
                            "WHERE c.facturado = 0 " +
                            "AND o.username = @proveedor " +
                            "AND c.fecha_compra >= @desde " +
                            "AND c.fecha_compra <= @hasta ) as facturados " +
                            "WHERE facturados.id = Cupones.id_cupon ");
            cmd.Parameters.AddWithValue("@proveedor", proveedor.username);
            cmd.Parameters.AddWithValue("@desde", desde);
            cmd.Parameters.AddWithValue("@hasta", hasta);

            cmd.ExecuteNonQuery();


            setCmd("SELECT SUM((r.cant * o.precio_rebajado)*0.1) FROM LOS_SINEQUI.Renglones r " +
                    "JOIN LOS_SINEQUI.Ofertas o ON r.id_oferta = o.id_oferta " +
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


            setCmd("UPDATE LOS_SINEQUI.Facturas SET monto = @monto WHERE id_factura = @idFactura");
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
