USE GD2C2019;
	GO

IF OBJECT_ID('LOS_SINEQUI.Rol_Usuario', 'U') IS NOT NULL
	DROP TABLE LOS_SINEQUI.Rol_Usuario
IF OBJECT_ID('LOS_SINEQUI.Rol_Funcionalidad', 'U') IS NOT NULL
	DROP TABLE LOS_SINEQUI.Rol_Funcionalidad
IF OBJECT_ID('LOS_SINEQUI.Cargas', 'U') IS NOT NULL
	DROP TABLE LOS_SINEQUI.Cargas
IF OBJECT_ID('LOS_SINEQUI.Tarjetas', 'U') IS NOT NULL
	DROP TABLE LOS_SINEQUI.Tarjetas
IF OBJECT_ID('LOS_SINEQUI.TiposPago', 'U') IS NOT NULL
	DROP TABLE LOS_SINEQUI.TiposPago
IF OBJECT_ID('LOS_SINEQUI.Renglones', 'U') IS NOT NULL
	DROP TABLE LOS_SINEQUI.Renglones
IF OBJECT_ID('LOS_SINEQUI.Facturas', 'U') IS NOT NULL
	DROP TABLE LOS_SINEQUI.Facturas
IF OBJECT_ID('LOS_SINEQUI.Cupones', 'U') IS NOT NULL
	DROP TABLE LOS_SINEQUI.Cupones
IF OBJECT_ID('LOS_SINEQUI.Ofertas', 'U') IS NOT NULL
	DROP TABLE LOS_SINEQUI.Ofertas
IF OBJECT_ID('LOS_SINEQUI.Proveedores', 'U') IS NOT NULL
	DROP TABLE LOS_SINEQUI.Proveedores
IF OBJECT_ID('LOS_SINEQUI.Clientes', 'U') IS NOT NULL
	DROP TABLE LOS_SINEQUI.Clientes
IF OBJECT_ID('LOS_SINEQUI.Direcciones', 'U') IS NOT NULL
	DROP TABLE LOS_SINEQUI.Direcciones
IF OBJECT_ID('LOS_SINEQUI.Ciudades', 'U') IS NOT NULL
	DROP TABLE LOS_SINEQUI.Ciudades
IF OBJECT_ID('LOS_SINEQUI.Funcionalidades', 'U') IS NOT NULL
	DROP TABLE LOS_SINEQUI.Funcionalidades
IF OBJECT_ID('LOS_SINEQUI.Roles', 'U') IS NOT NULL
	DROP TABLE LOS_SINEQUI.Roles
IF OBJECT_ID('LOS_SINEQUI.Usuarios', 'U') IS NOT NULL
	DROP TABLE LOS_SINEQUI.Usuarios
IF OBJECT_ID('LOS_SINEQUI.Rubros', 'U') IS NOT NULL
	DROP TABLE LOS_SINEQUI.Rubros
GO

IF EXISTS (SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'LOS_SINEQUI')
DROP SCHEMA LOS_SINEQUI
GO

CREATE SCHEMA LOS_SINEQUI AUTHORIZATION gd;
GO

----USUARIO----
CREATE TABLE LOS_SINEQUI.Usuarios (
	username NVARCHAR(255) PRIMARY KEY,
	password NVARCHAR(255) NOT NULL,
	habilitado BIT DEFAULT 1
)


----CIUDADES----
CREATE TABLE LOS_SINEQUI.Ciudades (
	id_ciudad INTEGER PRIMARY KEY IDENTITY(1, 1),
	nombre NVARCHAR(255) NOT NULL UNIQUE
)


----DIRECCIONES----
CREATE TABLE LOS_SINEQUI.Direcciones (
	id_direccion INTEGER PRIMARY KEY IDENTITY(1, 1),
	direccion NVARCHAR(255) NOT NULL,
	cp NVARCHAR(5),
	piso NVARCHAR(2),
	dpto NVARCHAR(2),
	ciudad INTEGER FOREIGN KEY REFERENCES LOS_SINEQUI.Ciudades NOT NULL
)

