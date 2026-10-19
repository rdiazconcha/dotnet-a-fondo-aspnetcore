using FabuRobotics.WebApp.Models;
using FabuRobotics.WebApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FabuRobotics.WebApp.Pages.Accessories;

public class IndexModel(ApiService apiService) : PageModel
{
	public IReadOnlyList<Accessory> Accessories { get; private set; } = [];
    public string? ErrorMessage { get; private set; }

    public async Task OnGetAsync()
    {
		try
		{
			Accessories = await apiService.GetAccesories();
		}
		catch (Exception)
		{
			ErrorMessage = "Hubo un error al traer la información del API";
		}
    }
}