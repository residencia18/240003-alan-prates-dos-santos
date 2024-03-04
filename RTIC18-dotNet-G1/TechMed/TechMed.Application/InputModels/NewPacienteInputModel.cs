using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechMed.Aplication.InputModel
{
    public class PacienteInputModel
    {
        public string? Nome { get; set; }
        public string? CPF {get;set;}
        public DateTimeOffset DataNascimento {get; set;}

    }
}