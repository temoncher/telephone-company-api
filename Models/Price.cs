using System.ComponentModel.DataAnnotations;

namespace SqlBackend.Models
{
  public interface IPrice
  {
    int price_id { get; set; }
    int locality_id { get; set; }
    string title { get; set; }
  }
  public class Price : IPrice
  {
    [Key]
    public int price_id { get; set; }
    [Required]
    public int locality_id { get; set; }
    [Required]
    [MaxLength(50)]
    public string title { get; set; }
  }

  public class PriceView : IPrice
  {
    public int price_id { get; set; }
    public int locality_id { get; set; }
    public string title { get; set; }
    public string locality_name { get; set; }
  }
}