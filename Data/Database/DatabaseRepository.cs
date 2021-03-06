using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SqlBackend.Models;
using SqlBackend.Utils;

namespace SqlBackend.Data
{
  public class DatabaseRepository : IDatabaseRepository
  {
    private readonly DatabaseContext _context;

    public DatabaseRepository(DatabaseContext context)
    {
      _context = context;
    }

    public IEnumerable<Database> GetAllDatabases()
    {
      string script = ScriptsUtils.GetSqlScript("Databases\\GetAllDatabases.sql");

      return _context.Databases.FromSqlRaw(script);
    }

    public int CreateTables()
    {
      string script = ScriptsUtils.GetSqlScript("CreateTables.sql");
      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(script);

      return numberOfAffectedRows;
    }

    public int CreateViews()
    {
      string PricesGlobalViewScript = ScriptsUtils.GetSqlScript("Views\\PricesGlobalView.sql");
      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(PricesGlobalViewScript);
      string daytimePricesGlobalViewScript = ScriptsUtils.GetSqlScript("Views\\DaytimePricesGlobalView.sql");
      numberOfAffectedRows = numberOfAffectedRows + _context.Database.ExecuteSqlRaw(daytimePricesGlobalViewScript);
      string subscribersGlobalViewScript = ScriptsUtils.GetSqlScript("Views\\SubscribersGlobalView.sql");
      numberOfAffectedRows = numberOfAffectedRows + _context.Database.ExecuteSqlRaw(subscribersGlobalViewScript);
      string accountsGlobalViewScript = ScriptsUtils.GetSqlScript("Views\\AccountsGlobalView.sql");
      numberOfAffectedRows = numberOfAffectedRows + _context.Database.ExecuteSqlRaw(accountsGlobalViewScript);
      string transactionsGlobalViewScript = ScriptsUtils.GetSqlScript("Views\\TransactionsGlobalView.sql");
      numberOfAffectedRows = numberOfAffectedRows + _context.Database.ExecuteSqlRaw(transactionsGlobalViewScript);

      return numberOfAffectedRows;
    }

    public int CreateRoles()
    {
      string script = ScriptsUtils.GetSqlScript("CreateRoles.sql");
      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(script);

      return numberOfAffectedRows;
    }

    public int SetupTriggers()
    {
      string createAccountTriggerScript = ScriptsUtils.GetSqlScript("Triggers\\CreateAccountTrigger.sql");
      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(createAccountTriggerScript);
      string updateBalanceTriggerScript = ScriptsUtils.GetSqlScript("Triggers\\UpdateBalanceTrigger.sql");
      numberOfAffectedRows = numberOfAffectedRows + _context.Database.ExecuteSqlRaw(updateBalanceTriggerScript);
      string createTransactionAfterCallScript = ScriptsUtils.GetSqlScript("Triggers\\CreateTransactionAfterCall.sql");
      numberOfAffectedRows = numberOfAffectedRows + _context.Database.ExecuteSqlRaw(createTransactionAfterCallScript);
      string softDeleteCallsScript = ScriptsUtils.GetSqlScript("Triggers\\SoftDeleteCalls.sql");
      numberOfAffectedRows = numberOfAffectedRows + _context.Database.ExecuteSqlRaw(softDeleteCallsScript);

      return numberOfAffectedRows;
    }

    public int Seed()
    {
      string script = ScriptsUtils.GetSqlScript("Seed.sql");
      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(script);

      return numberOfAffectedRows;
    }
  }
}