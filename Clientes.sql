-- Cria o banco de dados
CREATE DATABASE DB_Cadastro_Clientes;
-- Utiliza o banco de dados criado 
USE DB_Cadastro_Clientes;
-- cria a tabela de clientes
CREATE TABLE Clientes (
   Codigo INT PRIMARY KEY IDENTITY(1,1),
   Nome VARCHAR(50) NOT NULL,
   CNPJ VARCHAR(14) NOT NULL UNIQUE,
   DataCadastro DATE NOT NULL,
   Endereco VARCHAR(100) NOT NULL,
   Telefone VARCHAR(20) NOT NULL
);
