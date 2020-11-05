using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SqlBackend.Models;
using SqlBackend.Data;

namespace SqlBackend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AccountsController : ControllerBase
  {
    private readonly IAccountRepository _repository;

    public AccountsController(IAccountRepository repository)
    {
      _repository = repository;
    }
    // TODO: Add readonly table

    [HttpGet]
    public ActionResult<IEnumerable<Account>> GetAllAccounts()
    {
      var accounts = _repository.GetAllAccounts();

      return Ok(accounts);
    }
  }
}