using System.Collections.Generic;
using System.Threading.Tasks;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public interface ITransactionTypeRepository
  {
    int CreateTransactionType(TransactionType TransactionType);
    int UpdateTransactionType(int id, TransactionType TransactionType);
    int DeleteTransactionType(int id);
    IEnumerable<TransactionType> GetAllTransactionTypes();
    Task<TransactionType> GetTransactionTypeById(int id);
  }
}