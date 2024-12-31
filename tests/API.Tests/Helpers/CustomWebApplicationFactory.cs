using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace API.Tests.Helpers
{
    /// <summary>
    /// Custom WebApplicationFactory for integration testing.
    /// </summary>
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        /// <summary>
        /// Configures the test host for the application.
        /// </summary>
        /// <param name="builder">The IWebHostBuilder used to configure the application.</param>
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                // Remove existing DbContext registration
                services.RemoveAll(typeof(DbContextOptions<ApplicationDbContext>));

                // Add an in-memory database for the ApplicationDbContext
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("TestDb"));

                // Ensure the in-memory database is created and seeded
                using var scope = services.BuildServiceProvider().CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                // Seed test data
                SeedTestData(dbContext);
            });
        }

        /// <summary>
        /// Seeds initial data into the in-memory database for testing purposes.
        /// </summary>
        /// <param name="dbContext">The ApplicationDbContext instance.</param>
        private void SeedTestData(ApplicationDbContext dbContext)
        {
            // Clear existing data
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            // Add test data
            dbContext.Products.Add(new Product { Id = 1, Name = "Test Product 1" });
            dbContext.Products.Add(new Product { Id = 2, Name = "Test Product 2" });
            dbContext.SaveChanges();
        }
    }
}
