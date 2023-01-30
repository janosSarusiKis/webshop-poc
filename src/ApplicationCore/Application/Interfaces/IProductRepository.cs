using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<List<Product>> GetAllWithCategory();
    }
}
