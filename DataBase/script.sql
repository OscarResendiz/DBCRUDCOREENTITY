create database DBCRUDCOREENTITY
GO
USE DBCRUDCOREENTITY
GO
CREATE TABLE Cargo
(
	IdCargo int primary key identity,
	Descripcion varchar (50)
)
go
create table Empleado
(
	IdEmpleado int primary key identity,
	NombreCompleto varchar(60),
	Correo varchar(60),
	Telefono varchar(60),
	IdCargo int,
	constraint fk_Cargo foreign key(IdCargo) references Cargo
)
go

insert into cargo(Descripcion) values ('Asistente de ventas'),('Diseño de marketing'),('atencion a clientes')
go
insert into Empleado(NombreCompleto,Correo,Telefono,IdCargo) values('Jose perez','jose@email.com','5678956',1)
go
SELECT * FROM Cargo
go
select * from Empleado
go