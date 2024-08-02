
namespace OrderDeliverySystem.Payments.Application.Payments.GetPaymentHistoryByDatRange
{
    public class PaymentHistoryDto
    {
        public Guid PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
