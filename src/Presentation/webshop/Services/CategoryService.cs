using Application.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webshop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IAsyncRepository<Category> _repository;

        public CategoryService(IAsyncRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<Category> CreateAsync(Category category) =>
            await _repository.AddAsync(category);

        public Task<bool> DeleteAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAll() => (await _repository.GetAllAsync()).ToList();

        public async Task<Category> GetByIdAsync(Guid categoryId) => await _repository.GetByIdAsync(categoryId);

        public Task<Category> UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
