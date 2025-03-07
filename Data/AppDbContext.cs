using LoginMonitorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginMonitorAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<LoginMonitorEvent?> LoginMonitorEvents { get; set; }
}