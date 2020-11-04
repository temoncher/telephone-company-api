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

    [HttpPost("tables")]
    public ActionResult<int> CreateTables()
    {
      int numberOfAffectedRows = _repository.CreateTables();

      return Ok(numberOfAffectedRows);
    }

    [HttpPost("views")]
    public ActionResult<int> CreateViews()
    {
      int numberOfAffectedRows = _repository.CreateViews();

      return Ok(numberOfAffectedRows);
    }

    [HttpPost("roles")]
    public ActionResult<int> CreateRoles()
    {
      int numberOfAffectedRows = _repository.CreateRoles();

      return Ok(numberOfAffectedRows);
    }

    [HttpPost("triggers")]
    public ActionResult<int> SetupTriggers()
    {
      int numberOfAffectedRows = _repository.SetupTriggers();

      return Ok(numberOfAffectedRows);
    }

    [HttpPost("seed")]
    public ActionResult<int> Seed()
    {
      int numberOfAffectedRows = _repository.Seed();

      return Ok(numberOfAffectedRows);
    }
  }
}