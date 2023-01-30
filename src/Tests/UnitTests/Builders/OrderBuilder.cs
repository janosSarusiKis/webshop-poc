using Domain.Models;
using Domain.Models.ValueObjects;
using System;
using System.Collections.Generic;

namespace UnitTests.Builders
{
    public class OrderBuilder
    {
        private Order _order;
        public string TestBuyerName => "Test Buyer";
        public Guid TestProductId => Guid.NewGuid();
        public string TestProductName => "Test Product Name";
        public string TestPictureUri => "http://test.com/image.jpg";
        public decimal TestUnitPrice = 1.23m;
        public int TestUnits = 3;
        public OrderedProduct TestProductOrdered { get; }

        public OrderBuilder()
        {
            TestProductOrdered = new OrderedProduct(TestProductId, TestProductName, TestPictureUri);
            _order = WithDefaultValues();
        }
        public Order Build()
        {
            return _order;
        }
        public Order WithDefaultValues()
        {
            var orderItem = new OrderItem(TestProductOrdered, TestUnitPrice, TestUnits);
            var itemList = new List<OrderItem>() { orderItem };
            _order = new Order(TestBuyerName, new AddressBuilder().WithDefaultValues(), itemList);
            return _order;
        }

        public Order WithNoItems()
        {
            _order = new Order(TestBuyerName, new AddressBuilder().WithDefaultValues(), new List<OrderItem>());
            return _order;
        }

        public Order WithItems(List<OrderItem> items)
        {
            _order = new Order(TestBuyerName, new AddressBuilder().WithDefaultValues(), items);
            return _order;
        }
    }
}
