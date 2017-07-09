using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models
{
    public class ECommerceContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options) { }

        public DbSet<User> User {get; set;}
        public DbSet<Customer> Customer {get; set;}

        public DbSet<Product> Product {get; set;}
        public DbSet<Order> Order {get; set;}
        
        
        
        

    }
}