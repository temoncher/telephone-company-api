using System.Collections.Generic;
using System.Threading.Tasks;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public interface ISubscriberRepository
  {
    int CreateSubscriber(Subscriber subscriber);
    int UpdateSubscriber(int id, Subscriber subscriber);
    int DeleteSubscriber(int id);
    IEnumerable<Subscriber> GetAllSubscribers();
    IEnumerable<SubscriberView> GetSubscribersTable();
    Task<Subscriber> GetSubscriberById(int id);
  }
}