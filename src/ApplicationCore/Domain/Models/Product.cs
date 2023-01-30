using System;

namespace Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }


        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
