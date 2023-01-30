using Domain.Models.ValueObjects;

namespace Domain.Models
{
    /// <summary>
    /// Represents a snapshot of the item that was ordered.
    /// If the product item details change, 
    /// details of  the item that was part of a completed order should not change.
    /// </summary>
    public class OrderItem : BaseEntity
    {
        public OrderedProduct OrderedProduct { get; set; }

        public decimal UnitPrice { get; private set; }

        public int Units { get; private set; }

        private OrderItem()
        {
            // required by EF
        }

        public OrderItem(OrderedProduct itemOrdered, decimal unitPrice, int units)
        {
            OrderedProduct = itemOrdered;
            UnitPrice = unitPrice;
            Units = units;
        }
    }
}
