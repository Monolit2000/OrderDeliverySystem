﻿namespace OrderDeliverySystem.UserAccess.Api
{
    public interface IUserAccessApi
    {
        Task<UserResponse> GetUserAsync(Guid id);
    }

    public sealed record UserResponse(Guid UserId, string FirstName);
}
