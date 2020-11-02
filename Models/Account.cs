using System.ComponentModel.DataAnnotations;

namespace SqlBackend.Models
{
  public class Account
  {
    [Key]
    public int account_id { get; set; }
    [Required]
    public int subscriber_id { get; set; }
    [Required]
    public int balance { get; set; }
  }
}