using System.Collections.Generic;
using SqlBackend.Models;
using SqlBackend.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace SqlBackend.Data
{
  public class TransactionTypeRepository : ITransactionTypeRepository
  {
    private readonly TransactionTypeContext _context;

    public TransactionTypeRepository(TransactionTypeContext context)
    {
      _context = context;
    }

    public int CreateTransactionType(TransactionType transactionType)
    {
      string script = ScriptsUtils.GetSqlScript("TransactionTypes\\CreateTransactionType.sql");
      var title = new SqlParameter("@title", transactionType.title);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        title
      );

      return numberOfAffectedRows;
    }

    public IEnumerable<TransactionType> GetAllTransactionTypes()
    {
      string script = ScriptsUtils.GetSqlScript("TransactionTypes\\GetAllTransactionTypes.sql");
      IEnumerable<TransactionType> transactionTypes = _context.TransactionTypes.FromSqlRaw(script);

      return transactionTypes;
    }

    public async Task<TransactionType> GetTransactionTypeById(int id)
    {
      string script = ScriptsUtils.GetSqlScript("TransactionTypes\\GetTransactionTypeById.sql");
      var transactionTypeId = new SqlParameter("@transactionTypeId", id);

      TransactionType transactionType = await _context.TransactionTypes.FromSqlRaw(
        script,
        transactionTypeId
      ).FirstAsync();

      return transactionType;
    }

    public int UpdateTransactionType(int id, TransactionType transactionType)
    {
      string script = ScriptsUtils.GetSqlScript("TransactionTypes\\UpdateTransactionType.sql");
      var transactionTypeId = new SqlParameter("@transactionTypeId", id);
      var title = new SqlParameter("@title", transactionType.title);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        transactionTypeId,
        title
      );

      return numberOfAffectedRows;
    }

    public int DeleteTransactionType(int id)
    {
      string script = ScriptsUtils.GetSqlScript("TransactionTypes\\DeleteTransactionType.sql");
      var transactionTypeId = new SqlParameter("@transactionTypeId", id);

      int numberOfAffectedRows = _context.Database.ExecuteSqlRaw(
        script,
        transactionTypeId
      );

      return numberOfAffectedRows;
    }
  }
}