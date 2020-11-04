using System;
using System.ComponentModel.DataAnnotations;

namespace SqlBackend.Models
{
  public class Call
  {
    [Key]
    public int call_id { get; set; }
    [Required]
    public int subscriber_id { get; set; }
    public int? daytime_id { get; set; }
    public int? locality_id { get; set; }
    [Required]
    public int duration { get; set; }
    [Required]
    public DateTime timestamp { get; set; }
    public DateTime? deleted_at { get; set; }
  }
}