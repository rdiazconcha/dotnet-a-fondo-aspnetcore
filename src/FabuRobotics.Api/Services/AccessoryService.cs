using FabuRobotics.Api.Models;
using System.Text.Json;

namespace FabuRobotics.Api.Services;

public class AccessoryService
{
    private static readonly string DefaultDataFilePath =
        Path.Combine(AppContext.BaseDirectory, "Data", "catalog.json");

    private readonly IReadOnlyList<Accessory> all;
    private readonly IReadOnlyDictionary<string, Accessory> bySku;

    public AccessoryService()
    {
        using var stream = File.OpenRead(DefaultDataFilePath);
        var entries = JsonSerializer.Deserialize<List<CatalogItem>>(stream) ?? [];

        all = entries.Select(ToAccessory).ToList();
        bySku = all.ToDictionary(a => a.Sku, StringComparer.OrdinalIgnoreCase);
    }

    public IEnumerable<Accessory> GetAll()
    {
        return all;
    }

    public Accessory? GetBySku(string sku)
    {
        return bySku.GetValueOrDefault(sku);
    }

    private static Accessory ToAccessory(CatalogItem entry)
    {
        return new(
        Sku: entry.Sku,
        Name: entry.NameEs,
        Category: entry.Category,
        Subcategory: entry.Subcategory,
        Type: entry.Type,
        Compatibility: entry.Compatibility,
        CompatibilityNotes: entry.CompatibilityNotesEs,
        PriceUsd: entry.PriceUsd,
        BillingPeriod: entry.BillingPeriod,
        Description: entry.DescriptionEs,
        Specifications: entry.Specifications
            .Select(s => new AccessorySpecification(s.NameEs, s.ValueEs))
            .ToList(),
        Installation: entry.Installation,
        WarrantyMonths: entry.WarrantyMonths,
        Status: entry.Status,
        ReplacementSku: entry.ReplacementSku,
        Regions: entry.Regions,
        Tags: entry.Tags,
        ReleaseYear: entry.ReleaseYear);
    }
}