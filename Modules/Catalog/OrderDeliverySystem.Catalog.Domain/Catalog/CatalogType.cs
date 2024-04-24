using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Domain.Catalog
{
    public class CatalogType : Entity
    {
      
        public Guid CatalogTypeId { get; set; }


        [Required]
        public string Type { get; set; }

        public CatalogType()
        {
                
        }

        public CatalogType(string type)
        {
            CatalogTypeId = Guid.NewGuid();
            Type = type;
        }
    }
}
