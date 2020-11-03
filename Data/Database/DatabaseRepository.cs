using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SqlBackend.Models;
using SqlBackend.Utils;

namespace SqlBackend.Data
{
  public class DatabaseRepository : IDatabaseRepository
  {
    private readonly DatabaseContext _context;

    public DatabaseRepository(DatabaseContext context)
    {
      _context = context;
    }

    public IEnumerable<Database> GetAllDatabases()
    {
      string script = ScriptsUtils.GetSqlScript("Databases\\GetAllDatabases.sql");

      return _context.Databases.FromSqlRaw(script);
    }

    public int CreateTables()
    {
      string script = ScriptsUtils.GetSqlScript("CreateTables.sql");
      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(script);

      return numberOfAffectedRows;
    }

    public int SetupTriggers()
    {
      string createAccountTriggerScript = ScriptsUtils.GetSqlScript("Triggers\\CreateAccountTrigger.sql");
      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(createAccountTriggerScript);
      string updateBalanceTriggerScript = ScriptsUtils.GetSqlScript("Triggers\\UpdateBalanceTrigger.sql");
      numberOfAffectedRows = numberOfAffectedRows + _context.Database.ExecuteSqlRaw(updateBalanceTriggerScript);

      return numberOfAffectedRows;
    }

    public int Seed()
    {
      string script = ScriptsUtils.GetSqlScript("Seed.sql");
      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(script);

      return numberOfAffectedRows;
    }
  }
}