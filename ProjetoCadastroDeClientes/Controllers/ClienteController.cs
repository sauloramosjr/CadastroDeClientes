using Microsoft.AspNetCore.Mvc;
using ProjetoCadastroDeClientes.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjetoCadastroDeClientes.Models;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.EntityFrameworkCore;

namespace ProjetoCadastroDeClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly ClienteService _clienteService;
            public ClienteController(ClienteService clienteService)
            {
                _clienteService = clienteService;
            }

            // GET: api/Clientes
            [HttpGet]
            public async Task<ActionResult<List<ClienteModel>>> BuscarTodosClientes()
            {
                var clientes = await _clienteService.BuscarTodosClientes();
                return Ok(clientes);
            }

            // GET: api/Clientes/5
            [HttpGet("{id}")]
            public async Task<ActionResult<ClienteModel>> BuscarCliente(int id)
            {
                var cliente = await _clienteService.BuscarPorId(id);

                if (cliente == null)
                {
                    return NotFound($"Cliente com Id:{id} não foi encontrado!");
                }

                return Ok(cliente);
            }

            // POST: api/Clientes
            [HttpPost]
            public async Task<ActionResult<ClienteModel>> AdicionarCliente(CreateClienteModel cliente)
            {
                if (await _clienteService.CheckSeExisteClienteComEsseCnpj(cliente.Cnpj))
                {
                    return BadRequest($"Cliente com o Cnpj:{cliente.Cnpj} já está cadastrado!");
                }
                ClienteModel cli = await _clienteService.Adicionar(cliente);
                return Ok(cli);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> AtualizarCliente(int id, AtualizarClienteModel cliente)
            {   
                if (cliente.Cnpj != null)
                {
                    return BadRequest("CNPJ não pode ser alterado!");
                }
                try
                {
                    ClienteModel cli = await _clienteService.Atualizar(id, cliente);
                    return Ok(cli);
            }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (_clienteService.BuscarPorId(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

                    }
                }
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> ApagarCliente(int id)
            {
                try
                {
                    var client = await _clienteService.BuscarPorId(id);

                    if (client == null)
                    {
                        return NotFound($"Cliente com Id:{id} não foi encontrado!");
                    }

                    bool apagou = await _clienteService.Apagar(id);
                    if (apagou)
                    {
                    return Ok($"Cliente {client.Nome} com id: {id} foi apagado com sucesso!");
                    }

                    return BadRequest($"Cliente com id:{id} não foi encontrado!");
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
    }
}