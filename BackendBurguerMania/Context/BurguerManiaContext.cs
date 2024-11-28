using Microsoft.EntityFrameworkCore;
using BackendBurguerMania.Models;

namespace BackendBurguerMania.Context
{
    public class BurguerManiaContext : DbContext
    {
        public BurguerManiaContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }

        public DbSet<Users> Users { get; set; }
    }
}