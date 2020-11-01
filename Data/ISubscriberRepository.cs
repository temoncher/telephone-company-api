using System.Collections.Generic;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public interface ISubscriberRepository
  {
    int CreateSubscribersTable();
    int DropSubscribersTable();
    int CreateSubscriber(Subscriber subscriber);
    IEnumerable<Subscriber> GetAllSubscribers();
    Subscriber GetSubscriberById(int id);
  }
}