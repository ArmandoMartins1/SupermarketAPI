namespace SupermarketAPI.Models
{
    public class ProdutoResponseDTO
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
