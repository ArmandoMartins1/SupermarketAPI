namespace SupermarketAPI.Models
{
    public class ProdutoDTO
    {
        public required string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}