using System.Collections.Generic;
using SqlBackend.Models;
using SqlBackend.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace SqlBackend.Data
{
  public class CallRepository : ICallRepository
  {
    private readonly CallContext _context;

    public CallRepository(CallContext context)
    {
      _context = context;
    }

    public int CreateCall(Call call)
    {
      string script = ScriptsUtils.GetSqlScript("Calls\\CreateCall.sql");
      var subscriberId = new SqlParameter("@subscriberId", call.subscriber_id);
      var localityId = new SqlParameter("@localityId", call.locality_id);
      var duration = new SqlParameter("@duration", call.duration);
      var daytimeId = new SqlParameter("@daytimeId", call.daytime_id);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        subscriberId,
        localityId,
        daytimeId,
        duration
      );

      return numberOfAffectedRows;
    }

    public int DeleteCall(int call_id)
    {
      string script = ScriptsUtils.GetSqlScript("Calls\\DeleteCall.sql");
      var callId = new SqlParameter("@callId", call_id);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        callId
      );

      return numberOfAffectedRows;
    }
    public int RestoreCall(int call_id)
    {
      string script = ScriptsUtils.GetSqlScript("Calls\\RestoreCall.sql");
      var callId = new SqlParameter("@callId", call_id);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        callId
      );

      return numberOfAffectedRows;
    }

    public IEnumerable<Call> GetAllCalls()
    {
      string script = ScriptsUtils.GetSqlScript("Calls\\GetAllCalls.sql");
      IEnumerable<Call> calls = _context.Calls.FromSqlRaw(script);

      return calls;
    }

    public IEnumerable<Call> GetCallsBySubscriberId(int subscriber_id)
    {
      string script = ScriptsUtils.GetSqlScript("Calls\\GetCallsBySubscriberId.sql");
      var subscriberId = new SqlParameter("@subscriberId", subscriber_id);
      IEnumerable<Call> calls = _context.Calls.FromSqlRaw(
        script,
        subscriberId
      );

      return calls;
    }

    public async Task<Call> GetCallById(int id)
    {
      string script = ScriptsUtils.GetSqlScript("Calls\\GetCallById.sql");
      var callId = new SqlParameter("@callId", id);

      Call call = await _context.Calls.FromSqlRaw(
        script,
        callId
      ).FirstAsync();

      return call;
    }
  }
}