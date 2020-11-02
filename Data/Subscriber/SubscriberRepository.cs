using System.Collections.Generic;
using SqlBackend.Models;
using SqlBackend.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace SqlBackend.Data
{
  public class SubscriberRepository : ISubscriberRepository
  {
    private readonly SubscriberContext _context;

    public SubscriberRepository(SubscriberContext context)
    {
      _context = context;
    }

    public int CreateSubscriber(Subscriber subscriber)
    {
      string script = ScriptsUtils.GetSqlScript("Subscribers\\CreateSubscriber.sql");
      var organisationId = new SqlParameter("@organisationId", subscriber.organisation_id);
      var inn = new SqlParameter("@inn", subscriber.inn);
      var adress = new SqlParameter("@adress", string.IsNullOrEmpty(subscriber.adress) ? SqlString.Null : subscriber.adress);
      var firstName = new SqlParameter("@firstName", subscriber.first_name);
      var lastName = new SqlParameter("@lastName", subscriber.last_name);
      var patronymic = new SqlParameter("@patronymic", string.IsNullOrEmpty(subscriber.patronymic) ? SqlString.Null : subscriber.patronymic);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        organisationId,
        inn,
        firstName,
        lastName,
        patronymic,
        adress
      );

      return numberOfAffectedRows;
    }

    public IEnumerable<Subscriber> GetAllSubscribers()
    {
      string script = ScriptsUtils.GetSqlScript("Subscribers\\GetAllSubscribers.sql");
      IEnumerable<Subscriber> subscribers = _context.Subsrcibers.FromSqlRaw(script);

      return subscribers;
    }

    public async Task<Subscriber> GetSubscriberById(int id)
    {
      string script = ScriptsUtils.GetSqlScript("Subscribers\\GetSubscriberById.sql");
      var subscriberId = new SqlParameter("@subscriberId", id);

      Subscriber subscriber = await _context.Subsrcibers.FromSqlRaw(
        script,
        subscriberId
      ).FirstAsync();

      return subscriber;
    }

    public int UpdateSubscriber(int id, Subscriber subscriber)
    {
      string script = ScriptsUtils.GetSqlScript("Subscribers\\UpdateSubscriber.sql");
      var subscriberId = new SqlParameter("@subscriberId", id);
      var organisationId = new SqlParameter("@organisationId", subscriber.organisation_id);
      var inn = new SqlParameter("@inn", subscriber.inn);
      var adress = new SqlParameter("@adress", string.IsNullOrEmpty(subscriber.adress) ? SqlString.Null : subscriber.adress);
      var firstName = new SqlParameter("@firstName", subscriber.first_name);
      var lastName = new SqlParameter("@lastName", subscriber.last_name);
      var patronymic = new SqlParameter("@patronymic", string.IsNullOrEmpty(subscriber.patronymic) ? SqlString.Null : subscriber.patronymic);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        subscriberId,
        organisationId,
        inn,
        adress,
        firstName,
        lastName,
        patronymic
      );

      return numberOfAffectedRows;
    }

    public int DeleteSubscriber(int id)
    {
      string script = ScriptsUtils.GetSqlScript("Subscribers\\DeleteSubscriber.sql");
      var subscriberId = new SqlParameter("@subscriberId", id);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        subscriberId
      );

      return numberOfAffectedRows;
    }
  }
}