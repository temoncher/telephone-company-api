using System.Collections.Generic;
using SqlBackend.Models;
using SqlBackend.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace SqlBackend.Data
{
  public class TransactionRepository : ITransactionRepository
  {
    private readonly TransactionContext _context;

    public TransactionRepository(TransactionContext context)
    {
      _context = context;
    }

    public int CreateTransaction(Transaction transaction)
    {
      string script = ScriptsUtils.GetSqlScript("Transactions\\CreateTransaction.sql");
      var transactionTypeId = new SqlParameter("@transactionTypeId", transaction.transaction_type_id);
      var accountId = new SqlParameter("@accountId", transaction.account_id);
      var amount = new SqlParameter("@amount", transaction.amount);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        accountId,
        amount
      );

      return numberOfAffectedRows;
    }

    public IEnumerable<Transaction> GetAllTransactions()
    {
      string script = ScriptsUtils.GetSqlScript("Transactions\\GetAllTransactions.sql");
      IEnumerable<Transaction> transactions = _context.Transactions.FromSqlRaw(script);

      return transactions;
    }

    public async Task<Transaction> GetTransactionById(int id)
    {
      string script = ScriptsUtils.GetSqlScript("Transactions\\GetTransactionById.sql");
      var transactionId = new SqlParameter("@transactionId", id);

      Transaction transaction = await _context.Transactions.FromSqlRaw(
        script,
        transactionId
      ).FirstAsync();

      return transaction;
    }
  }
}