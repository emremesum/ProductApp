

namespace ProductApp.DataAccess.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public string ProductName { get; set; } = default!;
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImageUrl { get; set; } = default!;
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; } = false;
    }
}
