using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SqlBackend.Models;
using SqlBackend.Data;

namespace SqlBackend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DaytimePricesController : ControllerBase
  {
    private readonly IDaytimePriceRepository _repository;

    public DaytimePricesController(IDaytimePriceRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DaytimePrice>> GetAllDaytimePrices()
    {
      var daytimePrices = _repository.GetAllDaytimePrices();

      return Ok(daytimePrices);
    }

    [HttpGet("{price_id}")]
    public ActionResult<IEnumerable<DaytimePrice>> GetDaytimePricesByPriceId(int price_id)
    {
      var daytimePrices = _repository.GetDaytimePricesByPriceId(price_id);

      return Ok(daytimePrices);
    }

    [HttpPost]
    public ActionResult<int> CreateDaytimePrice(DaytimePrice daytimePrice)
    {
      int numberOfAffectedRows = _repository.CreateDaytimePrice(daytimePrice);

      return Ok(numberOfAffectedRows);
    }

    [HttpPut]
    public ActionResult<int> UpdateDaytimePrice(DaytimePrice daytimePrice)
    {
      int numberOfAffectedRows = _repository.UpdateDaytimePrice(
        daytimePrice.price_id,
        daytimePrice.daytime_id,
        daytimePrice
      );

      return Ok(numberOfAffectedRows);
    }

    [HttpDelete]
    public ActionResult<int> DeleteDaytimePrice(DaytimePrice daytimePrice)
    {
      int numberOfAffectedRows = _repository.DeleteDaytimePrice(daytimePrice.price_id, daytimePrice.daytime_id);

      return Ok(numberOfAffectedRows);
    }
  }
}