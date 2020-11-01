using Microsoft.EntityFrameworkCore;
using SqlBackend.Models;

namespace SqlBackend.Data
{
  public class OrganisationContext : DbContext
  {
    public OrganisationContext(DbContextOptions<OrganisationContext> opt) : base(opt) { }

    public DbSet<Organisation> Subsrcibers { get; set; }
  }
}