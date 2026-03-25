CREATE DATABASE SistemaEventos;
GO

USE SistemaEventos;
GO

CREATE TABLE TipoEvento (
    IdTipoEvento INT IDENTITY(1,1) PRIMARY KEY,
    Titulo VARCHAR(100) NOT NULL
);

CREATE TABLE TipoUsuario (
    IdTipoUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Titulo VARCHAR(100) NOT NULL
);

CREATE TABLE Instituicao (
    IdInstituicao INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(150) NOT NULL,
    NomeFantasia VARCHAR(150),
    Endereco VARCHAR(200)
);

CREATE TABLE Usuario (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(150) NOT NULL,
    Email VARCHAR(150) NOT NULL,
    Senha VARCHAR(200) NOT NULL,
    IdTipoUsuario INT NOT NULL,

    FOREIGN KEY (IdTipoUsuario) REFERENCES TipoUsuario(IdTipoUsuario)
);

CREATE TABLE Evento (
    IdEvento INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(150) NOT NULL,
    Descricao VARCHAR(300),
    Data DATETIME NOT NULL,
    IdTipoEvento INT NOT NULL,
    IdInstituicao INT NOT NULL,

    FOREIGN KEY (IdTipoEvento) REFERENCES TipoEvento(IdTipoEvento),
    FOREIGN KEY (IdInstituicao) REFERENCES Instituicao(IdInstituicao)
);

CREATE TABLE Presenca (
    IdPresenca INT IDENTITY(1,1) PRIMARY KEY,
    Situacao VARCHAR(50),
    IdEvento INT NOT NULL,
    IdUsuario INT NOT NULL,

    FOREIGN KEY (IdEvento) REFERENCES Evento(IdEvento),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

CREATE TABLE ComentarioEvento (
    IdComentario INT IDENTITY(1,1) PRIMARY KEY,
    Descricao VARCHAR(300),
    Data DATETIME,
    Exibi BIT,
    IdEvento INT NOT NULL,
    IdUsuario INT NOT NULL,

    FOREIGN KEY (IdEvento) REFERENCES Evento(IdEvento),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);