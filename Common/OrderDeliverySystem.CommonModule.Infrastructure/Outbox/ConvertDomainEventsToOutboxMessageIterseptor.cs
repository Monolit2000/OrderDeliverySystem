﻿using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.CommonModule.Infrastructure.Outbox
{
    public sealed class ConvertDomainEventsToOutboxMessageIterseptor : SaveChangesInterceptor
    {
    }
}
