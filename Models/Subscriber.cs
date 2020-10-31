using System.ComponentModel.DataAnnotations;

namespace SqlBackend.Models
{
  public class Subscriber
  {
    [Key]
    public string Id { get; set; }
    [Required]
    public string Inn { get; set; }
    [Required]
    public string Adress { get; set; }
    [Required]
    public string OrganistaionName { get; set; }
    [Required]
    public string Account { get; set; }
  }
}