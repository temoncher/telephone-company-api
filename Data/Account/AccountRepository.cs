using System.Collections.Generic;
using SqlBackend.Models;
using SqlBackend.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace SqlBackend.Data
{
  public class AccountRepository : IAccountRepository
  {
    private readonly AccountContext _context;

    public AccountRepository(AccountContext context)
    {
      _context = context;
    }

    public IEnumerable<Account> GetAllAccounts()
    {
      string script = ScriptsUtils.GetSqlScript("Accounts\\GetAllAccounts.sql");
      IEnumerable<Account> accounts = _context.Accounts.FromSqlRaw(script);

      return accounts;
    }

    public IEnumerable<AccountView> GetAccountsTable()
    {
      string script = ScriptsUtils.GetSqlScript("Accounts\\GetAccountsTable.sql");
      IEnumerable<AccountView> accounts = _context.AccountView.FromSqlRaw(script);

      return accounts;
    }
  }
}