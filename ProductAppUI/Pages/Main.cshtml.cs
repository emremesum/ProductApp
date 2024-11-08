using ProductApp.DataAccess.Users;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using Microsoft.Extensions.Caching.Memory;

namespace ProductAppUI.MainModel;

public class UsersModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMemoryCache _cache;

    public UsersModel(IHttpClientFactory httpClientFactory, IMemoryCache cache)
    {
        _httpClientFactory = httpClientFactory;
        _cache = cache;
    }
    

    public List<UserApp> Users { get; set; } = new List<UserApp>();

    public string ErrorMessage { get; set; }
    public string Token { get; set; }

    public async Task OnGetAsync()
    {
        if (!_cache.TryGetValue("token", out string token))
        {
            ErrorMessage = "Authorization token not found. Please log in.";
            return;
        }
        var role = "Admin";
        Token = token;

        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        try
        {
            // Make a GET request to the GetAll endpoint with the role parameter
            var response = await client.GetAsync($"https://localhost:7284/api/User/{role}");

            if (response.IsSuccessStatusCode)
            {
                Users = await response.Content.ReadFromJsonAsync<List<UserApp>>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ErrorMessage = "No users found for the specified role.";
            }
            else
            {
                ErrorMessage = "Error: Unable to retrieve data.";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Exception: {ex.Message}";
        }
    }
}

