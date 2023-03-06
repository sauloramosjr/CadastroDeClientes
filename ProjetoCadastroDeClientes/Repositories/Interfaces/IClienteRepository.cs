using ProjetoCadastroDeClientes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoCadastroDeClientes.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<ClienteModel>> BuscarTodosClientes();
        Task<ClienteModel> BuscarPorId(int id);
        Task<ClienteModel> BuscarPorCnpj(string cnpj);

        Task<ClienteModel> Adicionar(ClienteModel cliente);
        Task<ClienteModel> Atualizar(ClienteModel cliente, int id);
        Task<bool> Apagar(int id);
    }
}
