using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Users.GetByIdWithAddress;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Users.GetByIdWithAddress
{
    public class GetByIdWithAddressCommand : IRequest<GetByIdWithAddressResult>
    {
        public Guid Id { get; }
        public GetByIdWithAddressCommand(Guid id)
        {
            Id = id;
        }
    }
}
