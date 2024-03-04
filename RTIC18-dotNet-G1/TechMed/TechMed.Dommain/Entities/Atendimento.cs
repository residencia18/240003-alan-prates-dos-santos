namespace TechMed.Dommain.Entities;
public class Atendimento : BaseEntity
{
    public int AtendimentoId { get; set; }
   
    public DateTimeOffset DataHoraInicio { get; set; }
    public string? SuspeitaInicial { get; set; }
    public DateTimeOffset DataHoraFim { get; set; }
    public string? Diagnostico { get; set; }
    public int MedicoId { get; set; }
    public required Medico Medico { get; set; }
    public int PacienteId { get; set; }
    public required Paciente Paciente {get; set;}
    public ICollection<Exame>? Exames { get; set; }
}
