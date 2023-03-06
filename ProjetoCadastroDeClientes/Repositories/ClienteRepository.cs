using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ProjetoCadastroDeClientes.Data;
using ProjetoCadastroDeClientes.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjetoCadastroDeClientes.Helpers;
using System.Text.RegularExpressions;

namespace ProjetoCadastroDeClientes.Repositories
{
    public class ClienteRepository
    {
        private readonly CadastroClientesDBContext _dbContext;
        public ClienteRepository(CadastroClientesDBContext clientesContextDB)
        {
            _dbContext = clientesContextDB;
        }
        public async Task<List<ClienteModel>> BuscarTodosClientes()
        {
            return (await _dbContext.Clientes.ToListAsync()).ConvertAll(e => {
                e.Cnpj = CNPJUtils.FormatAsCNPJ(e.Cnpj);
                return e; 
            });
        }
        public async Task<ClienteModel> BuscarPorId(int id, bool withFormat = true)
        {
            ClienteModel cliente = await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if(cliente != null && withFormat == true)
            {
                cliente.Cnpj = CNPJUtils.FormatAsCNPJ(cliente.Cnpj);
            }

            return cliente;
        }
        public async Task<ClienteModel> BuscarPorCnpj(string cnpj)
        {
            ClienteModel cliente = await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Cnpj == cnpj);
            if(cliente != null)
            {
                cliente.Cnpj = CNPJUtils.FormatAsCNPJ(cliente.Cnpj);
            }
            return cliente;
        }
        public async Task<ClienteModel> Adicionar(CreateClienteModel cliente)
        {
            ClienteModel cli = new()
            {
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                Cnpj = cliente.Cnpj,
                Endereco = cliente.Endereco,
                DataCadastro = DateTime.Now
            };
            await _dbContext.Clientes.AddAsync(cli);
            await _dbContext.SaveChangesAsync();
            cli.Cnpj = CNPJUtils.FormatAsCNPJ(cli.Cnpj);
            return cli;
        }

        public async Task<bool> Apagar(int id)
        {
            ClienteModel clientePorId = await BuscarPorId(id);
            if (clientePorId == null)
            {
                return false;
            }
            _dbContext.Clientes.Remove(clientePorId);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<ClienteModel> Atualizar(AtualizarClienteModel usuario, int id)
        {
            ClienteModel ClientePorId = await BuscarPorId(id, false);
            if(usuario.Nome != null)
            {
              ClientePorId.Nome = usuario.Nome;
            }
            if (usuario.Telefone != null)
            {
                ClientePorId.Telefone = usuario.Telefone;
            }
            if (usuario.Endereco != null)
            {
                ClientePorId.Endereco = usuario.Endereco;
            }
            ClientePorId.Cnpj = Regex.Replace(ClientePorId.Cnpj ?? "", @"[^0-9]", "");
            _dbContext.Clientes.Update(ClientePorId);
            _dbContext.SaveChanges();
            ClientePorId.Cnpj = CNPJUtils.FormatAsCNPJ(ClientePorId.Cnpj);
            return ClientePorId;
        }


    }
}

