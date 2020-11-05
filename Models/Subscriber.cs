using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqlBackend.Models
{
  public interface ISubscriber {
    int subscriber_id { get; set; }
    int organisation_id { get; set; }
    int inn { get; set; }
    string first_name { get; set; }
    string last_name { get; set; }
    string patronymic { get; set; }
    string adress { get; set; }
  }
  public class Subscriber: ISubscriber
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int subscriber_id { get; set; }
    [Required]
    public int organisation_id { get; set; }
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
  public class SubscriberView: ISubscriber
  {
    public int subscriber_id { get; set; }
    public int inn { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string patronymic { get; set; }
    public string adress { get; set; }
    public int organisation_id { get; set; }
    public string organisation_name { get; set; }

  }
}