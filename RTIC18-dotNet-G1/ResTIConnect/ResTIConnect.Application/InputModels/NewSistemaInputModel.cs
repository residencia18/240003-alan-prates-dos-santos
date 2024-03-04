
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Application.InputModels
{
    public class NewSistemaInputModel
    {
        

        public required string Descricao { get; set; }
        public string? Tipo { get; set; }

        public int UserId { get; set; }
        public int EventoId { get; set; }
    }
}