using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Application.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public required string Name { get; set; }
        public EnderecoViewModel? Endereco { get; set; }
        public List<PerfilViewModel>? Perfis { get; set; }
        public List<SistemaViewModel>? Sistemas { get; set; }
    }
}