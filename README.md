
# Projeto Cadastro De Clientes

## Objetivo
Este projeto foi desenvolvido para a empresa Useall com o objetivo de fornecer uma solução simples de cadastro de clientes.



## Instalação & Execução

- Clone este repositório para sua máquina local
```
git clone https://github.com/sauloramosjr/CadastroDeClientes
```
- Precisa ter um Banco de Dados ativo sendo ele o Postgres para este projeto.
- Postgres: Porta=5432, User=postgres, Password=postgres;  Pode mudar essa configuração no arquivo: "appsettings.json"

- Acesse o diretório do projeto com Visual Studio
- Este projeto possui migrations, para utilizar as migrations abra o Package Manager Console (Tools -> NuGet Package Manager -> Package Manager Console) e execute o comando
 ```
 Update-Database
 ```
 para aplicar as migrations ao banco de dados.
 
 - Caso queira, o sql deste projeto está no arquivo "Clientes.sql" localizado na raiz do projeto.
 
## Tecnologias Utilizadas

- C#
- Entity Framework core 5.0
- Entity Framework core Design 5.0
- Entity Framework core Relacional 5.0
- Entity Framework core SqlServer 5.0
- Entity Framework core Tools 5.0
- NpgSql Entity Framework core - PostgresSql 5.0

## Autor

- [@SauloRamos](https://www.github.com/sauloramosjr)

