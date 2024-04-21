using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus
{
    public interface IAsyncEventBus
    {

       public Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken = default) 
            where T : class, IIntegrationEvent;

    }

}
