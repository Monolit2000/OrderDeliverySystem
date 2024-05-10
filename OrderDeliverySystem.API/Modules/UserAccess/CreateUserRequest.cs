namespace OrderDeliverySystem.API.Modules.UserAccess
{
    public class CreateUserRequest
    {
        public string PhoneNumber { get; set; }
        public long ChatId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }
    }
}
