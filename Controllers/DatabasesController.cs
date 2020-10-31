using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SqlBackend.Models;
using SqlBackend.Data;

namespace SqlBackend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DatabasesController : ControllerBase
  {
    private readonly IDatabaseRepository _repository;

    public DatabasesController(IDatabaseRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Database>> GetAllDatabases()
    {
      var databases = _repository.GetAllDatabases();

      return Ok(databases);
    }

    [HttpPost]
    public ActionResult<int> CreateDatabase()
    {
      int numberOfAffectedRows = _repository.CreateDatabase();

      return Ok(numberOfAffectedRows);
    }

    [HttpDelete]
    public ActionResult<int> DropDatabase()
    {
      int numberOfAffectedRows = _repository.DropDatabase();

      return Ok(numberOfAffectedRows);
    }
  }
}