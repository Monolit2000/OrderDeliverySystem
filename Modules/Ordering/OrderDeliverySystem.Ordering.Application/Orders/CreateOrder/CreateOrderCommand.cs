using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using MediatR;

namespace OrderDeliverySystem.Ordering.Application.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<Result<CreateOrderDto>>
    {
        public Guid UserId { get; set;}

        public long ChatId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adderss { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }
    }
}
