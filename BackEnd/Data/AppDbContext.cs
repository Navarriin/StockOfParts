using StockOfMachineParts.Models;
using Microsoft.EntityFrameworkCore;

namespace StockOfMachineParts.Data;

public class AppDbContext : DbContext
{
    public DbSet<Parts> Parts { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=MyDb.db");
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        base.OnConfiguring(optionsBuilder);
    }
}