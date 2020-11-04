using Microsoft.EntityFrameworkCore;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public class PriceContext : DbContext
  {
    public PriceContext(DbContextOptions<PriceContext> opt) : base(opt) { }

    public DbSet<Price> Prices { get; set; }
    public DbSet<PriceView> PriceView { get;set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<PriceView>()
        .HasNoKey()
        .ToView("PriceView");
    }
  }
}