using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email inserido não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IEnumerable<Estudio>? Estudios { get; set; }
        public IEnumerable<Artista>? Artistas { get; set; }
    }
}