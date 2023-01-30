using System.Collections.Generic;

namespace Domain.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
