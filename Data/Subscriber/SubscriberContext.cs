using Microsoft.EntityFrameworkCore;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public class SubscriberContext : DbContext
  {
    public SubscriberContext(DbContextOptions<SubscriberContext> opt) : base(opt) { }

    public DbSet<Subscriber> Subsrcibers { get; set; }
    public DbSet<SubscriberView> SubscriberView { get;set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<SubscriberView>()
        .HasNoKey()
        .ToView("SubscriberView");
    }
  }
}