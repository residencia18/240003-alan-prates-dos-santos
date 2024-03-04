using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechMed.Aplication.InputModel
{
    public class ExameInputModel
    {
        public string Nome { get; set; } = null!;
        public DateTimeOffset DataHora {get;set;}
        public decimal Valor;
        public string? Local;
    }
}