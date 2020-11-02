using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SqlBackend.Models;
using SqlBackend.Data;

namespace SqlBackend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class OrganisationsController : ControllerBase
  {
    private readonly IOrganisationRepository _repository;

    public OrganisationsController(IOrganisationRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Organisation>> GetAllOrganisations()
    {
      var organisations = _repository.GetAllOrganisations();

      return Ok(organisations);
    }

    [HttpPost]
    public ActionResult<int> CreateOrganisation(Organisation organisation)
    {
      int numberOfAffectedRows = _repository.CreateOrganisation(organisation);

      return Ok(numberOfAffectedRows);
    }

    [HttpPut("{id}")]
    public ActionResult<int> UpdateOrganisation(int id, Organisation organisation)
    {
      int numberOfAffectedRows = _repository.UpdateOrganisation(id, organisation);

      return Ok(numberOfAffectedRows);
    }

    [HttpDelete("{id}")]
    public ActionResult<int> DeleteOrganisation(int id)
    {
      int numberOfAffectedRows = _repository.DeleteOrganisation(id);

      return Ok(numberOfAffectedRows);
    }
  }
}