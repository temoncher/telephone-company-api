using System.Collections.Generic;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public interface IAccountRepository
  {
    IEnumerable<Account> GetAllAccounts();
  }
}