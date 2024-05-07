using OrderDeliverySystem.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.GetUserByChatId
{
    public class UserDto
    {
        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public string Address { get; set; }

        public bool IsActivated { get; set; }

        public long ChatId { get; set; }


        public UserDto(Guid userId, string firstName, string lastName, string name,
                string phoneNumber, string role, string address, bool isActivated, long chatId)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Name = name;
            PhoneNumber = phoneNumber;
            Role = role;
            Address = address;
            IsActivated = isActivated;
            ChatId = chatId;
        }

    }
}
