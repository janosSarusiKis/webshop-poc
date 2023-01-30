using System.Collections.Generic;

namespace webshop.ViewModels
{
    public class OrderViewModel
    {
        public string Name { get; private set; }

        public Address ShipToAddress { get; private set; }

        public List<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();
    }
}
