using KlantBestelApplicatie.Models;

namespace KlantBestelApplicatie.Services;

public class ProductCatalogService
{
    private readonly List<Product> _products =
    [
        new Product
        {
            Id = 1,
            Name = "Nova X koptelefoon",
            Price = 89.95m,
            Brand = "SoundWave",
            Color = "Zwart",
            Weight = "0,25 kg",
            WarrantyDuration = "24 maanden",
            Description = "Draadloze koptelefoon met helder geluid en lange batterijduur.",
            ImageUrls = new List<string>
            {
                "/images/products/headphones-1.jpg",
                "/images/products/headphones-2.jpg"
            }
        },

        new Product
        {
            Id = 2,
            Name = "Pulse rugzak",
            Price = 59.50m,
            Brand = "UrbanPack",
            Color = "Grijs",
            Weight = "0,80 kg",
            WarrantyDuration = "12 maanden",
            Description = "Moderne rugzak voor dagelijks gebruik.",
            ImageUrls = new List<string>()
            {
                "/images/products/pulse_backpack.jpg"
            }
        },

        new Product
        {
            Id = 3,
            Name = "Pro muis",
            Price = 34.99m,
            Brand = "ClickForge",
            Color = "Wit",
            Weight = "0,12 kg",
            WarrantyDuration = "24 maanden",
            Description = "Ergonomische draadloze computermuis."
        }
    ];

    public IReadOnlyList<Product> GetAllProducts()
    {
        return _products;
    }

    public Product? GetById(int id)
    {
        return _products.FirstOrDefault(product => product.Id == id);
    }

    public IReadOnlyList<Product> Search(string? search)
    {
        if (string.IsNullOrWhiteSpace(search))
        {
            return _products;
        }

        return _products
            .Where(product =>
                product.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                product.Brand.Contains(search, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}