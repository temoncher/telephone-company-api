using System;
using System.ComponentModel.DataAnnotations;

namespace SqlBackend.Models
{
  public interface ITransaction
  {
    int transaction_id { get; set; }
    int transaction_type_id { get; set; }
    int account_id { get; set; }
    decimal amount { get; set; }
    DateTime timestamp { get; set; }
  }
  public class Transaction : ITransaction
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
  public class TransactionView : ITransaction
  {
    public int transaction_id { get; set; }
    public decimal amount { get; set; }
    public DateTime timestamp { get; set; }
    public int account_id { get; set; }
    public string subscriber_full_name { get; set; }
    public int transaction_type_id { get; set; }
    public string transaction_type_title { get; set; }
  }
}