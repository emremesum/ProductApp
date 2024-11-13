using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ProductApp.DataAccess.Users;
using ProductApp.Services.Products;
using ProductApp.Services.SupportForm;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Net;
using Microsoft.AspNetCore.WebUtilities;

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
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public List<ContactFormDto> ContactForms { get; set; } = new List<ContactFormDto>();

        public string ErrorMessage { get; set; }
        public string Token { get; set; }

        // User için alanlar
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

        // Product için alanlar
        [BindProperty]
        public int ProductId { get; set; }

        // Product için alanlar
        [BindProperty]
        public string ProductCode { get; set; }

        [BindProperty]
        public string ProductName { get; set; }

        [BindProperty]
        public decimal ProductPrice { get; set; }

        [BindProperty]
        public string ProductImageUrl { get; set; }


        // Contact Form için alanlar
        [BindProperty]
        public int ContactFormId { get; set; }

        [BindProperty]
        public string ContactFormSubject { get; set; }

        [BindProperty]
        public string ContactFormMessage { get; set; }

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
                // User listesi
                var userResponse = await client.GetAsync("https://localhost:7284/api/User/Admin");
                if (userResponse.IsSuccessStatusCode)
                {
                    Users = await userResponse.Content.ReadFromJsonAsync<List<UserApp>>();
                }

                // Product listesi
                var productResponse = await client.GetAsync("https://localhost:7284/api/Products");
                if (productResponse.IsSuccessStatusCode)
                {
                    Products = await productResponse.Content.ReadFromJsonAsync<List<ProductDto>>();
                }

                // Contact Form listesi
                var contactFormResponse = await client.GetAsync("https://localhost:7284/api/ContactForm");
                if (contactFormResponse.IsSuccessStatusCode)
                {
                    ContactForms = await contactFormResponse.Content.ReadFromJsonAsync<List<ContactFormDto>>();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Exception: {ex.Message}";
            }
        }

        // User ekleme, güncelleme ve silme iþlemleri
        public async Task<IActionResult> OnPostCreateUserAsync()
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
                return RedirectToPage();
            }

            ErrorMessage = "Error: Unable to create user.";
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteUserAsync(int id)
        {

            
            var response = await SendAuthorizedDeleteRequestAsync($"https://localhost:7284/api/User/{id}");

            if (response.IsSuccessStatusCode)
            {
                // Optionally, reload users or handle success (e.g., showing success message)
                return RedirectToPage(); // Redirect to refresh the page
            }
            else
            {
                // Handle error (optional)
                ModelState.AddModelError(string.Empty, "Kullanýcý silinemedi. Lütfen tekrar deneyin.");
                return Page();
            }


        }

        public async Task<IActionResult> OnPostUpdateUserAsync()
        {
            var updateUserRequest = new { Username = UpdateUsername, Role = UpdateRole };
            var response = await SendAuthorizedPutRequestAsync($"https://localhost:7284/api/User/{UpdateUserId}", updateUserRequest);
            return HandleResponse(response);
        }

        // Product ekleme, güncelleme ve silme iþlemleri
        public async Task<IActionResult> OnPostCreateProductAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Lütfen tüm alanlarý doðru doldurun.";
                return Page();
            }

            if (!_cache.TryGetValue("token", out string token))
            {
                ErrorMessage = "Authorization token not found. Please log in.";
                return Page();
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var createProductRequest = new CreateProductRequest(ProductCode, ProductName, ProductPrice, ProductImageUrl);
            var response = await client.PostAsJsonAsync("https://localhost:7284/api/Products", createProductRequest);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage(); // Sayfayý yenileyerek tabloyu günceller
            }

            ErrorMessage = "Error: Unable to create product.";
            return Page();
        }


        public async Task<IActionResult> OnPostDeleteProductAsync(int id)
        {
            var response = await SendAuthorizedDeleteRequestAsync($"https://localhost:7284/api/Products/{id}");
            return HandleResponse(response);
        }

        public async Task<IActionResult> OnPostUpdateProductAsync()
        {
            if (!_cache.TryGetValue("token", out string token))
            {
                ErrorMessage = "Authorization token not found. Please log in.";
                return Page();
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var updateProductRequest = new { ProductName = ProductName, Price = ProductPrice };
            var response = await SendAuthorizedPutRequestAsync($"https://localhost:7284/api/Products/{ProductId}", updateProductRequest);
            return HandleResponse(response);
        }

        // Contact Form ekleme, güncelleme ve silme iþlemleri
        public async Task<IActionResult> OnPostCreateContactFormAsync()
        {
            if (!_cache.TryGetValue("token", out string token))
            {
                ErrorMessage = "Authorization token not found. Please log in.";
                return Page();
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            var createContactFormRequest = new { Subject = ContactFormSubject, Message = ContactFormMessage };
            var response = await SendAuthorizedPostRequestAsync("https://localhost:7284/api/ContactForm", createContactFormRequest);
            return HandleResponse(response);
        }

        public async Task<IActionResult> OnPostDeleteContactFormAsync(int id)
        {
            var response = await SendAuthorizedDeleteRequestAsync($"https://localhost:7284/api/ContactForm/{id}");
            return HandleResponse(response);
        }

        public async Task<IActionResult> OnPostUpdateContactFormAsync()
        {
            if (!_cache.TryGetValue("token", out string token))
            {
                ErrorMessage = "Authorization token not found. Please log in.";
                return Page();
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var updateContactFormRequest = new { Subject = ContactFormSubject, Message = ContactFormMessage };
            var response = await SendAuthorizedPutRequestAsync($"https://localhost:7284/api/ContactForm/{ContactFormId}", updateContactFormRequest);
            return HandleResponse(response);
        }

        // Yardýmcý Metodlar
        private async Task<HttpResponseMessage> SendAuthorizedPostRequestAsync(string url, object data)
        {
            if (!_cache.TryGetValue("token", out string token))
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    ReasonPhrase = "Yetkisiz Eriþim"
                };
                return response;

            }
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await client.PostAsJsonAsync(url, data);
        }

        private async Task<HttpResponseMessage> SendAuthorizedPutRequestAsync(string url, object data)
        {
            if (!_cache.TryGetValue("token", out string token))
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    ReasonPhrase = "Yetkisiz Eriþim"
                };
                return response;

            }
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            return await client.PutAsync(url, content);
        }

        private async Task<HttpResponseMessage> SendAuthorizedDeleteRequestAsync(string url)
        {

            if (!_cache.TryGetValue("token", out string token))
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    ReasonPhrase = "Yetkisiz Eriþim"
                };
                return response;

            }
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await client.DeleteAsync(url);
        }

        private IActionResult HandleResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return RedirectToPage();
            ErrorMessage = "Error: Unable to process request.";
            return Page();
        }
    }
}
