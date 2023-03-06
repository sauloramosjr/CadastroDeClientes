using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCadastroDeClientes.Models
{
    public class CreateClienteModel
    {
        public string Nome { get; set; }
        [MaxLength(14)]
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}
