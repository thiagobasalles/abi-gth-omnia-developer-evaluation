using Ambev.DeveloperEvaluation.Application.CommandHandlers.Sales.PreApprove;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.PreApprove
{
    public class PreApproveProfile : Profile
    {
        public PreApproveProfile()
        {
            CreateMap<PreApproveRequest, PreApproveCommand>();

            CreateMap<PreApproveResult, PreApproveResponse>();
            CreateMap<PreApproveItemResult, PreApproveItemResponse>();
        }
    }
}
