using System.Collections.Generic;
using SqlBackend.Models;
using SqlBackend.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace SqlBackend.Data
{
  public class LocalityRepository : ILocalityRepository
  {
    private readonly LocalityContext _context;

    public LocalityRepository(LocalityContext context)
    {
      _context = context;
    }

    public int CreateLocality(Locality locality)
    {
      string script = ScriptsUtils.GetSqlScript("Localities\\CreateLocality.sql");
      var name = new SqlParameter("@name", locality.name);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        name
      );

      return numberOfAffectedRows;
    }

    public int DeleteLocality(int id)
    {
      string script = ScriptsUtils.GetSqlScript("Localities\\DeleteLocality.sql");
      var localityId = new SqlParameter("@localityId", id);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        localityId
      );

      return numberOfAffectedRows;
    }

    public IEnumerable<Locality> GetAllLocalities()
    {
      string script = ScriptsUtils.GetSqlScript("Localities\\GetAllLocalities.sql");
      IEnumerable<Locality> localitys = _context.Localities.FromSqlRaw(script);

      return localitys;
    }

    public async Task<Locality> GetLocalityById(int id)
    {
      string script = ScriptsUtils.GetSqlScript("Localities\\GetLocalityById.sql");
      var localityId = new SqlParameter("@localityId", id);

      Locality locality = await _context.Localities.FromSqlRaw(
        script,
        localityId
      ).FirstAsync();

      return locality;
    }

    public int UpdateLocality(int id, Locality locality)
    {
      string script = ScriptsUtils.GetSqlScript("Localities\\UpdateLocality.sql");
      var localityId = new SqlParameter("@localityId", id);
      var name = new SqlParameter("@name", locality.name);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        localityId,
        name
      );

      return numberOfAffectedRows;
    }
  }
}