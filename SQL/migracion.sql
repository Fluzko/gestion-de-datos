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
GO

----USUARIO----
CREATE TABLE Usuarios (
	username NVARCHAR(255) PRIMARY KEY,
	password NVARCHAR(255) NOT NULL,
	habilitado BIT DEFAULT 1
)


----CIUDADES----
CREATE TABLE Ciudades (
	id_ciudad INTEGER PRIMARY KEY IDENTITY(1, 1),
	nombre NVARCHAR(255) NOT NULL UNIQUE
)


----DIRECCIONES----
CREATE TABLE Direcciones (
	id_direccion INTEGER PRIMARY KEY IDENTITY(1, 1),
	direccion NVARCHAR(255) NOT NULL,
	cp NVARCHAR(5),
	piso NVARCHAR(2),
	dpto NVARCHAR(2),
	ciudad INTEGER FOREIGN KEY REFERENCES Ciudades NOT NULL
)

----CLIENTES----
CREATE TABLE Clientes (
	username NVARCHAR(255) PRIMARY KEY FOREIGN KEY REFERENCES Usuarios,
	nombre NVARCHAR(255) NOT NULL,
	apellido NVARCHAR(255) NOT NULL,
	dni INTEGER NOT NULL,
	mail NVARCHAR(255),
	telefono INTEGER,
	id_direccion INTEGER FOREIGN KEY REFERENCES Direcciones,
	fecha_nac DATETIME NOT NULL,
	credito DECIMAL(12, 2) DEFAULT 0,
	habilitado BIT DEFAULT 1
)

----RUBROS----
CREATE TABLE Rubros (
	id_rubro INTEGER PRIMARY KEY IDENTITY(1, 1),
	nombre NVARCHAR(255) UNIQUE NOT NULL,
	habilitado BIT DEFAULT 1
)



----PROVEEDORES----
CREATE TABLE Proveedores (
	username NVARCHAR(255) PRIMARY KEY FOREIGN KEY REFERENCES Usuarios,
	razon_social NVARCHAR(255) NOT NULL UNIQUE,
	telefono INTEGER,
	mail NVARCHAR(255),
	id_direccion INTEGER FOREIGN KEY REFERENCES Direcciones,
	cuit NCHAR(13) NOT NULL UNIQUE,
	rubro INTEGER FOREIGN KEY REFERENCES Rubros NOT NULL,
	nombre_contacto VARCHAR(255),
	habilitado BIT DEFAULT 1
)


----ROLES----
CREATE TABLE Roles (
	id_rol INTEGER PRIMARY KEY IDENTITY(1, 1),
	nombre NVARCHAR(255) UNIQUE NOT NULL,
	habilitado BIT DEFAULT 1
)

----ROL_USUARIO----
CREATE TABLE Rol_Usuario (
	id_rol INTEGER FOREIGN KEY REFERENCES Roles,
	username NVARCHAR(255) FOREIGN KEY REFERENCES Usuarios,	
	habilitado BIT DEFAULT 1,
	PRIMARY KEY (id_rol, username)
) 

----FUNCIONALIDADES----
CREATE TABLE Funcionalidades (
	id_func INTEGER PRIMARY KEY IDENTITY(1, 1),
	nombre NVARCHAR(255) UNIQUE NOT NULL,
	descripcion NVARCHAR(255) DEFAULT 'Sin descripcion',
	habilitado BIT DEFAULT 1
)

----ROL_FUNCIONALIDAD----
CREATE TABLE Rol_Funcionalidad (
	id_rol INTEGER FOREIGN KEY REFERENCES ROLES,
	id_func INTEGER FOREIGN KEY REFERENCES Funcionalidades,
	PRIMARY KEY (id_rol, id_func)
)

----TIPOS_PAGO----
CREATE TABLE TiposPago (
	id_tipo INTEGER PRIMARY KEY IDENTITY(1, 1),
	nombre NVARCHAR(255) UNIQUE NOT NULL
)