----CLIENTES----
CREATE TABLE LOS_SINEQUI.Clientes (
	username NVARCHAR(255) PRIMARY KEY FOREIGN KEY REFERENCES LOS_SINEQUI.Usuarios,
	nombre NVARCHAR(255) NOT NULL,
	apellido NVARCHAR(255) NOT NULL,
	dni INTEGER NOT NULL,
	mail NVARCHAR(255),
	telefono INTEGER,
	id_direccion INTEGER FOREIGN KEY REFERENCES LOS_SINEQUI.Direcciones,
	fecha_nac DATETIME NOT NULL,
	credito DECIMAL(12, 2) DEFAULT 0,
	habilitado BIT DEFAULT 1
)

----RUBROS----
CREATE TABLE LOS_SINEQUI.Rubros (
	id_rubro INTEGER PRIMARY KEY IDENTITY(1, 1),
	nombre NVARCHAR(255) UNIQUE NOT NULL,
	habilitado BIT DEFAULT 1
)



----PROVEEDORES----
CREATE TABLE LOS_SINEQUI.Proveedores (
	username NVARCHAR(255) PRIMARY KEY FOREIGN KEY REFERENCES LOS_SINEQUI.Usuarios,
	razon_social NVARCHAR(255) NOT NULL UNIQUE,
	telefono INTEGER,
	mail NVARCHAR(255),
	id_direccion INTEGER FOREIGN KEY REFERENCES LOS_SINEQUI.Direcciones,
	cuit NCHAR(13) NOT NULL UNIQUE,
	rubro INTEGER FOREIGN KEY REFERENCES LOS_SINEQUI.Rubros NOT NULL,
	nombre_contacto VARCHAR(255),
	habilitado BIT DEFAULT 1
)


----ROLES----
CREATE TABLE LOS_SINEQUI.Roles (
	id_rol INTEGER PRIMARY KEY IDENTITY(1, 1),
	nombre NVARCHAR(255) UNIQUE NOT NULL,
	habilitado BIT DEFAULT 1
)

----ROL_USUARIO----
CREATE TABLE LOS_SINEQUI.Rol_Usuario (
	id_rol INTEGER FOREIGN KEY REFERENCES LOS_SINEQUI.Roles,
	username NVARCHAR(255) FOREIGN KEY REFERENCES LOS_SINEQUI.Usuarios,	
	habilitado BIT DEFAULT 1,
	PRIMARY KEY (id_rol, username)
) 

----FUNCIONALIDADES----
CREATE TABLE LOS_SINEQUI.Funcionalidades (
	id_func INTEGER PRIMARY KEY IDENTITY(1, 1),
	nombre NVARCHAR(255) UNIQUE NOT NULL,
	descripcion NVARCHAR(255) DEFAULT 'Sin descripcion',
	habilitado BIT DEFAULT 1
)

----ROL_FUNCIONALIDAD----
CREATE TABLE LOS_SINEQUI.Rol_Funcionalidad (
	id_rol INTEGER FOREIGN KEY REFERENCES LOS_SINEQUI.ROLES,
	id_func INTEGER FOREIGN KEY REFERENCES LOS_SINEQUI.Funcionalidades,
	PRIMARY KEY (id_rol, id_func)
)

----TIPOS_PAGO----
CREATE TABLE LOS_SINEQUI.TiposPago (
	id_tipo INTEGER PRIMARY KEY IDENTITY(1, 1),
	nombre NVARCHAR(255) UNIQUE NOT NULL
)

----TARJETAS----
CREATE TABLE LOS_SINEQUI.Tarjetas (
	numero NCHAR(16) PRIMARY KEY,
	vencimiento DATE NOT NULL,
	titular NCHAR(20) NOT NULL,
	codigo_verif NCHAR(3) NOT NULL
)

----CARGAS----
CREATE TABLE LOS_SINEQUI.Cargas (
	id_carga INTEGER PRIMARY KEY IDENTITY(1, 1),
	username NVARCHAR(255) FOREIGN KEY REFERENCES LOS_SINEQUI.Clientes NOT NULL,
	tipo_pago INTEGER FOREIGN KEY REFERENCES LOS_SINEQUI.TiposPago NOT NULL,
	fecha DATETIME NOT NULL,
	monto DECIMAL(12,2) NOT NULL DEFAULT 0,
	tarjeta_num NCHAR(16) FOREIGN KEY REFERENCES LOS_SINEQUI.Tarjetas
)

