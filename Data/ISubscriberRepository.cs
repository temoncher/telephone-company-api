using System.Collections.Generic;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public interface ISubscriberRepository
  {
    IEnumerable<Subscriber> GetAllSubscribers();
    Subscriber GetSubscriberById(string id);
  }
}