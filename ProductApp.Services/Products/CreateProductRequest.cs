

namespace ProductApp.Services.Products
{
    public record CreateProductRequest(string Code, string ProductName, decimal Price, string ImageUrl);

}
