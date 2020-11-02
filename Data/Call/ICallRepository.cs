using System.Collections.Generic;
using System.Threading.Tasks;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public interface ICallRepository
  {
    int CreateCall(Call Call);
    IEnumerable<Call> GetAllCalls();
    IEnumerable<Call> GetCallsBySubscriberId(int subscriber_id);
    Task<Call> GetCallById(int id);
  }
}