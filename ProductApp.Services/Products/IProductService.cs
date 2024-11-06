using ProductApp.DataAccess.Products;

namespace ProductApp.Services.Products;

public interface IProductService
{
    void DeleteId(int id);
    Task<ServiceResult<ProductDto>> GetProductByIdAsync(int id);
}
