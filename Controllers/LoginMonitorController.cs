using LoginMonitorAPI.Dto;
using LoginMonitorAPI.Models;
using LoginMonitorAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoginMonitorAPI.Controllers;

[ApiController]
// [Route("api/[controller]")]
public class LoginMonitorController : ControllerBase
{
    private readonly ILoginMonitorService _loginMonitorService;

    public LoginMonitorController(ILoginMonitorService loginMonitorService)
    {
        _loginMonitorService = loginMonitorService;
    }

    [HttpGet("api/logins")]
    public async Task<ActionResult<List<LoginMonitorEvent>>> GetLoginMonitorEvents()
    {
        var loginMonitorEvents = await _loginMonitorService.GetLoginMonitorEventsAsync();
        return Ok(loginMonitorEvents);
    }

    [HttpGet("api/logins/{userId:int}")]
    public async Task<ActionResult<List<LoginMonitorEvent>>> GetLoginMonitorEvents(int userId)
    {
        var loginMonitorEventsForUser = await _loginMonitorService.GetLoginMonitorEventsForUserAsync(userId);
        return Ok(loginMonitorEventsForUser);
    }

    [HttpGet("api/login/{id:int}")]
    public async Task<ActionResult<LoginMonitorEvent>> GetLoginMonitorEvent(int id)
    {
        var loginMonitorEvent = await _loginMonitorService.GetLoginMonitorEventAsync(id);
        if (loginMonitorEvent == null) return NotFound();
        return Ok(loginMonitorEvent);
    }

    [HttpPost("api/login")]
    public async Task<ActionResult<LoginMonitorEvent>> PostLoginMonitorEvent([FromBody] LoginEventDto? loginDto)
    {
        var role = HttpContext.Items["Role"] as string;
        
        if (role != "Admin") return Unauthorized();
        if (loginDto == null) return BadRequest();
        
        var loginMonitorEvent = new LoginMonitorEvent
        {
            UserId = loginDto.UserId,
            FirstName = loginDto.FirstName,
            LastName = loginDto.LastName,
            IpAddress = loginDto.IpAddress,
            UserAgent = loginDto.UserAgent,
            LoginTime = loginDto.LoginTime,
            WasSuccessful = loginDto.WasSuccessful
        };
        
        await _loginMonitorService.AddLoginMonitorEventAsync(loginMonitorEvent);
        return CreatedAtAction(nameof(GetLoginMonitorEvent), new { id = loginMonitorEvent.Id }, loginMonitorEvent);
    }
    
    [HttpPut("api/login/{id}")]
    public async Task<ActionResult<LoginMonitorEvent>> PutLoginMonitorEvent(int id, [FromBody] LoginEventDto? loginDto)
    {
        var role = HttpContext.Items["Role"] as string;
        if (role != "Admin") return Unauthorized();
        
        if (loginDto == null) return BadRequest();
        var existingLoginMonitorEvent = await _loginMonitorService.GetLoginMonitorEventAsync(id);
        if (existingLoginMonitorEvent == null) return NotFound();
        
        var loginMonitorEvent = new LoginMonitorEvent
        {
            Id = id,
            UserId = loginDto.UserId,
            FirstName = loginDto.FirstName,
            LastName = loginDto.LastName,
            IpAddress = loginDto.IpAddress,
            UserAgent = loginDto.UserAgent,
            LoginTime = loginDto.LoginTime,
            WasSuccessful = loginDto.WasSuccessful
        };
        
        await _loginMonitorService.UpdateLoginMonitorEventAsync(loginMonitorEvent);
        return Ok(loginMonitorEvent);
    }
    
    [HttpDelete("api/login/{id}")]
    public async Task<ActionResult> DeleteLoginMonitorEvent(int id)
    {
        var role = HttpContext.Items["Role"] as string;
        if (role != "Admin") return Unauthorized();
        
        var loginMonitorEvent = await _loginMonitorService.GetLoginMonitorEventAsync(id);
        if (loginMonitorEvent == null) return NotFound();
        await _loginMonitorService.DeleteLoginMonitorEventAsync(id);
        return NoContent();
    }
}