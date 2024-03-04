
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Application.ViewModels
{
    public class EnderecoViewModel
    {
        public int EnderecoId { get; set; }
        public required string  Logradouro { get; set; }
        public string?  Numero { get; set; }  
        public string?  Cidade { get; set; }
        public string?  Complemento { get; set; }
        public string?  Bairro { get; set; }
        public string?  Estado { get; set; }
        public string?  Cep { get; set; }
        public  string?  Pais { get; set; }
    }
}