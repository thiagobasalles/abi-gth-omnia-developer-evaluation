using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM;

public class DefaultContext : DbContext
{
    public DbSet<Address> Address { get; set; }
    public DbSet<Branch> Branche { get; set; }
    public DbSet<GeoLocation> GeoLocation { get; set; }
    public DbSet<Product> Product {  get; set; }
    public DbSet<Rating> Rating { get; set; }
    public DbSet<Sale> Sale { get; set; }
    public DbSet<SaleItem> SaleItem { get; set; }
    public DbSet<User> Users { get; set; }

    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Branch>().HasData(
            new Branch { Id = 1, Name = "Matriz" },
            new Branch { Id = 2, Name = "Filial Norte" },
            new Branch { Id = 3, Name = "Filial Sul" },
            new Branch { Id = 4, Name = "Filial Leste" },
            new Branch { Id = 5, Name = "Filial Oeste" }
        );
    }
}
public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DefaultContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseNpgsql(
               connectionString,
               b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
        );

        return new DefaultContext(builder.Options);
    }
}