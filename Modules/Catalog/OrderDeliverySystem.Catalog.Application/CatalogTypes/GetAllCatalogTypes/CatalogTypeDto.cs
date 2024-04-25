using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogTypes.GetAllCatalogTypes
{
    public class CatalogTypeDto
    {
        public Guid CatalogTypeId { get; set; }

        public string Type { get; set; }

        //public CatalogTypeDto(Guid catalogTypeId, string type)
        //{
        //    CatalogTypeId = catalogTypeId;
        //    Type = type;
        //}
    }
}
