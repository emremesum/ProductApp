namespace ProductApp.DataAccess.Products;

public interface IProductRepository : IGenericRepository<Product>
{
    // producta ait method

    public Task<List<Product>> GetTopProductsAsync(int count);
}
