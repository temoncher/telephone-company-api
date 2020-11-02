using Microsoft.EntityFrameworkCore;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public class LocalityContext : DbContext
  {
    public LocalityContext(DbContextOptions<LocalityContext> opt) : base(opt) { }

    public DbSet<Locality> Localities { get; set; }
  }
}