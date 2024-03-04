using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechMed.Aplication.ViewModel
{
  public class AtendimentoViewModel
  {
    public int AtendimentoId { get; set; }
    public DateTimeOffset DataHoraInicio { get; set; }
    public DateTimeOffset DataHoraFim { get; set; }
    public string? SuspeitaInicial { get; set; }
    public string? Diagnostico { get; set; }
    public PacienteViewModel Paciente { get; set; } = null!;
    public MedicoViewModel Medico { get; set; } = null!;
    public List<ExameViewModel>? Exames {get;set;}
  }
}