----OFERTAS----
CREATE TABLE LOS_SINEQUI.Ofertas (
	id_oferta INTEGER PRIMARY KEY IDENTITY(1, 1),
	descripcion NVARCHAR(255) NOT NULL,
	fecha_pub DATE NOT NULL,
	fecha_vec DATE NOT NULL,
	username NVARCHAR(255) FOREIGN KEY REFERENCES LOS_SINEQUI.Proveedores NOT NULL,
	precio_rebajado DECIMAL(12,2) NOT NULL,
	precio_lista DECIMAL(12,2) NOT NULL,
	stock INTEGER NOT NULL,
	max_cliente INTEGER NOT NULL
)


----CUPONES----
CREATE TABLE LOS_SINEQUI.Cupones (
	id_cupon INTEGER PRIMARY KEY IDENTITY(1,1),
	username NVARCHAR(255) FOREIGN KEY REFERENCES LOS_SINEQUI.Clientes NOT NULL,
	id_oferta INTEGER FOREIGN KEY REFERENCES LOS_SINEQUI.Ofertas NOT NULL,
	fecha_compra DATETIME NOT NULL,
	fecha_entrega DATETIME,
	codigo_legacy NVARCHAR(255),
	facturado BIT NOT NULL DEFAULT 0
)


----FACTURAS----
CREATE TABLE LOS_SINEQUI.Facturas (
	id_factura INTEGER PRIMARY KEY IDENTITY(153131,1),
	monto DECIMAL(12, 2) NOT NULL,
	username NVARCHAR(255) FOREIGN KEY REFERENCES LOS_SINEQUI.Proveedores NOT NULL,
	fecha DATETIME NOT NULL
)

----RENGLONES----
CREATE TABLE LOS_SINEQUI.Renglones (
	id_factura INTEGER FOREIGN KEY REFERENCES LOS_SINEQUI.Facturas,
	id_oferta INTEGER FOREIGN KEY REFERENCES LOS_SINEQUI.Ofertas,
	cant NUMERIC NOT NULL DEFAULT 1
)
GO

INSERT INTO LOS_SINEQUI.TiposPago (nombre)
	SELECT DISTINCT Tipo_Pago_Desc
		FROM gd_esquema.Maestra
		WHERE Tipo_Pago_Desc IS NOT NULL

INSERT INTO LOS_SINEQUI.Rubros (nombre, habilitado)
	SELECT DISTINCT Provee_Rubro, 1
		FROM gd_esquema.Maestra
		WHERE Provee_Rubro IS NOT NULL

INSERT INTO LOS_SINEQUI.Usuarios (username, password, habilitado)
	SELECT DISTINCT Cli_Dni, '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 1
		FROM gd_esquema.Maestra
		WHERE Cli_Nombre IS NOT NULL AND Cli_Apellido IS NOT NULL

INSERT INTO LOS_SINEQUI.Ciudades(nombre) 
	SELECT DISTINCT Cli_Ciudad FROM gd_esquema.Maestra

INSERT INTO LOS_SINEQUI.Direcciones (direccion,ciudad,cp,dpto,piso)
	SELECT DISTINCT m.Cli_Direccion, c.id_ciudad, '-', '-', '-' FROM gd_esquema.Maestra m
	JOIN LOS_SINEQUI.Ciudades c ON c.nombre = m.Cli_Ciudad
	

INSERT INTO LOS_SINEQUI.Clientes (username, nombre, apellido, dni, mail, telefono, fecha_nac, habilitado,id_direccion)
	SELECT DISTINCT Cli_Dni, UPPER(Cli_Nombre), UPPER(Cli_Apellido), Cli_Dni, Cli_Mail, Cli_Telefono, Cli_Fecha_Nac, 1, d.id_direccion
		FROM gd_esquema.Maestra
		JOIN LOS_SINEQUI.Direcciones d ON Cli_Direccion = d.direccion
		JOIN LOS_SINEQUI.Ciudades c ON d.ciudad = c.id_ciudad
		WHERE Cli_Nombre IS NOT NULL AND Cli_Apellido IS NOT NULL

