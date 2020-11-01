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
    private readonly ISubscriberRepository _repository;

    public SubscribersController(ISubscriberRepository repository)
    {
      _repository = repository;
    }

    [HttpPost]
    public ActionResult<int> CreateSubscribersTable()
    {
      var numberOfAffectedRows = _repository.CreateSubscribersTable();

      return Ok(numberOfAffectedRows);
    }

    [HttpDelete]
    public ActionResult<int> DropSubscribersTable()
    {
      var numberOfAffectedRows = _repository.DropSubscribersTable();

      return Ok(numberOfAffectedRows);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Subscriber>> GetAllSubscribers()
    {
      var subscribers = _repository.GetAllSubscribers();

      return Ok(subscribers);
    }

    [HttpPut]
    public ActionResult<int> CreateSubscriber()
    {
      var subscriber = new Subscriber
      {
        subscriber_id = 2,
        organisation_id = 3,
        account_id = 124,
        inn = 124,
        adress = "Some adress",
        first_name = "Artem",
        last_name = "Baranov"
      };
      var numberOfAffectedRows = _repository.CreateSubscriber(subscriber);

      return Ok(numberOfAffectedRows);
    }

    [HttpGet("{id}")]
    public ActionResult<Subscriber> GetSubscriberById(int id)
    {
      var subscriber = _repository.GetSubscriberById(id);

      return Ok(subscriber);

    }
  }
}