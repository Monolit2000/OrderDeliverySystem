using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Basket.Application.Basket.UpdateBaske;
using OrderDeliverySystem.Basket.Domain.Baskets;

namespace OrderDeliverySystem.Basket.Application.Basket.CreateBasket
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, CreateBasketResult>
    {
        private readonly IBasketRepository _basketRepository;

        public CreateBasketCommandHandler(IBasketRepository userRepository)
        {
            _basketRepository = userRepository;
        }

        public async Task<CreateBasketResult> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = new CustomerBasket(
                request.BuyerId
                );

            await Console.Out.WriteLineAsync($"BasketId - {basket.BasketId}");

            //await Task.Delay(TimeSpan.FromSeconds(30));

            var newbasket = new CustomerBasket(request.BuyerId, basket.BasketId);

            await _basketRepository.AddBasketAsync(newbasket);

            //var ExistBascket = await _basketRepository.GetBasketAsync(request.BuyerChatId);

            //await Console.Out.WriteLineAsync($"{ExistBascket.BuyerChatId} -> BasketId {ExistBascket.BasketId}");

            Console.WriteLine("-------");
            await Console.Out.WriteLineAsync($" {basket.BasketId}");
            //await Console.Out.WriteLineAsync($" {basket.BuyerChatId}");
            await Console.Out.WriteLineAsync($" {basket.BuyerId}");

            try 
            {

                await _basketRepository.SaveChangesAsync();

            }
            catch (DbUpdateException dbEx)
            {
                // Обработка исключений, связанных с базой данных
                Console.WriteLine("Database update error: " + dbEx.Message);
            }
            catch (Exception ex)
            {
                // Общая обработка исключений
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return new CreateBasketResult {BasketId = basket.BasketId};
        }
    }
}
