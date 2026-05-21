using KlantBestelApplicatie.Models;
using KlantBestelApplicatie.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KlantBestelApplicatie.Pages.Products;

public class DetailsModel : PageModel
{
    private readonly ProductCatalogService _catalog;

    private readonly ShoppingCartService _cart;

    public DetailsModel(
        ProductCatalogService catalog,
        ShoppingCartService cart)
    {
        _catalog = catalog;
        _cart = cart;
    }

    public Product? Product { get; private set; }

    [BindProperty]
    public int Quantity { get; set; } = 1;

    public IActionResult OnGet(int id)
    {
        Product = _catalog.GetById(id);

        if (Product is null)
        {
            return NotFound();
        }

        return Page();
    }

    public IActionResult OnPostAddToCart(int id)
    {
        _cart.Add(id, Quantity);

        return RedirectToPage("/Cart/Index");
    }
}