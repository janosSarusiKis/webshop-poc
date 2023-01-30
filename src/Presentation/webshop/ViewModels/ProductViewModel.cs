using Domain.Models;
using System;

namespace webshop.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }

        public string CategoryName { get; set; }

        public Guid? CategoryId { get; set; }

        public Product MapToEntity()
        {
            return new Product()
            {
                Name = Name,
                Description = Description,
                Price = Price,
                ImageUrl = ImageUrl,
                CategoryId = CategoryId.Value,
            };
        }

        public ProductViewModel MapFromEntity(Product product)
        {
            return new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryId = product.Category?.Id,
                CategoryName = product.Category?.Name,
            };
        }
    }
}
