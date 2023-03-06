using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace ProjetoCadastroDeClientes.Models
{
    public class AtualizarClienteModel
    {

        [AllowNull]
        [MaxLength(255, ErrorMessage = "O limite de caracteres é 255")]
        public string Nome { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Deve enviar apenas os números do Cnpj")]
        [MaxLength(14, ErrorMessage = "Cnpj contém 14 números, tem números a mais no que você enviou!")]
        [MinLength(14, ErrorMessage = "Cnpj contém 14 números, está faltando números no que você enviou!")]
        [AllowNull]
        public string Cnpj { get; set; }
        [AllowNull]
        [MaxLength(255, ErrorMessage = "O limite de caracteres é 255")]
        public string Endereco { get; set; }
        [AllowNull]
        [MaxLength(255, ErrorMessage = "O limite de caracteres é 255")]
        public string Telefone { get; set; }
    }
}
