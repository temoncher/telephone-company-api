using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SqlBackend.Models;
using SqlBackend.Data;

namespace SqlBackend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TransactionTypesController : ControllerBase
  {
    private readonly ITransactionTypeRepository _repository;

    public TransactionTypesController(ITransactionTypeRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TransactionType>> GetAllTransactionTypes()
    {
      var transactionTypes = _repository.GetAllTransactionTypes();

      return Ok(transactionTypes);
    }

    [HttpPut]
    public ActionResult<int> CreateTransactionType(TransactionType transactionType)
    {
      int numberOfAffectedRows = _repository.CreateTransactionType(transactionType);

      return Ok(numberOfAffectedRows);
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<TransactionType>> GetTransactionTypeById(int id)
    {
      var transactionType = _repository.GetTransactionTypeById(id);

      return Ok(transactionType);
    }

    [HttpPost("{id}")]
    public ActionResult<int> UpdateTransactionType(int id, TransactionType transactionType)
    {
      int numberOfAffectedRows = _repository.UpdateTransactionType(id, transactionType);

      return Ok(numberOfAffectedRows);
    }

    [HttpDelete("{id}")]
    public ActionResult<int> DeleteTransactionType(int id)
    {
      int numberOfAffectedRows = _repository.DeleteTransactionType(id);

      return Ok(numberOfAffectedRows);
    }
  }
}