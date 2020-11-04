using System.ComponentModel.DataAnnotations;

namespace SqlBackend.Models
{
  public interface IDaytimePrice
  {
    int daytime_id { get; set; }
    int price_id { get; set; }
    decimal price_per_minute { get; set; }
  }

  public class DaytimePrice : IDaytimePrice
  {
    [Key]
    public int daytime_id { get; set; }
    [Key]
    public int price_id { get; set; }
    [Required]
    public decimal price_per_minute { get; set; }
  }

  public class DaytimePriceView : IDaytimePrice
  {
    public int daytime_id { get; set; }
    public string daytime_title { get; set; }
    public int price_id { get; set; }
    public string price_title { get; set; }
    public decimal price_per_minute { get; set; }
  }
}