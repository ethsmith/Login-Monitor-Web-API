using LoginMonitorAPI.Data;
using LoginMonitorAPI.Models;

namespace LoginMonitorAPI.Services;

public class LoginMonitorService : ILoginMonitorService
{
    private readonly ILoginMonitorEventRepository _loginMonitorEventRepository;
    
    public LoginMonitorService(ILoginMonitorEventRepository loginMonitorEventRepository)
    {
        _loginMonitorEventRepository = loginMonitorEventRepository;
    }
    
    public async Task<IEnumerable<LoginMonitorEvent?>> GetLoginMonitorEventsAsync()
    {
        return await _loginMonitorEventRepository.GetLoginMonitorEventsAsync();
    }

    public async Task<LoginMonitorEvent?> GetLoginMonitorEventAsync(int id)
    {
        return await _loginMonitorEventRepository.GetLoginMonitorEventAsync(id);
    }

    public async Task AddLoginMonitorEventAsync(LoginMonitorEvent? loginMonitorEvent)
    {
        await _loginMonitorEventRepository.AddLoginMonitorEventAsync(loginMonitorEvent);
    }

    public async Task UpdateLoginMonitorEventAsync(LoginMonitorEvent? loginMonitorEvent)
    {
        await _loginMonitorEventRepository.UpdateLoginMonitorEventAsync(loginMonitorEvent);
    }

    public async Task DeleteLoginMonitorEventAsync(int id)
    {
        await _loginMonitorEventRepository.DeleteLoginMonitorEventAsync(id);
    }
}