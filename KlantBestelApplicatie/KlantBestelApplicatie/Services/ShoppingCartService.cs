using KlantBestelApplicatie.Models;

namespace KlantBestelApplicatie.Services;

public class ShoppingCartService
{
    private readonly List<CartItem> _items = new();

    private readonly ProductCatalogService _catalog;

    public ShoppingCartService(ProductCatalogService catalog)
    {
        _catalog = catalog;
    }

    public IReadOnlyList<CartItem> GetItems()
    {
        return _items;
    }

    public decimal TotalPrice =>
        _items.Sum(item => item.LineTotal);

    public int TotalQuantity =>
        _items.Sum(item => item.Quantity);

    public void Add(int productId, int quantity)
    {
        var product = _catalog.GetById(productId);

        if (product is null)
        {
            return;
        }

        var existingItem =
            _items.FirstOrDefault(item => item.Product.Id == productId);

        if (existingItem is null)
        {
            _items.Add(new CartItem
            {
                Product = product,
                Quantity = quantity
            });

            return;
        }

        existingItem.Quantity += quantity;
    }

    public void Remove(int productId)
    {
        _items.RemoveAll(item => item.Product.Id == productId);
    }
}