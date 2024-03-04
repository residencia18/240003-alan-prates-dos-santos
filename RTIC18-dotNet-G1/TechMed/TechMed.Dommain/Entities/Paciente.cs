namespace TechMed.Dommain.Entities;

public class Paciente : Pessoa{
   public int PacienteId {get; set;}
    public DateTimeOffset DataNascimento {get; set;}
    public ICollection<Atendimento>? Atendimentos {get;}
}
