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

            setCmd("SELECT username, password, habilitado from LOS_SINEQUI.Usuarios WHERE username = @username AND password = @password");
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", Hash.GetHash(password));
            //cmd.Parameters.AddWithValue("@password", password); DESCOMENTAR PARA LOGUEAR CON agusadmin - agus

            //password = hashbytes('SHA2_256', '" + password + "')
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                Modelos.Usuario usuario = new Modelos.Usuario(reader.GetString(0), reader.GetBoolean(2));
                reader.Close();
                return usuario;
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        public static int getIdRol(String nombreRol) {

            setCmd("SELECT COUNT(id_rol) FROM LOS_SINEQUI.Roles WHERE nombre = @nombreRol");
            cmd.Parameters.AddWithValue("@nombreRol", nombreRol);
            reader = cmd.ExecuteReader();
            reader.Read();
            int existe = reader.GetInt32(0);
            reader.Close();
            if ( existe != 0)
            {
                setCmd("SELECT id_rol FROM LOS_SINEQUI.Roles WHERE nombre = @nombreRol");
                cmd.Parameters.AddWithValue("@nombreRol", nombreRol);
                reader = cmd.ExecuteReader();
                reader.Read();
                int idRol = reader.GetInt32(0);
                reader.Close();
                return idRol;
            }
            else
                return 0;    
        }

        public static bool tieneFuncionalidad(string idFunc, int idRol) {
            int id_func = int.Parse(idFunc);

            setCmd("SELECT COUNT(id_rol) FROM LOS_SINEQUI.Rol_Funcionalidad WHERE id_rol = @idRol AND id_func = @idFunc");
            cmd.Parameters.AddWithValue("@idRol", idRol);
            cmd.Parameters.AddWithValue("@idFunc", id_func);

            reader = cmd.ExecuteReader();
            reader.Read();
            int result = reader.GetInt32(0);
            reader.Close();

            if(result == 1)
                return true;
            else
                return false;
      
        }

        public static List<string> getAllRoles() {

            setCmd("SELECT nombre FROM LOS_SINEQUI.Roles WHERE habilitado=1");
            reader = cmd.ExecuteReader();

            List<string> roles = new List<string>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string rol = reader.GetString(0);
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

        public static bool eliminarRol(string nombreRol)
        {
            setCmd("UPDATE LOS_SINEQUI.Roles SET habilitado=0 WHERE nombre=@nombreRol");
            cmd.Parameters.AddWithValue("@nombreRol", nombreRol);
            cmd.ExecuteNonQuery();

            return true;
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

        public static List<Modelos.Funcionalidad> getFuncionalidades()
        {

            setCmd("SELECT f.id_func,f.nombre, f.descripcion FROM LOS_SINEQUI.Funcionalidades f");

            reader = cmd.ExecuteReader();

            List<Modelos.Funcionalidad> funcionalidades = new List<Modelos.Funcionalidad>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    funcionalidades.Add(new Modelos.Funcionalidad(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
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

        public static int rolExiste(string nombreRol) {
            setCmd("SELECT COUNT(id_rol) FROM LOS_SINEQUI.Roles " +
                "WHERE nombre = @nombreRol");
            cmd.Parameters.AddWithValue("@nombreRol", nombreRol);
            reader = cmd.ExecuteReader();
            reader.Read();
            int exists = reader.GetInt32(0);
            reader.Close();
            return exists;
        }

        public static bool crearRol(string nombreRol, List<int> funcionalidades) {

            if(String.IsNullOrEmpty(nombreRol) || String.IsNullOrWhiteSpace(nombreRol))
            {
                MessageBox.Show("Se debe ingresar un nombre para el rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (DB_Ofertas.rolExiste(nombreRol) == 1)
            {
                MessageBox.Show("El nombre ingresado ya esta en uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(funcionalidades.Count == 0)
            {
                MessageBox.Show("Se debe seleccionar al menos una funcionalidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            
            
            setCmd("INSERT INTO LOS_SINEQUI.Roles(nombre, habilitado) " +
                "VALUES (@nombreRol, 1)");
            cmd.Parameters.AddWithValue("@nombreRol", nombreRol);
            cmd.ExecuteNonQuery();

            setCmd("SELECT id_rol FROM LOS_SINEQUI.Roles "+
                "WHERE nombre = @nombreRol");
            cmd.Parameters.AddWithValue("@nombreRol", nombreRol);
            reader = cmd.ExecuteReader();
            reader.Read();

            int idrol = reader.GetInt32(0);

            reader.Close();

            foreach (int id in funcionalidades) {               
                setCmd("INSERT INTO LOS_SINEQUI.Rol_Funcionalidad(id_rol, id_func) " +
                    "VALUES(@idrol,@idfunc)");

                cmd.Parameters.AddWithValue("@idrol", idrol);
                cmd.Parameters.AddWithValue("@idfunc", id);

                cmd.ExecuteNonQuery();
            }

            return true;
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

            setCmd("insert into LOS_SINEQUI.Rol_Usuario (id_rol,username)" +
                "values (1, @username)");

            cmd.Parameters.AddWithValue("@username", username);

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
                    "JOIN LOS_SINEQUI.Proveedores p ON p.username = o.username " +
                    "WHERE o.fecha_pub <= @hoy AND o.fecha_vec >= @hoy");
            cmd.Parameters.AddWithValue("@hoy", Properties.Settings.Default.Fecha);
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

        public static bool crearOferta(string descripcion, decimal precioOferta, decimal precioLista, int stock, int cantMax, DateTime fechaPublicacion, DateTime fechaVencimiento, String proveedor)
        { 
            setCmd("INSERT INTO LOS_SINEQUI.Ofertas (descripcion, fecha_pub, fecha_vec, username, precio_rebajado, precio_lista, stock, max_cliente)" +
                "VALUES(@descripcion,@fechapub,@fechavec,@usuario,@preciooferta,@preciolista,@stock,@cantmax)");

            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@fechapub", fechaPublicacion);
            cmd.Parameters.AddWithValue("@fechavec", fechaVencimiento);
            cmd.Parameters.AddWithValue("@usuario",proveedor);                   
            cmd.Parameters.AddWithValue("@preciooferta", precioOferta);
            cmd.Parameters.AddWithValue("@preciolista", precioLista);
            cmd.Parameters.AddWithValue("@stock", stock);
            cmd.Parameters.AddWithValue("@cantmax", cantMax);

            cmd.ExecuteNonQuery();

            return true;
        }

        public static bool usuarioEsProveedor(String user)
        {
            setCmd("SELECT username FROM LOS_SINEQUI.Rol_Usuario WHERE id_rol = 2 AND username = @user");
            cmd.Parameters.AddWithValue("@user", user);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            reader.Close();
            return false;
        }

        public static bool esAdmin(String user) {
            setCmd("SELECT id_rol FROM LOS_SINEQUI.Rol_Usuario WHERE username = @usuario");
            cmd.Parameters.AddWithValue("@usuario", user);

            reader = cmd.ExecuteReader();
            int rol;

            if (reader.HasRows)
            {
                reader.Read();
                rol = reader.GetInt32(0);
                reader.Close();
                if (rol == 3 || rol == 4) {
                    return true;
                }
            }
            return false;
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

            setCmd("SELECT credito FROM LOS_SINEQUI.Clientes WHERE username = @username");

            cmd.Parameters.AddWithValue("@username", usuario.getUsername());

            reader = cmd.ExecuteReader();
            reader.Read();

            Decimal credito = reader.GetDecimal(0);

            reader.Close();

            if (credito < oferta.Precio * cant)
            {
                MessageBox.Show("No dispone de saldo suficiente", "Comprar Ofertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reader.Close();
                return;
            }

            setCmd(query);

            cmd.Parameters.AddWithValue("@username", usuario.getUsername());
            cmd.Parameters.AddWithValue("@oferta", oferta.Id);
            cmd.Parameters.AddWithValue("@fecha", fecha);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("La compra fue realizada con exito", "Comprar Ofertas", MessageBoxButtons.OK, MessageBoxIcon.None);
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
        public static bool mailExistsProv(String mail)
        {
            setCmd("SELECT 1 FROM LOS_SINEQUI.Proveedores p WHERE p.mail = @mail");
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

        public static bool razonExists(String razon_social)
        {
            setCmd("SELECT 1 FROM LOS_SINEQUI.Proveedores p WHERE p.razon_social = @razon_social");
            cmd.Parameters.AddWithValue("@razon_social", razon_social);

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

        public static bool quiereDeshabilitar(string nombrerol, bool habilitado) {
            setCmd("SELECT habilitado FROM LOS_SINEQUI.Roles WHERE nombre = @nombrerol");
            cmd.Parameters.AddWithValue("@nombrerol", nombrerol);
            reader = cmd.ExecuteReader();
            reader.Read();
            bool habilitadoViejo = reader.GetBoolean(0);
            reader.Close();
            if (habilitadoViejo == true && habilitado == false)
                return true;
            else
                return false;
        
        }

        public static bool updateRol(String nombreRol, String nombreViejo, List<int> funcionalidades, bool habilitado) {
            if (String.IsNullOrEmpty(nombreViejo) || String.IsNullOrWhiteSpace(nombreViejo))
            {
                MessageBox.Show("No se ha ingresado ningun rol a modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if (quiereDeshabilitar(nombreViejo, habilitado))
            {
                MessageBox.Show("Para deshabilitar un rol ingrese a la seccion de Eliminar Rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if (String.IsNullOrEmpty(nombreRol) || String.IsNullOrWhiteSpace(nombreRol))
            {
                MessageBox.Show("Se debe ingresar un nombre para el rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (nombreRol != nombreViejo)
            {
                if (DB_Ofertas.rolExiste(nombreRol) == 1)
                {
                    MessageBox.Show("El nombre ingresado ya esta en uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (funcionalidades.Count == 0)
            {
                MessageBox.Show("Se debe seleccionar al menos una funcionalidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            setCmd("UPDATE LOS_SINEQUI.Roles SET nombre = @nombreRol, habilitado = @habilitado WHERE nombre = @nombreViejo" );
            cmd.Parameters.AddWithValue("@nombreRol", nombreRol);
            cmd.Parameters.AddWithValue("@nombreViejo", nombreViejo);
            cmd.Parameters.AddWithValue("@habilitado", habilitado);
            cmd.ExecuteNonQuery();

            setCmd("SELECT id_rol FROM LOS_SINEQUI.Roles " +
                "WHERE nombre = @nombreRol");
            cmd.Parameters.AddWithValue("@nombreRol", nombreRol);
            reader = cmd.ExecuteReader();
            reader.Read();

            int idrol = reader.GetInt32(0);

            reader.Close();

            setCmd("DELETE FROM LOS_SINEQUI.Rol_Funcionalidad WHERE id_rol = @idrol");
            cmd.Parameters.AddWithValue("@idrol", idrol);
            cmd.ExecuteNonQuery();

            foreach (int id in funcionalidades)
            {
                setCmd("INSERT INTO LOS_SINEQUI.Rol_Funcionalidad(id_rol, id_func) " +
                    "VALUES(@idrol,@idfunc)");

                cmd.Parameters.AddWithValue("@idrol", idrol);
                cmd.Parameters.AddWithValue("@idfunc", id);

                cmd.ExecuteNonQuery();
            }

            return true;     
        }

        public static void updateProveedor(Modelos.Proveedor proveedor)
        {

            setCmd("SELECT id_direccion FROM LOS_SINEQUI.Proveedores p WHERE  p.username = @username");
            cmd.Parameters.AddWithValue("@username", proveedor.Username);

            reader = cmd.ExecuteReader();
            int idDireccion = -1;

            if (reader.HasRows)
            {
                reader.Read();
                idDireccion = reader.GetInt32(0);
                reader.Close();
            }


            setCmd("UPDATE LOS_SINEQUI.Proveedores SET " +
                                    "razon_social = @razonsocial, " +
                                    "cuit = @cuit, " +
                                    "rubro = @rubro, " +
                                    "mail = @mail, " +
                                    "telefono = @telefono, " +
                                    "nombre_contacto = @nombrecontacto, " +
                                    "habilitado = @habilitado " +
                                    "WHERE username = @username");

            cmd.Parameters.AddWithValue("@razonsocial", proveedor.RazonSocial);
            cmd.Parameters.AddWithValue("@cuit", proveedor.Cuit);
            cmd.Parameters.AddWithValue("@rubro", proveedor.Rubro_Id);
            cmd.Parameters.AddWithValue("@mail", proveedor.Mail);
            cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);
            cmd.Parameters.AddWithValue("@nombrecontacto", proveedor.NombreContacto);
            cmd.Parameters.AddWithValue("@habilitado", proveedor.habilitado);
            cmd.Parameters.AddWithValue("@username", proveedor.Username);

            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("Ocurrio un error al actualizar los datos", "Actualizar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion);
                cmd.Parameters.AddWithValue("@cp", proveedor.Cp);
                cmd.Parameters.AddWithValue("@piso", proveedor.Piso);
                cmd.Parameters.AddWithValue("@dpto", proveedor.Dpto);
                cmd.Parameters.AddWithValue("@localidad", proveedor.Localidad);
                cmd.Parameters.AddWithValue("@idDireccion", idDireccion);

                cmd.ExecuteNonQuery();
            }


            MessageBox.Show("Proveedor actualizado con exito", "Actualizar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                proveedor.Username = reader.GetString(0);
                proveedor.RazonSocial = reader.GetString(1);

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

            cmd.Parameters.AddWithValue("@idProveedor", proveedor.Username);
            cmd.Parameters.AddWithValue("@fechaActual", Properties.Settings.Default.Fecha);

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
            cmd.Parameters.AddWithValue("@proveedor", proveedor.Username);
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
            cmd.Parameters.AddWithValue("@proveedor", proveedor.Username);
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
    
        /// /////////////PROVEEDORES///////////////////

        public static List<Modelos.Proveedor> getProveedores()
        {
            List<Modelos.Proveedor> proveedores = null;

            setCmd("SELECT p.username, p.razon_social, p.telefono, p.mail, p.cuit, p.rubro, p.nombre_contacto, d.direccion, d.cp, d.piso, d.dpto, d.localidad, p.habilitado " +
                   "FROM LOS_SINEQUI.Proveedores p " +
                   "LEFT JOIN LOS_SINEQUI.Direcciones d ON p.id_direccion = d.id_direccion");
            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return proveedores;
            }

            proveedores = new List<Modelos.Proveedor>();

            while (reader.Read())
            {
                Modelos.Proveedor proveedor = new Modelos.Proveedor();
                proveedor.Username = reader.GetString(0);
                proveedor.RazonSocial = reader.GetString(1);
                proveedor.Telefono = reader.GetInt32(2);
                if (reader.IsDBNull(3))
                    proveedor.Mail = "-";
                else
                    proveedor.Mail = reader.GetString(3);
                proveedor.Cuit = reader.GetString(4);
                proveedor.Rubro_Id = reader.GetInt32(5);
                if (reader.IsDBNull(6))
                    proveedor.NombreContacto = "-";
                else
                    proveedor.NombreContacto = reader.GetString(6); 
                if (reader.IsDBNull(7))
                    proveedor.Direccion = "-";
                else
                    proveedor.Direccion = reader.GetString(7);
                if (reader.IsDBNull(8))
                    proveedor.Cp = "-";
                else
                    proveedor.Cp = reader.GetString(8);
                if (reader.IsDBNull(9))
                    proveedor.Piso = "-";
                else
                    proveedor.Piso = reader.GetString(9);
                if (reader.IsDBNull(10))
                    proveedor.Dpto = "-";
                else
                    proveedor.Dpto = reader.GetString(10);
                if (reader.IsDBNull(11))
                    proveedor.Localidad = "-";
                else
                    proveedor.Localidad = reader.GetString(11);
                proveedor.habilitado = reader.GetBoolean(12);

                proveedores.Add(proveedor);
            }

            reader.Close();
            return proveedores;
        }

        public static string nombreRubro(int id) {

            setCmd("select nombre from LOS_SINEQUI.Rubros where id_rubro = @id");

            cmd.Parameters.AddWithValue("@id", id);
            reader = cmd.ExecuteReader();
            reader.Read();

            string nombre = reader.GetString(0);
            reader.Close();
            return nombre;
        }
        public static int idRubro(string nombre)
        {

            setCmd("select id_rubro from LOS_SINEQUI.Rubros where nombre = @name");

            cmd.Parameters.AddWithValue("@name", nombre);
            reader = cmd.ExecuteReader();
            reader.Read();

            int id = reader.GetInt32(0);
            reader.Close();
            return id;
        }

        public static bool altaProveedor(String username, String contra, String razonsocial, String cuit, String mail, String telefono, String nombrecontacto, String rubro,
                                        String calle, String piso, String dpto, String localidad, String cp)
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

            //chequeo unicidad cuit y razonsocial
            setCmd("select count(razon_social) from LOS_SINEQUI.Proveedores where razon_social = @razon_social and cuit = @cuit");

            cmd.Parameters.AddWithValue("@razon_social", razonsocial);
            cmd.Parameters.AddWithValue("@cuit", cuit);

            reader = cmd.ExecuteReader();
            reader.Read();
            int cantidadCuitRazonSoc = reader.GetInt32(0);
            reader.Close();

            if (cantidadCuitRazonSoc != 0)
            {
                MessageBox.Show("Ya hay un proveedor con esta combinacion de razon social y cuit. Contacte con un administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            setCmd("insert into LOS_SINEQUI.Rol_Usuario(id_rol,username,habilitado)" +
                    "values (2, @username, 1)");
            cmd.Parameters.AddWithValue("@username", username);
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

            Console.WriteLine(rubro);
            Console.WriteLine("AVEEEEEERGA");

            setCmd("select id_rubro from LOS_SINEQUI.Rubros where nombre = @rubro");
            cmd.Parameters.AddWithValue("@rubro", rubro);

            reader = cmd.ExecuteReader();
            reader.Read();
            int id_rubro = reader.GetInt32(0);
            reader.Close();

            setCmd("insert into LOS_SINEQUI.Proveedores (username,razon_social,telefono,mail,id_direccion,cuit,rubro,nombre_contacto,habilitado)" +
                "values (@username, @razon_social, @telefono, @mail, @id_direccion, @cuit, @idrubro, @nombre_contacto, @habilitado)");

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@razon_social", razonsocial);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@mail", mail);
            cmd.Parameters.AddWithValue("@id_direccion", idDireccion);
            cmd.Parameters.AddWithValue("@cuit", cuit);
            cmd.Parameters.AddWithValue("@idrubro", id_rubro);
            cmd.Parameters.AddWithValue("@nombre_contacto", nombrecontacto);
            cmd.Parameters.AddWithValue("@habilitado", 1);

            cmd.ExecuteNonQuery();

            return true;
        }

        public static List<Modelos.Proveedor> getProveedores(String razonsocial, String cuit, String mail)
        {
            List<Modelos.Proveedor> proveedores = null;

            setCmd("SELECT p.username, p.razon_social, p.telefono, p.mail, p.cuit, p.rubro, p.nombre_contacto, d.direccion, d.cp, d.piso, d.dpto, d.localidad, p.habilitado " +
                    "FROM LOS_SINEQUI.Proveedores p " +
                    "JOIN LOS_SINEQUI.Direcciones d ON p.id_direccion = d.id_direccion " +
                    "WHERE " +
                    "p.razon_social LIKE @razonsocial  AND " +
                    "p.cuit = @cuit AND " +
                    "p.mail LIKE @mail");

            cmd.Parameters.AddWithValue("@razonsocial", "%" + razonsocial + "%");
            cmd.Parameters.AddWithValue("@cuit", cuit);
            cmd.Parameters.AddWithValue("@mail", "%" + mail + "%");

            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return proveedores;
            }

            proveedores = new List<Modelos.Proveedor>();

            while (reader.Read())
            {
                Modelos.Proveedor proveedor = new Modelos.Proveedor();
                proveedor.Username = reader.GetString(0);
                proveedor.RazonSocial = reader.GetString(1);
                proveedor.Telefono = reader.GetInt32(2);
                if (reader.IsDBNull(3))
                    proveedor.Mail = "-";
                else
                    proveedor.Mail = reader.GetString(3);
                proveedor.Cuit = reader.GetString(4);
                proveedor.Rubro_Id = reader.GetInt32(5);
                if (reader.IsDBNull(6))
                    proveedor.NombreContacto = "-";
                else
                    proveedor.NombreContacto = reader.GetString(6);
                if (reader.IsDBNull(7))
                    proveedor.Direccion = "-";
                else
                    proveedor.Direccion = reader.GetString(7);
                if (reader.IsDBNull(8))
                    proveedor.Cp = "-";
                else
                    proveedor.Cp = reader.GetString(8);
                if (reader.IsDBNull(9))
                    proveedor.Piso = "-";
                else
                    proveedor.Piso = reader.GetString(9);
                if (reader.IsDBNull(10))
                    proveedor.Dpto = "-";
                else
                    proveedor.Dpto = reader.GetString(10);
                if (reader.IsDBNull(11))
                    proveedor.Localidad = "-";
                else
                    proveedor.Localidad = reader.GetString(11);
                proveedor.habilitado = reader.GetBoolean(12);

                proveedores.Add(proveedor);
            }

            reader.Close();
            return proveedores;
        }

        public static List<Modelos.Proveedor> getProveedores(String cuit, String mail)
        {
            List<Modelos.Proveedor> proveedores = null;

            setCmd("SELECT p.username, p.razon_social, p.telefono, p.mail, p.cuit, p.rubro, p.nombre_contacto, d.direccion, d.cp, d.piso, d.dpto, d.localidad, p.habilitado " +
                    "FROM LOS_SINEQUI.Proveedores p " +
                    "JOIN LOS_SINEQUI.Direcciones d ON p.id_direccion = d.id_direccion " +
                    "WHERE " +
                    "p.cuit = @cuit  AND " +
                    "p.mail LIKE @mail");

            cmd.Parameters.AddWithValue("@cuit", cuit);
            cmd.Parameters.AddWithValue("@mail", "%" + mail + "%");

            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return proveedores;
            }

            proveedores = new List<Modelos.Proveedor>();

            while (reader.Read())
            {
                Modelos.Proveedor proveedor = new Modelos.Proveedor();
                proveedor.Username = reader.GetString(0);
                proveedor.RazonSocial = reader.GetString(1);
                proveedor.Telefono = reader.GetInt32(2);
                if (reader.IsDBNull(3))
                    proveedor.Mail = "-";
                else
                    proveedor.Mail = reader.GetString(3);
                proveedor.Cuit = reader.GetString(4);
                proveedor.Rubro_Id = reader.GetInt32(5);
                if (reader.IsDBNull(6))
                    proveedor.NombreContacto = "-";
                else
                    proveedor.NombreContacto = reader.GetString(6);
                if (reader.IsDBNull(7))
                    proveedor.Direccion = "-";
                else
                    proveedor.Direccion = reader.GetString(7);
                if (reader.IsDBNull(8))
                    proveedor.Cp = "-";
                else
                    proveedor.Cp = reader.GetString(8);
                if (reader.IsDBNull(9))
                    proveedor.Piso = "-";
                else
                    proveedor.Piso = reader.GetString(9);
                if (reader.IsDBNull(10))
                    proveedor.Dpto = "-";
                else
                    proveedor.Dpto = reader.GetString(10);
                if (reader.IsDBNull(11))
                    proveedor.Localidad = "-";
                else
                    proveedor.Localidad = reader.GetString(11);
                proveedor.habilitado = reader.GetBoolean(12);

                proveedores.Add(proveedor);
            }

            reader.Close();
            return proveedores;
        }

        public static List<Modelos.Proveedor> getProveedoresRSyE(String razonSocial, String mail)
        {
            List<Modelos.Proveedor> proveedores = null;

            setCmd("SELECT p.username, p.razon_social, p.telefono, p.mail, p.cuit, p.rubro, p.nombre_contacto, d.direccion, d.cp, d.piso, d.dpto, d.localidad, p.habilitado " +
                    "FROM LOS_SINEQUI.Proveedores p " +
                    "JOIN LOS_SINEQUI.Direcciones d ON p.id_direccion = d.id_direccion " +
                    "WHERE " +
                    "p.razon_social LIKE @razonsocial  AND " +
                    "p.mail LIKE @mail");

            cmd.Parameters.AddWithValue("@razonsocial", "%" + razonSocial + "%");
            cmd.Parameters.AddWithValue("@mail", "%" + mail + "%");

            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return proveedores;
            }

            proveedores = new List<Modelos.Proveedor>();

            while (reader.Read())
            {
                Modelos.Proveedor proveedor = new Modelos.Proveedor();
                proveedor.Username = reader.GetString(0);
                proveedor.RazonSocial = reader.GetString(1);
                proveedor.Telefono = reader.GetInt32(2);
                if (reader.IsDBNull(3))
                    proveedor.Mail = "-";
                else
                    proveedor.Mail = reader.GetString(3);
                proveedor.Cuit = reader.GetString(4);
                proveedor.Rubro_Id = reader.GetInt32(5);
                if (reader.IsDBNull(6))
                    proveedor.NombreContacto = "-";
                else
                    proveedor.NombreContacto = reader.GetString(6);
                if (reader.IsDBNull(7))
                    proveedor.Direccion = "-";
                else
                    proveedor.Direccion = reader.GetString(7);
                if (reader.IsDBNull(8))
                    proveedor.Cp = "-";
                else
                    proveedor.Cp = reader.GetString(8);
                if (reader.IsDBNull(9))
                    proveedor.Piso = "-";
                else
                    proveedor.Piso = reader.GetString(9);
                if (reader.IsDBNull(10))
                    proveedor.Dpto = "-";
                else
                    proveedor.Dpto = reader.GetString(10);
                if (reader.IsDBNull(11))
                    proveedor.Localidad = "-";
                else
                    proveedor.Localidad = reader.GetString(11);
                proveedor.habilitado = reader.GetBoolean(12);

                proveedores.Add(proveedor);
            }

            reader.Close();
            return proveedores;
        }

        public static List<Modelos.Proveedor> getProveedoresRSyC(String razonSocial, String cuit)
        {
            List<Modelos.Proveedor> proveedores = null;

            setCmd("SELECT p.username, p.razon_social, p.telefono, p.mail, p.cuit, p.rubro, p.nombre_contacto, d.direccion, d.cp, d.piso, d.dpto, d.localidad, p.habilitado " +
                    "FROM LOS_SINEQUI.Proveedores p " +
                    "JOIN LOS_SINEQUI.Direcciones d ON p.id_direccion = d.id_direccion " +
                    "WHERE " +
                    "p.razon_social LIKE @razonsocial  AND " +
                    "p.cuit = @cuit");

            cmd.Parameters.AddWithValue("@razonsocial", "%" + razonSocial + "%");
            cmd.Parameters.AddWithValue("@cuit", cuit);

            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return proveedores;
            }

            proveedores = new List<Modelos.Proveedor>();

            while (reader.Read())
            {
                Modelos.Proveedor proveedor = new Modelos.Proveedor();
                proveedor.Username = reader.GetString(0);
                proveedor.RazonSocial = reader.GetString(1);
                proveedor.Telefono = reader.GetInt32(2);
                if (reader.IsDBNull(3))
                    proveedor.Mail = "-";
                else
                    proveedor.Mail = reader.GetString(3);
                proveedor.Cuit = reader.GetString(4);
                proveedor.Rubro_Id = reader.GetInt32(5);
                if (reader.IsDBNull(6))
                    proveedor.NombreContacto = "-";
                else
                    proveedor.NombreContacto = reader.GetString(6);
                if (reader.IsDBNull(7))
                    proveedor.Direccion = "-";
                else
                    proveedor.Direccion = reader.GetString(7);
                if (reader.IsDBNull(8))
                    proveedor.Cp = "-";
                else
                    proveedor.Cp = reader.GetString(8);
                if (reader.IsDBNull(9))
                    proveedor.Piso = "-";
                else
                    proveedor.Piso = reader.GetString(9);
                if (reader.IsDBNull(10))
                    proveedor.Dpto = "-";
                else
                    proveedor.Dpto = reader.GetString(10);
                if (reader.IsDBNull(11))
                    proveedor.Localidad = "-";
                else
                    proveedor.Localidad = reader.GetString(11);
                proveedor.habilitado = reader.GetBoolean(12);

                proveedores.Add(proveedor);
            }

            reader.Close();
            return proveedores;
        }
        public static List<Modelos.Proveedor> getProveedoresRS(string razonSocial)
        {
            List<Modelos.Proveedor> proveedores = null;

            setCmd("SELECT p.username, p.razon_social, p.telefono, p.mail, p.cuit, p.rubro, p.nombre_contacto, d.direccion, d.cp, d.piso, d.dpto, d.localidad, p.habilitado " +
                    "FROM LOS_SINEQUI.Proveedores p " +
                    "JOIN LOS_SINEQUI.Direcciones d ON p.id_direccion = d.id_direccion " +
                    "WHERE " +
                    "p.razon_social LIKE @razonsocial");

            cmd.Parameters.AddWithValue("@razonsocial", "%" + razonSocial + "%");

            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return proveedores;
            }

            proveedores = new List<Modelos.Proveedor>();

            while (reader.Read())
            {
                Modelos.Proveedor proveedor = new Modelos.Proveedor();
                proveedor.Username = reader.GetString(0);
                proveedor.RazonSocial = reader.GetString(1);
                proveedor.Telefono = reader.GetInt32(2);
                if (reader.IsDBNull(3))
                    proveedor.Mail = "-";
                else
                    proveedor.Mail = reader.GetString(3);
                proveedor.Cuit = reader.GetString(4);
                proveedor.Rubro_Id = reader.GetInt32(5);
                if (reader.IsDBNull(6))
                    proveedor.NombreContacto = "-";
                else
                    proveedor.NombreContacto = reader.GetString(6);
                if (reader.IsDBNull(7))
                    proveedor.Direccion = "-";
                else
                    proveedor.Direccion = reader.GetString(7);
                if (reader.IsDBNull(8))
                    proveedor.Cp = "-";
                else
                    proveedor.Cp = reader.GetString(8);
                if (reader.IsDBNull(9))
                    proveedor.Piso = "-";
                else
                    proveedor.Piso = reader.GetString(9);
                if (reader.IsDBNull(10))
                    proveedor.Dpto = "-";
                else
                    proveedor.Dpto = reader.GetString(10);
                if (reader.IsDBNull(11))
                    proveedor.Localidad = "-";
                else
                    proveedor.Localidad = reader.GetString(11);
                proveedor.habilitado = reader.GetBoolean(12);

                proveedores.Add(proveedor);
            }

            reader.Close();
            return proveedores;
        }

        public static List<Modelos.Proveedor> getProveedoresE(string mail)
        {
            List<Modelos.Proveedor> proveedores = null;

            setCmd("SELECT p.username, p.razon_social, p.telefono, p.mail, p.cuit, p.rubro, p.nombre_contacto, d.direccion, d.cp, d.piso, d.dpto, d.localidad, p.habilitado " +
                    "FROM LOS_SINEQUI.Proveedores p " +
                    "JOIN LOS_SINEQUI.Direcciones d ON p.id_direccion = d.id_direccion " +
                    "WHERE " +
                    "p.mail LIKE @mail");

            cmd.Parameters.AddWithValue("@mail", "%" + mail + "%");

            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return proveedores;
            }

            proveedores = new List<Modelos.Proveedor>();

            while (reader.Read())
            {
                Modelos.Proveedor proveedor = new Modelos.Proveedor();
                proveedor.Username = reader.GetString(0);
                proveedor.RazonSocial = reader.GetString(1);
                proveedor.Telefono = reader.GetInt32(2);
                if (reader.IsDBNull(3))
                    proveedor.Mail = "-";
                else
                    proveedor.Mail = reader.GetString(3);
                proveedor.Cuit = reader.GetString(4);
                proveedor.Rubro_Id = reader.GetInt32(5);
                if (reader.IsDBNull(6))
                    proveedor.NombreContacto = "-";
                else
                    proveedor.NombreContacto = reader.GetString(6);
                if (reader.IsDBNull(7))
                    proveedor.Direccion = "-";
                else
                    proveedor.Direccion = reader.GetString(7);
                if (reader.IsDBNull(8))
                    proveedor.Cp = "-";
                else
                    proveedor.Cp = reader.GetString(8);
                if (reader.IsDBNull(9))
                    proveedor.Piso = "-";
                else
                    proveedor.Piso = reader.GetString(9);
                if (reader.IsDBNull(10))
                    proveedor.Dpto = "-";
                else
                    proveedor.Dpto = reader.GetString(10);
                if (reader.IsDBNull(11))
                    proveedor.Localidad = "-";
                else
                    proveedor.Localidad = reader.GetString(11);
                proveedor.habilitado = reader.GetBoolean(12);

                proveedores.Add(proveedor);
            }

            reader.Close();
            return proveedores;
        }
        public static List<Modelos.Proveedor> getProveedoresC(string cuit)
        {
            List<Modelos.Proveedor> proveedores = null;

            setCmd("SELECT p.username, p.razon_social, p.telefono, p.mail, p.cuit, p.rubro, p.nombre_contacto, d.direccion, d.cp, d.piso, d.dpto, d.localidad, p.habilitado " +
                    "FROM LOS_SINEQUI.Proveedores p " +
                    "JOIN LOS_SINEQUI.Direcciones d ON p.id_direccion = d.id_direccion " +
                    "WHERE " +
                    "p.cuit = @cuit");

            cmd.Parameters.AddWithValue("@cuit", cuit);

            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return proveedores;
            }

            proveedores = new List<Modelos.Proveedor>();

            while (reader.Read())
            {
                Modelos.Proveedor proveedor = new Modelos.Proveedor();
                proveedor.Username = reader.GetString(0);
                proveedor.RazonSocial = reader.GetString(1);
                proveedor.Telefono = reader.GetInt32(2);
                if (reader.IsDBNull(3))
                    proveedor.Mail = "-";
                else
                    proveedor.Mail = reader.GetString(3);
                proveedor.Cuit = reader.GetString(4);
                proveedor.Rubro_Id = reader.GetInt32(5);
                if (reader.IsDBNull(6))
                    proveedor.NombreContacto = "-";
                else
                    proveedor.NombreContacto = reader.GetString(6);
                if (reader.IsDBNull(7))
                    proveedor.Direccion = "-";
                else
                    proveedor.Direccion = reader.GetString(7);
                if (reader.IsDBNull(8))
                    proveedor.Cp = "-";
                else
                    proveedor.Cp = reader.GetString(8);
                if (reader.IsDBNull(9))
                    proveedor.Piso = "-";
                else
                    proveedor.Piso = reader.GetString(9);
                if (reader.IsDBNull(10))
                    proveedor.Dpto = "-";
                else
                    proveedor.Dpto = reader.GetString(10);
                if (reader.IsDBNull(11))
                    proveedor.Localidad = "-";
                else
                    proveedor.Localidad = reader.GetString(11);
                proveedor.habilitado = reader.GetBoolean(12);

                proveedores.Add(proveedor);
            }

            reader.Close();
            return proveedores;
        }

        public static List<Modelos.Rubro> getRubros()
        {
            setCmd("SELECT id_rubro, nombre FROM LOS_SINEQUI.Rubros WHERE habilitado = 1 ORDER BY 2");

            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                MessageBox.Show("No hay ningun rubro habilitado en el sistema", "Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                reader.Close();
                return null;
            }

            List<Modelos.Rubro> rubros = new List<Modelos.Rubro>();

            while (reader.Read())
            {
                Modelos.Rubro rubro = new Modelos.Rubro();

                rubro.id_rubro = reader.GetInt32(0);
                rubro.nombre = reader.GetString(1);

                rubros.Add(rubro);
            }

            reader.Close();
            return rubros;
        }

        public static List<Modelos.TipoPago> getTiposDePago() {
            setCmd("SELECT t.id_tipo, t.nombre from LOS_SINEQUI.TiposPago t");

            reader = cmd.ExecuteReader();

            List<Modelos.TipoPago> tiposPago = new List<Modelos.TipoPago>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Modelos.TipoPago tipoPago = new Modelos.TipoPago(reader.GetInt32(0), reader.GetString(1));
                    tiposPago.Add(tipoPago);
                }
                reader.Close();
                return tiposPago;
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        public static List<Modelos.Tarjeta> getTarjetasParaCliente(String username)
        {
            setCmd("SELECT t.numero, t.titular from LOS_SINEQUI.Tarjetas t WHERE username = @username");
            cmd.Parameters.AddWithValue("@username", username);

            reader = cmd.ExecuteReader();

            List<Modelos.Tarjeta> tarjetas = new List<Modelos.Tarjeta>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Modelos.Tarjeta tarjeta = new Modelos.Tarjeta(reader.GetString(0), reader.GetString(1));
                    tarjetas.Add(tarjeta);
                }
                reader.Close();
                return tarjetas;
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        public static void agregarTarjetasParaCliente(String username, String numero, String titular, int mes, int anio, String codigo)
        {
            setCmd("INSERT INTO LOS_SINEQUI.Tarjetas (username, numero, mesVencimiento, anioVencimiento, titular, codigo_verif) " +
                            "VALUES (@idCliente, @numero, @mes, @anio, @titular, @codigo)");

            cmd.Parameters.AddWithValue("@idCliente", username);
            cmd.Parameters.AddWithValue("@numero", numero);
            cmd.Parameters.AddWithValue("@mes", mes);
            cmd.Parameters.AddWithValue("@anio", anio);
            cmd.Parameters.AddWithValue("@titular", titular);
            cmd.Parameters.AddWithValue("@codigo", codigo);

            cmd.ExecuteNonQuery();
        }

        public static void generarCarga(String username, int tipoPago, DateTime fecha, double monto, string tarjetaNum)
        {
            if (tarjetaNum != null)
            {
                setCmd("INSERT INTO LOS_SINEQUI.Cargas (username, tipo_pago, fecha, monto, tarjeta_num) " +
                                   "VALUES (@idCliente, @tipoPago, @fecha, @monto, @tarjetaNum)");
                cmd.Parameters.AddWithValue("@tarjetaNum", tarjetaNum);
            }
            else
            {
                setCmd("INSERT INTO LOS_SINEQUI.Cargas (username, tipo_pago, fecha, monto) " +
                                   "VALUES (@idCliente, @tipoPago, @fecha, @monto)");
            }

            cmd.Parameters.AddWithValue("@idCliente", username);
            cmd.Parameters.AddWithValue("@tipoPago", tipoPago);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            cmd.Parameters.AddWithValue("@monto", monto);       
            
            cmd.ExecuteNonQuery();
        }

        public static void actualizarMontoCliente(String username, double monto)
        {
            setCmd("UPDATE LOS_SINEQUI.Clientes " +
                            "SET credito = credito + @monto WHERE username = @idCliente");

            cmd.Parameters.AddWithValue("@idCliente", username);
            cmd.Parameters.AddWithValue("@monto", monto);            

            cmd.ExecuteNonQuery();
        }

        public static double getCreditoCliente(String username)
        {
            setCmd("SELECT credito from LOS_SINEQUI.Clientes WHERE username = @username");
            cmd.Parameters.AddWithValue("@username", username);

            reader = cmd.ExecuteReader();

            reader.Read();
            
            decimal credito = reader.GetDecimal(0);
            reader.Close();
            return Decimal.ToDouble(credito);
         
        }

        public static List<Modelos.ProveedorEstadistica1> getProveedoresFacturacion(String anio, int semestre) {

            String query = "SELECT TOP 5 p.username, p.razon_social, sum(f.monto) as facturacion from LOS_SINEQUI.Proveedores p JOIN"
                                    + " LOS_SINEQUI.Facturas f ON f.username = p.username"
                                    + " WHERE YEAR(f.fecha) = @anio AND ";
            if (semestre == 1)
            {
                query += "MONTH(f.fecha) <7";
            }
            else
            {
                query += "MONTH(f.fecha) >6";
            }

            query += " GROUP BY p.username, p.razon_social"
            + " ORDER BY 3 DESC";
           
            setCmd(query);

            cmd.Parameters.AddWithValue("@anio", anio);

            reader = cmd.ExecuteReader();

            List<Modelos.ProveedorEstadistica1> proveedores = new List<Modelos.ProveedorEstadistica1>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Modelos.ProveedorEstadistica1 proveedor = new Modelos.ProveedorEstadistica1(reader.GetString(0),
                                                              reader.GetString(1),Decimal.ToDouble(reader.GetDecimal(2)));

                    proveedores.Add(proveedor);
                }
                reader.Close();
                return proveedores;
            }
            else
            {
                reader.Close();
                return null;
            }
            
        }

        public static List<Modelos.ProveedorEstadistica2> getProveedoresPorcentajeOferta(String anio, int semestre)
        {

            String query = "SELECT TOP 5 p.username, p.razon_social, max(1 - (o.precio_rebajado/o.precio_lista)) as PorcentajeO from LOS_SINEQUI.Proveedores p JOIN"
                            + " LOS_SINEQUI.Ofertas o ON o.username = p.username"
                            + " WHERE YEAR(o.fecha_pub) = @anio AND ";
            
            if (semestre == 1)
            {
                query += "MONTH(o.fecha_pub) <7";
            }
            else
            {
                query += "MONTH(o.fecha_pub) >6";
            }

            query += " GROUP BY p.username, p.razon_social"
            + " ORDER BY 3 DESC";

            setCmd(query);

            cmd.Parameters.AddWithValue("@anio", anio);

            reader = cmd.ExecuteReader();

            List<Modelos.ProveedorEstadistica2> proveedores = new List<Modelos.ProveedorEstadistica2>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Modelos.ProveedorEstadistica2 proveedor = new Modelos.ProveedorEstadistica2(reader.GetString(0),
                                                              reader.GetString(1), Decimal.ToDouble(reader.GetDecimal(2)));

                    proveedores.Add(proveedor);
                }
                reader.Close();
                return proveedores;
            }
            else
            {
                reader.Close();
                return null;
            }

        }

        public static bool habilitado(int id_rol) {
            setCmd("SELECT habilitado FROM LOS_SINEQUI.Roles WHERE id_rol = @id_rol");
            cmd.Parameters.AddWithValue("@id_rol", id_rol);
            reader = cmd.ExecuteReader();
            reader.Read();
            bool habilitado = reader.GetBoolean(0);
            reader.Close();
            return habilitado;
        
        }

    }
}
