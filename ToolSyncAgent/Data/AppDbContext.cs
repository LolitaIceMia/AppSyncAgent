using System.IO;
using Microsoft.EntityFrameworkCore;

namespace ToolSyncAgent.Data;

public class AppDbContext : DbContext
{
    public DbSet<SoftwarePackage> Packages { get; set; }
    private static readonly string DbPath = Path.Combine(AppContext.BaseDirectory, "appsync.db");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}