using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SqlBackend.Models;
using SqlBackend.Data;

namespace SqlBackend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class SubscribersController : ControllerBase
  {
    private readonly MockSqlBackendRepo _repository = new MockSqlBackendRepo();

    [HttpGet]
    public ActionResult<IEnumerable<Subscriber>> GetAllSubscribers()
    {
      var subscribers = _repository.GetAllSubscribers();

      return Ok(subscribers);
    }

    [HttpGet("{id}")]
    public ActionResult<Subscriber> GetSubscriberById(string id)
    {
      var subscriber = _repository.GetSubscriberById(id);

      return Ok(subscriber);

    }
  }
}