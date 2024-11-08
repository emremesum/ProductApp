﻿namespace ProductApp.Services.Products
{
	public class ProductDto
	{
		public ProductDto(int id, string code, DateTime? deletedDate, DateTime createdDate, string productName, decimal price, DateTime? updatedDate, string imageUrl)
		{
			Id = id;
			Code = code;
			DeletedDate = deletedDate;
			CreatedDate = createdDate;
			ProductName = productName;
			Price = price;
			UpdatedDate = updatedDate;
			ImageUrl = imageUrl;
		}

		public int Id { get; init; }
		public string Code { get; init; } = default!;
		public string ProductName { get; init; } = default!;
		public decimal Price { get; init; }
		public DateTime CreatedDate { get; init; }
		public string ImageUrl { get; init; } = default!;
		public DateTime? UpdatedDate { get; init; }
		public DateTime? DeletedDate { get; init; }
	}
}
