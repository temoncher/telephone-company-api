using Microsoft.EntityFrameworkCore;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public class TransactionTypeContext : DbContext
  {
    public TransactionTypeContext(DbContextOptions<TransactionTypeContext> opt) : base(opt) { }

    public DbSet<TransactionType> TransactionTypes { get; set; }
  }
}