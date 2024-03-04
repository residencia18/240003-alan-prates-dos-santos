
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Application.ViewModels
{
    public class PerfilViewModel
    {
        public int PerfilId { get; set; }
        public required string Descricao { get; set; }
        public required string Permissoes { get; set; }

        public List<UserViewModel>? Users { get; set; }
    }
}