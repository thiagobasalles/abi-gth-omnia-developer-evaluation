using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CommandHandlers.Products.GetByIdWithRating
{
    public class GetByIdWithRatingHandler : IRequestHandler<GetByIdWithRatingCommand, GetByIdWithRatingResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetByIdWithRatingHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<GetByIdWithRatingResult> Handle(GetByIdWithRatingCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetByIdWithRatingValidator();
            var validatorResult = validator.Validate(request);
            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult.Errors);

            var productDb = await _productRepository.GetByIdWithRatingAsync(request.Id, cancellationToken);

            var result = _mapper.Map<GetByIdWithRatingResult>(productDb);
            return result;
        }
    }
}
