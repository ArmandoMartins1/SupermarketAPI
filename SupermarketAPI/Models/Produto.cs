using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketAPI.Models
{
    public class Produto
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Preco { get; set; }
    
    public int Quantidade { get; set; }
}

}
