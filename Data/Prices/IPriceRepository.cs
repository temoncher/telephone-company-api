using System.Collections.Generic;
using System.Threading.Tasks;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public interface IPriceRepository
  {
    int CreatePrice(Price price);
    int UpdatePrice(int id, Price price);
    int DeletePrice(int id);
    IEnumerable<Price> GetAllPrices();
    Task<Price> GetPriceById(int id);
  }
}