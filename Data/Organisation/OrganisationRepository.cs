using System.Collections.Generic;
using SqlBackend.Models;
using SqlBackend.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;
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
      throw new System.NotImplementedException();
    }

    public int CreateOrganisationsTable()
    {
      throw new System.NotImplementedException();
    }

    public int DeleteOrganisation(int id)
    {
      throw new System.NotImplementedException();
    }

    public int DropOrganisationsTable()
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<Organisation> GetAllOrganisations()
    {
      throw new System.NotImplementedException();
    }

    public Task<Organisation> GetOrganisationById(int id)
    {
      throw new System.NotImplementedException();
    }

    public int UpdateOrganisation(Organisation organisation)
    {
      throw new System.NotImplementedException();
    }
  }
}