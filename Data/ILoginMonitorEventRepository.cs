using LoginMonitorAPI.Models;

namespace LoginMonitorAPI.Data;

public interface ILoginMonitorEventRepository
{
    Task<IEnumerable<LoginMonitorEvent?>> GetLoginMonitorEventsAsync();
    Task<IEnumerable<LoginMonitorEvent?>> GetLoginMonitorEventsForUserAsync(int userId);
    Task<LoginMonitorEvent?> GetLoginMonitorEventAsync(int id);
    Task AddLoginMonitorEventAsync(LoginMonitorEvent? loginMonitorEvent);
    Task UpdateLoginMonitorEventAsync(LoginMonitorEvent? loginMonitorEvent);
    Task DeleteLoginMonitorEventAsync(int id);
}