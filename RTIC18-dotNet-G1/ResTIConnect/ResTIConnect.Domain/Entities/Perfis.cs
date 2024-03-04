using ResTIConnect.Domain.Common;

namespace ResTIConnect.Domain.Entities
{
    public class Perfis: BaseEntity
    {
        public int PerfilId { get; }
        public required string  Descricao { get; set; }
        public required string  Permissoes { get; set; }
        public ICollection<User>? Users { get; set; } = new List<User>();
    }
}