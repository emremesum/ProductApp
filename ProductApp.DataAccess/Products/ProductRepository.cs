namespace ProductApp.DataAccess.Products;

public class ContactFormRepository(ProductAppDbContext context) : GenericRepository<Product>(context), IProductRepository
{
    public Task<IEnumerable<Product>> GetAllAsync(int count)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetTopProductsAsync(int count)
    {
        throw new NotImplementedException();
    }
}
