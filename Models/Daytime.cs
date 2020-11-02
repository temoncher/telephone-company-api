using System.ComponentModel.DataAnnotations;

namespace SqlBackend.Models
{
  public class Daytime
  {
    [Key]
    public int daytime_id { get; set; }
    [Required]
    [MaxLength(20)]
    public string title { get; set; }
  }
}