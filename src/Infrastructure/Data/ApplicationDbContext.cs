using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    /// <summary>
    /// The application database context class that inherits from <see cref="DbContext"/>.
    /// This class represents a session with the database and provides access to the various DbSets of entities.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class with the specified options.
        /// </summary>
        /// <param name="options">The options used to configure the DbContext, including the connection string.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Configures the model for the <see cref="ApplicationDbContext"/>.
        /// This method is called during the model creation process and is used to configure entity properties.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base class implementation to ensure default configurations are applied
            base.OnModelCreating(modelBuilder);

            // Configure Product entity
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(100);
        }
    }
}
