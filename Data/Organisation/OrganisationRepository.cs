using System.Collections.Generic;
using SqlBackend.Models;
using SqlBackend.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace SqlBackend.Data
{
  public class OrganisationRepository : IOrganisationRepository
  {
    private readonly OrganisationContext _context;

    public OrganisationRepository(OrganisationContext context)
    {
      _context = context;
    }

    public int CreateOrganisation(Organisation organisation)
    {
      string script = ScriptsUtils.GetSqlScript("Organisations\\CreateOrganisation.sql");
      var name = new SqlParameter("@name", organisation.name);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        name
      );

      return numberOfAffectedRows;
    }

    public int DeleteOrganisation(int id)
    {
      string script = ScriptsUtils.GetSqlScript("Organisations\\DeleteOrganisation.sql");
      var organisationId = new SqlParameter("@organisationId", id);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        organisationId
      );

      return numberOfAffectedRows;
    }

    public IEnumerable<Organisation> GetAllOrganisations()
    {
      string script = ScriptsUtils.GetSqlScript("Organisations\\GetAllOrganisations.sql");
      IEnumerable<Organisation> organisations = _context.Organisations.FromSqlRaw(script);

      return organisations;
    }

    public async Task<Organisation> GetOrganisationById(int id)
    {
      string script = ScriptsUtils.GetSqlScript("Organisations\\GetOrganisationById.sql");
      var organisationId = new SqlParameter("@organisationId", id);

      Organisation organisation = await _context.Organisations.FromSqlRaw(
        script,
        organisationId
      ).FirstAsync();

      return organisation;
    }

    public int UpdateOrganisation(int id, Organisation organisation)
    {
      string script = ScriptsUtils.GetSqlScript("Organisations\\UpdateOrganisation.sql");
      var organisationId = new SqlParameter("@organisationId", id);
      var name = new SqlParameter("@name", organisation.name);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        organisationId,
        name
      );

      return numberOfAffectedRows;
    }
  }
}