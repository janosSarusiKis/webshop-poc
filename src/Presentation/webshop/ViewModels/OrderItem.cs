using System;

namespace webshop.ViewModels
{
    public class OrderItem
    {
        public Guid ProductId { get; set; }

        public int Units { get; private set; }
    }
}
