namespace LoginMonitorAPI.Dto;

public class LoginEventDto
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IpAddress { get; set; }
    public string UserAgent { get; set; }
    public DateTime LoginTime { get; set; }
    public bool WasSuccessful { get; set; }
}