using Microsoft.EntityFrameworkCore;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public class TransactionContext : DbContext
  {
    public TransactionContext(DbContextOptions<TransactionContext> opt) : base(opt) { }

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TransactionView> TransactionView { get;set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<TransactionView>()
        .HasNoKey()
        .ToView("TransactionView");
    }
  }
}