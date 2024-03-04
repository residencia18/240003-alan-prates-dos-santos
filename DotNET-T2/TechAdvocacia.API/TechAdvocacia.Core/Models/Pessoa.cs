// Em TechAdvocacia.Core/Models/Pessoa.cs
public abstract class Pessoa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }
}
