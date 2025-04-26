using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Sales.Cancel
{
    public class CancelCommand : IRequest
    {
        public long Id { get; }
        public CancelCommand(long id)
        {
            Id = id;
        }
    }
}
