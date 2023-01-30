using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateAsync(Order Order);

        Task<Order> UpdateAsync(Order Order);

        Task<bool> DeleteAsync(Order Order);

        Task<Order> GetByIdAsync(Guid OrderId);
    }
}
