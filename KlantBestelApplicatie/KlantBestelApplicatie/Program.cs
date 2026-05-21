using System.Globalization;
using KlantBestelApplicatie.Services;

namespace KlantBestelApplicatie;

public class Program
{
    public static void Main(string[] args)
    {
        var culture = CultureInfo.GetCultureInfo("nl-NL");

        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        builder.Services.AddSingleton<ProductCatalogService>();
        builder.Services.AddSingleton<ShoppingCartService>();
        builder.Services.AddSingleton<FavoritesService>();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}