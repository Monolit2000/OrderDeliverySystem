using FluentResults;
using LiqPay.SDK.Dto;

namespace OrderDeliverySystem.Payments.Application.Contract
{
    public interface ICallbackProcessingServise
    {
        public Task<Result<LiqPayResponse>> ProcessCallback(string data, string signature);
    }
}
