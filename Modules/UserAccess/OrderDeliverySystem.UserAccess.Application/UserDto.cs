namespace OrderDeliverySystem.UserAccess.Application
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsActivated;

        public long ChatId;

        public string Name { get; set; }

        public string Role { get; set; }

    }
}
