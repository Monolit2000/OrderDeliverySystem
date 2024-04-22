using Autofac;
using MediatR;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using OrderDeliverySystem.UserAccess.Application.Contracts;
using OrderDeliverySystem.UserAccess.Infrastructure.Configuration;
using OrderDeliverySystem.UserAccess.Infrastructure.Configuration.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OrderDeliverySystem.UserAccess.Infrastructure
{
    public class UserAccessModule : IUserAccessModule
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMediator _mediator;

        public UserAccessModule(IServiceProvider serviceProvider, IMediator mediator)
        {
            _serviceProvider = serviceProvider;
            _mediator = mediator;
        }

        public async Task<TResult> ExecuteCommandAsync<TResult>(IRequest<TResult> command)
        {
            //using var scope = _serviceProvider.CreateScope();

            //var mediator = GetMediatorServices(scope);

            return await _mediator.Send(command);
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            //await CommandsExecutor.Execute(command);
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IRequest<TResult> query)
        {

            //using var scope = _serviceProvider.CreateScope();

            //var mediator = GetMediatorServices(scope);

            return await _mediator.Send(query);

        }

        private IMediator GetMediatorServices(IServiceScope scope)
        {

            var mediator = scope.ServiceProvider.GetService<IMediator>();
            if (mediator == null)
                throw new ArgumentNullException(nameof(IMediator), "Cant resolve IMediator from service provider");

            return mediator;
        }
    }
}
