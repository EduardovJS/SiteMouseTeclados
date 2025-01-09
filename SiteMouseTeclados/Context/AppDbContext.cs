using Microsoft.EntityFrameworkCore;
using SiteMouseTeclados.Models;

namespace SiteMouseTeclados.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}
