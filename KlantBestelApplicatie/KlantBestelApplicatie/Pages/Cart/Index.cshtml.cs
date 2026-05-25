using KlantBestelApplicatie.Models;
using KlantBestelApplicatie.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KlantBestelApplicatie.Pages.Cart;

public class IndexModel : PageModel
{
    private readonly ShoppingCartService _cart;

    public IndexModel(ShoppingCartService cart)
    {
        _cart = cart;
    }

    public IReadOnlyList<CartItem> Items { get; private set; } = Array.Empty<CartItem>();

    public decimal Subtotal { get; private set; }

    public decimal Shipping { get; private set; }

    public decimal Total => Subtotal + Shipping;

    public void OnGet()
    {
        LoadCartState();
    }

    // updating the amount of a product in the cart
    public IActionResult OnPostUpdateQuantity(int id, int quantity)
    {
        _cart.UpdateQuantity(id, quantity);
        return RedirectToPage();
    }

    // removing a product from the cart
    public IActionResult OnPostRemove(int id)
    {
        _cart.Remove(id);
        return RedirectToPage();
    }

    private void LoadCartState()
    {
        Items = _cart.GetItems();
        Subtotal = _cart.TotalPrice;
        Shipping = Items.Any() ? 15m : 0m;
    }
}