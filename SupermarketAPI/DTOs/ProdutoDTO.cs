using System.ComponentModel.DataAnnotations;

namespace SupermarketAPI.Models
{
    public class ProdutoDTO
    {
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public required string Nome { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser maior ou igual a 0")]
        public decimal Preco { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser maior ou igual a 0")]
        public int Quantidade { get; set; }
    }
}
