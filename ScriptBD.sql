
DROP database IF EXISTS Restaurant
go

Create Database Restaurant
GO

Use Restaurant
Go

Create Table Perfiles
(
    ID tinyint Primary Key Identity(1,1),
    Nombre Varchar(20) Not Null
)

Create Table Paises
(
    ID int Primary Key Identity (1, 1),
    Nombre Varchar(20) Not Null
)

Create Table Usuarios(
    Legajo Int Primary Key Identity(1,1),
    Contraseña varchar(10) Not Null,
    Dni varchar(15) Unique Not Null Check (DNI > 10000000),
    Nombre varchar(40),
    Apellidos varchar(40) Not Null,
    Telefono varchar(20) Not Null,
    Email varchar(40) Not Null,
    Calle varchar(40) Not Null,
    Numero varchar(5) Not Null Check (Numero > 0),
    Piso varchar(5) Null Check (Piso > 0),
    Departamento char(1) Null,
    IDNacionalidad int Not Null Foreign Key References Paises(ID),
    TipoPerfil tinyint Not Null Foreign Key References Perfiles(ID),
    FechaNac date Not Null,
    FechaRegistro date Not Null,
	UrlImagen varchar(max) Not Null Default ('https://static.vecteezy.com/system/resources/previews/000/439/863/non_2x/vector-users-icon.jpg'),
    Estado bit Not Null Default (1)
)

Create Table Mesas(
    ID Int Not Null Primary Key Identity(1,1),
    MeseroAsignado Int Null Foreign Key References Usuarios(Legajo),
    Numero Int Not Null,
    Capacidad Int Not Null,
    Ocupado Bit Not Null Default(0),
    Activo Bit Not Null Default(1)
)

Create table TipoInsumo(
Id int primary key identity(1,1),
Nombre varchar(150),
Activo bit not null default 1
)
go

Create table Marcas(
Id int primary key identity(1,1),
Nombre varchar(max),
Activo bit not null default 1
)
go

create table TipoPlatos(
Id int primary key identity(1,1),
Nombre varchar(150),
Activo bit not null default 1
)

Create table Insumos(
Id int primary key identity(1,1),
Nombre varchar(150),
Precio money,
IdTipoInsumo int foreign key references TipoInsumo(Id) not null,
Capacidad float,
IdTipoPlato int foreign key references TipoPlatos(Id) null,
Marca int foreign key references Marcas(Id) null,
Alcoholica bit default 0,
Activo bit not null default 1
)
Go

Create table Pedidos (
Id int primary key identity(1,1),
IdMesa int foreign key references Mesas(Id) not null,
LegajoMeseroAsignado int foreign key references Usuarios(Legajo) not null,
Fecha Date Not Null,
Entregado bit not null default 0,
Total money not null
)
GO

Create table DetallePedidos (
Id int primary key identity(1,1),
IdPedido int foreign key references Pedidos(Id),
IdInsumo int foreign key references Insumos(Id),
Cantidad int not null,
PrecioUnitario money not null
)
GO

-- Store Procedures

Create Procedure SpListarInsumos
As
Begin
Select i.Id, i.Nombre, Precio, ti.Nombre As Tipo,
m.Nombre As Marca
From Insumos i
Inner join TipoInsumo ti
On i.IdTipoInsumo = ti.Id
Left Join Marcas m
On i.Id = m.Id
Where i.Activo = 1
end
Go 

Create Procedure SpListarUsuarios
As 
Begin 
Select 
    U.Legajo,
    U.Apellidos,
    U.Nombre,
    U.Dni,
    P.Nombre as Pais,
    U.TipoPerfil,
    U.Telefono,
    U.Email,
    U.Calle,
    U.Numero,
    U.Piso,
    CONVERT(VARCHAR(10),U.FechaNac ,103) AS FechaNac,
    CONVERT(VARCHAR(10),U.FechaRegistro ,103) AS FechaRegistro,
	U.UrlImagen,
    U.Estado
From Usuarios U Inner Join Paises P On U.IDNacionalidad = P.ID
End
Go 

Create Procedure SpListarMesas 
As
Begin
Select 
    M.Numero, 
    U.Legajo, 
    Coalesce(U.Apellidos, 'S/ Mesero'),
    Coalesce(U.Nombre, 'S/ Mesero'),
    M.Capacidad, 
    M.Ocupado,
    M.Activo,
	M.ID
From Mesas M 
Left Join Usuarios U On M.MeseroAsignado = U.Legajo
End
Go

