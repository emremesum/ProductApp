using Microsoft.AspNetCore.Mvc;
using ProductApp.DataAccess.Products;
using ProductApp.Services.Products;
using ProductApp.UI.Helpers;
using ProductApp.UI.Models;
using System;
using System.Diagnostics;

namespace ProductApp.UI.Controllers
{
	public class HomeController : Controller
	{
		private readonly HttpClient _client= HttpClientInstance.CreateClient();


		public async Task<IActionResult> Index()
		{
			var response = await _client.GetFromJsonAsync<List<Product>>("products"); // "products" web apý'deki endpoint yolu
			return View(response);

        }
		[HttpGet]

		public IActionResult Create()
		{
			return View();
		}

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
		public async Task<IActionResult> Create(CreateProductRequest createProduct)
		{
			 await _client.PostAsJsonAsync("products/create", createProduct);

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateProductRequest request)
		{
			await _client.PostAsJsonAsync("products/update", request);

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult UpdateForm(UpdateProductRequest request)
		{
			return View(request);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
