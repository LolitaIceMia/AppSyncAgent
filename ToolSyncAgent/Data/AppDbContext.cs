using Microsoft.EntityFrameworkCore;

namespace ToolSyncAgent.Data;

public class AppDbContext : DbContext
{
    public DbSet<SoftwarePackage> Packages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=appsync.db");
    }
}