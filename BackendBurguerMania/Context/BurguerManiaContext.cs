using Microsoft.EntityFrameworkCore;
using BackendBurguerMania.Models;

namespace BackendBurguerMania.Context
{
    public class BurguerManiaContext : DbContext
    {
        public BurguerManiaContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<OrdersProducts> OrdersProducts { get; set; }

        public DbSet<UsersOrders> UsersOrders { get; set; }
    }
}