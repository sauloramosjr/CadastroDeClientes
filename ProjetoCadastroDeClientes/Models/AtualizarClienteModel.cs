using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoCadastroDeClientes.Models
{
    public class AtualizarClienteModel
    {
        [AllowNull]
        public string Nome { get; set; }
        [AllowNull]
        public string Cnpj { get; set; }
        [AllowNull]
        public string Endereco { get; set; }
        [AllowNull]
        public string Telefone { get; set; }
    }
}
