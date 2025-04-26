using Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.UpdateUser;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser
{
    public class UpdateUserProfile : Profile
    {
        public UpdateUserProfile() 
        {
            CreateMap<UpdateUserRequest, UpdateUserCommand>();
            CreateMap<CreateUserNameRequest, UpdateUserNameDto>();
            CreateMap<CreateUserAddressRequest, UpdateUserAddressDto>();
        }
    }
}
