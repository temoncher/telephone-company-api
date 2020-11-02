using Microsoft.EntityFrameworkCore;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public class CallContext : DbContext
  {
    public CallContext(DbContextOptions<CallContext> opt) : base(opt) { }

    public DbSet<Call> Calls { get; set; }
  }
}