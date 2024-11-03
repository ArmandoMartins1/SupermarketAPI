using System.ComponentModel.DataAnnotations;

namespace SupermarketAPI.Models
{
    public class ProdutoDTO
    {
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        [Range(0.01, 10000, ErrorMessage = "O preço deve estar entre 0.01 e 10000.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A quantidade em estoque é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa.")]
        public int Quantidade { get; set; }
    }
}
