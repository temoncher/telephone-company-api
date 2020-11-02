using System.Collections.Generic;
using System.Threading.Tasks;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public interface IDaytimeRepository
  {
    int CreateDaytime(Daytime Daytime);
    int UpdateDaytime(int id, Daytime Daytime);
    int DeleteDaytime(int id);
    IEnumerable<Daytime> GetAllDaytimes();
    Task<Daytime> GetDaytimeById(int id);
  }
}