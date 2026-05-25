using KlantBestelApplicatie.Models;
using KlantBestelApplicatie.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KlantBestelApplicatie.Pages.Checkout;

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

    public bool OrderReceived { get; private set; }

    [BindProperty]
    public string PaymentMethod { get; set; } = "iDEAL";

    [BindProperty]
    public string Street { get; set; } = string.Empty;

    [BindProperty]
    public string HouseNumber { get; set; } = string.Empty;

    [BindProperty]
    public string Postcode { get; set; } = string.Empty;

    [BindProperty]
    public string City { get; set; } = string.Empty;

    [BindProperty]
    public string FirstName { get; set; } = string.Empty;

    [BindProperty]
    public string LastName { get; set; } = string.Empty;

    public void OnGet()
    {
        LoadSummary();
    }

    public IActionResult OnPost()
    {
        LoadSummary();

        if (!Items.Any())
        {
            return RedirectToPage("/Cart/Index");
        }

        OrderReceived = true;
        _cart.Clear();

        return Page();
    }

    private void LoadSummary()
    {
        Items = _cart.GetItems();
        Subtotal = _cart.TotalPrice;
        Shipping = Items.Any() ? 15m : 0m;
    }
}