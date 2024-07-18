using OrderDeliverySystem.CommonModule.Domain;


namespace OrderDeliverySystem.Payments.Domain.Payments
{
    public class OrderId : TypedIdValueBase
    {
        public OrderId(Guid value) 
            : base(value)
        {

        }
    }
}
