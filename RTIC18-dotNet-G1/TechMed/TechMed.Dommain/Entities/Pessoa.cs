namespace TechMed.Dommain.Entities;
public abstract class Pessoa : BaseEntity{
    public required string Nome {get; set;}
    public string? CPF {get;set;}
}
