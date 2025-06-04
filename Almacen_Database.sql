USE master;
GO
if exists(select * from sysdatabases where name='MiAlmacen')
drop database MiAlmacen
go

create database MiAlmacen;
go
use MiAlmacen;
go


CREATE TABLE Usuarios(
ID_USUARIO int primary key identity(250,5)  not null,
NOMBRE nvarchar(50)not null,
CONTRASEÑA nvarchar(50) not null,
ROL nvarchar(50) not null,
PREGUNTA nvarchar(50)not null,
RESPUESTA nvarchar (50)not null
);


CREATE TABLE Clientes(
ID_CLIENTE int primary key identity not null,
NOMBRE nvarchar (50) not null
CONSTRAINT UC_Cliente_trasa UNIQUE (NOMBRE)
);


CREATE TABLE Productos(
ID_PRODUCTO int primary key identity(2550,100) not null,
PRODUCTO nvarchar(50) not null,
PRECIO int not null,
STOCK int not null,
CONSTRAINT UC_Productos_Producto UNIQUE (PRODUCTO)
);

CREATE TABLE Transaccion(
ID_TRANSACCION int primary key identity(15825,5) not null,
FECHA nvarchar (50) not null,
ID_CLIENTE int not null,
NOMBRE NVARCHAR(50) not null,
ID_PRODUCTO int not null,
NOMBRE_PRODUCTO nvarchar (50) not null,
CANTIDAD int not null,
TOTAL int not null,
foreign key (ID_CLIENTE) references Clientes(ID_CLIENTE),
foreign key (ID_PRODUCTO) references Productos(ID_PRODUCTO),
foreign key (NOMBRE_PRODUCTO) references Productos(PRODUCTO),
foreign key (NOMBRE) references Clientes(NOMBRE)
);

INSERT INTO Usuarios (NOMBRE,CONTRASEÑA, ROL, PREGUNTA, RESPUESTA)
VALUES ('Julio','1234', 'ADMINISTRADOR', 'MASCOTA', 'FIDO'),
('Caliche','1234','CAJERO','NOMBRE MADRE','CLAUDIA'),
('Adrian','1234','CAJERO','COLOR','AZUL');

INSERT INTO Clientes (NOMBRE)
VALUES('Ana'),
('Andrea'),
('Sara'),
('Camila'),
('Lorena');


INSERT INTO Productos (PRODUCTO, PRECIO, STOCK)
VALUES ('POLVO AME', 15000, 60),
('CORRECTOR OJERAS', 9000, 40),
('AGUA DE ROSAS',5000,30),
('ILUMINADOR',13000,80),
('TINTA DE LABIOS',4000,50),
('PESTAÑINA',24000,25),
('SHANPO PANTENE',13000,30),
('TINTE DE PELO',18000,60),
('BARNIZ VOGE',5000,45);

ALTER TABLE Transaccion NOCHECK CONSTRAINT ALL;
DECLARE @id_cliente int,@Nombre NVARCHAR(50),@Producto NVARCHAR(50), @id_producto int, @cantidad int, @total MONEY
SET @id_cliente = (SELECT ID_CLIENTE FROM Clientes WHERE NOMBRE = 'Ana')
SET @Nombre = (SELECT NOMBRE FROM Clientes WHERE ID_CLIENTE = @id_cliente);
SET @id_producto = (SELECT ID_PRODUCTO FROM Productos WHERE PRODUCTO = 'AGUA DE ROSAS')
SET @Producto = (SELECT PRODUCTO FROM Productos WHERE ID_PRODUCTO = @id_producto)
SET @cantidad = 2
SET @total = @cantidad * (SELECT PRECIO FROM Productos WHERE ID_PRODUCTO = @id_producto)

INSERT INTO Transaccion (FECHA, ID_CLIENTE,NOMBRE, ID_PRODUCTO, NOMBRE_PRODUCTO,CANTIDAD, TOTAL)
VALUES ('20-04-2023', @id_cliente,@Nombre, @id_producto,@Producto, @cantidad, @total)
ALTER TABLE Transaccion CHECK CONSTRAINT ALL;

ALTER TABLE Transaccion NOCHECK CONSTRAINT ALL;
DECLARE @id_cliente2 int,@Nombre2 NVARCHAR(50),@Producto2 NVARCHAR(50), @id_producto2 int, @cantidad2 int, @total2 MONEY
SET @id_cliente2 = (SELECT ID_CLIENTE FROM Clientes WHERE NOMBRE = 'Andrea')
SET @Nombre2 = (SELECT NOMBRE FROM Clientes WHERE ID_CLIENTE = @id_cliente2);
SET @id_producto2 = (SELECT ID_PRODUCTO FROM Productos WHERE PRODUCTO = 'TINTE DE PELO')
SET @Producto2 = (SELECT PRODUCTO FROM Productos WHERE ID_PRODUCTO = @id_producto2)
SET @cantidad2 = 4
SET @total2 = @cantidad * (SELECT PRECIO FROM Productos WHERE ID_PRODUCTO = @id_producto2)

INSERT INTO Transaccion (FECHA, ID_CLIENTE,NOMBRE, ID_PRODUCTO, NOMBRE_PRODUCTO,CANTIDAD, TOTAL)
VALUES ('23-04-2023', @id_cliente2,@Nombre2, @id_producto2,@Producto2, @cantidad2, @total2)
ALTER TABLE Transaccion CHECK CONSTRAINT ALL;


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[AsistenteVista]
AS
SELECT dbo.Clientes.ID_CLIENTE, dbo.Clientes.NOMBRE, dbo.Productos.ID_PRODUCTO, dbo.Transaccion.ID_TRANSACCION, dbo.Transaccion.FECHA, dbo.Productos.PRODUCTO, dbo.Transaccion.TOTAL, dbo.Productos.PRECIO
FROM     dbo.Clientes INNER JOIN
                  dbo.Transaccion ON dbo.Clientes.ID_CLIENTE = dbo.Transaccion.ID_CLIENTE AND dbo.Clientes.NOMBRE = dbo.Transaccion.NOMBRE INNER JOIN
                  dbo.Productos ON dbo.Transaccion.ID_PRODUCTO = dbo.Productos.ID_PRODUCTO AND dbo.Transaccion.NOMBRE_PRODUCTO = dbo.Productos.PRODUCTO
GO

--/*

--Select *from Usuarios
--Select *from Clientes
--Select *from Productos
--Select *from Transaccion
--*/
--Select *from Productos
--Select *from Transaccion



--ALTER TABLE Transaccion NOCHECK CONSTRAINT ALL;

--UPDATE Productos SET PRODUCTO = 'TINTE' WHERE ID_PRODUCTO = (SELECT ID_PRODUCTO FROM Productos WHERE PRODUCTO = 'TINTE DE PELO');

--UPDATE Transaccion SET NOMBRE_PRODUCTO = 'TINTE' WHERE ID_PRODUCTO = (SELECT ID_PRODUCTO FROM Productos WHERE PRODUCTO = 'TINTE DE PELO');

--ALTER TABLE Transaccion CHECK CONSTRAINT ALL;

--SELECT *FROM Productos WHERE ID_PRODUCTO =

--Select *from Usuarios