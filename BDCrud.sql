-- Criação da tabela "usuario"
CREATE TABLE usuario (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(50),
    Email VARCHAR(50),
    Senha VARCHAR(50)
);

-- Criação da tabela "clientes"
CREATE TABLE clientes (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioID INT,
    Nome VARCHAR(50),
    Tipo VARCHAR(50),
    NumeroDocumento VARCHAR(100) UNIQUE,
    DataNascimento DATE,
    DataCadastro DATETIME
    FOREIGN KEY (UsuarioID) REFERENCES usuario(ID)
);