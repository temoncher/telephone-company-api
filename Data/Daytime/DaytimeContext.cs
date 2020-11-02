using Microsoft.EntityFrameworkCore;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public class DaytimeContext : DbContext
  {
    public DaytimeContext(DbContextOptions<DaytimeContext> opt) : base(opt) { }

    public DbSet<Daytime> Daytimes { get; set; }
  }
}