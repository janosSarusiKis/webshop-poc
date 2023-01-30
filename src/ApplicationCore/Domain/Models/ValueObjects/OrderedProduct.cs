using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.ValueObjects
{
    public class OrderedProduct // ValueObject
    {
        public OrderedProduct(Guid productId, string productName, string pictureUri)
        {
            Guard.Against.NullOrEmpty(productId, nameof(productId));
            Guard.Against.NullOrEmpty(productName, nameof(productName));
            Guard.Against.NullOrEmpty(pictureUri, nameof(pictureUri));

            ProductId = productId;
            ProductName = productName;
            PictureUri = pictureUri;
        }

        private OrderedProduct()
        {
            // required by EF
        }

        public Guid ProductId { get; private set; }

        public string ProductName { get; private set; }

        public string PictureUri { get; private set; }

    }
}
