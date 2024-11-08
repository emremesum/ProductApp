using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using ProductApp.Services.Auth;
using System.Text;
using System.Text.Json;

namespace ProductAppUI.Pages;
public class LoginModel : PageModel
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IMemoryCache _cache;

    public LoginModel(IHttpClientFactory clientFactory, IMemoryCache cache)
    {
        _clientFactory = clientFactory;
        _cache = cache;
    }

    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public string ErrorMessage { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        var client = _clientFactory.CreateClient();
        var loginRequest = new { Username = Username, Password = Password };

        var jsonContent = new StringContent(JsonSerializer.Serialize(loginRequest), Encoding.UTF8, "application/json");

        // API'ye POST isteði gönder
        var response = await client.PostAsync("https://localhost:7284/api/auth/login", jsonContent);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<LoginResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                                                    
            // Cache'e userId ve token kaydet
            _cache.Set("userId", result.Id);
            _cache.Set("token", result.Token);

            return RedirectToPage("Main"); // Login baþarýlýysa ana sayfaya yönlendirme
        }
        else
        {
            ErrorMessage = "Kullanýcý adý veya þifre hatalý";
            return Page();
        }
    }
}

