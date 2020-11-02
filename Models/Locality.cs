using System.ComponentModel.DataAnnotations;

namespace SqlBackend.Models
{
  public class Locality
  {
    [Key]
    public int locality_id { get; set; }
    [Required]
    [MaxLength(50)]
    public string name { get; set; }
  }
}