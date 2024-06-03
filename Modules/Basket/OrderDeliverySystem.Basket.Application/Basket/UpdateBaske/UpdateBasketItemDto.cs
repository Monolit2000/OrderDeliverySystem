
namespace OrderDeliverySystem.Basket.Application.Basket.UpdateBaske
{
    public class UpdateBasketItemDto
    {
        public Guid BasketItemId { get; set; }
        public int Quantity { get; set; }
        public bool isDelivery { get; set; } = false;   
        public DateTime DelvieryTime { get; set; } = default(DateTime); 
    }
}
