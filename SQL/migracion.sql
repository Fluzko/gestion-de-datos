IF OBJECT_ID('Rol_Usuario', 'U') IS NOT NULL
	DROP TABLE Rol_Usuario
IF OBJECT_ID('Rol_Funcionalidad', 'U') IS NOT NULL
	DROP TABLE Rol_Funcionalidad
IF OBJECT_ID('Cargas', 'U') IS NOT NULL
	DROP TABLE Cargas
IF OBJECT_ID('Tarjetas', 'U') IS NOT NULL
	DROP TABLE Tarjetas
IF OBJECT_ID('TiposPago', 'U') IS NOT NULL
	DROP TABLE TiposPago
IF OBJECT_ID('Renglones', 'U') IS NOT NULL
	DROP TABLE Renglones
IF OBJECT_ID('Facturas', 'U') IS NOT NULL
	DROP TABLE Facturas
IF OBJECT_ID('Entregas', 'U') IS NOT NULL
	DROP TABLE Entregas
IF OBJECT_ID('Cupones', 'U') IS NOT NULL
	DROP TABLE Cupones
IF OBJECT_ID('Ofertas', 'U') IS NOT NULL
	DROP TABLE Ofertas
IF OBJECT_ID('Proveedores', 'U') IS NOT NULL
	DROP TABLE Proveedores
IF OBJECT_ID('Clientes', 'U') IS NOT NULL
	DROP TABLE Clientes
IF OBJECT_ID('Direcciones', 'U') IS NOT NULL
	DROP TABLE Direcciones
IF OBJECT_ID('Ciudades', 'U') IS NOT NULL
	DROP TABLE Ciudades
IF OBJECT_ID('Funcionalidades', 'U') IS NOT NULL
	DROP TABLE Funcionalidades
IF OBJECT_ID('Roles', 'U') IS NOT NULL
	DROP TABLE Roles
IF OBJECT_ID('Usuarios', 'U') IS NOT NULL
	DROP TABLE Usuarios
IF OBJECT_ID('Rubros', 'U') IS NOT NULL
	DROP TABLE Rubros

----USUARIO----
CREATE TABLE Usuarios (
	username NVARCHAR(255) PRIMARY KEY,
	password NVARCHAR(255),
	habilitado BIT
)

----CIUDADES----
CREATE TABLE Ciudades (
	id_ciudad NUMERIC PRIMARY KEY IDENTITY(1, 1),
	nombre NVARCHAR(255)
)


----DIRECCIONES----
CREATE TABLE Direcciones (
	id_direccion NUMERIC PRIMARY KEY IDENTITY(1, 1),
	direccion NVARCHAR(255),
	ciudad NUMERIC FOREIGN KEY REFERENCES Ciudades
)

----CLIENTES----
CREATE TABLE Clientes (
	username NVARCHAR(255) PRIMARY KEY FOREIGN KEY REFERENCES Usuarios,
	nombre NVARCHAR(255),
	apellido NVARCHAR(255),
	dni DECIMAL(8,0),
	mail NVARCHAR(255),
	telefono NUMERIC,
	id_direccion NUMERIC FOREIGN KEY REFERENCES Direcciones,
	fecha_nac DATETIME,
	credito DECIMAL(12, 2),
	habilitado BIT
)

----RUBROS----
CREATE TABLE Rubros (
	id_rubro NUMERIC PRIMARY KEY IDENTITY(1, 1),
	nombre NVARCHAR(255),
	habilitado BIT
)

----PROVEEDORES----
CREATE TABLE Proveedores (
	username NVARCHAR(255) PRIMARY KEY FOREIGN KEY REFERENCES Usuarios,
	razon_social NVARCHAR(255),
	telefono NUMERIC,
	id_direccion NUMERIC FOREIGN KEY REFERENCES Direcciones,
	cuit NCHAR(13),
	rubro NUMERIC FOREIGN KEY REFERENCES Rubros,
	nombre_contacto VARCHAR(255),
	habilitado BIT
)

