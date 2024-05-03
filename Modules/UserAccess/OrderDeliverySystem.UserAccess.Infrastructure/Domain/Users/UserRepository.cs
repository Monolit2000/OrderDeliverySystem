using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.UserAccess.Domain.Users;
using OrderDeliverySystem.UserAccess.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Infrastructure.Domain.Users
{
    public class UserRepository : IUserRepository
    {

        private UserAccessContext _userAccessContext;

        public UserRepository(UserAccessContext userAccessContext)
        {
            _userAccessContext = userAccessContext;
        }

        public async Task AddAsync(User user)
        {
            await _userAccessContext.Users.AddAsync(user);
            await _userAccessContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetGetOllActiveUser()
        {
            var users = await _userAccessContext.Users.Where(u => u.IsActivated).ToListAsync();

            return users;   
        }

        public Task GetUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task <User> GetUserByChatId(long chatId)
        {
            var user = await _userAccessContext.Users
               .FirstOrDefaultAsync(u => u.ChatId == chatId);

            return user;
        }

        public async Task<User> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            var user = await _userAccessContext.Users
                .FirstOrDefaultAsync(u => u.PhoneNumber.Number == phoneNumber);

            return user;
        }

        public async Task SaveChangesAsync()
        {
            await _userAccessContext.SaveChangesAsync();   
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