Create Procedure SpListarMesasPorMesero
(
	@Legajo int
)
As
Begin
Select 
    M.Numero, 
    U.Legajo, 
    Coalesce(U.Apellidos, 'S/ Mesero'),
    Coalesce(U.Nombre, 'S/ Mesero'),
    M.Capacidad, 
    M.Ocupado,
    M.Activo,
	M.ID
From Mesas M 
Inner Join Usuarios U On M.MeseroAsignado = U.Legajo
Where M.MeseroAsignado = @Legajo
End
Go

Create Procedure SpListarMesasActivas
As
Begin
Select 
    M.Numero, 
    U.Legajo, 
    U.Apellidos, 
    U.Nombre,
    M.Capacidad, 
    M.Ocupado,
    M.Activo,
	M.ID
From Mesas M 
Inner Join Usuarios U On M.MeseroAsignado = U.Legajo
Where M.Activo = 1
End
Go


Create Procedure SpListarPaises
As
Begin 
Select P.ID, P.Nombre from Paises P
End 
Go

Create Procedure SpListarTiposPlato
as
Begin
Select Id, Nombre, Activo from TipoPlatos
End
go

Create Procedure SpListarPlatos
as
begin

Select I.Id, I.Nombre, I.Precio, I.Activo,  
TP.Id AS IdTipoPlato, TP.Nombre AS TipoPlato
from Insumos I
inner join TipoInsumo TI
on I.IdTipoInsumo = TI.Id
left join TipoPlatos TP
on I.IdTipoPlato = TP.Id
where ti.Id = 2
and i.Activo = 1

end
go


create Procedure SpBuscarPlatoPorId(@id int)
as
begin

Select I.Id, I.Nombre, I.Precio, I.Activo,  
TP.Id AS IdTipoPlato, TP.Nombre AS TipoPlato
from Insumos I
inner join TipoInsumo TI
on I.IdTipoInsumo = TI.Id
inner join TipoPlatos TP
on I.IdTipoPlato = TP.Id
where i.id = @id
and ti.Id = 2

end
go


Create Procedure SpNuevoUsuario
(
	@Contraseña Varchar(10),
	@Dni Varchar(15),
	@Apellido Varchar(40),
	@Nombre Varchar(40),
	@Telefono Varchar(20),
	@Email Varchar(40),
	@Calle Varchar(40),
	@Numero Varchar(5),
	@Piso Varchar(5),
	@Dpto char(1),
	@IDNacionalidad int,
	@TipoPerfil tinyint,
	@FechaNac date,
	@UrlImagen Varchar(max)
)
As
Begin
	Begin Try
	Begin Transaction
		Insert Into Usuarios (Contraseña, Dni, Apellidos, Nombre, Telefono, Email, Calle, Numero, Piso, Departamento, IDNacionalidad, TipoPerfil, FechaNac, FechaRegistro, UrlImagen, Estado)
		Values (@Contraseña, @Dni, @Apellido, @Nombre, @Telefono, @Email, @Calle, @Numero, @Piso, @Dpto, @IDNacionalidad, @TipoPerfil, @FechaNac, Getdate(), @UrlImagen, 1)
		Commit Transaction
	End Try
	Begin Catch
		Raiserror('Error al cargar usuario', 16, 1)
		Rollback 
	End Catch
End
Go

create View VW_ListaUsuarios as(
Select 
    U.Legajo,
	U.Contraseña,
    U.Apellidos,
    U.Nombre,
    U.Dni,
    P.ID as Pais,
    U.TipoPerfil,
    U.Telefono,
    U.Email,
    U.Calle,
    U.Numero,
    U.Piso,
    CONVERT(VARCHAR(10),U.FechaNac ,103) AS FechaNac,
    CONVERT(VARCHAR(10),U.FechaRegistro ,103) AS FechaRegistro,
	U.UrlImagen,
    U.Estado
From Usuarios U Inner Join Paises P On U.IDNacionalidad = P.ID)
GO

