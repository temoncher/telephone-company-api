using System.Collections.Generic;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public interface IDatabaseRepository
  {
    IEnumerable<Database> GetAllDatabases();
    int CreateDatabase();
    int DropDatabase();
  }
}