using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.Establishments.AddEstablishment
{
    public class AddEstablishmentDto
    {
        public Guid EstablishmentId { get; set; }    
        public string Name { get; set; }    
    }
}
