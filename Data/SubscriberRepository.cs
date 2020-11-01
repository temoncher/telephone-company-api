using System.Collections.Generic;
using SqlBackend.Models;
using SqlBackend.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace SqlBackend.Data
{
  public class SubscriberRepository : ISubscriberRepository
  {
    private readonly SubscriberContext _context;

    public SubscriberRepository(SubscriberContext context)
    {
      _context = context;
    }

    public int CreateSubscribersTable()
    {
      string script = ScriptsUtils.GetSqlScript("Subscribers\\CreateSubscribersTable.sql");
      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(script);

      return numberOfAffectedRows;
    }

    public int DropSubscribersTable()
    {
      string script = ScriptsUtils.GetSqlScript("Subscribers\\DropSubscribersTable.sql");
      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(script);

      return numberOfAffectedRows;
    }

    public int CreateSubscriber(Subscriber subscriber)
    {
      string script = ScriptsUtils.GetSqlScript("Subscribers\\CreateSubscriber.sql");
      var subscriberId = new SqlParameter("@subscriberId", subscriber.subscriber_id);
      var organisationId = new SqlParameter("@organisationId", subscriber.organisation_id);
      var accountId = new SqlParameter("@accountId", subscriber.account_id);
      var inn = new SqlParameter("@inn", subscriber.inn);
      var adress = new SqlParameter("@adress", subscriber.adress);
      var firstName = new SqlParameter("@firstName", subscriber.first_name);
      var lastName = new SqlParameter("@lastName", subscriber.last_name);
      var patronymic = new SqlParameter("@patronymic", string.IsNullOrEmpty(subscriber.patronymic) ? SqlString.Null : subscriber.patronymic);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        subscriberId,
        organisationId,
        accountId,
        inn,
        adress,
        firstName,
        lastName,
        patronymic
      );

      return numberOfAffectedRows;
    }

    public IEnumerable<Subscriber> GetAllSubscribers()
    {
      string script = ScriptsUtils.GetSqlScript("Subscribers\\GetAllSubscribers.sql");
      IEnumerable<Subscriber> subscribers = _context.Subsrcibers.FromSqlRaw(script);

      return subscribers;
    }

    public Subscriber GetSubscriberById(int id)
    {
      var subscriber = new Subscriber
      {
        subscriber_id = id,
        organisation_id = 123,
        account_id = 12,
        inn = 528590256,
        adress = "adress",
        first_name = "bruh",
        last_name = "joe",
      };

      return subscriber;
    }
  }
}