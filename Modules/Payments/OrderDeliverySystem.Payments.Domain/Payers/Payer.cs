using FluentResults;
using OrderDeliverySystem.CommonModule.Domain;

namespace OrderDeliverySystem.Payments.Domain.Payers
{
    public class Payer : Entity, IAggregateRoot
    {
        public PayerId Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        private Payer() { } //For EF Core 

        private Payer(
            PayerId id, 
            string name,
            string email, 
            string phoneNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public static Result<Payer> Create(
            PayerId id,
            string name,
            string email,
            string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Fail("Name cannot be empty.");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                return Result.Fail("Invalid email.");

            if (string.IsNullOrWhiteSpace(phoneNumber))
                return Result.Fail("Phone number cannot be empty.");

            var payer = new Payer(
                id, 
                name,
                email, 
                phoneNumber);

            return Result.Ok(payer);
        }

        public Result UpdateContactInfo(
            string email,
            string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                return Result.Fail("Invalid email.");

            if (string.IsNullOrWhiteSpace(phoneNumber))
                return Result.Fail("Phone number cannot be empty.");

            Email = email;
            PhoneNumber = phoneNumber;
            return Result.Ok();
        }

        public Result UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Fail("Name cannot be empty.");

            Name = name;
            return Result.Ok();
        }
    }
}
