namespace ProductApp.Services.Products;

public record UpdateProductRequest(int Id, string Code, string ProductName, decimal Price, string ImageUrl, DateTime? UpdatedDate);

