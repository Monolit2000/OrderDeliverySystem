using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OrderDeliverySystem.Basket.Application.Contracts;
using System.Windows.Input;


namespace OrderDeliverySystem.Basket.Infrastructure
{
    public class BasketModule : IBasketModule
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMediator _mediator;

        public BasketModule(IServiceProvider serviceProvider, IMediator mediator)
        {
            _serviceProvider = serviceProvider;
            _mediator = mediator;
        }

        public async Task<TResult> ExecuteCommandAsync<TResult>(IRequest<TResult> command)
        {
            return await _mediator.Send(command);
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            //await CommandsExecutor.Execute(command);
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IRequest<TResult> query)
        {
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
