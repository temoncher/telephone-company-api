using System.Collections.Generic;
using System.Threading.Tasks;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public interface ISubscriberRepository
  {
    int CreateSubscribersTable();
    int DropSubscribersTable();
    int CreateSubscriber(Subscriber subscriber);
    int UpdateSubscriber(Subscriber subscriber);
    int DeleteSubscriber(int id);
    IEnumerable<Subscriber> GetAllSubscribers();
    Task<Subscriber> GetSubscriberById(int id);
  }
}