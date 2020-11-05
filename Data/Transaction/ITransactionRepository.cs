using System.Collections.Generic;
using System.Threading.Tasks;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public interface ITransactionRepository
  {
    int CreateTransaction(Transaction Transaction);
    IEnumerable<Transaction> GetAllTransactions();
    IEnumerable<TransactionView> GetTransactionsTable();
    Task<Transaction> GetTransactionById(int id);
  }
}