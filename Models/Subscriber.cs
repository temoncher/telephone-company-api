using System.ComponentModel.DataAnnotations;

namespace SqlBackend.Models
{
  public class Subscriber
  {
    [Key]
    public int subscriber_id { get; set; }
    [Required]
    public int organisation_id { get; set; }
    [Required]
    public int account_id { get; set; }
    [Required]
    public int inn { get; set; }
    [Required]
    public string first_name { get; set; }
    [Required]
    public string last_name { get; set; }
    public string patronymic { get; set; }
    public string adress { get; set; }
  }
}