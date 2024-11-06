using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.DataAccess.Products
{
    public class ProductRepository(ProductAppDbContext context) : GenericRepository<Product>(context), IProductRepository
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
}
