using Microsoft.EntityFrameworkCore;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public class DaytimePriceContext : DbContext
  {
    public DaytimePriceContext(DbContextOptions<DaytimePriceContext> opt) : base(opt) { }

    public DbSet<DaytimePrice> DaytimePrices { get; set; }
    public DbSet<DaytimePriceView> DaytimePriceView { get;set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<DaytimePrice>()
          .HasKey(o => new { o.price_id, o.daytime_id });
      modelBuilder.Entity<DaytimePriceView>()
        .HasNoKey()
        .ToView("DaytimePriceView");
    }
  }
}