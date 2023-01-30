using Ardalis.GuardClauses;
using Domain.Models.ValueObject;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Order : BaseEntity
    {
        public string Name { get; private set; }

        public Address ShipToAddress { get; private set; }

        public DateTime OrderDate { get; private set; } = DateTime.Now;

        public DateTime? CompletitionDate { get; private set; }

        public List<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();

        private Order()
        {
            // required by EF
        }

        public Order(string name, Address shipToAddress, List<OrderItem> items)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.Null(shipToAddress, nameof(shipToAddress));
            Guard.Against.Null(items, nameof(items));

            Name = name;
            ShipToAddress = shipToAddress;
            OrderItems = items;
        }

        public decimal Total()
        {
            var total = 0m;
            foreach (var item in OrderItems)
            {
                total += item.UnitPrice * item.Units;
            }
            return total;
        }

        public void CompletedNow()
        {
            CompletitionDate = DateTime.Now;
        }
    }
}
