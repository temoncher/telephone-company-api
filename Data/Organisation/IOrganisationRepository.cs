using System.Collections.Generic;
using System.Threading.Tasks;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public interface IOrganisationRepository
  {
    int CreateOrganisationsTable();
    int DropOrganisationsTable();
    int CreateOrganisation(Organisation organisation);
    int UpdateOrganisation(Organisation organisation);
    int DeleteOrganisation(int id);
    IEnumerable<Organisation> GetAllOrganisations();
    Task<Organisation> GetOrganisationById(int id);
  }
}