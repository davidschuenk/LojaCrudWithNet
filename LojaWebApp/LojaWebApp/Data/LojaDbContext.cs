


using LojaWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaWebApp.Data;

public class LojaDbContext : DbContext
{
    public DbSet<Produto> Produto { get; set; }
    public DbSet<Marca> Marca { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        string conn = config.GetConnectionString("Conn");

        optionsBuilder.UseSqlServer(conn);
       

        //optionsBuilder.UseInMemoryDatabase(conn);
    }
}
