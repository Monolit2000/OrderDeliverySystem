using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OrderDeliverySystem.Basket.Application.Contracts
{
    public interface IBasketModule
    {
        Task<TResult> ExecuteCommandAsync<TResult>(IRequest<TResult> command);

        Task ExecuteCommandAsync(ICommand command);

        Task<TResult> ExecuteQueryAsync<TResult>(IRequest<TResult> query);
    }
}
