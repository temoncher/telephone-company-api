using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;
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

    public int CreateDatabase()
    {
      string script = ScriptsUtils.GetSqlScript("Databases\\CreateDatabase.sql");
      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(script);

      return numberOfAffectedRows;
    }

    public int DropDatabase()
    {
      string script = ScriptsUtils.GetSqlScript("Databases\\DropDatabase.sql");
      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(script);

      return numberOfAffectedRows;
    }
  }
}