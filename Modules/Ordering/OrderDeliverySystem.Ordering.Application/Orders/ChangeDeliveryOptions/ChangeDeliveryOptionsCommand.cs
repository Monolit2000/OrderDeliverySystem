using Autofac.Core.Activators.Reflection;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.ChangeDeliveryOptions
{
    public class ChangeDeliveryOptionsCommand : IRequest<Result<ChangeDeliveryOptionsResult>>
    {
        public Guid OrderId { get; set; }

        public Guid OrderItmeId { get; set; }

        public DateTime? NewDeliveriDetaTime { get; set; } = default;

        public string? NewAddress { get; set; }
    }
}
