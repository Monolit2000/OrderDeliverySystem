using FluentResults;
using MediatR;

namespace OrderDeliverySystem.UserAccess.Application.Users.ChangeFirstName
{
    public class ChangeFirstNameDto 
    {
        public string OldFirstName { get; set; }    

        public string NewFirstName { get; set; }

        public ChangeFirstNameDto(string oldFirstName, string newFirstName)
        {
            OldFirstName = oldFirstName;
            NewFirstName = newFirstName;
        }
    }
}