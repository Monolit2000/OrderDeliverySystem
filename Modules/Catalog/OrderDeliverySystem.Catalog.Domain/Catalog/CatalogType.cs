using OrderDeliverySystem.CommonModule.Domain;
using System.ComponentModel.DataAnnotations;


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
