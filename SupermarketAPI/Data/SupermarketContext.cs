using Microsoft.EntityFrameworkCore;
using SupermarketAPI.Models;

namespace SupermarketAPI.Data
{
    public class SupermarketContext : DbContext
    {
        public SupermarketContext(DbContextOptions<SupermarketContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}
