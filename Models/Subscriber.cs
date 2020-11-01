using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqlBackend.Models
{
  public class Subscriber
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int subscriber_id { get; set; }
    [Required]
    public int organisation_id { get; set; }
    [Required]
    public int account_id { get; set; }
    [Required]
    public int inn { get; set; }
    [Required]
    [MaxLength(30)]
    public string first_name { get; set; }
    [Required]
    [MaxLength(30)]
    public string last_name { get; set; }
    [MaxLength(30)]
    public string patronymic { get; set; }
    [MaxLength(50)]
    public string adress { get; set; }
  }
}