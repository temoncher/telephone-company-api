using Microsoft.EntityFrameworkCore;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public class AccountContext : DbContext
  {
    public AccountContext(DbContextOptions<AccountContext> opt) : base(opt) { }

    public DbSet<Account> Accounts { get; set; }
  }
}