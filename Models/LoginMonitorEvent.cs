using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginMonitorAPI.Models;

public class LoginMonitorEvent
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string IpAddress { get; set; }
    [Required]
    public string UserAgent { get; set; }
    [Required]
    public DateTime LoginTime { get; set; }
    [Required]
    public bool WasSuccessful { get; set; }
}