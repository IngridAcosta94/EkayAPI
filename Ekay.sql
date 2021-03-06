create database Ekay1
go

use Ekay1
go

CREATE TABLE Empresa (
 Id INT NOT NULL IDENTITY(1,1),
 Nombre VARCHAR(100),
 NombreRepresentante Varchar (100),
 Direccion VARCHAR(100),
 Correo VARCHAR(50),
 Telefono Varchar(10),
 CreateAt datetime,
 CreatedBy int,
 UpdateAt datetime,
 UpdateBy int


);

ALTER TABLE Empresa ADD CONSTRAINT PK_Empresa PRIMARY KEY (Id);


CREATE TABLE Autor (
 Id INT NOT NULL IDENTITY(1,1),
 NombreA VARCHAR(100),
 ApellidoA VARCHAR (100),
 CorreoA VARCHAR (50),
 CreateAt datetime,
 CreatedBy int,
 UpdateAt datetime,
 UpdateBy int
);

ALTER TABLE Autor ADD CONSTRAINT PK_Autor PRIMARY KEY (Id);


CREATE TABLE Carpeta (
 Id INT NOT NULL IDENTITY(1,1),
 Nombre VARCHAR(100),
 FechaCreacion datetime,
 EmpresaId INT NOT NULL,
 CreateAt datetime,
 CreatedBy int,
 UpdateAt datetime,
 UpdateBy int
);

ALTER TABLE Carpeta ADD CONSTRAINT PK_Carpeta PRIMARY KEY (Id);


CREATE TABLE Remitente (
 Id INT NOT NULL IDENTITY(1,1),
 Nombre VARCHAR (100),
 Apellido VARCHAR (100),
 Correo VARCHAR (50),
 Telefono VARCHAR (10),
 CreateAt datetime,
 CreatedBy int,
 UpdateAt datetime,
 UpdateBy int

 );

ALTER TABLE Remitente ADD CONSTRAINT PK_Remitente PRIMARY KEY (Id);


CREATE TABLE TipoDocumento (
 Id INT NOT NULL IDENTITY(1,1),
 NombreDoc VARCHAR(100),
 CreateAt datetime,
 CreatedBy int,
 UpdateAt datetime,
 UpdateBy int
 
);

ALTER TABLE TipoDocumento ADD CONSTRAINT PK_TipoDocumento PRIMARY KEY (Id);


CREATE TABLE Documento (
 Id INT NOT NULL IDENTITY(1,1),
 FechaCreacion datetime,
 Contenido VARCHAR(300),
 RemitenteId INT NOT NULL,
 AutorId INT NOT NULL,
 CarpetaId INT NOT NULL,
 TipoDocId INT NOT NULL,
 FirmanteId Int NOT NULL,
 CreateAt datetime,
 CreatedBy int,
 UpdateAt datetime,
 UpdateBy int,
 NombreArchivo Varchar(50),
 Extension Varchar(5),
 Tamanio float,
 Ruta text,
 RutaBase text,
 Certificado text
);

ALTER TABLE Documento ADD CONSTRAINT PK_Documento PRIMARY KEY (Id);


CREATE TABLE Estatus (
 Id INT NOT NULL IDENTITY(1,1),
 Descripcion VARCHAR(50),
 CreateAt datetime,
 CreatedBy int,
 UpdateAt datetime,
 UpdateBy int
);

ALTER TABLE Estatus ADD CONSTRAINT PK_Estatus PRIMARY KEY (Id);


CREATE TABLE Historial (
 Id INT NOT NULL IDENTITY(1,1),
 Fecha datetime,
 Descripcion VARCHAR(200),
 DocumentoId INT NOT NULL,
 EstatusId INT NOT NULL,
 CreateAt datetime,
 CreatedBy int,
 UpdateAt datetime,
 UpdateBy int
);

ALTER TABLE Historial ADD CONSTRAINT PK_Historial PRIMARY KEY (Id);


CREATE TABLE Firmante (
 Id INT NOT NULL IDENTITY(1,1),
 NombreF VARCHAR(100),
 ApellidoF VARCHAR(100),
 CorreoF VARCHAR(50),
 TelefonoF VARCHAR(10),
 Puesto VARCHAR(50),
 Organizacion VARCHAR(100),
 CreateAt datetime,
 CreatedBy int,
 UpdateAt datetime,
 UpdateBy int
 
);

ALTER TABLE Firmante ADD CONSTRAINT PK_Firmante PRIMARY KEY (Id);

CREATE TABLE Perfil (
 Id INT NOT NULL IDENTITY(1,1),
 Nombre VARCHAR(100),
 CreateAt datetime,
 CreatedBy int,
 UpdateAt datetime,
 UpdateBy int
 
);

ALTER TABLE Perfil ADD CONSTRAINT PK_Perfil PRIMARY KEY (Id);

CREATE TABLE Cuenta (
 Id INT NOT NULL IDENTITY(1,1),
 Usuario VARCHAR(50),
 Contraseña VARCHAR(50),
 PerfilId INT NOT NULL,
 EmpresaId INT NOT NULL,
 CreateAt datetime,
 CreatedBy int,
 UpdateAt datetime,
 UpdateBy int
 
);

ALTER TABLE Cuenta ADD CONSTRAINT PK_Cuenta PRIMARY KEY (Id);

--FOREIGNKEY


ALTER TABLE Documento ADD CONSTRAINT FK_Documento_0 FOREIGN KEY (RemitenteId) REFERENCES Remitente (Id);
ALTER TABLE Documento ADD CONSTRAINT FK_Documento_1 FOREIGN KEY (AutorId) REFERENCES Autor (Id);
ALTER TABLE Documento ADD CONSTRAINT FK_Documento_2 FOREIGN KEY (TipoDocId) REFERENCES TipoDocumento (Id);
ALTER TABLE Documento ADD CONSTRAINT FK_Documento_3 FOREIGN KEY (FirmanteId) REFERENCES Firmante (Id);
ALTER TABLE Documento ADD CONSTRAINT FK_Documento_4 FOREIGN KEY (CarpetaId) REFERENCES Carpeta (Id);



ALTER TABLE Historial ADD CONSTRAINT FK_Historial_0 FOREIGN KEY (DocumentoId) REFERENCES Documento (Id);
ALTER TABLE Historial ADD CONSTRAINT FK_Historial_1 FOREIGN KEY (EstatusId) REFERENCES Estatus (Id);

ALTER TABLE Cuenta ADD CONSTRAINT FK_Cuenta_0 FOREIGN KEY (EmpresaId) REFERENCES Empresa (Id);

