using Azure.Core;
using LiqPay.SDK.Dto.Enums;
using LiqPay.SDK.Dto;
using LiqPay.SDK;
using OrderDeliverySystem.Payments.Application.Contract;
using Microsoft.Extensions.Configuration;

namespace OrderDeliverySystem.Payments.Infrastructure.Servises.Peyments
{
    public class LiqPayService(IConfiguration _config) : ILiqPayService
    {
        public string GeneratePaymentUrl(double amount, Guid orderId, string? description = null)
        {
            var paymentRequest = new LiqPayRequest
            {
                Amount = amount,
                Currency = "UAH",
                OrderId = orderId.ToString(),
                Action = LiqPayRequestAction.Pay,
                Language = LiqPayRequestLanguage.EN,
                ServerUrl = _config["ProcessorCallbackUrl"],
                Version = 3,
                Description = description ?? "Оплата послуг",
            };

            var liqPayClient = new LiqPayClient(
                _config["LiqPayPublicTestKey"],
                _config["LiqPayPrivateTestKey"]);

            liqPayClient.IsCnbSandbox = true;

            var paymentDetails = liqPayClient.GenerateDataAndSignature(paymentRequest);

            string сheckoutUri = $"https://www.liqpay.ua/api/3/checkout?data={Uri.EscapeDataString(paymentDetails.Key)}" +
                $"&signature={Uri.EscapeDataString(paymentDetails.Value)}";

            return сheckoutUri;
        }
    }
}
