using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApp.DataAccess;
using ProductApp.DataAccess.Products;
using System.Net;


namespace ProductApp.Services.Products;

public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductService
{
    public async Task<ServiceResult<List<Product>>> GetTopProductsAsync(int count)
    {
        var products = await productRepository.GetTopProductsAsync(count);

        return new ServiceResult<List<Product>>()
        {
            Data = products,
        };
    }
    public async Task<ServiceResult<ProductDto>> GetProductByIdAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id);

        if (product is null)
        {
            ServiceResult<Product>.Fail("Product not found", HttpStatusCode.NotFound);
        }

        var productsDto = new ProductDto(product!.ProductName, product.Code, product.Price, product.DeletedDate, product.CreatedDate, product.IsDeleted, product.ImageUrl, product.UpdatedDate);

        return ServiceResult<ProductDto>.Success(productsDto!);
    }


    public void DeleteId(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest request, IFormFile image)
    {
        var product = new Product()
        {
            Code = request.Code,
            ProductName = request.ProductName,
            Price = request.Price,
            CreatedDate = DateTime.Now,
           
        };
        if (image != null)
        {
            var imagePath = Path.Combine("wwwroot/images", $"{Guid.NewGuid()}_{image.FileName}");
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
            product.ImageUrl = imagePath;
        }


        await productRepository.AddAsync(product);
        await unitOfWork.SaveChangeAsync();

        return ServiceResult<CreateProductResponse>.Success(new CreateProductResponse(product.Id));
    }

}


//[HttpPost]
//public async Task<IActionResult> AddProduct([FromForm] Product product, IFormFile image)
//{
//    if (image != null)
//    {
//        var imagePath = Path.Combine("wwwroot/images", $"{Guid.NewGuid()}_{image.FileName}");
//        using (var stream = new FileStream(imagePath, FileMode.Create))
//        {
//            await image.CopyToAsync(stream);
//        }
//        product.ImagePath = imagePath;
//    }

//    // Database'e kaydet
//    _context.Products.Add(product);
//    await _context.SaveChangesAsync();

//    return Ok(product);
//}
