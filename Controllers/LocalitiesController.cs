using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SqlBackend.Models;
using SqlBackend.Data;

namespace SqlBackend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class LocalitiesController : ControllerBase
  {
    private readonly ILocalityRepository _repository;

    public LocalitiesController(ILocalityRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Locality>> GetAllLocalities()
    {
      var localitys = _repository.GetAllLocalities();

      return Ok(localitys);
    }

    [HttpPut]
    public ActionResult<int> CreateLocality(Locality locality)
    {
      int numberOfAffectedRows = _repository.CreateLocality(locality);

      return Ok(numberOfAffectedRows);
    }

    [HttpPost("{id}")]
    public ActionResult<int> UpdateLocality(int id, Locality locality)
    {
      int numberOfAffectedRows = _repository.UpdateLocality(id, locality);

      return Ok(numberOfAffectedRows);
    }

    [HttpDelete("{id}")]
    public ActionResult<int> DeleteLocality(int id)
    {
      int numberOfAffectedRows = _repository.DeleteLocality(id);

      return Ok(numberOfAffectedRows);
    }
  }
}