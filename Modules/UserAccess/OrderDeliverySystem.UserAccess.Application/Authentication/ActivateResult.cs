using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Authentication
{
    public class ActivateResult
    {
        public ActivateResult(string authenticationError)
        {
            IsAuthenticated = false;
            AuthenticationError = authenticationError;
        }

        public ActivateResult(UserDto user)
        {
            this.IsAuthenticated = true;
            this.User = user;
        }

        public bool IsAuthenticated { get; }

        public string AuthenticationError { get; }

        public UserDto User { get; }
    }
}