----ROLES----
CREATE TABLE Roles (
	id_rol NUMERIC PRIMARY KEY IDENTITY(1, 1),
	nombre NVARCHAR(255),
	habilitado BIT
)

----ROL_USUARIO----
CREATE TABLE Rol_Usuario (
	id_rol NUMERIC FOREIGN KEY REFERENCES Roles,
	username NVARCHAR(255) FOREIGN KEY REFERENCES Usuarios,	
	habilitado BIT,
	PRIMARY KEY (id_rol, username)
) 

----FUNCIONALIDADES----
CREATE TABLE Funcionalidades (
	id_func NUMERIC PRIMARY KEY IDENTITY(1, 1),
	nombre NVARCHAR(255),
	descripcion NVARCHAR(255),
	habilitado BIT
)

----ROL_FUNCIONALIDAD----
CREATE TABLE Rol_Funcionalidad (
	id_rol NUMERIC FOREIGN KEY REFERENCES ROLES,
	id_func NUMERIC FOREIGN KEY REFERENCES Funcionalidades,
	PRIMARY KEY (id_rol, id_func)
)

----TIPOS_PAGO----
CREATE TABLE TiposPago (
	id_tipo NUMERIC PRIMARY KEY IDENTITY(1, 1),
	nombre NVARCHAR(255)
)

----TARJETAS----
CREATE TABLE Tarjetas (
	numero NCHAR(16) PRIMARY KEY,
	vencimiento DATE,
	titular NCHAR(20),
	codigo_verif NCHAR(3)
)

----CARGAS----
CREATE TABLE Cargas (
	id_carga NUMERIC PRIMARY KEY IDENTITY(1, 1),
	username NVARCHAR(255) FOREIGN KEY REFERENCES Clientes,
	tipo_pago NUMERIC FOREIGN KEY REFERENCES TiposPago,
	fecha DATETIME,
	monto DECIMAL(12,2),
	tarjeta_num NCHAR(16) FOREIGN KEY REFERENCES Tarjetas
)

----OFERTAS----
CREATE TABLE Ofertas (
	id_oferta NUMERIC PRIMARY KEY IDENTITY(1, 1),
	descripcion NVARCHAR(255),
	fecha_pub DATETIME,
	fecha_vec DATETIME,
	username NVARCHAR(255) FOREIGN KEY REFERENCES Proveedores,
	precio_rebajado DECIMAL(12,2),
	precio_lista DECIMAL(12,2),
	stock NUMERIC,
	max_cliente NUMERIC
)

----CUPONES----
CREATE TABLE Cupones (
	id_cupon NUMERIC PRIMARY KEY IDENTITY(1,1),
	username NVARCHAR(255) FOREIGN KEY REFERENCES Clientes,
	id_oferta NUMERIC FOREIGN KEY REFERENCES Ofertas,
	fecha_compra DATETIME,
	fecha_entrega DATETIME,
	codigo_legacy NVARCHAR(255),
	facturado NUMERIC
)

----ENTREGAS----
CREATE TABLE Entregas (
	id_cupon NUMERIC PRIMARY KEY FOREIGN KEY REFERENCES Cupones,
	fecha DATETIME
)

----FACTURAS----
CREATE TABLE Facturas (
	id_factura NUMERIC PRIMARY KEY IDENTITY(153131,1),
	monto DECIMAL(12, 2),
	username NVARCHAR(255) FOREIGN KEY REFERENCES Proveedores,
	fecha DATETIME
)

----RENGLONES----
CREATE TABLE Renglones (
	id_factura NUMERIC FOREIGN KEY REFERENCES Facturas,
	id_oferta NUMERIC FOREIGN KEY REFERENCES Ofertas,
	cant NUMERIC
)

INSERT INTO TiposPago (nombre)
	SELECT DISTINCT Tipo_Pago_Desc
		FROM gd_esquema.Maestra
		WHERE Tipo_Pago_Desc IS NOT NULL

