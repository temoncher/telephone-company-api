using System.ComponentModel.DataAnnotations;

namespace SqlBackend.Models
{
  public class Organisation
  {
    [Key]
    public int organisation_id { get; set; }
    [Required]
    [MaxLength(50)]
    public string name { get; set; }
  }
}