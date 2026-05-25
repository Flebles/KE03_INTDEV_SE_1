using KlantBestelApplicatie.Models;

namespace KlantBestelApplicatie.Services;

public class FavoritesService
{
    private readonly ProductCatalogService _catalog;
    private readonly HashSet<int> _favoriteIds = new();

    public FavoritesService(ProductCatalogService catalog)
    {
        _catalog = catalog;
    }

    public int Count => _favoriteIds.Count;

    public IReadOnlyList<Product> GetFavorites()
    {
        return _favoriteIds
            .Select(id => _catalog.GetById(id))
            .Where(product => product is not null)
            .Cast<Product>()
            .ToList();
    }

    // check if an item is favorited
    public bool IsFavorite(int productId)
    {
        return _favoriteIds.Contains(productId);
    }

    // toggle favorites
    public void Toggle(int productId)
    {
        if (!_favoriteIds.Add(productId))
        {
            _favoriteIds.Remove(productId);
        }
    }

    // remove something from your favorites
    public void Remove(int productId)
    {
        _favoriteIds.Remove(productId);
    }
}