INSERT INTO Rubros (nombre, habilitado)
	SELECT DISTINCT Provee_Rubro, 1
		FROM gd_esquema.Maestra
		WHERE Provee_Rubro IS NOT NULL

INSERT INTO Usuarios (username, password, habilitado)
	SELECT DISTINCT Cli_Dni, 1234, 1
		FROM gd_esquema.Maestra
		WHERE Cli_Nombre IS NOT NULL AND Cli_Apellido IS NOT NULL

INSERT INTO Clientes (username, nombre, apellido, dni, mail, telefono, fecha_nac, habilitado)
	SELECT DISTINCT Cli_Dni, Cli_Nombre, Cli_Apellido, Cli_Dni, Cli_Mail, Cli_Telefono, Cli_Fecha_Nac, 1
		FROM gd_esquema.Maestra
		WHERE Cli_Nombre IS NOT NULL AND Cli_Apellido IS NOT NULL

INSERT INTO Usuarios (username, password, habilitado)
	SELECT DISTINCT CONCAT(	SUBSTRING(Provee_CUIT,1, 2),
							SUBSTRING(Provee_CUIT,4,8),
							SUBSTRING(Provee_CUIT, 13,13)), 
					1234, 
					1
		FROM gd_esquema.Maestra
		WHERE Provee_CUIT IS NOT NULL

INSERT INTO Proveedores (username, razon_social, telefono, cuit, rubro, habilitado)
	SELECT DISTINCT CONCAT(	SUBSTRING(Provee_CUIT,1, 2),
							SUBSTRING(Provee_CUIT,4,8),
							SUBSTRING(Provee_CUIT, 13,13)), Provee_RS, Provee_Telefono, Provee_CUIT, (SELECT id_rubro FROM Rubros WHERE nombre = Provee_Rubro), 1
		FROM gd_esquema.Maestra
		WHERE Provee_CUIT IS NOT NULL

INSERT INTO Cargas (username, tipo_pago, fecha, monto)
	SELECT c.username, tp.id_tipo, m.Carga_Fecha, m.Carga_Credito
		FROM gd_esquema.Maestra m
		JOIN Clientes c ON c.dni = m.Cli_Dni
		JOIN TiposPago tp ON tp.nombre = m.Tipo_Pago_Desc

UPDATE Clientes SET credito = montoF
	FROM (
		SELECT Clientes.username as username, ISNULL(SUM(monto), 0) as montoF
			FROM Clientes
			LEFT JOIN Cargas
			ON Cargas.username = Clientes.username
			GROUP BY Clientes.username
	) Montos WHERE Clientes.username = Montos.username


INSERT INTO Roles(nombre, habilitado)
VALUES
  ('Cliente',1),
  ('Proveedor',1),
  ('Admisnitrador',1)


INSERT INTO Funcionalidades(nombre, descripcion,habilitado)
VALUES
  ('ABM Rol','Permite gestionar roles del sistema',1),
  ('ABM Cliente','Permite gestionar los clientes registrados',1),
  ('ABM Proveedor','Permite gestionar los proveedores registrados',1),	
  ('Cargar credito','Permite cargar credito en la cuenta',1),
  ('Gestionar ofertas','Permite crear y dar de baja nuevas ofertas',1),
  ('Comprar oferta','Permite comprar una oferta',1),
  ('Consumir oferta','Permite canjear la oferta',1),
  ('Facturar a proveedor','Permite facturar en un periodo de tiempo a un proveedor',1),
  ('Listado estadistico','Permite ver estadisticas diversas',1)


INSERT INTO Rol_Usuario (id_rol, username)
	SELECT DISTINCT 1, c.username from Clientes c
	WHERE c.habilitado = 1

INSERT INTO Rol_Usuario (id_rol, username)
	SELECT DISTINCT 2,
		p.username
FROM Proveedores p
WHERE p.habilitado = 1

