namespace OrderDeliverySystem.API.Modules.UserAccess
{
    public class ActivateUserRequest
    {
        public string PhoneNumber { get; set; }
        public long ChatId { get; set; }
    }
}
