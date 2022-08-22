using E_Commerce.Api.Entities.Auth;
using E_Commerce.Api.Entities.Products;
using E_Commerce.Api.Entities.Products.Specifications;
using Microsoft.EntityFrameworkCore;

#pragma warning disable
namespace E_Commerce.Api.Entities;

public class DataContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DataContext(DbContextOptions<DataContext> options,IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DataContext()
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Purchased> PurchasedItems { get; set; }
    public DbSet<BaseLaptop> Laptop { get; set; }
    public DbSet<Colors> Colors { get; set; }
    public DbSet<Display> Display { get; set; }
    public DbSet<Images> Images { get; set; }
    public DbSet<Ram> Ram { get; set; }
    public DbSet<Specs> Specifications { get; set; }
    public DbSet<Storage> Storage { get; set; }
    public DbSet<ColorImages> ColorImages { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
       base.OnModelCreating(builder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseNpgsql(_configuration.GetValue<string>("ConnectionStrings:Postgres"));
        }
    }
}