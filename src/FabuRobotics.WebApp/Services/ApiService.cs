using FabuRobotics.WebApp.Models;

namespace FabuRobotics.WebApp.Services;

public class ApiService(HttpClient httpClient, ILogger<ApiService> logger)
{
    public async Task<IReadOnlyList<Accessory>> GetAccesories(CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Invocando API");
        return await httpClient.GetFromJsonAsync<List<Accessory>>("/accessories", cancellationToken) ?? [];
    }
}