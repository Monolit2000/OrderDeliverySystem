using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrderDeliverySystem.Catalog.Domain.Catalog
{
    public class Establishment : Entity
    {
        
       
        public Guid EstablishmentId { get; set; } 

       // public Guid CatalogItemId { get; set; } 

        public string Name { get; set; }

        private Establishment()
        {
        }

        public Establishment(string name)
        {
            EstablishmentId = Guid.NewGuid();

            Name = name;    
        }

        public static Establishment Create(string name) 
        {
            return new Establishment(name); 
        }
    }
}
