using ProductApp.DataAccess.Users;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace ProductAppUI.Pages.User
{
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

        [BindProperty]
        public string NewUsername { get; set; }

        [BindProperty]
        public string NewPassword { get; set; }

        [BindProperty]
        public string NewRole { get; set; }

        [BindProperty]
        public int UpdateUserId { get; set; }

        [BindProperty]
        public string UpdateUsername { get; set; }

        [BindProperty]
        public string UpdateRole { get; set; }

        public async Task OnGetAsync()
        {
            if (!_cache.TryGetValue("token", out string token))
            {
                ErrorMessage = "Authorization token not found. Please log in.";
                return;
            }
            Token = token;

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                var response = await client.GetAsync("https://localhost:7284/api/User/Admin");

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

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!_cache.TryGetValue("token", out string token))
            {
                ErrorMessage = "Authorization token not found. Please log in.";
                return Page();
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var createUserRequest = new { Username = NewUsername, Password = NewPassword, Role = NewRole };
            var response = await client.PostAsJsonAsync("https://localhost:7284/api/User", createUserRequest);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage(); // Yeni kullanýcý eklendiðinde sayfayý yenileyerek güncellenmiþ listeyi göster
            }

            ErrorMessage = "Error: Unable to create user.";
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            if (!_cache.TryGetValue("token", out string token))
            {
                ErrorMessage = "Authorization token not found. Please log in.";
                return Page();
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.DeleteAsync($"https://localhost:7284/api/User/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage();
            }
            ErrorMessage = "Error: Unable to delete user.";
            return Page();
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (!_cache.TryGetValue("token", out string token))
            {
                ErrorMessage = "Authorization token not found. Please log in.";
                return Page();
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var updateUserRequest = new { Username = UpdateUsername, Role = UpdateRole };
            var content = new StringContent(JsonSerializer.Serialize(updateUserRequest), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7284/api/User/{UpdateUserId}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage();
            }

            ErrorMessage = "Error: Unable to update user.";
            return Page();
        }
    }
}
