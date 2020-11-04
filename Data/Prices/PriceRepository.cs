using System.Collections.Generic;
using SqlBackend.Models;
using SqlBackend.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace SqlBackend.Data
{
  public class PriceRepository : IPriceRepository
  {
    private readonly PriceContext _context;

    public PriceRepository(PriceContext context)
    {
      _context = context;
    }

    public int CreatePrice(Price price)
    {
      string script = ScriptsUtils.GetSqlScript("Prices\\CreatePrice.sql");
      var localityId = new SqlParameter("@localityId", price.locality_id);
      var title = new SqlParameter("@title", price.title);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        localityId,
        title
      );

      return numberOfAffectedRows;
    }

    public int DeletePrice(int id)
    {
      string script = ScriptsUtils.GetSqlScript("Prices\\DeletePrice.sql");
      var priceId = new SqlParameter("@priceId", id);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        priceId
      );

      return numberOfAffectedRows;
    }

    public IEnumerable<Price> GetAllPrices()
    {
      string script = ScriptsUtils.GetSqlScript("Prices\\GetAllPrices.sql");
      IEnumerable<Price> prices = _context.Prices.FromSqlRaw(script);

      return prices;
    }

    public IEnumerable<PriceView> GetPricesTable()
    {
      string script = ScriptsUtils.GetSqlScript("Prices\\GetPricesTable.sql");
      IEnumerable<PriceView> prices = _context.PriceView.FromSqlRaw(script);

      return prices;
    }

    public async Task<Price> GetPriceById(int id)
    {
      string script = ScriptsUtils.GetSqlScript("Prices\\GetPriceById.sql");
      var priceId = new SqlParameter("@priceId", id);

      Price price = await _context.Prices.FromSqlRaw(
        script,
        priceId
      ).FirstAsync();

      return price;
    }

    public int UpdatePrice(int id, Price price)
    {
      string script = ScriptsUtils.GetSqlScript("Prices\\UpdatePrice.sql");
      var priceId = new SqlParameter("@priceId", id);
      var localityId = new SqlParameter("@localityId", price.locality_id);
      var title = new SqlParameter("@title", price.title);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        priceId,
        localityId,
        title
      );

      return numberOfAffectedRows;
    }
  }
}