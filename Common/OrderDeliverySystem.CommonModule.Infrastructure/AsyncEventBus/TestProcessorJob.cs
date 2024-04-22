using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus
{
    public class TestProcessorJob : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Console.Out.WriteLineAsync("TestProcessorJob");
        }
    }
}