UPDATE LOS_SINEQUI.Clientes SET habilitado = 0
WHERE mail like '% %'

INSERT INTO LOS_SINEQUI.Usuarios (username, password, habilitado)
	SELECT DISTINCT CONCAT(	SUBSTRING(Provee_CUIT,1, 2),
							SUBSTRING(Provee_CUIT,4,8),
							SUBSTRING(Provee_CUIT, 13,13)), 
					'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', --Hash de 1234
					1
		FROM gd_esquema.Maestra
		WHERE Provee_CUIT IS NOT NULL

INSERT INTO LOS_SINEQUI.Proveedores (username, razon_social, telefono, cuit, rubro, habilitado)
	SELECT DISTINCT CONCAT(	SUBSTRING(Provee_CUIT,1, 2),
							SUBSTRING(Provee_CUIT,4,8),
							SUBSTRING(Provee_CUIT, 13,13)), Provee_RS, Provee_Telefono, Provee_CUIT, (SELECT id_rubro FROM LOS_SINEQUI.Rubros WHERE nombre = Provee_Rubro), 1
		FROM gd_esquema.Maestra
		WHERE Provee_CUIT IS NOT NULL

INSERT INTO LOS_SINEQUI.Cargas (username, tipo_pago, fecha, monto)
	SELECT c.username, tp.id_tipo, m.Carga_Fecha, m.Carga_Credito
		FROM gd_esquema.Maestra m
		JOIN LOS_SINEQUI.Clientes c ON c.dni = m.Cli_Dni
		JOIN LOS_SINEQUI.TiposPago tp ON tp.nombre = m.Tipo_Pago_Desc

UPDATE LOS_SINEQUI.Clientes SET credito = montoF
	FROM (
		SELECT Clientes.username as username, ISNULL(SUM(monto), 0) as montoF
			FROM LOS_SINEQUI.Clientes
			LEFT JOIN LOS_SINEQUI.Cargas
			ON Cargas.username = Clientes.username
			GROUP BY Clientes.username
	) Montos WHERE Clientes.username = Montos.username


INSERT INTO LOS_SINEQUI.Roles(nombre, habilitado)
VALUES
  ('Cliente',1),
  ('Proveedor',1),
  ('Administrador',1),
  ('Administrador General',1)


INSERT INTO LOS_SINEQUI.Funcionalidades(nombre, descripcion,habilitado)
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


INSERT INTO LOS_SINEQUI.Rol_Usuario (id_rol, username)
	SELECT DISTINCT 1, c.username from LOS_SINEQUI.Clientes c
	WHERE c.habilitado = 1

INSERT INTO LOS_SINEQUI.Rol_Usuario (id_rol, username)
	SELECT DISTINCT 2,
		p.username
FROM LOS_SINEQUI.Proveedores p
WHERE p.habilitado = 1

/*Funcionalidades de cliente*/
INSERT INTO LOS_SINEQUI.Rol_Funcionalidad (id_rol, id_func)
VALUES
	(1,4),
	(1,6)

/*Funcionalidades proveedor*/
INSERT INTO LOS_SINEQUI.Rol_Funcionalidad (id_rol, id_func)
VALUES
	(2,5),
	(2,7)

/*Funcionalidades Admin*/
INSERT INTO LOS_SINEQUI.Rol_Funcionalidad (id_rol, id_func)
VALUES
	(3,1),
	(3,2),
	(3,3),
	(3,8),
	(3,9)

/*Funcionalidades Admin General*/
INSERT INTO LOS_SINEQUI.Rol_Funcionalidad (id_rol, id_func)
VALUES
	(4,1),
	(4,2),
	(4,3),
	(4,4),
	(4,5),
	(4,6),
	(4,7),
	(4,8),
	(4,9)

