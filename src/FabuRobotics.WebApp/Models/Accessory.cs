namespace FabuRobotics.WebApp.Models;

public record Accessory(
    string Sku,
    string Name,
    string Category,
    string Subcategory,
    string Type,
    IReadOnlyList<string> Compatibility,
    decimal PriceUsd,
    string BillingPeriod,
    string Description,
    string Status,
    IReadOnlyList<string> Tags);
