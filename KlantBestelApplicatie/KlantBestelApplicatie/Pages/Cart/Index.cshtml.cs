using KlantBestelApplicatie.Models;
using KlantBestelApplicatie.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KlantBestelApplicatie.Pages.Cart;

public class IndexModel : PageModel
{
    private readonly ShoppingCartService _cart;

    public IndexModel(ShoppingCartService cart)
    {
        _cart = cart;
    }

    public IReadOnlyList<CartItem> Items =>
        _cart.GetItems();

    public decimal Total =>
        _cart.TotalPrice;

    public void OnGet()
    {
    }
}