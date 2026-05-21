using KlantBestelApplicatie.Models;
using KlantBestelApplicatie.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KlantBestelApplicatie.Pages;

public class IndexModel : PageModel
{
    private readonly ProductCatalogService _catalog;

    private readonly FavoritesService _favorites;

    public IndexModel(
        ProductCatalogService catalog,
        FavoritesService favorites)
    {
        _catalog = catalog;
        _favorites = favorites;
    }

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    public IReadOnlyList<Product> Products { get; private set; }
        = Array.Empty<Product>();

    public void OnGet()
    {
        Products = _catalog.Search(Search);
    }

    public IActionResult OnPostToggleFavorite(int id)
    {
        _favorites.Toggle(id);

        return RedirectToPage(new
        {
            search = Search
        });
    }

    public bool IsFavorite(int productId)
    {
        return _favorites.IsFavorite(productId);
    }
}