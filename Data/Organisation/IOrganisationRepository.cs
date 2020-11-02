using System.Collections.Generic;
using System.Threading.Tasks;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public interface IOrganisationRepository
  {
    int CreateOrganisation(Organisation organisation);
    int UpdateOrganisation(int id, Organisation organisation);
    int DeleteOrganisation(int id);
    IEnumerable<Organisation> GetAllOrganisations();
    Task<Organisation> GetOrganisationById(int id);
  }
}