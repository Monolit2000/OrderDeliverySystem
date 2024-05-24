using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.CreateOrder
{
    public class CreateOrderDto
    {
        public Guid OrderId { get; set; }

        public string CheckoutUrl { get; set; }  

        public CreateOrderDto(Guid orderId, string getCheckoutUrl)
        {
            OrderId = orderId;
            CheckoutUrl = getCheckoutUrl;
        }
    }
}
