-- Cria o banco de dados
CREATE DATABASE db_1;
GO

-- Define qual banco de dados será utilizado
USE db_1;
GO

-- Cria a tabela Products
CREATE TABLE ListaUsuarios(
	Id		    SMALLINT NOT NULL,
	Nome			    VARCHAR(255) NOT NULL,
	Email				VARCHAR(255) NOT NULL,
	Senha			    VARCHAR(255) NOT NULL
);
GO

-- Lista os dados da tabela
SELECT * FROM ListaUsuarios;
GO

