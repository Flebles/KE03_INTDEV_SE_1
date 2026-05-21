using KlantBestelApplicatie.Models;
using KlantBestelApplicatie.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KlantBestelApplicatie.Pages.Favorites;

public class IndexModel : PageModel
{
    private readonly FavoritesService _favorites;

    public IndexModel(FavoritesService favorites)
    {
        _favorites = favorites;
    }

    public IReadOnlyList<Product> Products =>
        _favorites.GetFavorites();

    public void OnGet()
    {
    }
}