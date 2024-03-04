
namespace TechMed.Dommain.Entities;

public class Medico : Pessoa{
    public int MedicoId {get; set;}
    public string? CRM {get; set;}

    public ICollection<Atendimento>? Atendimentos {get; set;}
    public ICollection<Exame>? Exames {get; set;}

}
