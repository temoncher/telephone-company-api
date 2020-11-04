using System;
using System.ComponentModel.DataAnnotations;

namespace SqlBackend.Models
{
  public class Transaction
  {
    [Key]
    public int transaction_id { get; set; }
    [Required]
    public int transaction_type_id { get; set; }
    [Required]
    public int account_id { get; set; }
    [Required]
    public decimal amount { get; set; }
    public DateTime timestamp { get; set; }
  }
}