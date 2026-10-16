var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<CatalogService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
}

app.UseHttpsRedirection();

app.MapGet("/catalog", (CatalogService catalogService) =>
{
    var items = catalogService.GetAll();
    return items;
})
.WithName("GetCatalog");

app.Run();

class CatalogService
{
    public IEnumerable<Robot> GetAll()
    {
        return [
            new("FB-01", "Asistente doméstico", "Hogar", 11_999m),
            new("FB-02", "Asistente de hospitalidad", "Servicio", 12_999m),
            new("FB-03", "Asistente híbrido", "Hogar y servicio", 10_999m)
        ];
    }
}

record Robot(string Code, string Name, string Segment, decimal Price);