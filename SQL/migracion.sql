IF OBJECT_ID('dbo.Clientes', 'U') IS NOT NULL
	DROP TABLE dbo.Clientes;
CREATE TABLE Clientes (
	username VARCHAR(255),
	nombre VARCHAR(255),
	apellido VARCHAR(255),
	DNI CHAR(8),
	mail VARCHAR(255),
	telefono NUMERIC,
	id_direccion NUMERIC,
	fecha_nac DATETIME,
	credito DECIMAL(12, 2),
	habilitado BIT
)