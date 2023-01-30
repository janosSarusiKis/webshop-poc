using Application.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webshop.Services
{
    public class ProductService : IProductService
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;

        public ProductService(
            IAsyncRepository<Product> productRepository,
            IAsyncRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }


        public async Task<Product> CreateAsync(Product product)
        {
            var category = await _categoryRepository.GetByIdAsync(product.CategoryId);
            if (category != null)
            {
                product.Id = Guid.NewGuid();
                product.Category = category;
                return await _productRepository.AddAsync(product);
            }

            return null;
        }

        public async Task<bool> DeleteByIdAsync(Guid productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            await _productRepository.DeleteAsync(product);

            return (await _productRepository.GetByIdAsync(productId)) == null;
        }

        public async Task<List<Product>> GetAll() => (await _productRepository.GetAllAsync()).ToList();

        public async Task<Product> GetByIdAsync(Guid productId) => await _productRepository.GetByIdAsync(productId);

        public async Task<Product> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
