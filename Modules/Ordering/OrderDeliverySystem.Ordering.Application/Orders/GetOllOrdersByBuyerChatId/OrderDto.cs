﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.GetOllOrdersByBuyerChatId
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }

        public Guid BuyerId { get; set; }

        public string Status { get; set; } 

        public DateTime Created { get; set; }

        public string Description { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } = [];
    }
}