/*Funcionalidades de cliente*/
INSERT INTO Rol_Funcionalidad (id_rol, id_func)
VALUES
	(1,4),
	(1,6),
	(1,7)

/*Funcionalidades proveedor*/
INSERT INTO Rol_Funcionalidad (id_rol, id_func)
VALUES
	(2,5)

/*Funcionalidades Admin*/
INSERT INTO Rol_Funcionalidad (id_rol, id_func)
VALUES
	(3,1),
	(3,2),
	(3,3),
	(3,8),
	(3,9)


INSERT INTO Ofertas (descripcion, fecha_pub, fecha_vec, username, precio_rebajado, precio_lista, stock, max_cliente)
	SELECT distinct	Oferta_Descripcion, 
			Oferta_Fecha, 
			Oferta_Fecha_Venc, 
			CONCAT(	SUBSTRING(Provee_CUIT,1, 2), SUBSTRING(Provee_CUIT,4,8), SUBSTRING(Provee_CUIT, 13,13)), 
			Oferta_Precio, 
			Oferta_Precio_Ficticio, 
			sum(Oferta_Cantidad), 
			sum(Oferta_Cantidad) 
	FROM gd_esquema.Maestra
	WHERE Oferta_Descripcion is not null 
	group by Oferta_Descripcion, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Precio, Oferta_Precio_Ficticio,Provee_CUIT   


INSERT INTO Cupones ( username, fecha_compra, id_oferta, fecha_entrega, codigo_legacy, facturado)
	SELECT distinct 
					Cli_Dni,
					Oferta_Fecha_Compra,
					id_oferta,
					Oferta_Entregado_Fecha,
					Oferta_Codigo,
					0
					from Ofertas o
			JOIN gd_esquema.Maestra m on
				o.descripcion = m.Oferta_Descripcion
				AND m.Oferta_Fecha = o.fecha_pub 
				AND m.Oferta_Fecha_Venc = o.fecha_vec 
				AND CONCAT(	SUBSTRING(Provee_CUIT,1, 2), SUBSTRING(Provee_CUIT,4,8), SUBSTRING(Provee_CUIT, 13,13)) =  o.username
				AND o.precio_lista = m.Oferta_Precio_Ficticio
				AND o.precio_rebajado = m.Oferta_Precio 
				group by Oferta_Codigo, Oferta_Fecha_Compra, Cli_Dni, id_oferta, Oferta_Entregado_Fecha
				having Oferta_Codigo IS NOT NULL


INSERT INTO Facturas (fecha,username)
	SELECT DISTINCT Factura_Fecha, CONCAT(	SUBSTRING(Provee_CUIT,1, 2), SUBSTRING(Provee_CUIT,4,8), SUBSTRING(Provee_CUIT, 13,13)) 
	FROM gd_esquema.Maestra
	WHERE Factura_Nro IS NOT NULL AND Factura_Fecha IS NOT NULL
	ORDER BY 1 ASC


INSERT INTO Renglones (id_factura,id_oferta,cant)
	SELECT Factura_Nro, id_oferta, count(Oferta_Codigo)
	FROM gd_esquema.Maestra
	JOIN Cupones c ON
		Oferta_Codigo = c.codigo_legacy
	WHERE Factura_Nro is not null
	GROUP BY  Factura_Nro, id_oferta

	
UPDATE Facturas SET monto = montoF
	FROM (
		SELECT Renglones.id_factura as id_factura, SUM(0.1*(Ofertas.precio_rebajado * Renglones.cant)) as montoF
			FROM Renglones
			JOIN Ofertas
			ON Ofertas.id_oferta = Renglones.id_oferta
			Group by Renglones.id_factura
	) Montos WHERE Facturas.id_factura = Montos.id_factura


UPDATE Cupones SET facturado = 1
	FROM(SELECT Oferta_Codigo as codigo FROM gd_esquema.Maestra WHERE Factura_Nro IS NOT NULL) facturados
	WHERE facturados.codigo = Cupones.codigo_legacy

