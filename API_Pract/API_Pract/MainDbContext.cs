using API_Pract.Orders;
using Microsoft.EntityFrameworkCore;

namespace API_Pract
{
    public class MainDbContext : DbContext
    {
        public DbSet<Order> orders {get; set;}
        public DbSet<Services> services { get; set; }
        public DbSet<Clients> clients { get; set; }
        public MainDbContext() 
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=192.168.0.222;User=root;Password=is410601;Database=apiSalon4");
        }
    }
}
