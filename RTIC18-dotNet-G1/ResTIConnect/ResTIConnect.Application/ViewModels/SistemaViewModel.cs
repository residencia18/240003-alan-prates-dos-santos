
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Application.ViewModels
{
    public class SistemaViewModel
    {
        public int SistemaId { get; set; }
        public required string Descricao { get; set; }
        public string? Tipo { get; set; }

        public List<UserViewModel>? Users { get; set; }
        public List<EventoViewModel>? Eventos { get; set; }
    }
}