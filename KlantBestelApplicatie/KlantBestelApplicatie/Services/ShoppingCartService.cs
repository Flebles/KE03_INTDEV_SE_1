using KlantBestelApplicatie.Models;

namespace KlantBestelApplicatie.Services;

public class ShoppingCartService
{
    private readonly ProductCatalogService _catalog;
    private readonly List<CartItem> _items = new();

    public ShoppingCartService(ProductCatalogService catalog)
    {
        _catalog = catalog;
    }

    public IReadOnlyList<CartItem> GetItems()
    {
        return _items
            .Select(item => new CartItem
            {
                Product = item.Product,
                Quantity = item.Quantity
            })
            .ToList();
    }

    public int TotalQuantity => _items.Sum(item => item.Quantity);

    public decimal TotalPrice => _items.Sum(item => item.LineTotal);

    public void Add(int productId, int quantity)
    {
        if (quantity < 1)
        {
            quantity = 1;
        }

        var product = _catalog.GetById(productId);
        if (product is null)
        {
            return;
        }

        var existingItem = _items.FirstOrDefault(item => item.Product.Id == productId);

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

    // option to edit the amount of products or to remove it by making it <= 0
    public void UpdateQuantity(int productId, int quantity)
    {
        var existingItem = _items.FirstOrDefault(item => item.Product.Id == productId);
        if (existingItem is null)
        {
            return;
        }

        if (quantity <= 0)
        {
            _items.Remove(existingItem);
            return;
        }

        existingItem.Quantity = quantity;
    }

    public void Remove(int productId)
    {
        _items.RemoveAll(item => item.Product.Id == productId);
    }

    public void Clear()
    {
        _items.Clear();
    }
}