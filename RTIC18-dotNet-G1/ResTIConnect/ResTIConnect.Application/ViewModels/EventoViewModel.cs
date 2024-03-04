
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Application.ViewModels
{
    public class EventoViewModel
    {
        public int EventoId { get; set; }
        public string? Tipo { get; set; }
        public required string Descricao { get; set; }
        public string? Codigo { get; set; }
        public string? Conteudo { get; set; }
        public DateTimeOffset DataHoraOcorrencia { get; set; }

        public SistemaViewModel? Sistema { get; set; }
    }
}