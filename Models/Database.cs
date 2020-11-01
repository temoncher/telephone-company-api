using System.ComponentModel.DataAnnotations;

namespace SqlBackend.Models
{
  public class Database
  {
    [Key]
    public string database_id { get; set; }
    public string name { get; set; }
  }
}