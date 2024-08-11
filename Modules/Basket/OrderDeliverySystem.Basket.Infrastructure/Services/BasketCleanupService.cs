using OrderDeliverySystem.Basket.Domain.Baskets;

public class BasketCleanupService
{
    private readonly IBasketRepository _basketRepository;

    public BasketCleanupService(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task CleanUpOldItems(DateTime currentDate)
    {
        var baskets = await _basketRepository.GetAllBasketsAsync();
        var nextDay = currentDate.AddDays(1).Date;

        foreach (var basket in baskets)
        {
            var itemsToRemove = basket.Items
                .Where(item => item.Day < nextDay)
                .ToList();

            foreach (var item in itemsToRemove)
            {
                basket.RemoveItem(item.BasketItemId);
            }

            if (itemsToRemove.Any())
            {
                await _basketRepository.SaveChangesAsync();
            }
        }
    }
}
