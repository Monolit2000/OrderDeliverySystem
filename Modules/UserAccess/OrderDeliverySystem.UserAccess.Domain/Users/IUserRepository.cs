using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Domain.Users
{
    public interface IUserRepository
    {
        Task AddAsyncAsync(User user);

        Task UpdateAsync(User user);

        Task GetUserAsync(User user);

        Task <User> GetUserByPhoneNumberAsync(string PhoneNumber);

        Task GetUserByChatId(long chatId);
    }
}
