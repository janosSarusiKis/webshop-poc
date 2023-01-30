using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateAsync(Product product);

        Task<Product> UpdateAsync(Product product);

        Task<bool> DeleteByIdAsync(Guid productId);

        Task<Product> GetByIdAsync(Guid productId);

        Task<List<Product>> GetAll();
    }
}
