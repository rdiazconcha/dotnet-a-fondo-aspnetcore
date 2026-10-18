namespace FabuRobotics.Api.Models;

public record Accessory(
    string Sku,
    string Name,
    string Category,
    string Subcategory,
    string Type,
    IReadOnlyList<string> Compatibility,
    string? CompatibilityNotes,
    decimal PriceUsd,
    string BillingPeriod,
    string Description,
    IReadOnlyList<AccessorySpecification> Specifications,
    string Installation,
    int WarrantyMonths,
    string Status,
    string? ReplacementSku,
    IReadOnlyList<string> Regions,
    IReadOnlyList<string> Tags,
    int ReleaseYear);

public record AccessorySpecification(string Name, string Value);
