using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.GetCartById
{
    public class GetCartByIdCommand : IRequest<GetCartByIdResult>
    {
        public long Id { get; }
        public GetCartByIdCommand(long id)
        {
            Id = id;
        }
    }
}
