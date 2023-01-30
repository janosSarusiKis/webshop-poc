using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> CreateAsync(Category category);

        Task<Category> UpdateAsync(Category category);

        Task<bool> DeleteAsync(Category category);

        Task<Category> GetByIdAsync(Guid categoryId);

        Task<List<Category>> GetAll();
    }
}
