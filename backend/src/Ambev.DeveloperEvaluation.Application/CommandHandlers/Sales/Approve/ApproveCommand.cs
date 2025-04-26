using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Sales.Approve
{
    public class ApproveCommand : IRequest
    {
        public long Id { get; }
        public ApproveCommand(long id) 
        {
            Id = id;
        }
    }
}
