using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Services.Products
{


    public record ProductDto
    {
        public ProductDto(string productName, string code, decimal price, DateTime? deletedDate, DateTime createdDate, bool? isDeleted, string imageUrl, DateTime? updatedDate)
        {
            ProductName = productName;
            Code = code;
            Price = price;
            DeletedDate = deletedDate;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            IsDeleted = isDeleted;
            ImageUrl = imageUrl;
        }

        public string Code { get; init; } = default!;
        public string ProductName { get; init; } = default!;
        public decimal Price { get; init; }
        public DateTime CreatedDate { get; init; }
        public string ImageUrl { get; init; } = default!;
        public DateTime? UpdatedDate { get; init; }
        public DateTime? DeletedDate { get; init; }
        public bool? IsDeleted { get; init; }

    }
}
