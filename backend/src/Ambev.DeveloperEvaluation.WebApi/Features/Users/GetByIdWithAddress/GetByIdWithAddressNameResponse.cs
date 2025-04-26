using StackExchange.Redis;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetByIdWithAddress
{
    public class GetByIdWithAddressNameResponse
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
    }
}
