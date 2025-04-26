using Ambev.DeveloperEvaluation.Application.CommandHandlers.Sales.Cancel;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Cancel
{
    public class CancelProfile : Profile
    {
        public CancelProfile()
        {
            CreateMap<CancelRequest, CancelCommand>();
        }
    }
}
