using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Sales.PreApprove
{

    public class PreApproveCommand : IRequest<PreApproveResult>
    {
        public long CartId { get; }

        public long BranchId { get; }
        public PreApproveCommand(long cartId, long branchId)
        {
            CartId = cartId;
            BranchId = branchId;
        }
    }
}
