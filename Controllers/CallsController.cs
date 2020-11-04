using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SqlBackend.Models;
using SqlBackend.Data;

namespace SqlBackend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CallsController : ControllerBase
  {
    private readonly ICallRepository _repository;

    public CallsController(ICallRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Call>> GetAllCalls()
    {
      var calls = _repository.GetAllCalls();

      return Ok(calls);
    }

    [HttpGet("subscriber/{subscriber_id}")]
    public ActionResult<IEnumerable<Call>> GetCallsBySubscriberId(int subscriber_id)
    {
      var calls = _repository.GetCallsBySubscriberId(subscriber_id);

      return Ok(calls);
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Call>> GetCallById(int id)
    {
      var call = _repository.GetCallById(id);

      return Ok(call);
    }

    [HttpPost]
    public ActionResult<int> CreateCall(Call call)
    {
      int numberOfAffectedRows = _repository.CreateCall(call);

      return Ok(numberOfAffectedRows);
    }

    [HttpDelete("{call_id}")]
    public ActionResult<int> DeleteCall(int call_id)
    {
      int numberOfAffectedRows = _repository.DeleteCall(call_id);

      return Ok(numberOfAffectedRows);
    }

    [HttpPut("{call_id}")]
    public ActionResult<int> RestoreCall(int call_id)
    {
      int numberOfAffectedRows = _repository.RestoreCall(call_id);

      return Ok(numberOfAffectedRows);
    }
  }
}