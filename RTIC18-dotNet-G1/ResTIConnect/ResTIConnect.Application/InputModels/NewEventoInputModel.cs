
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Application.InputModels
{
    public class NewEventoInputModel
    {
        public string? Tipo { get; set; }
        public required string Descricao { get; set; }
        public string? Codigo { get; set; }
        public string? Conteudo { get; set; }
        public DateTimeOffset DataHoraOcorrencia { get; set; }

        public int SistemaId { get; set; }
      
    }
}