using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Sales.Approve
{
    public class ApproveHandler : IRequestHandler<ApproveCommand>
    {
        private ISaleRepository _saleRepository;
        public ApproveHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        public async Task Handle(ApproveCommand request, CancellationToken cancellationToken)
        {
            var validator = new ApproveValidator();
            var validatorResult = validator.Validate(request);
            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult.Errors);

            var saleDb = await _saleRepository.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException("Sale not found.");

            saleDb.Approve();

            await _saleRepository.UpdateAsync(saleDb);
            return;
        }
    }
}
