using Microsoft.EntityFrameworkCore;

namespace Advantage.API.Models
{
    public class ApiContext: DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options): base(options){}

        public DbSet<Customer> Custumers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Server> Servers { get; set; }
    }
} 