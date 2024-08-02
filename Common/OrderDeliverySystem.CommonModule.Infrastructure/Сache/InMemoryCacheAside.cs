using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderDeliverySystem.CommonModule.Infrastructure.Сache
{
    public static class InMemoryCacheAside
    {
        private static readonly MemoryCacheEntryOptions Default = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30) 
        };

        public static async Task<T?> GetOrCreateAsync<T>(
            this IMemoryCache cache,
            string key,
            Func<CancellationToken, Task<T>> factory,
            MemoryCacheEntryOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            if (cache.TryGetValue(key, out string? cacheValue))
            {
                T? value = JsonSerializer.Deserialize<T>(cacheValue, new JsonSerializerOptions { IncludeFields = true });
                if (value is not null)
                {
                    return value;
                }
            }

            var result = await factory(cancellationToken);

            if (result is null)
                return default;

            cache.Set(key, JsonSerializer.Serialize(result), options ?? Default);

            return result;
        }
    }
}
