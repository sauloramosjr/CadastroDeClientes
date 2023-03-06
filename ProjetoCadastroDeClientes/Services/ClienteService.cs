using Microsoft.EntityFrameworkCore;
using ProjetoCadastroDeClientes.Data;
using ProjetoCadastroDeClientes.Models;
using ProjetoCadastroDeClientes.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ProjetoCadastroDeClientes.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(ClienteRepository repository)
        {
            _clienteRepository = repository;
        }

        public async Task<List<ClienteModel>> BuscarTodosClientes()
        {
            return await _clienteRepository.BuscarTodosClientes();
        }

        public async Task<ClienteModel> BuscarPorId(int id)
        {
            ClienteModel cliente = await _clienteRepository.BuscarPorId(id);
            return cliente;
        }

        public async Task<ClienteModel> Adicionar(CreateClienteModel cliente)
        {
            try
            {
                return await _clienteRepository.Adicionar(cliente);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }

        public async Task<ClienteModel> Atualizar(int id, AtualizarClienteModel cliente)
        {
            ClienteModel _ = await _clienteRepository.BuscarPorId(id) ?? throw new KeyNotFoundException($"Cliente com Id:{id} não foi encontrado");
            try
            {
                return await _clienteRepository.Atualizar(cliente, id);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }

        public async Task<bool> Apagar(int id)
        {
            return await _clienteRepository.Apagar(id);
        }

        public async Task<bool> CheckSeExisteClienteComEsseCnpj(string cnpj)
        {
            ClienteModel cliente =  await _clienteRepository.BuscarPorCnpj(cnpj);
            if (cliente != null)
            {
                return true;
            }
            return false;
        }
    }
}
