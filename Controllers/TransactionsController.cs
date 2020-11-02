using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SqlBackend.Models;
using SqlBackend.Data;

namespace SqlBackend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TransactionsController : ControllerBase
  {
    private readonly ITransactionRepository _repository;

    public TransactionsController(ITransactionRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Transaction>> GetAllTransactions()
    {
      var transactions = _repository.GetAllTransactions();

      return Ok(transactions);
    }

    [HttpPost]
    public ActionResult<int> CreateTransaction(Transaction transaction)
    {
      int numberOfAffectedRows = _repository.CreateTransaction(transaction);

      return Ok(numberOfAffectedRows);
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Transaction>> GetTransactionById(int id)
    {
      var transaction = _repository.GetTransactionById(id);

      return Ok(transaction);
    }
  }
}