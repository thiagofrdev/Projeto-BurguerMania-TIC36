using Microsoft.EntityFrameworkCore;
using BackendBurguerMania.Models;

namespace BackendBurguerMania.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}