using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FabuRobotics.WebApp.Pages;

public class IndexModel : PageModel
{
    public IndexModel(IConfiguration configuration)
    {
        var connString = configuration.GetValue<string>("FabuRobotics:AppInsights");
        var computerName = configuration.GetValue<string>("COMPUTERNAME");
    }
    public void OnGet()
    {

    }
}
