using System.ComponentModel.DataAnnotations;

namespace ProjetoWebApi.Models
{
    public class Personagem
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é um obrigatório")]
        [MaxLength(50, ErrorMessage = "Nome deve ter no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Tipo é um obrigatório")]
        [MaxLength(50, ErrorMessage = "Tipo deve ter no máximo 50 caracteres")]
        public string Tipo { get; set; }
    }
}