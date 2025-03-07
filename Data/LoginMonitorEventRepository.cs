using LoginMonitorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginMonitorAPI.Data;

public class LoginMonitorEventRepository : ILoginMonitorEventRepository
{
    private readonly AppDbContext _context;
    
    public LoginMonitorEventRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<LoginMonitorEvent?>> GetLoginMonitorEventsAsync()
    {
        return await _context.LoginMonitorEvents.ToListAsync();
    }

    public async Task<LoginMonitorEvent?> GetLoginMonitorEventAsync(int id)
    {
        return await _context.LoginMonitorEvents.FindAsync(id);
    }

    public async Task AddLoginMonitorEventAsync(LoginMonitorEvent? loginMonitorEvent)
    {
        _context.LoginMonitorEvents.Add(loginMonitorEvent);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateLoginMonitorEventAsync(LoginMonitorEvent? loginMonitorEvent)
    {
        _context.LoginMonitorEvents.Update(loginMonitorEvent);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteLoginMonitorEventAsync(int id)
    {
        var loginMonitorEvent = await _context.LoginMonitorEvents.FindAsync(id);
        if (loginMonitorEvent == null) return;
        _context.LoginMonitorEvents.Remove(loginMonitorEvent);
        await _context.SaveChangesAsync();
    }
}