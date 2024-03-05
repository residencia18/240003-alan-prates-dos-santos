using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Estudio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo País é obrigatório.")]
        public string Country { get; set; }

        public string Site { get; set; }
        
        public int UserId { get; set; }
    }
}