using Ambev.DeveloperEvaluation.Application.CommandHandlers.Sales.Approve;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Approve
{
    public class ApproveProfile : Profile
    {
        public ApproveProfile()
        {
            CreateMap<ApproveRequest, ApproveCommand>();
        }
    }
}
