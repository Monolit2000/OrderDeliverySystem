
namespace OrderDeliverySystem.Basket.Application.Basket.UpdateBaske
{
    public class UpdateBasketItemDto
    {
        public Guid BasketItemId { get; set; }
        public int Quantity { get; set; }
        public bool isDelivery { get; set; } = false;   
        public DateTime DelvieryTime { get; set; } = default(DateTime);


        public bool IsAdded { get; set; } = false;
        public string? OptionalItemName { get; set; }
        public string? OptionalItemDescription { get; set; }
        public decimal OptionalItemPrice { get; set; } = default;
    }
}
