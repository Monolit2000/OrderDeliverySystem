using MediatR;
using OrderDeliverySystem.Basket.Application.Contracts;
using OrderDeliverySystem.Basket.Infrastructure.Configuration;
using OrderDeliverySystem.Basket.Infrastructure.Configuration.Processing;

using System.Windows.Input;
using Autofac;

namespace OrderDeliverySystem.Basket.Infrastructure
{
    public class BasketModule : IBasketModule
    {
        public async Task<TResult> ExecuteCommandAsync<TResult>(IRequest<TResult> command)
        {
            return await CommandsExecutor.Execute(command);
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            await CommandsExecutor.Execute(command);
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IRequest<TResult> query)
        {
            using (var scope = BasketCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(query);
            }
        }
    }
}
