using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using OrderDeliverySystem.Basket.Application.Contracts;

namespace OrderDeliverySystem.Basket.Infrastructure.Configuration
{
    internal class Assemblies
    {
        public static readonly Assembly Application = typeof(IBasketModule).Assembly;
    }
}