----TARJETAS----
CREATE TABLE Tarjetas (
	numero NCHAR(16) PRIMARY KEY,
	vencimiento DATE NOT NULL,
	titular NCHAR(20) NOT NULL,
	codigo_verif NCHAR(3) NOT NULL
)

----CARGAS----
CREATE TABLE Cargas (
	id_carga INTEGER PRIMARY KEY IDENTITY(1, 1),
	username NVARCHAR(255) FOREIGN KEY REFERENCES Clientes NOT NULL,
	tipo_pago INTEGER FOREIGN KEY REFERENCES TiposPago NOT NULL,
	fecha DATETIME NOT NULL,
	monto DECIMAL(12,2) NOT NULL DEFAULT 0,
	tarjeta_num NCHAR(16) FOREIGN KEY REFERENCES Tarjetas
)

----OFERTAS----
CREATE TABLE Ofertas (
	id_oferta INTEGER PRIMARY KEY IDENTITY(1, 1),
	descripcion NVARCHAR(255) NOT NULL,
	fecha_pub DATE NOT NULL,
	fecha_vec DATE NOT NULL,
	username NVARCHAR(255) FOREIGN KEY REFERENCES Proveedores NOT NULL,
	precio_rebajado DECIMAL(12,2) NOT NULL,
	precio_lista DECIMAL(12,2) NOT NULL,
	stock INTEGER NOT NULL,
	max_cliente INTEGER NOT NULL
)


----CUPONES----
CREATE TABLE Cupones (
	id_cupon INTEGER PRIMARY KEY IDENTITY(1,1),
	username NVARCHAR(255) FOREIGN KEY REFERENCES Clientes NOT NULL,
	id_oferta INTEGER FOREIGN KEY REFERENCES Ofertas NOT NULL,
	fecha_compra DATETIME NOT NULL,
	fecha_entrega DATETIME,
	codigo_legacy NVARCHAR(255),
	facturado BIT NOT NULL DEFAULT 0
)


----FACTURAS----
CREATE TABLE Facturas (
	id_factura INTEGER PRIMARY KEY IDENTITY(153131,1),
	monto DECIMAL(12, 2) NOT NULL,
	username NVARCHAR(255) FOREIGN KEY REFERENCES Proveedores NOT NULL,
	fecha DATETIME NOT NULL
)

----RENGLONES----
CREATE TABLE Renglones (
	id_factura INTEGER FOREIGN KEY REFERENCES Facturas,
	id_oferta INTEGER FOREIGN KEY REFERENCES Ofertas,
	cant NUMERIC NOT NULL DEFAULT 1
)
GO

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

INSERT INTO Ciudades(nombre) 
	SELECT DISTINCT Cli_Ciudad FROM gd_esquema.Maestra

INSERT INTO Direcciones (direccion,ciudad,cp,dpto,piso)
	SELECT DISTINCT m.Cli_Direccion, c.id_ciudad, '-', '-', '-' FROM gd_esquema.Maestra m
	JOIN Ciudades c ON c.nombre = m.Cli_Ciudad
	

INSERT INTO Clientes (username, nombre, apellido, dni, mail, telefono, fecha_nac, habilitado,id_direccion)
	SELECT DISTINCT Cli_Dni, UPPER(Cli_Nombre), UPPER(Cli_Apellido), Cli_Dni, Cli_Mail, Cli_Telefono, Cli_Fecha_Nac, 1, d.id_direccion
		FROM gd_esquema.Maestra
		JOIN Direcciones d ON Cli_Direccion = d.direccion
		JOIN Ciudades c ON d.ciudad = c.id_ciudad
		WHERE Cli_Nombre IS NOT NULL AND Cli_Apellido IS NOT NULL

UPDATE Clientes SET habilitado = 0
WHERE mail like '% %'

