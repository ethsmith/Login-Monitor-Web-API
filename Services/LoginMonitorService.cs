using System.Text.Json;
using Aspose.Cells;
using Aspose.Cells.Utility;
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
    
    public async Task<byte[]> GetLoginMonitorEventsReportAsync()
    {
        var loginMonitorEvents = await _loginMonitorEventRepository.GetLoginMonitorEventsAsync();
        var workbook = new Workbook();
        var worksheet = workbook.Worksheets[0];

        var layoutOptions = new JsonLayoutOptions();
        layoutOptions.ArrayAsTable = true;
        
        JsonUtility.ImportData(JsonSerializer.Serialize(loginMonitorEvents), worksheet.Cells, 0, 0, layoutOptions);

        using (MemoryStream stream = new MemoryStream())
        {
            workbook.Save(stream, SaveFormat.Csv);
            return stream.ToArray();
        }
    }
    
    public async Task<IEnumerable<LoginMonitorEvent?>> GetLoginMonitorEventsAsync()
    {
        return await _loginMonitorEventRepository.GetLoginMonitorEventsAsync();
    }
    
    public async Task<IEnumerable<LoginMonitorEvent?>> GetLoginMonitorEventsForUserAsync(int userId)
    {
        return await _loginMonitorEventRepository.GetLoginMonitorEventsForUserAsync(userId);
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