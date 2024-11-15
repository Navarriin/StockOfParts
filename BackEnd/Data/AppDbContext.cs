using Microsoft.EntityFrameworkCore;
using StockOfMachineParts.Models;

namespace StockOfMachineParts.Data;

public class AppDbContext : DbContext
{
    public DbSet<Machine> Machine { get; set; }
    public DbSet<Parts> Parts { get; set; }
    
    // public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Parts>()
            .HasOne(p => p.Machine)   // Cada Peca tem uma Maquina associada
            .WithMany(m => m.Parts)   // Cada Maquina pode ter várias Pecas
            .HasForeignKey(p => p.MachineId); // Define a chave estrangeira

        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=MyDb.db");
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        base.OnConfiguring(optionsBuilder);
    }
}