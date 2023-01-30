using Domain.Models;
using System;

namespace webshop.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Category MapToEntity()
        {
            return new Category()
            {
                Id = Id,
                Name = Name,
            };
        }

        public CategoryViewModel MapFromEntity(Category category)
        {
            return new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
            };
        }
    }
}
