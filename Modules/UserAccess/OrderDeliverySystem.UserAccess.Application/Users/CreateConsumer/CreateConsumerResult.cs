namespace OrderDeliverySystem.UserAccess.Application.Users.CreateConsumer
{
    public class CreateConsumerResult
    {

        public string AuthenticationError { get; }

        public UserDto Consumer { get; }

        public CreateConsumerResult(string authenticationError)
        {
            AuthenticationError = authenticationError;
        }

        public CreateConsumerResult(UserDto user)
        {
            Consumer = user;
        }

    }
}
