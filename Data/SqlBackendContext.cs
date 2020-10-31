using Microsoft.EntityFrameworkCore;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public class SqlBackendContext : DbContext
  {
    public SqlBackendContext(DbContextOptions<SqlBackendContext> opt) : base(opt) { }

    public DbSet<Subscriber> Subsrcibers { get; set; }
  }
}