INSERT INTO Usuarios (username, password, habilitado)
	SELECT DISTINCT CONCAT(	SUBSTRING(Provee_CUIT,1, 2),
							SUBSTRING(Provee_CUIT,4,8),
							SUBSTRING(Provee_CUIT, 13,13)), 
					'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', --Hash de 1234
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
  ('Administrador',1)


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
	(1,6)

/*Funcionalidades proveedor*/
INSERT INTO Rol_Funcionalidad (id_rol, id_func)
VALUES
	(2,5),
	(2,7)

/*Funcionalidades Admin*/
INSERT INTO Rol_Funcionalidad (id_rol, id_func)
VALUES
	(3,1),
	(3,2),
	(3,3),
	(3,8),
	(3,9)


INSERT INTO Ofertas (descripcion, fecha_pub, fecha_vec, username, precio_rebajado, precio_lista, stock, max_cliente)
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


INSERT INTO Cupones ( username, fecha_compra, id_oferta, fecha_entrega, codigo_legacy, facturado)
	SELECT DISTINCT 
					Cli_Dni,
					Oferta_Fecha_Compra,
					id_oferta,
					Oferta_Entregado_Fecha,
					Oferta_Codigo,
					0
					FROM Ofertas o
			JOIN gd_esquema.Maestra m ON
				o.descripcion = m.Oferta_Descripcion
				AND m.Oferta_Fecha = o.fecha_pub 
				AND m.Oferta_Fecha_Venc = o.fecha_vec 
				AND CONCAT(	SUBSTRING(Provee_CUIT,1, 2), SUBSTRING(Provee_CUIT,4,8), SUBSTRING(Provee_CUIT, 13,13)) =  o.username
				AND o.precio_lista = m.Oferta_Precio_Ficticio
				AND o.precio_rebajado = m.Oferta_Precio 
				GROUP BY Oferta_Codigo, Oferta_Fecha_Compra, Cli_Dni, id_oferta, Oferta_Entregado_Fecha
				HAVING Oferta_Codigo IS NOT NULL


INSERT INTO Facturas (fecha,username,monto)
	SELECT DISTINCT Factura_Fecha, CONCAT(	SUBSTRING(Provee_CUIT,1, 2), SUBSTRING(Provee_CUIT,4,8), SUBSTRING(Provee_CUIT, 13,13)),0 
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


ALTER TABLE Cupones DROP COLUMN codigo_legacy


INSERT INTO Usuarios (username,password,habilitado)
VALUES				 ('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',1 )	--Hash de w23e

INSERT INTO Rol_Usuario (id_rol,username,habilitado)
VALUES					(3,'admin',1)
GO

CREATE TRIGGER tr_actualizarStock ON Cupones AFTER INSERT AS BEGIN TRANSACTION
	UPDATE Ofertas SET stock = stock - 1 WHERE id_oferta = (SELECT id_oferta FROM inserted)
COMMIT
GO

select * from Clientes order by id_direccion

/*
insert into Usuarios (username,password,habilitado) values('facundo','facu',1)
insert into Direcciones (ciudad,cp,direccion,dpto,piso) values (1,1822,'veracruz 2455','a',1)
insert into Clientes (username,nombre,apellido,dni,mail,telefono,id_direccion,fecha_nac,credito,habilitado)
values ('facundo', 'Facundo','Luzko',40571956,'fluzko@gmail.com',1167672254,1,'2013-10-10',200.00,1)
select * from Clientes
*/

/*
SELECT	c.nombre, c.apellido, c.dni, c.mail, c.telefono, d.direccion, d.cp, d.piso, d.dpto, ci.nombre, c.fecha_nac, c.credito
                   FROM Clientes c 
                   JOIN Direcciones d ON c.id_direccion = d.id_direccion 
                   JOIN Ciudades ci ON ci.id_ciudad = d.ciudad
                   WHERE c.habilitado = 1 AND c.nombre LIKE 	 
				   select * from Clientes
	
	update Clientes SET habilitado = 'false' where username = 'facundo'
*/