using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Sales.Cancel
{
    public class CancelHandler : IRequestHandler<CancelCommand>
    {

        private readonly ISaleRepository _saleRepository;

        public CancelHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task Handle(CancelCommand request, CancellationToken cancellationToken)
        {
            var validator = new CancelValidator();
            var validatorResult = validator.Validate(request);
            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult.Errors);

            var sale = await _saleRepository.GetByIdAsync(request.Id);
            if(sale == null)
                throw new KeyNotFoundException($"Key with ID {request.Id} not found.");

            sale.Cancel();

            await _saleRepository.UpdateAsync(sale);
        }
    }
}
