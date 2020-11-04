using System.Collections.Generic;
using SqlBackend.Models;
using SqlBackend.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace SqlBackend.Data
{
  public class DaytimePriceRepository : IDaytimePriceRepository
  {
    private readonly DaytimePriceContext _context;

    public DaytimePriceRepository(DaytimePriceContext context)
    {
      _context = context;
    }

    public int CreateDaytimePrice(DaytimePrice daytimePrice)
    {
      string script = ScriptsUtils.GetSqlScript("DaytimePrices\\CreateDaytimePrice.sql");
      var daytimeId = new SqlParameter("@daytimeId", daytimePrice.daytime_id);
      var priceId = new SqlParameter("@priceId", daytimePrice.price_id);
      var pricePerMinute = new SqlParameter("@pricePerMinute", daytimePrice.price_per_minute);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        daytimeId,
        priceId,
        pricePerMinute
      );

      return numberOfAffectedRows;
    }

    public int DeleteDaytimePrice(int price_id, int daytime_id)
    {
      string script = ScriptsUtils.GetSqlScript("DaytimePrices\\DeleteDaytimePrice.sql");
      var priceId = new SqlParameter("@priceId", price_id);
      var daytimeId = new SqlParameter("@daytimeId", daytime_id);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        priceId,
        daytimeId
      );

      return numberOfAffectedRows;
    }

    public IEnumerable<DaytimePrice> GetAllDaytimePrices()
    {
      string script = ScriptsUtils.GetSqlScript("DaytimePrices\\GetAllDaytimePrices.sql");
      IEnumerable<DaytimePrice> daytimePrices = _context.DaytimePrices.FromSqlRaw(script);

      return daytimePrices;
    }

    public IEnumerable<DaytimePriceView> GetDaytimePricesTable()
    {
      string script = ScriptsUtils.GetSqlScript("DaytimePrices\\GetDaytimePricesTable.sql");
      IEnumerable<DaytimePriceView> daytimePrices = _context.DaytimePriceView.FromSqlRaw(script);

      return daytimePrices;
    }

    public IEnumerable<DaytimePrice> GetDaytimePricesByPriceId(int price_id)
    {
      string script = ScriptsUtils.GetSqlScript("DaytimePrices\\GetDaytimePricesByPriceId.sql");
      var priceId = new SqlParameter("@priceId", price_id);
      IEnumerable<DaytimePrice> daytimePrices = _context.DaytimePrices.FromSqlRaw(
        script,
        priceId
      );

      return daytimePrices;
    }

    public int UpdateDaytimePrice(int price_id, int daytime_id, DaytimePrice daytimePrice)
    {
      string script = ScriptsUtils.GetSqlScript("DaytimePrices\\UpdateDaytimePrice.sql");
      var priceId = new SqlParameter("@priceId", price_id);
      var daytimeId = new SqlParameter("@daytimeId", daytime_id);
      var pricePerMinute = new SqlParameter("@pricePerMinute", daytimePrice.price_per_minute);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        priceId,
        daytimeId,
        pricePerMinute
      );

      return numberOfAffectedRows;
    }
  }
}