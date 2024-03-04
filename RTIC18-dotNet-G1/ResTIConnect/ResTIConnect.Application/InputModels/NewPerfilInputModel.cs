
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Application.InputModels
{
    public class NewPerfilInputModel
    {

        public required string Descricao { get; set; }
        public required string Permissoes { get; set; }

        public int UserId { get; set; }
    }
}