using Microsoft.EntityFrameworkCore;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public class TransactionContext : DbContext
  {
    public TransactionContext(DbContextOptions<TransactionContext> opt) : base(opt) { }

    public DbSet<Transaction> Transactions { get; set; }
  }
}