using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Domain.Baskets
{
    public class OptionalItem : ValueObject
    {
        public bool IsAdded { get; } = false;
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }

        public OptionalItem()
        {

        }
        public OptionalItem(
            bool isAdded,
            string name, 
            string description, 
            decimal price)
        {
            IsAdded = isAdded;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
