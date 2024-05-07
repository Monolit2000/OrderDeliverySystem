using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Domain.Users
{
    public interface IUserRepository
    {
        public Task AddAsync(User user);

        public Task UpdateUserAsync(User user);

        public Task GetUserAsync(User user);

        public Task<User> GetUserByPhoneNumberAsync(string PhoneNumber);

        public Task<User> GetUserByChatId(long chatId);

        public Task<List<User>> GetGetOllActiveUser();

        public Task SaveChangesAsync();
    }
}
