using System.ComponentModel.DataAnnotations;

namespace SqlBackend.Models
{
  public interface IAccount
  {
    int account_id { get; set; }
    int subscriber_id { get; set; }
    decimal balance { get; set; }
  }
  public class Account : IAccount
  {
    [Key]
    public int account_id { get; set; }
    [Required]
    public int subscriber_id { get; set; }
    [Required]
    public decimal balance { get; set; }
  }
  public class AccountView : IAccount
  {
    public int account_id { get; set; }
    public decimal balance { get; set; }
    public int subscriber_id { get; set; }
    public string subscriber_full_name { get; set; }
  }
}