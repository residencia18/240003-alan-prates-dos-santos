namespace TechMed.Dommain.Entities;
public class Exame : BaseEntity
{
   public int ExameId { get; set; }
   public string Nome { get; set; } = null!;
   public DateTimeOffset DataHora { get; set; }
   public decimal Valor {get; set;}
   public string? Local {get; set;}
   public string? ResultadoDescricao {get;set;}
   public ICollection<Atendimento>? Atendimentos {get; set;}
}
