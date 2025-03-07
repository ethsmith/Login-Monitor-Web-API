using LoginMonitorAPI.Models;
using LoginMonitorAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoginMonitorAPI.Controllers;

[ApiController]
[Route("api/login-events")]
public class LoginMonitorController : ControllerBase
{
    private readonly ILoginMonitorService _loginMonitorService;

    public LoginMonitorController(ILoginMonitorService loginMonitorService)
    {
        _loginMonitorService = loginMonitorService;
    }

    [HttpGet]
    public async Task<ActionResult<List<LoginMonitorEvent>>> GetLoginMonitorEvents()
    {
        var loginMonitorEvents = await _loginMonitorService.GetLoginMonitorEventsAsync();
        return Ok(loginMonitorEvents);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<LoginMonitorEvent>> GetLoginMonitorEvent(int id)
    {
        var loginMonitorEvent = await _loginMonitorService.GetLoginMonitorEventAsync(id);
        if (loginMonitorEvent == null) return NotFound();
        return Ok(loginMonitorEvent);
    }

    [HttpPost]
    public async Task<ActionResult<LoginMonitorEvent>> PostLoginMonitorEvent([FromBody] LoginMonitorEvent? loginMonitorEvent)
    {
        var role = HttpContext.Items["Role"] as string;
        if (role != "Admin") return Unauthorized();
        
        if (loginMonitorEvent == null) return BadRequest();
        await _loginMonitorService.AddLoginMonitorEventAsync(loginMonitorEvent);
        return CreatedAtAction(nameof(GetLoginMonitorEvent), new { id = loginMonitorEvent.Id }, loginMonitorEvent);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<LoginMonitorEvent>> PutLoginMonitorEvent(int id, [FromBody] LoginMonitorEvent? loginMonitorEvent)
    {
        var role = HttpContext.Items["Role"] as string;
        if (role != "Admin") return Unauthorized();
        
        if (loginMonitorEvent == null || loginMonitorEvent.Id != id) return BadRequest();
        var existingLoginMonitorEvent = await _loginMonitorService.GetLoginMonitorEventAsync(id);
        if (existingLoginMonitorEvent == null) return NotFound();
        await _loginMonitorService.UpdateLoginMonitorEventAsync(loginMonitorEvent);
        return Ok(loginMonitorEvent);
    }
    
    [HttpDelete("{id}")]
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