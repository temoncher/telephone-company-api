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

    [HttpGet]
    public ActionResult<IEnumerable<Subscriber>> GetAllSubscribers()
    {
      var subscribers = _repository.GetAllSubscribers();

      return Ok(subscribers);
    }

    [HttpPost]
    public ActionResult<int> CreateSubscriber(Subscriber subscriber)
    {
      var numberOfAffectedRows = _repository.CreateSubscriber(subscriber);

      return Ok(numberOfAffectedRows);
    }

    [HttpGet("{id}")]
    public ActionResult<Subscriber> GetSubscriberById(int id)
    {
      var subscriber = _repository.GetSubscriberById(id);

      return Ok(subscriber);
    }

    [HttpPost("{id}")]
    public ActionResult<Subscriber> UpdateSubscriber(int id, Subscriber subscriber)
    {
      var numberOfAffectedRows = _repository.UpdateSubscriber(id, subscriber);

      return Ok(numberOfAffectedRows);
    }

    [HttpDelete("{id}")]
    public ActionResult<Subscriber> DeleteSubscriber(int id)
    {
      var numberOfAffectedRows = _repository.DeleteSubscriber(id);

      return Ok(numberOfAffectedRows);
    }
  }
}