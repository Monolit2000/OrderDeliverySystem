using Autofac;
using MediatR;
using OrderDeliverySystem.CommonModule.Infrastructure;
using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Infrastructure.Configuration.Processing
{
    internal class ProcessingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //builder.RegisterType<UnitOfWork>()
            //    .As<IUnitOfWork>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<AsyncEventBus>()
            //    .As<IAsyncEventBus>() 
            //    .SingleInstance();


            //    builder.RegisterType<InMemoryMessageQueue>()
            //    .SingleInstance();

            //builder.RegisterGenericDecorator(
            //    typeof(UnitOfWorkCommandHandlerDecorator<>),
            //    typeof(IRequestHandler<>));

            //builder.RegisterGenericDecorator(
            //     typeof(UnitOfWorkCommandHandlerWithResultDecorator<,>),
            //     typeof(IRequestHandler<,>));


        }
    }
}
