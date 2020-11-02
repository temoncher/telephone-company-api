using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SqlBackend.Models;
using SqlBackend.Data;

namespace SqlBackend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PricesController : ControllerBase
  {
    private readonly IPriceRepository _repository;

    public PricesController(IPriceRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Price>> GetAllPrices()
    {
      var prices = _repository.GetAllPrices();

      return Ok(prices);
    }

    [HttpPost]
    public ActionResult<int> CreatePrice(Price price)
    {
      int numberOfAffectedRows = _repository.CreatePrice(price);

      return Ok(numberOfAffectedRows);
    }

    [HttpPost("{id}")]
    public ActionResult<int> UpdatePrice(int id, Price price)
    {
      int numberOfAffectedRows = _repository.UpdatePrice(id, price);

      return Ok(numberOfAffectedRows);
    }

    [HttpDelete("{id}")]
    public ActionResult<int> DeletePrice(int id)
    {
      int numberOfAffectedRows = _repository.DeletePrice(id);

      return Ok(numberOfAffectedRows);
    }
  }
}