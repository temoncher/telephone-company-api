using System.ComponentModel.DataAnnotations;

namespace SqlBackend.Models
{
  public class DaytimePrice
  {
    [Key]
    public int daytime_id { get; set; }
    [Key]
    public int price_id { get; set; }
    [Required]
    public int price_per_minute { get; set; }
  }
}