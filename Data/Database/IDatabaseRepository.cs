using System.Collections.Generic;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public interface IDatabaseRepository
  {
    IEnumerable<Database> GetAllDatabases();
    int CreateTables();
    int CreateViews();
    int CreateRoles();
    int SetupTriggers();
    int Seed();
  }
}