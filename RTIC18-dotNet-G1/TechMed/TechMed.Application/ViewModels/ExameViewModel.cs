using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechMed.Aplication.ViewModel
{
    public class ExameViewModel
    {
        public int ExameId { get; set; }
        public string? ExameNome { get; set; }
        public DateTimeOffset DataHora { get; set; }
        public decimal Valor { get; set; }
        public string? Local { get; set; }
        public string? ResultadoDescricao { get; set; }
    }
}