using System.Collections.Generic;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public class MockSubscriberRepo : ISubscriberRepository
  {
    public IEnumerable<Subscriber> GetAllSubscribers()
    {
      var subscribers = new List<Subscriber>
      {
        new Subscriber{ Id = "1", Inn = "Inn1", Account = "Something1", Adress = "Some adress1", OrganistaionName = "Organistaion name1" },
        new Subscriber{ Id = "2", Inn = "Inn2", Account = "Something2", Adress = "Some adress2", OrganistaionName = "Organistaion name2" },
        new Subscriber{ Id = "3", Inn = "Inn3", Account = "Something3", Adress = "Some adress3", OrganistaionName = "Organistaion name3" },
        new Subscriber{ Id = "4", Inn = "Inn4", Account = "Something4", Adress = "Some adress4", OrganistaionName = "Organistaion name2" },
        new Subscriber{ Id = "5", Inn = "Inn5", Account = "Something5", Adress = "Some adress5", OrganistaionName = "Organistaion name2" },
      };

      return subscribers;
    }

    public Subscriber GetSubscriberById(string id)
    {
      return new Subscriber
      {
        Id = id,
        Inn = "Inn",
        Account = "Something",
        Adress = "Some adress",
        OrganistaionName = "Organistaion name"
      };
    }
  }
}