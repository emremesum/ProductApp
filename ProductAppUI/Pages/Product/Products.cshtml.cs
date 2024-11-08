using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using ProductApp.Services.Products;
using System.Net.Http.Headers;
namespace ProductAppUI.Pages.Product;

public class ProductsModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMemoryCache _cache;
    public string ErrorMessage { get; set; }

    public ProductsModel(IHttpClientFactory httpClientFactory, IMemoryCache cache)
    {
        _httpClientFactory = httpClientFactory;
        _cache = cache;
    }

    public List<ProductDto> Products { get; set; }

    public async Task OnGetAsync()
    {
        if (!_cache.TryGetValue("token", out string token))
        {
            ErrorMessage = "Authorization token not found. Please log in.";
            return;
        }
        var role = "Admin";

        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        try
        {
            // Make a GET request to the GetAll endpoint with the role parameter
            var response = await client.GetAsync("https://localhost:7284/api/Products");

            if (response.IsSuccessStatusCode)
            {
                Products = await response.Content.ReadFromJsonAsync<List<ProductDto>>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ErrorMessage = "Stokta ürün yok ";
            }
            else
            {
                ErrorMessage = "Data alýnamadý.";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Exception: {ex.Message}";
        }
    }
}