using System.ComponentModel.DataAnnotations;

namespace SqlBackend.Models
{
  public class Price
  {
    [Key]
    public int price_id { get; set; }
    [Required]
    public int locality_id { get; set; }
    [Required]
    [MaxLength(50)]
    public string title { get; set; }
  }
}