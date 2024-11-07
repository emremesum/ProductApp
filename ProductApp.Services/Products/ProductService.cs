using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProductApp.DataAccess;
using ProductApp.DataAccess.Products;
using System.Net;

namespace ProductApp.Services.Products;

public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductService
{
	public async Task<ServiceResult<List<ProductDto>>> GetAllListAsync()
	{

		var products = await productRepository.GetAll().ToListAsync();
		var productsDto = products.Where(x=>x.IsDeleted==false).Select(x => new ProductDto(x.Id, x.Code, x.DeletedDate, x.CreatedDate, x.ProductName, x.Price, x.UpdatedDate, x.ImageUrl)).ToList();
		return ServiceResult<List<ProductDto>>.Success(productsDto);
	}
	public async Task<ServiceResult<ProductDto?>> GetByIdAsync(int id)
	{
		var product = await productRepository.GetByIdAsync(id);

		if (product == null || product.IsDeleted == true)
		{
			return ServiceResult<ProductDto?>.Fail("Product not found", HttpStatusCode.NotFound);
		}
		var productDto = new ProductDto(
		product.Id,
		product.Code,
		product.DeletedDate,
		product.CreatedDate,
		product.ProductName,
		product.Price,
		product.UpdatedDate,
		product.ImageUrl
   );


		return ServiceResult<ProductDto?>.Success(productDto);
	}
	public async Task<ServiceResult> DeleteAsync(int id)
	{
		var product = await productRepository.GetByIdAsync(id);
		if (product == null)
		{
			return ServiceResult.Fail("Product not found", HttpStatusCode.NotFound);
		}

		if (product.IsDeleted == true)
		{
			return ServiceResult.Fail("Product is already deleted", HttpStatusCode.BadRequest);
		}

		product.IsDeleted = true;
		product.DeletedDate = DateTime.Now;

		productRepository.Update(product);
		await unitOfWork.SaveChangeAsync();

		return ServiceResult.Success();
	}
	public async Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest request)
	{
		var product = await productRepository.GetByIdAsync(id);

		if (product == null || product.IsDeleted == true)
		{
			return ServiceResult.Fail("Product not found", HttpStatusCode.NotFound);
		}
		product.ProductName = request.ProductName;
		product.Price = request.Price;
		product.UpdatedDate = DateTime.Now;
		product.ImageUrl = request.ImageUrl;
		product.Code = request.Code;

		productRepository.Update(product);
		await unitOfWork.SaveChangeAsync();

		return ServiceResult.Success();
	}
	public async Task<ServiceResult<CreateProductResponse>> CreateWithoutImageAsync(CreateProductRequest request)
	{

		var product = new Product()
		{
			Code = request.Code,
			ProductName = request.ProductName,
			Price = request.Price,
			CreatedDate = DateTime.Now,
			DeletedDate = DateTime.Now,
			ImageUrl = request.ImageUrl,
			UpdatedDate = DateTime.Now,
			IsDeleted = false,

		};

		await productRepository.AddAsync(product);
		await unitOfWork.SaveChangeAsync();

		return ServiceResult<CreateProductResponse>.Success(new CreateProductResponse(product.Id));
	}


	public async Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request, IFormFile image)
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
