using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Carts.DeleteCart
{
    public class DeleteCartCommand : IRequest
    {
        public long Id { get; }
        public DeleteCartCommand(long id)
        {
            Id = id;
        }
    }
}
