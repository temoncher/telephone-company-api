using Microsoft.EntityFrameworkCore;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public class SubscriberContext : DbContext
  {
    public SubscriberContext(DbContextOptions<SubscriberContext> opt) : base(opt) { }

    public DbSet<Subscriber> Subsrcibers { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Subscriber>()
          .HasIndex(s => s.account_id)
          .IsUnique();
    }
  }
}