INSERT INTO LOS_SINEQUI.Ofertas (descripcion, fecha_pub, fecha_vec, username, precio_rebajado, precio_lista, stock, max_cliente)
	SELECT DISTINCT	Oferta_Descripcion, 
			Oferta_Fecha, 
			Oferta_Fecha_Venc, 
			CONCAT(	SUBSTRING(Provee_CUIT,1, 2), SUBSTRING(Provee_CUIT,4,8), SUBSTRING(Provee_CUIT, 13,13)), 
			Oferta_Precio, 
			Oferta_Precio_Ficticio, 
			sum(Oferta_Cantidad), 
			sum(Oferta_Cantidad) 
	FROM gd_esquema.Maestra
	WHERE Oferta_Descripcion is not null 
	GROUP BY Oferta_Descripcion, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Precio, Oferta_Precio_Ficticio,Provee_CUIT   


INSERT INTO LOS_SINEQUI.Cupones ( username, fecha_compra, id_oferta, fecha_entrega, codigo_legacy, facturado)
	SELECT DISTINCT 
					Cli_Dni,
					Oferta_Fecha_Compra,
					id_oferta,
					Oferta_Entregado_Fecha,
					Oferta_Codigo,
					0
					FROM LOS_SINEQUI.Ofertas o
			JOIN gd_esquema.Maestra m ON
				o.descripcion = m.Oferta_Descripcion
				AND m.Oferta_Fecha = o.fecha_pub 
				AND m.Oferta_Fecha_Venc = o.fecha_vec 
				AND CONCAT(	SUBSTRING(Provee_CUIT,1, 2), SUBSTRING(Provee_CUIT,4,8), SUBSTRING(Provee_CUIT, 13,13)) =  o.username
				AND o.precio_lista = m.Oferta_Precio_Ficticio
				AND o.precio_rebajado = m.Oferta_Precio 
				GROUP BY Oferta_Codigo, Oferta_Fecha_Compra, Cli_Dni, id_oferta, Oferta_Entregado_Fecha
				HAVING Oferta_Codigo IS NOT NULL


INSERT INTO LOS_SINEQUI.Facturas (fecha,username,monto)
	SELECT DISTINCT Factura_Fecha, CONCAT(	SUBSTRING(Provee_CUIT,1, 2), SUBSTRING(Provee_CUIT,4,8), SUBSTRING(Provee_CUIT, 13,13)),0 
	FROM gd_esquema.Maestra
	WHERE Factura_Nro IS NOT NULL AND Factura_Fecha IS NOT NULL
	ORDER BY 1 ASC


INSERT INTO LOS_SINEQUI.Renglones (id_factura,id_oferta,cant)
	SELECT Factura_Nro, id_oferta, count(Oferta_Codigo)
	FROM gd_esquema.Maestra
	JOIN LOS_SINEQUI.Cupones c ON
		Oferta_Codigo = c.codigo_legacy
	WHERE Factura_Nro is not null
	GROUP BY  Factura_Nro, id_oferta

	
UPDATE LOS_SINEQUI.Facturas SET monto = montoF
	FROM (
		SELECT Renglones.id_factura as id_factura, SUM(0.1*(Ofertas.precio_rebajado * Renglones.cant)) as montoF
			FROM LOS_SINEQUI.Renglones
			JOIN LOS_SINEQUI.Ofertas
			ON Ofertas.id_oferta = Renglones.id_oferta
			Group by Renglones.id_factura
	) Montos WHERE Facturas.id_factura = Montos.id_factura


UPDATE LOS_SINEQUI.Cupones SET facturado = 1
	FROM(SELECT Oferta_Codigo as codigo FROM gd_esquema.Maestra WHERE Factura_Nro IS NOT NULL) facturados
	WHERE facturados.codigo = Cupones.codigo_legacy


ALTER TABLE LOS_SINEQUI.Cupones DROP COLUMN codigo_legacy


INSERT INTO LOS_SINEQUI.Usuarios (username,password,habilitado)
VALUES				 ('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',1 )	--Hash de w23e

INSERT INTO LOS_SINEQUI.Rol_Usuario (id_rol,username,habilitado)
VALUES					(4,'admin',1)
GO

CREATE TRIGGER tr_actualizarStock ON LOS_SINEQUI.Cupones AFTER INSERT AS BEGIN TRANSACTION
	UPDATE LOS_SINEQUI.Ofertas SET stock = stock - 1 WHERE id_oferta = (SELECT id_oferta FROM inserted)
COMMIT
GO

