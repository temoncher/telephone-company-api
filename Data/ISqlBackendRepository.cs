using System.Collections.Generic;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public interface ISqlBackendRepository
  {
    IEnumerable<Subscriber> GetAllSubscribers();
    Subscriber GetSubscriberById(string id);
  }
}