using System.Text.Json.Serialization;

namespace FabuRobotics.Api.Models;

public record CatalogItem(
       [property: JsonPropertyName("sku")] string Sku,
       [property: JsonPropertyName("nombre_es")] string NameEs,
       [property: JsonPropertyName("nombre_en")] string NameEn,
       [property: JsonPropertyName("categoria")] string Category,
       [property: JsonPropertyName("subcategoria")] string Subcategory,
       [property: JsonPropertyName("tipo")] string Type,
       [property: JsonPropertyName("compatibilidad")] List<string> Compatibility,
       [property: JsonPropertyName("notas_compatibilidad_es")] string? CompatibilityNotesEs,
       [property: JsonPropertyName("notas_compatibilidad_en")] string? CompatibilityNotesEn,
       [property: JsonPropertyName("precio_usd")] decimal PriceUsd,
       [property: JsonPropertyName("periodicidad")] string BillingPeriod,
       [property: JsonPropertyName("descripcion_es")] string DescriptionEs,
       [property: JsonPropertyName("descripcion_en")] string DescriptionEn,
       [property: JsonPropertyName("especificaciones")] List<CatalogItemSpecification> Specifications,
       [property: JsonPropertyName("instalacion")] string Installation,
       [property: JsonPropertyName("garantia_meses")] int WarrantyMonths,
       [property: JsonPropertyName("estado")] string Status,
       [property: JsonPropertyName("reemplazo_sku")] string? ReplacementSku,
       [property: JsonPropertyName("regiones")] List<string> Regions,
       [property: JsonPropertyName("etiquetas")] List<string> Tags,
       [property: JsonPropertyName("anio_lanzamiento")] int ReleaseYear);

public record CatalogItemSpecification(
    [property: JsonPropertyName("es")] string NameEs,
    [property: JsonPropertyName("en")] string NameEn,
    [property: JsonPropertyName("valor_es")] string ValueEs,
    [property: JsonPropertyName("valor_en")] string ValueEn);