using Microsoft.EntityFrameworkCore;
using AdventureSWAPI.Models;  // Import your Models

namespace AdventureSWAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor that takes DbContextOptions and passes them to the base class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // DbSet property representing the "Products" table in the database
        public DbSet<Product> Products { get; set; }
    }
}