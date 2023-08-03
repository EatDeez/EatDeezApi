using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ZelpApi.Models;

public class ZelpContext : DbContext
{
    protected IConfiguration Configuration { get; }

    public ZelpContext(IConfiguration configuration) => Configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseNpgsql(
            // get the database name from the configuration and then the connection string from the key vault
            Configuration.GetSection(Configuration.GetSection("DatabaseName").Value!).Value!
        );

    // DbSet for each data model
    public DbSet<User> Users { get; set; }
    // public DbSet<Review> Reviews { get; set; }
    // public DbSet<Restaurant> Restaurants { get; set; }
    // DbSet for other data models...
}
