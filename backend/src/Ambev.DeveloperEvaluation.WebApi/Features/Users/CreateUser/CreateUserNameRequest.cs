using StackExchange.Redis;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser
{
    public class CreateUserNameRequest
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
    }
}