Create Procedure SpModificarUsuario
(
	@Legajo int,
	@Contraseña Varchar(10),
	@Dni Varchar(15),
	@Apellido Varchar(40),
	@Nombre Varchar(40),
	@Telefono Varchar(20),
	@Email Varchar(40),
	@Calle Varchar(40),
	@Numero Varchar(5),
	@Piso Varchar(5),
	@Dpto char(1),
	@IDNacionalidad int,
	@TipoPerfil tinyint,
	@FechaNac date,
	@UrlImagen Varchar(max)
)
As
Begin
	Begin Try
	Begin Transaction
		Update Usuarios set Contraseña = @Contraseña, Dni = @Dni, Apellidos = @Apellido, Nombre = @Nombre, Telefono = @Telefono, Email = @Email, Calle = @Calle, Numero = @Numero, Piso = @Piso, Departamento = @Dpto, IDNacionalidad = @IDNacionalidad, FechaNac = @FechaNac, UrlImagen = @UrlImagen where Legajo = @Legajo
		Commit Transaction
	End Try
	Begin Catch
		Raiserror('Error al modificar usuario', 16, 1)
		Rollback 
	End Catch
End
Go

Create Procedure SpEliminarUsuario(
	@Legajo int
)
As
Begin
	Begin Try
	Begin Transaction
		Update Mesas Set MeseroAsignado = Null Where MeseroAsignado = @Legajo
		Update Usuarios Set Estado = 0 where Legajo = @Legajo
		Commit Transaction
	End Try
	Begin Catch
		Raiserror('Error al eliminar usuario', 16, 1)
		Rollback 
	End Catch
End
Go

-- Pedidos --
create Procedure SpAgregarPedido(
 @IdMesa int,
 @LegajoMeseroAsignado int)
As
Begin 
	BEGIN TRY
	BEGIN TRAN
		INSERT INTO PEDIDOS (IdMesa, LegajoMeseroAsignado, Fecha, Entregado, Total)
		output inserted.Id   
		values (@IdMesa, @LegajoMeseroAsignado, GETDATE(), 0, 0)

		UPDATE Mesas SET Ocupado = 1
		Where ID = @IdMesa
	COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH

End
Go

Create procedure SpEliminarPedido (@IdPedido int)
as 
begin

	begin try
		begin tran
			Delete From DetallePedidos where IdPedido = @IdPedido
			Delete From Pedidos where Id = @IdPedido
		commit tran
	end try

	begin catch
		rollback tran
	end catch
end
go

Create Procedure SpListarMeseros
As
Begin
Select * From Usuarios Where TipoPerfil = 2
End
Go

Create Procedure SpAgregarMesa 
(
	@NumMesa int,
	@LegajoMeseroAsignado int,
	@Capacidad int,
	@Ocupado bit
)
As
Begin
	Insert into Mesas (Numero, MeseroAsignado, Capacidad, Ocupado) Values (@NumMesa, @LegajoMeseroAsignado, @Capacidad, @Ocupado)
End
Go

Create Procedure SpEditarMesa 
(
	@NumMesa int,
	@LegajoMeseroAsignado int,
	@Capacidad int,
	@Ocupado bit
)
As
Begin
	Update Mesas Set MeseroAsignado = @LegajoMeseroAsignado, Capacidad = @Capacidad, Ocupado = @Ocupado Where Numero = @NumMesa
End
Go

Create Proc SpObtenerMesaPorNumero 
(
	@NumeroMesa int
)
As
Begin 
	Select   
    M.Numero,   
    U.Legajo,   
    U.Apellidos,  
    U.Nombre, 
    M.Capacidad,   
    M.Ocupado,
    M.Activo,  
    M.ID  
From Mesas M   
Inner Join Usuarios U On M.MeseroAsignado = U.Legajo  
where M.Numero = @NumeroMesa
End
Go

-- REPORTES --

CREATE VIEW V_REPORTE_MESEROS
AS
	SELECT Legajo,
	NOMBRE + ' ' + Apellidos AS Mesero, 
	P.Fecha AS FechaPedidos,
	COUNT(P.Id) AS TotalPedidos,
	SUM(P.Total) AS TotalRecaudado
	 FROM Pedidos P
	INNER JOIN Usuarios U
	ON P.LegajoMeseroAsignado = U.Legajo
	WHERE U.TipoPerfil = 2
	GROUP BY U.Legajo, U.Nombre, U.Apellidos, P.Fecha
GO


CREATE VIEW V_REPORTE_MESAS
AS
	SELECT M.Numero AS NumeroMesa,
	P.Fecha AS FechaPedidos,
	COUNT(P.Id) AS TotalPedidos,
	SUM(P.Total) AS TotalRecaudado
	 FROM Pedidos P
	INNER JOIN Mesas M
	ON P.IdMesa =  M.ID
	GROUP BY M.ID, M.Numero, P.Fecha
GO