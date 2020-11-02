using System.ComponentModel.DataAnnotations;

namespace SqlBackend.Models
{
  public class TransactionType
  {
    [Key]
    public int transaction_type_id { get; set; }
    [Required]
    [MaxLength(50)]
    public string title { get; set; }
  }
}