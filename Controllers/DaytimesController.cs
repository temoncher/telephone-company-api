using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SqlBackend.Models;
using SqlBackend.Data;

namespace SqlBackend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DaytimesController : ControllerBase
  {
    private readonly IDaytimeRepository _repository;

    public DaytimesController(IDaytimeRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Daytime>> GetAllDaytimes()
    {
      var daytimes = _repository.GetAllDaytimes();

      return Ok(daytimes);
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Daytime>> GetDaytimeById(int id)
    {
      var daytime = _repository.GetDaytimeById(id);

      return Ok(daytime);
    }

    [HttpPost]
    public ActionResult<int> CreateDaytime(Daytime daytime)
    {
      int numberOfAffectedRows = _repository.CreateDaytime(daytime);

      return Ok(numberOfAffectedRows);
    }

    [HttpPut("{id}")]
    public ActionResult<int> UpdateDaytime(int id, Daytime daytime)
    {
      int numberOfAffectedRows = _repository.UpdateDaytime(id, daytime);

      return Ok(numberOfAffectedRows);
    }

    [HttpDelete("{id}")]
    public ActionResult<int> DeleteDaytime(int id)
    {
      int numberOfAffectedRows = _repository.DeleteDaytime(id);

      return Ok(numberOfAffectedRows);
    }
  }
}