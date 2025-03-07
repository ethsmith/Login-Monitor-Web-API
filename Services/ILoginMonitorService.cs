﻿using LoginMonitorAPI.Models;

namespace LoginMonitorAPI.Services;

public interface ILoginMonitorService
{
    Task<IEnumerable<LoginMonitorEvent?>> GetLoginMonitorEventsAsync();
    Task<LoginMonitorEvent?> GetLoginMonitorEventAsync(int id);
    Task AddLoginMonitorEventAsync(LoginMonitorEvent? loginMonitorEvent);
    Task UpdateLoginMonitorEventAsync(LoginMonitorEvent? loginMonitorEvent);
    Task DeleteLoginMonitorEventAsync(int id);
}