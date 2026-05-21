namespace KlantBestelApplicatie.Models;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Brand { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;

    public string Weight { get; set; } = string.Empty;

    public string WarrantyDuration { get; set; } = string.Empty;

    public List<string> ImageUrls { get; set; } = new();

    public string PrimaryImage =>
        ImageUrls.FirstOrDefault() ?? "/images/placeholder.svg";
}