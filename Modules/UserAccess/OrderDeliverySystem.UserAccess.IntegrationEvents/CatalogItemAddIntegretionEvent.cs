﻿using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.IntegrationEvents
{
    public class CatalogItemAddIntegretionEvent : IntegrationEvent
    {
        public CatalogItemAddIntegretionEvent() 
        {
        }
    }
}
