using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.CommonModule.Infrastructure.Outbox
{
    public sealed class ConvertDomainEventsToOutboxMessageIterseptor : SaveChangesInterceptor
    {

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData, 
            InterceptionResult<int> result, 
            CancellationToken cancellationToken = default)
        {
            DbContext? dbContext = eventData.Context;

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

    }
}
