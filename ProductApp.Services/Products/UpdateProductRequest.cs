namespace ProductApp.Services.Products;

public record UpdateProductRequest(string Code, string ProductName, decimal Price, string ImageUrl, DateTime? UpdatedDate);

