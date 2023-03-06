using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;

namespace ProjetoCadastroDeClientes.Helpers
{
    public class CNPJUtils
    {
        public static string FormatAsCNPJ(string input)
        {
            input = Regex.Replace(input ?? "", @"[^0-9]", "");
            input = String.Format(@"{0:00\.000\.000\/0000\-00}", long.Parse(input));
            return input;
        }
    }
}
