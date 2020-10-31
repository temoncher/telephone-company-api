using System.Collections.Generic;
using SqlBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

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
      string path = System.IO.Path.GetFullPath("Scripts\\Databases\\GetAllDatabases.sql");
      FileInfo file = new FileInfo(path);
      string script = file.OpenText().ReadToEnd();

      return _context.Databases.FromSqlRaw(script);
    }
  }
}