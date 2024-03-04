using ResTIConnect.Domain.Common;

namespace ResTIConnect.Domain.Entities;
public class User : BaseEntity
{
      public int UserId { get; set; }
      public required string Name { get; set; }
      public string? Email { get; set; }
      public string? Password { get; set; }
      public string? Telefone { get; set; }

      public int? EnderecoId { get; set; }
      public Enderecos? Endereco { get; set; }
      public ICollection<Perfis>? Perfis { get; set; } = new List<Perfis>();
      public ICollection<Sistemas>? Sistemas { get; set; } = new List<Sistemas>();
}
