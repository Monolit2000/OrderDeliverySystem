using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Domain.Catalog
{
    public class OptionItem : ValueObject
    {
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }

        public OptionItem()
        {
            
        }
        public OptionItem(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
