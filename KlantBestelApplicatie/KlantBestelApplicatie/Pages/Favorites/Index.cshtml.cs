using KlantBestelApplicatie.Models;
using KlantBestelApplicatie.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KlantBestelApplicatie.Pages.Favorites;

public class IndexModel : PageModel
{
    private readonly FavoritesService _favorites;
    private readonly ShoppingCartService _cart;

    public IndexModel(FavoritesService favorites, ShoppingCartService cart)
    {
        _favorites = favorites;
        _cart = cart;
    }

    public IReadOnlyList<Product> FavoriteProducts { get; private set; } = Array.Empty<Product>();

    // load favorited products
    public void OnGet()
    {
        FavoriteProducts = _favorites.GetFavorites();
    }

    // add item to cart directly from favs page
    public IActionResult OnPostAddToCart(int id)
    {
        _cart.Add(id, 1);
        return RedirectToPage();
    }

    // remove item from favorites
    public IActionResult OnPostRemove(int id)
    {
        _favorites.Remove(id);
        return RedirectToPage();
    }
}