using Microsoft.AspNetCore.Http;
using ProductApp.DataAccess.Products;

namespace ProductApp.Services.Products;

public interface IProductService
{
    Task<ServiceResult<List<ProductDto>>> GetAllListAsync();
    Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request, IFormFile image);
    Task<ServiceResult<CreateProductResponse>> CreateWithoutImageAsync(CreateProductRequest request);
    Task<ServiceResult> UpdateAsync(int id,UpdateProductRequest request);
    Task<ServiceResult> DeleteAsync(int id);
    Task<ServiceResult<ProductDto?>> GetByIdAsync(int id); // 2. api tekli cagırımda bu kullanılabilir 
}
