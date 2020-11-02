using System.Collections.Generic;
using SqlBackend.Models;
using SqlBackend.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace SqlBackend.Data
{
  public class DaytimeRepository : IDaytimeRepository
  {
    private readonly DaytimeContext _context;

    public DaytimeRepository(DaytimeContext context)
    {
      _context = context;
    }

    public int CreateDaytime(Daytime daytime)
    {
      string script = ScriptsUtils.GetSqlScript("Daytimes\\CreateDaytime.sql");
      var title = new SqlParameter("@title", daytime.title);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        title
      );

      return numberOfAffectedRows;
    }

    public int DeleteDaytime(int id)
    {
      string script = ScriptsUtils.GetSqlScript("Daytimes\\DeleteDaytime.sql");
      var daytimeId = new SqlParameter("@daytimeId", id);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        daytimeId
      );

      return numberOfAffectedRows;
    }

    public IEnumerable<Daytime> GetAllDaytimes()
    {
      string script = ScriptsUtils.GetSqlScript("Daytimes\\GetAllDaytimes.sql");
      IEnumerable<Daytime> daytimes = _context.Daytimes.FromSqlRaw(script);

      return daytimes;
    }

    public async Task<Daytime> GetDaytimeById(int id)
    {
      string script = ScriptsUtils.GetSqlScript("Daytimes\\GetDaytimeById.sql");
      var daytimeId = new SqlParameter("@daytimeId", id);

      Daytime daytime = await _context.Daytimes.FromSqlRaw(
        script,
        daytimeId
      ).FirstAsync();

      return daytime;
    }

    public int UpdateDaytime(int id, Daytime daytime)
    {
      string script = ScriptsUtils.GetSqlScript("Daytimes\\UpdateDaytime.sql");
      var daytimeId = new SqlParameter("@daytimeId", id);
      var title = new SqlParameter("@title", daytime.title);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        daytimeId,
        title
      );

      return numberOfAffectedRows;
    }
  }
}