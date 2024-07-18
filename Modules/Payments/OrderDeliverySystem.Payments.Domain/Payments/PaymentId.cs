using OrderDeliverySystem.CommonModule.Domain;

namespace OrderDeliverySystem.Payments.Domain.Payments
{
    public class PaymentId : TypedIdValueBase
    {
        public PaymentId(Guid value) 
            : base(value)
        {
                
        }
    }
}
