using FabuRobotics.WebApp.Models;

namespace FabuRobotics.WebApp.Services;

public class ApiService(HttpClient httpClient)
{
    public async Task<IReadOnlyList<Accessory>> GetAccesories(CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<List<Accessory>>("/accessories", cancellationToken) ?? [];
    }
}