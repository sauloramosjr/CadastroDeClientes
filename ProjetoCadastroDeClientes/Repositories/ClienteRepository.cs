using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ProjetoCadastroDeClientes.Data;
using ProjetoCadastroDeClientes.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            return await _dbContext.Clientes.ToListAsync();
        }
        public async Task<ClienteModel> BuscarPorId(int id)
        {
            ClienteModel cliente = await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            return cliente;
        }
        public async Task<ClienteModel> BuscarPorCnpj(string cnpj)
        {
            ClienteModel cliente = await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Cnpj == cnpj);
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
                DataCadastro = new DateTime()
            };
            await _dbContext.Clientes.AddAsync(cli);
            await _dbContext.SaveChangesAsync();
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
            ClienteModel ClientePorId = await BuscarPorId(id);
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
            _dbContext.Clientes.Update(ClientePorId);
            _dbContext.SaveChanges();

            return ClientePorId;
        }


    }
}

