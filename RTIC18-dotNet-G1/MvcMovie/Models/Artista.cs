using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Artista
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Biografia é obrigatório.")]
        public string Biografia { get; set; }

        [Required(ErrorMessage = "O campo Site é obrigatório.")]
        [Url(ErrorMessage = "O Site inserido não é válido.")]
        public string Site { get; set; }

        // ID do usuário associado ao artista
        public int UserId { get; set; }
    }
}