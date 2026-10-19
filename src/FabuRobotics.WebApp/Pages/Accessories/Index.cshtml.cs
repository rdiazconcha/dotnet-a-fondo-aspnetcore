using FabuRobotics.WebApp.Models;
using FabuRobotics.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FabuRobotics.WebApp.Pages.Accessories;

public class IndexModel(ApiService apiService) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Category { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Robot { get; set; }

    public IReadOnlyList<Accessory> Accessories { get; private set; } = [];
    public IReadOnlyList<string> Categories { get; private set; } = [];
    public int TotalCount { get; private set; }

    public string? ErrorMessage { get; private set; }

    public async Task OnGetAsync()
    {
        IReadOnlyList<Accessory> allAccessories;

        try
        {
            allAccessories = await apiService.GetAccesories();
        }
        catch (HttpRequestException)
        {
            ErrorMessage = "No fue posible obtener el catálogo de accesorios. Intenta de nuevo más tarde.";
            return;
        }

        TotalCount = allAccessories.Count;
        Categories = allAccessories.Select(a => a.Category).Distinct().Order().ToList();

        IEnumerable<Accessory> query = allAccessories;

        if (!string.IsNullOrWhiteSpace(Search))
        {
            query = query.Where(a =>
                a.Name.Contains(Search, StringComparison.OrdinalIgnoreCase) ||
                a.Sku.Contains(Search, StringComparison.OrdinalIgnoreCase) ||
                a.Description.Contains(Search, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(Category))
        {
            query = query.Where(a => a.Category == Category);
        }

        if (!string.IsNullOrWhiteSpace(Robot))
        {
            query = query.Where(a => a.Compatibility.Contains(Robot));
        }

        Accessories = query.ToList();

    }
}