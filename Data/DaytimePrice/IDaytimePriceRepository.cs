using System.Collections.Generic;
using System.Threading.Tasks;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public interface IDaytimePriceRepository
  {
    int CreateDaytimePrice(DaytimePrice daytimePrice);
    int UpdateDaytimePrice(int price_id, int daytime_id, DaytimePrice daytimePrice);
    int DeleteDaytimePrice(int price_id, int daytime_id);
    IEnumerable<DaytimePrice> GetDaytimePricesByPriceId(int price_id);
    IEnumerable<DaytimePrice> GetAllDaytimePrices();
  }
}