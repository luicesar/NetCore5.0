USE master;
GO

IF DB_ID (N'Estapar') IS NOT NULL
DROP DATABASE Estapar;
GO
CREATE DATABASE Estapar;
GO

----------------------------------------------------
USE Estapar;
GO

DROP TABLE Carro;
CREATE TABLE Carro
(
	ID int identity(1,1) not null,
	Marca varchar(100) not null,
	Modelo varchar(100) not null,
	Placa varchar(10) not null,
	DataCriacao datetime,
	CONSTRAINT PK_Carro PRIMARY KEY (ID)
);

DROP TABLE Pessoa;
CREATE TABLE Pessoa
(
	ID int identity(1,1) not null,
	Nome varchar(100) not null,
	Cpf varchar(20) not null,
	DataNascimento datetime,
	DataCriacao datetime,
	CONSTRAINT PK_Pessoa PRIMARY KEY (ID)
);

DROP TABLE Manobrista;
CREATE TABLE Manobrista (
	ID int identity(1,1) not null,
    PessoaId int NOT NULL,
    CarroId int NOT NULL,
    DataCriacao datetime,
	CONSTRAINT PK_Manobrista PRIMARY KEY (ID),
    CONSTRAINT FK_PessoaManobrista FOREIGN KEY (PessoaId) REFERENCES Pessoa(ID),
	CONSTRAINT FK_CarroManobrista FOREIGN KEY (CarroId) REFERENCES Carro(ID)
);
