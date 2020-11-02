using System.Collections.Generic;
using System.Threading.Tasks;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public interface ILocalityRepository
  {
    int CreateLocality(Locality locality);
    int UpdateLocality(int id, Locality locality);
    int DeleteLocality(int id);
    IEnumerable<Locality> GetAllLocalities();
    Task<Locality> GetLocalityById(int id);
  }
}