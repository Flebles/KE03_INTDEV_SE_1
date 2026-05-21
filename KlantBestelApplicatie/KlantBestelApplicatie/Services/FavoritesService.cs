using KlantBestelApplicatie.Models;

namespace KlantBestelApplicatie.Services;

public class FavoritesService
{
    private readonly HashSet<int> _favoriteIds = new();

    private readonly ProductCatalogService _catalog;

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

    public bool IsFavorite(int productId)
    {
        return _favoriteIds.Contains(productId);
    }

    public void Toggle(int productId)
    {
        if (!_favoriteIds.Add(productId))
        {
            _favoriteIds.Remove(productId);
        }
    }
}